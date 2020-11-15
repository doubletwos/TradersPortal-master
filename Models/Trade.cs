using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradersPortal.Models
{
    public class Trade
    {
        public int TradeId { get; set; }


        [Display(Name = ("Trade Name"))]
        [Required]
        public string TradeName { get; set; }

    }
}