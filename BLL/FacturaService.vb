Imports DAL
Imports Entidades
Imports Microsoft.EntityFrameworkCore

Public Class FacturaService
    Implements IDisposable

    Private ReadOnly _context As AppDbContext
    Private ReadOnly _repo As RepositorioGenerico(Of FacturaEntidad)
    Private disposedValue As Boolean

    Public Sub New()
        Dim opt As New DbContextOptionsBuilder(Of AppDbContext)()
        opt.UseSqlServer("Server=NAIFER\MSSQLSERVER01;Database=SistemaMudanzasDB;Trusted_Connection=True;TrustServerCertificate=True;")

        _context = New AppDbContext(opt.Options)
        _repo = New RepositorioGenerico(Of FacturaEntidad)(_context)
    End Sub


    '  OBTENER FACTURA POR MUDANZA

    Public Function ObtenerPorMudanzaId(mudanzaId As Integer) As FacturaEntidad
        Try
            Return _context.Facturas.
                Include(Function(f) f.Pagos).
                Include(Function(f) f.Mudanza).
                    ThenInclude(Function(m) m.Cliente).
                FirstOrDefault(Function(f) f.MudanzaId = mudanzaId)

        Catch ex As Exception
            Console.WriteLine("Error en ObtenerPorMudanzaId: " & ex.Message)
            Return Nothing
        End Try
    End Function


    '  OBTENER POR ID

    Public Function ObtenerPorId(id As Integer) As FacturaEntidad
        Try
            Return _context.Facturas.
                Include(Function(f) f.Pagos).
                Include(Function(f) f.Mudanza).
                    ThenInclude(Function(m) m.Cliente).
                FirstOrDefault(Function(f) f.FacturaId = id)

        Catch ex As Exception
            Console.WriteLine("Error en ObtenerPorId: " & ex.Message)
            Return Nothing
        End Try
    End Function


    '  GENERAR FACTURA

    Public Function GenerarFactura(mudanzaId As Integer) As FacturaEntidad
        Try
            Dim mudanza = _context.Mudanzas.
                Include(Function(m) m.Inventario).
                FirstOrDefault(Function(m) m.MudanzaId = mudanzaId)

            If mudanza Is Nothing Then
                Throw New Exception("Mudanza no encontrada.")
            End If

            ' Ya existe factura
            Dim existente = ObtenerPorMudanzaId(mudanzaId)
            If existente IsNot Nothing Then
                Return existente
            End If

            Dim baseCosto As Decimal = mudanza.CostoEstimado.GetValueOrDefault(0D)

            Dim impuestoPorc As Decimal = 18D
            Dim impuestoMonto As Decimal = Math.Round(baseCosto * (impuestoPorc / 100D), 2, MidpointRounding.AwayFromZero)

            Dim total As Decimal = baseCosto + impuestoMonto

            Dim factura As New FacturaEntidad With {
                .MudanzaId = mudanzaId,
                .MontoTotal = total,
                .Impuesto = impuestoPorc,
                .FechaEmision = DateTime.Now,
                .Estado = "Pendiente"
            }

            _context.Facturas.Add(factura)
            _context.SaveChanges()

            Return factura

        Catch ex As Exception
            Console.WriteLine("Error en GenerarFactura: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then _context.Dispose()
            disposedValue = True
        End If
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

End Class
