Imports System.Data.SqlClient
Imports Models

Public Class ClienteRepository

    Public Function GetAll() As List(Of Cliente)
        Dim lista As New List(Of Cliente)
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Using cmd As New SqlCommand("SELECT * FROM Clientes", conn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        lista.Add(New Cliente With {
                            .ClienteId = reader("ClienteId"),
                            .Nombre = reader("Nombre").ToString(),
                            .Apellidos = reader("Apellidos").ToString(),
                            .Telefono = reader("Telefono").ToString(),
                            .Email = reader("Email").ToString()
                        })
                    End While
                End Using
            End Using
        End Using
        Return lista
    End Function

    Public Sub Insert(c As Cliente)
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Using cmd As New SqlCommand("INSERT INTO Clientes (Nombre, Apellidos, Telefono, Email) VALUES (@Nombre, @Apellidos, @Telefono, @Email)", conn)
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre)
                cmd.Parameters.AddWithValue("@Apellidos", c.Apellidos)
                cmd.Parameters.AddWithValue("@Telefono", c.Telefono)
                cmd.Parameters.AddWithValue("@Email", c.Email)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Update(c As Cliente)
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Using cmd As New SqlCommand("UPDATE Clientes SET Nombre=@Nombre, Apellidos=@Apellidos, Telefono=@Telefono, Email=@Email WHERE ClienteId=@Id", conn)
                cmd.Parameters.AddWithValue("@Id", c.ClienteId)
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre)
                cmd.Parameters.AddWithValue("@Apellidos", c.Apellidos)
                cmd.Parameters.AddWithValue("@Telefono", c.Telefono)
                cmd.Parameters.AddWithValue("@Email", c.Email)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub Delete(id As Integer)
        Using conn = DatabaseHelper.GetConnection()
            conn.Open()
            Using cmd As New SqlCommand("DELETE FROM Clientes WHERE ClienteId=@Id", conn)
                cmd.Parameters.AddWithValue("@Id", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class