using FC.Caixa.Domain.Models;

namespace FC.Caixa.DTOs.Request
{
    public class MovimentacaoCaixaDTO
    {
        public decimal Valor { get; set; }
        public TipoMovimentacao Tipo { get; set; }
    }
}
