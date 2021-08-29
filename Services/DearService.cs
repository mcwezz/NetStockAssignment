using NetStockAssignment.Configuration;
using NetStockAssignment.Models.DearSystems;
using NetStockAssignment.CsvHelper.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using NetStockAssignment.CsvHelper.Services;
using System.IO;
using CsvHelper;
using System.Globalization;
using System;

namespace NetStockAssignment.Services
{
	public interface IDearService
	{
		Task<bool> DoWork();
	}

	public class DearService : IDearService
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILogger<DearService> _logger;
		private readonly ICsvFileBuilder _csvFileBuilder;
		private readonly DearOptions _options;
		private readonly ExtraOptions _extraOptions;

		public DearService(
			 IHttpClientFactory httpClientFactory,
			 ILogger<DearService> logger,
			 ICsvFileBuilder csvFileBuilder,
			IOptions<DearOptions> demoOptions,
			IOptions<ExtraOptions> extraOptions
		)
		{
			_httpClientFactory = httpClientFactory;
			_logger = logger;
			_csvFileBuilder = csvFileBuilder;
			_options = demoOptions.Value;
			_extraOptions = extraOptions.Value;
		}

		public async Task<bool> DoWork()
		{
			if (!_options.Enabled)
			{
				_logger.LogInformation("Service is not enabled in config options. Aborted.");
				return false;
			}

			// we can inject and use as many option objects we want
			_logger.LogInformation($"Current consoleId: {_extraOptions.ConsoleId}");

			// IHttpClientFactory is the suggested way to create an HttpClient
			HttpClient httpClient = _httpClientFactory.CreateClient();
			httpClient.BaseAddress = _options.Url;

			httpClient.DefaultRequestHeaders.Add("api-auth-accountid", _options.AccountID);
			httpClient.DefaultRequestHeaders.Add("api-auth-applicationkey", _options.AppKey);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			//-----------------------------------------------------------------------------------------------------------------
			//				Download Products
			//-----------------------------------------------------------------------------------------------------------------
			var response = await httpClient.GetAsync("product");
			ProductsRoot products = JsonSerializer.Deserialize<ProductsRoot>(await response.Content.ReadAsByteArrayAsync());

			List<ProductMaster> csvProductMaster = new List<ProductMaster>();
			foreach(var product in products.Products)
			{
				var csvProductRow = new ProductMaster();
				csvProductRow.Code = product.SKU;
				csvProductRow.Description = product.ShortDescription;
				csvProductRow.UniqueIdentifier = product.ID;
				csvProductRow.UoM = product.UOM;
				//csvProductRow.UnitVolume =  Convert.ToDecimal(product.Weight, CultureInfo.InvariantCulture);
				csvProductRow.UnitWeight = Convert.ToDecimal(product.Weight, CultureInfo.InvariantCulture);

				csvProductMaster.Add(csvProductRow);
			}

			//Write to CSV
			var pmSuccess = _csvFileBuilder.ExportProducts(csvProductMaster);

			//-----------------------------------------------------------------------------------------------------------------
			//				Download Locations
			//-----------------------------------------------------------------------------------------------------------------

			response = await httpClient.GetAsync("ref/location");
			LocationsRoot locations = JsonSerializer.Deserialize<LocationsRoot>(await response.Content.ReadAsByteArrayAsync());

			List<Locations> csvLocations = new List<Locations>();
			foreach (var loc in locations.LocationList)
			{
				var csvLocationRow = new Locations();
				csvLocationRow.Code = loc.ID;
				csvLocationRow.Description = loc.Name;
				csvLocationRow.Active = !loc.IsDeprecated;
				csvLocationRow.Group = "";
				csvLocationRow.Type = "";

				csvLocations.Add(csvLocationRow);

			}

			//Write to CSV
			var locSuccess = _csvFileBuilder.ExportLocations(csvLocations);

			//-----------------------------------------------------------------------------------------------------------------
			//				Download Suppliers
			//-----------------------------------------------------------------------------------------------------------------

			response = await httpClient.GetAsync("supplier");
			SuppliersRoot suppliers = JsonSerializer.Deserialize<SuppliersRoot>(await response.Content.ReadAsByteArrayAsync());

			List<Suppliers> csvSuppliers = new List<Suppliers>();
			foreach (var supplier in suppliers.SupplierList)
			{
				var csvSupplierRow = new Suppliers();

				csvSupplierRow.Code = supplier.ID;
				csvSupplierRow.Description = supplier.Name;
				csvSupplierRow.LeadTime = 0;
				csvSupplierRow.Type = "";

				csvSuppliers.Add(csvSupplierRow);

			}

			//Write to CSV
			var suppliersSuccess = _csvFileBuilder.ExportSuppliers(csvSuppliers);

			_logger.LogInformation($"{nameof(DoWork)} completed.");



			return true;
		}
	}
}
