using AutoMapper;
using FC.Caixa.DTOs;
using FC.Caixa.Models;

namespace FC.Caixa.Configurations
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
