using Microsoft.EntityFrameworkCore.Migrations;

namespace BEndClientes.Migrations
{
    public partial class DBInitial10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDocumentos",
                columns: table => new
                {
                    idtipodoc = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentos", x => x.idtipodoc);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Identificacion = table.Column<decimal>(type: "numeric(11,0)", nullable: false),
                    NombreCompleto = table.Column<string>(type: "varchar(150)", nullable: false),
                    RazonSocial = table.Column<string>(type: "varchar(150)", nullable: false),
                    Proveedores = table.Column<int>(type: "integer", nullable: false),
                    Ventas = table.Column<int>(type: "integer", nullable: false),
                    idtipodoc = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_Clientes_TipoDocumentos_idtipodoc",
                        column: x => x.idtipodoc,
                        principalTable: "TipoDocumentos",
                        principalColumn: "idtipodoc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_idtipodoc",
                table: "Clientes",
                column: "idtipodoc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TipoDocumentos");
        }
    }
}
