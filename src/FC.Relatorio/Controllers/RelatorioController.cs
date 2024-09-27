using FC.Relatorio.DTOs;
using FC.Relatorio.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FC.Relatorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        public RelatorioController(IRelatorioService relatorioService) 
        {
            _relatorioService = relatorioService;
        }

        [HttpGet("BuscarRelatorioDiario")]
        public async Task<IActionResult> RegistrarMovimentacao()
        {
            MovimentacaoCaixaDTO a = new MovimentacaoCaixaDTO()
            {
                tipo = TipoMovimentacao.Entrada,
                valor = 200
            };
            await _relatorioService.CriarRegistro(a);
            return Ok();
        }
    }
}
