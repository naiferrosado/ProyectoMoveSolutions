Public Class FrmMenuPrincipal
    Private Sub btnIrADashboard_Click(sender As Object, e As EventArgs)
        Dim f As New Dashboard
        f.Show
        Hide
    End Sub

    Private Sub btnIrAClientes_Click(sender As Object, e As EventArgs) Handles btnIrAClientes.Click
        Dim f As New GestionClientes()
        f.Show()
        Me.Hide()
    End Sub

    Private Sub btnIrAEmpleados_Click(sender As Object, e As EventArgs) Handles btnIrAEmpleados.Click
        Dim f As New FrmEmpleados()
        f.Show()
        Me.Hide()
    End Sub

    Private Sub btnIrAMudanzas_Click(sender As Object, e As EventArgs) Handles btnIrAMudanzas.Click
        Dim f As New GestionMudanzas()
        f.Show()
        Me.Hide()
    End Sub

    Private Sub btnIrAVehiculos_Click(sender As Object, e As EventArgs) Handles btnIrAVehiculos.Click
        Dim f As New FrmVahiculos()
        f.Show()
        Me.Hide()
    End Sub

    Private Sub btnIrAUsuarios_Click(sender As Object, e As EventArgs) Handles btnIrAUsuarios.Click
        Dim f As New NuevoUser()
        f.Show()
        Me.Hide()
    End Sub

    Private Sub btnIrAFacturacion_Click(sender As Object, e As EventArgs) Handles btnIrAFacturacion.Click
        Dim f As New FrmFacturacion()
        f.Show()
        Me.Hide()
    End Sub

    Private Sub btnIrAReportes_Click(sender As Object, e As EventArgs) Handles btnIrAReportes.Click
        Dim f As New FrmReportes()
        f.Show()
        Me.Hide()
    End Sub

    Private Sub FrmMenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class