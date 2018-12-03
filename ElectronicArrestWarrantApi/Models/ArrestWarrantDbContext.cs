using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElectronicArrestWarrantApi.Models
{
    public class ArrestWarrantDbContext : DbContext
    {
        public ArrestWarrantDbContext() : base("name=ArrestWarrant")
        {

        }

        public DbSet<EntryModel> Warrants { get; set; }
        public DbSet<PersonModel> Persons { get; set; }
    }
}