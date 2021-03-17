using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCCSharp.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int Personid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone{ get; set; }
        public string Empid { get; set; }
        public string Type { get; set; }

    }
}