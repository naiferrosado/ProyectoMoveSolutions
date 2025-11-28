Imports BLL
Imports Entidades

Public Class GestionMudanzas

    Private Sub GestionMudanzas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarGrid()
        CargarMudanzas()
        AddHandler MudanzaEventos.MudanzaChanged, AddressOf OnMudanzaChanged
        AddHandler DataGridView1.CellDoubleClick, AddressOf DataGridView1_CellDoubleClick
    End Sub

    Private Sub OnMudanzaChanged(mudanzaId As Integer)
        If Me.InvokeRequired Then
            Me.BeginInvoke(New Action(Of Integer)(AddressOf OnMudanzaChanged), mudanzaId)
            Return
        End If
        CargarMudanzas()
    End Sub

    Private Sub InicializarGrid()
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Columns.Clear()

        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "MudanzaId", .HeaderText = "ID", .DataPropertyName = "MudanzaId", .Width = 50})
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Cliente", .HeaderText = "Cliente", .DataPropertyName = "Cliente", .Width = 150})
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Empleado", .HeaderText = "Empleado", .DataPropertyName = "Empleado", .Width = 120})
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Vehiculo", .HeaderText = "Vehículo", .DataPropertyName = "Vehiculo", .Width = 120})
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Origen", .HeaderText = "Origen", .DataPropertyName = "Origen", .Width = 180})
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Destino", .HeaderText = "Destino", .DataPropertyName = "Destino", .Width = 180})
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "FechaProgramada", .HeaderText = "Fecha", .DataPropertyName = "FechaProgramada", .Width = 110})
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Estado", .HeaderText = "Estado", .DataPropertyName = "Estado", .Width = 100})
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "CostoEstimado", .HeaderText = "Costo", .DataPropertyName = "CostoEstimado", .Width = 90})

        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.RowTemplate.Height = 28
    End Sub

    Private Sub CargarMudanzas()
        Try
            Dim texto = If(String.IsNullOrWhiteSpace(TextBox1.Text), Nothing, TextBox1.Text.Trim())

            Using svc As New MudanzaService()
                Dim lista As List(Of MudanzaEntidad)

                If String.IsNullOrWhiteSpace(texto) Then
                    lista = svc.ObtenerMudanzas()
                Else
                    lista = svc.BuscarMudanzas(texto)
                End If

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

                DataGridView1.DataSource = view

                ' Actualizar contador de completadas y total en el panel
                Dim dto = svc.ObtenerDashboard()
                lblCompletadas.Text = dto.TotalCompletadas.ToString()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error cargando mudanzas: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim f As New FrmNuevaMudanza()
        f.Show()
        Me.Hide()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim f As New FrmSeguimientoMudanza()
        f.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        CargarMudanzas()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        Dim idObj = DataGridView1.Rows(e.RowIndex).Cells("MudanzaId").Value
        If idObj Is Nothing Then Return
        Dim id As Integer = Convert.ToInt32(idObj)
        Dim detalleFrm As New FrmDetalleMudanza(id)
        If detalleFrm.ShowDialog() = DialogResult.OK Then
            CargarMudanzas()
        End If
    End Sub

    Private Sub GestionMudanzas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler MudanzaEventos.MudanzaChanged, AddressOf OnMudanzaChanged
        RemoveHandler DataGridView1.CellDoubleClick, AddressOf DataGridView1_CellDoubleClick
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim f As New FrmMenuPrincipal()
        f.Show()
        Me.Hide()
    End Sub
End Class