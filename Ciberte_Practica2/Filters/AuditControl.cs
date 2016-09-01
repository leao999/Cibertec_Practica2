using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ciberte_Practica2.Filters
{
    public class AuditControl: ActionFilterAttribute
    {
        private static ILog Log { get; set; }
        //GetCurrentMethod() va representar todo el contexto del action result
        ILog log = LogManager.GetLogger
            (
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
            );
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Message(filterContext, "OnActionExecuted");
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            /*
            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            var filterMethod = "OnResultExecuted";
            log.Info($"{controller} in action {action} on {filterMethod}"); */

            Message(filterContext, "OnResultExecuted");
        }

        private void Message(ControllerContext context, string filterMethod)
        {
            var controller = context.RouteData.Values["controller"].ToString();
            var action = context.RouteData.Values["action"].ToString();

            log.Info($"{controller} in action {action} on {filterMethod}");
        }

    }
}