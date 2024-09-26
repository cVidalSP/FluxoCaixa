using AutoMapper;
using FC.Caixa.DTOs;
using FC.Caixa.Interfaces.Repository;
using FC.Caixa.Interfaces.Services;
using FC.Caixa.Models;

namespace FC.Caixa.Services
{
    public class CaixaService : ICaixaService
    {
        private readonly ICaixaRepository _caixaRepository;
        private readonly IMapper _mapper;

        public CaixaService(ICaixaRepository caixaRepository, IMapper mapper)
        {
            _caixaRepository = caixaRepository;
            _mapper = mapper;
        }
        public async Task RegistrarMovimentacaoAsync(MovimentacaoCaixaDTO dto)
        {
            MovimentacaoCaixa movimentacao = _mapper.Map<MovimentacaoCaixa>(dto);
            movimentacao.datamovimentacao = DateTime.Now.ToUniversalTime();

            await _caixaRepository.RegistrarMovimentacaoAsync(movimentacao);

            //TODO - Enviar movimentacao para fila
        }
    }
}