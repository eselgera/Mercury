Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        obtenerNuevoIdCliente()
        llenarTablaClientes()
    End Sub

    'Metodo para obtener el siguiente ID cliente por insertar
    Function obtenerNuevoIdCliente()

        Dim query As String
        Dim lista As String
        Dim NewID As String

        Try
            query = "SELECT count(*)+1 as ID FROM Cliente"
            Dim Rsdatos = Seleccion_de_datos(query)

            lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                NewID = Rsdatos.Tables("DATOS").Rows(0).Item("ID")
                txtidCliente.Text = NewID
            End If

            Conexion.Close()

        Catch ex As Exception
            MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

    Function llenarTablaClientes()

        Dim sql As String
        Dim lista As String

        sql = "Select * From Cliente"
        Try
            Dim Rsdatos = Seleccion_de_datos(sql)

            lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                TableClientes.DataSource = Rsdatos.Tables(0)
                AjustarTabla()

            End If

            Conexion.Close()

        Catch ex As Exception
            MsgBox("Error de inicio de sesión, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

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

            Try
                query = "INSERT INTO Cliente (Nombre,Apellido_Paterno,Apellido_Materno,Direccion,Correo,DateCreated)values('" & nombre & "','" & apPat & "','" & apMat & "','" & direccion & "','" & correo & "','" & mytimestamp & "' )"
                Ejecutar_Query(query)

                btnNewCliente_Click(sender, e)
                ' MsgBox("Cliente registrado exitosamente")

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
            Conexion.Close()
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

            Try
                query = "UPDATE Cliente SET
                              Nombre ='" & nombre & "',
                              Apellido_Paterno ='" & apPat & "',
                              Apellido_Materno ='" & apMat & "',
                              Direccion ='" & direccion & "',
                              Correo ='" & correo & "' 
                              WHERE idCliente = '" & txtidCliente.Text & "'"

                Ejecutar_Query(query)
                btnNewCliente_Click(sender, e)
                ' MsgBox("Cliente Actualizado")

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
            Conexion.Close()

        Else
            MsgBox("Se deben llenar todos los campos")
        End If

    End Sub

    Private Sub btnSearchCliente_Click(sender As Object, e As EventArgs) Handles btnSearchCliente.Click
        If txtBuscarCliente.Text <> "" Then
            Dim NombreCliente = txtBuscarCliente.Text
            Dim sql = "Select * From Cliente WHERE nombre LIKE '%" & NombreCliente & "%'  OR correo LIKE '%" & NombreCliente & "%'"

            Try
                Dim Rsdatos = Seleccion_de_datos(sql)
                Dim lista = Rsdatos.Tables("DATOS").Rows.Count

                If lista <> 0 Then
                    TableClientes.DataSource = Rsdatos.Tables(0)
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

            Conexion.Close()

        Else
            'MessageBox.Show("Se debe escribir un nombre o correo para buscar algun cliente", " Campo vacio")
            btnNewCliente_Click(sender, e)
        End If
    End Sub

    Private Sub EmpleadosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EmpleadosToolStripMenuItem1.Click
        Dim Empleados = New EmpleadosForm()
        Empleados.Show()
    End Sub

    Private Sub RolesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RolesToolStripMenuItem.Click
        Dim Roles = New RolesForm()
        Roles.Show()
    End Sub
End Class
