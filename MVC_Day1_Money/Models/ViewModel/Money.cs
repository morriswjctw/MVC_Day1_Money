using MVC_Day1_Money.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Day1_Money.Models.ViewModel
{
    public class Money
    {
        public System.Guid Key { get; set; }

        [Required(ErrorMessage = "此為必填欄位")]
        public int Id { get; set; }
        [DisplayName("類別")]
        [Required(ErrorMessage = "此為必填欄位")]
        public string SpendClass { get; set; }

        [DisplayName("日期")]
        [DayAttribute("2016/1/1")]
        [Required(ErrorMessage ="此為必填欄位")]
        [DataType(DataType.Date)]
        public System.DateTime SpendTime{ get; set; }

        [DisplayName("金額")]
        [Required(ErrorMessage = "此為必填欄位")]
        [Range(1,int.MaxValue,ErrorMessage ="請輸入正整數")]
        public int SpenSum { get; set; }

        [DisplayName("備註")]
        [Required(ErrorMessage = "此為必填欄位")]
        public string Description { get; set; }
    }
}