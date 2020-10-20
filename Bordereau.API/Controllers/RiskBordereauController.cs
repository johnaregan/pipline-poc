using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bordereau.API.Application.Pipelines;
using Bordereau.API.ApplicationMediatR;
using Bordereau.API.Controllers;
using Bordereau.API.PipelinesMediatR.Pipelines;
using Bordereau.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BordereauRisk.API.Controllers
{
	[Produces("application/json", new[] { "application/xml" })]
	[ApiController]
	[Route("[controller]")]
	public class RiskBordereauController : BaseController
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<RiskBordereauController> _logger;
		
		public RiskBordereauController(ILogger<RiskBordereauController> logger, IMediator mediator)
		{
			_logger = logger;
			Mediator = mediator;
		}

		/// <summary>
		/// Accepts a bordereau document for processing via hand-rolled pipeline
		/// </summary>
		/// <param name="document"></param>
		/// <returns></returns>
		[HttpPost]
		public string Post(string document)
		{
			var bdx = new RiskBordereau
			{
				UniqueIdentifier = (new Guid()).ToString(),
				XML = "<root><data>information</data></root>"
			};

			var pipeline = new BordereauPipline();
			
			return pipeline.Process(bdx).Url;
		}

		/// <summary>
		/// Dummy get endpoint for developing (mimics return types from POST too)
		/// </summary>
		/// <param name="document"></param>
		/// <returns></returns>
		/// <remarks>
		/// <pre>
		/// Sample request:
		///		POST /MediatR
		///		{
		///			"document": "<borderea></borderea>"
		///		}
		///	</pre>
		/// </remarks>
		/// <response code="201">Returns the newly created item</response>
		/// <response code="400">If the item is null</response>     
		[HttpGet("MediatR")]
		[ProducesResponseType(StatusCodes.Status201Created)] // for Swagger doc though not needed to Core >2.0
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<Response> GetMediatR(string document)
		{
			var bdx = new RiskBordereau
			{
				UniqueIdentifier = (new Guid()).ToString(),
				XML = "<root><data>information</data></root>"
			};
			var request = new BordereauRequest { Bdx = bdx };

			var result = await Mediator.Send(request);

			var response = BaseController.GetObject<Response>("RiskResponse.xml");
			return response;
		}

		/// <summary>
		/// Accepts a bordereau document for processing 
		/// </summary>
		/// <param name="document"></param>
		/// <returns></returns>
		[HttpPost("MediatR")]
		public async Task<string> PostMediatR(string document)
		{
			var bdx = new RiskBordereau
			{
				UniqueIdentifier = (new Guid()).ToString(),
				XML = "<root><data>information</data></root>"
			};
			var request = new BordereauRequest { Bdx = bdx };

			var result = await Mediator.Send(request);
			return result.UrlLocation;
		}

		[HttpGet("BordereauResponse/{guid}")]
		public Response GetBordereauResponse(string guid)
		{
			var response = BaseController.GetObject<Response>("RiskResponse.xml");
			return response;
		}

	}
}
