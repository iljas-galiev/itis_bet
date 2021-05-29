using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class artictes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Articles",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Articles",
                newName: "PublishedAt");

            migrationBuilder.AddColumn<bool>(
                name: "CanBetting",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Articles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Articles",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "Articles",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Sport",
                table: "Articles",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanBetting",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Header",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Sport",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "PublishedAt",
                table: "Articles",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Articles",
                newName: "Text");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Articles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
