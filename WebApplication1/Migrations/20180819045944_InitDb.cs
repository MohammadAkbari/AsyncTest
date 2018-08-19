using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Property1 = table.Column<int>(nullable: false),
                    Property2 = table.Column<int>(nullable: false),
                    Property3 = table.Column<int>(nullable: false),
                    Property4 = table.Column<string>(nullable: true),
                    Property5 = table.Column<string>(nullable: true),
                    Property6 = table.Column<string>(nullable: true),
                    Property7 = table.Column<DateTime>(nullable: false),
                    Property8 = table.Column<DateTime>(nullable: false),
                    Property9 = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
