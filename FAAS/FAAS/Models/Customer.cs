using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FAAS.Models
{
    public class Customer
    {
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",ErrorMessage = "Please provide valid email id")] 
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please provide UserName", AllowEmptyStrings = false)]
        public string CustomerName { get; set; }

        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Please provide Password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be 8 char long.")]

        public string Password { get; set; }
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Please provide Address", AllowEmptyStrings = false)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please provide PostCode", AllowEmptyStrings = false)]
        public string Postcode { get; set; }

        public string ImageUrl { get; set; } 

    }
}