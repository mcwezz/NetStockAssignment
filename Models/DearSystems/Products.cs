using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetStockAssignment.Models.DearSystems
{

		// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
		public class PriceTiers
		{
			[JsonPropertyName("Tier 1")]
			public double Tier1 { get; set; }

			[JsonPropertyName("Tier 2")]
			public double Tier2 { get; set; }

			[JsonPropertyName("Tier 3")]
			public double Tier3 { get; set; }

			[JsonPropertyName("Tier 4")]
			public double Tier4 { get; set; }

			[JsonPropertyName("Tier 5")]
			public double Tier5 { get; set; }

			[JsonPropertyName("Tier 6")]
			public double Tier6 { get; set; }

			[JsonPropertyName("Tier 7")]
			public double Tier7 { get; set; }

			[JsonPropertyName("Tier 8")]
			public double Tier8 { get; set; }

			[JsonPropertyName("Tier 9")]
			public double Tier9 { get; set; }

			[JsonPropertyName("Tier 10")]
			public double Tier10 { get; set; }
		}

		public class Product
		{
			[JsonPropertyName("ID")]
			public string ID { get; set; }

			[JsonPropertyName("SKU")]
			public string SKU { get; set; }

			[JsonPropertyName("Name")]
			public string Name { get; set; }

			[JsonPropertyName("Category")]
			public string Category { get; set; }

			[JsonPropertyName("Brand")]
			public string Brand { get; set; }

			[JsonPropertyName("Type")]
			public string Type { get; set; }

			[JsonPropertyName("CostingMethod")]
			public string CostingMethod { get; set; }

			[JsonPropertyName("DropShipMode")]
			public string DropShipMode { get; set; }

			[JsonPropertyName("DefaultLocation")]
			public string DefaultLocation { get; set; }

			[JsonPropertyName("Length")]
			public double Length { get; set; }

			[JsonPropertyName("Width")]
			public double Width { get; set; }

			[JsonPropertyName("Height")]
			public double Height { get; set; }

			[JsonPropertyName("Weight")]
			public double Weight { get; set; }

			[JsonPropertyName("UOM")]
			public string UOM { get; set; }

			[JsonPropertyName("WeightUnits")]
			public string WeightUnits { get; set; }

			[JsonPropertyName("DimensionsUnits")]
			public string DimensionsUnits { get; set; }

			[JsonPropertyName("Barcode")]
			public string Barcode { get; set; }

			[JsonPropertyName("MinimumBeforeReorder")]
			public double MinimumBeforeReorder { get; set; }

			[JsonPropertyName("ReorderQuantity")]
			public double ReorderQuantity { get; set; }

			[JsonPropertyName("PriceTier1")]
			public double PriceTier1 { get; set; }

			[JsonPropertyName("PriceTier2")]
			public double PriceTier2 { get; set; }

			[JsonPropertyName("PriceTier3")]
			public double PriceTier3 { get; set; }

			[JsonPropertyName("PriceTier4")]
			public double PriceTier4 { get; set; }

			[JsonPropertyName("PriceTier5")]
			public double PriceTier5 { get; set; }

			[JsonPropertyName("PriceTier6")]
			public double PriceTier6 { get; set; }

			[JsonPropertyName("PriceTier7")]
			public double PriceTier7 { get; set; }

			[JsonPropertyName("PriceTier8")]
			public double PriceTier8 { get; set; }

			[JsonPropertyName("PriceTier9")]
			public double PriceTier9 { get; set; }

			[JsonPropertyName("PriceTier10")]
			public double PriceTier10 { get; set; }

			[JsonPropertyName("PriceTiers")]
			public PriceTiers PriceTiers { get; set; }

			[JsonPropertyName("AverageCost")]
			public double AverageCost { get; set; }

			[JsonPropertyName("ShortDescription")]
			public string ShortDescription { get; set; }

			[JsonPropertyName("InternalNote")]
			public object InternalNote { get; set; }

			[JsonPropertyName("Description")]
			public string Description { get; set; }

			[JsonPropertyName("AdditionalAttribute1")]
			public string AdditionalAttribute1 { get; set; }

			[JsonPropertyName("AdditionalAttribute2")]
			public string AdditionalAttribute2 { get; set; }

			[JsonPropertyName("AdditionalAttribute3")]
			public string AdditionalAttribute3 { get; set; }

			[JsonPropertyName("AdditionalAttribute4")]
			public string AdditionalAttribute4 { get; set; }

			[JsonPropertyName("AdditionalAttribute5")]
			public string AdditionalAttribute5 { get; set; }

			[JsonPropertyName("AdditionalAttribute6")]
			public string AdditionalAttribute6 { get; set; }

			[JsonPropertyName("AdditionalAttribute7")]
			public string AdditionalAttribute7 { get; set; }

			[JsonPropertyName("AdditionalAttribute8")]
			public string AdditionalAttribute8 { get; set; }

			[JsonPropertyName("AdditionalAttribute9")]
			public string AdditionalAttribute9 { get; set; }

			[JsonPropertyName("AdditionalAttribute10")]
			public string AdditionalAttribute10 { get; set; }

			[JsonPropertyName("AttributeSet")]
			public string AttributeSet { get; set; }

			[JsonPropertyName("DiscountRule")]
			public object DiscountRule { get; set; }

			[JsonPropertyName("Tags")]
			public string Tags { get; set; }

			[JsonPropertyName("Status")]
			public string Status { get; set; }

			[JsonPropertyName("StockLocator")]
			public string StockLocator { get; set; }

			[JsonPropertyName("COGSAccount")]
			public object COGSAccount { get; set; }

			[JsonPropertyName("RevenueAccount")]
			public object RevenueAccount { get; set; }

			[JsonPropertyName("ExpenseAccount")]
			public string ExpenseAccount { get; set; }

			[JsonPropertyName("InventoryAccount")]
			public string InventoryAccount { get; set; }

			[JsonPropertyName("PurchaseTaxRule")]
			public string PurchaseTaxRule { get; set; }

			[JsonPropertyName("SaleTaxRule")]
			public string SaleTaxRule { get; set; }

			[JsonPropertyName("LastModifiedOn")]
			public DateTime LastModifiedOn { get; set; }

			[JsonPropertyName("Sellable")]
			public bool Sellable { get; set; }

			[JsonPropertyName("PickZones")]
			public string PickZones { get; set; }

			[JsonPropertyName("BillOfMaterial")]
			public bool BillOfMaterial { get; set; }

			[JsonPropertyName("AutoAssembly")]
			public bool AutoAssembly { get; set; }

			[JsonPropertyName("AutoDisassembly")]
			public bool AutoDisassembly { get; set; }

			[JsonPropertyName("QuantityToProduce")]
			public double QuantityToProduce { get; set; }

			[JsonPropertyName("AlwaysShowQuantity")]
			public object AlwaysShowQuantity { get; set; }

			[JsonPropertyName("AssemblyInstructionURL")]
			public string AssemblyInstructionURL { get; set; }

			[JsonPropertyName("AssemblyCostEstimationMethod")]
			public string AssemblyCostEstimationMethod { get; set; }

			[JsonPropertyName("Suppliers")]
			public List<object> Suppliers { get; set; }

			[JsonPropertyName("ReorderLevels")]
			public List<object> ReorderLevels { get; set; }

			[JsonPropertyName("BillOfMaterialsProducts")]
			public List<object> BillOfMaterialsProducts { get; set; }

			[JsonPropertyName("BillOfMaterialsServices")]
			public List<object> BillOfMaterialsServices { get; set; }

			[JsonPropertyName("Movements")]
			public List<object> Movements { get; set; }

			[JsonPropertyName("Attachments")]
			public List<object> Attachments { get; set; }

			[JsonPropertyName("BOMType")]
			public string BOMType { get; set; }
		}

		public class ProductsRoot
		{
			[JsonPropertyName("Total")]
			public int Total { get; set; }

			[JsonPropertyName("Page")]
			public int Page { get; set; }

			[JsonPropertyName("Products")]
			public List<Product> Products { get; set; }
		}


	
}
