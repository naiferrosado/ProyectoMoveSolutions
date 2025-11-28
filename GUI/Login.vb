Imports BLL.BLL
Imports DAL
Imports Entidades
Imports Microsoft.EntityFrameworkCore

Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            If String.IsNullOrWhiteSpace(txtUsuario.Text) Then
                MessageBox.Show("Por favor ingrese su nombre de usuario.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtUsuario.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtContraseña.Text) Then
                MessageBox.Show("Por favor ingrese su contraseña.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtContraseña.Focus()
                Return
            End If


            Using usuarioService As New UsuarioService()
                Dim usuario As UsuarioEntidad = usuarioService.ValidarLogin(txtUsuario.Text, txtContraseña.Text)

                If usuario IsNot Nothing Then

                    MessageBox.Show($"¡Bienvenido {usuario.NombreUsuario}!", "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information)


                    UsuarioSesion.UsuarioActual = usuario


                    Me.Hide()
                    Dim menuprincipal As New FrmMenuPrincipal()
                    menuprincipal.Show()

                    AddHandler menuprincipal.FormClosed, Sub() Me.Close()
                Else

                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtContraseña.Clear()
                    txtUsuario.Focus()
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al validar credenciales: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim form2 As New NuevoUser
        form2.Show


        AddHandler form2.FormClosed, Sub() Close
    End Sub
End Class