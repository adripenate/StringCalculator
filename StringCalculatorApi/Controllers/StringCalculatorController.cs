using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Model;
using Persistence;
using StringCalculatorApi.Models;
using UseCases;

namespace StringCalculatorApi.Controllers
{
    [Route("api/StringCalculator")]
    [ApiController]
    public class StringCalculatorController : ControllerBase
    {
        
        [HttpPost]
        public ActionResult<StringCalculatorResult> PostStringCalculator(StringCalculatorModel stringCalculatorModel)
        {
            var saveAction = new SaveAction(new StringCalculator(), new PersistenceFile(@"..\OperationLog.txt"));
            var stringCalculatorResult = saveAction.Execute(stringCalculatorModel.Numbers);
            return stringCalculatorResult ?? (ActionResult<StringCalculatorResult>) BadRequest(new ErrorMessage {Error = "Negative numbers not allowed"});
        }
    }

    public class ErrorMessage : ModelStateDictionary
    {
        public string Error { get; set; }
    }
}