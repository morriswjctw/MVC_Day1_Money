using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Day1_Money.Models.ViewModel;

namespace MVC_Day1_Money.Controllers
{
    public class MoneyController : Controller
    {
        private static List<Money> Spends = new List<Money>()
            {
                new Money() { Id = 1, SpendClass = "支出", SpendTime = DateTime.Now, SpenSum = 1000 },
                new Money() { Id = 2, SpendClass = "支出", SpendTime = DateTime.Now, SpenSum = 2000},
                new Money() {Id = 3, SpendClass = "支出", SpendTime = DateTime.Now, SpenSum = 3000 }
            };
        // GET: Money
        public ActionResult Index()
        {
            return View(Spends);
        }
    }
}