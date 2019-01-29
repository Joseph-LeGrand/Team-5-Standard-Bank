 using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Models
{
    public class DummyContext : DbContext
    {
        public DummyContext(DbContextOptions<DummyContext> options)
           : base(options)
        {
        }

        public DbSet<DummyModel> UserTest { get; set; }
    }
}
