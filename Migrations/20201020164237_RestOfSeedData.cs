using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations
{
    public partial class RestOfSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Big Ass Park", "Central Park" },
                    { 2, 1, "French Gift to the US", "Statue Of Liberty" },
                    { 3, 2, "Not as big as you'd think", "Eifell Tower" },
                    { 4, 2, "They love them snails", "Snails" },
                    { 5, 3, "Money Sinks", "Casinos" },
                    { 6, 3, "Them hoes ain't loyal", "Hoes" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
