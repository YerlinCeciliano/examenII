Imports System.Configuration
Imports System.Data.SqlClient

Public Class DatabaseHelper
    Public Shared Function GetConnection() As SqlConnection
        Dim connStr As String = ConfigurationManager.ConnectionStrings("ConexionDB").ConnectionString
        Return New SqlConnection(connStr)
    End Function
End Class
