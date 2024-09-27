using FC.Relatorio.DTOs;

namespace FC.Relatorio.Interfaces.Repositories
{
    public interface IRelatorioRepository
    {
        Task<List<MovimentacaoCaixaDTO>> GetAllAsync();
        Task CreateAsync(MovimentacaoCaixaDTO movimentacaoCaixaDTO);
    }
}
