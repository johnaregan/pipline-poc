using Bordereau.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bordereau.API.Application.Pipelines
{
	public class CreateRestLocationStep : IPiplineStep<RiskBordereau, CreateRestLocationResult>
	{
		public CreateRestLocationResult Process(RiskBordereau input)
		{

			var Id = (new Guid()).ToString();
			var fileLocation = $"base location";
			var urlLocation = "http://url-location";
			// save file to fileLocation

			var result = new CreateRestLocationResult { Id = Id, Bdx = input, FileLocation = fileLocation, UrlLocation = urlLocation };
			return result;
		}
	}

	public class CreateRestLocationResult
	{
		public string Id { get; set; }
		public RiskBordereau Bdx { get; set; }
		public string FileLocation { get; set; }
		public string UrlLocation { get; set; }
	}
}
