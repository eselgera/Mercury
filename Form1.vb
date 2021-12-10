Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        obtenerNuevoIdCliente()
        llenarTablaClientes()
        obtenerNuevoIdProveedor()
        llenarTablaProveedores()
        obtenerNuevoIdCat()
        llenarTablaCategorias()
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

    'Metodo para obtener el siguiente ID del Proveedor por insertar
    Function obtenerNuevoIdProveedor()

        Dim query As String
        Dim lista As String
        Dim NewID As String

        Try
            query = "SELECT count(*)+1 as ID FROM Proveedor"
            Dim Rsdatos = Seleccion_de_datos(query)

            lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                NewID = Rsdatos.Tables("DATOS").Rows(0).Item("ID")
                TextBox1_idprov.Text = NewID
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

    Function llenarTablaProveedores()

        Dim sql As String
        Dim lista As String

        sql = "Select * From Proveedor"
        Try
            Dim Rsdatos = Seleccion_de_datos(sql)

            lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                DataGridView1_prov.DataSource = Rsdatos.Tables(0)
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

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        TabControl1.SelectedTab = TabControl1.TabPages(1)
    End Sub

    Private Sub ProductosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem1.Click
        TabControl1.SelectedTab = TabControl1.TabPages(7)
    End Sub

    Private Sub CategoriasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoriasToolStripMenuItem.Click
        TabControl1.SelectedTab = TabControl1.TabPages(6)
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem.Click
        TabControl1.SelectedTab = TabControl1.TabPages(5)
    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click
        TabControl1.SelectedTab = TabControl1.TabPages(2)
    End Sub

    Private Sub PedidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidosToolStripMenuItem.Click
        TabControl1.SelectedTab = TabControl1.TabPages(3)
    End Sub

    Private Sub ReportesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportesToolStripMenuItem.Click
        TabControl1.SelectedTab = TabControl1.TabPages(4)
    End Sub

    Private Sub DataGridView1_prov_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1_prov.CellMouseClick
        If (e.RowIndex > -1) Then
            DataGridView1_prov.CurrentRow.Selected = True
            TextBox1_idprov.Text = DataGridView1_prov.Rows(e.RowIndex).Cells("idProveedor").FormattedValue.ToString()
            TextBox6_nomprov.Text = DataGridView1_prov.Rows(e.RowIndex).Cells("Nombre").FormattedValue.ToString()
            TextBox5_descprov.Text = DataGridView1_prov.Rows(e.RowIndex).Cells("Descripcion").FormattedValue.ToString()
            TextBox4_telprov.Text = DataGridView1_prov.Rows(e.RowIndex).Cells("Telefono").FormattedValue.ToString()
            TextBox3_mailprov.Text = DataGridView1_prov.Rows(e.RowIndex).Cells("Correo").FormattedValue.ToString()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1_idprov.Clear()
        TextBox6_nomprov.Clear()
        TextBox5_descprov.Clear()
        TextBox4_telprov.Clear()
        TextBox3_mailprov.Clear()
        TextBox2_buscprov.Clear()

        obtenerNuevoIdProveedor()
        llenarTablaProveedores()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox6_nomprov.Text.Trim.Length > 0 And TextBox5_descprov.Text.Trim.Length > 0 And TextBox4_telprov.Text.Trim.Length > 0 And TextBox3_mailprov.Text.Trim.Length > 0 Then
            Dim query As String
            Dim nombre = TextBox6_nomprov.Text
            Dim descProv = TextBox5_descprov.Text
            Dim telProv = TextBox4_telprov.Text
            Dim mailProv = TextBox3_mailprov.Text

            Try
                query = "INSERT INTO Proveedor (Nombre,Descripcion,Telefono,Correo)values('" & nombre & "','" & descProv & "','" & telProv & "','" & mailProv & "')"
                Ejecutar_Query(query)

                Button3_Click(sender, e)
                ' MsgBox("Proveedor registrado exitosamente")

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
            Conexion.Close()
        Else
            MsgBox("Se deben llenar todos los campos")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox6_nomprov.Text.Trim.Length > 0 And TextBox5_descprov.Text.Trim.Length > 0 And TextBox4_telprov.Text.Trim.Length > 0 And TextBox3_mailprov.Text.Trim.Length > 0 Then
            Dim query As String
            Dim nombre = TextBox6_nomprov.Text
            Dim descProv = TextBox5_descprov.Text
            Dim telProv = TextBox4_telprov.Text
            Dim mailProv = TextBox3_mailprov.Text

            Try
                query = "UPDATE Proveedor SET
                              Nombre ='" & nombre & "',
                              Descripcion ='" & descProv & "',
                              Telefono ='" & telProv & "',
                              Correo ='" & mailProv & "'
                              WHERE idProveedor = '" & TextBox1_idprov.Text & "'"

                Ejecutar_Query(query)

                Button3_Click(sender, e)
                ' MsgBox("Proveedor actualizado exitosamente")

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
            Conexion.Close()
        Else
            MsgBox("Se deben llenar todos los campos")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox2_buscprov.Text <> "" Then
            Dim NombreProveedor = TextBox2_buscprov.Text
            Dim sql = "Select * From Proveedor WHERE nombre LIKE '%" & NombreProveedor & "%'  OR correo LIKE '%" & NombreProveedor & "%'"

            Try
                Dim Rsdatos = Seleccion_de_datos(sql)
                Dim lista = Rsdatos.Tables("DATOS").Rows.Count

                If lista <> 0 Then
                    DataGridView1_prov.DataSource = Rsdatos.Tables(0)
                    'Si se encuentra un resultado, seleccionar
                    If DataGridView1_prov.SelectedCells.Count > 0 Then
                        DataGridView1_prov.Rows(0).Selected = True
                        Dim i_rowindex As Integer = DataGridView1_prov.SelectedCells(0).RowIndex
                        Dim i_colIndex As Integer = DataGridView1_prov.SelectedCells(0).ColumnIndex
                        DataGridView1_prov_CellMouseClick(sender, New DataGridViewCellMouseEventArgs(i_colIndex, i_rowindex, 0, 0, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)))
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

    Function llenarTablaCategorias()

        Dim sql As String
        Dim lista As String
        sql = "Select * From Categoria"

        Try
            Dim Rsdatos = Seleccion_de_datos(sql)
            lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                Table_Categoria.DataSource = Rsdatos.Tables(0)

            End If
            Conexion.Close()

        Catch ex As Exception
            MsgBox("Error de inicio de sesión, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

    'Metodo para obtener el siguiente ID de categoria para insertar nuevo registro
    Function obtenerNuevoIdCat()

        Dim sql As String
        Dim lista As String
        Dim NewID As String

        Try
            sql = "SELECT count(*)+1 as idCategoria FROM Categoria"
            Dim Rsdatos = Seleccion_de_datos(sql)

            lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                NewID = Rsdatos.Tables("DATOS").Rows(0).Item("idCategoria")
                txtidCat.Text = NewID
            End If

            Conexion.Close()

        Catch ex As Exception
            MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

    Private Sub btnNewCat_Click(sender As Object, e As EventArgs) Handles btnNewCat.Click
        txtidCat.Clear()
        txtNombreCat.Clear()
        txtApCat.Clear()
        txtBuscarCat.Clear()

        obtenerNuevoIdCat()
        llenarTablaCategorias()
    End Sub

    Private Sub btnAgregarCat_Click(sender As Object, e As EventArgs) Handles btnAgregarCat.Click
        If txtNombreCat.Text.Trim.Length > 0 And txtApCat.Text.Trim.Length > 0 Then
            Dim query As String
            Dim nombre = txtNombreCat.Text
            Dim desc = txtApCat.Text

            Try
                query = "INSERT INTO Categoria (Nombre,Descripcion)values('" & nombre & "','" & desc & "' )"
                Ejecutar_Query(query)

                btnNewCat_Click(sender, e)
                MsgBox("Categoria agregada exitosamente")

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
            Conexion.Close()
        Else
            MsgBox("Se deben llenar todos los campos")
        End If
    End Sub

    Private Sub btnUpdateCat_Click(sender As Object, e As EventArgs) Handles btnUpdateCat.Click
        If txtNombreCat.Text.Trim.Length > 0 And txtApCat.Text.Trim.Length > 0 Then
            Dim query As String
            Dim nombre = txtNombreCat.Text
            Dim desc = txtApCat.Text

            Try
                query = "UPDATE Categoria SET
                              Nombre ='" & nombre & "',
                              Descripcion ='" & desc & "'
                              WHERE idCategoria = '" & txtidCat.Text & "'"

                Ejecutar_Query(query)
                btnNewCat_Click(sender, e)
                MsgBox("Categoria Actualizada")

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
            Conexion.Close()
        Else
            MsgBox("Se deben llenar todos los campos")
        End If
    End Sub

    Private Sub btnSearchCat_Click(sender As Object, e As EventArgs) Handles btnSearchCat.Click
        If txtBuscarCat.Text <> "" Then
            Dim NombreCategoria = txtBuscarCat.Text
            Dim sql = "Select * From Categoria WHERE Nombre LIKE '%" & NombreCategoria & "%'  OR Descripcion LIKE '%" & NombreCategoria & "%'"

            Try
                Dim Rsdatos = Seleccion_de_datos(sql)
                Dim lista = Rsdatos.Tables("DATOS").Rows.Count

                If lista <> 0 Then
                    Table_Categoria.DataSource = Rsdatos.Tables(0)
                    'Si se encuentra un resultado, seleccionar
                    If Table_Categoria.SelectedCells.Count > 0 Then
                        Table_Categoria.Rows(0).Selected = True
                        Dim i_rowindex As Integer = Table_Categoria.SelectedCells(0).RowIndex
                        Dim i_colIndex As Integer = Table_Categoria.SelectedCells(0).ColumnIndex
                        Table_Categoria_CellMouseClick(sender, New DataGridViewCellMouseEventArgs(i_colIndex, i_rowindex, 0, 0, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)))
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

    Private Sub Table_Categoria_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Table_Categoria.CellMouseClick
        If (e.RowIndex > -1) Then
            Table_Categoria.CurrentRow.Selected = True
            txtidCat.Text = Table_Categoria.Rows(e.RowIndex).Cells("idCategoria").FormattedValue.ToString()
            txtNombreCat.Text = Table_Categoria.Rows(e.RowIndex).Cells("Nombre").FormattedValue.ToString()
            txtApCat.Text = Table_Categoria.Rows(e.RowIndex).Cells("Descripcion").FormattedValue.ToString()
        End If
    End Sub
End Class
