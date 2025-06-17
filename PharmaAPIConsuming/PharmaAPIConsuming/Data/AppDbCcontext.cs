using Microsoft.EntityFrameworkCore;
using PharmaAPIConsuming.Models;
using System.Data;

namespace PharmaAPIConsuming.Data
{
    public class AppDbCcontext:DbContext
    {
        public AppDbCcontext(DbContextOptions<AppDbCcontext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Branch> Branches { get; set; }

    }
}
