using Bordereau.API.ApplicationMediatR;
using Bordereau.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bordereau.API.PipelinesMediatR.Pipelines
{
	public class CreateRestLocationBehaviour : IPipelineBehavior<BordereauRequest, BordereauRequest> 
	{ 
		public async Task<BordereauRequest> Handle(BordereauRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<BordereauRequest> next)
		{
			request.Id = (new Guid()).ToString();
			request.FileLocation = $"\\file-location\\bdxdrop\\incoming\\\risk";
			request.UrlLocation = "https://url-location";

			// pre next stage processing
			// 1. save file to fileLocation
			// 2. send on for validation

			var response = await next();

			// post next stage processing

			return response;
		}
	}
}
