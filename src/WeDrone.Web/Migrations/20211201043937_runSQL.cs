using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeDrone.Web.Migrations
{
    public partial class runSQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin"));
            var sqlDir = Path.Combine(basePath, "Core/Persistence/");
            var sqlFile = Path.Combine(sqlDir, @"SetupViews.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin"));
            var sqlDir = Path.Combine(basePath, "Core/Persistence/");
            var sqlFile = Path.Combine(sqlDir, @"TearDownViews.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }
    }
}
