using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradersPortal.Models
{
    public class State
    {
        public int StateId { get; set; }

        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        public string StateName { get; set; }

    }
}