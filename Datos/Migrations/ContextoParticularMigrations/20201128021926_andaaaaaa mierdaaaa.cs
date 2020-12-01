using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Datos.Migrations.ContextoParticularMigrations
{
    public partial class andaaaaaamierdaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "fing");

            migrationBuilder.CreateTable(
                name: "Administrador",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Usuario = table.Column<string>(nullable: true),
                    Passwd = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Creditos = table.Column<int>(nullable: false),
                    ClaveMatriculacion = table.Column<string>(nullable: true),
                    YearDiactado = table.Column<int>(nullable: false),
                    TipoCurso = table.Column<string>(nullable: true),
                    DictaCurso = table.Column<string>(nullable: true),
                    Informacion = table.Column<string>(nullable: true),
                    FechaLimiteInscripcion = table.Column<DateTime>(nullable: false),
                    NotaMinimaAprobacion = table.Column<int>(nullable: false),
                    NotaMaximaAprobacion = table.Column<int>(nullable: false),
                    NotaMinimaExamen = table.Column<int>(nullable: true),
                    NotaMaximaExamen = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Encuesta",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TipoEncuesta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuesta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facultad",
                schema: "fing",
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
                name: "GeneralTemplate",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: true),
                    TipoTemplate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                schema: "fing",
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
                    table.UniqueConstraint("AK_Persona_Ci", x => x.Ci);
                });

            migrationBuilder.CreateTable(
                name: "AdministradorUdelar",
                schema: "fing",
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
                        principalSchema: "fing",
                        principalTable: "Administrador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comunicado",
                schema: "fing",
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
                        principalSchema: "fing",
                        principalTable: "Administrador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calendario",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CursoId = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendario_Curso_CursoId",
                        column: x => x.CursoId,
                        principalSchema: "fing",
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clases",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CursoId = table.Column<int>(nullable: false),
                    FechaClase = table.Column<DateTime>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clases_Curso_CursoId",
                        column: x => x.CursoId,
                        principalSchema: "fing",
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComunicadoCurso",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Texto = table.Column<string>(nullable: true),
                    FechaPublicacion = table.Column<DateTime>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComunicadoCurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComunicadoCurso_Curso_CursoId",
                        column: x => x.CursoId,
                        principalSchema: "fing",
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeccionTemplate",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Visible = table.Column<bool>(nullable: false),
                    Prioridad = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeccionTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeccionTemplate_Curso_CursoId",
                        column: x => x.CursoId,
                        principalSchema: "fing",
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Preguntas",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Frase = table.Column<string>(nullable: true),
                    TipoCheck = table.Column<string>(nullable: true),
                    EncuestaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preguntas_Encuesta_EncuestaId",
                        column: x => x.EncuestaId,
                        principalSchema: "fing",
                        principalTable: "Encuesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdministradorFacultad",
                schema: "fing",
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
                        principalSchema: "fing",
                        principalTable: "Administrador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdministradorFacultad_Facultad_FacultadId",
                        column: x => x.FacultadId,
                        principalSchema: "fing",
                        principalTable: "Facultad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuloDefault",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Prioridad = table.Column<int>(nullable: false),
                    TemplateId = table.Column<int>(nullable: false),
                    TamplateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuloDefault", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuloDefault_GeneralTemplate_TamplateId",
                        column: x => x.TamplateId,
                        principalSchema: "fing",
                        principalTable: "GeneralTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Usuario = table.Column<string>(nullable: false),
                    Passwd = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    NumeroTelefono = table.Column<string>(nullable: true),
                    TipoCuenta = table.Column<string>(nullable: true),
                    PersonaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.Id);
                    table.UniqueConstraint("AK_Cuenta_Usuario_Email", x => new { x.Usuario, x.Email });
                    table.ForeignKey(
                        name: "FK_Cuenta_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalSchema: "fing",
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaCreada = table.Column<DateTime>(nullable: false),
                    Titulo = table.Column<string>(nullable: false),
                    Mensaje = table.Column<string>(nullable: false),
                    PersonaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificaciones_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalSchema: "fing",
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComunicadoFacultad",
                schema: "fing",
                columns: table => new
                {
                    ComunicadoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComunicadoId1 = table.Column<int>(nullable: true),
                    FacultadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComunicadoFacultad", x => x.ComunicadoId);
                    table.ForeignKey(
                        name: "FK_ComunicadoFacultad_Comunicado_ComunicadoId1",
                        column: x => x.ComunicadoId1,
                        principalSchema: "fing",
                        principalTable: "Comunicado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComunicadoFacultad_Facultad_FacultadId",
                        column: x => x.FacultadId,
                        principalSchema: "fing",
                        principalTable: "Facultad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaCurso",
                schema: "fing",
                columns: table => new
                {
                    EncuestaId = table.Column<int>(nullable: false),
                    SeccionTemplateId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaCurso", x => new { x.SeccionTemplateId, x.EncuestaId });
                    table.ForeignKey(
                        name: "FK_EncuestaCurso_Curso_CursoId",
                        column: x => x.CursoId,
                        principalSchema: "fing",
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncuestaCurso_Encuesta_EncuestaId",
                        column: x => x.EncuestaId,
                        principalSchema: "fing",
                        principalTable: "Encuesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncuestaCurso_SeccionTemplate_SeccionTemplateId",
                        column: x => x.SeccionTemplateId,
                        principalSchema: "fing",
                        principalTable: "SeccionTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaFacultades",
                schema: "fing",
                columns: table => new
                {
                    EncuestaId = table.Column<int>(nullable: false),
                    SeccionTemplateId = table.Column<int>(nullable: false),
                    FacultadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaFacultades", x => new { x.SeccionTemplateId, x.EncuestaId });
                    table.ForeignKey(
                        name: "FK_EncuestaFacultades_Encuesta_EncuestaId",
                        column: x => x.EncuestaId,
                        principalSchema: "fing",
                        principalTable: "Encuesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncuestaFacultades_Facultad_FacultadId",
                        column: x => x.FacultadId,
                        principalSchema: "fing",
                        principalTable: "Facultad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncuestaFacultades_SeccionTemplate_SeccionTemplateId",
                        column: x => x.SeccionTemplateId,
                        principalSchema: "fing",
                        principalTable: "SeccionTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluaciones",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ValidacionBedelia = table.Column<bool>(nullable: false),
                    TipoEvaluacion = table.Column<string>(nullable: true),
                    EsArchivo = table.Column<bool>(nullable: false),
                    CalificacionAprobacion = table.Column<int>(nullable: false),
                    SeccionTemplateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluaciones_SeccionTemplate_SeccionTemplateId",
                        column: x => x.SeccionTemplateId,
                        principalSchema: "fing",
                        principalTable: "SeccionTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foros",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: false),
                    SeccionTemplateId = table.Column<int>(nullable: false),
                    Suscripcion = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foros_SeccionTemplate_SeccionTemplateId",
                        column: x => x.SeccionTemplateId,
                        principalSchema: "fing",
                        principalTable: "SeccionTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Informacion",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    SeccionTemplateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Informacion_SeccionTemplate_SeccionTemplateId",
                        column: x => x.SeccionTemplateId,
                        principalSchema: "fing",
                        principalTable: "SeccionTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    SeccionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_SeccionTemplate_SeccionId",
                        column: x => x.SeccionId,
                        principalSchema: "fing",
                        principalTable: "SeccionTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opciones",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Respuesta = table.Column<string>(nullable: true),
                    PreguntaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opciones_Preguntas_PreguntaId",
                        column: x => x.PreguntaId,
                        principalSchema: "fing",
                        principalTable: "Preguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asistencias",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClaseId = table.Column<int>(nullable: false),
                    CuentaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asistencias_Clases_ClaseId",
                        column: x => x.ClaseId,
                        principalSchema: "fing",
                        principalTable: "Clases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencias_Cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalSchema: "fing",
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuentaGoogle",
                schema: "fing",
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
                        principalSchema: "fing",
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocentesCurso",
                schema: "fing",
                columns: table => new
                {
                    DocenteId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    Escargado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocentesCurso", x => new { x.CursoId, x.DocenteId });
                    table.ForeignKey(
                        name: "FK_DocentesCurso_Curso_CursoId",
                        column: x => x.CursoId,
                        principalSchema: "fing",
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocentesCurso_Cuenta_DocenteId",
                        column: x => x.DocenteId,
                        principalSchema: "fing",
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripcion",
                schema: "fing",
                columns: table => new
                {
                    CursoId = table.Column<int>(nullable: false),
                    EsudianteInscripcionId = table.Column<int>(nullable: false),
                    FechaInscripcion = table.Column<DateTime>(nullable: false),
                    HabilitadoBedelia = table.Column<bool>(nullable: true),
                    Metriculado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripcion", x => new { x.CursoId, x.EsudianteInscripcionId });
                    table.ForeignKey(
                        name: "FK_Inscripcion_Curso_CursoId",
                        column: x => x.CursoId,
                        principalSchema: "fing",
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Cuenta_EsudianteInscripcionId",
                        column: x => x.EsudianteInscripcionId,
                        principalSchema: "fing",
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArchivoEvaluaciones",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EvaluacionId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    CuentaId = table.Column<int>(nullable: false),
                    Archivo = table.Column<byte[]>(nullable: true),
                    Creado = table.Column<DateTime>(nullable: false),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivoEvaluaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchivoEvaluaciones_Cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalSchema: "fing",
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchivoEvaluaciones_Evaluaciones_EvaluacionId",
                        column: x => x.EvaluacionId,
                        principalSchema: "fing",
                        principalTable: "Evaluaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calificaciones",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nota = table.Column<int>(nullable: false),
                    FechaPublicada = table.Column<DateTime>(nullable: false),
                    FechaCorregida = table.Column<DateTime>(nullable: false),
                    EstadoCalificacion = table.Column<string>(nullable: true),
                    EstudianteId = table.Column<int>(nullable: false),
                    EvaluacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calificaciones_Cuenta_EstudianteId",
                        column: x => x.EstudianteId,
                        principalSchema: "fing",
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calificaciones_Evaluaciones_EvaluacionId",
                        column: x => x.EvaluacionId,
                        principalSchema: "fing",
                        principalTable: "Evaluaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Desarrollo",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pregunta = table.Column<string>(nullable: true),
                    PuntajeAprobacion = table.Column<int>(nullable: false),
                    EvaluacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desarrollo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desarrollo_Evaluaciones_EvaluacionId",
                        column: x => x.EvaluacionId,
                        principalSchema: "fing",
                        principalTable: "Evaluaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerdaderoFalso",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Frase = table.Column<string>(nullable: true),
                    MultipleOpcion = table.Column<bool>(nullable: false),
                    EvaluacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerdaderoFalso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerdaderoFalso_Evaluaciones_EvaluacionId",
                        column: x => x.EvaluacionId,
                        principalSchema: "fing",
                        principalTable: "Evaluaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discusiones",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(nullable: false),
                    FechaCreado = table.Column<DateTime>(nullable: false),
                    CuentaId = table.Column<int>(nullable: false),
                    ForoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discusiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discusiones_Cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalSchema: "fing",
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discusiones_Foros_ForoId",
                        column: x => x.ForoId,
                        principalSchema: "fing",
                        principalTable: "Foros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suscripciones",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ForoId = table.Column<int>(nullable: false),
                    CuentaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suscripciones_Cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalSchema: "fing",
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suscripciones_Foros_ForoId",
                        column: x => x.ForoId,
                        principalSchema: "fing",
                        principalTable: "Foros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                schema: "fing",
                columns: table => new
                {
                    OpcionId = table.Column<int>(nullable: false),
                    CuentaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => new { x.CuentaId, x.OpcionId });
                    table.ForeignKey(
                        name: "FK_Respuestas_Cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalSchema: "fing",
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Respuestas_Opciones_OpcionId",
                        column: x => x.OpcionId,
                        principalSchema: "fing",
                        principalTable: "Opciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RespuestaDesarrollo",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Respuesta = table.Column<string>(nullable: true),
                    Puntaje = table.Column<int>(nullable: false),
                    EstudianteId = table.Column<int>(nullable: false),
                    DesarrolloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestaDesarrollo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespuestaDesarrollo_Desarrollo_DesarrolloId",
                        column: x => x.DesarrolloId,
                        principalSchema: "fing",
                        principalTable: "Desarrollo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespuestaDesarrollo_Cuenta_EstudianteId",
                        column: x => x.EstudianteId,
                        principalSchema: "fing",
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpcionesVoF",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Frase = table.Column<string>(nullable: true),
                    Correcta = table.Column<bool>(nullable: false),
                    VerdaderoFalsoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcionesVoF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpcionesVoF_VerdaderoFalso_VerdaderoFalsoId",
                        column: x => x.VerdaderoFalsoId,
                        principalSchema: "fing",
                        principalTable: "VerdaderoFalso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaCreado = table.Column<DateTime>(nullable: false),
                    Texto = table.Column<string>(nullable: false),
                    CuentaId = table.Column<int>(nullable: false),
                    DiscusionId = table.Column<int>(nullable: false),
                    ForoId = table.Column<int>(nullable: false),
                    ComentarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Comentarios_ComentarioId",
                        column: x => x.ComentarioId,
                        principalSchema: "fing",
                        principalTable: "Comentarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentarios_Cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalSchema: "fing",
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Discusiones_DiscusionId",
                        column: x => x.DiscusionId,
                        principalSchema: "fing",
                        principalTable: "Discusiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Foros_ForoId",
                        column: x => x.ForoId,
                        principalSchema: "fing",
                        principalTable: "Foros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RespuestaVoF",
                schema: "fing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Eleccion = table.Column<bool>(nullable: false),
                    EstudianteId = table.Column<int>(nullable: false),
                    OpcionId = table.Column<int>(nullable: false),
                    VerdaderoFalsoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestaVoF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespuestaVoF_Cuenta_EstudianteId",
                        column: x => x.EstudianteId,
                        principalSchema: "fing",
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespuestaVoF_OpcionesVoF_OpcionId",
                        column: x => x.OpcionId,
                        principalSchema: "fing",
                        principalTable: "OpcionesVoF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespuestaVoF_VerdaderoFalso_VerdaderoFalsoId",
                        column: x => x.VerdaderoFalsoId,
                        principalSchema: "fing",
                        principalTable: "VerdaderoFalso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministradorFacultad_FacultadId",
                schema: "fing",
                table: "AdministradorFacultad",
                column: "FacultadId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoEvaluaciones_CuentaId",
                schema: "fing",
                table: "ArchivoEvaluaciones",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoEvaluaciones_EvaluacionId",
                schema: "fing",
                table: "ArchivoEvaluaciones",
                column: "EvaluacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_ClaseId",
                schema: "fing",
                table: "Asistencias",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_CuentaId",
                schema: "fing",
                table: "Asistencias",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_CursoId",
                schema: "fing",
                table: "Calendario",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_EstudianteId",
                schema: "fing",
                table: "Calificaciones",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_EvaluacionId",
                schema: "fing",
                table: "Calificaciones",
                column: "EvaluacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_CursoId",
                schema: "fing",
                table: "Clases",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_ComentarioId",
                schema: "fing",
                table: "Comentarios",
                column: "ComentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_CuentaId",
                schema: "fing",
                table: "Comentarios",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_DiscusionId",
                schema: "fing",
                table: "Comentarios",
                column: "DiscusionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_ForoId",
                schema: "fing",
                table: "Comentarios",
                column: "ForoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comunicado_AdministradorId",
                schema: "fing",
                table: "Comunicado",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComunicadoCurso_CursoId",
                schema: "fing",
                table: "ComunicadoCurso",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComunicadoFacultad_ComunicadoId1",
                schema: "fing",
                table: "ComunicadoFacultad",
                column: "ComunicadoId1");

            migrationBuilder.CreateIndex(
                name: "IX_ComunicadoFacultad_FacultadId",
                schema: "fing",
                table: "ComunicadoFacultad",
                column: "FacultadId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_PersonaId",
                schema: "fing",
                table: "Cuenta",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaGoogle_CuentaId",
                schema: "fing",
                table: "CuentaGoogle",
                column: "CuentaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Desarrollo_EvaluacionId",
                schema: "fing",
                table: "Desarrollo",
                column: "EvaluacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Discusiones_CuentaId",
                schema: "fing",
                table: "Discusiones",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Discusiones_ForoId",
                schema: "fing",
                table: "Discusiones",
                column: "ForoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocentesCurso_DocenteId",
                schema: "fing",
                table: "DocentesCurso",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaCurso_CursoId",
                schema: "fing",
                table: "EncuestaCurso",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaCurso_EncuestaId",
                schema: "fing",
                table: "EncuestaCurso",
                column: "EncuestaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaFacultades_EncuestaId",
                schema: "fing",
                table: "EncuestaFacultades",
                column: "EncuestaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaFacultades_FacultadId",
                schema: "fing",
                table: "EncuestaFacultades",
                column: "FacultadId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_SeccionTemplateId",
                schema: "fing",
                table: "Evaluaciones",
                column: "SeccionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Foros_SeccionTemplateId",
                schema: "fing",
                table: "Foros",
                column: "SeccionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Informacion_SeccionTemplateId",
                schema: "fing",
                table: "Informacion",
                column: "SeccionTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_EsudianteInscripcionId",
                schema: "fing",
                table: "Inscripcion",
                column: "EsudianteInscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_SeccionId",
                schema: "fing",
                table: "Material",
                column: "SeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloDefault_TamplateId",
                schema: "fing",
                table: "ModuloDefault",
                column: "TamplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_PersonaId",
                schema: "fing",
                table: "Notificaciones",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Opciones_PreguntaId",
                schema: "fing",
                table: "Opciones",
                column: "PreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_OpcionesVoF_VerdaderoFalsoId",
                schema: "fing",
                table: "OpcionesVoF",
                column: "VerdaderoFalsoId");

            migrationBuilder.CreateIndex(
                name: "IX_Preguntas_EncuestaId",
                schema: "fing",
                table: "Preguntas",
                column: "EncuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaDesarrollo_DesarrolloId",
                schema: "fing",
                table: "RespuestaDesarrollo",
                column: "DesarrolloId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaDesarrollo_EstudianteId",
                schema: "fing",
                table: "RespuestaDesarrollo",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_OpcionId",
                schema: "fing",
                table: "Respuestas",
                column: "OpcionId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaVoF_EstudianteId",
                schema: "fing",
                table: "RespuestaVoF",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaVoF_OpcionId",
                schema: "fing",
                table: "RespuestaVoF",
                column: "OpcionId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaVoF_VerdaderoFalsoId",
                schema: "fing",
                table: "RespuestaVoF",
                column: "VerdaderoFalsoId");

            migrationBuilder.CreateIndex(
                name: "IX_SeccionTemplate_CursoId",
                schema: "fing",
                table: "SeccionTemplate",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Suscripciones_CuentaId",
                schema: "fing",
                table: "Suscripciones",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Suscripciones_ForoId",
                schema: "fing",
                table: "Suscripciones",
                column: "ForoId");

            migrationBuilder.CreateIndex(
                name: "IX_VerdaderoFalso_EvaluacionId",
                schema: "fing",
                table: "VerdaderoFalso",
                column: "EvaluacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministradorFacultad",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "AdministradorUdelar",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "ArchivoEvaluaciones",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Asistencias",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Calendario",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Calificaciones",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Comentarios",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "ComunicadoCurso",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "ComunicadoFacultad",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "CuentaGoogle",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "DocentesCurso",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "EncuestaCurso",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "EncuestaFacultades",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Informacion",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Inscripcion",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Material",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "ModuloDefault",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Notificaciones",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "RespuestaDesarrollo",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Respuestas",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "RespuestaVoF",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Suscripciones",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Clases",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Discusiones",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Comunicado",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Facultad",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "GeneralTemplate",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Desarrollo",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Opciones",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "OpcionesVoF",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Cuenta",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Foros",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Administrador",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Preguntas",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "VerdaderoFalso",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Persona",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Encuesta",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Evaluaciones",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "SeccionTemplate",
                schema: "fing");

            migrationBuilder.DropTable(
                name: "Curso",
                schema: "fing");
        }
    }
}
