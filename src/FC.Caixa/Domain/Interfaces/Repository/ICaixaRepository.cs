using FC.Caixa.Domain.Models;

namespace FC.Caixa.Domain.Interfaces.Repository
{
    public interface ICaixaRepository
    {
        public Task RegistrarMovimentacaoAsync(MovimentacaoCaixa movimentacao);
        public Task<List<MovimentacaoCaixa>> BuscarMovimentacoesDia(DateTime data);
    }
}
