Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_usuario")>
Public Class UsuarioEntidad
    <Key>
    Public Property UsuarioId As Integer

    <Required>
    <MaxLength(50)>
    Public Property NombreUsuario As String

    <Required>
    <MaxLength(255)>
    Public Property Contrasena As String

    <MaxLength(100)>
    Public Property Correo As String

    <Required>
    <MaxLength(20)>
    Public Property Estado As String

    Public Property RolId As Integer
    <ForeignKey("RolId")>
    Public Overridable Property Rol As RolEntidad

    ' Relaciones con otras entidades
    Public Overridable Property Empleados As ICollection(Of EmpleadoEntidad)
    Public Overridable Property Mudanzas As ICollection(Of MudanzaEntidad)

    Public Sub New()
        Empleados = New HashSet(Of EmpleadoEntidad)()
        Mudanzas = New HashSet(Of MudanzaEntidad)()
        Estado = "Activo"
    End Sub
End Class