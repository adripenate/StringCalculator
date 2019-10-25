using Kata;
using Microsoft.AspNetCore.Mvc;
using Model;
using Persistence;
using StringCalculatorApi.Models;

namespace StringCalculatorApi.Controllers
{
    [Route("api/StringCalculator")]
    [ApiController]
    public class StringCalculatorController : ControllerBase
    {
        private string postErrorMessage =
            "{ \"type\":\"https://tools.ietf.org/html/rfc7231#section-6.5.1 \", \"title\":\"Negative numbers not allowed\", \"status\":400, \"traceId\":\"|e2d90705-448fd768e0a87daa.\" }";

        [HttpPost]
        public ActionResult<StringCalculatorResult> PostStringCalculator(StringCalculatorModel stringCalculatorModel)
        {
            var saveAction = new SaveAction(new StringCalculator(), new PersistenceFile(@"..\OperationLog.txt"));
            var stringCalculatorResult = saveAction.Execute(stringCalculatorModel.Numbers);
            return stringCalculatorResult ?? (ActionResult<StringCalculatorResult>) BadRequest(postErrorMessage);
        }
    }
}