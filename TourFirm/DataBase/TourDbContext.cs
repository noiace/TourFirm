using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourFirm.Models;

namespace TourFirm.DataBase
{
    public class TourDbContext : DbContext
    {
        private static TourDbContext _context;

        public static TourDbContext GetContext()
        {
            if (_context == null)
                _context = new TourDbContext();
            return _context;
        }

        public TourDbContext()
        {

        }

        public TourDbContext(DbContextOptions<TourDbContext> options) : base(options)
        {
            Database.EnsureCreated();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=TourFirm;Username=postgres;Password=ilywenttosmoke19");
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
    }
}
