using AutoMapper;
using FC.Caixa.Domain.Interfaces.Repository;
using FC.Caixa.Domain.Interfaces.Services;
using FC.Caixa.Domain.Models;
using FC.Caixa.DTOs.Request;
using FC.Caixa.DTOs.Response;
using FC.Caixa.Infrastructure.services;

namespace FC.Caixa.Application.Services
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
        public async Task<BaseResponseDTO> RegistrarMovimentacaoAsync(MovimentacaoCaixaDTO dto)
        {
            BaseResponseDTO result = new BaseResponseDTO();
            MovimentacaoCaixa movimentacao = _mapper.Map<MovimentacaoCaixa>(dto);
            movimentacao.datamovimentacao = DateTime.Now.ToUniversalTime();

            List<MovimentacaoCaixa> movimentacoes = await _caixaRepository.BuscarMovimentacoesDia(DateTime.Now.ToUniversalTime());

            Domain.Entities.Caixa caixa = new Domain.Entities.Caixa(movimentacoes);

            if (caixa.Processar(movimentacao)) 
            {
                await _caixaRepository.RegistrarMovimentacaoAsync(movimentacao);

                _rabbitMQService.EnviarMovimentacao(movimentacao);

                result.Success = true;
                result.StatusCode = System.Net.HttpStatusCode.OK;
                result.Message = "Sucesso ao processar movimentação. Saldo atual: " + caixa.Saldo;

                return result;
            };

            result.Success = false;
            result.StatusCode = System.Net.HttpStatusCode.BadRequest;
            result.Message = "Erro ao processar movimentação";

            return result;
        }
    }
}