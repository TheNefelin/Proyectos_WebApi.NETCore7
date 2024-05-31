using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyectos_WebApi.NETCore7.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthPerfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthPerfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "F1Circuitos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    IdPais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F1Circuitos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "F1Escuderias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    UrlAuto = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    IdPais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F1Escuderias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "F1Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    UrlBandera = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F1Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GJJuegos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Descripcion = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Img = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GJJuegos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthUsuario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(450)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Usuario = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    AuthHash = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    AuthSalt = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    IdPerfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthUsuario_AuthPerfil_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "AuthPerfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "F1Carreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Clima = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    IdCircuito = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F1Carreras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_F1Carreras_F1Circuitos_IdCircuito",
                        column: x => x.IdCircuito,
                        principalTable: "F1Circuitos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "F1Pilotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    FechaNaci = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatura = table.Column<float>(type: "real", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Dorsal = table.Column<int>(type: "int", nullable: false),
                    UrlPerfil = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    EstaVivo = table.Column<bool>(type: "bit", nullable: false),
                    Puntos = table.Column<int>(type: "int", nullable: false),
                    IdPais = table.Column<int>(type: "int", nullable: false),
                    IdEscuderia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F1Pilotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_F1Pilotos_F1Escuderias_IdEscuderia",
                        column: x => x.IdEscuderia,
                        principalTable: "F1Escuderias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GJFondosImg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Id_Juego = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GJFondosImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GJFondosImg_GJJuegos_Id_Juego",
                        column: x => x.Id_Juego,
                        principalTable: "GJJuegos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GJFuentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Img = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Id_Juego = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GJFuentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GJFuentes_GJJuegos_Id_Juego",
                        column: x => x.Id_Juego,
                        principalTable: "GJJuegos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GJGuias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Id_Juego = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GJGuias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GJGuias_GJJuegos_Id_Juego",
                        column: x => x.Id_Juego,
                        principalTable: "GJJuegos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GJPersonajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Descripcion = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Img = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Id_Juego = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GJPersonajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GJPersonajes_GJJuegos_Id_Juego",
                        column: x => x.Id_Juego,
                        principalTable: "GJJuegos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GJAventuras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "VARCHAR(800)", nullable: false),
                    Importante = table.Column<bool>(type: "bit", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Id_Guia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GJAventuras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GJAventuras_GJGuias_Id_Guia",
                        column: x => x.Id_Guia,
                        principalTable: "GJGuias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GJGuiasUsuario",
                columns: table => new
                {
                    Id_Guia = table.Column<int>(type: "int", nullable: false),
                    Id_Usuario = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GJGuiasUsuario", x => new { x.Id_Guia, x.Id_Usuario });
                    table.ForeignKey(
                        name: "FK_GJGuiasUsuario_GJGuias_Id_Guia",
                        column: x => x.Id_Guia,
                        principalTable: "GJGuias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GJAventurasImg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Id_Aventura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GJAventurasImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GJAventurasImg_GJAventuras_Id_Aventura",
                        column: x => x.Id_Aventura,
                        principalTable: "GJAventuras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GJAventurasUsuario",
                columns: table => new
                {
                    Id_Aventura = table.Column<int>(type: "int", nullable: false),
                    Id_Usuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GJAventurasUsuario", x => new { x.Id_Aventura, x.Id_Usuario });
                    table.ForeignKey(
                        name: "FK_GJAventurasUsuario_GJAventuras_Id_Aventura",
                        column: x => x.Id_Aventura,
                        principalTable: "GJAventuras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthUsuario_IdPerfil",
                table: "AuthUsuario",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_F1Carreras_IdCircuito",
                table: "F1Carreras",
                column: "IdCircuito");

            migrationBuilder.CreateIndex(
                name: "IX_F1Pilotos_IdEscuderia",
                table: "F1Pilotos",
                column: "IdEscuderia");

            migrationBuilder.CreateIndex(
                name: "IX_GJAventuras_Id_Guia",
                table: "GJAventuras",
                column: "Id_Guia");

            migrationBuilder.CreateIndex(
                name: "IX_GJAventurasImg_Id_Aventura",
                table: "GJAventurasImg",
                column: "Id_Aventura");

            migrationBuilder.CreateIndex(
                name: "IX_GJFondosImg_Id_Juego",
                table: "GJFondosImg",
                column: "Id_Juego");

            migrationBuilder.CreateIndex(
                name: "IX_GJFuentes_Id_Juego",
                table: "GJFuentes",
                column: "Id_Juego");

            migrationBuilder.CreateIndex(
                name: "IX_GJGuias_Id_Juego",
                table: "GJGuias",
                column: "Id_Juego");

            migrationBuilder.CreateIndex(
                name: "IX_GJPersonajes_Id_Juego",
                table: "GJPersonajes",
                column: "Id_Juego");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthUsuario");

            migrationBuilder.DropTable(
                name: "F1Carreras");

            migrationBuilder.DropTable(
                name: "F1Paises");

            migrationBuilder.DropTable(
                name: "F1Pilotos");

            migrationBuilder.DropTable(
                name: "GJAventurasImg");

            migrationBuilder.DropTable(
                name: "GJAventurasUsuario");

            migrationBuilder.DropTable(
                name: "GJFondosImg");

            migrationBuilder.DropTable(
                name: "GJFuentes");

            migrationBuilder.DropTable(
                name: "GJGuiasUsuario");

            migrationBuilder.DropTable(
                name: "GJPersonajes");

            migrationBuilder.DropTable(
                name: "AuthPerfil");

            migrationBuilder.DropTable(
                name: "F1Circuitos");

            migrationBuilder.DropTable(
                name: "F1Escuderias");

            migrationBuilder.DropTable(
                name: "GJAventuras");

            migrationBuilder.DropTable(
                name: "GJGuias");

            migrationBuilder.DropTable(
                name: "GJJuegos");
        }
    }
}
