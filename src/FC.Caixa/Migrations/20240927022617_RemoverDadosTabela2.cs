using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FC.Caixa.Migrations
{
    /// <inheritdoc />
    public partial class RemoverDadosTabela2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM movimentacoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
