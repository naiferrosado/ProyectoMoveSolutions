Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_empleado")>
Public Class EmpleadoEntidad
    <Key>
    Public Property EmpleadoId As Integer

    <Required>
    <MaxLength(100)>
    Public Property Nombre As String

    <MaxLength(20)>
    Public Property Telefono As String

    <Required>
    <MaxLength(50)>
    Public Property Rol As String

    <Required>
    <MaxLength(10)>
    Public Property Disponibilidad As String

    Public Property UsuarioId As Integer?
    <ForeignKey("UsuarioId")>
    Public Overridable Property Usuario As UsuarioEntidad

    ' Relación 1:N - Un empleado puede tener muchas mudanzas asignadas
    Public Overridable Property Mudanzas As ICollection(Of MudanzaEntidad)

    Public Sub New()
        Mudanzas = New HashSet(Of MudanzaEntidad)()
        Disponibilidad = "Disponible"
    End Sub
End Class