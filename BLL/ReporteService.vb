Imports DAL
Imports Entidades
Imports Microsoft.EntityFrameworkCore

Public Class ReporteService
    Implements IDisposable

    Private ReadOnly _context As AppDbContext
    Private disposedValue As Boolean

    Public Sub New()
        Dim opt As New DbContextOptionsBuilder(Of AppDbContext)()
        opt.UseSqlServer("Server=NAIFER\MSSQLSERVER01;Database=SistemaMudanzasDB;Trusted_Connection=True;TrustServerCertificate=True;")

        _context = New AppDbContext(opt.Options)
    End Sub


    '   GENERAR REPORTE (Corregido — cliente opcional)

    Public Function GenerarReporte(inicio As DateTime, fin As DateTime, estado As String, cliente As String) As List(Of ReporteMudanzaDTO)
        Try
            Dim query = _context.Mudanzas.
                Include(Function(m) m.Cliente).
                AsQueryable()

            ' FILTRO FECHAS
            query = query.Where(Function(m) m.FechaProgramada >= inicio AndAlso m.FechaProgramada <= fin)

            ' FILTRO ESTADO
            If estado IsNot Nothing AndAlso estado <> "Todos" Then
                query = query.Where(Function(m) m.Estado = estado)
            End If

            ' FILTRO CLIENTE — SOLO si tiene texto
            If Not String.IsNullOrWhiteSpace(cliente) Then
                Dim c = cliente.Trim().ToLower()
                query = query.Where(Function(m) m.Cliente.Nombre.ToLower().Contains(c))
            End If

            ' PROYECCIÓN
            Return query.OrderBy(Function(m) m.FechaProgramada).
                Select(Function(m) New ReporteMudanzaDTO With {
                    .MudanzaId = m.MudanzaId,
                    .Cliente = m.Cliente.Nombre,
                    .FechaProgramada = m.FechaProgramada,
                    .Origen = m.Origen,
                    .Destino = m.Destino,
                    .Estado = m.Estado,
                    .Costo = If(m.CostoEstimado.HasValue, m.CostoEstimado.Value, 0)
                }).ToList()

        Catch ex As Exception
            Console.WriteLine("Error en GenerarReporte: " & ex.Message)
            Return New List(Of ReporteMudanzaDTO)
        End Try
    End Function


    '   DISPOSE

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