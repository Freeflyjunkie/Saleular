using System.Data.Entity;
using System.Diagnostics;
using Microsoft.AspNet.Identity.EntityFramework;
using Saleular.Models;

namespace Saleular.DAL
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext() : base("SaleularContext")
        {
            //Database.Log = sql => Debug.Write(sql);
        }
    }
}