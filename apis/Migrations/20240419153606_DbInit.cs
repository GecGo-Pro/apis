using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apis.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    phone_number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    avatar = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    longitude = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    latitude = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    otp = table.Column<int>(type: "int", nullable: true),
                    deleted = table.Column<int>(type: "int", nullable: true),
                    otp_life = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dispatchers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    phone_number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    avatar = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    otp = table.Column<int>(type: "int", nullable: true),
                    otp_life = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    deleted = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dispatchers", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "drivers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    phone_number = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    current_address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    avatar = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    longitude = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    latitude = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_active = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    deleted = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drivers", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    number_plate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    color = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    deleted = table.Column<int>(type: "int", nullable: true),
                    driver_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.id);
                    table.ForeignKey(
                        name: "FK_cars_drivers_driver_id",
                        column: x => x.driver_id,
                        principalTable: "drivers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dispatch_jobs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    start_longitude = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    start_latitude = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    end_longitude = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    end_latitude = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    start_address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    end_address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    end_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cancell_reason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    dispatcher_id = table.Column<int>(type: "int", nullable: false),
                    driver_id = table.Column<int>(type: "int", nullable: true),
                    car_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dispatch_jobs", x => x.id);
                    table.ForeignKey(
                        name: "FK_dispatch_jobs_cars_car_id",
                        column: x => x.car_id,
                        principalTable: "cars",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_dispatch_jobs_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dispatch_jobs_dispatchers_dispatcher_id",
                        column: x => x.dispatcher_id,
                        principalTable: "dispatchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dispatch_jobs_drivers_driver_id",
                        column: x => x.driver_id,
                        principalTable: "drivers",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "avatar", "created_at", "deleted", "latitude", "longitude", "name", "otp", "otp_life", "phone_number" },
                values: new object[] { 1, "", new DateTime(2024, 4, 19, 15, 36, 5, 114, DateTimeKind.Utc).AddTicks(8277), 0, "10.800102", "106.665794", "Nguyen Van A", 123456, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0123456789" });

            migrationBuilder.InsertData(
                table: "dispatchers",
                columns: new[] { "id", "avatar", "created_at", "deleted", "email", "name", "otp", "otp_life", "phone_number" },
                values: new object[] { 1, "", new DateTime(2024, 4, 19, 15, 36, 5, 114, DateTimeKind.Utc).AddTicks(8926), 0, "", "Nguyen Van B", 654321, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01212345678" });

            migrationBuilder.InsertData(
                table: "drivers",
                columns: new[] { "id", "address", "avatar", "created_at", "current_address", "deleted", "is_active", "latitude", "longitude", "name", "password", "phone_number", "status" },
                values: new object[] { 1, "HCM", null, new DateTime(2024, 4, 19, 15, 36, 5, 114, DateTimeKind.Utc).AddTicks(8998), null, 0, 1, "10.800450", "106.666357", "Nguyen Van C", "abcd", "1234234523", 0 });

            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "id", "color", "created_at", "deleted", "driver_id", "note", "number_plate", "type" },
                values: new object[] { 1, null, new DateTime(2024, 4, 19, 15, 36, 5, 114, DateTimeKind.Utc).AddTicks(9056), 0, 1, "", "49A 222222", "6 cho" });

            migrationBuilder.InsertData(
                table: "dispatch_jobs",
                columns: new[] { "id", "cancell_reason", "car_id", "created_at", "customer_id", "dispatcher_id", "driver_id", "end_address", "end_date", "end_latitude", "end_longitude", "note", "start_address", "start_date", "start_latitude", "start_longitude", "status" },
                values: new object[] { 1, null, 1, new DateTime(2024, 4, 19, 15, 36, 5, 114, DateTimeKind.Utc).AddTicks(9123), 1, 1, 1, "", null, "10.801418", "106.661530", null, "", null, "10.800102", "106.665794", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_cars_driver_id",
                table: "cars",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "IX_dispatch_jobs_car_id",
                table: "dispatch_jobs",
                column: "car_id");

            migrationBuilder.CreateIndex(
                name: "IX_dispatch_jobs_customer_id",
                table: "dispatch_jobs",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_dispatch_jobs_dispatcher_id",
                table: "dispatch_jobs",
                column: "dispatcher_id");

            migrationBuilder.CreateIndex(
                name: "IX_dispatch_jobs_driver_id",
                table: "dispatch_jobs",
                column: "driver_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dispatch_jobs");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "dispatchers");

            migrationBuilder.DropTable(
                name: "drivers");
        }
    }
}
