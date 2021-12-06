Imports MySql.Data.MySqlClient
Module CloudMySQL
    Public ConexionaJDESQL As MySqlConnection

    Private _connection As New MySqlConnection
    Private _errormessge As String
    Public ReadOnly Property ErrorMessage() As String
        Get
            Return _errormessge
        End Get
    End Property
    Public Function Connection() As Boolean
        Try
            _connection.connectionString = "Server=b8hrt3nyyisdb1zuqz9i-mysql.services.clever-cloud.com;Port=3306;Database=b8hrt3nyyisdb1zuqz9i;User ID=ufy3iskn6mnef5us;Password=zdaakkP7DXXiVmu7X411"
            _connection.Open()
            If _connection.State = ConnectionState.Open Then
                MsgBox("Conexión realizada con exito")
                _connection.Close()
                Return True
            End If
        Catch ex As Exception
            _errormessge = ex.Message
            MsgBox("Sin éxito :( " & ex.Message)
            Return False
        End Try
    End Function
End Module
