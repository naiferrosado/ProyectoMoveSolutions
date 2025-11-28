Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_checkpoint")>
Public Class CheckpointEntidad
    <Key>
    Public Property CheckpointId As Integer

    Public Property MudanzaId As Integer
    <ForeignKey("MudanzaId")>
    Public Overridable Property Mudanza As MudanzaEntidad

    <Required>
    Public Property Secuencia As Integer

    Public Property HoraPrevista As DateTime?

    Public Property HoraReal As DateTime?

    <Column(TypeName:="decimal(9,6)")>
    Public Property Latitud As Decimal?

    <Column(TypeName:="decimal(9,6)")>
    Public Property Longitud As Decimal?

    <Required>
    <MaxLength(20)>
    Public Property Estado As String

    Public Sub New()
        Estado = "Pendiente"
    End Sub
End Class