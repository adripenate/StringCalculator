using System.Net;
using Microsoft.AspNetCore.Mvc;
using Model;
using Persistence.File;
using StringCalculatorApi.Models;
using UseCases;

namespace StringCalculatorApi.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(StringCalculatorResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorMessage), (int)HttpStatusCode.BadRequest)]
    public class StringCalculatorController : ControllerBase
    {

        /// <summary>
        /// Devuelve la suma de una cadena que contiene números.
        /// v1
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
        [HttpPost, MapToApiVersion("1")]
        [Route("/v{version:apiVersion}/Add")]
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

        /// <summary>
        /// Devuelve la suma de una cadena que contiene números.
        /// V2
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
        [HttpPost, MapToApiVersion("2")]
        [Route("/v{version:apiVersion}/Add")]
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