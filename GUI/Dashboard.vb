Public Class Dashboard
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim nuevoForm As New GestionClientes()
        nuevoForm.Show()  ' Muestra el nuevo formulario
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim frm As New GestionMudanzas()
        frm.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim frm As New FrmNuevaMudanza
        frm.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim nuevoForm As New FrmVahiculos()
        nuevoForm.Show()  ' Muestra el nuevo formulario
    End Sub

    Private Sub btnIrAEmpleados_Click(sender As Object, e As EventArgs) _
    Handles btnIrAEmpleados.Click

        Dim f As New FrmEmpleados()
        f.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim f As New FrmMenuPrincipal()
        f.Show()
        Me.Hide()
    End Sub
End Class

