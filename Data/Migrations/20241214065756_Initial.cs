using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarshipServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hulls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mass = table.Column<int>(type: "int", nullable: false),
                    Armor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hulls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reactors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EnergyMax = table.Column<int>(type: "int", nullable: false),
                    EnergyGainPerSec = table.Column<int>(type: "int", nullable: false),
                    Mass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thrusters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ThrustPerSec = table.Column<int>(type: "int", nullable: false),
                    EnergyDrainPerSec = table.Column<int>(type: "int", nullable: false),
                    Mass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thrusters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DamagePerShot = table.Column<int>(type: "int", nullable: false),
                    ShotsPerSec = table.Column<int>(type: "int", nullable: false),
                    EnergyDrainPerSec = table.Column<int>(type: "int", nullable: false),
                    Mass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HullId = table.Column<int>(type: "int", nullable: false),
                    ReactorId = table.Column<int>(type: "int", nullable: false),
                    ThrusterId = table.Column<int>(type: "int", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Starships_Hulls_HullId",
                        column: x => x.HullId,
                        principalTable: "Hulls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Starships_Reactors_ReactorId",
                        column: x => x.ReactorId,
                        principalTable: "Reactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Starships_Thrusters_ThrusterId",
                        column: x => x.ThrusterId,
                        principalTable: "Thrusters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Starships_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hulls_Armor",
                table: "Hulls",
                column: "Armor");

            migrationBuilder.CreateIndex(
                name: "IX_Hulls_Mass",
                table: "Hulls",
                column: "Mass");

            migrationBuilder.CreateIndex(
                name: "IX_Hulls_Name",
                table: "Hulls",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Reactors_EnergyGainPerSec",
                table: "Reactors",
                column: "EnergyGainPerSec");

            migrationBuilder.CreateIndex(
                name: "IX_Reactors_EnergyMax",
                table: "Reactors",
                column: "EnergyMax");

            migrationBuilder.CreateIndex(
                name: "IX_Reactors_Mass",
                table: "Reactors",
                column: "Mass");

            migrationBuilder.CreateIndex(
                name: "IX_Reactors_Name",
                table: "Reactors",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Starships_HullId",
                table: "Starships",
                column: "HullId");

            migrationBuilder.CreateIndex(
                name: "IX_Starships_Name",
                table: "Starships",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Starships_Owner",
                table: "Starships",
                column: "Owner");

            migrationBuilder.CreateIndex(
                name: "IX_Starships_ReactorId",
                table: "Starships",
                column: "ReactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Starships_ThrusterId",
                table: "Starships",
                column: "ThrusterId");

            migrationBuilder.CreateIndex(
                name: "IX_Starships_WeaponId",
                table: "Starships",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Thrusters_EnergyDrainPerSec",
                table: "Thrusters",
                column: "EnergyDrainPerSec");

            migrationBuilder.CreateIndex(
                name: "IX_Thrusters_Mass",
                table: "Thrusters",
                column: "Mass");

            migrationBuilder.CreateIndex(
                name: "IX_Thrusters_Name",
                table: "Thrusters",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Thrusters_ThrustPerSec",
                table: "Thrusters",
                column: "ThrustPerSec");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_DamagePerShot",
                table: "Weapons",
                column: "DamagePerShot");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_EnergyDrainPerSec",
                table: "Weapons",
                column: "EnergyDrainPerSec");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_Mass",
                table: "Weapons",
                column: "Mass");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_Name",
                table: "Weapons",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_ShotsPerSec",
                table: "Weapons",
                column: "ShotsPerSec");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Starships");

            migrationBuilder.DropTable(
                name: "Hulls");

            migrationBuilder.DropTable(
                name: "Reactors");

            migrationBuilder.DropTable(
                name: "Thrusters");

            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
