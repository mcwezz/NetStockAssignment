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
		bool ExportProducts(IEnumerable<ProductMaster> products, string dir);
		bool ExportLocations(IEnumerable<Locations> locations, string dir);
		bool ExportSuppliers(IEnumerable<Suppliers> suppliers, string dir);

	}
	class CsvFileBuilder : ICsvFileBuilder
	{

		public bool ExportLocations(IEnumerable<Locations> locations,string dir)
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
			using (var writer = new StreamWriter(dir+"location.csv"))
			using (var csv = new CsvWriter(writer, config))
			{
				csv.Context.RegisterClassMap<LocationsMap>();

				csv.WriteRecords(locations);
			}

			return true;
		}

		public bool ExportSuppliers(IEnumerable<Suppliers> suppliers, string dir)
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
			using (var writer = new StreamWriter(dir + "supplier.csv"))
			using (var csv = new CsvWriter(writer, config))
			{
				csv.Context.RegisterClassMap<SuppliersMap>();

				csv.WriteRecords(suppliers);
			}

			return true;
		}

		public bool ExportProducts(IEnumerable<ProductMaster> products, string dir)
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
			using (var writer = new StreamWriter(dir + "master.csv"))
			using (var csv = new CsvWriter(writer,config))
			{
				csv.Context.RegisterClassMap<ProductMasterMap>();

				csv.WriteRecords(products);
			}

			return true;
		}

	}
}
