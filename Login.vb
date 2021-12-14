Imports System.Runtime.InteropServices

Public Class Login
    Public Property Nombre As String
    Public Property ID_Usario As String
    Public Property Acceso As String

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Button2_acceder_Click(sender As Object, e As EventArgs) Handles Button2_acceder.Click


        If TextBox1_user.Text <> "" And TextBox2_pass.Text <> "" Then
            Dim Usuario = TextBox1_user.Text
            Dim sql = "Select Password, Nombre, Rol_idRol, idEmpleado, UserEnable From Empleado WHERE Username = '" & TextBox1_user.Text & "'"

            Try
                Dim Rsdatos = Seleccion_de_datos(sql)
                Dim lista = Rsdatos.Tables("DATOS").Rows.Count
                Dim pass As String
                Dim active_disable As Integer

                If lista <> 0 Then
                    pass = Rsdatos.Tables("DATOS").Rows(0).Item("Password")
                    Nombre = Rsdatos.Tables("DATOS").Rows(0).Item("Nombre")
                    Acceso = Rsdatos.Tables("DATOS").Rows(0).Item("Rol_idRol")
                    ID_Usario = Rsdatos.Tables("DATOS").Rows(0).Item("idEmpleado")
                    active_disable = Rsdatos.Tables("DATOS").Rows(0).Item("UserEnable")
                End If

                If active_disable = 0 Then
                    MessageBox.Show("El usario esta deshabilitado ", " No podrá acceder")
                    Return
                End If

                If pass = TextBox2_pass.Text Then
                    ControlForm()
                    Me.Close()
                Else
                    MessageBox.Show("El usario o contraseña son incorrectos ", " Error de autenticación")
                End If

            Catch ex As Exception
                MsgBox("Error del Sistema, favor de reportar al administrador" & ex.Message)
            End Try

            Conexion.Close()
        Else
            MessageBox.Show("Ha surgido un problema", " Contacte al administrador")
        End If
    End Sub

    Private Sub TextBox2_pass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2_pass.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If TextBox1_user.Text <> "" And TextBox2_pass.Text <> "" Then
                Button2_acceder_Click(sender, e)
            Else
                MessageBox.Show("Capture los campos de Nombre y Contraseña", " Infomración faltante")
                Return
            End If
        End If
    End Sub

    Private Sub TextBox1_user_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1_user.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            If TextBox1_user.Text <> "" And TextBox2_pass.Text <> "" Then
                Button2_acceder_Click(sender, e)
            Else
                MessageBox.Show("Capture los campos de Nombre y Contraseña", " Infomración faltante")
                Return
            End If
        End If
    End Sub

    'Esto hace posible el control de accesos por tipo de ROL de usuario
    Function ControlForm()
        Dim Form = New Form1()
        Form.Show()
        Form.Label9_Nombre.Text = Nombre
        Form.lb_IdEmpleado.Text = ID_Usario
        Form.TB_EmpVta.Text = Nombre

        Select Case Acceso
            Case 1
                'Acceso libre
            Case 2
                ' Deja solo los tab de ventanas activos
                Form.EmpleadosToolStripMenuItem.Enabled = False
                Form.PedidosToolStripMenuItem.Enabled = False
                Form.TabPage3.Enabled = False
            Case 3
                ' Deja solo los tab de Almacen activos
                Form.EmpleadosToolStripMenuItem.Enabled = False
                Form.VentasToolStripMenuItem.Enabled = False
                Form.ClientesToolStripMenuItem.Enabled = False
                'Form.TabPage2.Enabled = False 'Por alguna razon desconocida genera error  
                Form.TabPage1.Enabled = False
            Case 4
                ' Deja solo los tab de RH activos
                Form.VentasToolStripMenuItem.Enabled = False
                Form.ProductosToolStripMenuItem.Enabled = False
                Form.PedidosToolStripMenuItem.Enabled = False
                Form.TabPage1.Enabled = False
                Form.TabPage7.Enabled = False
                Form.TabPage5.Enabled = False
                Form.TabPage3.Enabled = False
                Form.TabPage6.Enabled = False
        End Select

    End Function
End Class