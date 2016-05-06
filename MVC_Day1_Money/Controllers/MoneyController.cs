using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Day1_Money.Models.ViewModel;
using MVC_Day1_Money.Models;
using System.Data.SqlTypes;
using MVC_Day1_Money.Filter;

namespace MVC_Day1_Money.Controllers
{
    public class MoneyController : Controller
    {
        Dictionary<int, string> MoneyCategory = 
            new Dictionary<int, string>(){ {0,"支出"},{1,"收入"}};
        MoneyDBEntities MoneyDB = new MoneyDBEntities();
        
        // GET: Money
        //[LogAttribute]
        public ActionResult Index()
        {
            List<SelectListItem> Categorys = new List<SelectListItem>();
            foreach(var item in MoneyCategory)
            {
                Categorys.Add(new SelectListItem
                {
                    Text = item.Value,
                    Value = item.Key.ToString()
                });
            }
            //Enum.GetName(typeof(MoneyCategory), i)
            ViewBag.Categorys = Categorys;
            return View();
        }

        public ActionResult _MoneyListPartialView()
        {
            int DataCount = MoneyDB.AccountBook.Count();
            int TotalPages = DataCount % 50 == 0 ? (DataCount / 50) : (DataCount / 50) + 1;

            ViewBag.TotalPages = TotalPages;
            ViewBag.Counts = DataCount;
            ViewBag.Page = 1;
            List<Money> Moneys = GetMoney();
            return View(Moneys);
        }
        
        [HttpPost]
        public ActionResult ChangePage(int Page, int TotalPages)
        {
            List<Money> Moneys = GetMoney(Page);
            ViewBag.Page = Page;
            ViewBag.TotalPages = TotalPages;
            return PartialView("_MoneyListPartialView", Moneys);
        }

        private List<Money> GetMoney(int page = 1)
        {
            var DBData = new List<Money>();
            int i = (page-1) * 50;
            foreach(var item in MoneyDB.AccountBook.OrderBy(c => c.Dateee).Skip((page-1)*50).Take(50).ToList())
            {
                DBData.Add(new Money()
                {
                    Key = item.Id,
                    Id = ++i,
                    SpendClass = MoneyCategory[item.Categoryyy],//Enum.GetName(typeof(MoneyCategory), item.Categoryyy),//((MoneyCategory)Enum.Parse(typeof(MoneyCategory), item.Categoryyy.ToString())).ToString(),
                    SpendTime = item.Dateee,
                    SpenSum = item.Amounttt
                });
            }

            return DBData;
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int SpendClass, DateTime SpendTime, int SpenSum, string Description)
        {
            if (!ModelState.IsValid)
                return Content("");
            
            AccountBook AddData = new AccountBook
            {
                Id = Guid.NewGuid(),
                Categoryyy = SpendClass,
                Dateee = SpendTime,
                Amounttt = SpenSum,
                Remarkkk = Description
            };

            MoneyDB.AccountBook.Add(AddData);
            MoneyDB.SaveChanges();
            return RedirectToAction("_MoneyListPartialView");
            //return RedirectToAction("index");
        }

        [HttpGet]
        public PartialViewResult Edit(System.Guid MoneyId)
        {
            var AccountBook = MoneyDB.AccountBook.Single(c => c.Id == MoneyId);
            Money MoneyDetail = new Money()
            {
                Key = AccountBook.Id,
                SpendClass = MoneyCategory[AccountBook.Categoryyy],
                SpendTime = AccountBook.Dateee,
                SpenSum = AccountBook.Amounttt,
                Description = AccountBook.Remarkkk
            };
            List<SelectListItem> Categorys = new List<SelectListItem>();
            foreach (var item in MoneyCategory)
            {
                Categorys.Add(new SelectListItem
                {
                    Text = item.Value,
                    Value = item.Key.ToString(),
                    Selected = item.Key.Equals(AccountBook.Categoryyy)
                });
            }
            ViewBag.Categorys = Categorys;
            return PartialView("Edit", MoneyDetail);
        }

        [HttpPost]
        public ActionResult Edit(Money MoneyEdit)
        {
            var AccountBook = MoneyDB.AccountBook.Single(c => c.Id == MoneyEdit.Key);
            
            if (AccountBook != null)
            {
                AccountBook.Categoryyy = int.Parse(MoneyEdit.SpendClass);
                AccountBook.Dateee = MoneyEdit.SpendTime;
                AccountBook.Amounttt = MoneyEdit.SpenSum;
                AccountBook.Remarkkk = MoneyEdit.Description;
                MoneyDB.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}