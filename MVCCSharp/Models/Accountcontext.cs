using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCCSharp.Models
{
    public class Accountcontext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
}