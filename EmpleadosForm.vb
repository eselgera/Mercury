Imports MySql.Data.MySqlClient

Public Class EmpleadosForm
    Private Sub EmpleadosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        obtenerNuevoIdEmpleado()
        llenarTablaEmpleados()
        llenarCBRol()
        llenarCBEstatus()

    End Sub

    Private Sub btnNewEmpleado_Click(sender As Object, e As EventArgs) Handles btnNewEmpleado.Click
        txtidEmpleado.Clear()
        txtNombreEmpleado.Clear()
        txtApEmpleado.Clear()
        txtUserEmpleado.Clear()
        txtPassEmpleado.Clear()
        txtCorreoEmpleado.Clear()
        txtTelefonoEmpleado.Clear()
        txtBuscarEmpleado.Clear()
        cbRol.SelectedIndex = -1
        cbEstatus.SelectedIndex = -1
        obtenerNuevoIdEmpleado()
        llenarTablaEmpleados()
    End Sub

    Private Sub btnAgregarEmpleado_Click(sender As Object, e As EventArgs) Handles btnAgregarEmpleado.Click
        If txtNombreEmpleado.Text.Trim.Length > 0 And txtApEmpleado.Text.Trim.Length > 0 And txtTelefonoEmpleado.Text.Trim.Length > 0 And txtCorreoEmpleado.Text.Trim.Length > 0 And txtUserEmpleado.Text.Trim.Length > 0 And txtPassEmpleado.Text.Trim.Length > 0 And cbEstatus.SelectedIndex <> -1 And cbRol.SelectedIndex <> -1 Then
            Dim query As String
            Dim nombre = txtNombreEmpleado.Text
            Dim ap = txtApEmpleado.Text
            Dim tel = txtTelefonoEmpleado.Text
            Dim user = txtUserEmpleado.Text
            Dim pass = txtPassEmpleado.Text
            Dim correo = txtCorreoEmpleado.Text
            Dim estatus = cbEstatus.SelectedValue
            Dim rol = cbRol.SelectedValue
            Dim mytimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

            Try
                query = "INSERT INTO Empleado (Nombre,Apellidos, Telefono, Correo,Username, Password, UserEnable ,DateCreated, Rol_idRol) values
                                        ('" & nombre & "','" & ap & "','" & tel & "','" & correo & "','" & user & "','" & pass & "','" & estatus & "','" & mytimestamp & "','" & rol & "')"
                Ejecutar_Query(query)

                btnNewEmpleado_Click(sender, e)
                ' MsgBox("Empleado registrado exitosamente")

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
        Else
            MsgBox("Se deben llenar todos los campos")
        End If
    End Sub

    Private Sub btnUpdateEmpleado_Click(sender As Object, e As EventArgs) Handles btnUpdateEmpleado.Click
        If txtNombreEmpleado.Text.Trim.Length > 0 And txtApEmpleado.Text.Trim.Length > 0 And txtTelefonoEmpleado.Text.Trim.Length > 0 And txtCorreoEmpleado.Text.Trim.Length > 0 And txtUserEmpleado.Text.Trim.Length > 0 And txtPassEmpleado.Text.Trim.Length > 0 And cbEstatus.SelectedIndex <> -1 And cbRol.SelectedIndex <> -1 Then
            Dim query As String
            Dim nombre = txtNombreEmpleado.Text
            Dim ap = txtApEmpleado.Text
            Dim tel = txtTelefonoEmpleado.Text
            Dim user = txtUserEmpleado.Text
            Dim pass = txtPassEmpleado.Text
            Dim correo = txtCorreoEmpleado.Text
            Dim estatus = cbEstatus.SelectedValue
            Dim rol = cbRol.SelectedValue

            Try
                query = "UPDATE Empleado SET
                              Nombre ='" & nombre & "',
                              Apellidos ='" & ap & "',
                              Telefono ='" & tel & "',
                              Correo ='" & correo & "',
                              Username ='" & user & "',
                              Password ='" & pass & "', 
                              UserEnable ='" & estatus & "',
                              Rol_idRol ='" & rol & "' 
                              WHERE idEmpleado = '" & txtidEmpleado.Text & "'"

                Ejecutar_Query(query)
                btnNewEmpleado_Click(sender, e)
                MsgBox("Cliente Actualizado")

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
            Conexion.Close()

        Else
            MsgBox("Se deben llenar todos los campos")
        End If
    End Sub


    'Metodo para obtener el siguiente ID cliente por insertar
    Function obtenerNuevoIdEmpleado()

        Dim sql As String
        Dim lista As String
        Dim NewID As String

        Try
            sql = "SELECT count(*)+1 as ID FROM Empleado"
            Dim Rsdatos = Seleccion_de_datos(sql)

            lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                NewID = Rsdatos.Tables("DATOS").Rows(0).Item("ID")
                txtidEmpleado.Text = NewID
            End If

            Conexion.Close()


        Catch ex As Exception
            MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

    Function llenarTablaEmpleados()

        Dim sql As String
        Dim lista As String
        sql = "Select * From Empleado"

        Try
            Dim Rsdatos = Seleccion_de_datos(sql)
            lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                TableEmpleados.DataSource = Rsdatos.Tables(0)
                AjustarTabla()

            End If
            Conexion.Close()

        Catch ex As Exception
            MsgBox("Error de inicio de sesión, favor de reportar al administrador" & ex.Message)
        End Try

    End Function


    Function AjustarTabla()
        If (TableEmpleados.RowCount > 0) Then
            TableEmpleados.Columns(0).Width = 30
            TableEmpleados.Columns(1).Width = 150
            TableEmpleados.Columns(2).Width = 150
            TableEmpleados.Columns(3).Width = 100
            TableEmpleados.Columns(4).Width = 200
            TableEmpleados.Columns(6).Visible = False
            TableEmpleados.Columns(5).Width = 100
            TableEmpleados.Columns(7).Visible = False
            TableEmpleados.Columns(8).Visible = False
            TableEmpleados.Columns(9).Visible = False

            TableEmpleados.Columns(6).Visible = False
            TableEmpleados.Columns(0).HeaderText = "ID"
            TableEmpleados.Columns(1).HeaderText = "Nombre"
            TableEmpleados.Columns(2).HeaderText = "Apellidos"
            TableEmpleados.Columns(3).HeaderText = "Telefono"
            TableEmpleados.Columns(4).HeaderText = "Correo"
            TableEmpleados.Columns(5).HeaderText = "Usuario"
        End If

    End Function

    Function llenarCBRol()

        Dim sql As String
        sql = "Select * From Rol"

        Try
            Dim Rsdatos = Seleccion_de_datos(sql)


            Dim lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                cbRol.DataSource = Rsdatos.Tables("DATOS")
                cbRol.ValueMember = "idRol"
                cbRol.DisplayMember = "Nombre"
                cbRol.SelectedIndex = -1

            End If
            Conexion.Close()

        Catch ex As Exception
            MsgBox("Error de inicio de sesión, favor de reportar al administrador" & ex.Message)
        End Try

    End Function
    Public Enum Estatus
        Baja = 0
        Activo = 1
    End Enum
    Function llenarCBEstatus()

        Dim result = (From item As Integer In [Enum].GetValues(GetType(Estatus))
                      Select New With
                    {
                        .key = item,
                        .value = [Enum].GetName(GetType(Estatus), item)
                    }).ToList()

        cbEstatus.DataSource = result
        cbEstatus.ValueMember = "key"
        cbEstatus.DisplayMember = "value"

    End Function

    Private Sub TableEmpleados_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles TableEmpleados.CellMouseClick
        If (e.RowIndex > -1) Then
            TableEmpleados.CurrentRow.Selected = True
            txtidEmpleado.Text = TableEmpleados.Rows(e.RowIndex).Cells("idEmpleado").FormattedValue.ToString()
            txtNombreEmpleado.Text = TableEmpleados.Rows(e.RowIndex).Cells("Nombre").FormattedValue.ToString()
            txtApEmpleado.Text = TableEmpleados.Rows(e.RowIndex).Cells("Apellidos").FormattedValue.ToString()
            txtTelefonoEmpleado.Text = TableEmpleados.Rows(e.RowIndex).Cells("Telefono").FormattedValue.ToString()
            txtCorreoEmpleado.Text = TableEmpleados.Rows(e.RowIndex).Cells("Correo").FormattedValue.ToString()
            txtUserEmpleado.Text = TableEmpleados.Rows(e.RowIndex).Cells("Username").FormattedValue.ToString()
            txtPassEmpleado.Text = TableEmpleados.Rows(e.RowIndex).Cells("Password").FormattedValue.ToString()
            cbEstatus.SelectedIndex = TableEmpleados.Rows(e.RowIndex).Cells("UserEnable").FormattedValue.ToString()
            cbRol.SelectedValue = TableEmpleados.Rows(e.RowIndex).Cells("Rol_idRol").FormattedValue.ToString()

        End If
    End Sub

    Private Sub btnSearchEmpleado_Click(sender As Object, e As EventArgs) Handles btnSearchEmpleado.Click
        If txtBuscarEmpleado.Text <> "" Then
            Dim NombreEmpleado = txtBuscarEmpleado.Text
            Dim sql = "Select * From Empleado WHERE nombre LIKE '%" & NombreEmpleado & "%'  OR correo LIKE '%" & NombreEmpleado & "%'"

            Try
                Dim Rsdatos = Seleccion_de_datos(sql)
                Dim lista = Rsdatos.Tables("DATOS").Rows.Count

                If lista <> 0 Then
                    TableEmpleados.DataSource = Rsdatos.Tables(0)
                    'Si se encuentra un resultado, seleccionar
                    If TableEmpleados.SelectedCells.Count > 0 Then
                        TableEmpleados.Rows(0).Selected = True
                        Dim i_rowindex As Integer = TableEmpleados.SelectedCells(0).RowIndex
                        Dim i_colIndex As Integer = TableEmpleados.SelectedCells(0).ColumnIndex
                        TableEmpleados_CellMouseClick(sender, New DataGridViewCellMouseEventArgs(i_colIndex, i_rowindex, 0, 0, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)))
                    End If

                End If
            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try

            Conexion.Close()

        Else
            'MessageBox.Show("Se debe escribir un nombre o correo para buscar algun cliente", " Campo vacio")
            btnNewEmpleado_Click(sender, e)
        End If
    End Sub
End Class