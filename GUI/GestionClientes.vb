Imports BLL
Imports Entidades
Imports BLL.BLL
Imports System.Linq

Public Class GestionClientes

    Private Sub GestionClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarGrid()
        CargarClientes()
        AddHandler DataGridView1.CellDoubleClick, AddressOf DataGridView1_CellDoubleClick
        AddHandler MudanzaEventos.MudanzaChanged, AddressOf OnMudanzaChanged ' opcional: si clientes relacionados cambian
    End Sub

    Private Sub OnMudanzaChanged(mudanzaId As Integer)
        ' Si hay cambios relacionados con mudanzas que afecten clientes, refrescar
        If Me.InvokeRequired Then
            Me.BeginInvoke(New Action(Of Integer)(AddressOf OnMudanzaChanged), mudanzaId)
            Return
        End If
        CargarClientes()
    End Sub

    Private Sub InicializarGrid()
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.Columns.Clear()

        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "ClienteId", .HeaderText = "ID", .DataPropertyName = "ClienteId", .Width = 60})
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Nombre", .HeaderText = "Nombre", .DataPropertyName = "Nombre", .Width = 200})
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Telefono", .HeaderText = "Teléfono", .DataPropertyName = "Telefono", .Width = 120})
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Correo", .HeaderText = "Correo", .DataPropertyName = "Correo", .Width = 200})
        DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Direccion", .HeaderText = "Dirección", .DataPropertyName = "Direccion", .Width = 250})

        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.RowTemplate.Height = 28
    End Sub

    Private Sub CargarClientes()
        Try
            Dim texto = If(String.IsNullOrWhiteSpace(TextBox1.Text), Nothing, TextBox1.Text.Trim())

            Using svc As New ClienteService()
                Dim lista As List(Of ClienteEntidad)

                If String.IsNullOrWhiteSpace(texto) Then
                    lista = svc.ObtenerTodosLosClientes()
                Else
                    lista = svc.BuscarClientesPorNombre(texto)
                End If

                ' Preparar vista simple
                Dim view = lista.Select(Function(c) New With {
                                            .ClienteId = c.ClienteId,
                                            .Nombre = c.Nombre,
                                            .Telefono = c.Telefono,
                                            .Correo = c.Correo,
                                            .Direccion = c.Direccion
                                        }).ToList()

                DataGridView1.DataSource = view

                ' Actualizar paneles: reutilizo las labels del diseñador
                Label3.Text = $"Total de Clientes: {lista.Count}"
                Dim sinTelefono = lista.Where(Function(x) String.IsNullOrWhiteSpace(x.Telefono)).Count()
                Label4.Text = $"Clientes a contactar: {sinTelefono}"
            End Using
        Catch ex As Exception
            MessageBox.Show("Error cargando clientes: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim frm As New FrmCliente()
        frm.Show()
        Me.Close() ' o Me.Hide()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        CargarClientes()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        Dim idObj = DataGridView1.Rows(e.RowIndex).Cells("ClienteId").Value
        If idObj Is Nothing Then Return
        Dim id As Integer = Convert.ToInt32(idObj)

        ' Abrir formulario de cliente. FrmCliente no tiene constructor con id,
        ' así que abrimos el formulario y el usuario puede editar; luego refrescamos.
        Dim frm As New FrmCliente()
        frm.ShowDialog()
        CargarClientes()
    End Sub

    Private Sub GestionClientes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler DataGridView1.CellDoubleClick, AddressOf DataGridView1_CellDoubleClick
        RemoveHandler MudanzaEventos.MudanzaChanged, AddressOf OnMudanzaChanged
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' Intencionalmente vacío - usar doble click o botones del formulario para acciones
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim f As New FrmMenuPrincipal()
        f.Show()
        Me.Hide()
    End Sub
End Class