using Microsoft.EntityFrameworkCore.Migrations;

namespace zlobek.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Child_ChildId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Teacher_TeacherID",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_ChildId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_TeacherID",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "Groups");

            migrationBuilder.AddColumn<int>(
                name: "GroupsGroupId",
                table: "Teacher",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupsGroupId",
                table: "Child",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_GroupsGroupId",
                table: "Teacher",
                column: "GroupsGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Child_GroupsGroupId",
                table: "Child",
                column: "GroupsGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Child_Groups_GroupsGroupId",
                table: "Child",
                column: "GroupsGroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Groups_GroupsGroupId",
                table: "Teacher",
                column: "GroupsGroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Child_Groups_GroupsGroupId",
                table: "Child");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Groups_GroupsGroupId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_GroupsGroupId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Child_GroupsGroupId",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "GroupsGroupId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "GroupsGroupId",
                table: "Child");

            migrationBuilder.AddColumn<int>(
                name: "ChildId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherID",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ChildId",
                table: "Groups",
                column: "ChildId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TeacherID",
                table: "Groups",
                column: "TeacherID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Child_ChildId",
                table: "Groups",
                column: "ChildId",
                principalTable: "Child",
                principalColumn: "ChildID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Teacher_TeacherID",
                table: "Groups",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
