using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCrud.Data
{
    public class BlazorDbContext : DbContext
    {
        public DbSet<Students> Students { get; set; }

        public BlazorDbContext(DbContextOptions<BlazorDbContext> options) : base(options)
        {

        }
        
    }
}
