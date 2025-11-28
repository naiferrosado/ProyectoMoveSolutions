Imports BLL

Public Class FrmSeguimientoMudanza
    Private ReadOnly _mudanzaService As New MudanzaService()

    Private Sub FrmSeguimientoMudanza_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarControles()
        CargarDashboard()
        CargarGrid()

        ' Suscribirse a eventos de mudanza para refrescar automáticamente
        AddHandler MudanzaEventos.MudanzaChanged, AddressOf OnMudanzaChanged
    End Sub

    Private Sub OnMudanzaChanged(mudanzaId As Integer)
        ' Ejecutar en el hilo de UI
        If Me.InvokeRequired Then
            Me.BeginInvoke(New Action(Of Integer)(AddressOf OnMudanzaChanged), mudanzaId)
            Return
        End If

        ' Refrescar completamente (puedes optimizar para refrescar sólo la fila afectada)
        RefrescarVista()
    End Sub

    ' Quitar handler al cerrar el formulario
    Private Sub FrmSeguimientoMudanza_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler MudanzaEventos.MudanzaChanged, AddressOf OnMudanzaChanged
    End Sub

    Private Sub InicializarControles()
        ' Combo estados
        cmbEstadoFiltro.Items.Clear()
        cmbEstadoFiltro.Items.Add("Todas")
        cmbEstadoFiltro.Items.Add("Pendiente")
        cmbEstadoFiltro.Items.Add("En Proceso")
        cmbEstadoFiltro.Items.Add("Completada")
        cmbEstadoFiltro.SelectedIndex = 0

        ' DataGridView: columnas si quieres personalizar
        dgvMudanzas.AutoGenerateColumns = False
        dgvMudanzas.Columns.Clear()

        ' Agregar columnas relevantes:
        dgvMudanzas.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "MudanzaId", .HeaderText = "ID", .DataPropertyName = "MudanzaId", .Width = 50})
        dgvMudanzas.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Cliente", .HeaderText = "Cliente", .DataPropertyName = "Cliente", .Width = 180})
        dgvMudanzas.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Empleado", .HeaderText = "Empleado", .DataPropertyName = "Empleado", .Width = 140})
        dgvMudanzas.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Vehiculo", .HeaderText = "Vehículo", .DataPropertyName = "Vehiculo", .Width = 120})
        dgvMudanzas.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Origen", .HeaderText = "Origen", .DataPropertyName = "Origen", .Width = 180})
        dgvMudanzas.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Destino", .HeaderText = "Destino", .DataPropertyName = "Destino", .Width = 180})
        dgvMudanzas.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "FechaProgramada", .HeaderText = "Fecha", .DataPropertyName = "FechaProgramada", .Width = 120})
        dgvMudanzas.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Estado", .HeaderText = "Estado", .DataPropertyName = "Estado", .Width = 110})
        dgvMudanzas.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "CostoEstimado", .HeaderText = "Costo", .DataPropertyName = "CostoEstimado", .Width = 90})

        dgvMudanzas.RowTemplate.Height = 28
        dgvMudanzas.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        AddHandler dgvMudanzas.DataBindingComplete, AddressOf dgvMudanzas_DataBindingComplete
        AddHandler dgvMudanzas.KeyDown, AddressOf dgvMudanzas_KeyDown
    End Sub

    ' Usar un servicio nuevo por cada carga para garantizar datos frescos de BD
    Private Sub CargarGrid()
        Try
            Dim estado = If(cmbEstadoFiltro.SelectedItem IsNot Nothing, cmbEstadoFiltro.SelectedItem.ToString(), "Todas")

            Using svc As New MudanzaService()
                Dim lista = svc.ObtenerMudanzasPorEstado(estado)
                ' Para mostrar nombre de cliente/empleado/vehiculo en columnas que esperan string
                Dim view = lista.Select(Function(m) New With {
                                            .MudanzaId = m.MudanzaId,
                                            .Cliente = If(m.Cliente IsNot Nothing, If(String.IsNullOrWhiteSpace(m.Cliente.Nombre), m.Cliente.Correo, m.Cliente.Nombre), String.Empty),
                                            .Empleado = If(m.Empleado IsNot Nothing, m.Empleado.Nombre, String.Empty),
                                            .Vehiculo = If(m.Vehiculo IsNot Nothing, m.Vehiculo.Modelo, String.Empty),
                                            .Origen = m.Origen,
                                            .Destino = m.Destino,
                                            .FechaProgramada = m.FechaProgramada.ToString("dd/MM/yyyy"),
                                            .Estado = m.Estado,
                                            .CostoEstimado = If(m.CostoEstimado.HasValue, m.CostoEstimado.Value.ToString("N2"), String.Empty)
                                        }).ToList()

                dgvMudanzas.DataSource = view
            End Using

        Catch ex As Exception
            MessageBox.Show("Error cargando mudanzas: " & ex.Message)
        End Try
    End Sub

    Private Sub CargarDashboard()
        Try
            Using svc As New MudanzaService()
                Dim dto = svc.ObtenerDashboard()
                lblPendietes.Text = dto.TotalPendientes.ToString()
                lblEnProceso.Text = dto.TotalEnProceso.ToString()
                lblCompletadas.Text = dto.TotalCompletadas.ToString()
                lblTotal.Text = dto.Total.ToString()
            End Using
        Catch ex As Exception
            ' no crítico
        End Try
    End Sub

    ' Método público para que otros formularios soliciten refrescar la vista
    Public Sub RefrescarVista()
        CargarDashboard()
        CargarGrid()
    End Sub

    Private Sub dgvMudanzas_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        ' Colorear filas por estado
        For Each row As DataGridViewRow In dgvMudanzas.Rows
            Dim estado As String = Convert.ToString(row.Cells("Estado").Value).Trim()
            Select Case estado
                Case "Pendiente"
                    row.DefaultCellStyle.BackColor = Color.LightYellow
                Case "En Proceso"
                    row.DefaultCellStyle.BackColor = Color.LightSkyBlue
                Case "Completada"
                    row.DefaultCellStyle.BackColor = Color.LightGreen
                Case Else
                    row.DefaultCellStyle.BackColor = Color.White
            End Select
        Next
    End Sub

    Private Sub dgvMudanzas_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Delete Then
            EliminarMudanzaSeleccionada()
            e.Handled = True
        End If
    End Sub

    Private Sub EliminarMudanzaSeleccionada()
        If dgvMudanzas.CurrentRow Is Nothing Then
            MessageBox.Show("Seleccione una mudanza para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim idObj = dgvMudanzas.CurrentRow.Cells("MudanzaId").Value
        Dim id As Integer = Convert.ToInt32(idObj)

        Dim r = MessageBox.Show("¿Desea eliminar la mudanza seleccionada (ID: " & id & ")?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If r <> DialogResult.Yes Then Return

        Try
            Using svc As New MudanzaService()
                Dim ok = svc.EliminarMudanza(id)
                If ok Then
                    MessageBox.Show("Mudanza eliminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RefrescarVista()
                Else
                    MessageBox.Show("No se pudo eliminar la mudanza.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al eliminar: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub dgvMudanzas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMudanzas.CellContentClick

    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Dim t = txtBuscar.Text
        If String.IsNullOrWhiteSpace(t) Then
            CargarGrid()
        Else
            Try
                Using svc As New MudanzaService()
                    Dim resultados = svc.BuscarMudanzas(t)
                    Dim view = resultados.Select(Function(m) New With {
                                                    .MudanzaId = m.MudanzaId,
                                                    .Cliente = If(m.Cliente IsNot Nothing, If(String.IsNullOrWhiteSpace(m.Cliente.Nombre), m.Cliente.Correo, m.Cliente.Nombre), String.Empty),
                                                    .Empleado = If(m.Empleado IsNot Nothing, m.Empleado.Nombre, String.Empty),
                                                    .Vehiculo = If(m.Vehiculo IsNot Nothing, m.Vehiculo.Modelo, String.Empty),
                                                    .Origen = m.Origen,
                                                    .Destino = m.Destino,
                                                    .FechaProgramada = m.FechaProgramada.ToString("dd/MM/yyyy"),
                                                    .Estado = m.Estado,
                                                    .CostoEstimado = If(m.CostoEstimado.HasValue, m.CostoEstimado.Value.ToString("N2"), String.Empty)
                                                }).ToList()
                    dgvMudanzas.DataSource = view
                End Using
            Catch ex As Exception
                MessageBox.Show("Error buscando: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub cmbEstadoFintro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstadoFiltro.SelectedIndexChanged
        CargarGrid()
    End Sub

    ' Botón REFRESCAR fuerza recarga usando nuevos contextos
    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        RefrescarVista()
    End Sub

    Private Sub btnVerDetalle_Click(sender As Object, e As EventArgs) Handles btnVerDetalle.Click
        If dgvMudanzas.CurrentRow Is Nothing Then
            MessageBox.Show("Seleccione una mudanza.")
            Return
        End If

        Dim idObj = dgvMudanzas.CurrentRow.Cells("MudanzaId").Value
        Dim id As Integer = Convert.ToInt32(idObj)
        Dim detalleFrm As New FrmDetalleMudanza(id)
        If detalleFrm.ShowDialog() = DialogResult.OK Then
            ' actualizar vista
            RefrescarVista()
        End If
    End Sub

    Private Sub lblPendietes_Click(sender As Object, e As EventArgs) Handles lblPendietes.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New GestionMudanzas()
        f.Show()
        Me.Hide()
    End Sub
End Class