Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_rol")>
Public Class RolEntidad
    <Key>
    Public Property RolId As Integer

    <Required>
    <MaxLength(50)>
    Public Property Nombre As String

    <MaxLength(150)>
    Public Property Descripcion As String

    ' Relación 1:N - Un rol puede tener muchos usuarios
    Public Overridable Property Usuarios As ICollection(Of UsuarioEntidad)

    Public Sub New()
        Usuarios = New HashSet(Of UsuarioEntidad)()
    End Sub
End Class