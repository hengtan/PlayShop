using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PS.Produc.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //insert data on products table
            migrationBuilder
                .Sql("INSERT INTO Products (Name, Description, ImageURL, Price, CategoryId, Stock)" +
                    " VALUES ('Iphone 12', " +
                    "'Iphone 12 128GB', " +
                    "'https://www.iphonelife.com/sites/iphonelife.com/files/styles/panopoly_image_original/public/iphone-12-pro-max.jpg', " +
                    "1000, " +
                    "1," +
                    "10)");

            //insert data on products table with category 2
            migrationBuilder
                .Sql("INSERT INTO Products (Name, Description, ImageURL, Price, CategoryId, Stock)" +
                    " VALUES ('T-Shirt', " +
                    "'T-Shirt Black', " +
                    "'https://www.iphonelife.com/sites/iphonelife.com/files/styles/panopoly_image_original/public/iphone-12-pro-max.jpg', " +
                    "20, " +
                    "2," +
                    "5)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //Delete data from products table
            migrationBuilder
                .Sql("DELETE FROM Products");
        }
    }
}
