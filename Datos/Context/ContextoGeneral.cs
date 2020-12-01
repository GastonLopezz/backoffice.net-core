using Datos.Entity.EncuestaGeneralEntity;
using Datos.Entity.GlobalesEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Datos.Context {
    public class ContextoGeneral:DbContext {
        private readonly AppSettingsBD _settingsBD;

        public ContextoGeneral() : base() {

        }

        public ContextoGeneral(DbContextOptions<ContextoGeneral> options, IOptions<AppSettingsBD> appSettings) : base(options) {
            _settingsBD = appSettings.Value;
        }
        public DbSet<Facultad> Facultad { get; set; }
        public DbSet<Comunicado> Comunicado { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<AdministradorFacultad> AdministradorFacultad { get; set; }
        public DbSet<AdministradorUdelar> AdministradorUdelar { get; set; }
        public DbSet<ComunicadoFacultad> ComunicadoFacultad { get; set; }

        public DbSet<EncuestaGeneral> EncuestaGeneral { get; set; }
        public DbSet<OpcionesGeneral> OpcionesGeneral { get; set; }
        public DbSet<PreguntasGeneral> PreguntasGeneral { get; set; }
        public DbSet<RespuestasGeneral> RespuestasGeneral { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //Many to Many
            modelBuilder.Entity<ComunicadoFacultad>().HasKey(cf => new { cf.ComunicadoId, cf.FacultadId });
            modelBuilder.Entity<RespuestasGeneral>().HasKey(rg => new { rg.OpcionId, rg.CuentaId });
            //UNIQUE KEY
            //   modelBuilder.Entity<Facultad>().HasAlternateKey(f => new { f.Url, f.Abreviatura, f.Nombre });
            modelBuilder.Entity<Facultad>().HasIndex(f => new { f.Url, f.Abreviatura, f.Nombre }).IsUnique(true);
            modelBuilder.Entity<Administrador>().HasAlternateKey(a => new { a.Usuario });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
             //optionsBuilder.UseNpgsql(@"Host="+_settingsBD.Host+";Database="+_settingsBD.Bd+";Username=" + _settingsBD.Usuario + ";Password="+_settingsBD.Password+"");
            optionsBuilder.UseNpgsql(@"Host=127.0.0.1;Database=general;Username=postgres;Password=root");

            //UseNpgsql -> para postgress
        }



    }
}
