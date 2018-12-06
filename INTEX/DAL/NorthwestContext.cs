using INTEX.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace INTEX.DAL
{
    public class NorthwestContext : DbContext
    {
        public NorthwestContext()
            : base("NorthwestConnection")
        {

        }

        public DbSet<Assay> Assay { get; set; }
        public DbSet<Compound> Compound { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Sample> Sample { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<TestTypes> TestTypes { get; set; }
        public DbSet<State> State { get; set; }

        public System.Data.Entity.DbSet<INTEX.Models.Quote> Quotes { get; set; }
    }
}