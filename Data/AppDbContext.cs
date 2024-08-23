using Microsoft.EntityFrameworkCore;
using InstrumentoT4E0_29.Models;

namespace InstrumentoT4E0_29.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EncuadreBDT4E0_29> EncuadreBDT4E0_29 { get; set; }

        public DbSet<MonadicaBDT4E0_29> MonadicaBDT4E0_29 { get; set; }

        public DbSet<EFinalBDT4E0_29> EFinalBDT4E0_29 { get; set; }
    }
}
