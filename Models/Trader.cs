using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace TradersPortal.Models
{
    public class Trader
    {
        public int TraderId { get; set; }

        [Display(Name = "Business Name")]
        [Required(ErrorMessage = "Please Enter Business Name")]
        public string BusinessName { get; set; }

        [Display(Name = "Contact's First Name")]
        [Required(ErrorMessage = "Please Enter Contact's First Name")]
        public string ContactFirstName { get; set; }

        [Display(Name = "Contact's Last Name")]
        [Required(ErrorMessage = "Please Enter Contact's Last Name")]
        public string ContactLastName { get; set; }


        [Required(ErrorMessage = "Please Enter Your Telephone Number")]
        public string Telephone { get; set; }


        [Required(ErrorMessage = "Please Enter Mobile Contact Number")]
        public string Mobile { get; set; }


        [Required(ErrorMessage = "Please Enter Your Email Address")]
        public string Email { get; set; }


        [Display(Name = "Registration Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RegistrationDate { get; set; }

        [Display(Name = "Trade")]
        [Required(ErrorMessage = "Please Select Your Trade")]
        public int TradeId { get; set; }
        public Trade Trade { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "Please Select Your State")]
        public int StateId { get; set; }
        public State State { get; set; }


      
        public virtual ICollection<File> Files { get; set; }
    }
}