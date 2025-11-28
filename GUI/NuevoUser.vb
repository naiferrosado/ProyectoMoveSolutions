Imports BLL.BLL
Imports DAL
Imports Entidades
Imports Microsoft.EntityFrameworkCore

Public Class NuevoUser

    Private servicio As UsuarioService
    Public Sub New()
        InitializeComponent()
        servicio = New UsuarioService()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ValidarCampos() Then
            CrearNuevoUsuario()
        End If
    End Sub


    Private Function ValidarCampos() As Boolean


        Dim esValido As Boolean = True


        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            MessageBox.Show("El nombre de usuario es obligatorio.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNombre.Focus()
            Return False
        End If

        If txtNombre.Text.Trim().Length < 4 Then
            MessageBox.Show("El nombre de usuario debe tener al menos 4 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNombre.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtContraseña.Text) Then
            MessageBox.Show("La contraseña es obligatoria.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContraseña.Focus()
            Return False
        End If

        If txtContraseña.Text.Length < 6 Then
            MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContraseña.Focus()
            Return False
        End If


        If String.IsNullOrWhiteSpace(txtCorreo.Text) Then
            MessageBox.Show("El correo electrónico es obligatorio.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCorreo.Focus()
            Return False
        End If

        If Not ValidarFormatoCorreo(txtCorreo.Text) Then
            MessageBox.Show("El formato del correo electrónico no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCorreo.Focus()
            Return False
        End If


        If cmbRol.SelectedIndex = -1 OrElse cmbRol.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar un rol para el usuario.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRol.Focus()
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


    Private Sub CrearNuevoUsuario()
        Try
            Dim nombre As String = txtNombre.Text.Trim()
            Dim clave As String = txtContraseña.Text
            Dim correo As String = txtCorreo.Text.Trim()
            Dim rolId As Integer = Convert.ToInt32(cmbRol.SelectedValue)


            If servicio.CrearUsuario(nombre, clave, correo, rolId) Then
                MessageBox.Show("Usuario creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiarCampos()
                Dim form2 As New Login()
                form2.Show()


                AddHandler form2.FormClosed, Sub() Me.Close()



                ' Limpiar campos después de crear


                ' Opcional: Cerrar el formulario o regresar al login
                ' Dim f As Form = Application.OpenForms.Cast(Of Form)().FirstOrDefault(Function(x) TypeOf x Is Login)
                ' If f Is Nothing Then
                '     f = New Login()
                '     f.Show()
                ' Else
                '     f.BringToFront()
                ' End If
                ' Me.Close()
            Else
                MessageBox.Show("Error al crear usuario. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LimpiarCampos()
        txtNombre.Clear()
        txtContraseña.Clear()
        txtCorreo.Clear()
        cmbRol.SelectedIndex = -1
        txtNombre.Focus()
    End Sub

    Private Sub NuevoUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim roles As New List(Of Object) From {
                New With {.RolId = 2, .Nombre = "Administrador"},
                New With {.RolId = 1, .Nombre = "Usuario"}
            }


            cmbRol.DataSource = roles
            cmbRol.DisplayMember = "Nombre"
            cmbRol.ValueMember = "RolId"
            cmbRol.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show($"Error al cargar roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f = Application.OpenForms.Cast(Of Form).FirstOrDefault(Function(x) TypeOf x Is Login)
        If f Is Nothing Then
            f = New Login
            f.Show
        Else
            f.BringToFront
        End If
        Hide

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim f As New FrmMenuPrincipal()
        f.Show()
        Me.Hide()
    End Sub
End Class