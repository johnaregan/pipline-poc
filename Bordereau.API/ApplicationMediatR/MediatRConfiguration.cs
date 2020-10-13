using Bordereau.API.ApplicationMediatR.Behaviours;
using Bordereau.API.PipelinesMediatR.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Bordereau.API.ApplicationMediatR
{
	public static class MediatRConfiguration
	{
		public static void Register(IServiceCollection services)
		{			
			services.AddMediatR(Assembly.GetExecutingAssembly());

			var builder = new PipelineBuilder();
			builder.AddTo(services)
				.AddCreateRestLocation()
				.AddPropertyValidation()
				.AddModelValidation()
				.AddReturnStep();

			//var builder2 = new PipelineBuilder2();
			//builder2.AddTo(services)
			//	.AddPropertyValidation()
			//	.AddModelValidation()
			//	.AddReturnStep();

			//services.AddScoped(typeof(IPipelineBehavior<BordereauRequest, BordereauRequest>), typeof(CreateRestLocationBehaviour));
			//services.AddScoped(typeof(IPipelineBehavior<BordereauRequest, BordereauRequest>), typeof(PropertyValidationBehaviour));
			//services.AddScoped(typeof(IPipelineBehavior<BordereauRequest, BordereauRequest>), typeof(ModelValidationBehaviour));
			//services.AddScoped(typeof(IRequestHandler<BordereauRequest, BordereauRequest>), typeof(BordereauRequestHandler));

		}
	}

	// Prescriptive builder
	public class PipelineBuilder : IPipelineBuilder, IPiplineSteps
	{
		private IServiceCollection services;

		public IAddCreateRestLocation AddTo(IServiceCollection services)
		{
			this.services = services;
			return this;
		}

		public IPropertyValidation AddCreateRestLocation()
		{
			services.AddScoped(typeof(IPipelineBehavior<BordereauRequest, BordereauRequest>), typeof(CreateRestLocationBehaviour));
			return this;
		}

		public IModelValidation AddPropertyValidation()
		{
			services.AddScoped(typeof(IPipelineBehavior<BordereauRequest, BordereauRequest>), typeof(PropertyValidationBehaviour));
			return this;
		}
		public IReturnStep AddModelValidation()
		{
			services.AddScoped(typeof(IPipelineBehavior<BordereauRequest, BordereauRequest>), typeof(ModelValidationBehaviour));
			return this as IReturnStep;
		}

		public void AddReturnStep()
		{			
			services.AddScoped(typeof(IRequestHandler<BordereauRequest, BordereauRequest>), typeof(BordereauRequestHandler));
		}
	}

	// Not so prescriptive builder
	public class PipelineBuilder2 : IPipelineBuilder2
	{
		private IServiceCollection services;

		public IPipelineBuilder2 AddTo(IServiceCollection services)
		{
			this.services = services;
			return this;
		}

		public IPipelineBuilder2 AddCreateRestLocation()
		{
			services.AddScoped(typeof(IPipelineBehavior<BordereauRequest, BordereauRequest>), typeof(CreateRestLocationBehaviour));
			return this;
		}

		public IPipelineBuilder2 AddPropertyValidation()
		{
			services.AddScoped(typeof(IPipelineBehavior<BordereauRequest, BordereauRequest>), typeof(PropertyValidationBehaviour));
			return this;
		}
		public IPipelineBuilder2 AddModelValidation()
		{
			services.AddScoped(typeof(IPipelineBehavior<BordereauRequest, BordereauRequest>), typeof(ModelValidationBehaviour));
			return this as IPipelineBuilder2;
		}

		public void AddReturnStep()
		{
			services.AddScoped(typeof(IRequestHandler<BordereauRequest, BordereauRequest>), typeof(BordereauRequestHandler));
		}
	}

	// Interfaces
	public interface IPipelineBuilder2
	{
		public IPipelineBuilder2 AddTo(IServiceCollection services);
		public IPipelineBuilder2 AddCreateRestLocation();
		public IPipelineBuilder2 AddPropertyValidation();
		public IPipelineBuilder2 AddModelValidation();
		public void AddReturnStep();
	}

	public interface IPipelineBuilder
	{
		public IAddCreateRestLocation AddTo(IServiceCollection services);
		public IPropertyValidation AddCreateRestLocation();
		public IModelValidation AddPropertyValidation();
		public IReturnStep AddModelValidation();
		public void AddReturnStep();
	}

	public interface IPiplineSteps : IAddCreateRestLocation, IPropertyValidation, IModelValidation, IReturnStep { }

	public interface IAddCreateRestLocation
	{
		public IPropertyValidation AddCreateRestLocation();
	}

	public interface IPropertyValidation
	{
		public IModelValidation AddPropertyValidation();
	}

	public interface IModelValidation
	{
		public IReturnStep AddModelValidation();
	}

	public interface IReturnStep
	{
		public void AddReturnStep();
	}
}
