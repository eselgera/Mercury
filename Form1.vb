Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection_sql()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        connection_sql()

        Try
            'Leer tabla de usuarios

            Dim consulta As String
            Dim lista As String
            Dim Nombre As String

            consulta = "SELECT Name FROM Login where Credential = '" & TextBox1.Text & "'"

            'MsgBox("usario es" & consulta)

            adapt = New Odbc.OdbcDataAdapter(consulta, Connection.con)
            Connection.reg = New DataSet
            adapt.Fill(reg, "Tabla1")
            lista = reg.Tables("Tabla1").Rows.Count

            If lista <> 0 Then
                Nombre = reg.Tables("Tabla1").Rows(0).Item("Name")

                TextBox1.Text = Nombre

                MsgBox("Hola " & Nombre)

                con.Close()

            Else

                MsgBox("Usuario no existe")

                Return

            End If
        Catch ex As Exception
            MsgBox("Error de inicio de sesión, favor de reportar al administrador" & ex.Message)
        End Try

        con.Close()


    End Sub
End Class
