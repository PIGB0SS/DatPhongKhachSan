﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class themsophong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelNumbers",
                columns: table => new
                {
                    Hotel_Number = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelNumbers", x => x.Hotel_Number);
                    table.ForeignKey(
                        name: "FK_HotelNumbers_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HotelNumbers",
                columns: new[] { "Hotel_Number", "HotelId", "SpecialDetails" },
                values: new object[,]
                {
                    { 201, 1, null },
                    { 202, 1, null },
                    { 203, 1, null },
                    { 204, 1, null },
                    { 205, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelNumbers_HotelId",
                table: "HotelNumbers",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelNumbers");
        }
    }
}
