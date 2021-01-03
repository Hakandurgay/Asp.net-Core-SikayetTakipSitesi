using Microsoft.EntityFrameworkCore;
using SikayetTakipSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SikayetTakipSitesi.Data
{
    public class SikayetDbContext:DbContext
    {
        public SikayetDbContext(DbContextOptions<SikayetDbContext> options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Member> Members { get; set; }
     //   public DbSet<Country> Countries { get; set; }
        public DbSet<CategoryBrand> CategoryBrands { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
