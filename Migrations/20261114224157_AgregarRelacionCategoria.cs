using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieZone.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "PeliculasColeccion",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Acción / DC Comics" },
                    { 2, "Aventura / Fantasía" },
                    { 3, "Terror / Paranormal" },
                    { 4, "Animación / Videojuegos" },
                    { 5, "Acción / Suspenso" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasColeccion_CategoriaId",
                table: "PeliculasColeccion",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeliculasColeccion_Categorias_CategoriaId",
                table: "PeliculasColeccion",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeliculasColeccion_Categorias_CategoriaId",
                table: "PeliculasColeccion");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_PeliculasColeccion_CategoriaId",
                table: "PeliculasColeccion");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "PeliculasColeccion");
        }
    }
}
