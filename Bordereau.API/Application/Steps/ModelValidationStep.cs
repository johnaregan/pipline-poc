using Bordereau.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bordereau.API.Application.Pipelines
{
	public class ModelValidationStep : IPiplineStep<PropertyValidationResult, ValidationResult>
	{
		public ValidationResult Process(PropertyValidationResult result)
		{
			var valid = true;
			return new ValidationResult { Bdx = result.Bdx, Valid = valid };
		}
	}

	public class ValidationResult
	{
		public RiskBordereau Bdx { get; set; }
		public bool Valid { get; set; }
		public string Url { get; set; }
	}
}
