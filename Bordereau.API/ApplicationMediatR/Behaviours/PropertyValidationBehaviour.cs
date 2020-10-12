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
	public class PropertyValidationBehaviour : IPipelineBehavior<BordereauRequest, BordereauRequest>
	{
		public async Task<BordereauRequest> Handle(BordereauRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<BordereauRequest> next)
		{
			// property level validation
			request.Valid = true;
			if (!request.Valid)
			{
				// short circuit the pipline here and return
				request.Status = "Failed";
			}

			// pre next stage processing

			var response = next();

			// post next stage processing

			return await response;
		}
	}
}
