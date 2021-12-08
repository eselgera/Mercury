<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmpleadosForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableEmpleados = New System.Windows.Forms.DataGridView()
        Me.btnSearchEmpleado = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnUpdateEmpleado = New System.Windows.Forms.Button()
        Me.btnAgregarEmpleado = New System.Windows.Forms.Button()
        Me.btnNewEmpleado = New System.Windows.Forms.Button()
        Me.txtBuscarEmpleado = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtidEmpleado = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtUserEmpleado = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTelefonoEmpleado = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtApEmpleado = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombreEmpleado = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPassEmpleado = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbEstatus = New System.Windows.Forms.ComboBox()
        Me.cbRol = New System.Windows.Forms.ComboBox()
        Me.txtCorreoEmpleado = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.TableEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableEmpleados
        '
        Me.TableEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableEmpleados.Location = New System.Drawing.Point(10, 220)
        Me.TableEmpleados.Margin = New System.Windows.Forms.Padding(2)
        Me.TableEmpleados.MultiSelect = False
        Me.TableEmpleados.Name = "TableEmpleados"
        Me.TableEmpleados.ReadOnly = True
        Me.TableEmpleados.RowTemplate.Height = 24
        Me.TableEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TableEmpleados.Size = New System.Drawing.Size(766, 193)
        Me.TableEmpleados.TabIndex = 0
        '
        'btnSearchEmpleado
        '
        Me.btnSearchEmpleado.Location = New System.Drawing.Point(508, 185)
        Me.btnSearchEmpleado.Name = "btnSearchEmpleado"
        Me.btnSearchEmpleado.Size = New System.Drawing.Size(101, 25)
        Me.btnSearchEmpleado.TabIndex = 20
        Me.btnSearchEmpleado.Text = "Buscar"
        Me.btnSearchEmpleado.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnUpdateEmpleado)
        Me.GroupBox2.Controls.Add(Me.btnAgregarEmpleado)
        Me.GroupBox2.Controls.Add(Me.btnNewEmpleado)
        Me.GroupBox2.Location = New System.Drawing.Point(620, 34)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(156, 176)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        '
        'btnUpdateEmpleado
        '
        Me.btnUpdateEmpleado.Location = New System.Drawing.Point(9, 109)
        Me.btnUpdateEmpleado.Name = "btnUpdateEmpleado"
        Me.btnUpdateEmpleado.Size = New System.Drawing.Size(141, 30)
        Me.btnUpdateEmpleado.TabIndex = 2
        Me.btnUpdateEmpleado.Text = "Actualizar"
        Me.btnUpdateEmpleado.UseVisualStyleBackColor = True
        '
        'btnAgregarEmpleado
        '
        Me.btnAgregarEmpleado.Location = New System.Drawing.Point(9, 72)
        Me.btnAgregarEmpleado.Name = "btnAgregarEmpleado"
        Me.btnAgregarEmpleado.Size = New System.Drawing.Size(141, 30)
        Me.btnAgregarEmpleado.TabIndex = 1
        Me.btnAgregarEmpleado.Text = "Agregar"
        Me.btnAgregarEmpleado.UseVisualStyleBackColor = True
        '
        'btnNewEmpleado
        '
        Me.btnNewEmpleado.Location = New System.Drawing.Point(9, 36)
        Me.btnNewEmpleado.Name = "btnNewEmpleado"
        Me.btnNewEmpleado.Size = New System.Drawing.Size(141, 30)
        Me.btnNewEmpleado.TabIndex = 0
        Me.btnNewEmpleado.Text = "Nuevo"
        Me.btnNewEmpleado.UseVisualStyleBackColor = True
        '
        'txtBuscarEmpleado
        '
        Me.txtBuscarEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscarEmpleado.Location = New System.Drawing.Point(64, 188)
        Me.txtBuscarEmpleado.Name = "txtBuscarEmpleado"
        Me.txtBuscarEmpleado.Size = New System.Drawing.Size(425, 22)
        Me.txtBuscarEmpleado.TabIndex = 40
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 16)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Buscar"
        '
        'txtidEmpleado
        '
        Me.txtidEmpleado.Enabled = False
        Me.txtidEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtidEmpleado.Location = New System.Drawing.Point(82, 40)
        Me.txtidEmpleado.Name = "txtidEmpleado"
        Me.txtidEmpleado.ReadOnly = True
        Me.txtidEmpleado.Size = New System.Drawing.Size(80, 22)
        Me.txtidEmpleado.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(25, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 16)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "ID"
        '
        'txtUserEmpleado
        '
        Me.txtUserEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserEmpleado.Location = New System.Drawing.Point(440, 62)
        Me.txtUserEmpleado.Name = "txtUserEmpleado"
        Me.txtUserEmpleado.Size = New System.Drawing.Size(169, 22)
        Me.txtUserEmpleado.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(350, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 16)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Usuario"
        '
        'txtTelefonoEmpleado
        '
        Me.txtTelefonoEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefonoEmpleado.Location = New System.Drawing.Point(82, 121)
        Me.txtTelefonoEmpleado.Name = "txtTelefonoEmpleado"
        Me.txtTelefonoEmpleado.Size = New System.Drawing.Size(230, 22)
        Me.txtTelefonoEmpleado.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(25, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 16)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Telefono"
        '
        'txtApEmpleado
        '
        Me.txtApEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApEmpleado.Location = New System.Drawing.Point(82, 93)
        Me.txtApEmpleado.Name = "txtApEmpleado"
        Me.txtApEmpleado.Size = New System.Drawing.Size(230, 22)
        Me.txtApEmpleado.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(25, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 16)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Apellido"
        '
        'txtNombreEmpleado
        '
        Me.txtNombreEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreEmpleado.Location = New System.Drawing.Point(82, 64)
        Me.txtNombreEmpleado.Name = "txtNombreEmpleado"
        Me.txtNombreEmpleado.Size = New System.Drawing.Size(230, 22)
        Me.txtNombreEmpleado.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(25, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 16)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Nombre"
        '
        'txtPassEmpleado
        '
        Me.txtPassEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassEmpleado.Location = New System.Drawing.Point(440, 86)
        Me.txtPassEmpleado.Name = "txtPassEmpleado"
        Me.txtPassEmpleado.Size = New System.Drawing.Size(169, 22)
        Me.txtPassEmpleado.TabIndex = 26
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(350, 91)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 16)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Contraseña"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(350, 119)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 16)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "Rol"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(350, 145)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 16)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Estatus"
        '
        'cbEstatus
        '
        Me.cbEstatus.DisplayMember = "id"
        Me.cbEstatus.FormattingEnabled = True
        Me.cbEstatus.Items.AddRange(New Object() {"Baja", "Activo"})
        Me.cbEstatus.Location = New System.Drawing.Point(440, 139)
        Me.cbEstatus.Margin = New System.Windows.Forms.Padding(2)
        Me.cbEstatus.Name = "cbEstatus"
        Me.cbEstatus.Size = New System.Drawing.Size(169, 21)
        Me.cbEstatus.TabIndex = 28
        Me.cbEstatus.ValueMember = "id"
        '
        'cbRol
        '
        Me.cbRol.FormattingEnabled = True
        Me.cbRol.Location = New System.Drawing.Point(440, 113)
        Me.cbRol.Margin = New System.Windows.Forms.Padding(2)
        Me.cbRol.Name = "cbRol"
        Me.cbRol.Size = New System.Drawing.Size(169, 21)
        Me.cbRol.TabIndex = 27
        '
        'txtCorreoEmpleado
        '
        Me.txtCorreoEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorreoEmpleado.Location = New System.Drawing.Point(82, 151)
        Me.txtCorreoEmpleado.Name = "txtCorreoEmpleado"
        Me.txtCorreoEmpleado.Size = New System.Drawing.Size(230, 22)
        Me.txtCorreoEmpleado.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(25, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 16)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Correo"
        '
        'EmpleadosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(794, 419)
        Me.Controls.Add(Me.txtCorreoEmpleado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbRol)
        Me.Controls.Add(Me.cbEstatus)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtPassEmpleado)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtidEmpleado)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtUserEmpleado)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTelefonoEmpleado)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtApEmpleado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNombreEmpleado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSearchEmpleado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtBuscarEmpleado)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TableEmpleados)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "EmpleadosForm"
        Me.Text = "EmpleadosForm"
        CType(Me.TableEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableEmpleados As DataGridView
    Friend WithEvents btnSearchEmpleado As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnUpdateEmpleado As Button
    Friend WithEvents btnAgregarEmpleado As Button
    Friend WithEvents btnNewEmpleado As Button
    Friend WithEvents txtBuscarEmpleado As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtidEmpleado As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtUserEmpleado As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTelefonoEmpleado As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtApEmpleado As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNombreEmpleado As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPassEmpleado As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cbEstatus As ComboBox
    Friend WithEvents cbRol As ComboBox
    Friend WithEvents txtCorreoEmpleado As TextBox
    Friend WithEvents Label4 As Label
End Class
