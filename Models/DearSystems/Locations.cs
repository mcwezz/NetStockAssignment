using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NetStockAssignment.Models.DearSystems
{

	// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
	public class Bin
	{
		[JsonPropertyName("ID")]
		public string ID { get; set; }

		[JsonPropertyName("Name")]
		public string Name { get; set; }

		[JsonPropertyName("IsDeprecated")]
		public bool IsDeprecated { get; set; }

		[JsonPropertyName("IsStaging")]
		public bool IsStaging { get; set; }
	}

	public class LocationList
	{
		[JsonPropertyName("ID")]
		public string ID { get; set; }

		[JsonPropertyName("Name")]
		public string Name { get; set; }

		[JsonPropertyName("IsDefault")]
		public bool IsDefault { get; set; }

		[JsonPropertyName("IsDeprecated")]
		public bool IsDeprecated { get; set; }

		[JsonPropertyName("Bins")]
		public List<Bin> Bins { get; set; }

		[JsonPropertyName("FixedAssetsLocation")]
		public bool FixedAssetsLocation { get; set; }

		[JsonPropertyName("ParentID")]
		public string ParentID { get; set; }

		[JsonPropertyName("ParentName")]
		public string ParentName { get; set; }

		[JsonPropertyName("ReferenceCount")]
		public int ReferenceCount { get; set; }

		[JsonPropertyName("AddressLine1")]
		public string AddressLine1 { get; set; }

		[JsonPropertyName("AddressLine2")]
		public string AddressLine2 { get; set; }

		[JsonPropertyName("AddressCitySuburb")]
		public string AddressCitySuburb { get; set; }

		[JsonPropertyName("AddressStateProvince")]
		public string AddressStateProvince { get; set; }

		[JsonPropertyName("AddressZipPostCode")]
		public string AddressZipPostCode { get; set; }

		[JsonPropertyName("AddressCountry")]
		public string AddressCountry { get; set; }

		[JsonPropertyName("PickZones")]
		public string PickZones { get; set; }

		[JsonPropertyName("IsShopfloor")]
		public bool IsShopfloor { get; set; }

		[JsonPropertyName("IsCoMan")]
		public bool IsCoMan { get; set; }

		[JsonPropertyName("IsStaging")]
		public bool IsStaging { get; set; }
	}

	public class LocationsRoot
	{
		[JsonPropertyName("Total")]
		public int Total { get; set; }

		[JsonPropertyName("Page")]
		public int Page { get; set; }

		[JsonPropertyName("LocationList")]
		public List<LocationList> LocationList { get; set; }
	}



}
