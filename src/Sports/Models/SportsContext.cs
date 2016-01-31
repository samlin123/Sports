using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sports.Models
{
    public class SportsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SportsContext() : base("name=SportsContext")
        {
        }

        public System.Data.Entity.DbSet<Sports.Models.Manager.SportsCenter> SportsCenters { get; set; }

        public System.Data.Entity.DbSet<Sports.Models.Manager.BookSiteTemplete> BookSiteTempletes { get; set; }

        public System.Data.Entity.DbSet<Sports.Models.Manager.Site> Sites { get; set; }

        //public System.Data.Entity.DbSet<Sports.Models.Manager.BookRecord> BookRecords { get; set; }

        public System.Data.Entity.DbSet<Sports.Models.Manager.SportCategory> SportCategories { get; set; }

        public System.Data.Entity.DbSet<Sports.Models.Manager.SiteBookStatus> SiteBookStatus { get; set; }
    }
}
