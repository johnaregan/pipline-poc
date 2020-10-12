using Bordereau.API.Application.Pipelines;
using Bordereau.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bordereau.API.Application.Pipelines
{
	public class BordereauPipline : PipelineBase<RiskBordereau, ValidationResult>
	{
		public BordereauPipline()
		{
			// change to fluent builder pattern to strongly type which step is next
			// https://medium.com/@jacobcunningham/the-fluent-builder-pattern-ac1b6c23afc3

			PipelineSteps = bordereau => bordereau
				.Step(new CreateRestLocationStep())
				.Step(new PropertyValidationStep())
				.Step(new ModelValidationStep());
		}
		public void AddStep() { }
	}

	public static class PipelineStepExtentions
	{
		public static Output Step<Input, Output>(this Input input, IPiplineStep<Input, Output> step)
		{
			return step.Process(input);
		}
	}

}
