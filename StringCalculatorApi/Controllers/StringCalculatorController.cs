using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Model;
using Persistence.File;
using StringCalculatorApi.Models;
using UseCases;

namespace StringCalculatorApi.Controllers
{
    [Route("api/StringCalculator")]
    [ApiController]
    public class StringCalculatorController : ControllerBase
    {

        /// <summary>
        /// Devuelve la suma de una cadena que contiene números.
        /// </summary>
        [Produces("application/json")]
        [ProducesResponseType(typeof(StringCalculatorResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public ActionResult<StringCalculatorResult> PostStringCalculator(StringCalculatorModel stringCalculatorModel)
        {
            var saveAction = new SaveAction(new StringCalculator(), new PersistenceFile(@"..\OperationLog.txt"));
            var stringCalculatorResult = saveAction.Execute(stringCalculatorModel.Numbers);
            if (stringCalculatorResult == null)
            {
                return BadRequest(new ErrorMessage() { Error = "Negative numbers not allowed" });
            }
            return stringCalculatorResult;
        }
    }
}