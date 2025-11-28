Imports System
Imports System.Linq
Imports DAL
Imports Entidades
Imports Microsoft.EntityFrameworkCore

Namespace BLL
    Public Class EmpleadoService
        Implements IDisposable

        Private ReadOnly _contexto As AppDbContext
        Private ReadOnly _repositorio As RepositorioGenerico(Of EmpleadoEntidad)
        Private _disposed As Boolean = False

        Public Sub New()
            Dim optionsBuilder As New DbContextOptionsBuilder(Of AppDbContext)()
            optionsBuilder.UseSqlServer("Server=NAIFER\MSSQLSERVER01;Database=SistemaMudanzasDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true")

            _contexto = New AppDbContext(optionsBuilder.Options)
            _repositorio = New RepositorioGenerico(Of EmpleadoEntidad)(_contexto)
        End Sub
        Public Function ObtenerTodos() As List(Of EmpleadoEntidad)
            Try
                Return _repositorio.ObtenerTodos()
            Catch ex As Exception
                Console.WriteLine($"Error en EmpleadoService.ObtenerTodos: {ex.Message}")
                Return New List(Of EmpleadoEntidad)()
            End Try
        End Function
        Public Function ObtenerPorId(id As Integer) As EmpleadoEntidad
            Try
                Return _repositorio.BuscarPorId(id)
            Catch ex As Exception
                Console.WriteLine($"Error en EmpleadoService.ObtenerPorId: {ex.Message}")
                Return Nothing
            End Try
        End Function
        Public Function CrearEmpleado(ent As EmpleadoEntidad) As Boolean
            Try
                If ent Is Nothing Then Throw New ArgumentNullException(NameOf(ent))
                If String.IsNullOrWhiteSpace(ent.Nombre) Then
                    Console.WriteLine("Nombre de empleado requerido.")
                    Return False
                End If

                ' Puedes añadir validaciones adicionales (correo, cédula, etc.)
                Return _repositorio.Insertar(ent)
            Catch ex As Exception
                Console.WriteLine($"Error en EmpleadoService.CrearEmpleado: {ex.Message}")
                Return False
            End Try
        End Function
        Public Function ActualizarEmpleado(ent As EmpleadoEntidad) As Boolean
            Try
                If ent Is Nothing Then Throw New ArgumentNullException(NameOf(ent))
                Dim existente = _repositorio.BuscarPorId(ent.EmpleadoId)
                If existente Is Nothing Then
                    Console.WriteLine("Empleado no encontrado.")
                    Return False
                End If

                ' Actualizar campos necesarios
                existente.Nombre = ent.Nombre
                existente.Telefono = ent.Telefono

                ' agrega más propiedades según tu entidad

                Return _repositorio.Actualizar(existente)
            Catch ex As Exception
                Console.WriteLine($"Error en EmpleadoService.ActualizarEmpleado: {ex.Message}")
                Return False
            End Try
        End Function
        Public Function EliminarEmpleado(id As Integer) As Boolean
            Try
                Dim ent = _repositorio.BuscarPorId(id)
                If ent Is Nothing Then
                    Console.WriteLine("Empleado no encontrado.")
                    Return False
                End If
                Return _repositorio.Eliminar(ent)
            Catch ex As Exception
                Console.WriteLine($"Error en EmpleadoService.EliminarEmpleado: {ex.Message}")
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