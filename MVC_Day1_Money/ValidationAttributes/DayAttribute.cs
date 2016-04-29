using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Day1_Money.ValidationAttributes
{
    public class DayAttribute : ValidationAttribute, IClientValidatable
    {
        private string inputDays;
        /// <summary>
        /// 日期範圍驗證<para>只驗證日期，不考慮時間</para>
        /// </summary>
        public DayAttribute(string inputDays)
        {
            this.inputDays = inputDays;
        }
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            //var compareDate = value as DateTime?;
            var compareDates = value as string;
            DateTime compareDate = Convert.ToDateTime(compareDates);
            return compareDate.Date <= DateTime.Today;
            //if (compareDate.HasValue)
            //{
            //    compareDate = compareDate.Value.Date;
            //    return compareDate.Value.Date <= DateTime.Today;
            //}
            //return false;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "dayattribute",
                ErrorMessage = "日期需小於或等於今日"
                //ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };
            rule.ValidationParameters["inputdays"] = inputDays;
            yield return rule;
        }
    }
}