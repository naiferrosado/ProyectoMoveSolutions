using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rol",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_rol", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_vehiculo",
                columns: table => new
                {
                    VehiculoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Capacidad = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Activo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_vehiculo", x => x.VehiculoId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Activo"),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_tbl_usuario_tbl_rol_RolId",
                        column: x => x.RolId,
                        principalTable: "tbl_rol",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_empleado",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Disponibilidad = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: "Disponible"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_empleado", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_tbl_empleado_tbl_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tbl_usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mudanza",
                columns: table => new
                {
                    MudanzaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: true),
                    VehiculoId = table.Column<int>(type: "int", nullable: true),
                    Origen = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FechaProgramada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Pendiente"),
                    CostoEstimado = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_mudanza", x => x.MudanzaId);
                    table.ForeignKey(
                        name: "FK_tbl_mudanza_tbl_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "tbl_cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_mudanza_tbl_empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "tbl_empleado",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_tbl_mudanza_tbl_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tbl_usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_tbl_mudanza_tbl_vehiculo_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "tbl_vehiculo",
                        principalColumn: "VehiculoId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "tbl_checkpoint",
                columns: table => new
                {
                    CheckpointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MudanzaId = table.Column<int>(type: "int", nullable: false),
                    Secuencia = table.Column<int>(type: "int", nullable: false),
                    HoraPrevista = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraReal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Latitud = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Longitud = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Pendiente")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_checkpoint", x => x.CheckpointId);
                    table.ForeignKey(
                        name: "FK_tbl_checkpoint_tbl_mudanza_MudanzaId",
                        column: x => x.MudanzaId,
                        principalTable: "tbl_mudanza",
                        principalColumn: "MudanzaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_factura",
                columns: table => new
                {
                    FacturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MudanzaId = table.Column<int>(type: "int", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Impuesto = table.Column<decimal>(type: "decimal(5,2)", nullable: false, defaultValue: 18m),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Pendiente")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_factura", x => x.FacturaId);
                    table.ForeignKey(
                        name: "FK_tbl_factura_tbl_mudanza_MudanzaId",
                        column: x => x.MudanzaId,
                        principalTable: "tbl_mudanza",
                        principalColumn: "MudanzaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_incidencia",
                columns: table => new
                {
                    IncidenciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MudanzaId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Severidad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaReporte = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    FechaResolucion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_incidencia", x => x.IncidenciaId);
                    table.ForeignKey(
                        name: "FK_tbl_incidencia_tbl_mudanza_MudanzaId",
                        column: x => x.MudanzaId,
                        principalTable: "tbl_mudanza",
                        principalColumn: "MudanzaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_inventario",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MudanzaId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ValorEstimado = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_inventario", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_tbl_inventario_tbl_mudanza_MudanzaId",
                        column: x => x.MudanzaId,
                        principalTable: "tbl_mudanza",
                        principalColumn: "MudanzaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_pago",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_pago", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_tbl_pago_tbl_factura_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "tbl_factura",
                        principalColumn: "FacturaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tbl_rol",
                columns: new[] { "RolId", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Acceso completo al sistema", "Administrador" },
                    { 2, "Supervisión de operaciones y empleados", "Supervisor" },
                    { 3, "Operaciones básicas de mudanza", "Empleado" }
                });

            migrationBuilder.InsertData(
                table: "tbl_usuario",
                columns: new[] { "UsuarioId", "Contrasena", "Correo", "Estado", "NombreUsuario", "RolId" },
                values: new object[] { 1, "admin123", "admin@movesolutions.com", "Activo", "admin", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_checkpoint_MudanzaId",
                table: "tbl_checkpoint",
                column: "MudanzaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cliente_Correo",
                table: "tbl_cliente",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_empleado_UsuarioId",
                table: "tbl_empleado",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_factura_MudanzaId",
                table: "tbl_factura",
                column: "MudanzaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_incidencia_MudanzaId",
                table: "tbl_incidencia",
                column: "MudanzaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_inventario_MudanzaId",
                table: "tbl_inventario",
                column: "MudanzaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mudanza_ClienteId",
                table: "tbl_mudanza",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mudanza_EmpleadoId",
                table: "tbl_mudanza",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mudanza_UsuarioId",
                table: "tbl_mudanza",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mudanza_VehiculoId",
                table: "tbl_mudanza",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_pago_FacturaId",
                table: "tbl_pago",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_rol_Nombre",
                table: "tbl_rol",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_usuario_NombreUsuario",
                table: "tbl_usuario",
                column: "NombreUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_usuario_RolId",
                table: "tbl_usuario",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_vehiculo_Placa",
                table: "tbl_vehiculo",
                column: "Placa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_checkpoint");

            migrationBuilder.DropTable(
                name: "tbl_incidencia");

            migrationBuilder.DropTable(
                name: "tbl_inventario");

            migrationBuilder.DropTable(
                name: "tbl_pago");

            migrationBuilder.DropTable(
                name: "tbl_factura");

            migrationBuilder.DropTable(
                name: "tbl_mudanza");

            migrationBuilder.DropTable(
                name: "tbl_cliente");

            migrationBuilder.DropTable(
                name: "tbl_empleado");

            migrationBuilder.DropTable(
                name: "tbl_vehiculo");

            migrationBuilder.DropTable(
                name: "tbl_usuario");

            migrationBuilder.DropTable(
                name: "tbl_rol");
        }
    }
}
