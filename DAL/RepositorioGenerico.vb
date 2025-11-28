Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Linq.Expressions
Imports Microsoft.EntityFrameworkCore

Public Class RepositorioGenerico(Of T As Class)
    Implements IDisposable

    Private ReadOnly _contexto As DbContext
    Private ReadOnly _dbSet As DbSet(Of T)
    Private disposedValue As Boolean


    ' CONSTRUCTOR

    Public Sub New(contexto As DbContext)

        If contexto Is Nothing Then
            Throw New ArgumentNullException(NameOf(contexto))
        End If

        _contexto = contexto
        _dbSet = _contexto.Set(Of T)()

    End Sub

    ' MÉTODOS CRUD BÁSICOS

    Public Function Insertar(entidad As T) As Boolean
        Try
            If entidad Is Nothing Then
                Throw New ArgumentNullException(NameOf(entidad))
            End If

            _dbSet.Add(entidad)
            Return _contexto.SaveChanges() > 0

        Catch ex As Exception
            Console.WriteLine("Error al insertar: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function InsertarVarios(entidades As IEnumerable(Of T)) As Boolean
        Try
            If entidades Is Nothing OrElse Not entidades.Any() Then
                Return False
            End If

            _dbSet.AddRange(entidades)
            Return _contexto.SaveChanges() > 0

        Catch ex As Exception
            Console.WriteLine("Error al insertar varios: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function Actualizar(entidad As T) As Boolean
        Try
            If entidad Is Nothing Then
                Throw New ArgumentNullException(NameOf(entidad))
            End If

            _contexto.Entry(entidad).State = EntityState.Modified
            Return _contexto.SaveChanges() > 0

        Catch ex As Exception
            Console.WriteLine("Error al actualizar: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function Eliminar(entidad As T) As Boolean
        Try
            If entidad Is Nothing Then
                Throw New ArgumentNullException(NameOf(entidad))
            End If

            _dbSet.Remove(entidad)
            Return _contexto.SaveChanges() > 0

        Catch ex As Exception
            Console.WriteLine("Error al eliminar: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function EliminarPorId(id As Object) As Boolean
        Try
            Dim entidad = _dbSet.Find(id)

            If entidad Is Nothing Then
                Return False
            End If

            _dbSet.Remove(entidad)
            Return _contexto.SaveChanges() > 0

        Catch ex As Exception
            Console.WriteLine("Error al eliminar por ID: " & ex.Message)
            Return False
        End Try
    End Function


    ' MÉTODOS DE CONSULTA

    Public Function BuscarPorId(id As Object) As T
        Try
            Return _dbSet.Find(id)
        Catch ex As Exception
            Console.WriteLine("Error al buscar por ID: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerTodos() As List(Of T)
        Try
            Return _dbSet.AsNoTracking().ToList()
        Catch ex As Exception
            Console.WriteLine("Error al obtener todos: " & ex.Message)
            Return New List(Of T)
        End Try
    End Function

    Public Async Function ObtenerTodosAsync() As Task(Of List(Of T))
        Try
            Return Await _dbSet.AsNoTracking().ToListAsync()
        Catch ex As Exception
            Console.WriteLine("Error al obtener todos async: " & ex.Message)
            Return New List(Of T)
        End Try
    End Function

    Public Function Buscar(filtro As Expression(Of Func(Of T, Boolean))) As List(Of T)
        Try
            If filtro Is Nothing Then
                Return ObtenerTodos()
            End If

            Return _dbSet.Where(filtro).AsNoTracking().ToList()

        Catch ex As Exception
            Console.WriteLine("Error al buscar con filtro: " & ex.Message)
            Return New List(Of T)
        End Try
    End Function

    Public Function BuscarPrimero(filtro As Expression(Of Func(Of T, Boolean))) As T
        Try
            Return _dbSet.AsNoTracking().FirstOrDefault(filtro)
        Catch ex As Exception
            Console.WriteLine("Error al buscar primero: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Existe(filtro As Expression(Of Func(Of T, Boolean))) As Boolean
        Try
            Return _dbSet.Any(filtro)
        Catch ex As Exception
            Console.WriteLine("Error al verificar existencia: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function Contar(Optional filtro As Expression(Of Func(Of T, Boolean)) = Nothing) As Integer
        Try
            If filtro Is Nothing Then
                Return _dbSet.Count()
            Else
                Return _dbSet.Where(filtro).Count()
            End If

        Catch ex As Exception
            Console.WriteLine("Error al contar: " & ex.Message)
            Return 0
        End Try
    End Function


    ' INCLUYE NAVEGACIÓN

    Public Function ObtenerConIncluir(ParamArray incluir() As Expression(Of Func(Of T, Object))) As List(Of T)
        Try
            Dim query As IQueryable(Of T) = _dbSet

            For Each prop In incluir
                query = query.Include(prop)
            Next

            Return query.AsNoTracking().ToList()

        Catch ex As Exception
            Console.WriteLine("Error al obtener con incluir: " & ex.Message)
            Return New List(Of T)
        End Try
    End Function

    Public Function BuscarConIncluir(filtro As Expression(Of Func(Of T, Boolean)),
                                     ParamArray incluir() As Expression(Of Func(Of T, Object))) As List(Of T)

        Try
            Dim query As IQueryable(Of T) = _dbSet

            For Each prop In incluir
                query = query.Include(prop)
            Next

            If filtro IsNot Nothing Then
                query = query.Where(filtro)
            End If

            Return query.AsNoTracking().ToList()

        Catch ex As Exception
            Console.WriteLine("Error al buscar con incluir: " & ex.Message)
            Return New List(Of T)
        End Try
    End Function

    ' PAGINACIÓN

    Public Function ObtenerPaginado(numPagina As Integer, tamPagina As Integer,
                                    Optional filtro As Expression(Of Func(Of T, Boolean)) = Nothing) As List(Of T)

        Try
            Dim query As IQueryable(Of T) = _dbSet

            If filtro IsNot Nothing Then
                query = query.Where(filtro)
            End If

            Return query.AsNoTracking().
                         Skip((numPagina - 1) * tamPagina).
                         Take(tamPagina).
                         ToList()

        Catch ex As Exception
            Console.WriteLine("Error al paginar: " & ex.Message)
            Return New List(Of T)
        End Try
    End Function


    ' DISPOSE (FINAL)

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                _contexto.Dispose()
            End If
            disposedValue = True
        End If
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

End Class
