using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackendCatalogoAXA.Data.Context;

public partial class CatalogoServiciosAxaContext : DbContext
{
    public CatalogoServiciosAxaContext()
    {
    }

    public CatalogoServiciosAxaContext(DbContextOptions<CatalogoServiciosAxaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activo> Activos { get; set; }

    public virtual DbSet<Ambiente> Ambientes { get; set; }

    public virtual DbSet<Apimanager> Apimanagers { get; set; }

    public virtual DbSet<Aplicacion> Aplicacions { get; set; }

    public virtual DbSet<Balanceo> Balanceos { get; set; }

    public virtual DbSet<BalanceoServicio> BalanceoServicios { get; set; }

    public virtual DbSet<CategoriaServidor> CategoriaServidors { get; set; }

    public virtual DbSet<Entorno> Entornos { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Framework> Frameworks { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<MetodoHttp> MetodoHttps { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<MotorBd> MotorBds { get; set; }

    public virtual DbSet<Protocolo> Protocolos { get; set; }

    public virtual DbSet<Repositorio> Repositorios { get; set; }

    public virtual DbSet<RepositorioColeccion> RepositorioColeccions { get; set; }

    public virtual DbSet<RepositorioServicio> RepositorioServicios { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<ServicioLog> ServicioLogs { get; set; }

    public virtual DbSet<ServicioModulo> ServicioModulos { get; set; }

    public virtual DbSet<ServicioServidor> ServicioServidors { get; set; }

    public virtual DbSet<Servidor> Servidors { get; set; }

    public virtual DbSet<SistemaOperativo> SistemaOperativos { get; set; }

    public virtual DbSet<TipoServicio> TipoServicios { get; set; }

    public virtual DbSet<UnidadNegocio> UnidadNegocios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CatalogoServiciosAXA;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Activo>(entity =>
        {
            entity.ToTable("Activo");

            entity.HasIndex(e => e.Codigo, "UQ_Activo_Codigo").IsUnique();

            entity.Property(e => e.ActivoId).HasColumnName("ActivoID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TieneMfa).HasColumnName("TieneMFA");
        });

        modelBuilder.Entity<Ambiente>(entity =>
        {
            entity.ToTable("Ambiente");

            entity.HasIndex(e => e.Codigo, "UQ_Ambiente_Codigo").IsUnique();

            entity.Property(e => e.AmbienteId).HasColumnName("AmbienteID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Apimanager>(entity =>
        {
            entity.ToTable("APIManager");

            entity.HasIndex(e => e.ServicioId, "IX_APIManager_ServicioID");

            entity.HasIndex(e => e.Codigo, "UQ_APIManager_Codigo").IsUnique();

            entity.Property(e => e.ApimanagerId).HasColumnName("APIManagerID");
            entity.Property(e => e.AmbienteId).HasColumnName("AmbienteID");
            entity.Property(e => e.Catalogo)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MetodoHttpid).HasColumnName("MetodoHTTPID");
            entity.Property(e => e.NombreApi)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NombreAPI");
            entity.Property(e => e.Recurso)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ServicioId).HasColumnName("ServicioID");
            entity.Property(e => e.Url)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("URL");
            entity.Property(e => e.Version)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Ambiente).WithMany(p => p.Apimanagers)
                .HasForeignKey(d => d.AmbienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_APIManager_Ambiente");

            entity.HasOne(d => d.MetodoHttp).WithMany(p => p.Apimanagers)
                .HasForeignKey(d => d.MetodoHttpid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_APIManager_Metodo");

            entity.HasOne(d => d.Servicio).WithMany(p => p.Apimanagers)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_APIManager_Servicio");
        });

        modelBuilder.Entity<Aplicacion>(entity =>
        {
            entity.ToTable("Aplicacion");

            entity.HasIndex(e => e.Codigo, "UQ_Aplicacion_Codigo").IsUnique();

            entity.Property(e => e.AplicacionId).HasColumnName("AplicacionID");
            entity.Property(e => e.ActivoId).HasColumnName("ActivoID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DescripcionFuncional).IsUnicode(false);
            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.FrameworkId).HasColumnName("FrameworkID");
            entity.Property(e => e.NombreApp)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UnidadNegocioId).HasColumnName("UnidadNegocioID");
            entity.Property(e => e.Urlprod)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("URLProd");
            entity.Property(e => e.Urltst)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("URLTST");
            entity.Property(e => e.Urluat)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("URLUAT");

            entity.HasOne(d => d.Activo).WithMany(p => p.Aplicacions)
                .HasForeignKey(d => d.ActivoId)
                .HasConstraintName("FK_Aplicacion_Activo");

            entity.HasOne(d => d.Estado).WithMany(p => p.Aplicacions)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Aplicacion_Estado");

            entity.HasOne(d => d.Framework).WithMany(p => p.Aplicacions)
                .HasForeignKey(d => d.FrameworkId)
                .HasConstraintName("FK_Aplicacion_Framework");

            entity.HasOne(d => d.UnidadNegocio).WithMany(p => p.Aplicacions)
                .HasForeignKey(d => d.UnidadNegocioId)
                .HasConstraintName("FK_Aplicacion_Unidad");
        });

        modelBuilder.Entity<Balanceo>(entity =>
        {
            entity.ToTable("Balanceo");

            entity.HasIndex(e => e.AmbienteId, "IX_Balanceo_AmbienteID");

            entity.HasIndex(e => e.Codigo, "UQ_Balanceo_Codigo").IsUnique();

            entity.Property(e => e.BalanceoId).HasColumnName("BalanceoID");
            entity.Property(e => e.AmbienteId).HasColumnName("AmbienteID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("URL");

            entity.HasOne(d => d.Ambiente).WithMany(p => p.Balanceos)
                .HasForeignKey(d => d.AmbienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Balanceo_Ambiente");
        });

        modelBuilder.Entity<BalanceoServicio>(entity =>
        {
            entity.ToTable("BalanceoServicio");

            entity.HasIndex(e => new { e.BalanceoId, e.ServicioId }, "UQ_BalanceoServicio").IsUnique();

            entity.Property(e => e.BalanceoServicioId).HasColumnName("BalanceoServicioID");
            entity.Property(e => e.BalanceoId).HasColumnName("BalanceoID");
            entity.Property(e => e.ServicioId).HasColumnName("ServicioID");
            entity.Property(e => e.Urlcompleta)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("URLCompleta");

            entity.HasOne(d => d.Balanceo).WithMany(p => p.BalanceoServicios)
                .HasForeignKey(d => d.BalanceoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BaSvc_Balanceo");

            entity.HasOne(d => d.Servicio).WithMany(p => p.BalanceoServicios)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BaSvc_Servicio");
        });

        modelBuilder.Entity<CategoriaServidor>(entity =>
        {
            entity.ToTable("CategoriaServidor");

            entity.HasIndex(e => e.Nombre, "UQ_CategoriaServidor_Nombre").IsUnique();

            entity.Property(e => e.CategoriaServidorId).HasColumnName("CategoriaServidorID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Entorno>(entity =>
        {
            entity.ToTable("Entorno");

            entity.HasIndex(e => e.Nombre, "UQ_Entorno_Nombre").IsUnique();

            entity.Property(e => e.EntornoId).HasColumnName("EntornoID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.ToTable("Estado");

            entity.HasIndex(e => e.Nombre, "UQ_Estado_Nombre").IsUnique();

            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Framework>(entity =>
        {
            entity.ToTable("Framework");

            entity.HasIndex(e => e.Nombre, "UQ_Framework_Nombre").IsUnique();

            entity.Property(e => e.FrameworkId).HasColumnName("FrameworkID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.ToTable("Log");

            entity.HasIndex(e => e.Codigo, "UQ_Log_Codigo").IsUnique();

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RutaLog)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MetodoHttp>(entity =>
        {
            entity.ToTable("MetodoHTTP");

            entity.HasIndex(e => e.Nombre, "UQ_MetodoHTTP_Nombre").IsUnique();

            entity.Property(e => e.MetodoHttpid).HasColumnName("MetodoHTTPID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.ToTable("Modulo");

            entity.HasIndex(e => e.Codigo, "UQ_Modulo_Codigo").IsUnique();

            entity.Property(e => e.ModuloId).HasColumnName("ModuloID");
            entity.Property(e => e.AplicacionId).HasColumnName("AplicacionID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Aplicacion).WithMany(p => p.Modulos)
                .HasForeignKey(d => d.AplicacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Modulo_Aplicacion");
        });

        modelBuilder.Entity<MotorBd>(entity =>
        {
            entity.ToTable("MotorBD");

            entity.HasIndex(e => e.Nombre, "UQ_MotorBD_Nombre").IsUnique();

            entity.Property(e => e.MotorBdid).HasColumnName("MotorBDID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Protocolo>(entity =>
        {
            entity.ToTable("Protocolo");

            entity.HasIndex(e => e.Nombre, "UQ_Protocolo_Nombre").IsUnique();

            entity.Property(e => e.ProtocoloId).HasColumnName("ProtocoloID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Repositorio>(entity =>
        {
            entity.ToTable("Repositorio");

            entity.HasIndex(e => e.Codigo, "UQ_Repositorio_Codigo").IsUnique();

            entity.Property(e => e.RepositorioId).HasColumnName("RepositorioID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Urllibrerias)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("URLLibrerias");
            entity.Property(e => e.Urlrepositorio)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("URLRepositorio");
        });

        modelBuilder.Entity<RepositorioColeccion>(entity =>
        {
            entity.ToTable("RepositorioColeccion");

            entity.HasIndex(e => e.Codigo, "UQ_RepositorioColeccion_Codigo").IsUnique();

            entity.Property(e => e.RepositorioColeccionId).HasColumnName("RepositorioColeccionID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ServicioId).HasColumnName("ServicioID");
            entity.Property(e => e.Urlcoleccion)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("URLColeccion");
            entity.Property(e => e.UrlcoleccionAzure)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("URLColeccionAzure");

            entity.HasOne(d => d.Servicio).WithMany(p => p.RepositorioColeccions)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RepColeccion_Servicio");
        });

        modelBuilder.Entity<RepositorioServicio>(entity =>
        {
            entity.ToTable("RepositorioServicio");

            entity.HasIndex(e => new { e.RepositorioId, e.ServicioId }, "UQ_RepositorioServicio").IsUnique();

            entity.Property(e => e.RepositorioServicioId).HasColumnName("RepositorioServicioID");
            entity.Property(e => e.RepositorioId).HasColumnName("RepositorioID");
            entity.Property(e => e.ServicioId).HasColumnName("ServicioID");

            entity.HasOne(d => d.Repositorio).WithMany(p => p.RepositorioServicios)
                .HasForeignKey(d => d.RepositorioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RepSvc_Repositorio");

            entity.HasOne(d => d.Servicio).WithMany(p => p.RepositorioServicios)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RepSvc_Servicio");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.ToTable("Servicio");

            entity.HasIndex(e => e.EstadoId, "IX_Servicio_EstadoID");

            entity.HasIndex(e => e.Nombre, "IX_Servicio_Nombre");

            entity.HasIndex(e => e.Codigo, "UQ_Servicio_Codigo").IsUnique();

            entity.Property(e => e.ServicioId).HasColumnName("ServicioID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.FrameworkId).HasColumnName("FrameworkID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Propietario)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ProtocoloId).HasColumnName("ProtocoloID");
            entity.Property(e => e.TipoServicioId).HasColumnName("TipoServicioID");
            entity.Property(e => e.UnidadNegocioId).HasColumnName("UnidadNegocioID");

            entity.HasOne(d => d.Estado).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Servicio_Estado");

            entity.HasOne(d => d.Framework).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.FrameworkId)
                .HasConstraintName("FK_Servicio_Framework");

            entity.HasOne(d => d.Protocolo).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.ProtocoloId)
                .HasConstraintName("FK_Servicio_Protocolo");

            entity.HasOne(d => d.TipoServicio).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.TipoServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Servicio_TipoServicio");

            entity.HasOne(d => d.UnidadNegocio).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.UnidadNegocioId)
                .HasConstraintName("FK_Servicio_Unidad");
        });

        modelBuilder.Entity<ServicioLog>(entity =>
        {
            entity.ToTable("ServicioLog");

            entity.HasIndex(e => new { e.ServicioId, e.LogId }, "UQ_ServicioLog").IsUnique();

            entity.Property(e => e.ServicioLogId).HasColumnName("ServicioLogID");
            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.ServicioId).HasColumnName("ServicioID");

            entity.HasOne(d => d.Log).WithMany(p => p.ServicioLogs)
                .HasForeignKey(d => d.LogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SvcLog_Log");

            entity.HasOne(d => d.Servicio).WithMany(p => p.ServicioLogs)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SvcLog_Servicio");
        });

        modelBuilder.Entity<ServicioModulo>(entity =>
        {
            entity.ToTable("ServicioModulo");

            entity.HasIndex(e => new { e.ServicioId, e.ModuloId }, "UQ_ServicioModulo").IsUnique();

            entity.Property(e => e.ServicioModuloId).HasColumnName("ServicioModuloID");
            entity.Property(e => e.ModuloId).HasColumnName("ModuloID");
            entity.Property(e => e.ServicioId).HasColumnName("ServicioID");

            entity.HasOne(d => d.Modulo).WithMany(p => p.ServicioModulos)
                .HasForeignKey(d => d.ModuloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SvcMod_Modulo");

            entity.HasOne(d => d.Servicio).WithMany(p => p.ServicioModulos)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SvcMod_Servicio");
        });

        modelBuilder.Entity<ServicioServidor>(entity =>
        {
            entity.ToTable("ServicioServidor");

            entity.HasIndex(e => new { e.ServidorId, e.ServicioId, e.Puerto, e.AmbienteId }, "UQ_ServicioServidor").IsUnique();

            entity.Property(e => e.ServicioServidorId).HasColumnName("ServicioServidorID");
            entity.Property(e => e.AmbienteId).HasColumnName("AmbienteID");
            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.ServicioId).HasColumnName("ServicioID");
            entity.Property(e => e.ServidorId).HasColumnName("ServidorID");

            entity.HasOne(d => d.Ambiente).WithMany(p => p.ServicioServidors)
                .HasForeignKey(d => d.AmbienteId)
                .HasConstraintName("FK_SvcSvr_Ambiente");

            entity.HasOne(d => d.Estado).WithMany(p => p.ServicioServidors)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK_SvcSvr_Estado");

            entity.HasOne(d => d.Servicio).WithMany(p => p.ServicioServidors)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SvcSvr_Servicio");

            entity.HasOne(d => d.Servidor).WithMany(p => p.ServicioServidors)
                .HasForeignKey(d => d.ServidorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SvcSvr_Servidor");
        });

        modelBuilder.Entity<Servidor>(entity =>
        {
            entity.ToTable("Servidor");

            entity.HasIndex(e => e.AmbienteId, "IX_Servidor_AmbienteID");

            entity.HasIndex(e => e.Ip, "IX_Servidor_IP");

            entity.HasIndex(e => e.Codigo, "UQ_Servidor_Codigo").IsUnique();

            entity.Property(e => e.ServidorId).HasColumnName("ServidorID");
            entity.Property(e => e.Adapter)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Agrupacion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.AmbienteId).HasColumnName("AmbienteID");
            entity.Property(e => e.AmbientesQa)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("AmbientesQA");
            entity.Property(e => e.AplicacionNombre)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CategoriaServidorId).HasColumnName("CategoriaServidorID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.DiscoHddGb)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("DiscoHDD_GB");
            entity.Property(e => e.Dominio)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EntornoId).HasColumnName("EntornoID");
            entity.Property(e => e.EspacioActualDiscoGb)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("EspacioActualDisco_GB");
            entity.Property(e => e.EspacioDiscoGb)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("EspacioDisco_GB");
            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.GruposRed)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Ip)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("IP");
            entity.Property(e => e.MemoriaActualGb)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MemoriaActual_GB");
            entity.Property(e => e.MemoriaGb)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Memoria_GB");
            entity.Property(e => e.MotorBdid).HasColumnName("MotorBDID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Observacion).IsUnicode(false);
            entity.Property(e => e.SistemaOperativoId).HasColumnName("SistemaOperativoID");
            entity.Property(e => e.TieneDrp).HasColumnName("TieneDRP");
            entity.Property(e => e.UnidadNegocioId).HasColumnName("UnidadNegocioID");
            entity.Property(e => e.UsuarioResponsable)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Ambiente).WithMany(p => p.Servidors)
                .HasForeignKey(d => d.AmbienteId)
                .HasConstraintName("FK_Servidor_Ambiente");

            entity.HasOne(d => d.CategoriaServidor).WithMany(p => p.Servidors)
                .HasForeignKey(d => d.CategoriaServidorId)
                .HasConstraintName("FK_Servidor_Categoria");

            entity.HasOne(d => d.Entorno).WithMany(p => p.Servidors)
                .HasForeignKey(d => d.EntornoId)
                .HasConstraintName("FK_Servidor_Entorno");

            entity.HasOne(d => d.Estado).WithMany(p => p.Servidors)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK_Servidor_Estado");

            entity.HasOne(d => d.MotorBd).WithMany(p => p.Servidors)
                .HasForeignKey(d => d.MotorBdid)
                .HasConstraintName("FK_Servidor_MotorBD");

            entity.HasOne(d => d.SistemaOperativo).WithMany(p => p.Servidors)
                .HasForeignKey(d => d.SistemaOperativoId)
                .HasConstraintName("FK_Servidor_SO");

            entity.HasOne(d => d.UnidadNegocio).WithMany(p => p.Servidors)
                .HasForeignKey(d => d.UnidadNegocioId)
                .HasConstraintName("FK_Servidor_Unidad");
        });

        modelBuilder.Entity<SistemaOperativo>(entity =>
        {
            entity.ToTable("SistemaOperativo");

            entity.HasIndex(e => e.Nombre, "UQ_SistemaOperativo_Nombre").IsUnique();

            entity.Property(e => e.SistemaOperativoId).HasColumnName("SistemaOperativoID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.ToTable("TipoServicio");

            entity.HasIndex(e => e.Nombre, "UQ_TipoServicio_Nombre").IsUnique();

            entity.Property(e => e.TipoServicioId).HasColumnName("TipoServicioID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UnidadNegocio>(entity =>
        {
            entity.ToTable("UnidadNegocio");

            entity.HasIndex(e => e.Nombre, "UQ_UnidadNegocio_Nombre").IsUnique();

            entity.Property(e => e.UnidadNegocioId).HasColumnName("UnidadNegocioID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
