using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DbInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK__User__role_id__37A5467C",
                        column: x => x.role_id,
                        principalTable: "Role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    order_address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK__Order__status_id__34C8D9D1",
                        column: x => x.status_id,
                        principalTable: "Status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Order__user_id__33D4B598",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    recent_price = table.Column<int>(type: "int", nullable: true),
                    thumbnail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<int>(type: "int", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK__Product__categor__31EC6D26",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Product__user_id__32E0915F",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    order_id = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<int>(type: "int", nullable: true),
                    payment_price = table.Column<int>(type: "int", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK__OrderDeta__order__36B12243",
                        column: x => x.order_id,
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__OrderDeta__produ__35BCFE0A",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    rate = table.Column<int>(type: "int", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.id);
                    table.ForeignKey(
                        name: "FK__Review__product___38996AB5",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Review__user_id__398D8EEE",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_status_id",
                table: "Order",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_user_id",
                table: "Order",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_order_id",
                table: "OrderDetail",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_product_id",
                table: "OrderDetail",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_category_id",
                table: "Product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_user_id",
                table: "Product",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_product_id",
                table: "Review",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_user_id",
                table: "Review",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_role_id",
                table: "User",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
