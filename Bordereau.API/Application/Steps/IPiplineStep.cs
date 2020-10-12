using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bordereau.API.Application.Pipelines
{
	public interface IPiplineStep<Input, Output>
	{
		Output Process(Input input);
	}
}
