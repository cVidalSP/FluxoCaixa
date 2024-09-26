using FC.Caixa.DTOs;

namespace FC.Caixa.Interfaces.Services
{
    public interface ICaixaService
    {
        public Task RegistrarMovimentacaoAsync(MovimentacaoCaixaDTO dto);
    }
}
