Imports System.Data.Odbc

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection_sql()
        obtenerNuevoIdCliente()
        llenarTablaClientes()
    End Sub

    'Metodo para obtener el siguiente ID cliente por insertar
    Function obtenerNuevoIdCliente()

        connection_sql()
        Dim query As String
        Dim lista As String
        Dim NewID As String

        Try
            query = "SELECT count(*)+1 as ID FROM Cliente"
            adapt = New Odbc.OdbcDataAdapter(query, Connection.con)
            Connection.reg = New DataSet
            adapt.Fill(reg, "Tabla1")
            lista = reg.Tables("Tabla1").Rows.Count
            If lista <> 0 Then
                NewID = reg.Tables("Tabla1").Rows(0).Item("ID")
                txtidCliente.Text = NewID
            End If

            con.Close()

        Catch ex As Exception
            MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

    Function llenarTablaClientes()

        connection_sql()

        Dim ds As DataSet = New DataSet
        Dim adapter As New OleDb.OleDbDataAdapter
        Dim sql As String
        Dim lista As String

        sql = "Select * From cliente"
        Try
            adapt = New Odbc.OdbcDataAdapter(sql, Connection.con)
            Connection.reg = New DataSet
            adapt.Fill(reg, "Tabla1")
            lista = reg.Tables("Tabla1").Rows.Count
            If lista <> 0 Then
                TableClientes.DataSource = reg.Tables(0)
                AjustarTabla()
            End If
        Catch ex As Exception
            MsgBox("Error de inicio de sesión, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        connection_sql()

        Try
            'Leer tabla de usuarios

            Dim consulta As String
            Dim lista As String
            Dim Nombre As String

            consulta = "SELECT Nombre_Cliente FROM Cliente where idcliente = 1"

            'MsgBox("usario es" & consulta)

            adapt = New Odbc.OdbcDataAdapter(consulta, Connection.con)
            Connection.reg = New DataSet
            adapt.Fill(reg, "Tabla1")
            lista = reg.Tables("Tabla1").Rows.Count

            If lista <> 0 Then
                Nombre = reg.Tables("Tabla1").Rows(0).Item("Nombre_Cliente")

                txtNombreCliente.Text = Nombre

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

    'Metodo para limpiar el formulario y dejarlo listo para insertar un nuevo registro
    Private Sub btnNewCliente_Click(sender As Object, e As EventArgs) Handles btnNewCliente.Click
        txtidCliente.Clear()
        txtNombreCliente.Clear()
        txtApPatCliente.Clear()
        txtApMatCliente.Clear()
        txtDireccionCliente.Clear()
        txtCorreoCliente.Clear()
        txtBuscarCliente.Clear()

        llenarTablaClientes()
        obtenerNuevoIdCliente()
    End Sub

    'Metodo para insertar los datos del cliente del formulario
    Private Sub btnAddCliente_Click(sender As Object, e As EventArgs) Handles btnAddCliente.Click

        If txtNombreCliente.Text.Trim.Length > 0 And txtApMatCliente.Text.Trim.Length > 0 And txtApPatCliente.Text.Trim.Length > 0 And txtDireccionCliente.Text.Trim.Length > 0 And txtCorreoCliente.Text.Trim.Length > 0 Then
            Dim query As String
            Dim nombre = txtNombreCliente.Text
            Dim apPat = txtApPatCliente.Text
            Dim apMat = txtApMatCliente.Text
            Dim direccion = txtDireccionCliente.Text
            Dim correo = txtCorreoCliente.Text
            Dim mytimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

            connection_sql()

            Try
                query = "INSERT INTO cliente (Nombre,Apellido_Paterno,Apellido_Materno,Direccion,Correo,DateCreated)values('" & nombre & "','" & apPat & "','" & apMat & "','" & direccion & "','" & correo & "','" & mytimestamp & "' )"
                Dim comando_save As OdbcCommand
                comando_save = New OdbcCommand(query, Connection.con)
                comando_save.ExecuteNonQuery()
                con.Close()
                btnNewCliente_Click(sender, e)
                ' MsgBox("Cliente registrado exitosamente")

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
        Else
            MsgBox("Se deben llenar todos los campos")
        End If


    End Sub


    Function AjustarTabla()
        If (TableClientes.RowCount > 0) Then
            TableClientes.Columns(0).Width = 30
            TableClientes.Columns(2).Width = 110
            TableClientes.Columns(3).Width = 110
            TableClientes.Columns(4).Width = 300
            TableClientes.Columns(5).Width = 110
            TableClientes.Columns(6).Visible = False
            TableClientes.Columns(0).HeaderText = "ID"
            TableClientes.Columns(1).HeaderText = "Nombre"
            TableClientes.Columns(2).HeaderText = "Apellido Paterno"
            TableClientes.Columns(3).HeaderText = "Apellido Materno"
        End If

    End Function

    Private Sub TableClientes_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles TableClientes.CellMouseClick

        If (e.RowIndex > -1) Then
            TableClientes.CurrentRow.Selected = True
            txtidCliente.Text = TableClientes.Rows(e.RowIndex).Cells("idCliente").FormattedValue.ToString()
            txtNombreCliente.Text = TableClientes.Rows(e.RowIndex).Cells("Nombre").FormattedValue.ToString()
            txtApPatCliente.Text = TableClientes.Rows(e.RowIndex).Cells("Apellido_Paterno").FormattedValue.ToString()
            txtApMatCliente.Text = TableClientes.Rows(e.RowIndex).Cells("Apellido_Materno").FormattedValue.ToString()
            txtDireccionCliente.Text = TableClientes.Rows(e.RowIndex).Cells("Direccion").FormattedValue.ToString()
            txtCorreoCliente.Text = TableClientes.Rows(e.RowIndex).Cells("Correo").FormattedValue.ToString()
        End If

    End Sub

    Private Sub btnUpdateCliente_Click(sender As Object, e As EventArgs) Handles btnUpdateCliente.Click
        If txtNombreCliente.Text.Trim.Length > 0 And txtApMatCliente.Text.Trim.Length > 0 And txtApPatCliente.Text.Trim.Length > 0 And txtDireccionCliente.Text.Trim.Length > 0 And txtCorreoCliente.Text.Trim.Length > 0 Then
            Dim query As String
            Dim nombre = txtNombreCliente.Text
            Dim apPat = txtApPatCliente.Text
            Dim apMat = txtApMatCliente.Text
            Dim direccion = txtDireccionCliente.Text
            Dim correo = txtCorreoCliente.Text

            connection_sql()

            Try
                query = "UPDATE cliente SET
                              Nombre ='" & nombre & "',
                              Apellido_Paterno ='" & apPat & "',
                              Apellido_Materno ='" & apMat & "',
                              Direccion ='" & direccion & "',
                              Correo ='" & correo & "' 
                              WHERE idCliente = '" & txtidCliente.Text & "'"

                Dim comando_save As OdbcCommand
                comando_save = New OdbcCommand(query, Connection.con)
                comando_save.ExecuteNonQuery()
                con.Close()
                btnNewCliente_Click(sender, e)
                ' MsgBox("Cliente Actualizado")

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
        Else
            MsgBox("Se deben llenar todos los campos")
        End If

    End Sub

    Private Sub btnSearchCliente_Click(sender As Object, e As EventArgs) Handles btnSearchCliente.Click
        If txtBuscarCliente.Text <> "" Then
            Dim NombreCliente = txtBuscarCliente.Text
            Dim sql = "Select * From cliente WHERE nombre LIKE '%" & NombreCliente & "%'  OR correo LIKE '%" & NombreCliente & "%'"

            Try
                adapt = New Odbc.OdbcDataAdapter(sql, Connection.con)
                Connection.reg = New DataSet
                adapt.Fill(reg, "Tabla1")
                Dim lista = reg.Tables("Tabla1").Rows.Count
                If lista <> 0 Then
                    TableClientes.DataSource = reg.Tables(0)
                    'Si se encuentra un resultado, seleccionar
                    If TableClientes.SelectedCells.Count > 0 Then
                        TableClientes.Rows(0).Selected = True
                        Dim i_rowindex As Integer = TableClientes.SelectedCells(0).RowIndex
                        Dim i_colIndex As Integer = TableClientes.SelectedCells(0).ColumnIndex
                        TableClientes_CellMouseClick(sender, New DataGridViewCellMouseEventArgs(i_colIndex, i_rowindex, 0, 0, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)))
                    End If

                End If
            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try


        Else
            'MessageBox.Show("Se debe escribir un nombre o correo para buscar algun cliente", " Campo vacio")
            btnNewCliente_Click(sender, e)
        End If
    End Sub
End Class
