using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace TestCreate
{
    public class Function1
	{
		private readonly ILogger<Function1> _logger;

		public Function1(ILogger<Function1> log)
		{
			_logger = log;
		}

		[FunctionName("Test_01")]
		[OpenApiOperation(operationId: "Run", tags: new[] { "T100 D2i" })]
		[OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
		[OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]


		///
		public async Task<IActionResult> Run(
			
		[HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req) //post
		{
			_logger.LogInformation("C# HTTP trigger function processed a request.");

			

			string path = @"C:\Users\sitinorwahida\Desktop\Data01.csv";
			StreamReader objReader;
			objReader = new StreamReader(path);
			var readdata = objReader.ReadToEnd();
			readdata = readdata.Replace("\r\n", string.Empty);
			string[] splitdata = readdata.Split(',');

			return new OkObjectResult(splitdata);
		}
		

	}
}

