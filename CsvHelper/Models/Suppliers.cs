using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStockAssignment.CsvHelper.Models
{
	public class Suppliers
	{
		public string Code { get; set; }
		public string Description { get; set; }
		public string Type { get; set; }
		public int LeadTime { get; set; }
	}
}
