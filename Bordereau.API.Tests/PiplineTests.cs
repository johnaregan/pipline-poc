using Bordereau.API.Application.Pipelines;
using Bordereau.API.PipelinesMediatR.Pipelines;
using Bordereau.Domain;
using BordereauRisk.API;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bordereau.API.Tests
{
	public class PipelineTests
	{
		private TestServer server;
		private HttpClient client;

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Pipeline_Builds()
		{
			var bordereau = new RiskBordereau
			{
				UniqueIdentifier = (new Guid()).ToString(),
				XML = "<root><data>information</data></root>"
			};

			var pipeline = new BordereauPipline();
			var actual = pipeline.Process(bordereau);

			Assert.AreEqual(true, actual.Valid);
		}

		[Test]
		public async Task Pipeline_MediatR()
		{
			await BuildTestServerAsync();

			var bordereau = new RiskBordereau
			{ 
				XML = "<root><data>information</data></root>"
			};

			var bdx = new StringContent(bordereau.XML);			
			var response = await client.PostAsync("/RiskBordereau/Mediatr", bdx);

			Assert.NotNull(response);
		}

		private async Task BuildTestServerAsync() 
		{
			var hostBuilder = new HostBuilder().ConfigureWebHost(webHost => {
				webHost.UseTestServer();
				webHost.UseStartup<Startup>();
			});
			var server = await hostBuilder.StartAsync();
			client = server.GetTestClient();			
		}
	}
}