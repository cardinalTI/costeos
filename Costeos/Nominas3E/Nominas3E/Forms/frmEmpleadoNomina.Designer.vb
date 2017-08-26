<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpleadoNomina
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvNominaEmpleado = New System.Windows.Forms.DataGridView()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nomina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Empleado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreEmpleado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoNomina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCalculo = New System.Windows.Forms.Button()
        CType(Me.dgvNominaEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvNominaEmpleado
        '
        Me.dgvNominaEmpleado.AllowUserToAddRows = False
        Me.dgvNominaEmpleado.AllowUserToDeleteRows = False
        Me.dgvNominaEmpleado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvNominaEmpleado.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvNominaEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNominaEmpleado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cliente, Me.Nomina, Me.Empleado, Me.NombreEmpleado, Me.Mes, Me.NoNomina, Me.MontoH, Me.MontoIAS})
        Me.dgvNominaEmpleado.Location = New System.Drawing.Point(2, 2)
        Me.dgvNominaEmpleado.Name = "dgvNominaEmpleado"
        Me.dgvNominaEmpleado.ReadOnly = True
        Me.dgvNominaEmpleado.Size = New System.Drawing.Size(941, 431)
        Me.dgvNominaEmpleado.TabIndex = 0
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.MinimumWidth = 150
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 150
        '
        'Nomina
        '
        Me.Nomina.HeaderText = "Nomina"
        Me.Nomina.MinimumWidth = 120
        Me.Nomina.Name = "Nomina"
        Me.Nomina.ReadOnly = True
        Me.Nomina.Width = 120
        '
        'Empleado
        '
        Me.Empleado.HeaderText = "Empleado"
        Me.Empleado.MinimumWidth = 80
        Me.Empleado.Name = "Empleado"
        Me.Empleado.ReadOnly = True
        Me.Empleado.Width = 80
        '
        'NombreEmpleado
        '
        Me.NombreEmpleado.HeaderText = "Nombre Empleado"
        Me.NombreEmpleado.MinimumWidth = 150
        Me.NombreEmpleado.Name = "NombreEmpleado"
        Me.NombreEmpleado.ReadOnly = True
        Me.NombreEmpleado.Width = 150
        '
        'Mes
        '
        Me.Mes.HeaderText = "Mes"
        Me.Mes.MinimumWidth = 80
        Me.Mes.Name = "Mes"
        Me.Mes.ReadOnly = True
        Me.Mes.Width = 80
        '
        'NoNomina
        '
        Me.NoNomina.HeaderText = "No. Nomina"
        Me.NoNomina.MinimumWidth = 80
        Me.NoNomina.Name = "NoNomina"
        Me.NoNomina.ReadOnly = True
        Me.NoNomina.Width = 80
        '
        'MontoH
        '
        Me.MontoH.HeaderText = "Monto Haberes"
        Me.MontoH.MinimumWidth = 100
        Me.MontoH.Name = "MontoH"
        Me.MontoH.ReadOnly = True
        '
        'MontoIAS
        '
        Me.MontoIAS.HeaderText = "Monto IAS"
        Me.MontoIAS.MinimumWidth = 100
        Me.MontoIAS.Name = "MontoIAS"
        Me.MontoIAS.ReadOnly = True
        '
        'btnCalculo
        '
        Me.btnCalculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalculo.Location = New System.Drawing.Point(691, 440)
        Me.btnCalculo.Name = "btnCalculo"
        Me.btnCalculo.Size = New System.Drawing.Size(239, 23)
        Me.btnCalculo.TabIndex = 1
        Me.btnCalculo.Text = "Calculo Piramidador"
        Me.btnCalculo.UseVisualStyleBackColor = True
        '
        'frmEmpleadoNomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 475)
        Me.Controls.Add(Me.btnCalculo)
        Me.Controls.Add(Me.dgvNominaEmpleado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmEmpleadoNomina"
        Me.Text = "Nominas"
        CType(Me.dgvNominaEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvNominaEmpleado As System.Windows.Forms.DataGridView
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nomina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Empleado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreEmpleado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoNomina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontoH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontoIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCalculo As System.Windows.Forms.Button
End Class
