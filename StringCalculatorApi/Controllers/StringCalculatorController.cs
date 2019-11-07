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
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /PostStringCalculator
        ///     {
        ///        "numbers": "1,3,4"
        ///     }
        ///
        /// </remarks>
        [ApiVersion("1.0")]
        [Route("api/v{version:apiVersion}/[controller]")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(StringCalculatorResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public ActionResult<StringCalculatorResult> PostStringCalculator(StringCalculatorRequest request)
        {
            var saveAction = new SaveAction(new StringCalculator(), new PersistenceFile(@"..\OperationLog.txt"));
            var stringCalculatorResult = saveAction.Execute(request.Numbers);
            if (stringCalculatorResult == null)
            {
                return BadRequest(new ErrorMessage() { Error = "Negative numbers not allowed" });
            }
            return stringCalculatorResult;
        }

        [ApiVersion("2.0")]
        [Route("api/v{version:apiVersion}/[controller]")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(StringCalculatorResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public ActionResult<StringCalculatorResult> PostStringCalculatora(StringCalculatorRequest request)
        {
            var saveAction = new SaveAction(new StringCalculator(), new PersistenceFile(@"..\OperationLog.txt"));
            var stringCalculatorResult = saveAction.Execute(request.Numbers);
            if (stringCalculatorResult == null)
            {
                return BadRequest(new ErrorMessage() { Error = "Negative numbers not allowed" });
            }
            return stringCalculatorResult;
        }
    }

}