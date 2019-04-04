using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessCoreTests.Migrations
{
    public partial class testentityfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestEntities_TestEntity2s_TestEntity2ID",
                table: "TestEntities");

            migrationBuilder.AlterColumn<int>(
                name: "TestEntity2ID",
                table: "TestEntities",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TestEntities_TestEntity2s_TestEntity2ID",
                table: "TestEntities",
                column: "TestEntity2ID",
                principalTable: "TestEntity2s",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestEntities_TestEntity2s_TestEntity2ID",
                table: "TestEntities");

            migrationBuilder.AlterColumn<int>(
                name: "TestEntity2ID",
                table: "TestEntities",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TestEntities_TestEntity2s_TestEntity2ID",
                table: "TestEntities",
                column: "TestEntity2ID",
                principalTable: "TestEntity2s",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
