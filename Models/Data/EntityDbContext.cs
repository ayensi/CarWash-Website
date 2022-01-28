using otoyikama.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace otoyikama.Models.Data
{
    public class EntityDbContext:DbContext
    {
        public EntityDbContext():base("DataBaseOtoyikama")
        {

        }
        public DbSet<Islem> Islem{ get; set; }
        public DbSet<Musteri> Musteri { get; set; }
        public  DbSet<IslemHizmet> IslemHizmet { get; set; }
        public DbSet<Hizmet> Hizmet { get; set; }
    }
}