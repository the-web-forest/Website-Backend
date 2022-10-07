using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebsiteBackend.Controllers.Certificate;
using WebsiteBackend.Controllers.Certificate.DTOs;

namespace WebsiteBackend.Functions;
public class CertificateValidate
{
    private CertificateValidateController _controller { get; }

    public CertificateValidate(CertificateValidateController controller)
    {
        _controller = controller;
    }

    [FunctionName("CertificateValidate")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "Get", Route = null)] HttpRequest req, 
        ILogger log
    )
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        string certificateId = req.Query["CertificateId"];

        var response = await _controller
            .Run(new CertificateValidateInput
            {
                CertificateId = certificateId
            });

        return response;
    }
}