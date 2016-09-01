using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ciberte_Practica2.Helpers
{
    public static class CustomHelper
    {
        //this HtmlHelper: se indica con la palabra this que se va extender(agregar) la clase HtmlHelper
        public static IHtmlString GetDate(this HtmlHelper helper, string text)
        {
            return new HtmlString($"<h1>{text} - {DateTime.Now.ToShortDateString() }</h1>");
        }
    }
}