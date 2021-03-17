using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MVCCSharp.Models
{
    public class Leadcontext:DbContext
    {
        public DbSet<Lead> Leads { get; set; }
    }
}