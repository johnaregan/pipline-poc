using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Bordereau.Domain
{
	[XmlRoot]
	public class RiskBordereau	
	{
		[Required] // will appear in Swagger doc
		public string UniqueIdentifier { get; set; }
		[Required]
		public string XML { get; set; }
		[DefaultValue(false)]
		public bool SomeBool { get; set; }
	}
}
