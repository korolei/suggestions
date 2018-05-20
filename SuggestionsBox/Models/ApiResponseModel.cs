using System;
using System.Linq;
using System.Web.Mvc;

namespace SuggestionsBox.Models
{
    public class ApiResponseModel:ActionResult
    {
        public object Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            Success = (context.RequestContext.HttpContext.AllErrors ?? throw new InvalidOperationException()).Any();
        }
    }
}