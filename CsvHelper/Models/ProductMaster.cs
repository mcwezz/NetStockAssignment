using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStockAssignment.CsvHelper.Models
{
	public class ProductMaster
	{
		public string Code { get; set; }
		public string Description { get; set; }
		public string UoM { get; set; }
		public decimal UnitVolume { get; set; }
		public decimal UnitWeight { get; set; }
		public string SupercededItemCode { get; set; }
		public decimal SupercededItemFactor { get; set; }
		public string PlaceHolder { get; set; }
		public string UniqueIdentifier { get; set; }
	}
}
