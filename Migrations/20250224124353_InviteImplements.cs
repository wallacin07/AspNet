﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNet.Migrations
{
    /// <inheritdoc />
    public partial class InviteImplements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InvitedById",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_InvitedById",
                table: "Users",
                column: "InvitedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_InvitedById",
                table: "Users",
                column: "InvitedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_InvitedById",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_InvitedById",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InvitedById",
                table: "Users");
        }
    }
}
