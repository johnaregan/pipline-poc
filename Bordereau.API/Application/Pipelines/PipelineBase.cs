using System;

namespace Bordereau.API.Application.Pipelines
{
	public abstract class PipelineBase<Input, Output> : IPiplineStep<Input, Output>
	{
		public Func<Input, Output> PipelineSteps { get; protected set; }

		public Output Process(Input input)
		{
			return PipelineSteps(input);
		}
	}
}
