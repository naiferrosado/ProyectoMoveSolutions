Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_vehiculo")>
Public Class VehiculoEntidad
    <Key>
    Public Property VehiculoId As Integer

    <Required>
    <MaxLength(20)>
    Public Property Placa As String

    <MaxLength(50)>
    Public Property Modelo As String

    Public Property Capacidad As Integer?

    <Required>
    <MaxLength(20)>
    Public Property Estado As String

    ' Relación 1:N - Un vehículo puede ser asignado a muchas mudanzas
    Public Overridable Property Mudanzas As ICollection(Of MudanzaEntidad)

    Public Sub New()
        Mudanzas = New HashSet(Of MudanzaEntidad)()
        Estado = "Activo"
    End Sub
End Class