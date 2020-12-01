using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Datos.Migrations
{
    public partial class papaya : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Usuario = table.Column<string>(nullable: false),
                    Passwd = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Id);
                    table.UniqueConstraint("AK_Administrador_Usuario", x => x.Usuario);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaGeneral",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaGeneral", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facultad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Abreviatura = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    TipoNav = table.Column<string>(nullable: true),
                    ColorNav = table.Column<string>(nullable: true),
                    TipoAutenticacion = table.Column<string>(nullable: true),
                    NombreBD = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ci = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdministradorUdelar",
                columns: table => new
                {
                    AdministradorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministradorUdelar", x => x.AdministradorId);
                    table.ForeignKey(
                        name: "FK_AdministradorUdelar_Administrador_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administrador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comunicado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Texto = table.Column<string>(nullable: true),
                    FechaPublicacion = table.Column<DateTime>(nullable: false),
                    AdministradorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunicado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comunicado_Administrador_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administrador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreguntasGeneral",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Frase = table.Column<string>(nullable: true),
                    TipoCheck = table.Column<string>(nullable: true),
                    EncuestaGeneralId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntasGeneral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreguntasGeneral_EncuestaGeneral_EncuestaGeneralId",
                        column: x => x.EncuestaGeneralId,
                        principalTable: "EncuestaGeneral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdministradorFacultad",
                columns: table => new
                {
                    AdministradorId = table.Column<int>(nullable: false),
                    FacultadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministradorFacultad", x => x.AdministradorId);
                    table.ForeignKey(
                        name: "FK_AdministradorFacultad_Administrador_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administrador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdministradorFacultad_Facultad_FacultadId",
                        column: x => x.FacultadId,
                        principalTable: "Facultad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Usuario = table.Column<string>(nullable: true),
                    Passwd = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NumeroTelefono = table.Column<string>(nullable: true),
                    TipoCuenta = table.Column<string>(nullable: true),
                    PersonaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuenta_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComunicadoFacultad",
                columns: table => new
                {
                    ComunicadoId = table.Column<int>(nullable: false),
                    FacultadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComunicadoFacultad", x => new { x.ComunicadoId, x.FacultadId });
                    table.ForeignKey(
                        name: "FK_ComunicadoFacultad_Comunicado_ComunicadoId",
                        column: x => x.ComunicadoId,
                        principalTable: "Comunicado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComunicadoFacultad_Facultad_FacultadId",
                        column: x => x.FacultadId,
                        principalTable: "Facultad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpcionesGeneral",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Respuesta = table.Column<string>(nullable: true),
                    PreguntaGeneralId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcionesGeneral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpcionesGeneral_PreguntasGeneral_PreguntaGeneralId",
                        column: x => x.PreguntaGeneralId,
                        principalTable: "PreguntasGeneral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuentaGoogle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GoogleId = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    CuentaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaGoogle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuentaGoogle_Cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RespuestasGeneral",
                columns: table => new
                {
                    OpcionId = table.Column<int>(nullable: false),
                    CuentaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestasGeneral", x => new { x.OpcionId, x.CuentaId });
                    table.ForeignKey(
                        name: "FK_RespuestasGeneral_Cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespuestasGeneral_OpcionesGeneral_OpcionId",
                        column: x => x.OpcionId,
                        principalTable: "OpcionesGeneral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministradorFacultad_FacultadId",
                table: "AdministradorFacultad",
                column: "FacultadId");

            migrationBuilder.CreateIndex(
                name: "IX_Comunicado_AdministradorId",
                table: "Comunicado",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComunicadoFacultad_FacultadId",
                table: "ComunicadoFacultad",
                column: "FacultadId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_PersonaId",
                table: "Cuenta",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaGoogle_CuentaId",
                table: "CuentaGoogle",
                column: "CuentaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facultad_Url_Abreviatura_Nombre",
                table: "Facultad",
                columns: new[] { "Url", "Abreviatura", "Nombre" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpcionesGeneral_PreguntaGeneralId",
                table: "OpcionesGeneral",
                column: "PreguntaGeneralId");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntasGeneral_EncuestaGeneralId",
                table: "PreguntasGeneral",
                column: "EncuestaGeneralId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestasGeneral_CuentaId",
                table: "RespuestasGeneral",
                column: "CuentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministradorFacultad");

            migrationBuilder.DropTable(
                name: "AdministradorUdelar");

            migrationBuilder.DropTable(
                name: "ComunicadoFacultad");

            migrationBuilder.DropTable(
                name: "CuentaGoogle");

            migrationBuilder.DropTable(
                name: "RespuestasGeneral");

            migrationBuilder.DropTable(
                name: "Comunicado");

            migrationBuilder.DropTable(
                name: "Facultad");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "OpcionesGeneral");

            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "PreguntasGeneral");

            migrationBuilder.DropTable(
                name: "EncuestaGeneral");
        }
    }
}
