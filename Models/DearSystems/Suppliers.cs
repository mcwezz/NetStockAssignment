using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetStockAssignment.Models.DearSystems
{
	// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
	public class Address
	{
		[JsonPropertyName("Line1")]
		public string Line1 { get; set; }

		[JsonPropertyName("Line2")]
		public string Line2 { get; set; }

		[JsonPropertyName("City")]
		public string City { get; set; }

		[JsonPropertyName("State")]
		public string State { get; set; }

		[JsonPropertyName("Postcode")]
		public string Postcode { get; set; }

		[JsonPropertyName("Country")]
		public string Country { get; set; }

		[JsonPropertyName("Type")]
		public string Type { get; set; }

		[JsonPropertyName("DefaultForType")]
		public bool DefaultForType { get; set; }

		[JsonPropertyName("ID")]
		public string ID { get; set; }
	}

	public class Contact
	{
		[JsonPropertyName("Name")]
		public string Name { get; set; }

		[JsonPropertyName("Phone")]
		public string Phone { get; set; }

		[JsonPropertyName("MobilePhone")]
		public string MobilePhone { get; set; }

		[JsonPropertyName("Fax")]
		public string Fax { get; set; }

		[JsonPropertyName("Email")]
		public string Email { get; set; }

		[JsonPropertyName("Website")]
		public object Website { get; set; }

		[JsonPropertyName("Default")]
		public bool Default { get; set; }

		[JsonPropertyName("Comment")]
		public object Comment { get; set; }

		[JsonPropertyName("IncludeInEmail")]
		public bool IncludeInEmail { get; set; }

		[JsonPropertyName("ID")]
		public string ID { get; set; }
	}

	public class SupplierList
	{
		[JsonPropertyName("ID")]
		public string ID { get; set; }

		[JsonPropertyName("Name")]
		public string Name { get; set; }

		[JsonPropertyName("Currency")]
		public string Currency { get; set; }

		[JsonPropertyName("PaymentTerm")]
		public string PaymentTerm { get; set; }

		[JsonPropertyName("TaxRule")]
		public string TaxRule { get; set; }

		[JsonPropertyName("Discount")]
		public double Discount { get; set; }

		[JsonPropertyName("Comments")]
		public object Comments { get; set; }

		[JsonPropertyName("AccountPayable")]
		public string AccountPayable { get; set; }

		[JsonPropertyName("TaxNumber")]
		public object TaxNumber { get; set; }

		[JsonPropertyName("AdditionalAttribute1")]
		public object AdditionalAttribute1 { get; set; }

		[JsonPropertyName("AdditionalAttribute2")]
		public object AdditionalAttribute2 { get; set; }

		[JsonPropertyName("AdditionalAttribute3")]
		public object AdditionalAttribute3 { get; set; }

		[JsonPropertyName("AdditionalAttribute4")]
		public object AdditionalAttribute4 { get; set; }

		[JsonPropertyName("AdditionalAttribute5")]
		public object AdditionalAttribute5 { get; set; }

		[JsonPropertyName("AdditionalAttribute6")]
		public object AdditionalAttribute6 { get; set; }

		[JsonPropertyName("AdditionalAttribute7")]
		public object AdditionalAttribute7 { get; set; }

		[JsonPropertyName("AdditionalAttribute8")]
		public object AdditionalAttribute8 { get; set; }

		[JsonPropertyName("AdditionalAttribute9")]
		public object AdditionalAttribute9 { get; set; }

		[JsonPropertyName("AdditionalAttribute10")]
		public object AdditionalAttribute10 { get; set; }

		[JsonPropertyName("AttributeSet")]
		public object AttributeSet { get; set; }

		[JsonPropertyName("Status")]
		public string Status { get; set; }

		[JsonPropertyName("LastModifiedOn")]
		public DateTime LastModifiedOn { get; set; }

		[JsonPropertyName("Addresses")]
		public List<Address> Addresses { get; set; }

		[JsonPropertyName("Contacts")]
		public List<Contact> Contacts { get; set; }
	}

	public class SuppliersRoot
	{
		[JsonPropertyName("Total")]
		public int Total { get; set; }

		[JsonPropertyName("Page")]
		public int Page { get; set; }

		[JsonPropertyName("SupplierList")]
		public List<SupplierList> SupplierList { get; set; }
	}


}
