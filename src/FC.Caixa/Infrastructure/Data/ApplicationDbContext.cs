using FC.Caixa.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FC.Caixa.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<MovimentacaoCaixa> movimentacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovimentacaoCaixa>().ToTable("movimentacoes");
        }
    }
}
