Imports System
Imports System.Linq
Imports DAL
Imports Entidades
Imports Microsoft.EntityFrameworkCore

Namespace BLL
    Public Class ClienteService
        Implements IDisposable

        Private ReadOnly _contexto As AppDbContext
        Private ReadOnly _repositorio As RepositorioGenerico(Of ClienteEntidad)
        Private _disposed As Boolean = False


        ' CONSTRUCTOR

        Public Sub New()
            Dim optionsBuilder As New DbContextOptionsBuilder(Of AppDbContext)()
            optionsBuilder.UseSqlServer("Server=NAIFER\MSSQLSERVER01;Database=SistemaMudanzasDB;Trusted_Connection=True;TrustServerCertificate=True;")

            _contexto = New AppDbContext(optionsBuilder.Options)
            _repositorio = New RepositorioGenerico(Of ClienteEntidad)(_contexto)
        End Sub


        ' CREAR CLIENTE

        Public Function CrearCliente(nombre As String, telefono As String, correo As String, direccion As String) As Boolean
            Try
                ' Validaciones básicas
                If String.IsNullOrWhiteSpace(nombre) Then Throw New Exception("El nombre es obligatorio.")
                If String.IsNullOrWhiteSpace(correo) Then Throw New Exception("El correo es obligatorio.")

                ' Normalizar correo: trim, tolower y remover espacios invisibles
                Dim correoLimpio As String = correo.Trim().ToLowerInvariant()
                ' eliminar caracteres unicode de espacio no imprimible (opcional)
                correoLimpio = New String(correoLimpio.Where(Function(ch) Not Char.IsControl(ch)).ToArray())

                ' Buscar existente EN LA BASE (no cargar toda la tabla)
                Dim correoExiste As Boolean = _contexto.Clientes.
            Any(Function(c) c.Correo.Trim().ToLower() = correoLimpio)

                If correoExiste Then
                    ' Loguea o lanza una excepción específica
                    Console.WriteLine("⚠️ El correo ya está registrado.")
                    Return False
                End If

                Dim nuevoCliente As New ClienteEntidad With {
            .Nombre = nombre.Trim(),
            .Telefono = If(telefono, String.Empty).Trim(),
            .Correo = correoLimpio,
            .Direccion = If(direccion, String.Empty).Trim()
        }

                _contexto.Clientes.Add(nuevoCliente)

                Try
                    _contexto.SaveChanges()
                Catch dbex As Microsoft.EntityFrameworkCore.DbUpdateException
                    ' Aquí puedes inspeccionar inner exception para la causa real
                    Dim detalle = If(dbex.InnerException?.Message, dbex.Message)
                    Console.WriteLine($"DbUpdateException al guardar cliente: {detalle}")
                    ' Si la causa es violación de único, devuelve false indicando duplicado
                    Return False
                End Try

                Console.WriteLine("✅ Cliente creado correctamente.")
                Return True

            Catch ex As Exception
                Console.WriteLine($"Error en CrearCliente: {ex.Message}")
                Return False
            End Try
        End Function


        ' OBTENER TODOS LOS CLIENTES
        Public Function ObtenerTodosLosClientes() As List(Of ClienteEntidad)
            Try
                Return _repositorio.ObtenerTodos()
            Catch ex As Exception
                Console.WriteLine($"Error en ObtenerTodosLosClientes: {ex.Message}")
                Return New List(Of ClienteEntidad)()
            End Try
        End Function


        ' OBTENER CLIENTE POR ID

        Public Function ObtenerClientePorId(id As Integer) As ClienteEntidad
            Try
                Return _repositorio.BuscarPorId(id)
            Catch ex As Exception
                Console.WriteLine($"Error en ObtenerClientePorId: {ex.Message}")
                Return Nothing
            End Try
        End Function


        ' ACTUALIZAR CLIENTE

        Public Function ActualizarCliente(clienteId As Integer, nombre As String, telefono As String, correo As String, direccion As String) As Boolean
            Try
                Dim cliente = _repositorio.BuscarPorId(clienteId)
                If cliente Is Nothing Then
                    Console.WriteLine("❌ Cliente no encontrado.")
                    Return False
                End If

                Dim correoLimpio As String = correo.Trim().ToLower()

                ' Verificar si el correo pertenece a otro cliente
                Dim existeOtro As Boolean = _contexto.Clientes.AsEnumerable().
                    Any(Function(c) c.Correo?.Trim().ToLower() = correoLimpio AndAlso c.ClienteId <> clienteId)

                If existeOtro Then
                    Console.WriteLine("❌ El correo ya está en uso por otro cliente.")
                    Return False
                End If

                ' Actualizar datos
                cliente.Nombre = nombre.Trim()
                cliente.Telefono = telefono.Trim()
                cliente.Correo = correoLimpio
                cliente.Direccion = direccion.Trim()

                Return _repositorio.Actualizar(cliente)

            Catch ex As Exception
                Console.WriteLine($"Error en ActualizarCliente: {ex.Message}")
                Return False
            End Try
        End Function


        ' ELIMINAR CLIENTE

        Public Function EliminarCliente(id As Integer) As Boolean
            Try
                Dim cliente = _repositorio.BuscarPorId(id)
                If cliente Is Nothing Then
                    Console.WriteLine("Cliente no encontrado.")
                    Return False
                End If

                Return _repositorio.Eliminar(cliente)

            Catch ex As Exception
                Console.WriteLine($"Error en EliminarCliente: {ex.Message}")
                Return False
            End Try
        End Function


        ' BUSCAR CLIENTES POR NOMBRE

        Public Function BuscarClientesPorNombre(nombre As String) As List(Of ClienteEntidad)
            Try
                If String.IsNullOrWhiteSpace(nombre) Then
                    Return ObtenerTodosLosClientes()
                End If

                Dim nombreLimpio As String = nombre.Trim().ToLower()
                Return _repositorio.Buscar(Function(c) c.Nombre.ToLower().Contains(nombreLimpio))

            Catch ex As Exception
                Console.WriteLine($"Error en BuscarClientesPorNombre: {ex.Message}")
                Return New List(Of ClienteEntidad)()
            End Try
        End Function


        ' DISPOSE

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not _disposed Then
                If disposing Then
                    _repositorio?.Dispose()
                    _contexto?.Dispose()
                End If
                _disposed = True
            End If
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

    End Class
End Namespace
