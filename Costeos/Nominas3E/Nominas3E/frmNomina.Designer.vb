<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNomina
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNomina))
        Me.btnExportarE = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAbrir = New System.Windows.Forms.Button()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.dtFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmpresa = New System.Windows.Forms.TextBox()
        Me.txtSeguro = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnExportarR = New System.Windows.Forms.Button()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.btnEmpleados = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtArchEmpleados = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.btnConsultaBD = New System.Windows.Forms.Button()
        Me.gbBase = New System.Windows.Forms.GroupBox()
        Me.rbIpp = New System.Windows.Forms.RadioButton()
        Me.rbHitss = New System.Windows.Forms.RadioButton()
        Me.lbMensaaje = New System.Windows.Forms.Label()
        Me.chImss = New System.Windows.Forms.CheckBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.dtFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbObtenerBD = New System.Windows.Forms.GroupBox()
        Me.chNomina9 = New System.Windows.Forms.CheckBox()
        Me.chPrimaRiesgo = New System.Windows.Forms.CheckBox()
        Me.chNomina = New System.Windows.Forms.CheckBox()
        Me.chEdadSexoCurp = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPrimaRiesgo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtHaberesArchivo = New System.Windows.Forms.TextBox()
        Me.btnHaberes = New System.Windows.Forms.Button()
        Me.OpenFileDialog3 = New System.Windows.Forms.OpenFileDialog()
        Me.btnInsertarBase = New System.Windows.Forms.Button()
        Me.tbMenu = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtaviso = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbxlista = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbann1 = New System.Windows.Forms.ComboBox()
        Me.cbxan = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtEmpleadoBuscar = New System.Windows.Forms.TextBox()
        Me.cmbBuscar = New System.Windows.Forms.ComboBox()
        Me.btnCopiar = New System.Windows.Forms.Button()
        Me.btnBuscarEmp = New System.Windows.Forms.Button()
        Me.lstView = New System.Windows.Forms.ListView()
        Me.lCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lMes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lAn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lNomina = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lMonto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmEliminar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DetallesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblNomina = New System.Windows.Forms.Label()
        Me.chkNomina = New System.Windows.Forms.CheckedListBox()
        Me.btnVerificar = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSumaHaberes = New System.Windows.Forms.TextBox()
        Me.txtHAnual = New System.Windows.Forms.TextBox()
        Me.cmsMontoAnual = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtlog = New System.Windows.Forms.TextBox()
        Me.gbBase.SuspendLayout()
        Me.gbObtenerBD.SuspendLayout()
        Me.tbMenu.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.cmEliminar.SuspendLayout()
        Me.cmsMontoAnual.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExportarE
        '
        Me.btnExportarE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportarE.Location = New System.Drawing.Point(6, 363)
        Me.btnExportarE.Name = "btnExportarE"
        Me.btnExportarE.Size = New System.Drawing.Size(239, 32)
        Me.btnExportarE.TabIndex = 18
        Me.btnExportarE.Text = "Estandar"
        Me.btnExportarE.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Archivo de Nominas:"
        '
        'btnAbrir
        '
        Me.btnAbrir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbrir.Location = New System.Drawing.Point(51, 108)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(36, 23)
        Me.btnAbrir.TabIndex = 6
        Me.btnAbrir.Text = "..."
        Me.btnAbrir.UseVisualStyleBackColor = True
        '
        'txtArchivo
        '
        Me.txtArchivo.Enabled = False
        Me.txtArchivo.Location = New System.Drawing.Point(12, 111)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(49, 20)
        Me.txtArchivo.TabIndex = 1
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Archivos Excel (*.xlsx)|*.xlsx|All Files (*.*)|*.*"""
        '
        'dtFechaInicial
        '
        Me.dtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaInicial.Location = New System.Drawing.Point(9, 84)
        Me.dtFechaInicial.Name = "dtFechaInicial"
        Me.dtFechaInicial.Size = New System.Drawing.Size(144, 20)
        Me.dtFechaInicial.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Fecha de Conversión:"
        '
        'txtEmpresa
        '
        Me.txtEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpresa.Location = New System.Drawing.Point(531, 6)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.ReadOnly = True
        Me.txtEmpresa.Size = New System.Drawing.Size(19, 20)
        Me.txtEmpresa.TabIndex = 4
        Me.txtEmpresa.Visible = False
        '
        'txtSeguro
        '
        Me.txtSeguro.Location = New System.Drawing.Point(6, 292)
        Me.txtSeguro.Name = "txtSeguro"
        Me.txtSeguro.ReadOnly = True
        Me.txtSeguro.Size = New System.Drawing.Size(556, 20)
        Me.txtSeguro.TabIndex = 17
        Me.txtSeguro.Text = "3108.36"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Empresa:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 276)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Seguro de Vida:"
        '
        'btnExportarR
        '
        Me.btnExportarR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportarR.Location = New System.Drawing.Point(6, 401)
        Me.btnExportarR.Name = "btnExportarR"
        Me.btnExportarR.Size = New System.Drawing.Size(239, 32)
        Me.btnExportarR.TabIndex = 19
        Me.btnExportarR.Text = "Real"
        Me.btnExportarR.UseVisualStyleBackColor = True
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Items.AddRange(New Object() {"2901 CORPORATIVO DE OPERACION INTERGRUP SA DE CV", "2902 CORPORATIVO DE OPERACION INTERGRUP SA DE CV", "2903 CORPORATIVO DE OPERACION INTERGRUP SA DE CV", "3201 GRUPO CONISAL SA DE CV", "3202 GRUPO CONISAL SA DE CV", "3601 CORPORATIVO DE OPERACION INTERGRUP SA DE CV", "3701 CORPORATIVO DE OPERACION INTERGRUP SA DE CV", "3801 GRUPO CONISAL SA DE CV", "5003 GRUPO CONSULTOR DE LOS ANGELES S.A. DE C.V.", "5005 GRUPO CONSULTOR DE LOS ANGELES S.A. DE C.V.", "4601 IT RESOURSCES TELECOM SA DE CV.", "4701 IT RESOURSCES TELECOM SA DE CV.", "4801 IT RESOURSCES TELECOM SA DE CV.", "5401 IT RESOURSCES TELECOM SA DE CV.", "5701 GRUPO CONISAL SA DE CV"})
        Me.cmbEmpresa.Location = New System.Drawing.Point(12, 20)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(556, 21)
        Me.cmbEmpresa.TabIndex = 2
        '
        'btnEmpleados
        '
        Me.btnEmpleados.Location = New System.Drawing.Point(65, 158)
        Me.btnEmpleados.Name = "btnEmpleados"
        Me.btnEmpleados.Size = New System.Drawing.Size(36, 22)
        Me.btnEmpleados.TabIndex = 8
        Me.btnEmpleados.Text = "..."
        Me.btnEmpleados.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Archivo de Empleados: "
        '
        'txtArchEmpleados
        '
        Me.txtArchEmpleados.Enabled = False
        Me.txtArchEmpleados.Location = New System.Drawing.Point(12, 158)
        Me.txtArchEmpleados.Name = "txtArchEmpleados"
        Me.txtArchEmpleados.Size = New System.Drawing.Size(75, 20)
        Me.txtArchEmpleados.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(150, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(381, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "(debe coincidir los empleados en el mismo orden que en el archivo de Nominas)"
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.Filter = "Archivos Excel (*.xlsx)|*.xlsx|All Files (*.*)|*.*"""
        '
        'btnConsultaBD
        '
        Me.btnConsultaBD.Location = New System.Drawing.Point(451, 130)
        Me.btnConsultaBD.Name = "btnConsultaBD"
        Me.btnConsultaBD.Size = New System.Drawing.Size(111, 85)
        Me.btnConsultaBD.TabIndex = 15
        Me.btnConsultaBD.Text = "Consultar en BD"
        Me.btnConsultaBD.UseVisualStyleBackColor = True
        '
        'gbBase
        '
        Me.gbBase.Controls.Add(Me.rbIpp)
        Me.gbBase.Controls.Add(Me.rbHitss)
        Me.gbBase.Location = New System.Drawing.Point(9, 127)
        Me.gbBase.Name = "gbBase"
        Me.gbBase.Size = New System.Drawing.Size(191, 49)
        Me.gbBase.TabIndex = 18
        Me.gbBase.TabStop = False
        Me.gbBase.Text = "Seleccione la base de datos"
        '
        'rbIpp
        '
        Me.rbIpp.AutoSize = True
        Me.rbIpp.Location = New System.Drawing.Point(85, 19)
        Me.rbIpp.Name = "rbIpp"
        Me.rbIpp.Size = New System.Drawing.Size(43, 17)
        Me.rbIpp.TabIndex = 11
        Me.rbIpp.Text = "Ipp"
        Me.rbIpp.UseVisualStyleBackColor = True
        '
        'rbHitss
        '
        Me.rbHitss.AutoSize = True
        Me.rbHitss.Checked = True
        Me.rbHitss.Location = New System.Drawing.Point(7, 19)
        Me.rbHitss.Name = "rbHitss"
        Me.rbHitss.Size = New System.Drawing.Size(53, 17)
        Me.rbHitss.TabIndex = 10
        Me.rbHitss.TabStop = True
        Me.rbHitss.Text = "Hitss"
        Me.rbHitss.UseVisualStyleBackColor = True
        '
        'lbMensaaje
        '
        Me.lbMensaaje.AutoSize = True
        Me.lbMensaaje.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMensaaje.Location = New System.Drawing.Point(12, 410)
        Me.lbMensaaje.Name = "lbMensaaje"
        Me.lbMensaaje.Size = New System.Drawing.Size(0, 13)
        Me.lbMensaaje.TabIndex = 19
        '
        'chImss
        '
        Me.chImss.AutoSize = True
        Me.chImss.Checked = True
        Me.chImss.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chImss.Location = New System.Drawing.Point(405, 5)
        Me.chImss.Name = "chImss"
        Me.chImss.Size = New System.Drawing.Size(120, 17)
        Me.chImss.TabIndex = 20
        Me.chImss.Text = "ImssSarInfonavit"
        Me.chImss.UseVisualStyleBackColor = True
        Me.chImss.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 451)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(556, 23)
        Me.ProgressBar1.TabIndex = 21
        '
        'dtFechaFinal
        '
        Me.dtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFinal.Location = New System.Drawing.Point(206, 84)
        Me.dtFechaFinal.Name = "dtFechaFinal"
        Me.dtFechaFinal.Size = New System.Drawing.Size(144, 20)
        Me.dtFechaFinal.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(170, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "a"
        '
        'gbObtenerBD
        '
        Me.gbObtenerBD.Controls.Add(Me.chNomina9)
        Me.gbObtenerBD.Controls.Add(Me.chPrimaRiesgo)
        Me.gbObtenerBD.Controls.Add(Me.chNomina)
        Me.gbObtenerBD.Controls.Add(Me.chEdadSexoCurp)
        Me.gbObtenerBD.Location = New System.Drawing.Point(206, 127)
        Me.gbObtenerBD.Name = "gbObtenerBD"
        Me.gbObtenerBD.Size = New System.Drawing.Size(239, 88)
        Me.gbObtenerBD.TabIndex = 24
        Me.gbObtenerBD.TabStop = False
        Me.gbObtenerBD.Text = "Obtener de la BD"
        '
        'chNomina9
        '
        Me.chNomina9.AutoSize = True
        Me.chNomina9.Location = New System.Drawing.Point(83, 42)
        Me.chNomina9.Name = "chNomina9"
        Me.chNomina9.Size = New System.Drawing.Size(138, 17)
        Me.chNomina9.TabIndex = 15
        Me.chNomina9.Text = "Nomina (1,2,8,9,23)"
        Me.chNomina9.UseVisualStyleBackColor = True
        '
        'chPrimaRiesgo
        '
        Me.chPrimaRiesgo.AutoSize = True
        Me.chPrimaRiesgo.Checked = True
        Me.chPrimaRiesgo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chPrimaRiesgo.Location = New System.Drawing.Point(9, 65)
        Me.chPrimaRiesgo.Name = "chPrimaRiesgo"
        Me.chPrimaRiesgo.Size = New System.Drawing.Size(118, 17)
        Me.chPrimaRiesgo.TabIndex = 14
        Me.chPrimaRiesgo.Text = "Prima de Riesgo"
        Me.chPrimaRiesgo.UseVisualStyleBackColor = True
        '
        'chNomina
        '
        Me.chNomina.AutoSize = True
        Me.chNomina.Checked = True
        Me.chNomina.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chNomina.Location = New System.Drawing.Point(9, 42)
        Me.chNomina.Name = "chNomina"
        Me.chNomina.Size = New System.Drawing.Size(68, 17)
        Me.chNomina.TabIndex = 13
        Me.chNomina.Text = "Nomina"
        Me.chNomina.UseVisualStyleBackColor = True
        '
        'chEdadSexoCurp
        '
        Me.chEdadSexoCurp.AutoSize = True
        Me.chEdadSexoCurp.Checked = True
        Me.chEdadSexoCurp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chEdadSexoCurp.Location = New System.Drawing.Point(9, 19)
        Me.chEdadSexoCurp.Name = "chEdadSexoCurp"
        Me.chEdadSexoCurp.Size = New System.Drawing.Size(125, 17)
        Me.chEdadSexoCurp.TabIndex = 12
        Me.chEdadSexoCurp.Text = "Edad, Sexo, Curp"
        Me.chEdadSexoCurp.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 224)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Prima de Riesgo:"
        '
        'txtPrimaRiesgo
        '
        Me.txtPrimaRiesgo.Location = New System.Drawing.Point(6, 240)
        Me.txtPrimaRiesgo.Name = "txtPrimaRiesgo"
        Me.txtPrimaRiesgo.Size = New System.Drawing.Size(556, 20)
        Me.txtPrimaRiesgo.TabIndex = 16
        Me.txtPrimaRiesgo.Text = "0.5"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Cargar Archivo"
        '
        'txtHaberesArchivo
        '
        Me.txtHaberesArchivo.Location = New System.Drawing.Point(11, 101)
        Me.txtHaberesArchivo.Name = "txtHaberesArchivo"
        Me.txtHaberesArchivo.Size = New System.Drawing.Size(523, 20)
        Me.txtHaberesArchivo.TabIndex = 27
        '
        'btnHaberes
        '
        Me.btnHaberes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHaberes.Location = New System.Drawing.Point(535, 99)
        Me.btnHaberes.Name = "btnHaberes"
        Me.btnHaberes.Size = New System.Drawing.Size(36, 23)
        Me.btnHaberes.TabIndex = 28
        Me.btnHaberes.Text = "..."
        Me.btnHaberes.UseVisualStyleBackColor = True
        '
        'OpenFileDialog3
        '
        Me.OpenFileDialog3.Filter = "Archivos Excel (*.xlsx)|*.xlsx|All Files (*.*)|*.*"""
        '
        'btnInsertarBase
        '
        Me.btnInsertarBase.Location = New System.Drawing.Point(423, 47)
        Me.btnInsertarBase.Name = "btnInsertarBase"
        Me.btnInsertarBase.Size = New System.Drawing.Size(141, 23)
        Me.btnInsertarBase.TabIndex = 30
        Me.btnInsertarBase.Text = "Insertar en Base"
        Me.btnInsertarBase.UseVisualStyleBackColor = True
        '
        'tbMenu
        '
        Me.tbMenu.Controls.Add(Me.TabPage1)
        Me.tbMenu.Controls.Add(Me.TabPage2)
        Me.tbMenu.Location = New System.Drawing.Point(12, 6)
        Me.tbMenu.Name = "tbMenu"
        Me.tbMenu.SelectedIndex = 0
        Me.tbMenu.Size = New System.Drawing.Size(592, 624)
        Me.tbMenu.TabIndex = 32
        '
        'TabPage1
        '
        Me.TabPage1.CausesValidation = False
        Me.TabPage1.Controls.Add(Me.txtaviso)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.ProgressBar1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cmbEmpresa)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.dtFechaInicial)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.dtFechaFinal)
        Me.TabPage1.Controls.Add(Me.gbBase)
        Me.TabPage1.Controls.Add(Me.txtPrimaRiesgo)
        Me.TabPage1.Controls.Add(Me.gbObtenerBD)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.btnConsultaBD)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtSeguro)
        Me.TabPage1.Controls.Add(Me.btnExportarR)
        Me.TabPage1.Controls.Add(Me.btnExportarE)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(584, 598)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Costeo"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtaviso
        '
        Me.txtaviso.ForeColor = System.Drawing.Color.Red
        Me.txtaviso.Location = New System.Drawing.Point(251, 319)
        Me.txtaviso.Multiline = True
        Me.txtaviso.Name = "txtaviso"
        Me.txtaviso.Size = New System.Drawing.Size(311, 31)
        Me.txtaviso.TabIndex = 27
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(7, 318)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(238, 32)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "Actualizar la Base de Datos"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.cbxlista)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.cmbann1)
        Me.TabPage2.Controls.Add(Me.cbxan)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.txtEmpleadoBuscar)
        Me.TabPage2.Controls.Add(Me.cmbBuscar)
        Me.TabPage2.Controls.Add(Me.btnHaberes)
        Me.TabPage2.Controls.Add(Me.btnCopiar)
        Me.TabPage2.Controls.Add(Me.btnBuscarEmp)
        Me.TabPage2.Controls.Add(Me.lstView)
        Me.TabPage2.Controls.Add(Me.lblNomina)
        Me.TabPage2.Controls.Add(Me.chkNomina)
        Me.TabPage2.Controls.Add(Me.btnVerificar)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.txtSumaHaberes)
        Me.TabPage2.Controls.Add(Me.txtHAnual)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.txtHaberesArchivo)
        Me.TabPage2.Controls.Add(Me.btnInsertarBase)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(584, 598)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Haberes"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(123, 257)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 23)
        Me.Button1.TabIndex = 55
        Me.Button1.Text = "Filtrar por periodo"
        Me.Button1.UseMnemonic = False
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbxlista
        '
        Me.cbxlista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxlista.FormattingEnabled = True
        Me.cbxlista.Items.AddRange(New Object() {"2015", "2016"})
        Me.cbxlista.Location = New System.Drawing.Point(18, 257)
        Me.cbxlista.Name = "cbxlista"
        Me.cbxlista.Size = New System.Drawing.Size(99, 21)
        Me.cbxlista.TabIndex = 54
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(348, 177)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 13)
        Me.Label14.TabIndex = 53
        Me.Label14.Text = "Periodo"
        '
        'cmbann1
        '
        Me.cmbann1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbann1.FormattingEnabled = True
        Me.cmbann1.Items.AddRange(New Object() {"2015", "2016"})
        Me.cmbann1.Location = New System.Drawing.Point(349, 193)
        Me.cmbann1.Name = "cmbann1"
        Me.cmbann1.Size = New System.Drawing.Size(102, 21)
        Me.cmbann1.TabIndex = 52
        '
        'cbxan
        '
        Me.cbxan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxan.FormattingEnabled = True
        Me.cbxan.Items.AddRange(New Object() {"2015", "2016"})
        Me.cbxan.Location = New System.Drawing.Point(137, 54)
        Me.cbxan.Name = "cbxan"
        Me.cbxan.Size = New System.Drawing.Size(121, 21)
        Me.cbxan.TabIndex = 51
        Me.cbxan.Tag = ""
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(179, 177)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 13)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "Buscar Empleado"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(130, 13)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "Seleccione el periodo"
        '
        'txtEmpleadoBuscar
        '
        Me.txtEmpleadoBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpleadoBuscar.Location = New System.Drawing.Point(179, 220)
        Me.txtEmpleadoBuscar.Name = "txtEmpleadoBuscar"
        Me.txtEmpleadoBuscar.Size = New System.Drawing.Size(355, 20)
        Me.txtEmpleadoBuscar.TabIndex = 47
        '
        'cmbBuscar
        '
        Me.cmbBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBuscar.FormattingEnabled = True
        Me.cmbBuscar.Items.AddRange(New Object() {"No. Empleado", "Nombre Empleado"})
        Me.cmbBuscar.Location = New System.Drawing.Point(179, 193)
        Me.cmbBuscar.Name = "cmbBuscar"
        Me.cmbBuscar.Size = New System.Drawing.Size(164, 21)
        Me.cmbBuscar.TabIndex = 46
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(433, 255)
        Me.btnCopiar.Name = "btnCopiar"
        Me.btnCopiar.Size = New System.Drawing.Size(145, 23)
        Me.btnCopiar.TabIndex = 45
        Me.btnCopiar.Text = "Copiar listado clientes"
        Me.btnCopiar.UseVisualStyleBackColor = True
        '
        'btnBuscarEmp
        '
        Me.btnBuscarEmp.Image = Global.Nominas3E.My.Resources.Resources.search_4
        Me.btnBuscarEmp.Location = New System.Drawing.Point(540, 214)
        Me.btnBuscarEmp.Name = "btnBuscarEmp"
        Me.btnBuscarEmp.Size = New System.Drawing.Size(31, 30)
        Me.btnBuscarEmp.TabIndex = 48
        Me.btnBuscarEmp.UseVisualStyleBackColor = True
        '
        'lstView
        '
        Me.lstView.AllowColumnReorder = True
        Me.lstView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstView.BackgroundImageTiled = True
        Me.lstView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lCliente, Me.lMes, Me.lAn, Me.lNomina, Me.lMonto})
        Me.lstView.ContextMenuStrip = Me.cmEliminar
        Me.lstView.Location = New System.Drawing.Point(12, 284)
        Me.lstView.Name = "lstView"
        Me.lstView.Size = New System.Drawing.Size(569, 308)
        Me.lstView.TabIndex = 44
        Me.lstView.UseCompatibleStateImageBehavior = False
        Me.lstView.View = System.Windows.Forms.View.Details
        '
        'lCliente
        '
        Me.lCliente.Text = "Cliente"
        Me.lCliente.Width = 185
        '
        'lMes
        '
        Me.lMes.Text = "Mes"
        Me.lMes.Width = 101
        '
        'lAn
        '
        Me.lAn.DisplayIndex = 4
        Me.lAn.Text = "Año"
        '
        'lNomina
        '
        Me.lNomina.DisplayIndex = 2
        Me.lNomina.Text = "No. Nomina"
        Me.lNomina.Width = 95
        '
        'lMonto
        '
        Me.lMonto.DisplayIndex = 3
        Me.lMonto.Text = "Monto"
        Me.lMonto.Width = 115
        '
        'cmEliminar
        '
        Me.cmEliminar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DetallesToolStripMenuItem, Me.EliminarToolStripMenuItem})
        Me.cmEliminar.Name = "cmEliminar"
        Me.cmEliminar.Size = New System.Drawing.Size(118, 48)
        '
        'DetallesToolStripMenuItem
        '
        Me.DetallesToolStripMenuItem.Name = "DetallesToolStripMenuItem"
        Me.DetallesToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.DetallesToolStripMenuItem.Text = "Detalles"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'lblNomina
        '
        Me.lblNomina.AutoSize = True
        Me.lblNomina.Location = New System.Drawing.Point(9, 128)
        Me.lblNomina.Name = "lblNomina"
        Me.lblNomina.Size = New System.Drawing.Size(49, 13)
        Me.lblNomina.TabIndex = 38
        Me.lblNomina.Text = "Nomina"
        '
        'chkNomina
        '
        Me.chkNomina.CheckOnClick = True
        Me.chkNomina.FormattingEnabled = True
        Me.chkNomina.Location = New System.Drawing.Point(9, 144)
        Me.chkNomina.Name = "chkNomina"
        Me.chkNomina.Size = New System.Drawing.Size(164, 64)
        Me.chkNomina.TabIndex = 37
        '
        'btnVerificar
        '
        Me.btnVerificar.Location = New System.Drawing.Point(423, 15)
        Me.btnVerificar.Name = "btnVerificar"
        Me.btnVerificar.Size = New System.Drawing.Size(141, 23)
        Me.btnVerificar.TabIndex = 36
        Me.btnVerificar.Text = "Verificar"
        Me.btnVerificar.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(178, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Suma"
        '
        'txtSumaHaberes
        '
        Me.txtSumaHaberes.Location = New System.Drawing.Point(181, 144)
        Me.txtSumaHaberes.Name = "txtSumaHaberes"
        Me.txtSumaHaberes.ReadOnly = True
        Me.txtSumaHaberes.Size = New System.Drawing.Size(162, 20)
        Me.txtSumaHaberes.TabIndex = 34
        '
        'txtHAnual
        '
        Me.txtHAnual.ContextMenuStrip = Me.cmsMontoAnual
        Me.txtHAnual.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHAnual.Location = New System.Drawing.Point(90, 12)
        Me.txtHAnual.Name = "txtHAnual"
        Me.txtHAnual.ReadOnly = True
        Me.txtHAnual.Size = New System.Drawing.Size(191, 26)
        Me.txtHAnual.TabIndex = 33
        Me.txtHAnual.Text = "2300000"
        Me.txtHAnual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmsMontoAnual
        '
        Me.cmsMontoAnual.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarToolStripMenuItem})
        Me.cmsMontoAnual.Name = "cmsMontoAnual"
        Me.cmsMontoAnual.Size = New System.Drawing.Size(105, 26)
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(104, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Monto Anual"
        '
        'txtlog
        '
        Me.txtlog.Location = New System.Drawing.Point(611, 24)
        Me.txtlog.Multiline = True
        Me.txtlog.Name = "txtlog"
        Me.txtlog.Size = New System.Drawing.Size(416, 602)
        Me.txtlog.TabIndex = 33
        '
        'frmNomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 642)
        Me.Controls.Add(Me.txtlog)
        Me.Controls.Add(Me.tbMenu)
        Me.Controls.Add(Me.chImss)
        Me.Controls.Add(Me.lbMensaaje)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnEmpleados)
        Me.Controls.Add(Me.txtEmpresa)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAbrir)
        Me.Controls.Add(Me.txtArchivo)
        Me.Controls.Add(Me.txtArchEmpleados)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmNomina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nominas V.3.2"
        Me.gbBase.ResumeLayout(False)
        Me.gbBase.PerformLayout()
        Me.gbObtenerBD.ResumeLayout(False)
        Me.gbObtenerBD.PerformLayout()
        Me.tbMenu.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.cmEliminar.ResumeLayout(False)
        Me.cmsMontoAnual.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExportarE As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents txtArchivo As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dtFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents txtSeguro As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnExportarR As System.Windows.Forms.Button
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents btnEmpleados As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtArchEmpleados As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnConsultaBD As System.Windows.Forms.Button
    Friend WithEvents gbBase As System.Windows.Forms.GroupBox
    Friend WithEvents rbIpp As System.Windows.Forms.RadioButton
    Friend WithEvents rbHitss As System.Windows.Forms.RadioButton
    Friend WithEvents lbMensaaje As System.Windows.Forms.Label
    Friend WithEvents chImss As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents dtFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gbObtenerBD As System.Windows.Forms.GroupBox
    Friend WithEvents chPrimaRiesgo As System.Windows.Forms.CheckBox
    Friend WithEvents chNomina As System.Windows.Forms.CheckBox
    Friend WithEvents chEdadSexoCurp As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPrimaRiesgo As System.Windows.Forms.TextBox
    Friend WithEvents chNomina9 As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtHaberesArchivo As System.Windows.Forms.TextBox
    Friend WithEvents btnHaberes As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog3 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnInsertarBase As System.Windows.Forms.Button
    Friend WithEvents tbMenu As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtHAnual As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSumaHaberes As System.Windows.Forms.TextBox
    Friend WithEvents btnVerificar As System.Windows.Forms.Button
    Friend WithEvents lblNomina As System.Windows.Forms.Label
    Friend WithEvents chkNomina As System.Windows.Forms.CheckedListBox
    Friend WithEvents cmEliminar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EliminarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetallesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lstView As System.Windows.Forms.ListView
    Friend WithEvents lCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents lMes As System.Windows.Forms.ColumnHeader
    Friend WithEvents lNomina As System.Windows.Forms.ColumnHeader
    Friend WithEvents lMonto As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnCopiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscarEmp As System.Windows.Forms.Button
    Friend WithEvents txtEmpleadoBuscar As System.Windows.Forms.TextBox
    Friend WithEvents cmbBuscar As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmsMontoAnual As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lAn As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbxan As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbann1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbxlista As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtlog As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtaviso As System.Windows.Forms.TextBox

End Class
