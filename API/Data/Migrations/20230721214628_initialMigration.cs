using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
	/// <inheritdoc />
	public partial class initialMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{

			migrationBuilder.CreateTable(
				name: "Baskets",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					BuyerId = table.Column<string>(type: "longtext", nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Baskets", x => x.Id);
				})
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateTable(
				name: "Products",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					Name = table.Column<string>(type: "longtext", nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4"),
					Description = table.Column<string>(type: "longtext", nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4"),
					Price = table.Column<long>(type: "bigint", nullable: false),
					PictureUrl = table.Column<string>(type: "longtext", nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4"),
					Type = table.Column<string>(type: "longtext", nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4"),
					Brand = table.Column<string>(type: "longtext", nullable: true)
						.Annotation("MySql:CharSet", "utf8mb4"),
					QuantityInStock = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Products", x => x.Id);
				})
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateTable(
				name: "BasketItems",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					Quantity = table.Column<int>(type: "int", nullable: false),
					ProductId = table.Column<int>(type: "int", nullable: false),
					BasketId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BasketItems", x => x.Id);
				})
				.Annotation("MySql:CharSet", "utf8mb4");

			migrationBuilder.CreateIndex(
				name: "IX_BasketItems_BasketId",
				table: "BasketItems",
				column: "BasketId");

			migrationBuilder.CreateIndex(
				name: "IX_BasketItems_ProductId",
				table: "BasketItems",
				column: "ProductId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "BasketItems");

			migrationBuilder.DropTable(
				name: "Baskets");

			migrationBuilder.DropTable(
				name: "Products");
		}
	}
}
