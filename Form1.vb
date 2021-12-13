Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        obtenerNuevoIdCliente()
        llenarTablaClientes()
        obtenerNuevoIdProveedor()
        llenarTablaProveedores()
        obtenerNuevoIdCat()
        llenarTablaCategorias()
        llenarCBProveedores()
        obtenerNuevoIdProducto()
        llenarTablaProducto()
        llenarCBCat()
        llenarCBProveedor()
        llenarCBCatPromo()
        obtenerNuevoIdVenta()
        llenarCBClientes()
        llenarTablaPdctoVenta()

        'Columnas Carrito de Ventas
        DG_Carrito.Columns.Add("id", "idProducto")
        DG_Carrito.Columns.Add("Desc", "Nombre")
        DG_Carrito.Columns.Add("Cant", "Cantidad")
        DG_Carrito.Columns.Add("Dinero", "Precio Total")
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
                lb_IdEmpleado.Text = NewID
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

    '-------------------------------------------PEDIDOS-----------------------------------------------------------'
    Function llenarCBProveedores()

        'dateTimePicker1.CustomFormat = "yyyy/MM/dd"
        'DateTimePicker2.CustomFormat = "yyyy/MM/dd"
        dateTimePicker1.Value = DateTime.Today.AddMonths(-1)
        DateTimePicker2.Value = DateTime.Today

        Dim sql As String
        sql = "Select * From Proveedor"

        Try
            Dim Rsdatos = Seleccion_de_datos(sql)

            Dim lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                cbProveedor.DataSource = Rsdatos.Tables("DATOS")
                cbProveedor.ValueMember = "idProveedor"
                cbProveedor.DisplayMember = "Nombre"
                'cbProveedor.SelectedIndex = 0
            End If
            Conexion.Close()

        Catch ex As Exception
            MsgBox("Error de inicio de sesión, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

    Private Sub cbProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProveedor.SelectedIndexChanged
        Dim idProveedor = cbProveedor.SelectedValue
        Dim fecha_inicio = dateTimePicker1.Value.ToString("yyyy/MM/dd")
        Dim fecha_fin = DateTimePicker2.Value.ToString("yyyy/MM/dd")

        If cbProveedor.SelectedValue > 0 Then
            btnCrearPedido.Enabled = True
            Dim sql = "SELECT idPedido, Fecha_Pedido, Estatus, Nombre FROM Pedido JOIN Proveedor on (Proveedor_idProveedor = idProveedor) WHERE Proveedor_idProveedor = '" & idProveedor & "' AND (Fecha_Pedido BETWEEN '" & fecha_inicio & " 00:00:00' AND '" & fecha_fin & " 23:59:59')"
            Try
                Dim Rsdatos = Seleccion_de_datos(sql)
                Dim lista = Rsdatos.Tables("DATOS").Rows.Count

                PedidosTable.DataSource = Rsdatos.Tables(0)
                PedidosTable.Columns(0).Width = 60
                PedidosTable.Columns(1).Width = 150
                PedidosTable.Columns(2).Width = 120
                PedidosTable.Columns(3).Width = 150
                PedidosTable.Columns(3).HeaderText = "Proveedor"

                'Si se encuentra un resultado, seleccionar

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try

            Conexion.Close()
        End If
    End Sub

    Private Sub btnCrearPedido_Click(sender As Object, e As EventArgs) Handles btnCrearPedido.Click
        If (cbProveedor.SelectedValue > 0) Then
            Dim query As String
            Dim idproveedor = cbProveedor.SelectedValue
            Dim desc = txtApCat.Text
            Dim mytimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            Try
                query = "INSERT INTO Pedido (Estatus,Fecha_Pedido,Proveedor_idProveedor)values('Preparando','" & mytimestamp & "' ,'" & idproveedor & "')"
                Ejecutar_Query(query)

                cbProveedor_SelectedIndexChanged(sender, e)
                MsgBox("Se ha creado un nuevo Pedido para " & cbProveedor.Text)

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
            Conexion.Close()
        End If
    End Sub

    Public estatus_pedidos
    Public id_pedidos

    Private Sub PedidosTable_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles PedidosTable.CellMouseClick
        btnEliminarPedido.Enabled = False
        btnEnviarPedido.Enabled = False
        btnCompletarPedido.Enabled = False
        btnCancelarPedido.Enabled = False
        btnAgregarProductoPedido.Enabled = False
        btnBorrarProductoPedido.Enabled = False
        btnActualizarProductoPedido.Enabled = False
        btnGuardarProductosPedido.Enabled = False
        DetallesPedidoTable.Enabled = False

        txtcantidad.Clear()
        txtNombreProductoPedido.Clear()

        If (e.RowIndex > -1) Then
            PedidosTable.CurrentRow.Selected = True
            id_pedidos = PedidosTable.Rows(e.RowIndex).Cells("idPedido").FormattedValue.ToString()
            estatus_pedidos = PedidosTable.Rows(e.RowIndex).Cells("Estatus").FormattedValue.ToString()

            Select Case estatus_pedidos
                Case "Preparando"
                    btnEliminarPedido.Enabled = True
                    btnEnviarPedido.Enabled = True
                    btnAgregarProductoPedido.Enabled = True
                    btnCancelarPedido.Enabled = True
                    DetallesPedidoTable.Enabled = True
                Case "Enviado"
                    btnCompletarPedido.Enabled = True
                    btnCancelarPedido.Enabled = True
                    btnCancelarPedido.Enabled = True

                Case "Cancelado"
                    btnEliminarPedido.Enabled = False
                    btnEnviarPedido.Enabled = False
                    btnCompletarPedido.Enabled = False
                    btnCancelarPedido.Enabled = False

            End Select

            llenarTablaDetallesPedidos()


        End If
    End Sub

    Function llenarTablaDetallesPedidos()
        Dim sql As String
        Dim lista As String

        sql = "Select idProducto, Nombre as Producto, Cantidad, idDetallesPedido From DetallesPedido JOIN Producto ON (idProducto = Producto_idProducto) WHERE Pedido_idPedido = " & id_pedidos

        Try
            Dim Rsdatos = Seleccion_de_datos(sql)
            lista = Rsdatos.Tables("DATOS").Rows.Count
            'If lista <> 0 Then
            DetallesPedidoTable.DataSource = Rsdatos.Tables(0)

            'End If
            Conexion.Close()

            DetallesPedidoTable.Columns(0).Width = 60
            DetallesPedidoTable.Columns(1).Width = 210
            DetallesPedidoTable.Columns(2).Width = 110
            DetallesPedidoTable.Columns(0).HeaderText = "ID"
            DetallesPedidoTable.Columns(1).HeaderText = "Producto"
            DetallesPedidoTable.Columns(2).HeaderText = "Cantidad"
            DetallesPedidoTable.Columns(3).Visible = False


        Catch ex As Exception
            MsgBox("Error de inicio de sesión, favor de reportar al administrador" & ex.Message)
        End Try
    End Function

    Private Sub btnEliminarPedido_Click(sender As Object, e As EventArgs) Handles btnEliminarPedido.Click
        If (estatus_pedidos = "Preparando") Then
            Dim query As String
            Try
                query = "DELETE FROM Pedido WHERE idPedido = " & id_pedidos
                Ejecutar_Query(query)

                cbProveedor_SelectedIndexChanged(sender, e)
                MsgBox("Se elimino el Pedido " & id_pedidos)

            Catch ex As Exception
                MsgBox("Este pedido no puede eliminarse")
                'MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
            Conexion.Close()
        Else
            MsgBox("No es posible eliminar este pedidos")
        End If

    End Sub

    Private Sub btnEnviarPedido_Click(sender As Object, e As EventArgs) Handles btnEnviarPedido.Click
        If (estatus_pedidos = "Preparando") Then
            Dim query As String
            Try
                query = "UPDATE Pedido SET Estatus = 'Enviado' WHERE idPedido = " & id_pedidos
                Ejecutar_Query(query)

                cbProveedor_SelectedIndexChanged(sender, e)
                MsgBox("Se ha enviado el pedido al proveedor " & cbProveedor.Text)

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
            Conexion.Close()
        Else
            'MsgBox("Error del Sistema")
        End If
    End Sub

    Private Sub btnCompletarPedido_Click(sender As Object, e As EventArgs) Handles btnCompletarPedido.Click
        If (estatus_pedidos = "Enviado") Then
            Dim query As String
            Try
                query = "UPDATE Pedido SET Estatus = 'Completado' WHERE idPedido = " & id_pedidos
                Ejecutar_Query(query)
                btnCancelarPedido.Enabled = False

                Try
                    Dim procedure = "Call recibirProductos(" & id_pedidos & ")"
                    Ejecutar_Query(procedure)

                Catch ex As Exception
                    MsgBox("Error del Sistema 2, favor de reportar al administrador" & ex.Message)
                End Try

                cbProveedor_SelectedIndexChanged(sender, e)
                MsgBox("Se recibieron todos los productos del pedido")

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
            Conexion.Close()
        Else
            'MsgBox("Error del Sistema")
        End If
    End Sub

    Private Sub btnCancelarPedido_Click(sender As Object, e As EventArgs) Handles btnCancelarPedido.Click
        Dim query As String
        btnEnviarPedido.Enabled = False
        btnCompletarPedido.Enabled = False
        btnCancelarPedido.Enabled = False
        Try
            query = "UPDATE Pedido SET Estatus = 'Cancelado' WHERE idPedido = " & id_pedidos
            Ejecutar_Query(query)

            cbProveedor_SelectedIndexChanged(sender, e)
            MsgBox("Se ha cancelado el pedido " & id_pedidos)

        Catch ex As Exception
            MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
        End Try
        Conexion.Close()
    End Sub

    Private Sub btnAgregarProductoPedido_Click(sender As Object, e As EventArgs) Handles btnAgregarProductoPedido.Click

        txtcantidad.Clear()
        txtNombreProductoPedido.Clear()
        btnGuardarProductosPedido.Enabled = True

        Dim AgregarProductos = New SeleccionarProductosForm(Me)
        AgregarProductos.idProveedor = cbProveedor.SelectedValue
        AgregarProductos.Show()


    End Sub

    Private Sub DetallesPedidoTable_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DetallesPedidoTable.CellMouseClick
        If (e.RowIndex > -1) Then
            DetallesPedidoTable.CurrentRow.Selected = True
            txtNombreProductoPedido.Text = DetallesPedidoTable.Rows(e.RowIndex).Cells(1).FormattedValue.ToString()
            txtcantidad.Text = DetallesPedidoTable.Rows(e.RowIndex).Cells(2).FormattedValue.ToString()
            btnActualizarProductoPedido.Enabled = True
            btnBorrarProductoPedido.Enabled = True
            btnGuardarProductosPedido.Enabled = True

        End If
    End Sub

    Private Sub btnBorrarProductoPedido_Click(sender As Object, e As EventArgs) Handles btnBorrarProductoPedido.Click
        DetallesPedidoTable.Rows.Remove(DetallesPedidoTable.CurrentRow)
        btnActualizarProductoPedido.Enabled = False
        btnBorrarProductoPedido.Enabled = False
        txtcantidad.Clear()
        txtNombreProductoPedido.Clear()

    End Sub

    Private Sub btnActualizarProductoPedido_Click(sender As Object, e As EventArgs) Handles btnActualizarProductoPedido.Click
        Try
            DetallesPedidoTable.CurrentRow.Cells(2).Value = txtcantidad.Text
            txtcantidad.Clear()
            txtNombreProductoPedido.Clear()
        Catch
            MessageBox.Show("Se debe seleccionar una fila", "ERROR! Seleccion de fila necesaria")
        End Try

    End Sub

    Private Sub btnGuardarProductosPedido_Click(sender As Object, e As EventArgs) Handles btnGuardarProductosPedido.Click

        If cbProveedor.SelectedIndex <> -1 AndAlso DetallesPedidoTable.RowCount > 0 Then
            Dim query As String
            Dim query2 As String
            Dim where As String = ""
            Dim lista As String ' = DetallesPedidoTable.Rows.Count
            Dim contador = 0
            Try

                For row As Integer = 0 To DetallesPedidoTable.Rows.Count - 1

                    Dim idproducto = DetallesPedidoTable.Rows(row).Cells(0).Value.ToString()
                    Dim Cantidad = DetallesPedidoTable.Rows(row).Cells(2).Value.ToString()
                    Dim detallesPedido = DetallesPedidoTable.Rows(row).Cells(3).Value.ToString()
                    Dim Pedido_idPedido = id_pedidos

                    'VERIFICAR SI YA HAY PRODUCTOS EN EL PEDIDO PARA ACTUALIZARLOS
                    Try
                        Dim sql = "SELECT * FROM DetallesPedido WHERE idDetallesPedido = " & detallesPedido
                        Dim Rsdatos = Seleccion_de_datos(sql)
                        lista = Rsdatos.Tables("DATOS").Rows.Count
                        If lista <> 0 Then
                            query = "UPDATE DetallesPedido SET Cantidad = " & Cantidad & " WHERE idDetallesPedido = " & detallesPedido
                            If (contador = 0) Then
                                contador = 1
                                where = where & " Pedido_idPedido = " & Pedido_idPedido & " AND idDetallesPedido <> " & detallesPedido
                            Else
                                where = where & " AND idDetallesPedido <> " & detallesPedido
                            End If

                        Else
                            query = "INSERT INTO DetallesPedido (Producto_idProducto,Cantidad,Pedido_idPedido) 
                            VALUES(" & idproducto & "," & Cantidad & "," & Pedido_idPedido & ")"

                        End If

                        Ejecutar_Query(query)
                        Conexion.Close()

                    Catch ex As Exception
                        MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
                    End Try

                Next

                If lista <> 0 Then
                    Try
                        query2 = "DELETE FROM DetallesPedido WHERE " & where
                        Ejecutar_Query(query2)
                    Catch ex As Exception
                        MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
                    End Try

                End If


                MessageBox.Show("Se ha actualizado  el pedido", "Pedido Actualizado")
                DetallesPedidoTable.ClearSelection()
                DetallesPedidoTable.DataSource = Nothing

            Catch ex As Exception

            End Try

        Else
            MessageBox.Show("Favor de indicar el ID del Proveedor e ingrese un producto a la lista de pedidos")
        End If


    End Sub

    Function obtenerNuevoIdProducto()

        Dim sql As String
        Dim lista As String
        Dim NewID As String

        Try
            sql = "SELECT max(idProducto) + 1 as IDPdcto FROM Producto"
            Dim Rsdatos = Seleccion_de_datos(sql)

            lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                NewID = Rsdatos.Tables("DATOS").Rows(0).Item("IDPdcto")
                txtidPdcto.Text = NewID
            End If

            Conexion.Close()


        Catch ex As Exception
            MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

    Function llenarTablaProducto()

        Dim sql As String
        Dim lista As String
        sql = "Select * From Producto"

        Try
            Dim Rsdatos = Seleccion_de_datos(sql)
            lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                TableProductos.DataSource = Rsdatos.Tables(0)

            End If
            Conexion.Close()

        Catch ex As Exception
            MsgBox("Error de inicio de sesión, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

    Function llenarCBCat()

        Dim sql As String
        sql = "Select * From Categoria"

        Try
            Dim Rsdatos = Seleccion_de_datos(sql)


            Dim lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                CBCat.DataSource = Rsdatos.Tables("DATOS")
                CBCat.ValueMember = "idCategoria"
                CBCat.DisplayMember = "Nombre"
                CBCat.SelectedIndex = -1

            End If
            Conexion.Close()

        Catch ex As Exception
            MsgBox("Error de inicio de sesión, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

    Function llenarCBProveedor()

        Dim sql As String
        sql = "Select * From Proveedor"

        Try
            Dim Rsdatos = Seleccion_de_datos(sql)


            Dim lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                CBPdcto_Prov.DataSource = Rsdatos.Tables("DATOS")
                CBPdcto_Prov.ValueMember = "idProveedor"
                CBPdcto_Prov.DisplayMember = "Nombre"
                CBPdcto_Prov.SelectedIndex = -1

            End If
            Conexion.Close()

        Catch ex As Exception
            MsgBox("Error de inicio de sesión, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

    Private Sub btnNewPdcto_Click(sender As Object, e As EventArgs) Handles btnNewPdcto.Click
        txtidPdcto.Clear()
        txtNombrePdcto.Clear()
        txtDescPdcto.Clear()
        txtstockPdcto.Clear()
        txtCunitPdcto.Clear()
        txtPdescuentoPdcto.Clear()
        txtBuscarPdcto.Clear()
        CBactive.SelectedIndex = -1
        CBCat.SelectedIndex = -1
        CBPdcto_Prov.SelectedIndex = -1
        obtenerNuevoIdProducto()
        llenarTablaProducto()
    End Sub

    Private Sub btnAgregarPdcto_Click(sender As Object, e As EventArgs) Handles btnAgregarPdcto.Click
        If txtNombrePdcto.Text.Trim.Length > 0 And txtDescPdcto.Text.Trim.Length > 0 And txtstockPdcto.Text.Trim.Length > 0 And txtCunitPdcto.Text.Trim.Length > 0 And txtPdescuentoPdcto.Text.Trim.Length > 0 And CBactive.SelectedIndex <> -1 And CBCat.SelectedIndex <> -1 And CBPdcto_Prov.SelectedIndex <> -1 Then
            Dim query As String
            Dim nombre = txtNombrePdcto.Text
            Dim desc = txtDescPdcto.Text
            Dim stock = txtstockPdcto.Text
            Dim precio_unit = txtCunitPdcto.Text
            Dim precio_descuen = txtPdescuentoPdcto.Text
            Dim desc_status = CBactive.SelectedValue
            If desc_status = "SI" Then
                desc_status = 1
            Else
                desc_status = 0
            End If
            Dim cat = CBCat.SelectedValue
            Dim prov = CBPdcto_Prov.SelectedValue
            Dim mytimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

            Try
                query = "INSERT INTO Producto (Nombre, Descripcion, Stock, Precio_Unitario, Precio_Descuento, DescuentoEnable, DateCreated ,Categoria_idCategoria, Proveedor_idProveedor) values
                                        ('" & nombre & "','" & desc & "','" & stock & "','" & precio_unit & "','" & precio_descuen & "','" & desc_status & "','" & mytimestamp & "','" & cat & "','" & prov & "')"
                Ejecutar_Query(query)
                btnNewPdcto_Click(sender, e)
                MsgBox("Producto registrado exitosamente")

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
        Else
            MsgBox("Se deben llenar todos los campos")
        End If
    End Sub

    Private Sub Bt_uppdctolist_Click(sender As Object, e As EventArgs) Handles Bt_uppdctolist.Click
        llenarCBCat()
        llenarCBProveedor()
    End Sub

    Private Sub btnUpdatePdcto_Click(sender As Object, e As EventArgs) Handles btnUpdatePdcto.Click

        If txtNombrePdcto.Text.Trim.Length > 0 And txtDescPdcto.Text.Trim.Length > 0 And txtstockPdcto.Text.Trim.Length > 0 And txtCunitPdcto.Text.Trim.Length > 0 And txtPdescuentoPdcto.Text.Trim.Length > 0 And CBactive.SelectedIndex <> -1 And CBCat.SelectedIndex <> -1 And CBPdcto_Prov.SelectedIndex <> -1 Then
            Dim query As String
            Dim nombre = txtNombrePdcto.Text
            Dim desc = txtDescPdcto.Text
            Dim stock = txtstockPdcto.Text
            Dim precio_unit = txtCunitPdcto.Text
            Dim precio_descuen = txtPdescuentoPdcto.Text
            Dim desc_status = CBactive.Text
            If desc_status = "SI" Then
                desc_status = 1
            Else
                desc_status = 0
            End If
            Dim cat = CBCat.SelectedValue
            Dim prov = CBPdcto_Prov.SelectedValue
            Dim mytimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

            Try

                query = "UPDATE Producto SET
                              Nombre ='" & nombre & "',
                              Descripcion ='" & desc & "',
                              Stock ='" & stock & "',
                              Precio_Unitario ='" & precio_unit & "',
                              Precio_Descuento ='" & precio_descuen & "',
                              DescuentoEnable ='" & desc_status & "', 
                              DateCreated ='" & mytimestamp & "',
                              Categoria_idCategoria ='" & cat & "' ,
                              Proveedor_idProveedor ='" & prov & "' 
                              WHERE idProducto = '" & txtidPdcto.Text & "'"
                MsgBox("tu consulta es:  " & query)
                Ejecutar_Query(query)
                btnNewPdcto_Click(sender, e)
                MsgBox("Producto Actualizado")

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
            Conexion.Close()

        Else
            MsgBox("Se deben llenar todos los campos")
        End If
    End Sub

    Private Sub btnSearchPdcto_Click(sender As Object, e As EventArgs) Handles btnSearchPdcto.Click, Button8.Click, Button12.Click
        If txtBuscarPdcto.Text <> "" Then
            Dim NombrePdcto = txtBuscarPdcto.Text
            Dim sql = "Select * From Producto WHERE nombre LIKE '%" & NombrePdcto & "%'  OR Descripcion LIKE '%" & NombrePdcto & "%'"

            Try
                Dim Rsdatos = Seleccion_de_datos(sql)
                Dim lista = Rsdatos.Tables("DATOS").Rows.Count

                If lista <> 0 Then
                    TableProductos.DataSource = Rsdatos.Tables(0)
                    'Si se encuentra un resultado, seleccionar
                    If TableProductos.SelectedCells.Count > 0 Then
                        TableProductos.Rows(0).Selected = True
                        Dim i_rowindex As Integer = TableProductos.SelectedCells(0).RowIndex
                        Dim i_colIndex As Integer = TableProductos.SelectedCells(0).ColumnIndex
                        TableProductos_CellMouseClick(sender, New DataGridViewCellMouseEventArgs(i_colIndex, i_rowindex, 0, 0, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)))
                    End If

                End If
            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try

            Conexion.Close()

        Else
            'MessageBox.Show("Se debe llenar los campos", " Campo vacio")
            btnNewPdcto_Click(sender, e)
        End If
    End Sub

    Private Sub TableProductos_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles TableProductos.CellMouseClick
        If (e.RowIndex > -1) Then
            TableProductos.CurrentRow.Selected = True
            txtidPdcto.Text = TableProductos.Rows(e.RowIndex).Cells("idProducto").FormattedValue.ToString()
            txtNombrePdcto.Text = TableProductos.Rows(e.RowIndex).Cells("Nombre").FormattedValue.ToString()
            txtDescPdcto.Text = TableProductos.Rows(e.RowIndex).Cells("Descripcion").FormattedValue.ToString()
            txtstockPdcto.Text = TableProductos.Rows(e.RowIndex).Cells("Stock").FormattedValue.ToString()
            txtCunitPdcto.Text = TableProductos.Rows(e.RowIndex).Cells("Precio_Unitario").FormattedValue.ToString()
            txtPdescuentoPdcto.Text = TableProductos.Rows(e.RowIndex).Cells("Precio_Descuento").FormattedValue.ToString()
            Dim enable = TableProductos.Rows(e.RowIndex).Cells("DescuentoEnable").FormattedValue.ToString()
            If enable = "1" Then
                CBactive.Text = "SI"
            Else
                CBactive.Text = "NO"
            End If
            CBCat.SelectedValue = TableProductos.Rows(e.RowIndex).Cells("Categoria_idCategoria").FormattedValue.ToString()
            CBPdcto_Prov.SelectedValue = TableProductos.Rows(e.RowIndex).Cells("Proveedor_idProveedor").FormattedValue.ToString()


        End If
    End Sub
    '---------------------------------- INICIO -------------------------------------------------------
    Private Sub btnActivarDescuentos_Click(sender As Object, e As EventArgs) Handles btnActivarDescuentos.Click
        If (cbCategoriaProm.SelectedIndex > -1) Then
            Try
                Dim query = "CALL Descuentos (" & cbCategoriaProm.SelectedValue & ", 'Activar')"
                Ejecutar_Query(query)

                MsgBox("Descuentos activados para los productos en la categoria " & cbCategoriaProm.SelectedText)

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try


        End If
    End Sub

    Private Sub DesactivarDescuentos_Click(sender As Object, e As EventArgs) Handles DesactivarDescuentos.Click
        If (cbCategoriaProm.SelectedIndex > -1) Then
            Try
                Dim query = "CALL Descuentos (" & cbCategoriaProm.SelectedValue & ", 'Desactivar')"

                Ejecutar_Query(query)

                MsgBox("Descuentos desactivados para los productos en la categoria " & cbCategoriaProm.SelectedText)

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try


        End If
    End Sub
    Function llenarCBCatPromo()

        Dim sql As String
        sql = "Select * From Categoria"

        Try
            Dim Rsdatos = Seleccion_de_datos(sql)


            Dim lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                cbCategoriaProm.DataSource = Rsdatos.Tables("DATOS")
                cbCategoriaProm.ValueMember = "idCategoria"
                cbCategoriaProm.DisplayMember = "Nombre"
                cbCategoriaProm.SelectedIndex = -1

            End If
            Conexion.Close()

        Catch ex As Exception
            MsgBox("Error de inicio de sesión, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

    Function obtenerNuevoIdVenta()

        Dim sql As String
        Dim lista As String
        Dim NewID As String

        Try
            sql = "SELECT max(idVenta) + 1 as IDVenta FROM Venta"
            Dim Rsdatos = Seleccion_de_datos(sql)

            lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                NewID = Rsdatos.Tables("DATOS").Rows(0).Item("IDVenta").ToString
                TB_IdVta.Text = NewID
            End If

            Conexion.Close()


        Catch ex As Exception
            MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

    Function llenarCBClientes()

        Dim sql As String
        sql = "Select * From Cliente"

        Try
            Dim Rsdatos = Seleccion_de_datos(sql)


            Dim lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                CB_IdClienteVta.DataSource = Rsdatos.Tables("DATOS")
                CB_IdClienteVta.ValueMember = "idCliente"
                CB_IdClienteVta.DisplayMember = "Nombre"
                CB_IdClienteVta.SelectedIndex = -1

            End If
            Conexion.Close()

        Catch ex As Exception
            MsgBox("Error de inicio de sesión, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

    Function llenarTablaPdctoVenta()

        Dim sql As String
        Dim lista As String
        sql = "SELECT idProducto, Nombre, Stock,  IF(DescuentoEnable = 0, Precio_Unitario, Precio_Descuento) as Precio, IF(DescuentoEnable = 0, 'Sin descuento', 'Con descuento') as Descuento FROM b8hrt3nyyisdb1zuqz9i.Producto"

        Try
            Dim Rsdatos = Seleccion_de_datos(sql)
            lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                DG_PdctoVta.DataSource = Rsdatos.Tables(0)

            End If
            Conexion.Close()

        Catch ex As Exception
            MsgBox("Error de inicio de sesión, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

    Private Sub DG_PdctoVta_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DG_PdctoVta.CellMouseClick
        If (e.RowIndex > -1) Then
            DG_PdctoVta.CurrentRow.Selected = True
            Tb_IdPdcto.Text = DG_PdctoVta.Rows(e.RowIndex).Cells("idProducto").FormattedValue.ToString()
            TB_NombreArtVta.Text = DG_PdctoVta.Rows(e.RowIndex).Cells("Nombre").FormattedValue.ToString()
            Tb_PrecioPdcto.Text = DG_PdctoVta.Rows(e.RowIndex).Cells("Precio").FormattedValue.ToString()
        End If
    End Sub

    Private Sub Tb_cantidadPdcto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tb_cantidadPdcto.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub bt_addPdcto_Click(sender As Object, e As EventArgs) Handles bt_addPdcto.Click
        If Tb_IdPdcto.Text.Trim.Length > 0 And TB_NombreArtVta.Text.Trim.Length > 0 And Tb_PrecioPdcto.Text.Trim.Length > 0 And Tb_cantidadPdcto.Text.Trim.Length > 0 Then

            Dim PrecioTotalPrdctoCant = Val(Tb_cantidadPdcto.Text) * Val(Tb_PrecioPdcto.Text)
            DG_Carrito.Rows.Add(Tb_IdPdcto.Text, TB_NombreArtVta.Text, Tb_cantidadPdcto.Text, PrecioTotalPrdctoCant)


            Tb_IdPdcto.Text = ""
            TB_NombreArtVta.Text = ""
            Tb_PrecioPdcto.Text = ""
            Tb_cantidadPdcto.Text = ""

        Else
            MsgBox("Se deben llenar todos los campos")
        End If

        'Sumar una Columna
        Dim Total As Single
        Dim Col = 3
        For Each row As DataGridViewRow In Me.DG_Carrito.Rows
            Total += Val(row.Cells(Col).Value)
        Next
        Me.TB_SubTotalVta.Text = Total.ToString

        TB_IvaVta.Text = Val(TB_SubTotalVta.Text) * 0.16
        TB_TotalVta.Text = Val(TB_IvaVta.Text) + Val(TB_SubTotalVta.Text)


    End Sub

    Private Sub bt_BorrarVta_Click(sender As Object, e As EventArgs) Handles bt_BorrarVta.Click

        Dim fila = DG_Carrito.CurrentCell.RowIndex.ToString
        DG_Carrito.Rows.RemoveAt(fila)

        'Sumar una Columna
        Dim Total As Single
        Dim Col = 3
        For Each row As DataGridViewRow In Me.DG_Carrito.Rows
            Total += Val(row.Cells(Col).Value)
        Next
        Me.TB_SubTotalVta.Text = Total.ToString

        TB_IvaVta.Text = Val(TB_SubTotalVta.Text) * 0.16
        TB_TotalVta.Text = Val(TB_IvaVta.Text) + Val(TB_SubTotalVta.Text)

    End Sub

    Private Sub bt_Cancel_Click(sender As Object, e As EventArgs) Handles bt_Cancel.Click
        'Borra todo el formulario

    End Sub
End Class
