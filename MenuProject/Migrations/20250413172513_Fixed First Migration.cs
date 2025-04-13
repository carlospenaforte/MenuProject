using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuProject.Migrations
{
    /// <inheritdoc />
    public partial class FixedFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "DishIngredients");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTSN8GeAtB9n7it8mS7J4zIbtQvXQcLy1gjEQ&s");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DishIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DishIngredients",
                keyColumns: new[] { "DishId", "IngredientId" },
                keyValues: new object[] { 1, 1 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DishIngredients",
                keyColumns: new[] { "DishId", "IngredientId" },
                keyValues: new object[] { 2, 2 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");
        }
    }
}
