namespace FC.Caixa.Domain.Models
{
    public class MovimentacaoCaixa
    {
        public Guid id { get; set; }
        public decimal valor { get; set; }
        public TipoMovimentacao tipo { get; set; } // Entrada ou Saída
        public DateTime datamovimentacao { get; set; }
    }

    public enum TipoMovimentacao
    {
        Entrada = 1,
        Saida = 2
    }
}
