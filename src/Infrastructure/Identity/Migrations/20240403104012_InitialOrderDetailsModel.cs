using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microsoft.eShopWeb.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class InitialOrderDetailsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "OrderDetails",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                OrderId = table.Column<int>(type: "int", nullable: false),
                BuyerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                OrderDate=table.Column<DateTime>(type:"date", nullable:false),
                Address= table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                TotalPrice=table.Column<decimal>(type:"decimal", nullable:false),
                Status = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true,defaultValue:"Pending"),
                
                
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OrderDetails", x => x.Id);
                table.CheckConstraint("CK_OrderDetails_Status", "Status IN ('Pending', 'Approved')");
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
