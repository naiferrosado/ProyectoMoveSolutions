Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_pago")>
Public Class PagoEntidad
    <Key>
    Public Property PagoId As Integer

    Public Property FacturaId As Integer
    <ForeignKey("FacturaId")>
    Public Overridable Property Factura As FacturaEntidad

    <Required>
    <MaxLength(50)>
    Public Property MetodoPago As String

    <Required>
    <Column(TypeName:="decimal(10,2)")>
    Public Property Monto As Decimal

    <Required>
    Public Property FechaPago As DateTime

    Public Sub New()
        FechaPago = DateTime.Now
    End Sub
End Class