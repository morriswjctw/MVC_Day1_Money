using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Day1_Money.Models.ViewModel
{
    public class Money
    {   
        public int Id { get; set; }
        public string SpendClass { get; set; }
        [DataType(DataType.Date)]
        public DateTime SpendTime{ get; set; }
        public int SpenSum { get; set; }
        public string Description { get; set; }
    }
}