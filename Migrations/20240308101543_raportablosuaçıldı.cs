using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GorevYoneticisi.Migrations
{
    /// <inheritdoc />
    public partial class raportablosuaçıldı : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaporKayit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    raporTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    raporIcerigi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaporKayit", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaporKayit");
        }
    }
}
