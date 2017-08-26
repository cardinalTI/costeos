<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHaberesDetalles
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
        Me.components = New System.ComponentModel.Container()
        Me.dgvEmpleadosHaberes = New System.Windows.Forms.DataGridView()
        Me.cmsEmpleado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VerNominasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.label = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nomina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Empleado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreEmpleado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Enero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EneIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Febrero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FebIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marzo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MarIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Abril = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AbrIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mayo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MayIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Junio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JunIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Julio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JulIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Agosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AgoIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Septiembre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SepIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Octubre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OctIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Noviembre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NovIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Diciembre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DicIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalHaberes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvEmpleadosHaberes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsEmpleado.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvEmpleadosHaberes
        '
        Me.dgvEmpleadosHaberes.AllowUserToAddRows = False
        Me.dgvEmpleadosHaberes.AllowUserToDeleteRows = False
        Me.dgvEmpleadosHaberes.AllowUserToOrderColumns = True
        Me.dgvEmpleadosHaberes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEmpleadosHaberes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvEmpleadosHaberes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmpleadosHaberes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cliente, Me.Nomina, Me.Empleado, Me.NombreEmpleado, Me.Enero, Me.EneIAS, Me.Febrero, Me.FebIAS, Me.Marzo, Me.MarIAS, Me.Abril, Me.AbrIAS, Me.Mayo, Me.MayIAS, Me.Junio, Me.JunIAS, Me.Julio, Me.JulIAS, Me.Agosto, Me.AgoIAS, Me.Septiembre, Me.SepIAS, Me.Octubre, Me.OctIAS, Me.Noviembre, Me.NovIAS, Me.Diciembre, Me.DicIAS, Me.TotalHaberes, Me.TotalIAS, Me.Total})
        Me.dgvEmpleadosHaberes.ContextMenuStrip = Me.cmsEmpleado
        Me.dgvEmpleadosHaberes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvEmpleadosHaberes.Location = New System.Drawing.Point(3, 44)
        Me.dgvEmpleadosHaberes.Name = "dgvEmpleadosHaberes"
        Me.dgvEmpleadosHaberes.Size = New System.Drawing.Size(1398, 558)
        Me.dgvEmpleadosHaberes.TabIndex = 43
        '
        'cmsEmpleado
        '
        Me.cmsEmpleado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerNominasToolStripMenuItem})
        Me.cmsEmpleado.Name = "cmsEmpleado"
        Me.cmsEmpleado.Size = New System.Drawing.Size(143, 26)
        '
        'VerNominasToolStripMenuItem
        '
        Me.VerNominasToolStripMenuItem.Name = "VerNominasToolStripMenuItem"
        Me.VerNominasToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.VerNominasToolStripMenuItem.Text = "Ver Nominas"
        '
        'label
        '
        Me.label.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label.AutoSize = True
        Me.label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label.Location = New System.Drawing.Point(1136, 623)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(77, 16)
        Me.label.TabIndex = 44
        Me.label.Text = "TOTAL:  $"
        '
        'txtMonto
        '
        Me.txtMonto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(1219, 618)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ReadOnly = True
        Me.txtMonto.Size = New System.Drawing.Size(182, 24)
        Me.txtMonto.TabIndex = 45
        Me.txtMonto.Text = "0.0"
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 16)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Buscar Empleado:"
        '
        'txtBuscar
        '
        Me.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(141, 5)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(1058, 22)
        Me.txtBuscar.TabIndex = 1
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.MinimumWidth = 150
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Width = 150
        '
        'Nomina
        '
        Me.Nomina.HeaderText = "Nomina"
        Me.Nomina.MinimumWidth = 70
        Me.Nomina.Name = "Nomina"
        Me.Nomina.Width = 70
        '
        'Empleado
        '
        Me.Empleado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Empleado.FillWeight = 152.2843!
        Me.Empleado.HeaderText = "Empleado"
        Me.Empleado.MinimumWidth = 70
        Me.Empleado.Name = "Empleado"
        '
        'NombreEmpleado
        '
        Me.NombreEmpleado.HeaderText = "Nombre Empleado"
        Me.NombreEmpleado.MinimumWidth = 120
        Me.NombreEmpleado.Name = "NombreEmpleado"
        Me.NombreEmpleado.Width = 120
        '
        'Enero
        '
        Me.Enero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Enero.FillWeight = 147.7157!
        Me.Enero.HeaderText = "Enero Haberes"
        Me.Enero.MinimumWidth = 50
        Me.Enero.Name = "Enero"
        '
        'EneIAS
        '
        Me.EneIAS.HeaderText = "Enero IAS"
        Me.EneIAS.MinimumWidth = 50
        Me.EneIAS.Name = "EneIAS"
        Me.EneIAS.Width = 50
        '
        'Febrero
        '
        Me.Febrero.HeaderText = "Febrero Haberes"
        Me.Febrero.MinimumWidth = 50
        Me.Febrero.Name = "Febrero"
        Me.Febrero.Width = 50
        '
        'FebIAS
        '
        Me.FebIAS.HeaderText = "Febrero IAS"
        Me.FebIAS.MinimumWidth = 50
        Me.FebIAS.Name = "FebIAS"
        Me.FebIAS.Width = 50
        '
        'Marzo
        '
        Me.Marzo.HeaderText = "Marzo Haberes"
        Me.Marzo.MinimumWidth = 50
        Me.Marzo.Name = "Marzo"
        Me.Marzo.Width = 50
        '
        'MarIAS
        '
        Me.MarIAS.HeaderText = "Marzo IAS"
        Me.MarIAS.MinimumWidth = 50
        Me.MarIAS.Name = "MarIAS"
        Me.MarIAS.Width = 50
        '
        'Abril
        '
        Me.Abril.HeaderText = "Abril Haberes"
        Me.Abril.MinimumWidth = 50
        Me.Abril.Name = "Abril"
        Me.Abril.Width = 50
        '
        'AbrIAS
        '
        Me.AbrIAS.HeaderText = "Abril IAS"
        Me.AbrIAS.MinimumWidth = 50
        Me.AbrIAS.Name = "AbrIAS"
        Me.AbrIAS.Width = 50
        '
        'Mayo
        '
        Me.Mayo.HeaderText = "Mayo Haberes"
        Me.Mayo.MinimumWidth = 50
        Me.Mayo.Name = "Mayo"
        Me.Mayo.Width = 50
        '
        'MayIAS
        '
        Me.MayIAS.HeaderText = "Mayo IAS"
        Me.MayIAS.MinimumWidth = 50
        Me.MayIAS.Name = "MayIAS"
        Me.MayIAS.Width = 50
        '
        'Junio
        '
        Me.Junio.HeaderText = "Junio Haberes"
        Me.Junio.MinimumWidth = 50
        Me.Junio.Name = "Junio"
        Me.Junio.Width = 50
        '
        'JunIAS
        '
        Me.JunIAS.HeaderText = "Junio IAS"
        Me.JunIAS.MinimumWidth = 50
        Me.JunIAS.Name = "JunIAS"
        Me.JunIAS.Width = 50
        '
        'Julio
        '
        Me.Julio.HeaderText = "Julio Haberes"
        Me.Julio.MinimumWidth = 50
        Me.Julio.Name = "Julio"
        Me.Julio.Width = 50
        '
        'JulIAS
        '
        Me.JulIAS.HeaderText = "Julio IAS"
        Me.JulIAS.MinimumWidth = 50
        Me.JulIAS.Name = "JulIAS"
        Me.JulIAS.Width = 50
        '
        'Agosto
        '
        Me.Agosto.HeaderText = "Agosto Haberes"
        Me.Agosto.MinimumWidth = 50
        Me.Agosto.Name = "Agosto"
        Me.Agosto.Width = 50
        '
        'AgoIAS
        '
        Me.AgoIAS.HeaderText = "Agosto IAS"
        Me.AgoIAS.MinimumWidth = 50
        Me.AgoIAS.Name = "AgoIAS"
        Me.AgoIAS.Width = 50
        '
        'Septiembre
        '
        Me.Septiembre.HeaderText = "Septiembre Haberes"
        Me.Septiembre.MinimumWidth = 50
        Me.Septiembre.Name = "Septiembre"
        Me.Septiembre.Width = 50
        '
        'SepIAS
        '
        Me.SepIAS.HeaderText = "Septiembre IAS"
        Me.SepIAS.MinimumWidth = 50
        Me.SepIAS.Name = "SepIAS"
        Me.SepIAS.Width = 50
        '
        'Octubre
        '
        Me.Octubre.HeaderText = "Octubre Haberes"
        Me.Octubre.MinimumWidth = 50
        Me.Octubre.Name = "Octubre"
        Me.Octubre.Width = 50
        '
        'OctIAS
        '
        Me.OctIAS.HeaderText = "Octubre IAS"
        Me.OctIAS.MinimumWidth = 50
        Me.OctIAS.Name = "OctIAS"
        Me.OctIAS.Width = 50
        '
        'Noviembre
        '
        Me.Noviembre.HeaderText = "Noviembre Haberes"
        Me.Noviembre.MinimumWidth = 50
        Me.Noviembre.Name = "Noviembre"
        Me.Noviembre.Width = 50
        '
        'NovIAS
        '
        Me.NovIAS.HeaderText = "Noviembre IAS"
        Me.NovIAS.MinimumWidth = 50
        Me.NovIAS.Name = "NovIAS"
        Me.NovIAS.Width = 50
        '
        'Diciembre
        '
        Me.Diciembre.HeaderText = "Diciembre Haberes"
        Me.Diciembre.MinimumWidth = 50
        Me.Diciembre.Name = "Diciembre"
        Me.Diciembre.Width = 50
        '
        'DicIAS
        '
        Me.DicIAS.HeaderText = "Diciembre IAS"
        Me.DicIAS.MinimumWidth = 50
        Me.DicIAS.Name = "DicIAS"
        Me.DicIAS.Width = 50
        '
        'TotalHaberes
        '
        Me.TotalHaberes.HeaderText = "Total Haberes"
        Me.TotalHaberes.MinimumWidth = 50
        Me.TotalHaberes.Name = "TotalHaberes"
        Me.TotalHaberes.Width = 70
        '
        'TotalIAS
        '
        Me.TotalIAS.HeaderText = "Total IAS"
        Me.TotalIAS.MinimumWidth = 50
        Me.TotalIAS.Name = "TotalIAS"
        Me.TotalIAS.Width = 70
        '
        'Total
        '
        Me.Total.HeaderText = "Total Acumulado"
        Me.Total.MinimumWidth = 80
        Me.Total.Name = "Total"
        Me.Total.Width = 80
        '
        'frmHaberesDetalles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1413, 647)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.label)
        Me.Controls.Add(Me.dgvEmpleadosHaberes)
        Me.Name = "frmHaberesDetalles"
        Me.Text = "Detalles Haberes"
        CType(Me.dgvEmpleadosHaberes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsEmpleado.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvEmpleadosHaberes As System.Windows.Forms.DataGridView
    Friend WithEvents label As System.Windows.Forms.Label
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents cmsEmpleado As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents VerNominasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nomina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Empleado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreEmpleado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Enero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EneIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Febrero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FebIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Marzo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Abril As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AbrIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mayo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MayIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Junio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JunIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Julio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JulIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agosto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgoIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Septiembre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SepIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Octubre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OctIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Noviembre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NovIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Diciembre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DicIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalHaberes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
