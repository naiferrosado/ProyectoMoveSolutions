Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_inventario")>
Public Class InventarioEntidad
    <Key>
    Public Property ItemId As Integer

    Public Property MudanzaId As Integer
    <ForeignKey("MudanzaId")>
    Public Overridable Property Mudanza As MudanzaEntidad

    <Required>
    <MaxLength(100)>
    Public Property Descripcion As String

    <Required>
    Public Property Cantidad As Integer

    <Column(TypeName:="decimal(10,2)")>
    Public Property ValorEstimado As Decimal?
End Class