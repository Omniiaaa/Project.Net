using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Net.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, " Relive classic board games with our collection of vintage games. Enjoy hours of fun and family entertainment with games that have been enjoyed for generations.", "Toys & Games" },
                    { 2, "Indulge in the luxury of handmade soap, crafted with natural ingredients and essential oils. Our soaps are gentle on the skin and offer a delightful sensory experience.", " Beauty & Personal Care" },
                    { 3, "Create a truly unique and meaningful piece of jewelry with our personalized sterling silver necklaces. Choose from a variety of designs and customization options to create a necklace that's perfect for you.\r\n\r\n", " Jewelry " },
                    { 4, "Boost your energy and focus with our organic matcha powder. This nutrient-rich green tea powder offers a natural and delicious way to enhance your health and well-being.\r\n\r\n", "Food & Beverage" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 123, "Ahmed@gmail.com", "Ahmed", "samy", "Ahmed123" },
                    { 124, "Tamer@gmail.com", "Omar", "Tamer", "Omar124" },
                    { 125, "Nada@gmail.com", "Nada", "Khaled", "Nada125" },
                    { 126, "Hend@gmail.com", "Hend", "Fathi", "Hend126" },
                    { 127, "Ali@gmail.com", "Ali", "Ahmed", "Ali127" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImagePath", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 4, " Our organic matcha powder is sourced from the highest quality tea leaves and is packed with antioxidants and amino acids. Enjoy a cup of matcha for a boost of energy and a calming effect.", "", 250m, 50, "Organic Matcha Powder" },
                    { 2, 3, "This personalized sterling silver necklace is crafted from high-quality sterling silver and features a customizable pendant with your choice of engraving. It's the perfect gift for any occasion.", "", 300m, 40, "Silver Necklace" },
                    { 3, 2, "This handmade soap is crafted with all-natural ingredients, including shea butter, coconut oil, and essential oils. It's gentle on the skin and leaves it feeling soft and hydrated.", "", 120m, 100, "Handmade Soap" },
                    { 4, 1, "This vintage board game is a classic that's perfect for family game nights. It features simple rules, strategic gameplay, and hours of fun for all ages.", "", 500m, 50, "Vintage Board Game" },
                    { 5, 3, "This personalized sterling silver bracelet is crafted from high-quality sterling silver and features a customizable pendant with your choice of engraving. It's the perfect gift for any occasion.", "", 100m, 60, "Silver bracelet" },
                    { 6, 2, "This Moisturizer is crafted with all-natural ingredients, including shea butter, coconut oil, and essential oils. It's gentle on the skin and leaves it feeling soft and hydrated.", "", 150m, 100, "Moisturizer" },
                    { 7, 1, "This scooter is a classic that's perfect for Kids. It features easy to use, strategic gameplay, and hours of fun for all ages.", "", 500m, 50, "scooter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
