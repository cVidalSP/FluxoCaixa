using FC.Caixa.Models;

namespace FC.Caixa.Interfaces.Repository
{
    public interface ICaixaRepository
    {
        public Task RegistrarMovimentacaoAsync(MovimentacaoCaixa movimentacao);
    }
}
