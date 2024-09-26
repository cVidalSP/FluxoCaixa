using FC.Caixa.Models;

namespace FC.Caixa.DTOs
{
    public class MovimentacaoCaixaDTO
    {
        public decimal Valor { get; set; }
        public TipoMovimentacao Tipo { get; set; }
    }
}
