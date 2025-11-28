Imports DAL
Imports Entidades
Imports Microsoft.EntityFrameworkCore
Imports System.Linq

Public Class MudanzaService
    Implements IDisposable

    Private ReadOnly _context As AppDbContext
    Private ReadOnly _repo As RepositorioGenerico(Of MudanzaEntidad)
    Private disposedValue As Boolean

    Public Sub New()
        Dim opt As New DbContextOptionsBuilder(Of AppDbContext)()
        opt.UseSqlServer("Server=NAIFER\MSSQLSERVER01;Database=SistemaMudanzasDB;Trusted_Connection=True;TrustServerCertificate=True;")

        _context = New AppDbContext(opt.Options)
        _repo = New RepositorioGenerico(Of MudanzaEntidad)(_context)
    End Sub

    '  CREAR MUDANZA

    Public Function CrearMudanza(model As MudanzaEntidad) As Boolean
        Try
            If model Is Nothing Then Return False

            Dim insertResult = _repo.Insertar(model)
            If insertResult Then
                ' model.MudanzaId será poblado por EF tras SaveChanges
                MudanzaEventos.OnMudanzaChanged(model.MudanzaId)
            End If

            Return insertResult
        Catch ex As Exception
            Console.WriteLine("Error en CrearMudanza: " & ex.Message)
            Return False
        End Try
    End Function


    '  ELIMINAR MUDANZA

    Public Function EliminarMudanza(mudanzaId As Integer) As Boolean
        Try
            Dim deleted = _repo.EliminarPorId(mudanzaId)
            If deleted Then
                ' Notificar que la mudanza cambió (se eliminó)
                MudanzaEventos.OnMudanzaChanged(mudanzaId)
            End If
            Return deleted
        Catch ex As Exception
            Console.WriteLine("Error en EliminarMudanza: " & ex.Message)
            Return False
        End Try
    End Function

    '  OBTENER TODAS

    Public Function ObtenerMudanzas() As List(Of MudanzaEntidad)
        Try
            Return _context.Mudanzas.
                Include(Function(x) x.Cliente).
                Include(Function(x) x.Empleado).
                Include(Function(x) x.Vehiculo).
                ToList()
        Catch ex As Exception
            Console.WriteLine("Error en ObtenerMudanzas: " & ex.Message)
            Return New List(Of MudanzaEntidad)
        End Try
    End Function


    '  OBTENER POR ESTADO

    Public Function ObtenerMudanzasPorEstado(estado As String) As List(Of MudanzaEntidad)
        Try
            Dim query = _context.Mudanzas.
                Include(Function(x) x.Cliente).
                Include(Function(x) x.Empleado).
                Include(Function(x) x.Vehiculo).
                AsQueryable()

            If Not String.IsNullOrWhiteSpace(estado) AndAlso estado <> "Todas" Then
                query = query.Where(Function(m) m.Estado = estado)
            End If

            Return query.OrderBy(Function(m) m.FechaProgramada).ToList()

        Catch ex As Exception
            Console.WriteLine("Error en ObtenerMudanzasPorEstado: " & ex.Message)
            Return New List(Of MudanzaEntidad)
        End Try
    End Function

    '  BUSCAR MUDANZAS

    Public Function BuscarMudanzas(texto As String) As List(Of MudanzaEntidad)
        Try
            Dim t = If(texto, "").Trim().ToLower()

            Return _context.Mudanzas.
                Include(Function(x) x.Cliente).
                Include(Function(x) x.Empleado).
                Include(Function(x) x.Vehiculo).
                Where(Function(m) m.Origen.ToLower().Contains(t) _
                               Or m.Destino.ToLower().Contains(t) _
                               Or m.Estado.ToLower().Contains(t) _
                               Or (m.Cliente IsNot Nothing AndAlso m.Cliente.Nombre.ToLower().Contains(t))).
                OrderBy(Function(m) m.FechaProgramada).
                ToList()

        Catch ex As Exception
            Console.WriteLine("Error en BuscarMudanzas: " & ex.Message)
            Return New List(Of MudanzaEntidad)
        End Try
    End Function


    '  DASHBOARD (Totales)

    Public Function ObtenerDashboard() As DashboardMudanzasDTO
        Try
            Dim lista As List(Of MudanzaEntidad) = _context.Mudanzas.ToList()

            Dim dto As New DashboardMudanzasDTO With {
                .Total = lista.Count,
                .TotalPendientes = lista.Where(Function(x) x.Estado = "Pendiente").Count(),
                .TotalEnProceso = lista.Where(Function(x) x.Estado = "En Proceso").Count(),
                .TotalCompletadas = lista.Where(Function(x) x.Estado = "Completada").Count()
            }

            Return dto

        Catch ex As Exception
            Console.WriteLine("Error en ObtenerDashboard: " & ex.Message)
            Return New DashboardMudanzasDTO()
        End Try
    End Function


    '  ACTUALIZAR ESTADO

    Public Function ActualizarEstadoMudanza(mudanzaId As Integer, nuevoEstado As String) As Boolean
        Try
            Dim mudanza = _repo.BuscarPorId(mudanzaId)
            If mudanza Is Nothing Then Return False

            mudanza.Estado = nuevoEstado

            Dim updated = _repo.Actualizar(mudanza)
            If updated Then
                MudanzaEventos.OnMudanzaChanged(mudanzaId)
            End If

            Return updated

        Catch ex As Exception
            Console.WriteLine("Error en ActualizarEstadoMudanza: " & ex.Message)
            Return False
        End Try
    End Function


    '  OBTENER POR ID

    Public Function ObtenerPorId(id As Integer) As MudanzaEntidad
        Try
            Return _context.Mudanzas.
                Include(Function(x) x.Cliente).
                Include(Function(x) x.Empleado).
                Include(Function(x) x.Vehiculo).
                FirstOrDefault(Function(m) m.MudanzaId = id)

        Catch ex As Exception
            Console.WriteLine("Error en ObtenerPorId: " & ex.Message)
            Return Nothing
        End Try
    End Function


    '  DISPOSE

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                _context?.Dispose()
            End If
            disposedValue = True
        End If
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

End Class


'  DTO DEL DASHBOARD

Public Class DashboardMudanzasDTO
    Public Property Total As Integer
    Public Property TotalPendientes As Integer
    Public Property TotalEnProceso As Integer
    Public Property TotalCompletadas As Integer
End Class

