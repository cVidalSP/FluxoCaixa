using FC.Caixa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.Caixa.Tests.Domain
{
    public class CaixaTests
    {
        [Fact(DisplayName = "Credita valor corretamente")]
        [Trait("Categoria", "Caixa")]
        public void CalcularSaldo_SomarUmaNovaMovimentacao()
        {
            //Arrange

            MovimentacaoCaixa movimentacaoCaixa = new()
            {
                tipo = TipoMovimentacao.Entrada,
                valor = 150
            };
            MovimentacaoCaixa movimentacaoCaixa2 = new()
            {
                tipo = TipoMovimentacao.Entrada,
                valor = 200
            };
            MovimentacaoCaixa novaMovimentacao = new()
            {
                tipo = TipoMovimentacao.Entrada,
                valor = 25
            };

            List<MovimentacaoCaixa> list = new() { movimentacaoCaixa, movimentacaoCaixa2 };

            //Act
            Caixa.Domain.Entities.Caixa caixa = new (list);

            caixa.Processar(novaMovimentacao);

            //Assert
            Assert.Equal(375, caixa.Saldo);
        }
        [Fact(DisplayName = "Debita valor corretamente")]
        [Trait("Categoria", "Caixa")]
        public void CalcularSaldo_SubtrairUmaNovaMovimentacao()
        {
            //Arrange

            MovimentacaoCaixa movimentacaoCaixa = new()
            {
                tipo = TipoMovimentacao.Entrada,
                valor = 150
            };
            MovimentacaoCaixa movimentacaoCaixa2 = new()
            {
                tipo = TipoMovimentacao.Entrada,
                valor = 200
            };
            MovimentacaoCaixa novaMovimentacao = new()
            {
                tipo = TipoMovimentacao.Saida,
                valor = 25
            };

            List<MovimentacaoCaixa> list = new() { movimentacaoCaixa, movimentacaoCaixa2 };
            
            //Act
            Caixa.Domain.Entities.Caixa caixa = new(list);

            caixa.Processar(novaMovimentacao);

            //Assert
            Assert.Equal(325, caixa.Saldo);
        }
        [Fact(DisplayName = "Deve retornar erro, lista inconsistente")]
        [Trait("Categoria", "Caixa")]
        public void CalcularSaldo_DeveRetornarException_ListaInconsistente()
        {
            //Arrange

            MovimentacaoCaixa movimentacaoCaixa = new()
            {
                tipo = TipoMovimentacao.Entrada,
                valor = 150
            };
            MovimentacaoCaixa movimentacaoCaixa2 = new()
            {
                tipo = TipoMovimentacao.Saida,
                valor = 500
            };
            MovimentacaoCaixa novaMovimentacao = new()
            {
                tipo = TipoMovimentacao.Saida,
                valor = 20
            };

            List<MovimentacaoCaixa> list = new() { movimentacaoCaixa, movimentacaoCaixa2 };

            //Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Caixa.Domain.Entities.Caixa(list));

            //Assert
            Assert.Equal("Caixa tentou inicializar com lista de movimentações inválida. (Parameter 'ListaMovimentacoes')", exception.Message);
        }
    }
}
