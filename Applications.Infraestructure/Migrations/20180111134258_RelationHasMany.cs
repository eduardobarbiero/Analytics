using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infraestructure.Config.Migrations
{
    public partial class RelationHasMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValueWorks_Values_ValueId",
                table: "ValueWorks");

            migrationBuilder.AddForeignKey(
                name: "FK_ValueWorks_Values_ValueId",
                table: "ValueWorks",
                column: "ValueId",
                principalTable: "Values",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValueWorks_Values_ValueId",
                table: "ValueWorks");

            migrationBuilder.AddForeignKey(
                name: "FK_ValueWorks_Values_ValueId",
                table: "ValueWorks",
                column: "ValueId",
                principalTable: "Values",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
