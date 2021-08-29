using NetStockAssignment.CsvHelper.Maps;
using NetStockAssignment.CsvHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;

namespace NetStockAssignment.CsvHelper.Services
{
	public interface ICsvFileBuilder
	{
		bool ExportProducts(IEnumerable<ProductMaster> products);
		bool ExportLocations(IEnumerable<Locations> locations);
		bool ExportSuppliers(IEnumerable<Suppliers> suppliers);

	}
	class CsvFileBuilder : ICsvFileBuilder
	{

		public bool ExportLocations(IEnumerable<Locations> locations)
		{

			CsvConfiguration config = new(CultureInfo.InvariantCulture);
			config.HasHeaderRecord = false;
			config.ShouldQuote = (field) => {
				if (field.FieldType == typeof(string))
				{
					return true;
				}
				return false;
			};
			using (var writer = new StreamWriter("C:\\DearSystems\\location.csv"))
			using (var csv = new CsvWriter(writer, config))
			{
				csv.Context.RegisterClassMap<LocationsMap>();

				csv.WriteRecords(locations);
			}

			return true;
		}

		public bool ExportSuppliers(IEnumerable<Suppliers> suppliers)
		{

			CsvConfiguration config = new(CultureInfo.InvariantCulture);
			config.HasHeaderRecord = false;
			config.ShouldQuote = (field) => {
				if (field.FieldType == typeof(string))
				{
					return true;
				}
				return false;
			};
			using (var writer = new StreamWriter("C:\\DearSystems\\supplier.csv"))
			using (var csv = new CsvWriter(writer, config))
			{
				csv.Context.RegisterClassMap<SuppliersMap>();

				csv.WriteRecords(suppliers);
			}

			return true;
		}

		public bool ExportProducts(IEnumerable<ProductMaster> products)
		{

			CsvConfiguration config = new(CultureInfo.InvariantCulture);
			config.HasHeaderRecord = false;
			config.ShouldQuote = (field) => {
				if (field.FieldType == typeof(string))
				{
					return true;
				}
				return false;
			}; 
			using (var writer = new StreamWriter("C:\\DearSystems\\master.csv"))
			using (var csv = new CsvWriter(writer,config))
			{
				csv.Context.RegisterClassMap<ProductMasterMap>();

				csv.WriteRecords(products);
			}

			return true;
		}

	}
}
