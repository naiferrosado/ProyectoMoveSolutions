using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.Migrations
{
    /// <summary>
    /// Factory para crear instancias del DbContext en tiempo de diseño.
    /// Necesario para que las migraciones de Entity Framework Core funcionen correctamente.
    /// Este proyecto en C# es solo para las migraciones, el resto puede seguir en VB.NET
    /// </summary>
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // CADENA DE CONEXIÓN PARA DESARROLLO

            // IMPORTANTE: Cambia estos valores según tu configuración de SQL Server

            // Opción 1: Autenticación de Windows (Trusted Connection)
            string connectionString = "Server=NAIFER\\MSSQLSERVER01;Database=SistemaMudanzasDB;Trusted_Connection=True;TrustServerCertificate=True;";

            // Opción 2: Autenticación SQL Server (descomenta si usas esta opción)
            // string connectionString = "Server=localhost;Database=SistemaMudanzasDB;User Id=sa;Password=TuContraseña123;TrustServerCertificate=True;MultipleActiveResultSets=true";

            // Opción 3: Si tu SQL Server tiene una instancia nombrada (ej: SQLEXPRESS)
            // string connectionString = "Server=localhost\\SQLEXPRESS;Database=SistemaMudanzasDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";

            // Especificar que las migraciones estarán en este proyecto (DAL.Migrations)
            optionsBuilder.UseSqlServer(connectionString,
                b => b.MigrationsAssembly("DAL.Migrations"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}