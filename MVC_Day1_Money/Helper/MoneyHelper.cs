using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Day1_Money.Helper
{
    public static class MoneyHelper
    {
        public static MvcHtmlString SpenClasscolor(this HtmlHelper helper, string SpenClass)
        {
            string Style = (SpenClass == "支出") ? "red" : "blue";
            return MvcHtmlString.Create(String.Format(@"<span style = ""color:{0}"">{1}</ span>", Style, SpenClass));
            //if (SpenClass == "支出")
            //    return MvcHtmlString.Create("<span style = \"color:red\" >支出</ span>");
            //else
            //    return MvcHtmlString.Create(String.Format(@"<span style = ""color:blue"">{0}</ span>", SpenClass));
        }
    }
}