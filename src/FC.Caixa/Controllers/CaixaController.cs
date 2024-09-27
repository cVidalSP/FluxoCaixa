using FC.Caixa.Domain.Interfaces.Services;
using FC.Caixa.DTOs.Request;
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
            var result = await _caixaService.RegistrarMovimentacaoAsync(dto);
            return StatusCode((int)result.StatusCode, result.Message);
        }
    }
}
