using Bordereau.API.ApplicationMediatR.Behaviours;
using Bordereau.API.PipelinesMediatR.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Bordereau.API.ApplicationMediatR
{
	public static class MediatRConfiguration
	{
		public static void Register(IServiceCollection services)
		{
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddScoped(typeof(IPipelineBehavior<BordereauRequest, BordereauRequest>), typeof(CreateRestLocationBehaviour));
			services.AddScoped(typeof(IPipelineBehavior<BordereauRequest, BordereauRequest>), typeof(PropertyValidationBehaviour));
			services.AddScoped(typeof(IPipelineBehavior<BordereauRequest, BordereauRequest>), typeof(ModelValidationBehaviour));
			services.AddScoped(typeof(IRequestHandler<BordereauRequest, BordereauRequest>), typeof(BordereauRequestHandler));
		}
	}
}
