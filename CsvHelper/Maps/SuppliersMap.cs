using NetStockAssignment.CsvHelper.Models;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStockAssignment.CsvHelper.Maps
{
	public class SuppliersMap : ClassMap<Suppliers>
	{
		public SuppliersMap()
		{
			AutoMap(CultureInfo.InvariantCulture);

			//change the name of the column
			//Map(m => m.Description).Convert(c => "\"" + c + "\"");


			//convert the boolean values to string: Yes and No
			//Map(m => m.UniqueIdentifier)
			//	.Convert(c => c.UniqueIdentifier ? "Yes" : "No")
			//	.TypeConverterOption.BooleanValues(true, true, "Yes", "Yes")
			//	.TypeConverterOption.BooleanValues(false, true, "No", "No");
		}
	}
}
