Public Class SeleccionarProductosForm

    Private fgrid As New Form1
    Public Sub New(ByVal fg As Form1)
        InitializeComponent()
        Me.fgrid = fg
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If idproducto <> "" Then


            Dim dt As DataTable = DirectCast(fgrid.DetallesPedidoTable.DataSource, DataTable)

            Dim row As DataRow = dt.NewRow()

            row("idProducto") = idproducto
            row("Producto") = nombreProducto
            row("Cantidad") = 5
            row("idDetallesPedido") = 0


            dt.Rows.Add(row)

            fgrid.DetallesPedidoTable.DataSource = dt



            Me.Close()
        Else
            MsgBox("Seleccionar un producto")
        End If

        '-

        '-

    End Sub


    Private Sub SeleccionarProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarTablaProductos()
    End Sub

    Public idProveedor
    Public idproducto
    Public nombreProducto

    Function llenarTablaProductos()

        Dim sql As String
        Dim lista As String

        sql = "Select idProducto, Nombre From Producto Where Proveedor_idProveedor = " & idProveedor
        Try
            Dim Rsdatos = Seleccion_de_datos(sql)

            lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                TableProductos.DataSource = Rsdatos.Tables(0)
                AjustarTabla()

            End If

            Conexion.Close()

        Catch ex As Exception
            MsgBox("Error de inicio de sesión, favor de reportar al administrador" & ex.Message)
        End Try

    End Function


    Function AjustarTabla()
        TableProductos.Columns(0).Visible = False
        TableProductos.Columns(1).Width = 250


    End Function

    Private Sub TableProductos_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles TableProductos.CellMouseClick
        idproducto = TableProductos.Rows(e.RowIndex).Cells("idProducto").FormattedValue.ToString()
        nombreProducto = TableProductos.Rows(e.RowIndex).Cells("Nombre").FormattedValue.ToString()
    End Sub
End Class