using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.Sql("INSERT INTO Personas (Nombre, Documento) VALUES ('Juan', '1234567')");
            migrationBuilder.Sql("INSERT INTO Personas (Nombre, Documento) VALUES ('Ana', '7654321')");
            migrationBuilder.Sql("INSERT INTO Personas (Nombre, Documento) VALUES ('Pedro', '1234567')");
            migrationBuilder.Sql("INSERT INTO Personas (Nombre, Documento) VALUES ('Maria', '7654321')");
            migrationBuilder.Sql("INSERT INTO Personas (Nombre, Documento) VALUES ('Carlos', '1234567')");
            migrationBuilder.Sql("INSERT INTO Personas (Nombre, Documento) VALUES ('Lucia', '7654321')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
