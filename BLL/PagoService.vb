Imports DAL
Imports Entidades
Imports Microsoft.EntityFrameworkCore

Public Class PagoService
    Implements IDisposable

    Private ReadOnly _context As AppDbContext
    Private disposedValue As Boolean

    Public Sub New()
        Dim opt As New DbContextOptionsBuilder(Of AppDbContext)()
        opt.UseSqlServer("Server=NAIFER\MSSQLSERVER01;Database=SistemaMudanzasDB;Trusted_Connection=True;TrustServerCertificate=True;")

        _context = New AppDbContext(opt.Options)
    End Sub

    Public Function RegistrarPago(model As PagoEntidad) As Boolean
        Try
            If model Is Nothing Then Return False

            _context.Pagos.Add(model)

            Dim factura = _context.Facturas.
                Include(Function(f) f.Pagos).
                FirstOrDefault(Function(f) f.FacturaId = model.FacturaId)

            Dim totalPagado As Decimal = factura.Pagos.Sum(Function(p) p.Monto) + model.Monto

            If totalPagado >= factura.MontoTotal Then
                factura.Estado = "Pagada"
            End If

            _context.SaveChanges()

            Return True

        Catch ex As Exception
            Console.WriteLine("Error en RegistrarPago: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function ObtenerPagosDeFactura(idFactura As Integer) As List(Of PagoEntidad)
        Try
            Return _context.Pagos.
                Where(Function(p) p.FacturaId = idFactura).
                OrderBy(Function(p) p.FechaPago).
                ToList()

        Catch ex As Exception
            Console.WriteLine("Error en ObtenerPagosDeFactura:" & ex.Message)
            Return New List(Of PagoEntidad)
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
