Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_incidencia")>
Public Class IncidenciaEntidad
    <Key>
    Public Property IncidenciaId As Integer

    Public Property MudanzaId As Integer
    <ForeignKey("MudanzaId")>
    Public Overridable Property Mudanza As MudanzaEntidad

    <Required>
    <MaxLength(200)>
    Public Property Descripcion As String

    <Required>
    <MaxLength(20)>
    Public Property Severidad As String

    <Required>
    Public Property FechaReporte As DateTime

    Public Property FechaResolucion As DateTime?

    Public Sub New()
        FechaReporte = DateTime.Now
    End Sub
End Class