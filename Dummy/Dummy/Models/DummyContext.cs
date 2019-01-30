 using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dummy.Models
{
   /* public interface IDummyDbContext
    {
        DbSet<DummyModel> UserTest { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
    */
    public class DummyContext : DbContext
    {
        public DummyContext(DbContextOptions<DummyContext> options)
           : base(options)
        {
        }

        

        public virtual DbSet<DummyModel> UserTest { get; set; }
       // public virtual DbSet<DummyModel> User_Test { get; set; }
    }
}
