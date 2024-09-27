using FC.Relatorio.DTOs;
using FC.Relatorio.Interfaces.Repositories;
using FC.Relatorio.Interfaces.Services;

namespace FC.Relatorio.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioService(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }
        public async Task CriarRegistro(MovimentacaoCaixaDTO movimentacaoCaixaDTO)
        {
            await _relatorioRepository.CreateAsync(movimentacaoCaixaDTO);
        }
    }
}