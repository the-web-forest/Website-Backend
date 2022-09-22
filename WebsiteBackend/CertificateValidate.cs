using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WebsiteBackend.Controllers;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;

namespace WebsiteBackend
{
    public class CertificateValidate
    {
        private readonly CertificateValidateController _controller;


        public CertificateValidate(CertificateValidateController controller)
        {
            _controller = controller;
        }


        [FunctionName("CertificateValidate")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous,"post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string controllerString = await _controller.Run();

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = controllerString;

            return new OkObjectResult(responseMessage);
        }
    }
}

