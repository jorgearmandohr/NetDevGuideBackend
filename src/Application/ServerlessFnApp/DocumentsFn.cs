using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Domain.Model.Entities;
using Domain.Model.Repository;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

namespace ServerlessFnApp
{
    public class DocumentsFn
    {
        private readonly IRepository<Document> _docRepository;

        public DocumentsFn(IRepository<Document> docRepository)
        {
            _docRepository = docRepository;
        }

        [FunctionName("Documents")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "documents/{documentId}")] HttpRequest req,
            string documentId,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            log.LogInformation("request received documentId eq ", documentId);
            //var docs = _dbCotext.Documents.ToList();
            //var doc = await _dbCotext.Documents.FirstOrDefaultAsync(x => x.Reference == documentId);
            var doc = _docRepository.GetByExpression(x => x.Reference == documentId).FirstOrDefault();
            //string name = req.Query["name"];
            /*Create a helper in architecture to deserialize request*/
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;
            string name = doc?.Name;

            /*Create a helper handle response types*/
            //string responseMessage = string.IsNullOrEmpty(name)
            //    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //    : $"Hello, {name}. This HTTP triggered function executed successfully.";

            if (string.IsNullOrEmpty(name))
            {
                return new NotFoundObjectResult($"No result for {documentId}");
            }
            else
            {
                return new OkObjectResult($"Document name: {name}");
            }
        }
    }
}