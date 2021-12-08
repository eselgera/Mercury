<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RolesForm
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
        Me.txtidRol = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombreRol = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSearchRol = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnUpdateRol = New System.Windows.Forms.Button()
        Me.btnAgregarRol = New System.Windows.Forms.Button()
        Me.btnNewRol = New System.Windows.Forms.Button()
        Me.txtBuscarRol = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TableRoles = New System.Windows.Forms.DataGridView()
        Me.txtApRol = New System.Windows.Forms.TextBox()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TableRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtidRol
        '
        Me.txtidRol.Enabled = False
        Me.txtidRol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtidRol.Location = New System.Drawing.Point(112, 30)
        Me.txtidRol.Name = "txtidRol"
        Me.txtidRol.ReadOnly = True
        Me.txtidRol.Size = New System.Drawing.Size(80, 22)
        Me.txtidRol.TabIndex = 50
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(16, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 16)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Descripcion"
        '
        'txtNombreRol
        '
        Me.txtNombreRol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreRol.Location = New System.Drawing.Point(112, 58)
        Me.txtNombreRol.Name = "txtNombreRol"
        Me.txtNombreRol.Size = New System.Drawing.Size(179, 22)
        Me.txtNombreRol.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 16)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Nombre"
        '
        'btnSearchRol
        '
        Me.btnSearchRol.Location = New System.Drawing.Point(307, 179)
        Me.btnSearchRol.Name = "btnSearchRol"
        Me.btnSearchRol.Size = New System.Drawing.Size(101, 25)
        Me.btnSearchRol.TabIndex = 44
        Me.btnSearchRol.Text = "Buscar"
        Me.btnSearchRol.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnUpdateRol)
        Me.GroupBox2.Controls.Add(Me.btnAgregarRol)
        Me.GroupBox2.Controls.Add(Me.btnNewRol)
        Me.GroupBox2.Location = New System.Drawing.Point(297, 30)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(111, 129)
        Me.GroupBox2.TabIndex = 43
        Me.GroupBox2.TabStop = False
        '
        'btnUpdateRol
        '
        Me.btnUpdateRol.Location = New System.Drawing.Point(6, 88)
        Me.btnUpdateRol.Name = "btnUpdateRol"
        Me.btnUpdateRol.Size = New System.Drawing.Size(98, 30)
        Me.btnUpdateRol.TabIndex = 2
        Me.btnUpdateRol.Text = "Actualizar"
        Me.btnUpdateRol.UseVisualStyleBackColor = True
        '
        'btnAgregarRol
        '
        Me.btnAgregarRol.Location = New System.Drawing.Point(6, 51)
        Me.btnAgregarRol.Name = "btnAgregarRol"
        Me.btnAgregarRol.Size = New System.Drawing.Size(98, 30)
        Me.btnAgregarRol.TabIndex = 1
        Me.btnAgregarRol.Text = "Agregar"
        Me.btnAgregarRol.UseVisualStyleBackColor = True
        '
        'btnNewRol
        '
        Me.btnNewRol.Location = New System.Drawing.Point(6, 15)
        Me.btnNewRol.Name = "btnNewRol"
        Me.btnNewRol.Size = New System.Drawing.Size(98, 30)
        Me.btnNewRol.TabIndex = 0
        Me.btnNewRol.Text = "Nuevo"
        Me.btnNewRol.UseVisualStyleBackColor = True
        '
        'txtBuscarRol
        '
        Me.txtBuscarRol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscarRol.Location = New System.Drawing.Point(65, 181)
        Me.txtBuscarRol.Name = "txtBuscarRol"
        Me.txtBuscarRol.Size = New System.Drawing.Size(236, 22)
        Me.txtBuscarRol.TabIndex = 51
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(9, 183)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 16)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Buscar"
        '
        'TableRoles
        '
        Me.TableRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableRoles.Location = New System.Drawing.Point(11, 213)
        Me.TableRoles.Margin = New System.Windows.Forms.Padding(2)
        Me.TableRoles.MultiSelect = False
        Me.TableRoles.Name = "TableRoles"
        Me.TableRoles.ReadOnly = True
        Me.TableRoles.RowTemplate.Height = 24
        Me.TableRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TableRoles.Size = New System.Drawing.Size(397, 193)
        Me.TableRoles.TabIndex = 41
        '
        'txtApRol
        '
        Me.txtApRol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApRol.Location = New System.Drawing.Point(112, 87)
        Me.txtApRol.Multiline = True
        Me.txtApRol.Name = "txtApRol"
        Me.txtApRol.Size = New System.Drawing.Size(179, 72)
        Me.txtApRol.TabIndex = 46
        '
        'RolesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(427, 417)
        Me.Controls.Add(Me.txtidRol)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtApRol)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNombreRol)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSearchRol)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtBuscarRol)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TableRoles)
        Me.Name = "RolesForm"
        Me.Text = "Roles"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.TableRoles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtidRol As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNombreRol As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSearchRol As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnUpdateRol As Button
    Friend WithEvents btnAgregarRol As Button
    Friend WithEvents btnNewRol As Button
    Friend WithEvents txtBuscarRol As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TableRoles As DataGridView
    Friend WithEvents txtApRol As TextBox
End Class
