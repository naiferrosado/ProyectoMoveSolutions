Imports BLL
Imports BLL.BLL
Imports Entidades

Public Class FrmEmpleados

    Private servicio As New EmpleadoService()

    Private Sub FrmEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarComboRol()
        CargarComboDisponibilidad()
        ConfigurarGrid()
        CargarEmpleados()
        txtEmpleadoId.ReadOnly = True
    End Sub


    '   CONFIGURAR COLUMNAS DEL DATAGRIDVIEW (solo las necesarias)

    Private Sub ConfigurarGrid()
        dgvEmpleados.Columns.Clear()
        dgvEmpleados.AutoGenerateColumns = False

        dgvEmpleados.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colId",
            .HeaderText = "ID",
            .DataPropertyName = "EmpleadoId",
            .Width = 50
        })

        dgvEmpleados.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colNombre",
            .HeaderText = "Nombre",
            .DataPropertyName = "Nombre",
            .Width = 150
        })

        dgvEmpleados.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colTelefono",
            .HeaderText = "Teléfono",
            .DataPropertyName = "Telefono",
            .Width = 100
        })

        dgvEmpleados.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colRol",
            .HeaderText = "Rol",
            .DataPropertyName = "Rol",
            .Width = 120
        })

        dgvEmpleados.Columns.Add(New DataGridViewTextBoxColumn() With {
            .Name = "colDisponibilidad",
            .HeaderText = "Disponibilidad",
            .DataPropertyName = "Disponibilidad",
            .Width = 120
        })

        ' Opcional para hacer el grid más bonito
        dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvEmpleados.ReadOnly = True
        dgvEmpleados.AllowUserToAddRows = False
        dgvEmpleados.AllowUserToDeleteRows = False
        dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub


    '   CARGAR DATOS

    Private Sub CargarEmpleados()
        dgvEmpleados.DataSource = servicio.ObtenerTodos()
    End Sub

    Private Sub CargarComboRol()
        cmbRol.Items.Clear()
        cmbRol.Items.AddRange({"Conductor", "Ayudante", "Supervisor", "Oficina"})
    End Sub

    Private Sub CargarComboDisponibilidad()
        cmbDisponibilidad.Items.Clear()
        cmbDisponibilidad.Items.AddRange({"Disponible", "Ocupado", "Fuera de servicio"})
    End Sub

    Private Sub Limpiar()
        txtEmpleadoId.Text = ""
        txtNombre.Text = ""
        txtTelefono.Text = ""
        cmbRol.SelectedIndex = -1
        cmbDisponibilidad.SelectedIndex = -1
    End Sub


    '   BOTÓN GUARDAR

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim emp As New EmpleadoEntidad With {
            .Nombre = txtNombre.Text,
            .Telefono = txtTelefono.Text,
            .Rol = cmbRol.Text,
            .Disponibilidad = cmbDisponibilidad.Text
        }

        If servicio.CrearEmpleado(emp) Then
            MessageBox.Show("Empleado registrado correctamente.")
            CargarEmpleados()
            Limpiar()
        Else
            MessageBox.Show("Error al guardar el empleado.")
        End If

    End Sub


    '   BOTÓN EDITAR

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If txtEmpleadoId.Text = "" Then
            MessageBox.Show("Seleccione un empleado.")
            Return
        End If

        Dim emp As New EmpleadoEntidad With {
            .EmpleadoId = Integer.Parse(txtEmpleadoId.Text),
            .Nombre = txtNombre.Text,
            .Telefono = txtTelefono.Text,
            .Rol = cmbRol.Text,
            .Disponibilidad = cmbDisponibilidad.Text
        }

        If servicio.ActualizarEmpleado(emp) Then
            MessageBox.Show("Empleado actualizado.")
            CargarEmpleados()
            Limpiar()
        Else
            MessageBox.Show("Error al actualizar.")
        End If
    End Sub


    '   BOTÓN ELIMINAR

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If txtEmpleadoId.Text = "" Then
            MessageBox.Show("Seleccione un empleado.")
            Return
        End If

        If servicio.EliminarEmpleado(Integer.Parse(txtEmpleadoId.Text)) Then
            MessageBox.Show("Empleado eliminado.")
            CargarEmpleados()
            Limpiar()
        Else
            MessageBox.Show("No se pudo eliminar.")
        End If

    End Sub


    '   BOTÓN NUEVO

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiar()
    End Sub


    '     EVENTO PARA PASAR DATOS DEL GRID AL FORMULARIO

    Private Sub dgvEmpleados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpleados.CellClick
        If e.RowIndex >= 0 Then
            Dim fila = dgvEmpleados.Rows(e.RowIndex)

            txtEmpleadoId.Text = fila.Cells("colId").Value.ToString()
            txtNombre.Text = fila.Cells("colNombre").Value.ToString()
            txtTelefono.Text = fila.Cells("colTelefono").Value.ToString()
            cmbRol.Text = fila.Cells("colRol").Value.ToString()
            cmbDisponibilidad.Text = fila.Cells("colDisponibilidad").Value.ToString()
        End If
    End Sub

    Private Sub txtTelefono_TextChanged(sender As Object, e As EventArgs) Handles txtTelefono.TextChanged
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

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim f As New FrmMenuPrincipal()
        f.Show()
        Me.Hide()
    End Sub
End Class
