using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class Function1
    {
      
    [FunctionName("Function1")]
         public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            [Sql("SELECT * FROM [dbo].[AccessLogs]",
            CommandType = System.Data.CommandType.Text,
            ConnectionStringSetting = "myconnections")] IEnumerable<Object> result,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger  function processed a request.");

            return new OkObjectResult(result);
        }
    }
}
