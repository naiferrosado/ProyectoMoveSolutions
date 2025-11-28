Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema


<Table("tbl_cliente")>
Public Class ClienteEntidad
    <Key>
    Public Property ClienteId As Integer

    <Required>
    <MaxLength(100)>
    Public Property Nombre As String

    <MaxLength(20)>
    Public Property Telefono As String

    <Required>
    <MaxLength(100)>
    Public Property Correo As String

    <MaxLength(150)>
    Public Property Direccion As String

    ' Relación 1:N - Un cliente puede tener muchas mudanzas
    Public Overridable Property Mudanzas As ICollection(Of MudanzaEntidad)

    Public Sub New()
        Mudanzas = New HashSet(Of MudanzaEntidad)()
    End Sub
End Class