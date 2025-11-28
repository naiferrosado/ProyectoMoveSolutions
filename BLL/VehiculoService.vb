Imports System
Imports System.Linq
Imports DAL
Imports Entidades
Imports Microsoft.EntityFrameworkCore

Namespace BLL
    Public Class VehiculoService
        Implements IDisposable

        Private ReadOnly _contexto As AppDbContext
        Private ReadOnly _repositorio As RepositorioGenerico(Of VehiculoEntidad)
        Private _disposed As Boolean = False

        Public Sub New()
            Dim optionsBuilder As New DbContextOptionsBuilder(Of AppDbContext)()
            optionsBuilder.UseSqlServer("Server=NAIFER\MSSQLSERVER01;Database=SistemaMudanzasDB;Trusted_Connection=True;TrustServerCertificate=True;")

            _contexto = New AppDbContext(optionsBuilder.Options)
            _repositorio = New RepositorioGenerico(Of VehiculoEntidad)(_contexto)
        End Sub

        Public Function CrearVehiculo(placa As String, modelo As String, capacidad As Integer?, estado As String) As Boolean
            Try
                If String.IsNullOrWhiteSpace(placa) Then
                    Console.WriteLine("Placa vacía")
                    Return False
                End If

                If String.IsNullOrWhiteSpace(estado) Then
                    Console.WriteLine("Estado vacío")
                    Return False
                End If

                Dim existe = _repositorio.Existe(Function(v) v.Placa.ToLower() = placa.Trim().ToLower())

                If existe Then
                    Console.WriteLine("❌ La placa ya existe")
                    Return False
                End If

                Dim nuevoVehiculo As New VehiculoEntidad With {
                    .Placa = placa.Trim().ToUpper(),
                    .Modelo = modelo.Trim(),
                    .Capacidad = capacidad,
                    .Estado = estado.Trim()
                }

                Dim resultado = _repositorio.Insertar(nuevoVehiculo)

                If resultado Then
                    Console.WriteLine("✅ Vehículo creado correctamente")
                Else
                    Console.WriteLine("❌ Error al crear vehículo")
                End If

                Return resultado

            Catch ex As Exception
                Console.WriteLine($"Error en CrearVehiculo: {ex.Message}")
                Return False
            End Try
        End Function

        Public Function ObtenerTodosLosVehiculos() As List(Of VehiculoEntidad)
            Try
                Return _repositorio.ObtenerTodos()
            Catch ex As Exception
                Console.WriteLine($"Error en ObtenerTodosLosVehiculos: {ex.Message}")
                Return New List(Of VehiculoEntidad)()
            End Try
        End Function

        Public Function ObtenerVehiculoPorId(id As Integer) As VehiculoEntidad
            Try
                Return _repositorio.BuscarPorId(id)
            Catch ex As Exception
                Console.WriteLine($"Error en ObtenerVehiculoPorId: {ex.Message}")
                Return Nothing
            End Try
        End Function

        Public Function ActualizarVehiculo(vehiculoId As Integer, placa As String, modelo As String, capacidad As Integer?, estado As String) As Boolean
            Try
                Dim vehiculo = _repositorio.BuscarPorId(vehiculoId)

                If vehiculo Is Nothing Then
                    Console.WriteLine("Vehículo no encontrado")
                    Return False
                End If

                Dim existeOtro = _repositorio.Existe(Function(v) _
                    v.Placa.ToLower() = placa.Trim().ToLower() AndAlso v.VehiculoId <> vehiculoId)

                If existeOtro Then
                    Console.WriteLine("❌ La placa ya está en uso por otro vehículo")
                    Return False
                End If

                vehiculo.Placa = placa.Trim().ToUpper()
                vehiculo.Modelo = modelo.Trim()
                vehiculo.Capacidad = capacidad
                vehiculo.Estado = estado.Trim()

                Return _repositorio.Actualizar(vehiculo)

            Catch ex As Exception
                Console.WriteLine($"Error en ActualizarVehiculo: {ex.Message}")
                Return False
            End Try
        End Function

        Public Function EliminarVehiculo(id As Integer) As Boolean
            Try
                Dim vehiculo = _repositorio.BuscarPorId(id)

                If vehiculo Is Nothing Then
                    Console.WriteLine("Vehículo no encontrado")
                    Return False
                End If

                Return _repositorio.Eliminar(vehiculo)

            Catch ex As Exception
                Console.WriteLine($"Error en EliminarVehiculo: {ex.Message}")
                Return False
            End Try
        End Function

        Public Function BuscarVehiculosPorPlaca(placa As String) As List(Of VehiculoEntidad)
            Try
                If String.IsNullOrWhiteSpace(placa) Then
                    Return ObtenerTodosLosVehiculos()
                End If

                Return _repositorio.Buscar(Function(v) v.Placa.ToLower().Contains(placa.Trim().ToLower()))
            Catch ex As Exception
                Console.WriteLine($"Error en BuscarVehiculosPorPlaca: {ex.Message}")
                Return New List(Of VehiculoEntidad)()
            End Try
        End Function

        Public Function ObtenerVehiculosActivos() As List(Of VehiculoEntidad)
            Try
                Return _repositorio.Buscar(Function(v) v.Estado.ToLower() = "activo")
            Catch ex As Exception
                Console.WriteLine($"Error en ObtenerVehiculosActivos: {ex.Message}")
                Return New List(Of VehiculoEntidad)()
            End Try
        End Function

        Public Function CambiarEstadoVehiculo(id As Integer, nuevoEstado As String) As Boolean
            Try
                Dim vehiculo = _repositorio.BuscarPorId(id)

                If vehiculo Is Nothing Then
                    Console.WriteLine("Vehículo no encontrado")
                    Return False
                End If

                vehiculo.Estado = nuevoEstado
                Return _repositorio.Actualizar(vehiculo)

            Catch ex As Exception
                Console.WriteLine($"Error en CambiarEstadoVehiculo: {ex.Message}")
                Return False
            End Try
        End Function

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not _disposed Then
                If disposing Then
                    _repositorio?.Dispose()
                    _contexto?.Dispose()
                End If
                _disposed = True
            End If
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
    End Class
End Namespace