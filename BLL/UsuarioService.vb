Imports System
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Text
Imports DAL
Imports Entidades
Imports Microsoft.EntityFrameworkCore

Namespace BLL
    Public Class UsuarioService
        Implements IDisposable

        Private ReadOnly _contexto As AppDbContext
        Private ReadOnly _repositorio As RepositorioGenerico(Of UsuarioEntidad)
        Private _disposed As Boolean = False

        Public Sub New()
            Dim optionsBuilder As New DbContextOptionsBuilder(Of AppDbContext)()
            optionsBuilder.UseSqlServer("Server=NAIFER\MSSQLSERVER01;Database=SistemaMudanzasDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true")

            _contexto = New AppDbContext(optionsBuilder.Options)
            _repositorio = New RepositorioGenerico(Of UsuarioEntidad)(_contexto)
        End Sub

        ' 
        ' Método para hashear contraseñas (SHA256)
        ' 
        Private Function HashPassword(password As String) As String
            Using sha256 As SHA256 = SHA256.Create()
                Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
                Dim builder As New StringBuilder()
                For Each b As Byte In bytes
                    builder.Append(b.ToString("x2"))
                Next
                Return builder.ToString()
            End Using
        End Function

        ' 
        '  LOGIN con verificación de hash
        ' 
        Public Function ValidarLogin(nombreUsuario As String, contrasena As String) As UsuarioEntidad
            Try
                If String.IsNullOrWhiteSpace(nombreUsuario) OrElse String.IsNullOrWhiteSpace(contrasena) Then
                    Console.WriteLine("Campos vacíos en el login")
                    Return Nothing
                End If

                Dim usuario = _repositorio.BuscarPrimero(Function(u) _
                    u.NombreUsuario.ToLower() = nombreUsuario.Trim().ToLower() AndAlso
                    u.Estado.ToLower() = "activo"
                )

                If usuario Is Nothing Then
                    Console.WriteLine(" Usuario no encontrado o inactivo")
                    Return Nothing
                End If

                ' Hashear la contraseña ingresada para comparar
                Dim hashIngresado As String = HashPassword(contrasena)

                If usuario.Contrasena = hashIngresado Then
                    Console.WriteLine($" Login exitoso para {usuario.NombreUsuario}")
                    Return usuario
                Else
                    Console.WriteLine(" Contraseña incorrecta")
                    Return Nothing
                End If

            Catch ex As Exception
                Console.WriteLine($"Error en ValidarLogin: {ex.Message}")
                Return Nothing
            End Try
        End Function

        ' 
        ' Crear Usuario (hasheando contraseña)
        ' 
        Public Function CrearUsuario(nombreUsuario As String, contrasena As String, correo As String, rolId As Integer) As Boolean
            Try
                If String.IsNullOrWhiteSpace(nombreUsuario) OrElse String.IsNullOrWhiteSpace(contrasena) Then
                    Console.WriteLine("Datos inválidos al crear usuario")
                    Return False
                End If

                Dim existe = _repositorio.Existe(Function(u) _
                    u.NombreUsuario.ToLower() = nombreUsuario.Trim().ToLower() OrElse
                    (Not String.IsNullOrEmpty(u.Correo) AndAlso u.Correo.ToLower() = correo.Trim().ToLower())
                )

                If existe Then
                    Console.WriteLine("El usuario o correo ya existe")
                    Return False
                End If

                ' Hashear la contraseña antes de guardar
                Dim contrasenaHasheada As String = HashPassword(contrasena)

                Dim nuevoUsuario As New UsuarioEntidad With {
                    .NombreUsuario = nombreUsuario.Trim(),
                    .Contrasena = contrasenaHasheada,
                    .Correo = correo.Trim(),
                    .RolId = rolId,
                    .Estado = "Activo"
                }

                Console.WriteLine($"Insertando usuario: {nuevoUsuario.NombreUsuario}")

                Dim resultado = _repositorio.Insertar(nuevoUsuario)

                If resultado Then
                    Console.WriteLine("Usuario creado correctamente")
                Else
                    Console.WriteLine("Error al crear usuario")
                End If

                Return resultado

            Catch ex As Exception
                Console.WriteLine($"Error en CrearUsuario: {ex.Message}")
                Return False
            End Try
        End Function

        ' 
        ' Cambiar Contraseña (con hash)
        ' 
        Public Function CambiarContrasena(id As Integer, contrasenaActual As String, nuevaContrasena As String) As Boolean
            Try
                Dim usuario = _repositorio.BuscarPorId(id)
                If usuario Is Nothing Then
                    Console.WriteLine("Usuario no encontrado")
                    Return False
                End If

                ' Verificar hash de la contraseña actual
                Dim hashActual As String = HashPassword(contrasenaActual)
                If usuario.Contrasena <> hashActual Then
                    Console.WriteLine("Contraseña actual incorrecta")
                    Return False
                End If

                ' Guardar la nueva hasheada
                usuario.Contrasena = HashPassword(nuevaContrasena)
                Return _repositorio.Actualizar(usuario)

            Catch ex As Exception
                Console.WriteLine($"Error en CambiarContrasena: {ex.Message}")
                Return False
            End Try
        End Function

        'Liberar recursos (IDisposable)

        Public Sub Dispose() Implements IDisposable.Dispose
            If Not _disposed Then
                _contexto.Dispose()
                _disposed = True
            End If
            GC.SuppressFinalize(Me)
        End Sub

    End Class
End Namespace
