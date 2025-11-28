Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_factura")>
Public Class FacturaEntidad
    <Key>
    Public Property FacturaId As Integer

    Public Property MudanzaId As Integer
    <ForeignKey("MudanzaId")>
    Public Overridable Property Mudanza As MudanzaEntidad

    <Required>
    <Column(TypeName:="decimal(10,2)")>
    Public Property MontoTotal As Decimal

    <Required>
    <Column(TypeName:="decimal(5,2)")>
    Public Property Impuesto As Decimal

    <Required>
    Public Property FechaEmision As DateTime

    <Required>
    <MaxLength(20)>
    Public Property Estado As String

    ' Relación 1:N - Una factura puede tener varios pagos
    Public Overridable Property Pagos As ICollection(Of PagoEntidad)

    Public Sub New()
        Pagos = New HashSet(Of PagoEntidad)()
        Impuesto = 18D
        FechaEmision = DateTime.Now
        Estado = "Pendiente"
    End Sub
End Class