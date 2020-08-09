using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadidato",
                columns: table => new
                {
                    IdCandidato = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCandidato = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    fotoCandidato = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PartidoCandidato = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PuestoCandidato = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadidato", x => x.IdCandidato);
                });

            migrationBuilder.CreateTable(
                name: "Ciudadanos",
                columns: table => new
                {
                    Cedula = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudadanos", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "Elecciones",
                columns: table => new
                {
                    IdElecciones = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEleciones = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Fecha = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elecciones", x => x.IdElecciones);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePartido = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DescripcionPartido = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LogoPartido = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PuestoElectivo",
                columns: table => new
                {
                    IdPuesto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePuesto = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DescripcionPuesto = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuestoElectivo", x => x.IdPuesto);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadidato");

            migrationBuilder.DropTable(
                name: "Ciudadanos");

            migrationBuilder.DropTable(
                name: "Elecciones");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "PuestoElectivo");
        }
    }
}
