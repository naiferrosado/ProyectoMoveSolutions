Imports System
Imports System.Windows.Forms
Imports BLL
Imports BLL.BLL
Imports Entidades
Public Class FrmCliente
    Private servicio As ClienteService
    Private clienteIdSeleccionado As Integer = 0
    Private modoEdicion As Boolean = False
    Public Sub New()
        InitializeComponent()
        servicio = New ClienteService()
    End Sub
    Private Sub ConfigurarDataGridView()
        dgvClientes.AutoGenerateColumns = False
        dgvClientes.AllowUserToAddRows = False
        dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvClientes.MultiSelect = False
        dgvClientes.Columns.Clear()

        dgvClientes.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "ClienteId",
            .HeaderText = "ID",
            .DataPropertyName = "ClienteId",
            .Width = 50,
            .ReadOnly = True
        })

        dgvClientes.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Nombre",
            .HeaderText = "Nombre",
            .DataPropertyName = "Nombre",
            .Width = 200,
            .ReadOnly = True
        })

        dgvClientes.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Telefono",
            .HeaderText = "Teléfono",
            .DataPropertyName = "Telefono",
            .Width = 100,
            .ReadOnly = True
        })

        dgvClientes.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Correo",
            .HeaderText = "Correo",
            .DataPropertyName = "Correo",
            .Width = 200,
            .ReadOnly = True
        })

        dgvClientes.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Direccion",
            .HeaderText = "Dirección",
            .DataPropertyName = "Direccion",
            .Width = 250,
            .ReadOnly = True
        })
    End Sub
    Private Sub CargarClientes()
        Try
            Dim clientes = servicio.ObtenerTodosLosClientes()
            dgvClientes.DataSource = Nothing
            dgvClientes.DataSource = clientes
            lblTotal.Text = $"Total de clientes: {clientes.Count}"
        Catch ex As Exception
            MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FrmCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarDataGridView()
        CargarClientes()
        LimpiarCampos()

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not ValidarCampos() Then
            Return
        End If

        Try
            Dim nombre As String = txtNombre.Text.Trim()
            Dim telefono As String = txtTelefono.Text.Trim()
            Dim correo As String = txtCorreo.Text.Trim()
            Dim direccion As String = txtDireccion.Text.Trim()
            Dim resultado As Boolean

            If modoEdicion Then
                resultado = servicio.ActualizarCliente(clienteIdSeleccionado, nombre, telefono, correo, direccion)
                If resultado Then
                    MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            Else
                resultado = servicio.CrearCliente(nombre, telefono, correo, direccion)
                If resultado Then
                    MessageBox.Show("Cliente creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al crear el cliente. El correo puede estar duplicado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End If

            CargarClientes()
            LimpiarCampos()
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If dgvClientes.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un cliente para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim fila = dgvClientes.SelectedRows(0)
            clienteIdSeleccionado = Convert.ToInt32(fila.Cells("ClienteId").Value)
            Dim cliente = servicio.ObtenerClientePorId(clienteIdSeleccionado)

            If cliente IsNot Nothing Then
                txtNombre.Text = cliente.Nombre
                txtTelefono.Text = cliente.Telefono
                txtCorreo.Text = cliente.Correo
                txtDireccion.Text = cliente.Direccion
                modoEdicion = True
                btnGuardar.Text = "Actualizar"
                btnCancelar.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show($"Error al cargar datos del cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvClientes.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim fila = dgvClientes.SelectedRows(0)
            Dim clienteId As Integer = Convert.ToInt32(fila.Cells("ClienteId").Value)
            Dim nombreCliente As String = fila.Cells("Nombre").Value.ToString()

            Dim confirmacion = MessageBox.Show($"¿Está seguro que desea eliminar al cliente '{nombreCliente}'?",
                                               "Confirmar Eliminación",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question)

            If confirmacion = DialogResult.Yes Then
                If servicio.EliminarCliente(clienteId) Then
                    MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CargarClientes()
                    LimpiarCampos()
                Else
                    MessageBox.Show("Error al eliminar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Dim clientes = servicio.BuscarClientesPorNombre(textoBuscar)
            dgvClientes.DataSource = Nothing
            dgvClientes.DataSource = clientes
            lblTotal.Text = $"Clientes encontrados: {clientes.Count}"
        Catch ex As Exception
            MessageBox.Show($"Error en la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function ValidarCampos() As Boolean
        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            MessageBox.Show("El nombre es obligatorio.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNombre.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtCorreo.Text) Then
            MessageBox.Show("El correo es obligatorio.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCorreo.Focus()
            Return False
        End If

        If Not ValidarFormatoCorreo(txtCorreo.Text) Then
            MessageBox.Show("El formato del correo no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCorreo.Focus()
            Return False
        End If

        Return True
    End Function
    Private Function ValidarFormatoCorreo(correo As String) As Boolean
        Try
            Dim email As New System.Net.Mail.MailAddress(correo)
            Return email.Address = correo.Trim()
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub LimpiarCampos()
        txtNombre.Clear()
        txtTelefono.Clear()
        txtCorreo.Clear()
        txtDireccion.Clear()
        txtBuscar.Clear()

        clienteIdSeleccionado = 0
        modoEdicion = False
        btnGuardar.Text = "Guardar"
        btnCancelar.Enabled = False

        txtNombre.Focus()
    End Sub
    Private Sub FrmClientes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If servicio IsNot Nothing Then
            servicio.Dispose()
        End If
    End Sub

    Private Sub txtTelefono_TextChanged(sender As Object, e As EventArgs) Handles txtTelefono.TextChanged
        ' Si el textbox está vacío, salir
        If txtTelefono.Text = "" Then Exit Sub

        ' Mantener solo números
        Dim soloNumeros As String = ""
        For Each c As Char In txtTelefono.Text
            If Char.IsDigit(c) Then
                soloNumeros &= c
            End If
        Next

        ' Si se modificó, reemplazar el texto
        If txtTelefono.Text <> soloNumeros Then
            Dim pos As Integer = txtTelefono.SelectionStart - 1
            txtTelefono.Text = soloNumeros
            If pos < 0 Then pos = 0
            txtTelefono.SelectionStart = pos
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New GestionClientes()
        f.Show()
        Me.Hide()
    End Sub
End Class