using FC.Caixa.DTOs;
using FC.Caixa.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FC.Caixa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaixaController : ControllerBase
    {
        private readonly ICaixaService _caixaService;

        public CaixaController(ICaixaService caixaService) 
        {
            _caixaService = caixaService;
        }


        [HttpPost("movimentacao")]
        public async Task<IActionResult> RegistrarMovimentacao([FromBody] MovimentacaoCaixaDTO dto)
        {
            await _caixaService.RegistrarMovimentacaoAsync(dto);
            return Ok();
        }
    }
}
