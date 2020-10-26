using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using InfrastructureLayer.Interfaces.DataAccess;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiTemplateCore.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _log;
        private readonly IDataAccess _dataAccess;

        public ErrorController(ILogger<ErrorController> log, IDataAccess dataAccess)
        {
            _log = log;
            _dataAccess = dataAccess;
        }

        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment(
            [FromServices] IHostingEnvironment webHostEnvironment)
        {
            if (!webHostEnvironment.IsDevelopment())
            {
                throw new InvalidOperationException(
                    "This shouldn't be invoked in non-development environments.");
            }

            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;

            // The response to the client in development
            var problemDetails = new ProblemDetails

            {
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = feature?.Path,
                Title = ex.GetType().Name,
                Detail = ex.ToString(),
            };

            // Log development error
         //   _log.LogError(JsonSerializer.Serialize(problemDetails));
            _log.LogError("{EmailFlag}{MyErrorMessage}", true, JsonSerializer.Serialize(problemDetails));

            // Close DB connection
            _dataAccess.CloseConnection();


            return StatusCode(problemDetails.Status.Value, problemDetails);

        }


        [Route("/error")]
        public ActionResult Error(
            [FromServices] IHostingEnvironment webHostEnvironment)
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var ex = feature?.Error;

            var isDev = webHostEnvironment.IsDevelopment();

            // The response to the client in production
            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = feature?.Path,
                Title = isDev ? $"{ex.GetType().Name}: {ex.Message}" : "An error occurred.",
                Detail = isDev ? ex.StackTrace : null,
            };

            // The error log data
            var problemDetails2Log = new ProblemDetails

            {
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = feature?.Path,
                Title = ex.GetType().Name,
                Detail = ex.ToString(),
            };

            // Log production error
            _log.LogError("{EmailFlag}{MyErrorMessage}",true,JsonSerializer.Serialize(problemDetails2Log));

            // Close DB connection
            _dataAccess.CloseConnection();

            return StatusCode(problemDetails.Status.Value, problemDetails);
        }
    }
}
