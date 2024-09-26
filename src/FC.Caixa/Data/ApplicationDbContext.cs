﻿using FC.Caixa.Models;
using Microsoft.EntityFrameworkCore;

namespace FC.Caixa.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<MovimentacaoCaixa> movimentacoes { get; set; }
    }
}
