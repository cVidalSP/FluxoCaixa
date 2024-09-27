using AutoMapper;
using FC.Caixa.Domain.Models;
using FC.Caixa.DTOs.Request;

namespace FC.Caixa.Application.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MovimentacaoCaixa, MovimentacaoCaixaDTO>();

            CreateMap<MovimentacaoCaixaDTO, MovimentacaoCaixa>();
        }
    }
}
