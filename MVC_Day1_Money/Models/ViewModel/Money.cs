using MVC_Day1_Money.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Day1_Money.Models.ViewModel
{
    public class Money
    {
        [Required(ErrorMessage = "此為必填欄位")]
        public int Id { get; set; }
        [Required(ErrorMessage = "此為必填欄位")]
        public string SpendClass { get; set; }


        [DayAttribute("2016/1/1")]
        [Required(ErrorMessage ="此為必填欄位")]
        [DataType(DataType.Date)]
        public System.DateTime SpendTime{ get; set; }

        [Required(ErrorMessage = "此為必填欄位")]
        [Range(1,int.MaxValue,ErrorMessage ="請輸入正整數")]
        public int SpenSum { get; set; }

        [Required(ErrorMessage = "此為必填欄位")]
        public string Description { get; set; }
    }
}