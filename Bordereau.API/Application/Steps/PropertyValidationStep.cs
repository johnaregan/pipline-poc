using Bordereau.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bordereau.API.Application.Pipelines
{
	public class PropertyValidationStep : IPiplineStep<CreateRestLocationResult, PropertyValidationResult>
	{
		public PropertyValidationResult Process(CreateRestLocationResult input)
		{
			// do property validation

			var result = new PropertyValidationResult
			{
				Bdx = input.Bdx,
				Valid = true
			};
			return result;
		}			
	}

	public class PropertyValidationResult
	{
		public PropertyValidationResult()
		{
			Id = (new Guid()).ToString();
		}

		public string Id { get; set; }
		public RiskBordereau Bdx { get; set; }
		public bool Valid { get; set; }
	}
}
