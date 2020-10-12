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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BordereauRisk.API.Controllers
{
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
		
		// set this up to get xml
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

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
