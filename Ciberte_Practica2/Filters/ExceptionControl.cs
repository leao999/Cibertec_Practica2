using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ciberte_Practica2.Filters
{
    public class ExceptionControl : ActionFilterAttribute, IExceptionFilter
    {
        private static ILog Log { get; set; }
        //GetCurrentMethod() va representar todo el contexto del action result
        ILog log = LogManager.GetLogger
            (
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
            );

        //filterContext cotiene todo el contecto de la accion
        public void OnException(ExceptionContext filterContext)
        {
            //la sgte linea si sale un error sigue ejecutandose la aplizacion
            filterContext.ExceptionHandled = true;
            log.Error(filterContext.Exception);

            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            //usamos el model HandleErrorInfo de la pagina Error.cshtml en la carpeta Shared
            var model = new HandleErrorInfo(filterContext.Exception,
                                            controller,
                                            action);

            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml",
                ViewData =new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };
        }
    }
}