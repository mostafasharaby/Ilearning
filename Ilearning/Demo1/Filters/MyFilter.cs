using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Demo1.Filters
{
    public class MyFilter :  ActionFilterAttribute  // CUSTOME FILTER  IActionResult
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("After Executing");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine( "After Executed") ;
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", filterContext.RouteData);
        }
        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
            Debug.WriteLine(message, "Action Filter Log");
        }

    }
}
