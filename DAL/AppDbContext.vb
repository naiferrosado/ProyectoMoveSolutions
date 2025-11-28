Imports Entidades
Imports Microsoft.EntityFrameworkCore



Public Class AppDbContext
    Inherits DbContext

    ' Constructor sin parámetros (necesario para migraciones)
    Public Sub New()
    End Sub

    ' Constructor con opciones
    Public Sub New(options As DbContextOptions(Of AppDbContext))
        MyBase.New(options)
    End Sub

    ' DbSets para cada entidad
    Public Property Clientes As DbSet(Of ClienteEntidad)
    Public Property Empleados As DbSet(Of EmpleadoEntidad)
    Public Property Vehiculos As DbSet(Of VehiculoEntidad)
    Public Property Mudanzas As DbSet(Of MudanzaEntidad)
    Public Property Inventarios As DbSet(Of InventarioEntidad)
    Public Property Checkpoints As DbSet(Of CheckpointEntidad)
    Public Property Facturas As DbSet(Of FacturaEntidad)
    Public Property Pagos As DbSet(Of PagoEntidad)
    Public Property Incidencias As DbSet(Of IncidenciaEntidad)
    Public Property Usuarios As DbSet(Of UsuarioEntidad)
    Public Property Roles As DbSet(Of RolEntidad)

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        ' Solo se usa si el DbContext se crea sin opciones (ej: en migraciones)
        If Not optionsBuilder.IsConfigured Then
            optionsBuilder.UseSqlServer(
                "Server=NAIFER\MSSQLSERVER01;Database=SistemaMudanzasDB;Trusted_Connection=True;TrustServerCertificate=True;",
                Function(b) b.MigrationsAssembly("DAL.Migrations"))
        End If
    End Sub

    Protected Overrides Sub OnModelCreating(builder As ModelBuilder)
        MyBase.OnModelCreating(builder)


        ' CONFIGURACIÓN DE CLIENTE

        builder.Entity(Of ClienteEntidad)(Sub(entity)
                                              entity.ToTable("tbl_cliente")
                                              entity.HasKey(Function(e) e.ClienteId)
                                              entity.Property(Function(e) e.ClienteId).UseIdentityColumn()

                                              entity.Property(Function(e) e.Correo).IsRequired().HasMaxLength(100)
                                              entity.HasIndex(Function(e) e.Correo).IsUnique()

                                              entity.Property(Function(e) e.Nombre).IsRequired().HasMaxLength(100)
                                              entity.Property(Function(e) e.Telefono).HasMaxLength(20)
                                              entity.Property(Function(e) e.Direccion).HasMaxLength(150)

                                              ' Relación 1:N con Mudanza
                                              entity.HasMany(Function(e) e.Mudanzas) _
                  .WithOne(Function(m) m.Cliente) _
                  .HasForeignKey(Function(m) m.ClienteId) _
                  .OnDelete(DeleteBehavior.Restrict)
                                          End Sub)


        ' CONFIGURACIÓN DE EMPLEADO

        builder.Entity(Of EmpleadoEntidad)(Sub(entity)
                                               entity.ToTable("tbl_empleado")
                                               entity.HasKey(Function(e) e.EmpleadoId)
                                               entity.Property(Function(e) e.EmpleadoId).UseIdentityColumn()

                                               entity.Property(Function(e) e.Nombre).IsRequired().HasMaxLength(100)
                                               entity.Property(Function(e) e.Telefono).HasMaxLength(20)
                                               entity.Property(Function(e) e.Rol).IsRequired().HasMaxLength(50)
                                               entity.Property(Function(e) e.Disponibilidad).IsRequired().HasMaxLength(10).HasDefaultValue("Disponible")

                                               ' Relación con Usuario (opcional)
                                               entity.HasOne(Function(e) e.Usuario) _
                  .WithMany(Function(u) u.Empleados) _
                  .HasForeignKey(Function(e) e.UsuarioId) _
                  .OnDelete(DeleteBehavior.SetNull)

                                               ' Relación 1:N con Mudanza
                                               entity.HasMany(Function(e) e.Mudanzas) _
                  .WithOne(Function(m) m.Empleado) _
                  .HasForeignKey(Function(m) m.EmpleadoId) _
                  .OnDelete(DeleteBehavior.SetNull)
                                           End Sub)


        ' CONFIGURACIÓN DE VEHICULO

        builder.Entity(Of VehiculoEntidad)(Sub(entity)
                                               entity.ToTable("tbl_vehiculo")
                                               entity.HasKey(Function(e) e.VehiculoId)
                                               entity.Property(Function(e) e.VehiculoId).UseIdentityColumn()

                                               entity.Property(Function(e) e.Placa).IsRequired().HasMaxLength(20)
                                               entity.HasIndex(Function(e) e.Placa).IsUnique()

                                               entity.Property(Function(e) e.Modelo).HasMaxLength(50)
                                               entity.Property(Function(e) e.Capacidad).IsRequired(False)
                                               entity.Property(Function(e) e.Estado).IsRequired().HasMaxLength(20).HasDefaultValue("Activo")

                                               ' Relación 1:N con Mudanza
                                               entity.HasMany(Function(e) e.Mudanzas) _
                  .WithOne(Function(m) m.Vehiculo) _
                  .HasForeignKey(Function(m) m.VehiculoId) _
                  .OnDelete(DeleteBehavior.SetNull)
                                           End Sub)


        ' CONFIGURACIÓN DE MUDANZA

        builder.Entity(Of MudanzaEntidad)(Sub(entity)
                                              entity.ToTable("tbl_mudanza")
                                              entity.HasKey(Function(e) e.MudanzaId)
                                              entity.Property(Function(e) e.MudanzaId).UseIdentityColumn()

                                              entity.Property(Function(e) e.Origen).IsRequired().HasMaxLength(150)
                                              entity.Property(Function(e) e.Destino).IsRequired().HasMaxLength(150)
                                              entity.Property(Function(e) e.FechaProgramada).IsRequired()
                                              entity.Property(Function(e) e.Estado).IsRequired().HasMaxLength(20).HasDefaultValue("Pendiente")
                                              entity.Property(Function(e) e.CostoEstimado).HasColumnType("decimal(10,2)")

                                              ' Relación con Usuario (opcional)
                                              entity.HasOne(Function(e) e.Usuario) _
                  .WithMany(Function(u) u.Mudanzas) _
                  .HasForeignKey(Function(e) e.UsuarioId) _
                  .OnDelete(DeleteBehavior.SetNull)

                                              ' Relación 1:N con Inventario
                                              entity.HasMany(Function(e) e.Inventario) _
                  .WithOne(Function(i) i.Mudanza) _
                  .HasForeignKey(Function(i) i.MudanzaId) _
                  .OnDelete(DeleteBehavior.Cascade)

                                              ' Relación 1:N con Checkpoint
                                              entity.HasMany(Function(e) e.Checkpoints) _
                  .WithOne(Function(c) c.Mudanza) _
                  .HasForeignKey(Function(c) c.MudanzaId) _
                  .OnDelete(DeleteBehavior.Cascade)

                                              ' Relación 1:N con Incidencia
                                              entity.HasMany(Function(e) e.Incidencias) _
                  .WithOne(Function(i) i.Mudanza) _
                  .HasForeignKey(Function(i) i.MudanzaId) _
                  .OnDelete(DeleteBehavior.Cascade)

                                              ' Relación 1:1 con Factura
                                              entity.HasOne(Function(e) e.Factura) _
                  .WithOne(Function(f) f.Mudanza) _
                  .HasForeignKey(Of FacturaEntidad)(Function(f) f.MudanzaId) _
                  .OnDelete(DeleteBehavior.Cascade)
                                          End Sub)


        ' CONFIGURACIÓN DE INVENTARIO

        builder.Entity(Of InventarioEntidad)(Sub(entity)
                                                 entity.ToTable("tbl_inventario")
                                                 entity.HasKey(Function(e) e.ItemId)
                                                 entity.Property(Function(e) e.ItemId).UseIdentityColumn()

                                                 entity.Property(Function(e) e.Descripcion).IsRequired().HasMaxLength(100)
                                                 entity.Property(Function(e) e.Cantidad).IsRequired()
                                                 entity.Property(Function(e) e.ValorEstimado).HasColumnType("decimal(10,2)")
                                             End Sub)


        ' CONFIGURACIÓN DE CHECKPOINT

        builder.Entity(Of CheckpointEntidad)(Sub(entity)
                                                 entity.ToTable("tbl_checkpoint")
                                                 entity.HasKey(Function(e) e.CheckpointId)
                                                 entity.Property(Function(e) e.CheckpointId).UseIdentityColumn()

                                                 entity.Property(Function(e) e.Secuencia).IsRequired()
                                                 entity.Property(Function(e) e.HoraPrevista).IsRequired(False)
                                                 entity.Property(Function(e) e.HoraReal).IsRequired(False)
                                                 entity.Property(Function(e) e.Latitud).HasColumnType("decimal(9,6)")
                                                 entity.Property(Function(e) e.Longitud).HasColumnType("decimal(9,6)")
                                                 entity.Property(Function(e) e.Estado).IsRequired().HasMaxLength(20).HasDefaultValue("Pendiente")
                                             End Sub)


        ' CONFIGURACIÓN DE FACTURA

        builder.Entity(Of FacturaEntidad)(Sub(entity)
                                              entity.ToTable("tbl_factura")
                                              entity.HasKey(Function(e) e.FacturaId)
                                              entity.Property(Function(e) e.FacturaId).UseIdentityColumn()

                                              entity.Property(Function(e) e.MontoTotal).IsRequired().HasColumnType("decimal(10,2)")
                                              entity.Property(Function(e) e.Impuesto).IsRequired().HasColumnType("decimal(5,2)").HasDefaultValue(18D)
                                              entity.Property(Function(e) e.FechaEmision).IsRequired().HasDefaultValueSql("GETDATE()")
                                              entity.Property(Function(e) e.Estado).IsRequired().HasMaxLength(20).HasDefaultValue("Pendiente")

                                              ' Relación 1:N con Pago
                                              entity.HasMany(Function(e) e.Pagos) _
                  .WithOne(Function(p) p.Factura) _
                  .HasForeignKey(Function(p) p.FacturaId) _
                  .OnDelete(DeleteBehavior.Cascade)
                                          End Sub)


        ' CONFIGURACIÓN DE PAGO

        builder.Entity(Of PagoEntidad)(Sub(entity)
                                           entity.ToTable("tbl_pago")
                                           entity.HasKey(Function(e) e.PagoId)
                                           entity.Property(Function(e) e.PagoId).UseIdentityColumn()

                                           entity.Property(Function(e) e.MetodoPago).IsRequired().HasMaxLength(50)
                                           entity.Property(Function(e) e.Monto).IsRequired().HasColumnType("decimal(10,2)")
                                           entity.Property(Function(e) e.FechaPago).IsRequired().HasDefaultValueSql("GETDATE()")
                                       End Sub)


        ' CONFIGURACIÓN DE INCIDENCIA

        builder.Entity(Of IncidenciaEntidad)(Sub(entity)
                                                 entity.ToTable("tbl_incidencia")
                                                 entity.HasKey(Function(e) e.IncidenciaId)
                                                 entity.Property(Function(e) e.IncidenciaId).UseIdentityColumn()

                                                 entity.Property(Function(e) e.Descripcion).IsRequired().HasMaxLength(200)
                                                 entity.Property(Function(e) e.Severidad).IsRequired().HasMaxLength(20)
                                                 entity.Property(Function(e) e.FechaReporte).IsRequired().HasDefaultValueSql("GETDATE()")
                                                 entity.Property(Function(e) e.FechaResolucion).IsRequired(False)
                                             End Sub)


        ' CONFIGURACIÓN DE USUARIO

        builder.Entity(Of UsuarioEntidad)(Sub(entity)
                                              entity.ToTable("tbl_usuario")
                                              entity.HasKey(Function(e) e.UsuarioId)
                                              entity.Property(Function(e) e.UsuarioId).UseIdentityColumn()

                                              entity.Property(Function(e) e.NombreUsuario).IsRequired().HasMaxLength(50)
                                              entity.HasIndex(Function(e) e.NombreUsuario).IsUnique()

                                              entity.Property(Function(e) e.Contrasena).IsRequired().HasMaxLength(255)
                                              entity.Property(Function(e) e.Correo).HasMaxLength(100)
                                              entity.Property(Function(e) e.Estado).IsRequired().HasMaxLength(20).HasDefaultValue("Activo")

                                              ' Relación con Rol
                                              entity.HasOne(Function(e) e.Rol) _
                  .WithMany(Function(r) r.Usuarios) _
                  .HasForeignKey(Function(e) e.RolId) _
                  .OnDelete(DeleteBehavior.Restrict)
                                          End Sub)


        ' CONFIGURACIÓN DE ROL

        builder.Entity(Of RolEntidad)(Sub(entity)
                                          entity.ToTable("tbl_rol")
                                          entity.HasKey(Function(e) e.RolId)
                                          entity.Property(Function(e) e.RolId).UseIdentityColumn()

                                          entity.Property(Function(e) e.Nombre).IsRequired().HasMaxLength(50)
                                          entity.HasIndex(Function(e) e.Nombre).IsUnique()

                                          entity.Property(Function(e) e.Descripcion).HasMaxLength(150)
                                      End Sub)


        ' DATOS INICIALES (SEED DATA)


        ' Datos iniciales de roles
        builder.Entity(Of RolEntidad)().HasData(
            New RolEntidad With {
                .RolId = 1,
                .Nombre = "Administrador",
                .Descripcion = "Acceso completo al sistema"
            },
            New RolEntidad With {
                .RolId = 2,
                .Nombre = "Supervisor",
                .Descripcion = "Supervisión de operaciones y empleados"
            },
            New RolEntidad With {
                .RolId = 3,
                .Nombre = "Empleado",
                .Descripcion = "Operaciones básicas de mudanza"
            }
        )

        ' Usuario administrador inicial
        builder.Entity(Of UsuarioEntidad)().HasData(
            New UsuarioEntidad With {
                .UsuarioId = 1,
                .NombreUsuario = "admin",
                .Contrasena = "admin123",
                .Correo = "admin@movesolutions.com",
                .Estado = "Activo",
                .RolId = 1
            }
        )

    End Sub
End Class