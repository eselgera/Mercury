Public Class RolesForm
    Private Sub Roles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        obtenerNuevoIdRol()
        llenarTablaRoles()

    End Sub
    Private Sub btnNewRol_Click(sender As Object, e As EventArgs) Handles btnNewRol.Click
        txtidRol.Clear()
        txtNombreRol.Clear()
        txtApRol.Clear()
        txtBuscarRol.Clear()

        obtenerNuevoIdRol()
        llenarTablaRoles()
    End Sub
    Private Sub btnAgregarRol_Click(sender As Object, e As EventArgs) Handles btnAgregarRol.Click
        If txtNombreRol.Text.Trim.Length > 0 And txtApRol.Text.Trim.Length > 0 Then
            Dim query As String
            Dim nombre = txtNombreRol.Text
            Dim desc = txtApRol.Text

            Try
                query = "INSERT INTO Rol (Nombre,Descripcion)values('" & nombre & "','" & desc & "' )"
                Ejecutar_Query(query)

                btnNewRol_Click(sender, e)
                MsgBox("Rol registrado exitosamente")

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
            Conexion.Close()
        Else
            MsgBox("Se deben llenar todos los campos")
        End If

    End Sub
    Private Sub btnUpdateRol_Click(sender As Object, e As EventArgs) Handles btnUpdateRol.Click
        If txtNombreRol.Text.Trim.Length > 0 And txtApRol.Text.Trim.Length > 0 Then
            Dim query As String
            Dim nombre = txtNombreRol.Text
            Dim desc = txtApRol.Text

            Try
                query = "UPDATE Rol SET
                              Nombre ='" & nombre & "',
                              Descripcion ='" & desc & "'
                              WHERE idRol = '" & txtidRol.Text & "'"

                Ejecutar_Query(query)
                btnNewRol_Click(sender, e)
                MsgBox("Rol Actualizado")

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try
            Conexion.Close()
        Else
            MsgBox("Se deben llenar todos los campos")
        End If
    End Sub

    'Metodo para obtener el siguiente ID cliente por insertar
    Function obtenerNuevoIdRol()

        Dim sql As String
        Dim lista As String
        Dim NewID As String

        Try
            sql = "SELECT count(*)+1 as ID FROM Rol"
            Dim Rsdatos = Seleccion_de_datos(sql)

            lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                NewID = Rsdatos.Tables("DATOS").Rows(0).Item("ID")
                txtidRol.Text = NewID
            End If

            Conexion.Close()


        Catch ex As Exception
            MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
        End Try

    End Function

    Function llenarTablaRoles()

        Dim sql As String
        Dim lista As String
        sql = "Select * From Rol"

        Try
            Dim Rsdatos = Seleccion_de_datos(sql)
            lista = Rsdatos.Tables("DATOS").Rows.Count
            If lista <> 0 Then
                TableRoles.DataSource = Rsdatos.Tables(0)
                AjustarTabla()

            End If
            Conexion.Close()

        Catch ex As Exception
            MsgBox("Error de inicio de sesión, favor de reportar al administrador" & ex.Message)
        End Try

    End Function


    Function AjustarTabla()
        If (TableRoles.RowCount > 0) Then
            TableRoles.Columns(0).Width = 30
            TableRoles.Columns(1).Width = 70
            TableRoles.Columns(2).Width = 252
            TableRoles.Columns(0).HeaderText = "ID"

        End If

    End Function

    Private Sub TableRoles_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles TableRoles.CellMouseClick
        If (e.RowIndex > -1) Then
            TableRoles.CurrentRow.Selected = True
            txtidRol.Text = TableRoles.Rows(e.RowIndex).Cells("idRol").FormattedValue.ToString()
            txtNombreRol.Text = TableRoles.Rows(e.RowIndex).Cells("Nombre").FormattedValue.ToString()
            txtApRol.Text = TableRoles.Rows(e.RowIndex).Cells("Descripcion").FormattedValue.ToString()

        End If
    End Sub

    Private Sub btnSearchRol_Click(sender As Object, e As EventArgs) Handles btnSearchRol.Click

    End Sub
End Class