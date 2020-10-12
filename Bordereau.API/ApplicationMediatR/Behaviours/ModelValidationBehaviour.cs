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
	public class ModelValidationBehaviour : IPipelineBehavior<BordereauRequest, BordereauRequest>
	{
		public async Task<BordereauRequest> Handle(BordereauRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<BordereauRequest> next)
		{
			// model level validation

			request.Valid = true;
			if (!request.Valid)
			{
				// short circuit the pipline here and return
				request.Status = "Failed";
			}

			// pre next stage processing

			var response = await next();

			// post next stage processing

			return response;
		}
	}
}
