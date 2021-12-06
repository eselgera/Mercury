Imports System.Data.Odbc
Imports System.Data
Imports System.Data.SqlClient

Module Connection


    'Public ConexionSQL As SqlConnection

    Public sql As String
    Public cmd As OdbcCommand
    Public dr As OdbcDataReader
    Public con As OdbcConnection
    Public adapt As OdbcDataAdapter
    'Public adapt As New SqlDataAdapter
    Public reg As New DataSet


    Sub connection_sql()
        Try
            con = New OdbcConnection("DSN=ProyectoDB;")
            If con.State = ConnectionState.Closed Then
                con.Open()
                'MsgBox("Conexión exitosa")
            End If
        Catch ex As Exception
            MsgBox("Error al tratar de conectar a la base de datos: " & ex.Message)
        End Try
    End Sub
End Module

