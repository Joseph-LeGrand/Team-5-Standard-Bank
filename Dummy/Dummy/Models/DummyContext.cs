 using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Models
{
    public class DummyContext : DbContext, IDisposable
    {
        public DummyContext(DbContextOptions<DummyContext> options)
           : base(options)
        {
        }

        public DbSet<DummyModel> UserTest { get; set; }
        public virtual DbSet<DummyModel> User_Test { get; set; }
    }
}
