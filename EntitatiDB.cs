using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace LucrareDeDisertatie.Models
{


    public class EntitatiDB: DbContext
    {
        public EntitatiDB() : base("MyDBRegister") { }
    public DbSet<Utilizator> Utilizatori { get; set; }
    protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Utilizator>().ToTable("Utilizatori");
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        base.OnModelCreating(modelBuilder);


    }
}
    
   
}