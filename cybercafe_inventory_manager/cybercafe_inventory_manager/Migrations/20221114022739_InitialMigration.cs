using Microsoft.EntityFrameworkCore.Migrations;

namespace cybercafe_inventory_manager.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand = table.Column<string>(maxLength: 20, nullable: false),
                    processor_speed = table.Column<float>(nullable: false),
                    number_of_cores = table.Column<int>(nullable: false),
                    number_of_usb_ports = table.Column<int>(nullable: false),
                    number_of_hdmi_ports = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    notes = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keyboards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand = table.Column<string>(maxLength: 20, nullable: false),
                    model = table.Column<string>(maxLength: 20, nullable: false),
                    type = table.Column<string>(maxLength: 20, nullable: false),
                    colour = table.Column<string>(maxLength: 20, nullable: true),
                    has_numeric_keypad = table.Column<string>(maxLength: 4, nullable: true),
                    has_backlight = table.Column<string>(maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand = table.Column<string>(maxLength: 20, nullable: false),
                    model = table.Column<string>(maxLength: 20, nullable: false),
                    type = table.Column<string>(maxLength: 20, nullable: false),
                    colour = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monitors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand = table.Column<string>(maxLength: 20, nullable: false),
                    model = table.Column<string>(maxLength: 20, nullable: false),
                    screen_resolution = table.Column<string>(maxLength: 20, nullable: false),
                    ports_and_types = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand = table.Column<string>(maxLength: 20, nullable: false),
                    model = table.Column<string>(maxLength: 20, nullable: false),
                    service_provider = table.Column<string>(maxLength: 20, nullable: false),
                    colour = table.Column<string>(maxLength: 20, nullable: true),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "Keyboards");

            migrationBuilder.DropTable(
                name: "Mice");

            migrationBuilder.DropTable(
                name: "Monitors");

            migrationBuilder.DropTable(
                name: "Routers");
        }
    }
}
