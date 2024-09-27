using FC.Relatorio.DTOs;

namespace FC.Relatorio.Interfaces.Services
{
    public interface IRelatorioService
    {
        public Task CriarRegistro(MovimentacaoCaixaDTO movimentacaoCaixaDTO);
    }
}
