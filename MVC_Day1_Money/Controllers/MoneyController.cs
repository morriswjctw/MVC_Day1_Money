using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Day1_Money.Models.ViewModel;
using MVC_Day1_Money.Models;

namespace MVC_Day1_Money.Controllers
{
    public class MoneyController : Controller
    {
        enum MoneyCategory { 支出, 收入 };
        MoneyDBEntities MoneyDB = new MoneyDBEntities();
        
        private static List<Money> Spends = new List<Money>()
            {
                new Money() { Id = 1, SpendClass = "支出", SpendTime = DateTime.Now, SpenSum = 1000 },
                new Money() { Id = 2, SpendClass = "支出", SpendTime = DateTime.Now, SpenSum = 2000},
                new Money() {Id = 3, SpendClass = "支出", SpendTime = DateTime.Now, SpenSum = 3000 }
            };
        
        private List<SelectListItem> Categorys = new List<SelectListItem>() {
            new SelectListItem { Text = "支出", Value = ((int)MoneyCategory.支出).ToString() },
            new SelectListItem{ Text = "收入", Value = ((int)(MoneyCategory.收入)).ToString() }
        };
        
        // GET: Money
        public ActionResult Index()
        {
            int DataCount = MoneyDB.AccountBook.Count();
            int TotalPages = DataCount % 50 == 0 ? (DataCount / 50) : (DataCount / 50) + 1;
            ViewBag.Categorys = Categorys;
            ViewBag.TotalPages = TotalPages;
            ViewBag.Page = 1;
            ViewBag.Prev = false;
            ViewBag.Next = true;
            List<Money> Moneys = GetMoney();
            return View(Moneys);
        }
        
        [HttpPost]
        public ActionResult ChangePage(int Page, int TotalPages)
        {
            List<Money> Moneys = GetMoney(Page);
            ViewBag.Page = Page;
            ViewBag.TotalPages = TotalPages;
            ViewBag.Prev = Page == 1 ? false : true;
            ViewBag.Next = Page == TotalPages ? false : true;
            return PartialView("_MoneyListPartialView", Moneys);
        }

        private List<Money> GetMoney(int page = 1)
        {
            var DBData = new List<Money>();
            int i = (page-1) * 50;
            foreach(var item in MoneyDB.AccountBook.OrderBy(c => c.Id).Skip((page-1)*50).Take(50).ToList())
            {
                DBData.Add(new Money()
                {
                    Id = ++i,
                    SpendClass = Enum.GetName(typeof(MoneyCategory), item.Categoryyy),//((MoneyCategory)Enum.Parse(typeof(MoneyCategory), item.Categoryyy.ToString())).ToString(),
                    SpendTime = item.Dateee,
                    SpenSum = item.Amounttt
                });
            }

            return DBData;
        }
    }
}