using Datos.Entity;
using Datos.Entity.EncuestaEntity;
using Datos.Entity.EvaluacionEntity;
using Datos.Entity.GlobalesEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Context {
    public class ContextoParticular: DbContext {
        private readonly AppSettingsBD _settingsBD;
      //  public string BdNodoFacultadTenancy { get; set; }
        public string SchemaName { get; set; }
        public string DbName { get; set; }

        public ContextoParticular() : base() {
         }
        public ContextoParticular(DbContextOptions<ContextoParticular> options, IOptions<AppSettingsBD> appSettings) : base(options) {
            _settingsBD = appSettings.Value;
            /*var ser = new ServiceCollection();
            ser.AddEntityFrameworkNpgsql();*/
        }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<DocentesCurso> DocentesCurso { get; set; }
        public DbSet<ComunicadoCurso> ComunicadoCurso { get; set; }
        public DbSet<Inscripcion> Inscripcion { get; set; }
        public DbSet<CuentaGoogle> CuentaGoogle { get; set; }
        public DbSet<SeccionTemplate> SeccionTemplate { get; set; }
        public DbSet<Informacion> Informacion { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<GeneralTemplate> GeneralTemplate { get; set; }
        public DbSet<ModuloDefault> ModuloDefault { get; set; }

        //Chat
        public DbSet<Notificacion> Notificaciones { get; set; }
        //Foro
        public DbSet<Foro> Foros { get; set; }
        public DbSet<Discusion> Discusiones { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        //Evaluaciones
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Desarrollo> Desarrollo { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }
        public DbSet<RespuestaVoF> RespuestaVoF { get; set; }
        public DbSet<RespuestaDesarrollo> RespuestaDesarrollo { get; set; }
        public DbSet<VerdaderoFalso> VerdaderoFalso { get; set; }
        public DbSet<Opcion> OpcionesVoF { get; set; }
        public DbSet<ArchivoEvaluacion> ArchivoEvaluaciones { get; set; }
     
        //Encuestas
        public DbSet<Encuesta> Encuesta { get; set; }
        public DbSet<Preguntas> Preguntas { get; set; }
        public DbSet<Opciones> Opciones { get; set; }
        public DbSet<EncuestaCurso> EncuestaCurso { get; set; }
        public DbSet<Respuestas> Respuestas { get; set; }
        public DbSet<Calendario> Calendario { get; set; }
        public DbSet<EncuestaFacultad> EncuestaFacultades { get; set; }


        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Suscripcion> Suscripciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //Select Schema Name
           modelBuilder.HasDefaultSchema("fing");
           //modelBuilder.HasDefaultSchema(SchemaName);

            //Many to Many
            modelBuilder.Entity<DocentesCurso>().HasKey(dc => new { dc.CursoId, dc.DocenteId });
            modelBuilder.Entity<Inscripcion>().HasKey(i => new { i.CursoId, i.EsudianteInscripcionId });
            modelBuilder.Entity<Respuestas>().HasKey(i => new { i.CuentaId, i.OpcionId });
            modelBuilder.Entity<EncuestaCurso>().HasKey(i => new { i.SeccionTemplateId, i.EncuestaId });
            modelBuilder.Entity<EncuestaFacultad>().HasKey(ef => new { ef.SeccionTemplateId, ef.EncuestaId });

            //Clave unica
            modelBuilder.Entity<Cuenta>().HasAlternateKey(c => new { c.Usuario, c.Email });
            modelBuilder.Entity<Persona>().HasAlternateKey(p => new { p.Ci });

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //optionsBuilder.UseNpgsql(@"Host=" + _settingsBD.Host + ";Database=facultades;Username=" + _settingsBD.Usuario + ";Password=" + _settingsBD.Password + "");
            optionsBuilder.UseNpgsql(@"Host=127.0.0.1;Database=facultades;Username=postgres;Password=root");
            

        }

    }
}
