using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_framework_one.Migrations
{
    public partial class seg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Pedido_pedidoId",
                table: "Nota");

            migrationBuilder.RenameColumn(
                name: "pedidoId",
                table: "Nota",
                newName: "PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_Nota_pedidoId",
                table: "Nota",
                newName: "IX_Nota_PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Pedido_PedidoId",
                table: "Nota",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Pedido_PedidoId",
                table: "Nota");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "Nota",
                newName: "pedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_Nota_PedidoId",
                table: "Nota",
                newName: "IX_Nota_pedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Pedido_pedidoId",
                table: "Nota",
                column: "pedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
