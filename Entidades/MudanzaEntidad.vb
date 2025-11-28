Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("tbl_mudanza")>
Public Class MudanzaEntidad
    <Key>
    Public Property MudanzaId As Integer

    Public Property ClienteId As Integer
    <ForeignKey("ClienteId")>
    Public Overridable Property Cliente As ClienteEntidad

    Public Property EmpleadoId As Integer?
    <ForeignKey("EmpleadoId")>
    Public Overridable Property Empleado As EmpleadoEntidad

    Public Property VehiculoId As Integer?
    <ForeignKey("VehiculoId")>
    Public Overridable Property Vehiculo As VehiculoEntidad

    <Required>
    <MaxLength(150)>
    Public Property Origen As String

    <Required>
    <MaxLength(150)>
    Public Property Destino As String

    <Required>
    Public Property FechaProgramada As DateTime

    <Required>
    <MaxLength(20)>
    Public Property Estado As String

    <Column(TypeName:="decimal(10,2)")>
    Public Property CostoEstimado As Decimal?

    Public Property UsuarioId As Integer?
    <ForeignKey("UsuarioId")>
    Public Overridable Property Usuario As UsuarioEntidad

    ' Relaciones 1:N
    Public Overridable Property Inventario As ICollection(Of InventarioEntidad)
    Public Overridable Property Checkpoints As ICollection(Of CheckpointEntidad)
    Public Overridable Property Incidencias As ICollection(Of IncidenciaEntidad)

    ' Relación 1:1
    Public Overridable Property Factura As FacturaEntidad

    Public Sub New()
        Inventario = New HashSet(Of InventarioEntidad)()
        Checkpoints = New HashSet(Of CheckpointEntidad)()
        Incidencias = New HashSet(Of IncidenciaEntidad)()
        Estado = "Pendiente"
    End Sub
End Class