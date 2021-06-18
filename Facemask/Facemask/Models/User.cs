using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.Models
{
    [Table("Customers")]
    public class User : IdentityUser
    {
        //public string Email { get; set; }
        //public string Password { get; set; }
        public string FullName { get; set; }
        public string BillingAddress { get; set; }
        public string DefaultShippingAddress { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}
