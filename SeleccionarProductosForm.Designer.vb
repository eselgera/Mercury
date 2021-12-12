<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SeleccionarProductosForm
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
        Me.TableProductos = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.TableProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableProductos
        '
        Me.TableProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableProductos.Location = New System.Drawing.Point(12, 21)
        Me.TableProductos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableProductos.MultiSelect = False
        Me.TableProductos.Name = "TableProductos"
        Me.TableProductos.ReadOnly = True
        Me.TableProductos.RowTemplate.Height = 24
        Me.TableProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TableProductos.Size = New System.Drawing.Size(396, 594)
        Me.TableProductos.TabIndex = 42
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(12, 634)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(396, 44)
        Me.Button1.TabIndex = 43
        Me.Button1.Text = "Agregar al Pedido"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SeleccionarProductosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(420, 694)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TableProductos)
        Me.Name = "SeleccionarProductosForm"
        Me.Text = "SeleccionarProductos"
        CType(Me.TableProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableProductos As DataGridView
    Friend WithEvents Button1 As Button
End Class
