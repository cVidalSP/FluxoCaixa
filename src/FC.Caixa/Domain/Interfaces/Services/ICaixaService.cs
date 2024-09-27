using FC.Caixa.DTOs.Request;
using FC.Caixa.DTOs.Response;

namespace FC.Caixa.Domain.Interfaces.Services
{
    public interface ICaixaService
    {
        public Task<BaseResponseDTO> RegistrarMovimentacaoAsync(MovimentacaoCaixaDTO dto);
    }
}
