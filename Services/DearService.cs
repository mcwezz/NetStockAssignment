using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetStockAssignment.Configuration;
using NetStockAssignment.CsvHelper.Models;
using NetStockAssignment.CsvHelper.Services;
using NetStockAssignment.Models.DearSystems;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

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
		private readonly CsvOptions _csvOptions;

		public DearService(
			 IHttpClientFactory httpClientFactory,
			 ILogger<DearService> logger,
			 ICsvFileBuilder csvFileBuilder,
			IOptions<DearOptions> demoOptions,
			IOptions<ExtraOptions> extraOptions,
			IOptions<CsvOptions> csvOptions
		)
		{
			_httpClientFactory = httpClientFactory;
			_logger = logger;
			_csvFileBuilder = csvFileBuilder;
			_options = demoOptions.Value;
			_extraOptions = extraOptions.Value;
			_csvOptions = csvOptions.Value;
		}

		public async Task<bool> DoWork()
		{
			if (!_options.Enabled || string.IsNullOrEmpty(_options.AccountID) || string.IsNullOrEmpty(_options.AppKey) || string.IsNullOrEmpty(_csvOptions.Directory))
			{
				_logger.LogInformation("Service is not enabled or missing values in config options. Aborted.");
				return false;
			}

			//TODO move this code to Startup
			if (!Directory.Exists(_csvOptions.Directory))
			{
				Directory.CreateDirectory(_csvOptions.Directory);
			}

			// we can inject and use as many option objects we want
			_logger.LogInformation($"Current consoleId: {_extraOptions.ConsoleId}");

			// IHttpClientFactory is the suggested way to create an HttpClient
			HttpClient httpClient = _httpClientFactory.CreateClient();
			httpClient.BaseAddress = _options.Url;

			httpClient.DefaultRequestHeaders.Add("api-auth-accountid", _options.AccountID);
			httpClient.DefaultRequestHeaders.Add("api-auth-applicationkey", _options.AppKey);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response;
			//-----------------------------------------------------------------------------------------------------------------
			//				Download Products
			//-----------------------------------------------------------------------------------------------------------------
			List<ProductMaster> csvProductMaster = new List<ProductMaster>();
			ProductsRoot allProducts = new();
			allProducts.Products = new List<Product>();

			for (int i = 1; i < 1000; i++)
			{
				response = await httpClient.GetAsync("product?page=" + i + "&limit=100");
				ProductsRoot products = JsonSerializer.Deserialize<ProductsRoot>(await response.Content.ReadAsByteArrayAsync());

				if (response.StatusCode != System.Net.HttpStatusCode.OK || products.Products.Count == 0)
				{
					break;
				}
				allProducts.Products.AddRange(products.Products);
			}
			foreach (var product in allProducts.Products)
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
			var pmSuccess = _csvFileBuilder.ExportProducts(csvProductMaster, _csvOptions.Directory);

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
				csvLocationRow.Description = loc.Name.Length > 255 ? loc.Name.Substring(0, 255) : loc.Name;
				csvLocationRow.Active = !loc.IsDeprecated;
				csvLocationRow.Group = "";
				csvLocationRow.Type = "";

				csvLocations.Add(csvLocationRow);

			}

			//Write to CSV
			var locSuccess = _csvFileBuilder.ExportLocations(csvLocations, _csvOptions.Directory);

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
			var suppliersSuccess = _csvFileBuilder.ExportSuppliers(csvSuppliers, _csvOptions.Directory);

			_logger.LogInformation($"{nameof(DoWork)} completed.");



			return true;
		}
	}
}
