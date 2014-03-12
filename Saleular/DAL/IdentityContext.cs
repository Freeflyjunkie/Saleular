using System.Diagnostics;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Saleular.Models;

namespace Saleular.DAL
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext() : base("SaleularContext")
        {
            Database.Log = sql => Debug.Write(sql);
        }
    }
}