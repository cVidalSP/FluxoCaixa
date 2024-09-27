using FC.Caixa.Domain.Models;

namespace FC.Caixa.Domain.Entities
{
    public class Caixa
    {
        public decimal Saldo { get; private set; }

        public Caixa(List<MovimentacaoCaixa> ListaMovimentacoes) 
        {
            foreach (var item in ListaMovimentacoes) 
            {
                Saldo += item.tipo == TipoMovimentacao.Entrada ? item.valor : item.valor * -1;
            }

            if (Saldo < 0) 
            {
                throw new ArgumentException("Caixa tentou inicializar com lista de movimentações inválida.", nameof(ListaMovimentacoes));
            }
        }
        public bool Processar(MovimentacaoCaixa movimentacaoCaixa) 
        {
            if (!ValidarValor(movimentacaoCaixa.valor)) return false;

            switch (movimentacaoCaixa.tipo) 
            {
                case TipoMovimentacao.Entrada:
                    Creditar(movimentacaoCaixa.valor);
                    return true;
                case TipoMovimentacao.Saida:
                    return Debitar(movimentacaoCaixa.valor);
                default:
                    return false;
            }
            return false;
        }

        private void Creditar(decimal valor) 
        {
            Saldo += valor;
        }
        private bool Debitar(decimal valor) 
        {
            decimal saldo = Saldo - valor;
            if (saldo < 0) return false;
            Saldo = saldo;
            return true;
        }

        private bool ValidarValor(decimal valor) 
        {
            return valor > 0;
        }
    }
}