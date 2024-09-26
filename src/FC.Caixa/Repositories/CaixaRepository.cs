using FC.Caixa.Data;
using FC.Caixa.Interfaces.Repository;
using FC.Caixa.Models;

namespace FC.Caixa.Repositories
{
    public class CaixaRepository : ICaixaRepository
    {
        private readonly ApplicationDbContext _context;

        public CaixaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RegistrarMovimentacaoAsync(MovimentacaoCaixa movimentacao)
        {
            _context.movimentacoes.Add(movimentacao);
            await _context.SaveChangesAsync();
        }
    }
}
