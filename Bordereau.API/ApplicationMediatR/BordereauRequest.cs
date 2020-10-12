using Bordereau.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bordereau.API.ApplicationMediatR
{
	public class BordereauRequest : IRequest<BordereauRequest>
	{
		public BordereauRequest()
		{
			Id = (new Guid()).ToString();
		}
		public string Status { get; set; }
		public string Id { get; set; }
		public RiskBordereau Bdx { get; set; }
		public string FileLocation { get; set; }
		public string UrlLocation { get; set; }
		public bool Valid { get; set; }
	}

	public class BordereauRequest2 : BordereauRequest
	{
	}
}
