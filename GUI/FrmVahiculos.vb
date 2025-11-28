Imports System
Imports System.Windows.Forms
Imports BLL
Imports BLL.BLL
Imports Entidades
Public Class FrmVahiculos
    Private servicio As VehiculoService
    Private vehiculoIdSeleccionado As Integer = 0
    Private modoEdicion As Boolean = False
    Public Sub New()
        InitializeComponent()
        servicio = New VehiculoService()
    End Sub

    Private Sub FrmVahiculos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarDataGridView()
        CargarEstados()
        CargarVehiculos()
        LimpiarCampos()
    End Sub
    Private Sub ConfigurarDataGridView()
        dgvVehiculos.AutoGenerateColumns = False
        dgvVehiculos.AllowUserToAddRows = False
        dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvVehiculos.MultiSelect = False
        dgvVehiculos.Columns.Clear()

        dgvVehiculos.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "VehiculoId",
            .HeaderText = "ID",
            .DataPropertyName = "VehiculoId",
            .Width = 50,
            .ReadOnly = True
        })

        dgvVehiculos.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Placa",
            .HeaderText = "Placa",
            .DataPropertyName = "Placa",
            .Width = 120,
            .ReadOnly = True
        })

        dgvVehiculos.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Modelo",
            .HeaderText = "Modelo",
            .DataPropertyName = "Modelo",
            .Width = 200,
            .ReadOnly = True
        })

        dgvVehiculos.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Capacidad",
            .HeaderText = "Capacidad (kg)",
            .DataPropertyName = "Capacidad",
            .Width = 120,
            .ReadOnly = True
        })

        dgvVehiculos.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Estado",
            .HeaderText = "Estado",
            .DataPropertyName = "Estado",
            .Width = 100,
            .ReadOnly = True
        })
    End Sub
    Private Sub CargarEstados()
        cmbEstado.Items.Clear()
        cmbEstado.Items.Add("Activo")
        cmbEstado.Items.Add("Inactivo")
        cmbEstado.Items.Add("Mantenimiento")
        cmbEstado.SelectedIndex = 0
    End Sub
    Private Sub CargarVehiculos()
        Try
            Dim vehiculos = servicio.ObtenerTodosLosVehiculos()
            dgvVehiculos.DataSource = Nothing
            dgvVehiculos.DataSource = vehiculos
            lblTotal.Text = $"Total de vehículos: {vehiculos.Count}"
        Catch ex As Exception
            MessageBox.Show($"Error al cargar vehículos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not ValidarCampos() Then
            Return
        End If

        Try
            Dim placa As String = txtPlaca.Text.Trim()
            Dim modelo As String = txtModelo.Text.Trim()
            Dim capacidad As Integer? = If(String.IsNullOrWhiteSpace(txtCapacidad.Text), Nothing, Convert.ToInt32(txtCapacidad.Text))
            Dim estado As String = cmbEstado.SelectedItem.ToString()
            Dim resultado As Boolean

            If modoEdicion Then
                resultado = servicio.ActualizarVehiculo(vehiculoIdSeleccionado, placa, modelo, capacidad, estado)
                If resultado Then
                    MessageBox.Show("Vehículo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al actualizar el vehículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Else
                resultado = servicio.CrearVehiculo(placa, modelo, capacidad, estado)
                If resultado Then
                    MessageBox.Show("Vehículo creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al crear el vehículo. La placa puede estar duplicada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End If

            CargarVehiculos()
            LimpiarCampos()
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If dgvVehiculos.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un vehículo para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim fila = dgvVehiculos.SelectedRows(0)
            vehiculoIdSeleccionado = Convert.ToInt32(fila.Cells("VehiculoId").Value)
            Dim vehiculo = servicio.ObtenerVehiculoPorId(vehiculoIdSeleccionado)

            If vehiculo IsNot Nothing Then
                txtPlaca.Text = vehiculo.Placa
                txtModelo.Text = vehiculo.Modelo
                txtCapacidad.Text = If(vehiculo.Capacidad.HasValue, vehiculo.Capacidad.Value.ToString(), "")
                cmbEstado.SelectedItem = vehiculo.Estado
                modoEdicion = True
                btnGuardar.Text = "Actualizar"
                btnCancelar.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show($"Error al cargar datos del vehículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If dgvVehiculos.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un vehículo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim fila = dgvVehiculos.SelectedRows(0)
            Dim vehiculoId As Integer = Convert.ToInt32(fila.Cells("VehiculoId").Value)
            Dim placa As String = fila.Cells("Placa").Value.ToString()

            Dim confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar el vehículo con placa '{placa}'?",
                                               "Confirmar Eliminación",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question)

            If confirmacion = DialogResult.Yes Then
                If servicio.EliminarVehiculo(vehiculoId) Then
                    MessageBox.Show("Vehículo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CargarVehiculos()
                    LimpiarCampos()
                Else
                    MessageBox.Show("Error al eliminar el vehículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        LimpiarCampos()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim textoBuscar As String = txtBuscar.Text.Trim()
            Dim vehiculos = servicio.BuscarVehiculosPorPlaca(textoBuscar)
            dgvVehiculos.DataSource = Nothing
            dgvVehiculos.DataSource = vehiculos
            lblTotal.Text = $"Vehículos encontrados: {vehiculos.Count}"
        Catch ex As Exception
            MessageBox.Show($"Error en la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function ValidarCampos() As Boolean
        If String.IsNullOrWhiteSpace(txtPlaca.Text) Then
            MessageBox.Show("La placa es obligatoria.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPlaca.Focus()
            Return False
        End If

        If txtPlaca.Text.Trim().Length > 20 Then
            MessageBox.Show("La placa no puede tener más de 20 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPlaca.Focus()
            Return False
        End If

        If Not String.IsNullOrWhiteSpace(txtCapacidad.Text) Then
            Dim capacidad As Integer
            If Not Integer.TryParse(txtCapacidad.Text, capacidad) OrElse capacidad <= 0 Then
                MessageBox.Show("La capacidad debe ser un número positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCapacidad.Focus()
                Return False
            End If
        End If

        If cmbEstado.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar un estado.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbEstado.Focus()
            Return False
        End If

        Return True
    End Function
    Private Sub LimpiarCampos()
        txtPlaca.Clear()
        txtModelo.Clear()
        txtCapacidad.Clear()
        txtBuscar.Clear()
        cmbEstado.SelectedIndex = 0
        vehiculoIdSeleccionado = 0
        modoEdicion = False
        btnGuardar.Text = "Guardar"
        btnCancelar.Enabled = False
        txtPlaca.Focus()
    End Sub
    Private Sub txtCapacidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCapacidad.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim f As New FrmMenuPrincipal()
        f.Show()
        Me.Hide()
    End Sub
End Class