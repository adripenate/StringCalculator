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
        [HttpPost]
        public ActionResult<StringCalculatorResult> PostStringCalculator(StringCalculatorModel stringCalculatorModel)
        {
            var saveAction = new SaveAction(new StringCalculator(), new PersistenceFile(@"..\OperationLog.txt"));
            var stringCalculatorResult = saveAction.execute(stringCalculatorModel.Numbers);
            return stringCalculatorResult ?? (ActionResult<StringCalculatorResult>) BadRequest();
        }
    }
}