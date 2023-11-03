using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleTaskAPI.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_TASK",
                columns: table => new
                {
                    CL_PK_IDENTIFY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CL_TITLE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CL_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CL_PRIORITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CL_CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CL_LAST_UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CL_IS_DONE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TASK", x => x.CL_PK_IDENTIFY);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TASK");
        }
    }
}
