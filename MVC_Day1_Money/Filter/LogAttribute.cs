using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Day1_Money.Filter
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //base.OnActionExecuted(filterContext);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"D:\log.txt", true))
            {
                file.WriteLine(string.Format(@"action end time:{0}", DateTime.Now.ToString()));
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"D:\log.txt", true))
            {
                file.WriteLine(string.Format(@"into action time:{0}", DateTime.Now.ToString()));
                //StreamWriter sw = new StreamWriter(@"D:\log.txt");
                //sw.WriteLine(string.Format(@"into action time:{0}",DateTime.Now.ToString()));            // 寫入文字
                //sw.Close();
            }
        }
    }
}