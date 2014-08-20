using System.Diagnostics;
using Saleular.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Saleular.DAL
{
    public class SaleularContext : DbContext
    {
        public SaleularContext() : base("SaleularContext")
        {
            Database.Log = sql => Debug.Write(sql);
        }

        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<PriceListRequest> PriceListRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();      
        }
    }
}