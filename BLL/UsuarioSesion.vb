Imports Entidades

Namespace BLL
    Public Class UsuarioSesion
        ' Variable estática para guardar el usuario actual
        Private Shared _usuarioActual As UsuarioEntidad = Nothing

        ''' <summary>
        ''' Obtiene o establece el usuario actual en sesión
        ''' </summary>
        Public Shared Property UsuarioActual As UsuarioEntidad
            Get
                Return _usuarioActual
            End Get
            Set(value As UsuarioEntidad)
                _usuarioActual = value
            End Set
        End Property

        ''' <summary>
        ''' Verifica si hay un usuario con sesión activa
        ''' </summary>
        Public Shared Function TieneSesion() As Boolean
            Return _usuarioActual IsNot Nothing
        End Function

        ''' <summary>
        ''' Obtiene el nombre del usuario actual
        ''' </summary>
        Public Shared Function ObtenerNombreUsuario() As String
            If _usuarioActual IsNot Nothing Then
                Return _usuarioActual.NombreUsuario
            End If
            Return "Invitado"
        End Function

        ''' <summary>
        ''' Obtiene el ID del usuario actual
        ''' </summary>
        Public Shared Function ObtenerUsuarioId() As Integer?
            If _usuarioActual IsNot Nothing Then
                Return _usuarioActual.UsuarioId
            End If
            Return Nothing
        End Function

        ''' <summary>
        ''' Obtiene el rol del usuario actual
        ''' </summary>
        Public Shared Function ObtenerRolId() As Integer?
            If _usuarioActual IsNot Nothing Then
                Return _usuarioActual.RolId
            End If
            Return Nothing
        End Function

        ''' <summary>
        ''' Cierra la sesión del usuario actual
        ''' </summary>
        Public Shared Sub CerrarSesion()
            _usuarioActual = Nothing
        End Sub

        ''' <summary>
        ''' Verifica si el usuario actual es administrador (ajusta según tu lógica)
        ''' </summary>
        Public Shared Function EsAdministrador() As Boolean
            If _usuarioActual IsNot Nothing Then
                ' Ajusta el ID del rol según tu sistema
                Return _usuarioActual.RolId = 1 ' Ejemplo: 1 = Administrador
            End If
            Return False
        End Function

        ''' <summary>
        ''' Verifica si el usuario tiene un rol específico
        ''' </summary>
        Public Shared Function TieneRol(rolId As Integer) As Boolean
            If _usuarioActual IsNot Nothing Then
                Return _usuarioActual.RolId = rolId
            End If
            Return False
        End Function
    End Class
End Namespace