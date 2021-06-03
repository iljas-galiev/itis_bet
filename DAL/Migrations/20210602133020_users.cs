using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Matches_Match_Id",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_Article_Id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_User_Id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ReplyTo",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_User_Id",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_UsersBets_User_Bet_Id",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersBets_AspNetUsers_User_Id",
                table: "UsersBets");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersBets_Bets_Bet_Id",
                table: "UsersBets");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_User_Bet_Id",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Comments_Article_Id",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Article_Id",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CanBetting",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Passport",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Verificated",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "UsersBets",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Bet_Id",
                table: "UsersBets",
                newName: "BetId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersBets_User_Id",
                table: "UsersBets",
                newName: "IX_UsersBets_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersBets_Bet_Id",
                table: "UsersBets",
                newName: "IX_UsersBets_BetId");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Transactions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_User_Id",
                table: "Transactions",
                newName: "IX_Transactions_UserId");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Comments",
                newName: "ArticleId");

            migrationBuilder.RenameColumn(
                name: "ReplyTo",
                table: "Comments",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_User_Id",
                table: "Comments",
                newName: "IX_Comments_ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ReplyTo",
                table: "Comments",
                newName: "IX_Comments_UserId1");

            migrationBuilder.RenameColumn(
                name: "Match_Id",
                table: "Bets",
                newName: "MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_Bets_Match_Id",
                table: "Bets",
                newName: "IX_Bets_MatchId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserBetId",
                table: "Transactions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PassportId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Passports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Serial = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Issued = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Money = table.Column<long>(type: "bigint", nullable: false),
                    CanBet = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserBetId",
                table: "Transactions",
                column: "UserBetId");

            migrationBuilder.CreateIndex(
                name: "IX_Passports_UserId",
                table: "Passports",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Matches_MatchId",
                table: "Bets",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_ArticleId",
                table: "Comments",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId1",
                table: "Comments",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_UsersBets_UserBetId",
                table: "Transactions",
                column: "UserBetId",
                principalTable: "UsersBets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersBets_AspNetUsers_UserId",
                table: "UsersBets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersBets_Bets_BetId",
                table: "UsersBets",
                column: "BetId",
                principalTable: "Bets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Matches_MatchId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_ArticleId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_UserId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_UsersBets_UserBetId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersBets_AspNetUsers_UserId",
                table: "UsersBets");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersBets_Bets_BetId",
                table: "UsersBets");

            migrationBuilder.DropTable(
                name: "Passports");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UserBetId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UserBetId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PassportId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UsersBets",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "BetId",
                table: "UsersBets",
                newName: "Bet_Id");

            migrationBuilder.RenameIndex(
                name: "IX_UsersBets_UserId",
                table: "UsersBets",
                newName: "IX_UsersBets_User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_UsersBets_BetId",
                table: "UsersBets",
                newName: "IX_UsersBets_Bet_Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Transactions",
                newName: "User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                newName: "IX_Transactions_User_Id");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Comments",
                newName: "ReplyTo");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "Comments",
                newName: "User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId1",
                table: "Comments",
                newName: "IX_Comments_ReplyTo");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                newName: "IX_Comments_User_Id");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "Bets",
                newName: "Match_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Bets_MatchId",
                table: "Bets",
                newName: "IX_Bets_Match_Id");

            migrationBuilder.AddColumn<Guid>(
                name: "Article_Id",
                table: "Comments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CanBetting",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Money",
                table: "AspNetUsers",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Passport",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Verificated",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_User_Bet_Id",
                table: "Transactions",
                column: "User_Bet_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Article_Id",
                table: "Comments",
                column: "Article_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Matches_Match_Id",
                table: "Bets",
                column: "Match_Id",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_Article_Id",
                table: "Comments",
                column: "Article_Id",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_User_Id",
                table: "Comments",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ReplyTo",
                table: "Comments",
                column: "ReplyTo",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_User_Id",
                table: "Transactions",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_UsersBets_User_Bet_Id",
                table: "Transactions",
                column: "User_Bet_Id",
                principalTable: "UsersBets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersBets_AspNetUsers_User_Id",
                table: "UsersBets",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersBets_Bets_Bet_Id",
                table: "UsersBets",
                column: "Bet_Id",
                principalTable: "Bets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
