using AutoMapper;
using FC.Caixa.DTOs;
using FC.Caixa.Infra;
using FC.Caixa.Interfaces.Repository;
using FC.Caixa.Interfaces.Services;
using FC.Caixa.Models;

namespace FC.Caixa.Services
{
    public class CaixaService : ICaixaService
    {
        private readonly ICaixaRepository _caixaRepository;
        private readonly IMapper _mapper;
        private readonly RabbitMQService _rabbitMQService;

        public CaixaService(ICaixaRepository caixaRepository, IMapper mapper, RabbitMQService rabbitMQService)
        {
            _caixaRepository = caixaRepository;
            _mapper = mapper;
            _rabbitMQService = rabbitMQService;
        }
        public async Task RegistrarMovimentacaoAsync(MovimentacaoCaixaDTO dto)
        {
            MovimentacaoCaixa movimentacao = _mapper.Map<MovimentacaoCaixa>(dto);
            movimentacao.datamovimentacao = DateTime.Now.ToUniversalTime();

            await _caixaRepository.RegistrarMovimentacaoAsync(movimentacao);

            _rabbitMQService.EnviarMovimentacao(movimentacao);
        }
    }
}