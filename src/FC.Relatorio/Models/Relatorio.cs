namespace FC.Relatorio.Models
{
    public class Relatorio
    {
        public int TotalOperacoes { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataRelatorio { get; set; }
        public string PeriodoPesquisado { get; set; }
    }
}
