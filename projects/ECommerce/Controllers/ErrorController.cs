using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ErrorController:Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult StatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the page you are looking for could not be found.";
                    ViewBag.Path = statusCodeResult?.OriginalPath;
                    ViewBag.QS = statusCodeResult?.OriginalQueryString;
                    break;
                default:
                    ViewBag.ErrorMessage = "An unexpected error has occurred.";
                    break;
            }
            return View("NotFound");
        }
        
        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature?.Error != null)
            {
                ViewBag.ErrorMessage = exceptionHandlerPathFeature.Error.Message;
                ViewBag.Path = exceptionHandlerPathFeature.Path;
            }

            return View("Error");
        }

        
    }
}