using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace MVCCSharp.Models
{
 
    [Table("Leads")]
    public partial class Lead
    {
        public int Leadid { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string SourceLead { get; set; }
        public Nullable<System.DateTime> CreatDate { get; set; }
        public string InteractionType { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public string Details { get; set; }
        public string Empid { get; set; }
        public string LeadScore { get; set; }
    }
}
