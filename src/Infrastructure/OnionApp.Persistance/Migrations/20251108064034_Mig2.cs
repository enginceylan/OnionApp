using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAENhzA4xMIh27qb169+gZDzSe+RN8QC4M9vh3/J/+yycGyd/XMrlJaG7m7Gjrr07ikw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { "USER@GMAIL.COM", "AQAAAAIAAYagAAAAENhzA4xMIh27qb169+gZDzSe+RN8QC4M9vh3/J/+yycGyd/XMrlJaG7m7Gjrr07ikw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { null, "AQAAAAIAAYagAAAAEE8KkpKdPfevAH7kfGtMFniBo/aie/4/WW5vX3BtS9NT/pr3rjkd+Vyp3o3NxckHYw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NormalizedEmail", "PasswordHash" },
                values: new object[] { null, "AQAAAAIAAYagAAAAENa/OIkRugbPnBOSrXZt1Sc9QS979k+nwR9nSVm7yBQ1keWvgnN+hMNDvHXpIrVTIA==" });
        }
    }
}
