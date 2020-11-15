using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradersPortal.Models;

namespace TradersPortal.Dtos
{
    public class TraderDto
    {
        public int TraderId { get; set; }

      
        public string BusinessName { get; set; }

      
        public string ContactFirstName { get; set; }

       
        public string ContactLastName { get; set; }

        public string Telephone { get; set; }

        public string Mobile { get; set; }



        public string Email { get; set; }


        public DateTime? RegistrationDate { get; set; }



        public int TradeId { get; set; }
        public TradeDto Trade { get; set; }


        public int StateId { get; set; }
        public StateDto State { get; set; }




    }
}