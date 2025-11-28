Imports BLL
Imports Entidades

Public Class FrmDetalleMudanza
    Private ReadOnly _mudanzaService As New MudanzaService()
    Private _mudanzaId As Integer
    Private _mudanza As MudanzaEntidad

    Public Sub New(mudanzaId As Integer)
        InitializeComponent()
        _mudanzaId = mudanzaId
    End Sub

    Private Sub FrmDetalleMudanza_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDetalle()
        AddHandler MudanzaEventos.MudanzaChanged, AddressOf OnMudanzaChanged
    End Sub

    Private Sub FrmDetalleMudanza_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler MudanzaEventos.MudanzaChanged, AddressOf OnMudanzaChanged
    End Sub

    Private Sub OnMudanzaChanged(mudanzaId As Integer)
        If mudanzaId <> _mudanzaId Then
            Return
        End If

        If Me.InvokeRequired Then
            Me.BeginInvoke(New Action(Of Integer)(AddressOf OnMudanzaChanged), mudanzaId)
            Return
        End If

        CargarDetalle()
    End Sub

    Private Sub CargarDetalle()
        Try
            _mudanza = _mudanzaService.ObtenerPorId(_mudanzaId)
            If _mudanza Is Nothing Then
                MessageBox.Show("Mudanza no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
                Return
            End If

            txtCliente.Text = If(_mudanza.Cliente IsNot Nothing, _mudanza.Cliente.Nombre, String.Empty)
            txtEmpleado.Text = If(_mudanza.Empleado IsNot Nothing, _mudanza.Empleado.Nombre, String.Empty)
            txtVehiculo.Text = If(_mudanza.Vehiculo IsNot Nothing, _mudanza.Vehiculo.Modelo, String.Empty)
            txtOrigen.Text = _mudanza.Origen
            txtDestino.Text = _mudanza.Destino
            txtFecha.Text = _mudanza.FechaProgramada.ToString("dd/MM/yyyy HH:mm")
            txtCosto.Text = If(_mudanza.CostoEstimado.HasValue, _mudanza.CostoEstimado.Value.ToString("N2"), String.Empty)
            txtEstado.Text = _mudanza.Estado
        Catch ex As Exception
            MessageBox.Show("Error cargando detalle: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza el estado o elimina la mudanza si el nuevoEstado es "Cancelada".
    ''' </summary>
    Private Sub ActualizarEstado(nuevoEstado As String)
        Try
            If String.Equals(nuevoEstado, "Cancelada", StringComparison.OrdinalIgnoreCase) Then
                ' Eliminar la mudanza en lugar de marcarla como cancelada
                Dim r = MessageBox.Show("La mudanza se eliminará permanentemente. ¿Desea continuar?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If r <> DialogResult.Yes Then
                    Return
                End If

                Using svc As New MudanzaService()
                    Dim ok = svc.EliminarMudanza(_mudanzaId)
                    If ok Then
                        MessageBox.Show("Mudanza eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Else
                        MessageBox.Show("No se pudo eliminar la mudanza.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using

                Return
            End If

            ' Para otros estados, usamos la actualización existente
            If _mudanzaService.ActualizarEstadoMudanza(_mudanzaId, nuevoEstado) Then
                MessageBox.Show("Estado actualizado a '" & nuevoEstado & "'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("No se pudo actualizar el estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al actualizar estado: " & ex.Message)
        End Try
    End Sub

    Private Sub btnMarcarEnProceso_Click(sender As Object, e As EventArgs) Handles btnMarcarEnProceso.Click
        ActualizarEstado("En Proceso")
    End Sub

    Private Sub btnMarcarCompletada_Click(sender As Object, e As EventArgs) Handles btnMarcarCompletada.Click
        ActualizarEstado("Completada")
    End Sub

    Private Sub btnCancelarMudanza_Click(sender As Object, e As EventArgs) Handles btnCancelarMudanza.Click
        ' Antes: ActualizarEstado("Cancelada")
        ' Ahora: ActualizarEstado manejará la eliminación
        ActualizarEstado("Cancelada")
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class