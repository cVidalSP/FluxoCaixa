using FC.Caixa.Domain.Interfaces.Repository;
using FC.Caixa.Domain.Models;
using FC.Caixa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FC.Caixa.Infrastructure.Repositories
{
    public class CaixaRepository : ICaixaRepository
    {
        private readonly ApplicationDbContext _context;

        public CaixaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MovimentacaoCaixa>> BuscarMovimentacoesDia(DateTime data)
        {
            return await (from dados in _context.movimentacoes
                          where dados.datamovimentacao.Day == data.Day
                          select dados).ToListAsync();
        }

        public async Task RegistrarMovimentacaoAsync(MovimentacaoCaixa movimentacao)
        {
            _context.movimentacoes.Add(movimentacao);
            await _context.SaveChangesAsync();
        }
    }
}