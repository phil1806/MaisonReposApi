using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaisonReposApi.Domaines.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategorieDesSoins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieSoin = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieDesSoins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fonctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fonction = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fonctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Residants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricule = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateNass = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEntre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSortie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personnels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Matricule = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FonctionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personnels_Fonctions_FonctionId",
                        column: x => x.FonctionId,
                        principalTable: "Fonctions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResidantSuivis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricule = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    residantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidantSuivis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidantSuivis_Residants_residantId",
                        column: x => x.residantId,
                        principalTable: "Residants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoinsAjouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescSoins = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategorieDesSoinsId = table.Column<int>(type: "int", nullable: false),
                    PersonnelCreatedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoinsAjouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoinsAjouts_CategorieDesSoins_CategorieDesSoinsId",
                        column: x => x.CategorieDesSoinsId,
                        principalTable: "CategorieDesSoins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoinsAjouts_Personnels_PersonnelCreatedId",
                        column: x => x.PersonnelCreatedId,
                        principalTable: "Personnels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrancheHoraires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Horaire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    personnelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrancheHoraires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrancheHoraires_Personnels_personnelId",
                        column: x => x.personnelId,
                        principalTable: "Personnels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Boissons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QteBoisson = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Normal"),
                    DescBoisson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeBoisson = table.Column<DateTime>(type: "datetime2", nullable: false),
                    personnelId = table.Column<int>(type: "int", nullable: false),
                    CategorieDesSoinId = table.Column<int>(type: "int", nullable: false),
                    residantSuiviId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boissons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boissons_CategorieDesSoins_CategorieDesSoinId",
                        column: x => x.CategorieDesSoinId,
                        principalTable: "CategorieDesSoins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Boissons_Personnels_personnelId",
                        column: x => x.personnelId,
                        principalTable: "Personnels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Boissons_ResidantSuivis_residantSuiviId",
                        column: x => x.residantSuiviId,
                        principalTable: "ResidantSuivis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parametres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saturation = table.Column<int>(type: "int", nullable: false, defaultValue: 95),
                    Tension = table.Column<double>(type: "float", nullable: false, defaultValue: 12.6),
                    Temperature = table.Column<double>(type: "float", nullable: false, defaultValue: 36.700000000000003),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    personnelId = table.Column<int>(type: "int", nullable: false),
                    CategorieDesSoinId = table.Column<int>(type: "int", nullable: false),
                    residantSuiviId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parametres_CategorieDesSoins_CategorieDesSoinId",
                        column: x => x.CategorieDesSoinId,
                        principalTable: "CategorieDesSoins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parametres_Personnels_personnelId",
                        column: x => x.personnelId,
                        principalTable: "Personnels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parametres_ResidantSuivis_residantSuiviId",
                        column: x => x.residantSuiviId,
                        principalTable: "ResidantSuivis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QteRepas = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Normal"),
                    DescRepas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    personnelId = table.Column<int>(type: "int", nullable: false),
                    CategorieDesSoinId = table.Column<int>(type: "int", nullable: false),
                    residantSuiviId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repas_CategorieDesSoins_CategorieDesSoinId",
                        column: x => x.CategorieDesSoinId,
                        principalTable: "CategorieDesSoins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repas_Personnels_personnelId",
                        column: x => x.personnelId,
                        principalTable: "Personnels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repas_ResidantSuivis_residantSuiviId",
                        column: x => x.residantSuiviId,
                        principalTable: "ResidantSuivis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Selles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NbreDeSelle = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    DescSelle = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Normal"),
                    DateTimeSelle = table.Column<DateTime>(type: "datetime2", nullable: false),
                    personnelId = table.Column<int>(type: "int", nullable: false),
                    CategorieDesSoinId = table.Column<int>(type: "int", nullable: false),
                    residantSuiviId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Selles_CategorieDesSoins_CategorieDesSoinId",
                        column: x => x.CategorieDesSoinId,
                        principalTable: "CategorieDesSoins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Selles_Personnels_personnelId",
                        column: x => x.personnelId,
                        principalTable: "Personnels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Selles_ResidantSuivis_residantSuiviId",
                        column: x => x.residantSuiviId,
                        principalTable: "ResidantSuivis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Therapies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Horaire = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 1, 7, 11, 19, 15, 335, DateTimeKind.Local).AddTicks(4874)),
                    DescTherapie = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Contactez medecin."),
                    personnelCreatedId = table.Column<int>(type: "int", nullable: false),
                    CategorieDesSoinId = table.Column<int>(type: "int", nullable: false),
                    residantSuiviId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Therapies_CategorieDesSoins_CategorieDesSoinId",
                        column: x => x.CategorieDesSoinId,
                        principalTable: "CategorieDesSoins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Therapies_Personnels_personnelCreatedId",
                        column: x => x.personnelCreatedId,
                        principalTable: "Personnels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Therapies_ResidantSuivis_residantSuiviId",
                        column: x => x.residantSuiviId,
                        principalTable: "ResidantSuivis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Toillettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDone = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DescToillete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeToillette = table.Column<DateTime>(type: "datetime2", nullable: false),
                    personnelId = table.Column<int>(type: "int", nullable: false),
                    CategorieDesSoinId = table.Column<int>(type: "int", nullable: false),
                    residantSuiviId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toillettes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Toillettes_CategorieDesSoins_CategorieDesSoinId",
                        column: x => x.CategorieDesSoinId,
                        principalTable: "CategorieDesSoins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Toillettes_Personnels_personnelId",
                        column: x => x.personnelId,
                        principalTable: "Personnels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Toillettes_ResidantSuivis_residantSuiviId",
                        column: x => x.residantSuiviId,
                        principalTable: "ResidantSuivis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoinsAjoutResidantSuivis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSoinsAjout = table.Column<int>(type: "int", nullable: false),
                    IdResidantSuivi = table.Column<int>(type: "int", nullable: false),
                    PersonnelId = table.Column<int>(type: "int", nullable: false),
                    ResidantSuiviId = table.Column<int>(type: "int", nullable: true),
                    SoinsAjoutId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoinsAjoutResidantSuivis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoinsAjoutResidantSuivis_Personnels_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "Personnels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SoinsAjoutResidantSuivis_ResidantSuivis_IdResidantSuivi",
                        column: x => x.IdResidantSuivi,
                        principalTable: "ResidantSuivis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SoinsAjoutResidantSuivis_ResidantSuivis_ResidantSuiviId",
                        column: x => x.ResidantSuiviId,
                        principalTable: "ResidantSuivis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SoinsAjoutResidantSuivis_SoinsAjouts_IdSoinsAjout",
                        column: x => x.IdSoinsAjout,
                        principalTable: "SoinsAjouts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SoinsAjoutResidantSuivis_SoinsAjouts_SoinsAjoutId",
                        column: x => x.SoinsAjoutId,
                        principalTable: "SoinsAjouts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResidantSuiviTherapies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdResidantSuivi = table.Column<int>(type: "int", nullable: false),
                    IdTherapie = table.Column<int>(type: "int", nullable: false),
                    PersonnelDoneId = table.Column<int>(type: "int", nullable: false),
                    residantId = table.Column<int>(type: "int", nullable: true),
                    therapieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidantSuiviTherapies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidantSuiviTherapies_Personnels_PersonnelDoneId",
                        column: x => x.PersonnelDoneId,
                        principalTable: "Personnels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResidantSuiviTherapies_ResidantSuivis_IdResidantSuivi",
                        column: x => x.IdResidantSuivi,
                        principalTable: "ResidantSuivis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResidantSuiviTherapies_ResidantSuivis_residantId",
                        column: x => x.residantId,
                        principalTable: "ResidantSuivis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResidantSuiviTherapies_Therapies_IdTherapie",
                        column: x => x.IdTherapie,
                        principalTable: "Therapies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResidantSuiviTherapies_Therapies_therapieId",
                        column: x => x.therapieId,
                        principalTable: "Therapies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TherapieTrancheHoraires",
                columns: table => new
                {
                    IdTherapie = table.Column<int>(type: "int", nullable: false),
                    IdTrancheHoraire = table.Column<int>(type: "int", nullable: false),
                    therapieId = table.Column<int>(type: "int", nullable: true),
                    trancheHoraireId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TherapieTrancheHoraires", x => new { x.IdTherapie, x.IdTrancheHoraire });
                    table.ForeignKey(
                        name: "FK_TherapieTrancheHoraires_Therapies_IdTherapie",
                        column: x => x.IdTherapie,
                        principalTable: "Therapies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TherapieTrancheHoraires_Therapies_therapieId",
                        column: x => x.therapieId,
                        principalTable: "Therapies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TherapieTrancheHoraires_TrancheHoraires_IdTrancheHoraire",
                        column: x => x.IdTrancheHoraire,
                        principalTable: "TrancheHoraires",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TherapieTrancheHoraires_TrancheHoraires_trancheHoraireId",
                        column: x => x.trancheHoraireId,
                        principalTable: "TrancheHoraires",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boissons_CategorieDesSoinId",
                table: "Boissons",
                column: "CategorieDesSoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Boissons_personnelId",
                table: "Boissons",
                column: "personnelId");

            migrationBuilder.CreateIndex(
                name: "IX_Boissons_residantSuiviId",
                table: "Boissons",
                column: "residantSuiviId");

            migrationBuilder.CreateIndex(
                name: "IX_Fonctions_fonction",
                table: "Fonctions",
                column: "fonction",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parametres_CategorieDesSoinId",
                table: "Parametres",
                column: "CategorieDesSoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Parametres_personnelId",
                table: "Parametres",
                column: "personnelId");

            migrationBuilder.CreateIndex(
                name: "IX_Parametres_residantSuiviId",
                table: "Parametres",
                column: "residantSuiviId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_FonctionId",
                table: "Personnels",
                column: "FonctionId");

            migrationBuilder.CreateIndex(
                name: "Key_unique_email",
                table: "Personnels",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Key_unique_matricule",
                table: "Personnels",
                column: "Matricule",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repas_CategorieDesSoinId",
                table: "Repas",
                column: "CategorieDesSoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Repas_personnelId",
                table: "Repas",
                column: "personnelId");

            migrationBuilder.CreateIndex(
                name: "IX_Repas_residantSuiviId",
                table: "Repas",
                column: "residantSuiviId");

            migrationBuilder.CreateIndex(
                name: "Key_unique_matricule1",
                table: "Residants",
                column: "Matricule",
                unique: true,
                filter: "[Matricule] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ResidantSuivis_Matricule",
                table: "ResidantSuivis",
                column: "Matricule",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResidantSuivis_residantId",
                table: "ResidantSuivis",
                column: "residantId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidantSuiviTherapies_IdResidantSuivi",
                table: "ResidantSuiviTherapies",
                column: "IdResidantSuivi");

            migrationBuilder.CreateIndex(
                name: "IX_ResidantSuiviTherapies_IdTherapie",
                table: "ResidantSuiviTherapies",
                column: "IdTherapie");

            migrationBuilder.CreateIndex(
                name: "IX_ResidantSuiviTherapies_PersonnelDoneId",
                table: "ResidantSuiviTherapies",
                column: "PersonnelDoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidantSuiviTherapies_residantId",
                table: "ResidantSuiviTherapies",
                column: "residantId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidantSuiviTherapies_therapieId",
                table: "ResidantSuiviTherapies",
                column: "therapieId");

            migrationBuilder.CreateIndex(
                name: "IX_Selles_CategorieDesSoinId",
                table: "Selles",
                column: "CategorieDesSoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Selles_personnelId",
                table: "Selles",
                column: "personnelId");

            migrationBuilder.CreateIndex(
                name: "IX_Selles_residantSuiviId",
                table: "Selles",
                column: "residantSuiviId");

            migrationBuilder.CreateIndex(
                name: "IX_SoinsAjoutResidantSuivis_IdResidantSuivi",
                table: "SoinsAjoutResidantSuivis",
                column: "IdResidantSuivi");

            migrationBuilder.CreateIndex(
                name: "IX_SoinsAjoutResidantSuivis_IdSoinsAjout",
                table: "SoinsAjoutResidantSuivis",
                column: "IdSoinsAjout");

            migrationBuilder.CreateIndex(
                name: "IX_SoinsAjoutResidantSuivis_PersonnelId",
                table: "SoinsAjoutResidantSuivis",
                column: "PersonnelId");

            migrationBuilder.CreateIndex(
                name: "IX_SoinsAjoutResidantSuivis_ResidantSuiviId",
                table: "SoinsAjoutResidantSuivis",
                column: "ResidantSuiviId");

            migrationBuilder.CreateIndex(
                name: "IX_SoinsAjoutResidantSuivis_SoinsAjoutId",
                table: "SoinsAjoutResidantSuivis",
                column: "SoinsAjoutId");

            migrationBuilder.CreateIndex(
                name: "IX_SoinsAjouts_CategorieDesSoinsId",
                table: "SoinsAjouts",
                column: "CategorieDesSoinsId");

            migrationBuilder.CreateIndex(
                name: "IX_SoinsAjouts_PersonnelCreatedId",
                table: "SoinsAjouts",
                column: "PersonnelCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapies_CategorieDesSoinId",
                table: "Therapies",
                column: "CategorieDesSoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapies_personnelCreatedId",
                table: "Therapies",
                column: "personnelCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapies_residantSuiviId",
                table: "Therapies",
                column: "residantSuiviId");

            migrationBuilder.CreateIndex(
                name: "IX_TherapieTrancheHoraires_IdTrancheHoraire",
                table: "TherapieTrancheHoraires",
                column: "IdTrancheHoraire");

            migrationBuilder.CreateIndex(
                name: "IX_TherapieTrancheHoraires_therapieId",
                table: "TherapieTrancheHoraires",
                column: "therapieId");

            migrationBuilder.CreateIndex(
                name: "IX_TherapieTrancheHoraires_trancheHoraireId",
                table: "TherapieTrancheHoraires",
                column: "trancheHoraireId");

            migrationBuilder.CreateIndex(
                name: "IX_Toillettes_CategorieDesSoinId",
                table: "Toillettes",
                column: "CategorieDesSoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Toillettes_personnelId",
                table: "Toillettes",
                column: "personnelId");

            migrationBuilder.CreateIndex(
                name: "IX_Toillettes_residantSuiviId",
                table: "Toillettes",
                column: "residantSuiviId");

            migrationBuilder.CreateIndex(
                name: "IX_TrancheHoraires_personnelId",
                table: "TrancheHoraires",
                column: "personnelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boissons");

            migrationBuilder.DropTable(
                name: "Parametres");

            migrationBuilder.DropTable(
                name: "Repas");

            migrationBuilder.DropTable(
                name: "ResidantSuiviTherapies");

            migrationBuilder.DropTable(
                name: "Selles");

            migrationBuilder.DropTable(
                name: "SoinsAjoutResidantSuivis");

            migrationBuilder.DropTable(
                name: "TherapieTrancheHoraires");

            migrationBuilder.DropTable(
                name: "Toillettes");

            migrationBuilder.DropTable(
                name: "SoinsAjouts");

            migrationBuilder.DropTable(
                name: "Therapies");

            migrationBuilder.DropTable(
                name: "TrancheHoraires");

            migrationBuilder.DropTable(
                name: "CategorieDesSoins");

            migrationBuilder.DropTable(
                name: "ResidantSuivis");

            migrationBuilder.DropTable(
                name: "Personnels");

            migrationBuilder.DropTable(
                name: "Residants");

            migrationBuilder.DropTable(
                name: "Fonctions");
        }
    }
}
