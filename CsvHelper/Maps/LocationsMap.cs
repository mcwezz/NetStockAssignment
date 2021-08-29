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
	public class LocationsMap : ClassMap<Locations>
	{
		public LocationsMap()
		{
			AutoMap(CultureInfo.InvariantCulture);

			//convert the boolean values to string: 1 and 0
			Map(m => m.Active)
				.TypeConverterOption.BooleanValues(true, true, "1", "1")
				.TypeConverterOption.BooleanValues(false, true, "0", "0");
		}
	}
}

