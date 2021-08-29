using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStockAssignment.CsvHelper.Models
{
	public class Locations
	{
		public string Code { get; set; }
		public string Description { get; set; }
		public bool Active { get; set; }
		public string Group { get; set; }
		public string Type { get; set; }
	}
}
