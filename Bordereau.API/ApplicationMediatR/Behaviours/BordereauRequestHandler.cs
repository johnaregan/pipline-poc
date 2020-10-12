using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bordereau.API.ApplicationMediatR.Behaviours
{
	public class BordereauRequestHandler : IRequestHandler<BordereauRequest, BordereauRequest>
	{
		public Task<BordereauRequest> Handle(BordereauRequest request, CancellationToken cancellationToken)
		{
			return Task.FromResult(request);
		}
	}
}
