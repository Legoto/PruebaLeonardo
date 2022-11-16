using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EntitiesNeoris;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using EntitiesNeoris.Response;

namespace DataNeoris
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //PERSONAS
        public DbSet<EntityClienteResponse> EntityClienteResponse { get; set; }
        public DbSet<RespuestaGenerica> EntityClienteResponseCrear { get; set; }

        //CUENTAS
        public DbSet<EntityCuentaResponse> EntityCuentaResponse { get; set; }
        public DbSet<RespuestaGenerica> EntityCuentaCrear { get; set; }

        //MOVIMIENTOS
        public DbSet<EntityMovimientoResponse> EntityMovimientoResponse { get; set; }
        public DbSet<RespuestaGenerica> EntityMovimientoCrear { get; set; }

        //REPORTE
        public DbSet<EntityReporteResponse> EntityReportes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityClienteDB>().ToTable("tblCuenta", "dbo");
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}
