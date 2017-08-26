Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Text
Imports System.Data.SqlClient

Public Class frmNomina
    Private archivo, archivoE, ArchivoH, Centro, Empresa, EmpIntel As String

    Private obExcel As Object
    Private obLibro As Object
    Private obHoja As Object

    Private obExcelE As Object
    Private obLibroE As Object
    Private obHojaE As Object

    Private obExcelH As Object
    Private obLibroH As Object
    Private obHojaH As Object

    Private arrDatosNomina As ArrayList
    Private arrEstandar As ArrayList
    Private arrReal As ArrayList
    Private arrEmpleados As ArrayList
    Private arrEmpleadosEdad As ArrayList
    Private arrEmpleadosBaja As ArrayList
    Private arrEmpleadosEdadBaja As ArrayList
    Private arrHaberes As ArrayList
    Private arrHMeses As ArrayList

    Private cNomina As clsNominaHandler
    Private cRT As clsRT
    Public CONTADOR As Integer
    Private empBajas As Int32
    Private NomCalculadas As Int32

    Private TotalHaberes As Double
    Private HaberesNomina As String

    Private band As Boolean
    Private bandera As Boolean
    Private numeroHoja As Int32

    Public textolog As String

    Public nominalog As clsNominaHandler
    Public Sub ObtenerDatosdeExcel()
        Try
            'Creamos una instancia de Excel
            Me.obExcel = CreateObject("Excel.Application")
            Me.obLibro = Me.obExcel.workbooks.open(Me.archivo)
            Me.obHoja = Me.obLibro.worksheets(1)
            Me.obHoja.activate()
            Me.obHoja.application.visible = True
            Me.ObtenDatosExcelNomina()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub ObtenerDatosdeExcelEmp()
        Try
            'Creamos una instancia de Excel
            Me.obExcelE = CreateObject("Excel.Application")
            Me.obLibroE = Me.obExcelE.workbooks.open(Me.archivoE)
            Me.obHojaE = Me.obLibroE.worksheets(1)
            Me.obHojaE.activate()
            Me.obHojaE.application.visible = True
            Me.ObtenDatosExcelEmpleados()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub ObtenerDatosdeExcelHaberes()
        Try
            'Creamos una instancia de Excel
            Me.obExcelH = CreateObject("Excel.Application")
            Me.obLibroH = Me.obExcelH.workbooks.open(Me.ArchivoH)
            Me.obHojaH = Me.obLibroH.worksheets(1)
            Me.obHojaH.activate()
            Me.obHojaH.application.visible = True
            Me.band = False
            Me.numeroHoja = 1
            Me.chkNomina.Items.Clear()

            'Eliminamos datos temporales
            Dim cH As clsHaberesHandler
            cH = New clsHaberesHandler(Funciones.GetConnectionStringHaberes)
            cH.EliminaTemporal()

            Me.ObtenDatosHaberes(1)
            'Me.numeroHoja = 2
            'Select Case Me.HaberesNomina
            '    Case "NOMINA QUINCENAL"
            '        Me.ObtenDatosHaberes(2)
            '        Me.lblNomina.Text = "Nomina Quincenal"
            '    Case "NOMINA SEMANAL"
            '        Me.ObtenDatosHaberes(2)
            '        Me.ObtenDatosHaberes(3)
            '        Me.ObtenDatosHaberes(4)
            '        Me.lblNomina.Text = "Nomina Semanal"
            '    Case "NOMINA MENSUAL"
            '        Me.ObtenDatosHaberes(2)
            '        Me.ObtenDatosHaberes(3)
            '        Me.ObtenDatosHaberes(4)
            '        Me.ObtenDatosHaberes(5)
            '        Me.ObtenDatosHaberes(6)
            '        Me.ObtenDatosHaberes(7)
            '        Me.ObtenDatosHaberes(8)
            '        Me.ObtenDatosHaberes(9)
            '        Me.ObtenDatosHaberes(10)
            '        Me.ObtenDatosHaberes(11)
            '        Me.ObtenDatosHaberes(12)
            '    Case "NOMINA CATORCENAL"
            '        Me.ObtenDatosHaberes(2)
            'End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        Me.OpenFileDialog1.ShowDialog()
        Me.txtArchivo.Text = Me.archivo
        If Me.archivo <> "" Then
            Me.ObtenerDatosdeExcel()
        End If
        MessageBox.Show("Archivo cargado correctamente")
    End Sub
    Private Sub btnEmpleados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleados.Click
        Me.OpenFileDialog2.ShowDialog()
        Me.txtArchEmpleados.Text = Me.archivoE
        If Me.archivoE <> "" Then
            Me.ObtenerDatosdeExcelEmp()
        End If
        MessageBox.Show("Archivo cargado correctamente")
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Me.archivo = Me.OpenFileDialog1.FileName
    End Sub
    Private Sub OpenFileDialog2_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog2.FileOk
        Me.archivoE = Me.OpenFileDialog2.FileName
    End Sub
    Private Sub OpenFileDialog3_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog3.FileOk
        Me.ArchivoH = Me.OpenFileDialog3.FileName
    End Sub


    Public Sub ObtenDatosHaberes(ByVal Hoja As Int32)
        Dim i As Int32
        Dim c As clsHaberes
        Dim ce As clsHaberesEmpleado
        Dim cH As clsHaberesHandler

        Dim arrEmpHaberes As ArrayList
        Dim cliente, nomina As String
        Dim mes, numeronomina, idH As Int32
        Dim SubtotalH As Double
        i = 13
        Me.arrHaberes = New ArrayList
        arrEmpHaberes = New ArrayList

        Me.obHojaH = Me.obLibroH.worksheets(Hoja)
        cH = New clsHaberesHandler(Funciones.GetConnectionStringHaberes)

        cliente = Me.obHojaH.Cells(5, 2).value
        nomina = Me.obHojaH.Cells(7, 2).value
        Me.HaberesNomina = nomina    'Nomina --> Quincenal, Semanal, Mensual, Anual
        mes = Me.obHojaH.Cells(9, 2).value
        numeronomina = Me.obHojaH.Cells(10, 2).value
        'Me.TotalHaberes = 0
        SubtotalH = 0
        'nuevo
        Dim j As Integer
        Dim h = CInt(cbxan.Text)
        Integer.TryParse(CStr(cbxan.Text), j)
        'nuevo
        c = New clsHaberes(cliente, nomina, mes, numeronomina, j)
        'Validamos que no haya en base
        Me.band = Me.ValidaMes(cliente, mes, numeronomina, j)
        If Me.band = True And Me.numeroHoja = 1 Then
            MessageBox.Show("Este mes ya se encuentra en la BD " & vbCrLf & "Si desea eliminarlo por favor vaya a la tabla de abajo")
            Return
        End If
        If Me.band = True And Me.numeroHoja = 2 Then
            Return
        End If

        idH = cH.AgregarHaberesT(c)
        c.IdHaberes = idH
        'agregar a la base de datos temporal ********************

        While Me.obHojaH.cells(i, 2).value <> Nothing
            'Validacion de datos fecha y montos
            If Not IsNumeric(Me.obHojaH.Cells(i, 3).value) Then
                MessageBox.Show("Error en monto de Haberes, verificar empleado: " & Me.obHoja.cells(i, 1).value) : Return : End If

            'TotalHaberes += CDbl(Me.obHojaH.cells(i, 3).value)
            SubtotalH += CDbl(Me.obHojaH.cells(i, 3).value)
            ' Insercion en arreglo
            'c = New clsHaberes(titulo, nomina, mes, numeronomina, Me.obHojaH.cells(i, 1).value, Me.obHojaH.cells(i, 2).value, CDbl(Me.obHojaH.cells(i, 3).value), CInt(Me.obHojaH.cells(i, 4).value))
            ce = New clsHaberesEmpleado(idH, Me.obHojaH.cells(i, 1).value, Me.obHojaH.cells(i, 2).value, CDbl(Me.obHojaH.cells(i, 3).value), CInt(Me.obHojaH.cells(i, 4).value))
            'Insertamos en base de datos
            cH.AgregarHaberesEmpleadosT(ce)
            'Me.arrHaberes.Add(c)
            arrEmpHaberes.Add(ce)
            i += 1
        End While
        c.arrEmpleadosHaberes = arrEmpHaberes
        Me.arrHaberes.Add(c)
        'Me.chkNomina.Items.Add(Hoja.ToString() & "-->" & SubtotalH.ToString())
        Me.chkNomina.Items.Add(SubtotalH.ToString())

        'MessageBox.Show("Total de Haberes: " & Me.TotalHaberes.ToString())
    End Sub

    Public Sub ObtenDatosExcelNomina()
        Dim i As Int32
        Dim c As clsNomina
        i = 2
        Me.arrDatosNomina = New ArrayList
        While Me.obHoja.cells(i, 1).value <> Nothing
            'Validacion de datos fecha y montos
            If Not IsDate(Me.obHoja.Cells(i, 4).value) Then
                MessageBox.Show("Error en fecha, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If
            If Me.obHoja.cells(i, 5).value <> Nothing And Not IsDate(Me.obHoja.cells(i, 5).value) Then
                MessageBox.Show("Error en fecha, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If
            If Not IsNumeric(Me.obHoja.cells(i, 7).value) Or Not IsNumeric(Me.obHoja.cells(i, 8).value) Or Not IsNumeric(Me.obHoja.cells(i, 9).value) Or Not IsNumeric(Me.obHoja.cells(i, 10).value) Or Not IsNumeric(Me.obHoja.cells(i, 11).value) Then
                MessageBox.Show("Error en monto, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If
            If Not IsNumeric(Me.obHoja.cells(i, 12).value) Or Not IsNumeric(Me.obHoja.cells(i, 13).value) Or Not IsNumeric(Me.obHoja.cells(i, 14).value) Or Not IsNumeric(Me.obHoja.cells(i, 15).value) Or Not IsNumeric(Me.obHoja.cells(i, 16).value) Then
                MessageBox.Show("Error en monto, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If
            If Not IsNumeric(Me.obHoja.cells(i, 17).value) Or Not IsNumeric(Me.obHoja.cells(i, 18).value) Or Not IsNumeric(Me.obHoja.cells(i, 19).value) Or Not IsNumeric(Me.obHoja.cells(i, 20).value) Or Not IsNumeric(Me.obHoja.cells(i, 21).value) Then
                MessageBox.Show("Error en monto, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If
            If Not IsNumeric(Me.obHoja.cells(i, 22).value) Or Not IsNumeric(Me.obHoja.cells(i, 23).value) Or Not IsNumeric(Me.obHoja.cells(i, 24).value) Or Not IsNumeric(Me.obHoja.cells(i, 25).value) Or Not IsNumeric(Me.obHoja.cells(i, 26).value) Then
                MessageBox.Show("Error en monto, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If
            If Not IsNumeric(Me.obHoja.cells(i, 27).value) Or Not IsNumeric(Me.obHoja.cells(i, 28).value) Or Not IsNumeric(Me.obHoja.cells(i, 29).value) Or Not IsNumeric(Me.obHoja.cells(i, 30).value) Or Not IsNumeric(Me.obHoja.cells(i, 31).value) Then
                MessageBox.Show("Error en monto, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If
            If Not IsNumeric(Me.obHoja.cells(i, 32).value) Or Not IsNumeric(Me.obHoja.cells(i, 33).value) Or Not IsNumeric(Me.obHoja.cells(i, 34).value) Or Not IsNumeric(Me.obHoja.cells(i, 35).value) Or Not IsNumeric(Me.obHoja.cells(i, 36).value) Then
                MessageBox.Show("Error en monto, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If
            If Not IsNumeric(Me.obHoja.cells(i, 37).value) Or Not IsNumeric(Me.obHoja.cells(i, 38).value) Or Not IsNumeric(Me.obHoja.cells(i, 39).value) Or Not IsNumeric(Me.obHoja.cells(i, 40).value) Or Not IsNumeric(Me.obHoja.cells(i, 41).value) Then
                MessageBox.Show("Error en monto, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If
            If Not IsNumeric(Me.obHoja.cells(i, 42).value) Or Not IsNumeric(Me.obHoja.cells(i, 43).value) Or Not IsNumeric(Me.obHoja.cells(i, 44).value) Or Not IsNumeric(Me.obHoja.cells(i, 45).value) Or Not IsNumeric(Me.obHoja.cells(i, 46).value) Then
                MessageBox.Show("Error en monto, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If
            If Not IsNumeric(Me.obHoja.cells(i, 47).value) Or Not IsNumeric(Me.obHoja.cells(i, 48).value) Or Not IsNumeric(Me.obHoja.cells(i, 49).value) Or Not IsNumeric(Me.obHoja.cells(i, 50).value) Or Not IsNumeric(Me.obHoja.cells(i, 51).value) Then
                MessageBox.Show("Error en monto, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If
            If Not IsNumeric(Me.obHoja.cells(i, 52).value) Or Not IsNumeric(Me.obHoja.cells(i, 53).value) Or Not IsNumeric(Me.obHoja.cells(i, 54).value) Or Not IsNumeric(Me.obHoja.cells(i, 55).value) Or Not IsNumeric(Me.obHoja.cells(i, 56).value) Then
                MessageBox.Show("Error en monto, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If
            If Not IsNumeric(Me.obHoja.cells(i, 57).value) Or Not IsNumeric(Me.obHoja.cells(i, 58).value) Or Not IsNumeric(Me.obHoja.cells(i, 59).value) Or Not IsNumeric(Me.obHoja.cells(i, 60).value) Or Not IsNumeric(Me.obHoja.cells(i, 61).value) Then
                MessageBox.Show("Error en monto, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If
            If Not IsNumeric(Me.obHoja.cells(i, 62).value) Or Not IsNumeric(Me.obHoja.cells(i, 63).value) Or Not IsNumeric(Me.obHoja.cells(i, 64).value) Or Not IsNumeric(Me.obHoja.cells(i, 65).value) Or Not IsNumeric(Me.obHoja.cells(i, 66).value) Then
                MessageBox.Show("Error en monto, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If
            If Not IsNumeric(Me.obHoja.cells(i, 67).value) Or Not IsNumeric(Me.obHoja.cells(i, 68).value) Or Not IsNumeric(Me.obHoja.cells(i, 69).value) Or Not IsNumeric(Me.obHoja.cells(i, 70).value) Or Not IsNumeric(Me.obHoja.cells(i, 71).value) Then
                MessageBox.Show("Error en monto, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If
            If Not IsNumeric(Me.obHoja.cells(i, 72).value) Or Not IsNumeric(Me.obHoja.cells(i, 73).value) Or Not IsNumeric(Me.obHoja.cells(i, 74).value) Or Not IsNumeric(Me.obHoja.cells(i, 75).value) Or Not IsNumeric(Me.obHoja.cells(i, 76).value) Then
                MessageBox.Show("Error en monto, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If
            If Not IsNumeric(Me.obHoja.cells(i, 77).value) Or Not IsNumeric(Me.obHoja.cells(i, 78).value) Or Not IsNumeric(Me.obHoja.cells(i, 79).value) Or Not IsNumeric(Me.obHoja.cells(i, 80).value) Or Not IsNumeric(Me.obHoja.cells(i, 81).value) Or Not IsNumeric(Me.obHoja.cells(i, 82).value) Then
                MessageBox.Show("Error en monto, verificar empleado: " & Me.obHoja.cells(i, 3).value) : Return : End If

            ' Insercion en arreglo
            c = New clsNomina(Me.obHoja.cells(i, 1).value, Me.obHoja.cells(i, 2).value, Me.obHoja.cells(i, 3).value, Me.obHoja.cells(i, 4).value, _
                              Me.obHoja.cells(i, 6).value, Me.obHoja.cells(i, 7).value, Me.obHoja.cells(i, 8).value, Me.obHoja.cells(i, 9).value, Me.obHoja.cells(i, 10).value, _
                              Me.obHoja.cells(i, 11).value, Me.obHoja.cells(i, 12).value, Me.obHoja.cells(i, 13).value, Me.obHoja.cells(i, 14).value, Me.obHoja.cells(i, 15).value, _
                              Me.obHoja.cells(i, 16).value, Me.obHoja.cells(i, 17).value, Me.obHoja.cells(i, 18).value, Me.obHoja.cells(i, 19).value, Me.obHoja.cells(i, 20).value, _
                              Me.obHoja.cells(i, 21).value, Me.obHoja.cells(i, 22).value, Me.obHoja.cells(i, 23).value, Me.obHoja.cells(i, 24).value, Me.obHoja.cells(i, 25).value, _
                              Me.obHoja.cells(i, 26).value, Me.obHoja.cells(i, 27).value, Me.obHoja.cells(i, 28).value, Me.obHoja.cells(i, 29).value, Me.obHoja.cells(i, 30).value, _
                              Me.obHoja.cells(i, 31).value, Me.obHoja.cells(i, 32).value, Me.obHoja.cells(i, 33).value, Me.obHoja.cells(i, 34).value, Me.obHoja.cells(i, 35).value, _
                              Me.obHoja.cells(i, 36).value, Me.obHoja.cells(i, 37).value, Me.obHoja.cells(i, 38).value, Me.obHoja.cells(i, 39).value, Me.obHoja.cells(i, 40).value, _
                              Me.obHoja.cells(i, 41).value, Me.obHoja.cells(i, 42).value, Me.obHoja.cells(i, 43).value, Me.obHoja.cells(i, 44).value, Me.obHoja.cells(i, 45).value, _
                              Me.obHoja.cells(i, 46).value, Me.obHoja.cells(i, 47).value, Me.obHoja.cells(i, 48).value, Me.obHoja.cells(i, 49).value, Me.obHoja.cells(i, 50).value, _
                              Me.obHoja.cells(i, 51).value, Me.obHoja.cells(i, 52).value, Me.obHoja.cells(i, 53).value, Me.obHoja.cells(i, 54).value, Me.obHoja.cells(i, 55).value, _
                              Me.obHoja.cells(i, 56).value, Me.obHoja.cells(i, 57).value, Me.obHoja.cells(i, 58).value, Me.obHoja.cells(i, 59).value, Me.obHoja.cells(i, 60).value, _
                              Me.obHoja.cells(i, 61).value, Me.obHoja.cells(i, 62).value, Me.obHoja.cells(i, 63).value, Me.obHoja.cells(i, 64).value, Me.obHoja.cells(i, 65).value, _
                              Me.obHoja.cells(i, 66).value, Me.obHoja.cells(i, 67).value, Me.obHoja.cells(i, 68).value, Me.obHoja.cells(i, 69).value, Me.obHoja.cells(i, 70).value, _
                              Me.obHoja.cells(i, 71).value, Me.obHoja.cells(i, 72).value, Me.obHoja.cells(i, 73).value, Me.obHoja.cells(i, 74).value, Me.obHoja.cells(i, 75).value, _
                              Me.obHoja.cells(i, 76).value, Me.obHoja.cells(i, 77).value, Me.obHoja.cells(i, 78).value, Me.obHoja.cells(i, 79).value, Me.obHoja.cells(i, 80).value, _
                              Me.obHoja.cells(i, 81).value, Me.obHoja.cells(i, 82).value, Me.obHoja.cells(i, 83).value, Me.obHoja.cells(i, 84).value, Me.obHoja.cells(i, 85).value, _
                              Me.obHoja.cells(i, 86).value)

            If Not Me.obHoja.cells(i, 5).value Is Nothing Then
                c.FechaBaja = CDate(Me.obHoja.cells(i, 5).value)
            End If

            Me.arrDatosNomina.Add(c)
            i += 1
        End While
    End Sub
    Public Sub ObtenDatosExcelEmpleados()
        Dim i As Int32
        Dim sexo As Int32
        Dim c As clsEmpleadoEdad
        i = 2
        Me.arrEmpleadosEdad = New ArrayList
        While Me.obHojaE.cells(i, 1).value <> Nothing
            If Me.obHojaE.cells(i, 1).value = "0" Or Me.obHojaE.cells(i, 1).value = "H" Then
                sexo = 0
            Else
                sexo = 1
            End If
            If Not IsDate(Me.obHojaE.cells(i, 2).value) Then
                MessageBox.Show("Error en fecha, verificar empleado: " & Me.obHojaE.cells(i, 3).value)
                Return
            End If
            c = New clsEmpleadoEdad(Me.obHojaE.cells(i, 3).value, Me.obHojaE.cells(i, 2).value, sexo, "")
            c.SeguroGMM = Funciones.ObtieneSeguroVida(c)
            Me.arrEmpleadosEdad.Add(c)
            i += 1
        End While
    End Sub

    Public Function ObtenerDiaVacaciones(ByVal Antiguedad As Int32) As Int32
        Select Case Antiguedad
            Case 0 : Return 6
            Case 1 : Return 8
            Case 2 : Return 10
            Case 3 : Return 12
            Case 4 : Return 14
            Case 5 To 9 : Return 16
            Case 10 To 14 : Return 18
            Case 15 To 19 : Return 20
            Case 20 To 24 : Return 22
            Case 25 To 29 : Return 22 'checar si sigue igual
        End Select
        Return 0
    End Function

    Public Function fin_del_Mes(ByVal Fecha As Object) As Date
        If IsDate(Fecha) Then
            fin_del_Mes = DateAdd("m", 1, Fecha)
            fin_del_Mes = DateSerial(Year(fin_del_Mes), Month(fin_del_Mes), 1)
            fin_del_Mes = DateAdd("d", -1, fin_del_Mes)
        End If
        Return Now()
    End Function

    Public Sub CreaCostoEstandar()
        Dim i As Int32
        Dim c As clsEstandar
        Dim FActual, FConversion, FInicio, FAlta As Date
        Dim Vacaciones, Antiguedad As Int32
        Dim SueldoAnual, Aguinaldo, Prima, IAS, PrevisionS, ImssSarInfo, PRT As Double
        Dim sgmm As Double = 0
        Dim curp As String = ""
        Dim TipoCaso As Int32
        Dim Flexible As Double
        Dim mISN As Double

        FActual = dtFechaInicial.Value
        'FConversion = fin_del_Mes(FActual)
        FConversion = DateSerial(Year(FActual), Month(FActual) + 1, 0) 'Ultimo dia del mes
        FInicio = DateSerial(Year(FActual), Month(FActual) + 0, 1) 'Primer dia del mes

        Me.arrEstandar = New ArrayList

        For i = 0 To Me.arrDatosNomina.Count - 1
            FAlta = CType(Me.arrDatosNomina(i), clsNomina).FechaAlta
            Antiguedad = DateDiff(DateInterval.Year, FAlta, FConversion)
            'Antiguedad = DateDiff("d", FAlta, FActual) \ 365
            Vacaciones = ObtenerDiaVacaciones(Antiguedad)

            SueldoAnual = CType(Me.arrDatosNomina(i), clsNomina).SueldoDiario * 30 * 12 'Sueldo Anual
            Aguinaldo = CType(Me.arrDatosNomina(i), clsNomina).SueldoDiario * 15  'Aguinaldo
            Prima = CType(Me.arrDatosNomina(i), clsNomina).SueldoDiario * Vacaciones * 0.25  'Prima Vacacional

            'Obtenemos el IAS y la Prevision social
            TipoCaso = 0 : Flexible = 0.0
            Try
                ' If CType(Me.arrDatosNomina(i), clsNomina).Empleado = CType(Me.arrEmpleadosEdad(i), clsEmpleadoEdad).TarjetaId Then
                Dim fechaMov As Date
                Dim mov As String
                fechaMov = CType(Me.arrDatosNomina(i), clsNomina).fecmov
                mov = CType(Me.arrDatosNomina(i), clsNomina).movi
                TipoCaso = CType(Me.arrDatosNomina(i), clsNomina).tipocaso2
                Flexible = CType(Me.arrDatosNomina(i), clsNomina).flexible
                'If fechaMov >= Me.dtFechaInicial.Value And fechaMov <= Me.dtFechaFinal.Value Then
                '    If mov = "R" Or mov = "B" Then
                '        TipoCaso = CType(Me.arrDatosNomina(i), clsNomina).TipoCaso
                '    End If
                'Else
                '    TipoCaso = CType(Me.arrDatosNomina(i), clsNomina).TipoCaso / NomCalculadas
                'End If
                ' Else
                ' MessageBox.Show("Error, no coinciden los numeros de empleado de ambos archivos, verificar por favor")
                ' Return
                'End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error en al obtener tipo Caso, verificar por administrador")
                Return
            End Try

            'If TipoCaso = 2 Or TipoCaso = 3 Then
            '    IAS = (CType(Me.arrDatosNomina(i), clsNomina).FlexBrutoMensual * 12.0) / Me.NomCalculadas
            '    PrevisionS = 0
            'Else
            '    IAS = 0
            '    PrevisionS = (CType(Me.arrDatosNomina(i), clsNomina).FlexBrutoMensual * 12.0) / Me.NomCalculadas
            'End If
            If TipoCaso = 2 Or TipoCaso = 3 Then
                IAS = Flexible * 12.0
                PrevisionS = 0
            Else
                IAS = 0
                PrevisionS = Flexible * 12.0
            End If
            ''termino de obtenencion de Prevision Social e IAS

            sgmm = 0 : curp = ""
            Try
                'If CType(Me.arrDatosNomina(i), clsNomina).Empleado = CType(Me.arrEmpleadosEdad(i), clsEmpleadoEdad).TarjetaId Then
                sgmm = CType(Me.arrDatosNomina(i), clsNomina).segurogmm
                curp = CType(Me.arrDatosNomina(i), clsNomina).curp
                'Else
                '    MessageBox.Show("Error, no coinciden los numeros de empleado de ambos archivos, verificar por favor")
                '    Return
                'End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error en el archivo de Edades, verificar por favor")
                Return
            End Try

            With CType(Me.arrDatosNomina(i), clsNomina)
                'IMSS-SAR-INFONAVIT  =((67.29*365)*0.204)+((Sdi*365)*0.045)+((Sdi*365)*prt)+(SI(SDI>67.29*3,((Sdi-(67.29*3))*365)*0.011,0))+((365*Sdi)*0.1015) --> Formula
                If .SDI > (226.47) Then ''70.10*3-->2015 '67.29*3=201.87 -->2014
                    ImssSarInfo = ((.SDI - (75.49 * 3.0)) * 365.0) * 0.011
                Else : ImssSarInfo = 0
                End If
                If Me.chImss.Checked Then
                    PRT = 365.0 * (Me.cRT.RT / 100.0)
                    'ImssSarInfo += 5010.4134 + (.SDI * 16.425) + (.SDI * PRT) + (.SDI * 37.0475) 'Tomando de base la Prima de Riesgo --> 2014 (67.29)
                    'ImssSarInfo += 5219.646 + (.SDI * 16.425) + (.SDI * PRT) + (.SDI * 37.0475) 'Tomando de base la Prima de Riesgo -->2015 (70.10)
                    'ImssSarInfo += 5438.5584 + (.SDI * 16.425) + (.SDI * PRT) + (.SDI * 37.0475) 'Tomando de base la Prima de Riesgo -->2016 (73.04)
                    ImssSarInfo += 5620.9854 + (.SDI * 16.425) + (.SDI * PRT) + (.SDI * 37.0475) 'Tomando de base la Prima de Riesgo -->2017 (80.04)

                    'MessageBox.Show(ImssSarInfo.ToString())
                    'ImssSarInfo += 5010.4134 + (.SDI * 16.425) + (.SDI * 1.9839575) + (.SDI * 37.0475) 'Prima de Riesgo = .54355
                    'ImssSarInfo += 5010.4134 + (.SDI * 16.425) + (.SDI * 1.825) + (.SDI * 37.0475) 'Prima de Riesgo = .5
                    'ImssSarInfo += 5010.4134 + (.SDI * 16.425) + (.SDI * 4.1268725) + (.SDI * 37.0475) 'Prima de Riesgo = 1.13065  --> Conisal Reg32 
                Else
                    ImssSarInfo = ((.ImssExcedentePatron + .ImssPrestacionesDinero + .ImssPrestacionesEspecie + .ImssIVPatronal + .ImssProvisionGuarderia + .ImssRiesgoTrabajo + .ProvisionSAR + .ProvisionInfonavit + .ImssCVPatronal + .ImssCuotaFija) / .DiasLaborables) * 12.0 * 30.0
                End If
                If Me.Centro = "4701" Or Me.Centro = "4801" Then
                    mISN = 0.02
                Else
                    mISN = 0.03
                End If
                c = New clsEstandar(.Empleado, .Nombre, 1, 1, Me.txtEmpresa.Text, .Cliente, .Puesto, 1, .FechaAlta, _
                                    Antiguedad, Vacaciones, "MXN", FConversion, FInicio, FConversion, _
                                    SueldoAnual, PrevisionS, IAS, _
                                    Aguinaldo, Prima, 0.0, _
                                    ImssSarInfo, _
                                    (SueldoAnual + Aguinaldo + Prima) * mISN, _
                                    sgmm, CDbl(Me.txtSeguro.Text), (PrevisionS + IAS) * 0.0635, 0, 0, .SDI, curp, .BonoUnico, .BonoEspecial, .BonoNegociacion)
            End With

            Me.arrEstandar.Add(c)
        Next
        CreaCostoEstandarEmpBajas()
        Me.CreaArchivoEstandar()
    End Sub
    Public Sub CreaCostoEstandarEmpBajas()
        Dim i As Int32
        Dim c As clsEstandar
        Dim FActual, FConversion, FInicio, FAlta As Date
        Dim Vacaciones, Antiguedad As Int32
        Dim SueldoAnual, Aguinaldo, Prima, IAS, PrevisionS, ImssSarInfo, PRT As Double
        Dim sgmm As Double = 0
        Dim curp As String = ""
        Dim TipoCaso As Int32
        Dim Flexible As Double
        Dim mISN As Double

        FActual = dtFechaInicial.Value
        'FConversion = fin_del_Mes(FActual)
        FConversion = DateSerial(Year(FActual), Month(FActual) + 1, 0) 'Ultimo dia del mes
        FInicio = DateSerial(Year(FActual), Month(FActual) + 0, 1) 'Primer dia del mes

        'Me.arrEstandar = New ArrayList

        For i = 0 To Me.arrEmpleadosBaja.Count - 1
            With CType(Me.arrEmpleadosBaja(i), clsEmpleadoBaja)
                If Not .NominaActual Then
                    Try
                        FAlta = .NominaEmpleado.FechaAlta
                        Antiguedad = DateDiff(DateInterval.Year, FAlta, FConversion)
                        'Antiguedad = DateDiff("d", FAlta, FActual) \ 365
                        Vacaciones = ObtenerDiaVacaciones(Antiguedad)

                        SueldoAnual = .NominaEmpleado.SueldoDiario * 30 * 12 'Sueldo Anual
                        Aguinaldo = .NominaEmpleado.SueldoDiario * 15  'Aguinaldo
                        Prima = .NominaEmpleado.SueldoDiario * Vacaciones * 0.25  'Prima Vacacional

                        'Obtenemos el IAS y la Prevision social
                        TipoCaso = CType(Me.arrDatosNomina(i), clsNomina).tipocaso2
                        Flexible = CType(Me.arrDatosNomina(i), clsNomina).flexible
                        If TipoCaso = 2 Or TipoCaso = 3 Then
                            'If .NominaEmpleado.TipoCaso = 2 Or .NominaEmpleado.TipoCaso = 3 Then
                            IAS = Flexible * 12.0
                            PrevisionS = 0
                        Else
                            IAS = 0
                            PrevisionS = Flexible * 12.0
                        End If

                        sgmm = 0 : curp = ""
                        Try
                            ' .NominaEmpleado.Empleado = CType(Me.arrDatosNomina(i), clsNomina).TarjetaId Then
                            sgmm = CType(Me.arrDatosNomina(i), clsNomina).segurogmm
                            curp = CType(Me.arrDatosNomina(i), clsNomina).curp
                            'Else
                            '    MessageBox.Show("Error, no coinciden los numeros de empleado de ambos archivos, verificar por favor")
                            '    Return
                            'End If
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error en el archivo de Edades, verificar por favor")
                            Return
                        End Try

                        With .NominaEmpleado
                            'IMSS-SAR-INFONAVIT
                            If .SDI > (226.47) Then
                                ImssSarInfo = ((.SDI - (75.49 * 3.0)) * 365.0) * 0.011
                            Else : ImssSarInfo = 0
                            End If

                            If Me.chImss.Checked Then
                                PRT = 365.0 * (Me.cRT.RT / 100.0)
                                'ImssSarInfo += 5010.4134 + (.SDI * 16.425) + (.SDI * PRT) + (.SDI * 37.0475) 'Tomando de base la Prima de Riesgo -->2014
                                'ImssSarInfo += 5219.646 + (.SDI * 16.425) + (.SDI * PRT) + (.SDI * 37.0475) 'Tomando de base la Prima de Riesgo -->2015 (70.10)
                                'ImssSarInfo += 5438.5584 + (.SDI * 16.425) + (.SDI * PRT) + (.SDI * 37.0475) 'Tomando de base la Prima de Riesgo -->2016 (73.04)
                                ImssSarInfo += 5620.9854 + (.SDI * 16.425) + (.SDI * PRT) + (.SDI * 37.0475) 'Tomando de base la Prima de Riesgo -->2017 (80.04)
                            Else
                                ImssSarInfo = ((.ImssExcedentePatron + .ImssPrestacionesDinero + .ImssPrestacionesEspecie + .ImssIVPatronal + .ImssProvisionGuarderia + .ImssRiesgoTrabajo + .ProvisionSAR + .ProvisionInfonavit + .ImssCVPatronal + .ImssCuotaFija) / .DiasLaborables) * 12.0 * 30.0
                            End If
                            If Me.Centro = "4701" Or Me.Centro = "4801" Then
                                mISN = 0.02
                            Else
                                mISN = 0.03
                            End If
                            c = New clsEstandar(.Empleado, .Nombre, 1, 1, Me.txtEmpresa.Text, .Cliente, .Puesto, 1, .FechaAlta, _
                                                Antiguedad, Vacaciones, "MXN", FConversion, FInicio, FConversion, _
                                                SueldoAnual, PrevisionS, IAS, _
                                                Aguinaldo, Prima, 0.0, _
                                                ImssSarInfo, _
                                                (SueldoAnual + Aguinaldo + Prima) * mISN, _
                                                sgmm, CDbl(Me.txtSeguro.Text), (PrevisionS + IAS) * 0.0635, 0, 0, .SDI, curp, .BonoUnico, .BonoEspecial, .BonoNegociacion)
                        End With
                    Catch ex As Exception
                        MessageBox.Show("Revisar este empleado pues no tiene nomina pasada y no sera agregado a la nomina: " + .TarjetaID)
                    End Try
                    If Not c Is Nothing Then
                        Me.arrEstandar.Add(c)
                    End If
                End If
            End With

        Next
    End Sub
    Public Sub CreaCostoReal()
        Dim i As Int32
        Dim c As clsReal
        Dim FActual, FConversion, FInicio, FAlta As Date
        Dim Vacaciones, Antiguedad As Int32
        Dim sgmm As Double = 0
        Dim FiniqPrimaVacE As Double = 0
        Dim FiniqPrimaVacG As Double = 0
        Dim FiniqAguinaldoE As Double = 0
        Dim FiniqAguinaldoG As Double = 0
        Dim SalarioFlex As Double = 0 'Salario Diario del Esquema Flexible

        FActual = dtFechaInicial.Value
        'FConversion = fin_del_Mes(FActual)
        FConversion = DateSerial(Year(FActual), Month(FActual) + 1, 0) 'Ultimo dia del mes
        FInicio = DateSerial(Year(FActual), Month(FActual) + 0, 1) 'Primer dia del mes

        Me.arrReal = New ArrayList

        For i = 0 To Me.arrDatosNomina.Count - 1
            FAlta = CType(Me.arrDatosNomina(i), clsNomina).FechaAlta
            Antiguedad = DateDiff(DateInterval.Year, FAlta, FConversion)
            'Antiguedad = DateDiff("d", FAlta, FActual) \ 365
            Vacaciones = ObtenerDiaVacaciones(Antiguedad)
            sgmm = 0 : FiniqPrimaVacE = 0 : FiniqPrimaVacG = 0 : FiniqAguinaldoE = 0 : FiniqAguinaldoG = 0
            SalarioFlex = 0
            Try
                'If CType(Me.arrDatosNomina(i), clsNomina).Empleado = CType(Me.arrEmpleadosEdad(i), clsEmpleadoEdad).TarjetaId Then
                sgmm = CType(Me.arrDatosNomina(i), clsNomina).segurogmm
                SalarioFlex = (CType(Me.arrDatosNomina(i), clsNomina).flexible) / 30.0
                'Else
                '    MessageBox.Show("Error, no coinciden los numeros de empleado de ambos archivos, verificar por favor")
                '    Return
                'End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error en el archivo de Edades, verificar por favor")
                Return
            End Try
            With CType(Me.arrDatosNomina(i), clsNomina)
                If .PrimaVacacionalFiniquito <= (.SueldoDiario * 15.0) Then
                    FiniqPrimaVacE = .PrimaVacacionalFiniquito
                    FiniqPrimaVacG = 0
                Else
                    FiniqPrimaVacE = .SueldoDiario * 15.0
                    FiniqPrimaVacG = .PrimaVacacionalAni - FiniqPrimaVacE
                End If
                If .AguinaldoFiniquito <= (.SueldoDiario * 30.0) Then
                    FiniqAguinaldoE = .AguinaldoFiniquito
                    FiniqAguinaldoG = 0
                Else
                    FiniqAguinaldoE = .SueldoDiario * 30.0
                    FiniqAguinaldoG = .AguinaldoAnual - FiniqAguinaldoE
                End If
                c = New clsReal(.Empleado, .Nombre, 1, 1, Me.txtEmpresa.Text, .Cliente, .Puesto, 1, "MXN", FConversion, _
                                 FInicio, FConversion, .Sueldo + .RetroactivoSueldo, .SubEg1_3Dias, .SubEg4_Adelante, 0, 0, .NegociacionGravada, _
                                 .PsDiasLaborados + .PsRetroactivo, _
                                 .FlexBono + .FlexBonoNegociacion + .FlexBonoEspecial, _
                                 .IasDiasLaborados + .IasDiasPendientes, .FlexSubsidiosIncap, .SubsidioEmpleoPagado, 0, 0, 0, 0, .AguinaldoAnual, _
                                 .VacacionesFiniquito, .PrimaVacacionalAni, FiniqPrimaVacE, FiniqPrimaVacG, FiniqAguinaldoE, FiniqAguinaldoG, .PTU, .PrimaAnt12Dias, .Indemnizacion3Meses, _
                                 .Indemnizacion20Dias, .IMSS + .ImssObrero, _
                                 .DescCreditoInfonavit, .AjusteDifCredInfonavit, 0, 0, .OtrosDescuentos, 0, 0, 0, .OtrasDeducciones, .Fonacot, _
                                 .ImpuestoRetenido, _
                                 .ImpuestoIndemnizacion, .ISR_AjusteAnual177, .DescPensionAlimenticia, _
                                 (.DiasLaborables / 365.0) * .SueldoDiario * 15.0, _
                                 ((.DiasLaborables / 365.0) * Vacaciones) * 0.25 * .SueldoDiario, _
                                 .ISN, _
                                 .ImssExcedentePatron + .ImssPrestacionesDinero + .ImssPrestacionesEspecie + .ImssIVPatronal + .ImssProvisionGuarderia + .ImssRiesgoTrabajo + .ImssCuotaFija, _
                                 .ProvisionSAR + .ProvisionInfonavit + .ImssCVPatronal, _
                                 sgmm / 12.0, CDbl(Me.txtSeguro.Text) / 12.0, .IVA, .ComisionNomina, 0, 0, .SueldoDiario, SalarioFlex)
            End With
            Me.arrReal.Add(c)
        Next
        Me.CreaArchivoReal()
    End Sub

    Public Sub CreaArchivoEstandar()
        Dim oExcel As Object 'Excel.ApplicationClass
        Dim oBooks As Object 'Excel.Workbooks
        Dim oBook As Object 'Excel.WorkbookClass
        Dim oSheet As Object 'Excel.Worksheet

        ' Inicia Excel y abre el workbook
        oExcel = CreateObject("Excel.Application")
        oExcel.Visible = True
        oBooks = oExcel.Workbooks
        oBook = oExcel.Workbooks.Add
        oSheet = oBook.Sheets(1)

        'oBook = oBooks.Open("C:\DevCare\DevCareExcelAutomation\Data.xls")

        Const ROW_FIRST = 1
        Dim iRow As Int64 = 1
        Dim j As Int32

        ' Encabezado
        oSheet.Cells(ROW_FIRST, 1) = "Tarjeta_id"
        'oSheet.Cells(ROW_FIRST, 2) = "Nombre"
        'oSheet.Cells(ROW_FIRST, 3) = "IDEmp"
        'oSheet.Cells(ROW_FIRST, 4) = "IDIntel"

        oSheet.Cells(ROW_FIRST, 2) = "IDEmp"
        oSheet.Cells(ROW_FIRST, 3) = "IDIntel"
        oSheet.Cells(ROW_FIRST, 4) = "Nombre"
        oSheet.Cells(ROW_FIRST, 5) = "Empresa"
        oSheet.Cells(ROW_FIRST, 6) = "Depto"
        oSheet.Cells(ROW_FIRST, 7) = "Puesto"
        oSheet.Cells(ROW_FIRST, 8) = "CENTROCOSTOS"
        oSheet.Cells(ROW_FIRST, 9) = "FechaAnt"
        oSheet.Cells(ROW_FIRST, 10) = "AntAños"
        oSheet.Cells(ROW_FIRST, 11) = "Vacaciones"
        oSheet.Cells(ROW_FIRST, 12) = "Moneda"
        oSheet.Cells(ROW_FIRST, 13) = "FechaConversion"
        oSheet.Cells(ROW_FIRST, 14) = "Inicio"
        oSheet.Cells(ROW_FIRST, 15) = "Final"
        oSheet.Cells(ROW_FIRST, 16) = "SALARIOANUAL"
        oSheet.Cells(ROW_FIRST, 17) = "PREVISION"
        oSheet.Cells(ROW_FIRST, 18) = "IAS"
        oSheet.Cells(ROW_FIRST, 19) = "AGUINALDO"
        oSheet.Cells(ROW_FIRST, 20) = "PRIMA"
        oSheet.Cells(ROW_FIRST, 21) = "BONO"
        oSheet.Cells(ROW_FIRST, 22) = "IMSSSARINFONAVIT"
        oSheet.Cells(ROW_FIRST, 23) = "ISN"
        oSheet.Cells(ROW_FIRST, 24) = "SGMM"
        oSheet.Cells(ROW_FIRST, 25) = "SVA"
        oSheet.Cells(ROW_FIRST, 26) = "COMISION"
        oSheet.Cells(ROW_FIRST, 27) = "D3"
        oSheet.Cells(ROW_FIRST, 28) = "PROVISIONBONO"
        oSheet.Cells(ROW_FIRST, 29) = "SDI"
        oSheet.Cells(ROW_FIRST, 30) = "CURP"
        oSheet.cells(ROW_FIRST, 31) = "BONO UNICO"
        oSheet.cells(ROW_FIRST, 32) = "BONO ESPECIAL"
        oSheet.cellS(ROW_FIRST, 33) = "BONO NEGOCIACION"
        oSheet.Cells(ROW_FIRST, 1).font.bold = True
        oSheet.Cells(ROW_FIRST, 2).font.bold = True
        oSheet.Cells(ROW_FIRST, 3).font.bold = True
        oSheet.Cells(ROW_FIRST, 4).font.bold = True
        oSheet.Cells(ROW_FIRST, 5).font.bold = True
        oSheet.Cells(ROW_FIRST, 6).font.bold = True
        oSheet.Cells(ROW_FIRST, 7).font.bold = True
        oSheet.Cells(ROW_FIRST, 8).font.bold = True
        oSheet.Cells(ROW_FIRST, 9).font.bold = True
        oSheet.Cells(ROW_FIRST, 10).font.bold = True
        oSheet.Cells(ROW_FIRST, 11).font.bold = True
        oSheet.Cells(ROW_FIRST, 12).font.bold = True
        oSheet.Cells(ROW_FIRST, 13).font.bold = True
        oSheet.Cells(ROW_FIRST, 14).font.bold = True
        oSheet.Cells(ROW_FIRST, 15).font.bold = True
        oSheet.Cells(ROW_FIRST, 16).font.bold = True
        oSheet.Cells(ROW_FIRST, 17).font.bold = True
        oSheet.Cells(ROW_FIRST, 18).font.bold = True
        oSheet.Cells(ROW_FIRST, 19).font.bold = True
        oSheet.Cells(ROW_FIRST, 20).font.bold = True
        oSheet.Cells(ROW_FIRST, 21).font.bold = True
        oSheet.Cells(ROW_FIRST, 22).font.bold = True
        oSheet.Cells(ROW_FIRST, 23).font.bold = True
        oSheet.Cells(ROW_FIRST, 24).font.bold = True
        oSheet.Cells(ROW_FIRST, 25).font.bold = True
        oSheet.Cells(ROW_FIRST, 26).font.bold = True
        oSheet.Cells(ROW_FIRST, 27).font.bold = True
        oSheet.Cells(ROW_FIRST, 28).font.bold = True
        oSheet.Cells(ROW_FIRST, 29).font.bold = True
        oSheet.Cells(ROW_FIRST, 30).font.bold = True
        oSheet.Cells(ROW_FIRST, 31).font.bold = True
        oSheet.Cells(ROW_FIRST, 32).font.bold = True
        oSheet.Cells(ROW_FIRST, 33).font.bold = True
        Dim iCurrRow As Int64
        For i = 0 To Me.arrDatosNomina.Count - 1
            iCurrRow = ROW_FIRST + iRow
            If CType(Me.arrDatosNomina(i), clsNomina).FechaBaja.HasValue Then
                oSheet.Cells(iCurrRow, 1).font.color = 250 : oSheet.Cells(iCurrRow, 2).font.color = 250 : oSheet.Cells(iCurrRow, 3).font.color = 250 : oSheet.Cells(iCurrRow, 4).font.color = 250 : oSheet.Cells(iCurrRow, 5).font.color = 250
                oSheet.Cells(iCurrRow, 6).font.color = 250 : oSheet.Cells(iCurrRow, 7).font.color = 250 : oSheet.Cells(iCurrRow, 8).font.color = 250 : oSheet.Cells(iCurrRow, 9).font.color = 250 : oSheet.Cells(iCurrRow, 10).font.color = 250
                oSheet.Cells(iCurrRow, 11).font.color = 250 : oSheet.Cells(iCurrRow, 12).font.color = 250 : oSheet.Cells(iCurrRow, 13).font.color = 250 : oSheet.Cells(iCurrRow, 14).font.color = 250 : oSheet.Cells(iCurrRow, 15).font.color = 250
                oSheet.Cells(iCurrRow, 16).font.color = 250 : oSheet.Cells(iCurrRow, 17).font.color = 250 : oSheet.Cells(iCurrRow, 18).font.color = 250 : oSheet.Cells(iCurrRow, 19).font.color = 250 : oSheet.Cells(iCurrRow, 20).font.color = 250
                oSheet.Cells(iCurrRow, 21).font.color = 250 : oSheet.Cells(iCurrRow, 22).font.color = 250 : oSheet.Cells(iCurrRow, 23).font.color = 250 : oSheet.Cells(iCurrRow, 24).font.color = 250 : oSheet.Cells(iCurrRow, 25).font.color = 250
                oSheet.Cells(iCurrRow, 26).font.color = 250 : oSheet.Cells(iCurrRow, 27).font.color = 250 : oSheet.Cells(iCurrRow, 28).font.color = 250 : oSheet.Cells(iCurrRow, 29).font.color = 250 : oSheet.Cells(iCurrRow, 30).font.color = 250
                oSheet.Cells(iCurrRow, 31).font.color = 250 : oSheet.Cells(iCurrRow, 32).font.color = 250 : oSheet.Cells(iCurrRow, 33).font.color = 250
            End If

            Dim fechaMov As Date
            Dim mov As String
            fechaMov = CType(Me.arrDatosNomina(i), clsNomina).fecmov : mov = CType(Me.arrDatosNomina(i), clsNomina).movi
            If fechaMov >= Me.dtFechaInicial.Value And fechaMov <= Me.dtFechaFinal.Value Then
                If mov = "R" Then 'Empleados con reinreso
                    oSheet.Cells(iCurrRow, 1).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 2).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 3).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 4).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 5).font.color = RGB(0, 100, 250)
                    oSheet.Cells(iCurrRow, 6).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 7).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 8).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 9).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 10).font.color = RGB(0, 100, 250)
                    oSheet.Cells(iCurrRow, 11).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 12).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 13).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 14).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 15).font.color = RGB(0, 100, 250)
                    oSheet.Cells(iCurrRow, 16).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 17).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 18).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 19).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 20).font.color = RGB(0, 100, 250)
                    oSheet.Cells(iCurrRow, 21).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 22).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 23).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 24).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 25).font.color = RGB(0, 100, 250)
                    oSheet.Cells(iCurrRow, 26).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 27).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 28).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 29).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 30).font.color = RGB(0, 100, 250)
                    oSheet.Cells(iCurrRow, 31).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 32).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow, 33).font.color = RGB(0, 100, 250)
                End If
            End If
            With CType(Me.arrEstandar(i), clsEstandar)
                oSheet.Cells(iCurrRow, 1) = .IdEmpleado
                oSheet.Cells(iCurrRow, 2) = Me.Empresa
                oSheet.Cells(iCurrRow, 3) = Me.EmpIntel
                oSheet.Cells(iCurrRow, 4) = .Nombre
                oSheet.Cells(iCurrRow, 5) = .RegistroPatronal
                oSheet.Cells(iCurrRow, 6) = .Departamento
                oSheet.Cells(iCurrRow, 7) = .Puesto
                oSheet.Cells(iCurrRow, 8) = .CentroCosto
                oSheet.Cells(iCurrRow, 9) = Me.ConvierteFechaCadena(.FechaAntiguedad)
                oSheet.Cells(iCurrRow, 10) = .Antiguedad
                oSheet.Cells(iCurrRow, 11) = .DiasVacaciones
                oSheet.Cells(iCurrRow, 12) = .Moneda
                oSheet.Cells(iCurrRow, 13) = Me.ConvierteFechaCadena(.FechaConversion)
                oSheet.Cells(iCurrRow, 14) = Me.ConvierteFechaCadena(.FechaInicio)
                oSheet.Cells(iCurrRow, 15) = Me.ConvierteFechaCadena(.FechaFin)
                oSheet.Cells(iCurrRow, 16) = Math.Round(.SueldoAnual, 2)
                oSheet.Cells(iCurrRow, 17) = Math.Round(.PrevisionSocial, 2)
                oSheet.Cells(iCurrRow, 18) = Math.Round(.Ias, 2)
                oSheet.Cells(iCurrRow, 19) = Math.Round(.AguinaldoAnual, 2)
                oSheet.Cells(iCurrRow, 20) = Math.Round(.PrimaVacAnual, 2)
                oSheet.Cells(iCurrRow, 21) = Math.Round(.BonoAnual, 2)
                oSheet.Cells(iCurrRow, 22) = Math.Round(.ImssSarInfonavitAnual, 2)
                oSheet.Cells(iCurrRow, 23) = Math.Round(.Isn, 2) 'oSheet.Cells(iCurrRow, 23) = .Isn
                oSheet.Cells(iCurrRow, 24) = Math.Round(.Sgmm, 2)
                oSheet.Cells(iCurrRow, 25) = Math.Round(.SeguroVida, 2)
                oSheet.Cells(iCurrRow, 26) = Math.Round(.ComisionNomina, 2)
                oSheet.Cells(iCurrRow, 27) = Math.Round(.D3, 2)
                oSheet.Cells(iCurrRow, 28) = Math.Round(.ProvisionBono, 2)
                oSheet.Cells(iCurrRow, 29) = Math.Round(.SDI, 2)
                oSheet.Cells(iCurrRow, 30) = .Curp
                oSheet.Cells(iCurrRow, 31) = .Bono_Unico
                oSheet.CELLS(iCurrRow, 32) = .Bono_Especial
                oSheet.CELLS(iCurrRow, 33) = .Bono_Negociacion

            End With
            iRow += 1
            j = i + 1
        Next
        For i = j To Me.arrEstandar.Count - 1
            iCurrRow = ROW_FIRST + iRow
            oSheet.Cells(iCurrRow, 1).font.color = 100 : oSheet.Cells(iCurrRow, 2).font.color = 100 : oSheet.Cells(iCurrRow, 3).font.color = 100 : oSheet.Cells(iCurrRow, 4).font.color = 100 : oSheet.Cells(iCurrRow, 5).font.color = 100
            oSheet.Cells(iCurrRow, 6).font.color = 100 : oSheet.Cells(iCurrRow, 7).font.color = 100 : oSheet.Cells(iCurrRow, 8).font.color = 100 : oSheet.Cells(iCurrRow, 9).font.color = 100 : oSheet.Cells(iCurrRow, 10).font.color = 100
            oSheet.Cells(iCurrRow, 11).font.color = 100 : oSheet.Cells(iCurrRow, 12).font.color = 100 : oSheet.Cells(iCurrRow, 13).font.color = 100 : oSheet.Cells(iCurrRow, 14).font.color = 100 : oSheet.Cells(iCurrRow, 15).font.color = 100
            oSheet.Cells(iCurrRow, 16).font.color = 100 : oSheet.Cells(iCurrRow, 17).font.color = 100 : oSheet.Cells(iCurrRow, 18).font.color = 100 : oSheet.Cells(iCurrRow, 19).font.color = 100 : oSheet.Cells(iCurrRow, 20).font.color = 100
            oSheet.Cells(iCurrRow, 21).font.color = 100 : oSheet.Cells(iCurrRow, 22).font.color = 100 : oSheet.Cells(iCurrRow, 23).font.color = 100 : oSheet.Cells(iCurrRow, 24).font.color = 100 : oSheet.Cells(iCurrRow, 25).font.color = 100
            oSheet.Cells(iCurrRow, 26).font.color = 100 : oSheet.Cells(iCurrRow, 27).font.color = 100 : oSheet.Cells(iCurrRow, 28).font.color = 100 : oSheet.Cells(iCurrRow, 29).font.color = 100 : oSheet.Cells(iCurrRow, 30).font.color = 100
            oSheet.Cells(iCurrRow, 31).font.color = 100 : oSheet.Cells(iCurrRow, 32).font.color = 100 : oSheet.Cells(iCurrRow, 33).font.color = 100
            With CType(Me.arrEstandar(i), clsEstandar)
                oSheet.Cells(iCurrRow, 1) = .IdEmpleado
                oSheet.Cells(iCurrRow, 2) = Me.Empresa
                oSheet.Cells(iCurrRow, 3) = Me.EmpIntel
                oSheet.Cells(iCurrRow, 4) = .Nombre
                oSheet.Cells(iCurrRow, 5) = .RegistroPatronal
                oSheet.Cells(iCurrRow, 6) = .Departamento
                oSheet.Cells(iCurrRow, 7) = .Puesto
                oSheet.Cells(iCurrRow, 8) = .CentroCosto
                oSheet.Cells(iCurrRow, 9) = Me.ConvierteFechaCadena(.FechaAntiguedad)
                oSheet.Cells(iCurrRow, 10) = .Antiguedad
                oSheet.Cells(iCurrRow, 11) = .DiasVacaciones
                oSheet.Cells(iCurrRow, 12) = .Moneda
                oSheet.Cells(iCurrRow, 13) = Me.ConvierteFechaCadena(.FechaConversion)
                oSheet.Cells(iCurrRow, 14) = Me.ConvierteFechaCadena(.FechaInicio)
                oSheet.Cells(iCurrRow, 15) = Me.ConvierteFechaCadena(.FechaFin)
                oSheet.Cells(iCurrRow, 16) = Math.Round(.SueldoAnual, 2)
                oSheet.Cells(iCurrRow, 17) = Math.Round(.PrevisionSocial, 2)
                oSheet.Cells(iCurrRow, 18) = Math.Round(.Ias, 2)
                oSheet.Cells(iCurrRow, 19) = Math.Round(.AguinaldoAnual, 2)
                oSheet.Cells(iCurrRow, 20) = Math.Round(.PrimaVacAnual, 2)
                oSheet.Cells(iCurrRow, 21) = Math.Round(.BonoAnual, 2)
                oSheet.Cells(iCurrRow, 22) = Math.Round(.ImssSarInfonavitAnual, 2)
                oSheet.Cells(iCurrRow, 23) = Math.Round(.Isn, 2) 'oSheet.Cells(iCurrRow, 23) = .Isn
                oSheet.Cells(iCurrRow, 24) = Math.Round(.Sgmm, 2)
                oSheet.Cells(iCurrRow, 25) = Math.Round(.SeguroVida, 2)
                oSheet.Cells(iCurrRow, 26) = Math.Round(.ComisionNomina, 2)
                oSheet.Cells(iCurrRow, 27) = Math.Round(.D3, 2)
                oSheet.Cells(iCurrRow, 28) = Math.Round(.ProvisionBono, 2)
                oSheet.Cells(iCurrRow, 29) = Math.Round(.SDI, 2)
                oSheet.Cells(iCurrRow, 30) = .Curp
                oSheet.Cells(iCurrRow, 31) = .Bono_Unico
                oSheet.Cells(iCurrRow, 32) = .Bono_Especial
                oSheet.Cells(iCurrRow, 33) = .Bono_Negociacion
            End With
            iRow += 1
        Next
        'iCurrRow += 1
        oSheet.Cells(iCurrRow + 1, 2).font.bold = True : oSheet.Cells(iCurrRow + 1, 16).font.bold = True : oSheet.Cells(iCurrRow + 1, 17).font.bold = True : oSheet.Cells(iCurrRow + 1, 18).font.bold = True
        oSheet.Cells(iCurrRow + 1, 19).font.bold = True : oSheet.Cells(iCurrRow + 1, 20).font.bold = True : oSheet.Cells(iCurrRow + 1, 21).font.bold = True : oSheet.Cells(iCurrRow + 1, 22).font.bold = True
        oSheet.Cells(iCurrRow + 1, 23).font.bold = True : oSheet.Cells(iCurrRow + 1, 24).font.bold = True : oSheet.Cells(iCurrRow + 1, 25).font.bold = True : oSheet.Cells(iCurrRow + 1, 26).font.bold = True

        oSheet.Cells(iCurrRow + 1, 2).Formula = "NO. EMPLEADOS = " & Me.arrEstandar.Count.ToString()
        oSheet.Cells(iCurrRow + 1, 16).Formula = "=SUMA(P2:P" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 17).Formula = "=SUMA(Q2:Q" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 18).Formula = "=SUMA(R2:R" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 19).Formula = "=SUMA(S2:S" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 20).Formula = "=SUMA(T2:T" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 21).Formula = "=SUMA(U2:U" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 22).Formula = "=SUMA(V2:V" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 23).Formula = "=SUMA(W2:W" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 24).Formula = "=SUMA(X2:X" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 25).Formula = "=SUMA(Y2:Y" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 26).Formula = "=SUMA(Z2:Z" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 27).Formula = "=SUMA(AA2:AA" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 28).Formula = "=SUMA(AB2:AB" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 29).Formula = "=SUMA(AC2:AC" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 31).Formula = "=SUMA(AD2:AD" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 32).Formula = "=SUMA(AE2:AE" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 33).Formula = "=SUMA(AF2:AF" & iCurrRow.ToString() & ")"

        oSheet.Cells(iCurrRow + 4, 2).font.italic = True : oSheet.Cells(iCurrRow + 4, 2).font.color = 250 : oSheet.Cells(iCurrRow + 4, 2) = "*Empleados dados de baja"
        oSheet.Cells(iCurrRow + 5, 2).font.italic = True : oSheet.Cells(iCurrRow + 5, 2).font.color = 100 : oSheet.Cells(iCurrRow + 5, 2) = "*Empleados dados de baja y que no estan en la nomina actual, sino que son tomados de la nomina pasada"
        oSheet.Cells(iCurrRow + 6, 2).font.italic = True : oSheet.Cells(iCurrRow + 6, 2).font.color = RGB(0, 100, 250) : oSheet.Cells(iCurrRow + 6, 2) = "*Empleados con Reingreso"
        oSheet.Cells(iCurrRow + 7, 2).font.italic = True : oSheet.Cells(iCurrRow + 7, 2) = "*Recuerde tener actualizado la prima de riesgo de cada centro en Sicoss"
        oSheet.Cells(iCurrRow + 8, 2).font.italic = True : oSheet.Cells(iCurrRow + 8, 2) = "*El sexo y fecha de nacimiento son tomados del CURP de cada empleado"


        '' Cierra todo
        'oBook.Close(True)
        'System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook)
        'oBook = Nothing
        'System.Runtime.InteropServices.Marshal.ReleaseComObject(oBooks)
        'oBooks = Nothing
        'oExcel.Quit()
        'System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel)
        'oExcel = Nothing

        Me.GeneraArchivoE("NominaE_" + Me.Centro)
    End Sub
    Public Sub CreaArchivoReal()
        Dim oExcel As Object 'Excel.ApplicationClass
        Dim oBooks As Object 'Excel.Workbooks
        Dim oBook As Object 'Excel.WorkbookClass
        Dim oSheet As Object 'Excel.Worksheet

        ' Inicia Excel y abre el workbook
        oExcel = CreateObject("Excel.Application")
        oExcel.Visible = True
        oBooks = oExcel.Workbooks
        oBook = oExcel.Workbooks.Add
        oSheet = oBook.Sheets(1)

        'oBook = oBooks.Open("C:\DevCare\DevCareExcelAutomation\Data.xls")

        Const ROW_FIRST = 1
        Dim iRow As Int64 = 1

        ' Encabezado
        oSheet.Cells(ROW_FIRST, 1) = "tarjeta_id"
        oSheet.Cells(ROW_FIRST, 2) = "IDEMPRESA"
        oSheet.Cells(ROW_FIRST, 3) = "IDEMPRESAINTELISIS"
        oSheet.Cells(ROW_FIRST, 4) = "NOMBRE"
        oSheet.Cells(ROW_FIRST, 5) = "EMPRESA"
        oSheet.Cells(ROW_FIRST, 6) = "DEPARTAMENTO"
        oSheet.Cells(ROW_FIRST, 7) = "PUESTO"
        oSheet.Cells(ROW_FIRST, 8) = "CENTRODECOSTOS"
        oSheet.Cells(ROW_FIRST, 9) = "MONEDA"
        oSheet.Cells(ROW_FIRST, 10) = "FECHACONVERSION"
        oSheet.Cells(ROW_FIRST, 11) = "FECHAINICIO"
        oSheet.Cells(ROW_FIRST, 12) = "FECHAFINAL"
        oSheet.Cells(ROW_FIRST, 13) = "SUELDO"
        oSheet.Cells(ROW_FIRST, 14) = "SUB_EG_3"
        oSheet.Cells(ROW_FIRST, 15) = "SUB_EG_4"
        oSheet.Cells(ROW_FIRST, 16) = "SubsidioMaternidad"
        oSheet.Cells(ROW_FIRST, 17) = "Bonosunico"
        oSheet.Cells(ROW_FIRST, 18) = "NEGOCIACIONGRAVADA"
        oSheet.Cells(ROW_FIRST, 19) = "PS"
        oSheet.Cells(ROW_FIRST, 20) = "BOno_PS"
        oSheet.Cells(ROW_FIRST, 21) = "IAS"
        oSheet.Cells(ROW_FIRST, 22) = "FlexiblesSubsidiosIncap"
        oSheet.Cells(ROW_FIRST, 23) = "SUBSIDIOALEMPLEO"
        oSheet.Cells(ROW_FIRST, 24) = "PRIMADOMINICAL"
        oSheet.Cells(ROW_FIRST, 25) = "DESCANSOLABORADO"
        oSheet.Cells(ROW_FIRST, 26) = "HorasExtra"
        oSheet.Cells(ROW_FIRST, 27) = "HorasExtraTriples"
        oSheet.Cells(ROW_FIRST, 28) = "AGUINALDO"
        oSheet.Cells(ROW_FIRST, 29) = "FiniquitoVacaciones"
        oSheet.Cells(ROW_FIRST, 30) = "PRIMAVAC"
        oSheet.Cells(ROW_FIRST, 31) = "FiniquitoPrimaVacEXCENTO"
        oSheet.Cells(ROW_FIRST, 32) = "FiniquitoPrimaVacGRAVADO"
        oSheet.Cells(ROW_FIRST, 33) = "FiniquitoAGUINALDOEXCENTO"
        oSheet.Cells(ROW_FIRST, 34) = "FiniquitoAGUINALDOGRAVADO"
        oSheet.Cells(ROW_FIRST, 35) = "PTU"
        oSheet.Cells(ROW_FIRST, 36) = "LiquidacionPrimaAntigüedad"
        oSheet.Cells(ROW_FIRST, 37) = "Liquidación3Meses"
        oSheet.Cells(ROW_FIRST, 38) = "Liquidación20DíasporAño"
        oSheet.Cells(ROW_FIRST, 39) = "CuotaIMSS"
        oSheet.Cells(ROW_FIRST, 40) = "CREDITOINFONA"
        oSheet.Cells(ROW_FIRST, 41) = "AJUSTECREDITOIN"
        oSheet.Cells(ROW_FIRST, 42) = "DESCUENTOCOMEDOR"
        oSheet.Cells(ROW_FIRST, 43) = "FONDODEAHORRO"
        oSheet.Cells(ROW_FIRST, 44) = "DescuentoOtro"
        oSheet.Cells(ROW_FIRST, 45) = "DescuentoSeguroGMM"
        oSheet.Cells(ROW_FIRST, 46) = "DescuentoEQUIPOCOMPUTO"
        oSheet.Cells(ROW_FIRST, 47) = "PRESTAMOpersonal"
        oSheet.Cells(ROW_FIRST, 48) = "OTRASDEDUCCIONES"
        oSheet.Cells(ROW_FIRST, 49) = "FONACOT"
        oSheet.Cells(ROW_FIRST, 50) = "ISR"
        oSheet.Cells(ROW_FIRST, 51) = "ISRFINIQUITO"
        oSheet.Cells(ROW_FIRST, 52) = "DIFERENCIAISRAJUSTE"
        oSheet.Cells(ROW_FIRST, 53) = "PENSIONALIMENTICIA"
        oSheet.Cells(ROW_FIRST, 54) = "PROVISIONAGUINALDO"
        oSheet.Cells(ROW_FIRST, 55) = "PROVISIONPRIMAVAC"
        oSheet.Cells(ROW_FIRST, 56) = "ISN"
        oSheet.Cells(ROW_FIRST, 57) = "IMSSPatronal"
        oSheet.Cells(ROW_FIRST, 58) = "SAREINFONAVIT"
        oSheet.Cells(ROW_FIRST, 59) = "SGMMMENSUAL"
        oSheet.Cells(ROW_FIRST, 60) = "SEGUROVIDAMENSUAL"
        oSheet.Cells(ROW_FIRST, 61) = "IVA"
        oSheet.Cells(ROW_FIRST, 62) = "ComisiónNómina"
        oSheet.Cells(ROW_FIRST, 63) = "D3"
        oSheet.Cells(ROW_FIRST, 64) = "ProvisiónBono"
        oSheet.Cells(ROW_FIRST, 65) = "SalarioDiario"
        oSheet.Cells(ROW_FIRST, 66) = "SalarioDiarioDelEsquemaFlexible"
        oSheet.Cells(ROW_FIRST, 67) = "PrimaAnt12Dias"

        oSheet.Cells(ROW_FIRST, 1).font.bold = True : oSheet.Cells(ROW_FIRST, 2).font.bold = True : oSheet.Cells(ROW_FIRST, 3).font.bold = True
        oSheet.Cells(ROW_FIRST, 4).font.bold = True : oSheet.Cells(ROW_FIRST, 5).font.bold = True : oSheet.Cells(ROW_FIRST, 6).font.bold = True
        oSheet.Cells(ROW_FIRST, 7).font.bold = True : oSheet.Cells(ROW_FIRST, 8).font.bold = True : oSheet.Cells(ROW_FIRST, 9).font.bold = True
        oSheet.Cells(ROW_FIRST, 10).font.bold = True : oSheet.Cells(ROW_FIRST, 11).font.bold = True : oSheet.Cells(ROW_FIRST, 12).font.bold = True
        oSheet.Cells(ROW_FIRST, 13).font.bold = True : oSheet.Cells(ROW_FIRST, 14).font.bold = True : oSheet.Cells(ROW_FIRST, 15).font.bold = True
        oSheet.Cells(ROW_FIRST, 16).font.bold = True : oSheet.Cells(ROW_FIRST, 17).font.bold = True : oSheet.Cells(ROW_FIRST, 18).font.bold = True
        oSheet.Cells(ROW_FIRST, 19).font.bold = True : oSheet.Cells(ROW_FIRST, 20).font.bold = True : oSheet.Cells(ROW_FIRST, 21).font.bold = True
        oSheet.Cells(ROW_FIRST, 22).font.bold = True : oSheet.Cells(ROW_FIRST, 23).font.bold = True : oSheet.Cells(ROW_FIRST, 24).font.bold = True
        oSheet.Cells(ROW_FIRST, 25).font.bold = True : oSheet.Cells(ROW_FIRST, 26).font.bold = True : oSheet.Cells(ROW_FIRST, 27).font.bold = True
        oSheet.Cells(ROW_FIRST, 28).font.bold = True : oSheet.Cells(ROW_FIRST, 29).font.bold = True : oSheet.Cells(ROW_FIRST, 30).font.bold = True
        oSheet.Cells(ROW_FIRST, 31).font.bold = True : oSheet.Cells(ROW_FIRST, 32).font.bold = True : oSheet.Cells(ROW_FIRST, 33).font.bold = True
        oSheet.Cells(ROW_FIRST, 34).font.bold = True : oSheet.Cells(ROW_FIRST, 35).font.bold = True : oSheet.Cells(ROW_FIRST, 36).font.bold = True
        oSheet.Cells(ROW_FIRST, 37).font.bold = True : oSheet.Cells(ROW_FIRST, 38).font.bold = True : oSheet.Cells(ROW_FIRST, 39).font.bold = True
        oSheet.Cells(ROW_FIRST, 40).font.bold = True : oSheet.Cells(ROW_FIRST, 41).font.bold = True : oSheet.Cells(ROW_FIRST, 42).font.bold = True
        oSheet.Cells(ROW_FIRST, 43).font.bold = True : oSheet.Cells(ROW_FIRST, 44).font.bold = True : oSheet.Cells(ROW_FIRST, 45).font.bold = True
        oSheet.Cells(ROW_FIRST, 46).font.bold = True : oSheet.Cells(ROW_FIRST, 47).font.bold = True : oSheet.Cells(ROW_FIRST, 48).font.bold = True
        oSheet.Cells(ROW_FIRST, 49).font.bold = True : oSheet.Cells(ROW_FIRST, 50).font.bold = True : oSheet.Cells(ROW_FIRST, 51).font.bold = True
        oSheet.Cells(ROW_FIRST, 52).font.bold = True : oSheet.Cells(ROW_FIRST, 53).font.bold = True : oSheet.Cells(ROW_FIRST, 54).font.bold = True
        oSheet.Cells(ROW_FIRST, 55).font.bold = True : oSheet.Cells(ROW_FIRST, 56).font.bold = True : oSheet.Cells(ROW_FIRST, 57).font.bold = True
        oSheet.Cells(ROW_FIRST, 58).font.bold = True : oSheet.Cells(ROW_FIRST, 59).font.bold = True : oSheet.Cells(ROW_FIRST, 60).font.bold = True
        oSheet.Cells(ROW_FIRST, 61).font.bold = True : oSheet.Cells(ROW_FIRST, 62).font.bold = True : oSheet.Cells(ROW_FIRST, 63).font.bold = True
        oSheet.Cells(ROW_FIRST, 64).font.bold = True : oSheet.Cells(ROW_FIRST, 65).font.bold = True : oSheet.Cells(ROW_FIRST, 66).font.bold = True : oSheet.Cells(ROW_FIRST, 67).font.bold = True
        Dim iCurrRow As Int64
        For i = 0 To arrReal.Count - 1
            iCurrRow = ROW_FIRST + iRow
            If CType(Me.arrDatosNomina(i), clsNomina).FechaBaja.HasValue Then
                oSheet.Cells(iCurrRow, 1).font.color = 250 : oSheet.Cells(iCurrRow, 2).font.color = 250 : oSheet.Cells(iCurrRow, 3).font.color = 250 : oSheet.Cells(iCurrRow, 4).font.color = 250 : oSheet.Cells(iCurrRow, 5).font.color = 250
                oSheet.Cells(iCurrRow, 6).font.color = 250 : oSheet.Cells(iCurrRow, 7).font.color = 250 : oSheet.Cells(iCurrRow, 8).font.color = 250 : oSheet.Cells(iCurrRow, 9).font.color = 250 : oSheet.Cells(iCurrRow, 10).font.color = 250
                oSheet.Cells(iCurrRow, 11).font.color = 250 : oSheet.Cells(iCurrRow, 12).font.color = 250 : oSheet.Cells(iCurrRow, 13).font.color = 250 : oSheet.Cells(iCurrRow, 14).font.color = 250 : oSheet.Cells(iCurrRow, 15).font.color = 250
                oSheet.Cells(iCurrRow, 16).font.color = 250 : oSheet.Cells(iCurrRow, 17).font.color = 250 : oSheet.Cells(iCurrRow, 18).font.color = 250 : oSheet.Cells(iCurrRow, 19).font.color = 250 : oSheet.Cells(iCurrRow, 20).font.color = 250
                oSheet.Cells(iCurrRow, 21).font.color = 250 : oSheet.Cells(iCurrRow, 22).font.color = 250 : oSheet.Cells(iCurrRow, 23).font.color = 250 : oSheet.Cells(iCurrRow, 24).font.color = 250 : oSheet.Cells(iCurrRow, 25).font.color = 250
                oSheet.Cells(iCurrRow, 26).font.color = 250 : oSheet.Cells(iCurrRow, 27).font.color = 250 : oSheet.Cells(iCurrRow, 28).font.color = 250 : oSheet.Cells(iCurrRow, 29).font.color = 250 : oSheet.Cells(iCurrRow, 30).font.color = 250
                oSheet.Cells(iCurrRow, 31).font.color = 250 : oSheet.Cells(iCurrRow, 32).font.color = 250 : oSheet.Cells(iCurrRow, 33).font.color = 250 : oSheet.Cells(iCurrRow, 34).font.color = 250 : oSheet.Cells(iCurrRow, 35).font.color = 250
                oSheet.Cells(iCurrRow, 36).font.color = 250 : oSheet.Cells(iCurrRow, 37).font.color = 250 : oSheet.Cells(iCurrRow, 38).font.color = 250 : oSheet.Cells(iCurrRow, 39).font.color = 250 : oSheet.Cells(iCurrRow, 40).font.color = 250
                oSheet.Cells(iCurrRow, 41).font.color = 250 : oSheet.Cells(iCurrRow, 42).font.color = 250 : oSheet.Cells(iCurrRow, 43).font.color = 250 : oSheet.Cells(iCurrRow, 44).font.color = 250 : oSheet.Cells(iCurrRow, 45).font.color = 250
                oSheet.Cells(iCurrRow, 46).font.color = 250 : oSheet.Cells(iCurrRow, 47).font.color = 250 : oSheet.Cells(iCurrRow, 48).font.color = 250 : oSheet.Cells(iCurrRow, 49).font.color = 250 : oSheet.Cells(iCurrRow, 50).font.color = 250
                oSheet.Cells(iCurrRow, 51).font.color = 250 : oSheet.Cells(iCurrRow, 52).font.color = 250 : oSheet.Cells(iCurrRow, 53).font.color = 250 : oSheet.Cells(iCurrRow, 54).font.color = 250 : oSheet.Cells(iCurrRow, 55).font.color = 250
                oSheet.Cells(iCurrRow, 56).font.color = 250 : oSheet.Cells(iCurrRow, 57).font.color = 250 : oSheet.Cells(iCurrRow, 58).font.color = 250 : oSheet.Cells(iCurrRow, 59).font.color = 250 : oSheet.Cells(iCurrRow, 60).font.color = 250
                oSheet.Cells(iCurrRow, 61).font.color = 250 : oSheet.Cells(iCurrRow, 62).font.color = 250 : oSheet.Cells(iCurrRow, 63).font.color = 250 : oSheet.Cells(iCurrRow, 64).font.color = 250 : oSheet.Cells(iCurrRow, 65).font.color = 250
                oSheet.Cells(iCurrRow, 66).font.color = 250 : oSheet.Cells(iCurrRow, 67).font.color = 250
            End If

            With CType(arrReal(i), clsReal)
                oSheet.Cells(iCurrRow, 1) = .Tarjeta_Id
                oSheet.Cells(iCurrRow, 2) = Me.Empresa
                oSheet.Cells(iCurrRow, 3) = Me.EmpIntel
                oSheet.Cells(iCurrRow, 4) = .Nombre
                oSheet.Cells(iCurrRow, 5) = .Empresa
                oSheet.Cells(iCurrRow, 6) = .Departamento
                oSheet.Cells(iCurrRow, 7) = .Puesto
                oSheet.Cells(iCurrRow, 8) = .CentroDeCostos
                oSheet.Cells(iCurrRow, 9) = .Moneda
                oSheet.Cells(iCurrRow, 10) = Me.ConvierteFechaCadena(.FechaConversion)
                oSheet.Cells(iCurrRow, 11) = Me.ConvierteFechaCadena(.FechaInicio)
                oSheet.Cells(iCurrRow, 12) = Me.ConvierteFechaCadena(.FechaFinal)
                oSheet.Cells(iCurrRow, 13) = Math.Round(.Sueldo, 2)
                oSheet.Cells(iCurrRow, 14) = Math.Round(.Sub_Eg_3, 2)
                oSheet.Cells(iCurrRow, 15) = Math.Round(.Sub_Eg_4, 2)
                oSheet.Cells(iCurrRow, 16) = Math.Round(.SubsidioMaternidad, 2)
                oSheet.Cells(iCurrRow, 17) = Math.Round(.BonosUnico, 2)
                oSheet.Cells(iCurrRow, 18) = Math.Round(.NegociacionGravada, 2)
                oSheet.Cells(iCurrRow, 19) = Math.Round(.Ps, 2)
                oSheet.Cells(iCurrRow, 20) = Math.Round(.Bono_Ps, 2)
                oSheet.Cells(iCurrRow, 21) = Math.Round(.Ias, 2)
                oSheet.Cells(iCurrRow, 22) = Math.Round(.FlexiblesSubsidiosIncap, 2)
                oSheet.Cells(iCurrRow, 23) = Math.Round(.SubsidioAlEmpleo, 2)
                oSheet.Cells(iCurrRow, 24) = Math.Round(.PrimaDominical, 2)
                oSheet.Cells(iCurrRow, 25) = Math.Round(.DescansoLaborado, 2)
                oSheet.Cells(iCurrRow, 26) = Math.Round(.HorasExtra, 2)
                oSheet.Cells(iCurrRow, 27) = Math.Round(.HorasExtraTriples, 2)
                oSheet.Cells(iCurrRow, 28) = Math.Round(.Aguinaldo, 2)
                oSheet.Cells(iCurrRow, 29) = Math.Round(.FiniquitoVacaciones, 2)
                oSheet.Cells(iCurrRow, 30) = Math.Round(.PrimaVac, 2)
                oSheet.Cells(iCurrRow, 31) = Math.Round(.FiniqitoPrimaVacExcento, 2)
                oSheet.cells(iCurrRow, 32) = Math.Round(.FiniquitoPrimaVacGravado, 2)
                oSheet.cells(iCurrRow, 33) = Math.Round(.FiniquitoAguinaldoExcento, 2)
                oSheet.cells(iCurrRow, 34) = Math.Round(.FiniquitoAguinaldoGravado, 2)
                oSheet.cells(iCurrRow, 35) = Math.Round(.Ptu, 2)
                oSheet.cells(iCurrRow, 36) = Math.Round(.LiquidacionPrimaAntiguedad, 2)
                oSheet.cells(iCurrRow, 37) = Math.Round(.Liquidacion3meses, 2)
                oSheet.cells(iCurrRow, 38) = Math.Round(.Liquidacion20diaspora, 2)
                oSheet.cells(iCurrRow, 39) = Math.Round(.CuotaImss, 2)
                oSheet.cells(iCurrRow, 40) = Math.Round(.CreditoInfona, 2)
                oSheet.Cells(iCurrRow, 41) = Math.Round(.AjusteCreditoIn, 2)
                oSheet.Cells(iCurrRow, 42) = Math.Round(.DescuentoComedor, 2)
                oSheet.Cells(iCurrRow, 43) = Math.Round(.FondodeAhorro, 2)
                oSheet.Cells(iCurrRow, 44) = Math.Round(.DescuentoOtro, 2)
                oSheet.Cells(iCurrRow, 45) = Math.Round(.DescuentoSeguroGmm, 2)
                oSheet.Cells(iCurrRow, 46) = Math.Round(.DescuentoEquipoComputo, 2)
                oSheet.Cells(iCurrRow, 47) = Math.Round(.PrestamoPersonal, 2)
                oSheet.Cells(iCurrRow, 48) = Math.Round(.OtrasDeducciones, 2)
                oSheet.Cells(iCurrRow, 49) = Math.Round(.Fonacot, 2)
                oSheet.Cells(iCurrRow, 50) = Math.Round(.Isr, 2)
                oSheet.Cells(iCurrRow, 51) = Math.Round(.IsrFiniquito, 2)
                oSheet.Cells(iCurrRow, 52) = Math.Round(.DiferenciaIsrAjuste, 2)
                oSheet.Cells(iCurrRow, 53) = Math.Round(.PensionAlimenticia, 2)
                oSheet.Cells(iCurrRow, 54) = Math.Round(.ProvisionAguinaldo, 2)
                oSheet.Cells(iCurrRow, 55) = Math.Round(.ProvisionPrimaVac, 2)
                oSheet.Cells(iCurrRow, 56) = Math.Round(.Isn, 2)
                oSheet.Cells(iCurrRow, 57) = Math.Round(.ImssPatronal, 2)
                oSheet.Cells(iCurrRow, 58) = Math.Round(.SareInfonavit, 2)
                oSheet.Cells(iCurrRow, 59) = Math.Round(.SgmmMensual, 2)
                oSheet.Cells(iCurrRow, 60) = Math.Round(.SeguroVidaMensual, 2)
                oSheet.Cells(iCurrRow, 61) = Math.Round(.Iva, 2)
                oSheet.Cells(iCurrRow, 62) = Math.Round(.ComisionNomina, 2)
                oSheet.Cells(iCurrRow, 63) = Math.Round(.D3, 2)
                oSheet.Cells(iCurrRow, 64) = Math.Round(.ProvisionBono, 2)
                oSheet.Cells(iCurrRow, 65) = Math.Round(.SalarioDiario, 2)
                oSheet.Cells(iCurrRow, 66) = Math.Round(.SalarioDiarioDelEsquemaFlexible, 2)

            End With
            With CType(Me.arrDatosNomina(i), clsNomina)
                oSheet.Cells(iCurrRow, 67) = Math.Round(.PrimaAnt12Dias, 2)
            End With

            iRow += 1
        Next
        oSheet.Cells(iCurrRow + 1, 2).font.bold = True : oSheet.Cells(iCurrRow + 1, 13).font.bold = True : oSheet.Cells(iCurrRow + 1, 14).font.bold = True : oSheet.Cells(iCurrRow + 1, 15).font.bold = True
        oSheet.Cells(iCurrRow + 1, 16).font.bold = True : oSheet.Cells(iCurrRow + 1, 17).font.bold = True : oSheet.Cells(iCurrRow + 1, 18).font.bold = True : oSheet.Cells(iCurrRow + 1, 19).font.bold = True
        oSheet.Cells(iCurrRow + 1, 20).font.bold = True : oSheet.Cells(iCurrRow + 1, 21).font.bold = True : oSheet.Cells(iCurrRow + 1, 22).font.bold = True : oSheet.Cells(iCurrRow + 1, 23).font.bold = True
        oSheet.Cells(iCurrRow + 1, 24).font.bold = True : oSheet.Cells(iCurrRow + 1, 25).font.bold = True : oSheet.Cells(iCurrRow + 1, 26).font.bold = True : oSheet.Cells(iCurrRow + 1, 27).font.bold = True
        oSheet.Cells(iCurrRow + 1, 28).font.bold = True : oSheet.Cells(iCurrRow + 1, 29).font.bold = True : oSheet.Cells(iCurrRow + 1, 30).font.bold = True : oSheet.Cells(iCurrRow + 1, 31).font.bold = True
        oSheet.Cells(iCurrRow + 1, 32).font.bold = True : oSheet.Cells(iCurrRow + 1, 33).font.bold = True : oSheet.Cells(iCurrRow + 1, 34).font.bold = True : oSheet.Cells(iCurrRow + 1, 35).font.bold = True
        oSheet.Cells(iCurrRow + 1, 36).font.bold = True : oSheet.Cells(iCurrRow + 1, 37).font.bold = True : oSheet.Cells(iCurrRow + 1, 38).font.bold = True : oSheet.Cells(iCurrRow + 1, 39).font.bold = True
        oSheet.Cells(iCurrRow + 1, 40).font.bold = True : oSheet.Cells(iCurrRow + 1, 41).font.bold = True : oSheet.Cells(iCurrRow + 1, 42).font.bold = True : oSheet.Cells(iCurrRow + 1, 43).font.bold = True
        oSheet.Cells(iCurrRow + 1, 44).font.bold = True : oSheet.Cells(iCurrRow + 1, 45).font.bold = True : oSheet.Cells(iCurrRow + 1, 46).font.bold = True : oSheet.Cells(iCurrRow + 1, 47).font.bold = True
        oSheet.Cells(iCurrRow + 1, 48).font.bold = True : oSheet.Cells(iCurrRow + 1, 49).font.bold = True : oSheet.Cells(iCurrRow + 1, 50).font.bold = True : oSheet.Cells(iCurrRow + 1, 51).font.bold = True
        oSheet.Cells(iCurrRow + 1, 52).font.bold = True : oSheet.Cells(iCurrRow + 1, 53).font.bold = True : oSheet.Cells(iCurrRow + 1, 54).font.bold = True : oSheet.Cells(iCurrRow + 1, 55).font.bold = True
        oSheet.Cells(iCurrRow + 1, 56).font.bold = True : oSheet.Cells(iCurrRow + 1, 57).font.bold = True : oSheet.Cells(iCurrRow + 1, 58).font.bold = True : oSheet.Cells(iCurrRow + 1, 59).font.bold = True
        oSheet.Cells(iCurrRow + 1, 60).font.bold = True : oSheet.Cells(iCurrRow + 1, 61).font.bold = True : oSheet.Cells(iCurrRow + 1, 62).font.bold = True : oSheet.Cells(iCurrRow + 1, 63).font.bold = True
        oSheet.Cells(iCurrRow + 1, 64).font.bold = True : oSheet.Cells(iCurrRow + 1, 65).font.bold = True : oSheet.Cells(iCurrRow + 1, 66).font.bold = True : oSheet.Cells(iCurrRow + 1, 67).font.bold = True

        oSheet.Cells(iCurrRow + 1, 2).Formula = "NO. EMPLEADOS = " & Me.arrReal.Count.ToString()
        oSheet.Cells(iCurrRow + 1, 13).Formula = "=SUMA(M2:M" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 14).Formula = "=SUMA(N2:N" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 15).Formula = "=SUMA(O2:O" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 16).Formula = "=SUMA(P2:P" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 17).Formula = "=SUMA(Q2:Q" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 18).Formula = "=SUMA(R2:R" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 19).Formula = "=SUMA(S2:S" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 20).Formula = "=SUMA(T2:T" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 21).Formula = "=SUMA(U2:U" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 22).Formula = "=SUMA(V2:V" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 23).Formula = "=SUMA(W2:W" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 24).Formula = "=SUMA(X2:X" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 25).Formula = "=SUMA(Y2:Y" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 26).Formula = "=SUMA(Z2:Z" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 27).Formula = "=SUMA(AA2:AA" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 28).Formula = "=SUMA(AB2:AB" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 29).Formula = "=SUMA(AC2:AC" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 30).Formula = "=SUMA(AD2:AD" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 31).Formula = "=SUMA(AE2:AE" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 32).Formula = "=SUMA(AF2:AF" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 33).Formula = "=SUMA(AG2:AG" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 34).Formula = "=SUMA(AH2:AH" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 35).Formula = "=SUMA(AI2:AI" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 36).Formula = "=SUMA(AJ2:AJ" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 37).Formula = "=SUMA(AK2:AK" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 38).Formula = "=SUMA(AL2:AL" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 39).Formula = "=SUMA(AM2:AM" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 40).Formula = "=SUMA(AN2:AN" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 41).Formula = "=SUMA(AO2:AO" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 42).Formula = "=SUMA(AP2:AP" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 43).Formula = "=SUMA(AQ2:AQ" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 44).Formula = "=SUMA(AR2:AR" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 45).Formula = "=SUMA(AS2:AS" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 46).Formula = "=SUMA(AT2:AT" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 47).Formula = "=SUMA(AU2:AU" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 48).Formula = "=SUMA(AV2:AV" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 49).Formula = "=SUMA(AW2:AW" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 50).Formula = "=SUMA(AX2:AX" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 51).Formula = "=SUMA(AY2:AY" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 52).Formula = "=SUMA(AZ2:AZ" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 53).Formula = "=SUMA(BA2:BA" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 54).Formula = "=SUMA(BB2:BB" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 55).Formula = "=SUMA(BC2:BC" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 56).Formula = "=SUMA(BD2:BD" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 57).Formula = "=SUMA(BE2:BE" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 58).Formula = "=SUMA(BF2:BF" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 59).Formula = "=SUMA(BG2:BG" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 60).Formula = "=SUMA(BH2:BH" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 61).Formula = "=SUMA(BI2:BI" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 62).Formula = "=SUMA(BJ2:BJ" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 63).Formula = "=SUMA(BK2:BK" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 64).Formula = "=SUMA(BL2:BL" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 65).Formula = "=SUMA(BM2:BM" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 66).Formula = "=SUMA(BN2:BN" & iCurrRow.ToString() & ")"
        oSheet.Cells(iCurrRow + 1, 67).Formula = "=SUMA(BO2:BO" & iCurrRow.ToString() & ")"

        Me.GeneraArchivoR("NominaR_" + Me.Centro)
    End Sub

    Public Function ConvierteFecha(ByVal strFecha As String) As Date
        Dim f As Date
        f = CType(strFecha.Substring(0, 4) & "-" & strFecha.Substring(4, 2) & "-" & strFecha.Substring(6, 2), Date)
        Return f
    End Function

    Public Function ConvierteFechaCadena(ByVal fecha As Date) As String
        Dim fechaStr As String
        fechaStr = fecha.ToString("yyyyMMdd")
        Return fechaStr
    End Function

    Public Function ChecaSiExisteCarpetaRespaldo() As String
        Dim ruta As String = Nothing
        If Not My.Computer.FileSystem.DirectoryExists("C:\Respaldos Nominas") Then
            Try
                My.Computer.FileSystem.CreateDirectory("C:\Respaldos Nominas")
            Catch ex As Exception
            End Try
        End If

        If Not My.Computer.FileSystem.DirectoryExists("C:\Respaldos Nominas\" & Format(Date.Now, "MMMM yyyy").ToUpper & "\" & Format(Date.Now, "dd").ToUpper) Then
            Try
                My.Computer.FileSystem.CreateDirectory("C:\Respaldos Nominas\" & Format(Date.Now, "MMMM yyyy").ToUpper & "\" & Format(Date.Now, "dd").ToUpper)
            Catch ex As Exception
            End Try
        Else
            ruta = "C:\Respaldos Nominas\" & Format(Date.Now, "MMMM yyyy").ToUpper & "\" & Format(Date.Now, "dd").ToUpper
        End If

        Return ruta
    End Function

    Private Sub GeneraArchivoE(ByVal NombreArchivo As String)
        'Variables para abrir el archivo en modo de escritura
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter
        Dim ruta As String = Nothing
        Dim linea As String  'para imprimir una linea

        'Empiezo a escribir en el archivo de texto
        Try
            ruta = Me.ChecaSiExisteCarpetaRespaldo()
            'Me aseguro que la carpeta de respaldo exista
            If Not ruta Is Nothing Then
                'Creo el nombre del archivo en la ruta especificada
                Dim FilePath As String = ruta + "\" + NombreArchivo + ".txt"

                'Se abre el archivo y si este no existe se crea
                strStreamW = File.OpenWrite(FilePath)
                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.UTF8)

                Const ROW_FIRST = 1
                Dim iRow As Int64 = 1

                ' Encabezado
                strStreamWriter.WriteLine("Tarjeta_id" + "," + "IDEmp" + "," + "IDIntel" + "," + "Nombre" + "," + "Empresa" + "," + "Depto" + "," + "Puesto" + "," + _
                                          "CENTROCOSTOS" + "," + "FechaAnt" + "," + "AntAños" + "," + "Vacaciones" + "," + "Moneda" + "," + "FechaConversion" + "," + _
                                          "Inicio" + "," + "Final" + "," + "SALARIOANUAL" + "," + "PREVISION" + "," + "IAS" + "," + "AGUINALDO" + "," + "PRIMA" + "," + _
                                          "BONO" + "," + "IMSSSARINFONAVIT" + "," + "ISN" + "," + "SGMM" + "," + "SVA" + "," + "COMISION" + "," + "D3" + "," + "PROVISIONBONO" + "," + "SDI" + "," + "CURP" + "," + "BONO UNICO" + "," + "BONO ESPECIAL" + "," + "BONO NEGOCIACION")

                For i = 0 To Me.arrEstandar.Count - 1
                    Dim iCurrRow As Int64 = ROW_FIRST + iRow
                    With CType(Me.arrEstandar(i), clsEstandar)
                        linea = " " + .IdEmpleado
                        linea += "," + Me.Empresa
                        linea += "," + Me.EmpIntel
                        linea += "," + .Nombre
                        linea += "," + .RegistroPatronal
                        linea += "," + .Departamento
                        linea += "," + .Puesto
                        linea += "," + .CentroCosto.ToString()
                        linea += "," + Me.ConvierteFechaCadena(.FechaAntiguedad)
                        linea += "," + .Antiguedad.ToString()
                        linea += "," + .DiasVacaciones.ToString()
                        linea += "," + .Moneda
                        linea += "," + Me.ConvierteFechaCadena(.FechaConversion)
                        linea += "," + Me.ConvierteFechaCadena(.FechaInicio)
                        linea += "," + Me.ConvierteFechaCadena(.FechaFin)
                        linea += "," + Math.Round(.SueldoAnual, 2).ToString()
                        linea += "," + Math.Round(.PrevisionSocial, 2).ToString()
                        linea += "," + Math.Round(.Ias, 2).ToString()
                        linea += "," + Math.Round(.AguinaldoAnual, 2).ToString()
                        linea += "," + Math.Round(.PrimaVacAnual, 2).ToString()
                        linea += "," + Math.Round(.BonoAnual, 2).ToString()
                        linea += "," + Math.Round(.ImssSarInfonavitAnual, 2).ToString()
                        linea += "," + Math.Round(.Isn, 2).ToString()
                        linea += "," + Math.Round(.Sgmm, 2).ToString()
                        linea += "," + Math.Round(.SeguroVida, 2).ToString()
                        linea += "," + Math.Round(.ComisionNomina, 2).ToString()
                        linea += "," + Math.Round(.D3, 2).ToString()
                        linea += "," + Math.Round(.ProvisionBono, 2).ToString()
                        linea += "," + Math.Round(.SDI, 2).ToString()

                        linea += "," + .Curp
                        linea += "," + Math.Round(.Bono_Unico, 2).ToString()
                        linea += "," + Math.Round(.Bono_Especial, 2).ToString()
                        linea += "," + Math.Round(.Bono_Negociacion, 2).ToString()
                    End With
                    strStreamWriter.WriteLine(linea)
                    iRow += 1
                Next

                'Cierro el archivo
                strStreamWriter.Close()
            Else
                MsgBox("No se pudo guardar el archivo", MsgBoxStyle.Critical, "Mensaje del sistema")
            End If

        Catch ex As Exception
            strStreamWriter.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GeneraArchivoR(ByVal NombreArchivo As String)
        'Variables para abrir el archivo en modo de escritura
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter
        Dim ruta As String = Nothing
        Dim linea As String  'para imprimir una linea

        'Empiezo a escribir en el archivo de texto
        Try
            ruta = Me.ChecaSiExisteCarpetaRespaldo()
            'Me aseguro que la carpeta de respaldo exista
            If Not ruta Is Nothing Then
                'Creo el nombre del archivo en la ruta especificada
                Dim FilePath As String = ruta + "\" + NombreArchivo + ".txt"

                'Se abre el archivo y si este no existe se crea
                strStreamW = File.OpenWrite(FilePath)
                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.UTF8)

                Const ROW_FIRST = 1
                Dim iRow As Int64 = 1

                ' Encabezado
                strStreamWriter.WriteLine("tarjeta_id" + "," + "IDEMPRESA" + "," + "IDEMPRESAINTELISIS" + "," + "NOMBRE" + "," + "EMPRESA" + "," + "DEPARTAMENTO" + "," + _
                                          "PUESTO" + "," + "CENTRODECOSTOS" + "," + "MONEDA" + "," + "FECHACONVERSION" + "," + "FECHAINICIO" + "," + "FECHAFINAL" + "," + _
                                          "SUELDO" + "," + "SUB_EG_3" + "," + "SUB_EG_4" + "," + "SubsidioMaternidad" + "," + "Bonosunico" + "," + "NEGOCIACIONGRAVADA" + "," + _
                                          "PS" + "," + "BOno_PS" + "," + "IAS" + "," + "FlexiblesSubsidiosIncap" + "," + "SUBSIDIOALEMPLEO" + "," + "PRIMADOMINICAL" + "," + _
                                          "DESCANSOLABORADO" + "," + "HorasExtra" + "," + "HorasExtraTriples" + "," + "AGUINALDO" + "," + "FiniquitoVacaciones" + "," + _
                                          "PRIMAVAC" + "," + "FiniquitoPrimaVacEXCENTO" + "," + "FiniquitoPrimaVacGRAVADO" + "," + "FiniquitoAGUINALDOEXCENTO" + "," + _
                                          "FiniquitoAGUINALDOGRAVADO" + "," + "PTU" + "," + "LiquidacionPrimaAntigüedad" + "," + "Liquidación3Meses" + "," + _
                                          "Liquidación20DíasporAño" + "," + "CuotaIMSS" + "," + "CREDITOINFONA" + "," + "AJUSTECREDITOIN" + "," + "DESCUENTOCOMEDOR" + "," + _
                                          "FONDODEAHORRO" + "," + "DescuentoOtro" + "," + "DescuentoSeguroGMM" + "," + "DescuentoEQUIPOCOMPUTO" + "," + "PRESTAMOpersonal" + "," + _
                                          "OTRASDEDUCCIONES" + "," + "FONACOT" + "," + "ISR" + "," + "ISRFINIQUITO" + "," + "DIFERENCIAISRAJUSTE" + "," + "PENSIONALIMENTICIA" + "," + _
                                          "PROVISIONAGUINALDO" + "," + "PROVISIONPRIMAVAC" + "," + "ISN" + "," + "IMSSPatronal" + "," + "SAREINFONAVIT" + "," + "SGMMMENSUAL" + "," + _
                                          "SEGUROVIDAMENSUAL" + "," + "IVA" + "," + "ComisiónNómina" + "," + "D3" + "," + "ProvisiónBono" + "," + "SalarioDiario" + "," + "SalarioDiarioDelEsquemaFlexible" + "," + "prueba")

                For i = 0 To arrReal.Count - 1
                    Dim iCurrRow As Int64 = ROW_FIRST + iRow
                    With CType(arrReal(i), clsReal)
                        linea = "" + .Tarjeta_Id
                        linea += "," + Me.Empresa
                        linea += "," + Me.EmpIntel
                        linea += "," + .Nombre
                        linea += "," + .Empresa
                        linea += "," + .Departamento
                        linea += "," + .Puesto
                        linea += "," + .CentroDeCostos.ToString()
                        linea += "," + .Moneda
                        linea += "," + Me.ConvierteFechaCadena(.FechaConversion)
                        linea += "," + Me.ConvierteFechaCadena(.FechaInicio)
                        linea += "," + Me.ConvierteFechaCadena(.FechaFinal)
                        linea += "," + Math.Round(.Sueldo, 2).ToString()
                        linea += "," + Math.Round(.Sub_Eg_3, 2).ToString()
                        linea += "," + Math.Round(.Sub_Eg_4, 2).ToString()
                        linea += "," + Math.Round(.SubsidioMaternidad, 2).ToString()
                        linea += "," + Math.Round(.BonosUnico, 2).ToString()
                        linea += "," + Math.Round(.NegociacionGravada, 2).ToString()
                        linea += "," + Math.Round(.Ps, 2).ToString()
                        linea += "," + Math.Round(.Bono_Ps, 2).ToString()
                        linea += "," + Math.Round(.Ias, 2).ToString()
                        linea += "," + Math.Round(.FlexiblesSubsidiosIncap, 2).ToString()
                        linea += "," + Math.Round(.SubsidioAlEmpleo, 2).ToString()
                        linea += "," + Math.Round(.PrimaDominical, 2).ToString()
                        linea += "," + Math.Round(.DescansoLaborado, 2).ToString()
                        linea += "," + Math.Round(.HorasExtra, 2).ToString()
                        linea += "," + Math.Round(.HorasExtraTriples, 2).ToString()
                        linea += "," + Math.Round(.Aguinaldo, 2).ToString()
                        linea += "," + Math.Round(.FiniquitoVacaciones, 2).ToString()
                        linea += "," + Math.Round(.PrimaVac, 2).ToString()
                        linea += "," + Math.Round(.FiniqitoPrimaVacExcento, 2).ToString()
                        linea += "," + Math.Round(.FiniquitoPrimaVacGravado, 2).ToString()
                        linea += "," + Math.Round(.FiniquitoAguinaldoExcento, 2).ToString()
                        linea += "," + Math.Round(.FiniquitoAguinaldoGravado, 2).ToString()
                        linea += "," + Math.Round(.Ptu, 2).ToString()
                        linea += "," + Math.Round(.LiquidacionPrimaAntiguedad, 2).ToString()
                        linea += "," + Math.Round(.Liquidacion3meses, 2).ToString()
                        linea += "," + Math.Round(.Liquidacion20diaspora, 2).ToString()
                        linea += "," + Math.Round(.CuotaImss, 2).ToString()
                        linea += "," + Math.Round(.CreditoInfona, 2).ToString()
                        linea += "," + Math.Round(.AjusteCreditoIn, 2).ToString()
                        linea += "," + Math.Round(.DescuentoComedor, 2).ToString()
                        linea += "," + Math.Round(.FondodeAhorro, 2).ToString()
                        linea += "," + Math.Round(.DescuentoOtro, 2).ToString()
                        linea += "," + Math.Round(.DescuentoSeguroGmm, 2).ToString()
                        linea += "," + Math.Round(.DescuentoEquipoComputo, 2).ToString()
                        linea += "," + Math.Round(.PrestamoPersonal, 2).ToString()
                        linea += "," + Math.Round(.OtrasDeducciones, 2).ToString()
                        linea += "," + Math.Round(.Fonacot, 2).ToString()
                        linea += "," + Math.Round(.Isr, 2).ToString()
                        linea += "," + Math.Round(.IsrFiniquito, 2).ToString()
                        linea += "," + Math.Round(.DiferenciaIsrAjuste, 2).ToString()
                        linea += "," + Math.Round(.PensionAlimenticia, 2).ToString()
                        linea += "," + Math.Round(.ProvisionAguinaldo, 2).ToString()
                        linea += "," + Math.Round(.ProvisionPrimaVac, 2).ToString()
                        linea += "," + Math.Round(.Isn, 2).ToString()
                        linea += "," + Math.Round(.ImssPatronal, 2).ToString()
                        linea += "," + Math.Round(.SareInfonavit, 2).ToString()
                        linea += "," + Math.Round(.SgmmMensual, 2).ToString()
                        linea += "," + Math.Round(.SeguroVidaMensual, 2).ToString()
                        linea += "," + Math.Round(.Iva, 2).ToString()
                        linea += "," + Math.Round(.ComisionNomina, 2).ToString()
                        linea += "," + Math.Round(.D3, 2).ToString()
                        linea += "," + Math.Round(.ProvisionBono, 2).ToString()
                        linea += "," + Math.Round(.SalarioDiario, 2).ToString()
                        linea += "," + Math.Round(.SalarioDiarioDelEsquemaFlexible, 2).ToString()
                        linea += "," + Math.Round(.D3, 2).ToString()

                    End With
                    'With CType(arrReal(i), clsReal)
                    '    linea = .Tarjeta_Id
                    '    linea += vbTab + .Nombre
                    '    linea += vbTab + .IdEmpresa.ToString()
                    '    linea += vbTab + .IdEmpresaIntelisis.ToString()
                    '    linea += vbTab + .Empresa
                    '    linea += vbTab + .Departamento
                    '    linea += vbTab + .Puesto
                    '    linea += vbTab + .CentroDeCostos.ToString()
                    '    linea += vbTab + .Moneda
                    '    linea += vbTab + Me.ConvierteFechaCadena(.FechaConversion)
                    '    linea += vbTab + Me.ConvierteFechaCadena(.FechaInicio)
                    '    linea += vbTab + Me.ConvierteFechaCadena(.FechaFinal)
                    '    linea += vbTab + Math.Round(.Sueldo, 2).ToString()
                    '    linea += vbTab + Math.Round(.Sub_Eg_3, 2).ToString()
                    '    linea += vbTab + Math.Round(.Sub_Eg_4, 2).ToString()
                    '    linea += vbTab + Math.Round(.SubsidioMaternidad, 2).ToString()
                    '    linea += vbTab + Math.Round(.BonosUnico, 2).ToString()
                    '    linea += vbTab + Math.Round(.NegociacionGravada, 2).ToString()
                    '    linea += vbTab + Math.Round(.Ps, 2).ToString()
                    '    linea += vbTab + Math.Round(.Bono_Ps, 2).ToString()
                    '    linea += vbTab + Math.Round(.Ias, 2).ToString()
                    '    linea += vbTab + Math.Round(.FlexiblesSubsidiosIncap, 2).ToString()
                    '    linea += vbTab + Math.Round(.SubsidioAlEmpleo, 2).ToString()
                    '    linea += vbTab + Math.Round(.PrimaDominical, 2).ToString()
                    '    linea += vbTab + Math.Round(.DescansoLaborado, 2).ToString()
                    '    linea += vbTab + Math.Round(.HorasExtra, 2).ToString()
                    '    linea += vbTab + Math.Round(.HorasExtraTriples, 2).ToString()
                    '    linea += vbTab + Math.Round(.Aguinaldo, 2).ToString()
                    '    linea += vbTab + Math.Round(.FiniquitoVacaciones, 2).ToString()
                    '    linea += vbTab + Math.Round(.PrimaVac, 2).ToString()
                    '    linea += vbTab + Math.Round(.FiniqitoPrimaVacExcento, 2).ToString()
                    '    linea += vbTab + Math.Round(.FiniquitoPrimaVacGravado, 2).ToString()
                    '    linea += vbTab + Math.Round(.FiniquitoAguinaldoExcento, 2).ToString()
                    '    linea += vbTab + Math.Round(.FiniquitoAguinaldoGravado, 2).ToString()
                    '    linea += vbTab + Math.Round(.Ptu, 2).ToString()
                    '    linea += vbTab + Math.Round(.LiquidacionPrimaAntiguedad, 2).ToString()
                    '    linea += vbTab + Math.Round(.Liquidacion3meses, 2).ToString()
                    '    linea += vbTab + Math.Round(.Liquidacion20diaspora, 2).ToString()
                    '    linea += vbTab + Math.Round(.CuotaImss, 2).ToString()
                    '    linea += vbTab + Math.Round(.CreditoInfona, 2).ToString()
                    '    linea += vbTab + Math.Round(.AjusteCreditoIn, 2).ToString()
                    '    linea += vbTab + Math.Round(.DescuentoComedor, 2).ToString()
                    '    linea += vbTab + Math.Round(.FondodeAhorro, 2).ToString()
                    '    linea += vbTab + Math.Round(.DescuentoOtro, 2).ToString()
                    '    linea += vbTab + Math.Round(.DescuentoSeguroGmm, 2).ToString()
                    '    linea += vbTab + Math.Round(.DescuentoEquipoComputo, 2).ToString()
                    '    linea += vbTab + Math.Round(.PrestamoPersonal, 2).ToString()
                    '    linea += vbTab + Math.Round(.OtrasDeducciones, 2).ToString()
                    '    linea += vbTab + Math.Round(.Fonacot, 2).ToString()
                    '    linea += vbTab + Math.Round(.Isr, 2).ToString()
                    '    linea += vbTab + Math.Round(.IsrFiniquito, 2).ToString()
                    '    linea += vbTab + Math.Round(.DiferenciaIsrAjuste, 2).ToString()
                    '    linea += vbTab + Math.Round(.PensionAlimenticia, 2).ToString()
                    '    linea += vbTab + Math.Round(.ProvisionAguinaldo, 2).ToString()
                    '    linea += vbTab + Math.Round(.ProvisionPrimaVac, 2).ToString()
                    '    linea += vbTab + Math.Round(.Isn, 2).ToString()
                    '    linea += vbTab + Math.Round(.ImssPatronal, 2).ToString()
                    '    linea += vbTab + Math.Round(.SareInfonavit, 2).ToString()
                    '    linea += vbTab + Math.Round(.SgmmMensual, 2).ToString()
                    '    linea += vbTab + Math.Round(.SeguroVidaMensual, 2).ToString()
                    '    linea += vbTab + Math.Round(.Iva, 2).ToString()
                    '    linea += vbTab + Math.Round(.ComisionNomina, 2).ToString()
                    'End With
                    strStreamWriter.WriteLine(linea)
                    iRow += 1
                Next
                'Cierro el archivo
                strStreamWriter.Close()
            Else
                MsgBox("No se pudo guardar el archivo de Nomina Real", MsgBoxStyle.Critical, "Mensaje del sistema")
            End If

        Catch ex As Exception
            strStreamWriter.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmExportar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Try
                Me.obExcel.quit()
            Catch ex As Exception
            End Try
            Me.Close()
        End If
    End Sub
    Private Sub frmNomina_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtaviso.Text = "*Ejeutar una vez al dia, verificando que nadie este conectado a Siccos"
        cbxan.SelectedIndex = 0
        cbxlista.SelectedIndex = 0
        'Me.tbMenu.TabPages(0).Enabled = False  'Deshabilitamos la Pagina1
        'Me.TabPage1.Parent = False 'Invisible Pagina1

        Me.archivo = ""
        Me.cmbEmpresa.SelectedIndex = 0
        Me.cRT = New clsRT(Me.Centro, 32, 2014, 5, 0.5)
        Me.ChecaSiExisteCarpetaRespaldo()
        Me.NomCalculadas = 1

        Me.MuestraInformacion()
        Me.bandera = False

        Me.cmbBuscar.SelectedIndex = 0
        Me.cmbann1.SelectedIndex = 0
        Me.txtlog.Clear()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarE.Click
        If Me.arrDatosNomina.Count <> 0 Then
            Me.CreaCostoEstandar()
        Else
            MsgBox("Debe seleccionar un archivo a exportar", MsgBoxStyle.Information, "Mensaje")
        End If
    End Sub

    Private Sub btnExportarR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarR.Click
        If Me.arrDatosNomina.Count <> 0 Then
            'If Me.archivo <> "" Then
            Me.CreaCostoReal()
        Else
            MsgBox("Debe seleccionar un archivo a exportar", MsgBoxStyle.Information, "Mensaje")
        End If
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        'Me.txtEmpresa.Text = Me.cmbEmpresa.SelectedItem.ToString
        Me.txtEmpresa.Text = Me.cmbEmpresa.SelectedItem.ToString.Substring(5, Me.cmbEmpresa.SelectedItem.ToString.Length - 5)
        Me.Centro = Me.cmbEmpresa.SelectedItem.ToString.Substring(0, 4)
    End Sub

    Private Sub AsignaEmpresa()
        'Empresa Intelisis: INTEGRUP(11081), CONISAL(11215)
        Select Case Me.Centro
            Case "2901", "3601", "3701"  'CENTRO 2901, 3601,3701 - BLITZ SOFTWARE SA DE CV (21) - INTERGRUP
                Me.Empresa = "21"
                Me.EmpIntel = "11081"
                Me.txtSeguro.Text = "339.47" 'Asignacion del Seguro de Vida (Anual) - INTERGRUP
            Case "2902" 'CENTRO 2902 - DSS DE MEXICO S.A. DE C.V. (11029) - INTERGRUP
                Me.Empresa = "11029"
                Me.EmpIntel = "11081"
                Me.txtSeguro.Text = "339.47" 'Asignacion del Seguro de Vida (Anual) - INTERGRUP
            Case "2903"  'CENTRO 2903 - QUALITA INTEGRACION S.A. DE C.V. (11022) - INTERGRUP
                Me.Empresa = "11022"
                Me.EmpIntel = "11081"
                Me.txtSeguro.Text = "339.47" 'Asignacion del Seguro de Vida (Anual) - INTERGRUP
            Case "3201", "3801", "5701"  'CENTRO 3201,3801 - BLITZ SOFTWARE SA DE CV (21) - CONISAL
                Me.Empresa = "21"
                Me.EmpIntel = "11215"
                Me.txtSeguro.Text = "517.39" 'Asignacion del Seguro de Vida (Anual) - CONISAL

                ''nuevo IT RESOURSCES TELECOM, S.A. DE C.V.
            Case "4601", "4701", "4801", "5401"  'IT RESOURSCES TELECOM, S.A. DE C.V.
                Me.Empresa = "21"
                Me.EmpIntel = "11081"
                Me.txtSeguro.Text = "351.89" 'Asignacion del Seguro de Vida (Anual) - CONISAL
                ''nuevo
            Case Else
                Me.Empresa = "1"
                Me.EmpIntel = "1"
        End Select
    End Sub
    Private Sub btnConsultaBD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaBD.Click
        If Me.rbHitss.Checked Then
            Me.cNomina = New clsNominaHandler(Funciones.GetConnectionStringHitss)



        ElseIf Me.rbIpp.Checked Then
            Me.cNomina = New clsNominaHandler(Funciones.GetConnectionStringIpp)

        End If

        If Me.chPrimaRiesgo.Checked Then : Me.ObtenerPrimaRiesgoBase() : End If

        If Me.chNomina.Checked Or Me.chNomina9.Checked Then : Me.ObtenerNominaBase() : End If

        'If Me.chEdadSexoCurp.Checked Then : Me.ObtenerEdadSexoCurpBase() : End If

        MessageBox.Show("Termino de Exportacion")
        Me.lbMensaaje.Text = "Se obtuvo la información correcta de la base de datos del Centro: " & Me.Centro
        Me.ProgressBar1.Value = 0

        'Asignamos el nombre de Empresa y Empresa Intelisis
        Me.AsignaEmpresa()
        'MsgBox(Me.Centro & " - " & Me.Empresa & " - " & Me.EmpIntel)
    End Sub
    Public Sub ObtenerPrimaRiesgoBase()
        Me.txtlog.Text += vbCrLf & "Obteniendo prima de riesgo..." & Date.Now.ToShortTimeString & vbCrLf
        Me.cRT = Me.cNomina.ObtienePRT(Me.Centro)
        Me.txtPrimaRiesgo.Text = Me.cRT.RT.ToString()
    End Sub
    Public Sub ObtenerNominaBase()
        Using ventana As New frmNominaCalculada()
            ventana.ShowDialog(Me)
            Me.NomCalculadas = ventana.NominasCalculadas
        End Using
        Dim arreTiposNomina As New ArrayList
        'Obtenemos la nomina de la base
        Me.arrDatosNomina = New ArrayList
        Me.arrEmpleadosBaja = New ArrayList
        Me.lbMensaaje.Text = "Procesando..."

        Try
            'Obtenemos todos los empleados que fueron dados de baja en el rango de fecha
            Me.txtlog.Text += "Obteniendo los empleados dados de baja en la fecha dada..." & Date.Now.ToShortTimeString & vbCrLf
            My.Application.DoEvents()
            Me.arrEmpleadosBaja = Me.cNomina.sp_ObtenerEmpleadosBaja(Me.Centro, Me.dtFechaInicial.Value, Me.dtFechaFinal.Value)
            'Me.ObtenerEdadSexoCurpBaseEmpBaja()
        Catch ex As Exception

        End Try

        'Me.arrDatosNomina = Me.cNomina.ObtenerNomina(Me.Centro, FechaInicio(dtFechaInicial.Value), FechaUltimo(dtFechaInicial.Value)) 'Obteniendo como FInicio el primero del mes y FFinal el ultimo dia 
        If Me.chNomina9.Checked Then
            If Me.dtFechaInicial.Value.Month = 12 And Me.dtFechaFinal.Value.Month = 12 Then
                arreTiposNomina.Add(1)
                arreTiposNomina.Add(2)
                arreTiposNomina.Add(9)
                arreTiposNomina.Add(8)
                arreTiposNomina.Add(23)
            Else
                arreTiposNomina.Add(1)
                arreTiposNomina.Add(2)
                arreTiposNomina.Add(9)
                arreTiposNomina.Add(23)
            End If

            Me.txtlog.Text += "Obteniendo reporte de nomina..." & Date.Now.ToShortTimeString & vbCrLf
            My.Application.DoEvents()
            'Me.arrDatosNomina = Me.cNomina.ObtenerNominaReal(Me.Centro, Me.dtFechaInicial.Value, Me.dtFechaFinal.Value, Me.arrEmpleadosBaja)
            Me.arrDatosNomina = Me.cNomina.pGenerarReporteNominaXML(arreTiposNomina, Me.dtFechaInicial.Value, Me.dtFechaFinal.Value, Me.Centro, Me.arrEmpleadosBaja)
        Else
            Me.txtlog.Text += "Obteniendo reporte de nomina..." & Date.Now.ToShortTimeString & vbCrLf
            My.Application.DoEvents()
            arreTiposNomina.Add(1)
            Me.arrDatosNomina = Me.cNomina.pGenerarReporteNominaXML(arreTiposNomina, Me.dtFechaInicial.Value, Me.dtFechaFinal.Value, Me.Centro, Me.arrEmpleadosBaja)
            ' Dim mensaje As String
            'txtlog.Text = nominalog.mensajelog
            '= mensaje
        End If

        'Obtenemos los empleados que han sido dados de baja y que no tienen movimientos en esta nomina, sin embargo devolvemos el ultimo pago que se realizo.
        Dim i As Int32
        empBajas = 0
        For i = 0 To Me.arrEmpleadosBaja.Count - 1
            With CType(Me.arrEmpleadosBaja(i), clsEmpleadoBaja)
                If Not .NominaActual Then

                    arreTiposNomina.Add(1)
                    .NominaEmpleado = Me.cNomina.ObtenerNominaEmpleadoBaja(Me.Centro, .TarjetaID, Me.dtFechaInicial.Value, .FechaBaja)
                    empBajas += 1
                End If
            End With
        Next
    End Sub

    Public Sub ObtenerEdadSexoCurpBase()
        If Me.arrDatosNomina.Count = 0 Then
            MessageBox.Show("No hay ningun registro en el centro: " & Me.Centro)
        Else
            Me.ProgressBar1.Value = 1
            Me.ProgressBar1.Value = 0.0
            Me.ProgressBar1.Maximum = Me.arrDatosNomina.Count - 1
            CONTADOR = 0

            'Obtenemos las edades de la base
            Me.arrEmpleadosEdad = New ArrayList
            For i As Int32 = 0 To Me.arrDatosNomina.Count - 1  'Obtenemos los datos de edad, sexo, curp por cada Empleado

                Me.arrEmpleadosEdad.Add(Me.cNomina.ObtieneEdadesPorPersona(CType(Me.arrDatosNomina(i), clsNomina).Empleado, Me.Centro, Me.dtFechaInicial.Value, Me.dtFechaFinal.Value))
                If CONTADOR < Me.arrDatosNomina.Count - 1 Then
                    Me.ProgressBar1.Value = CONTADOR
                    CONTADOR += 1
                Else
                    Me.ProgressBar1.Value = CONTADOR
                    CONTADOR += 1
                End If
            Next
        End If
    End Sub
    Public Sub ObtenerEdadSexoCurpBaseEmpBaja()
        If Me.arrEmpleadosBaja.Count <> 0 Then
            Dim finicio As Date

            If Me.dtFechaInicial.Value.Day = 1 Then
                finicio = DateSerial(Year(Me.dtFechaInicial.Value.Date), Month(Me.dtFechaInicial.Value.Date) - 1, 15)
            ElseIf Me.dtFechaInicial.Value.Day = 15 Then
                finicio = DateSerial(Year(Me.dtFechaInicial.Value.Date), Month(Me.dtFechaInicial.Value.Date), 1)
            End If
            'Obtenemos las edades de la base
            Me.arrEmpleadosEdadBaja = New ArrayList
            For i As Int32 = 0 To Me.arrEmpleadosBaja.Count - 1  'Obtenemos los datos de edad, sexo, curp por cada Empleado
                Me.arrEmpleadosEdadBaja.Add(Me.cNomina.ObtieneEdadesPorPersona(CType(Me.arrEmpleadosBaja(i), clsEmpleadoBaja).TarjetaID, Me.Centro, finicio, Me.dtFechaFinal.Value))
                My.Application.DoEvents()
            Next
        End If
    End Sub
    Private Sub txtSeguro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSeguro.TextChanged
        If Not IsNumeric(Me.txtSeguro.Text) Then
            MessageBox.Show("Digite un número valido para el Seguro de Vida")
        End If
    End Sub

    Private Sub txtPrimaRiesgo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrimaRiesgo.TextChanged
        If Not IsNumeric(Me.txtPrimaRiesgo.Text) Then
            MessageBox.Show("Digite un número valido para la Prima de Riesgo")
        Else
            Me.cRT = New clsRT(Me.Centro, 32, 2014, 5, CDbl(Me.txtPrimaRiesgo.Text))
        End If
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim finicio, ffin As Date

    '    If Me.dtFechaInicial.Value.Day = 1 Then
    '        finicio = DateSerial(Year(Me.dtFechaInicial.Value.Date), Month(Me.dtFechaInicial.Value.Date) - 1, 15)
    '        ffin = DateSerial(Year(Me.dtFechaInicial.Value.Date), Month(Me.dtFechaInicial.Value.Date), 0)
    '    ElseIf Me.dtFechaInicial.Value.Day = 15 Then
    '        finicio = DateSerial(Year(Me.dtFechaInicial.Value.Date), Month(Me.dtFechaInicial.Value.Date), 1)
    '        ffin = DateSerial(Year(Me.dtFechaInicial.Value.Date), Month(Me.dtFechaInicial.Value.Date), 15)
    '    End If
    '    MessageBox.Show("Inicio: " + finicio.Date.ToString() + "   Final:    " + ffin.Date.ToString())
    'End Sub

    Private Sub chNomina9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chNomina9.CheckedChanged
        If Me.chNomina9.Checked Then
            Me.chNomina.Checked = False
            Me.btnExportarE.Enabled = False
            Me.btnExportarR.Enabled = True
        Else
            Me.chNomina.Checked = True
            Me.btnExportarE.Enabled = True
            Me.btnExportarR.Enabled = False
        End If
    End Sub

    Private Sub chNomina_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chNomina.CheckedChanged
        If Me.chNomina.Checked Then
            Me.chNomina9.Checked = False
            Me.btnExportarE.Enabled = True
            Me.btnExportarR.Enabled = False
        Else
            Me.chNomina9.Checked = True
            Me.btnExportarE.Enabled = False
            Me.btnExportarR.Enabled = True
        End If
    End Sub


    Private Sub btnHaberes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHaberes.Click
        Me.OpenFileDialog3.ShowDialog()
        Me.txtHaberesArchivo.Text = Me.ArchivoH
        If Me.ArchivoH <> "" Then
            Me.ObtenerDatosdeExcelHaberes()
        End If
    End Sub

    Private Sub btnInsertarBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertarBase.Click
        Dim cH As clsHaberesHandler
        cH = New clsHaberesHandler(Funciones.GetConnectionStringHaberes)
        'Me.txtHaberesBase.Text = cH.ObtenerInfoAnterior()
        'Me.txtHaberesBase.Text += Me.txtTotalAnualBD.Text
        If Me.bandera = False Then
            MessageBox.Show("Valide antes de insertar")
        Else
            cH.PasarTablaTemporal()
            Me.MuestraInformacion()
            'Me.txtTotalAnualBD.Text = cH.ObtieneTotalAnualHaberes()
            '   Me.txtHaberesBase.Text = cH.ObtenerInfoAnterior
            Me.chkNomina.Items.Clear()
            Me.txtSumaHaberes.Clear()
            Me.txtHaberesArchivo.Clear()
            Me.bandera = False
        End If
    End Sub


    Private Sub btnVerificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerificar.Click
        Dim cH As clsHaberesHandler
        cH = New clsHaberesHandler(Funciones.GetConnectionStringHaberes)

        For idx As Integer = 0 To Me.chkNomina.Items.Count - 1
            Me.chkNomina.SetItemCheckState(idx, CheckState.Checked)
        Next

        Me.TotalHaberes = 0
        For Each itemchecked In chkNomina.CheckedItems
            Me.TotalHaberes += CDbl(itemchecked)
        Next
        Me.txtSumaHaberes.Text = Me.TotalHaberes.ToString

        Me.bandera = True
    End Sub

    Private Sub txtHAnual_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHAnual.TextChanged
        If Not IsNumeric(Me.txtHAnual.Text) Then
            MessageBox.Show("Favor de proporcionar un valor numerico")
        End If
    End Sub

    Public Sub MuestraInformacion()

        Dim cH As clsHaberesHandler
        cH = New clsHaberesHandler(Funciones.GetConnectionStringHaberes)
        Me.arrHMeses = cH.ObtenerInfoMeses()



        Try
            Me.lstView.Items.Clear()
            If Me.arrHMeses.Count > 0 Then
                Dim j As Int16
                Dim c As clsMesesMontos


                Me.lstView.FullRowSelect = True
                Me.lstView.MultiSelect = False
                Dim grupoActual As String = String.Empty
                Dim g As New ListViewGroup
                For j = 0 To Me.arrHMeses.Count - 1
                    c = Me.arrHMeses(j)

                    With c



                        If c.Cliente <> grupoActual Then
                            g = New ListViewGroup(c.Cliente)
                            grupoActual = c.Cliente
                            Me.lstView.Groups.Add(g)
                        End If

                        Dim item As New ListViewItem("")


                        If cbxlista.SelectedItem = c.an Then
                            If c.Cliente = grupoActual Then


                                item.SubItems.Add(c.Mes)
                                item.SubItems.Add(c.an)
                                item.SubItems.Add(c.NumNomina.ToString())
                                item.SubItems.Add(c.Monto.ToString())
                                item.Group = g
                                Me.lstView.Items.Add(item)
                            End If
                        End If


                    End With
                Next
            End If

        Catch ex As Exception
        End Try
    End Sub

    ''nuevo



    ''nuevo

    Public Function ValidaMes(ByVal cliente As String, ByVal mes As Int32, ByVal numNomina As Int32, ByVal numan As Int32) As Boolean
        Try
            Dim band As Boolean = False
            For Each c As clsMesesMontos In Me.arrHMeses
                If c.idMes = mes And c.Cliente = cliente And c.NumNomina = numNomina And c.an = numan Then
                    band = True
                    Return band
                End If
            Next
            Return band
        Catch ex As Exception

        End Try
    End Function


    Private Sub btnEliminarTemporal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cH As clsHaberesHandler
        cH = New clsHaberesHandler(Funciones.GetConnectionStringHaberes)
        cH.EliminaTemporal()
        MessageBox.Show("Datos temporales se han eliminado")
    End Sub


    Private Sub EliminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarToolStripMenuItem.Click
        'If MessageBox.Show("Realmente deseas eliminar la nomina: [" + CType(Me.arrHMeses(Me.lstView.SelectedItems(0).Index), clsMesesMontos).NumNomina.ToString + "] del mes de [" + CType(Me.arrHMeses(Me.lstView.SelectedItems(0).Index), clsMesesMontos).Mes + "] del cliente [" + CType(Me.arrHMeses(Me.lstView.SelectedItems(0).Index), clsMesesMontos).Cliente + "] ?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
        '    'If MessageBox.Show("Realmente deseas eliminar la nomina: [" + CType(Me.arrHMeses(Me.dgvTablaMeses.CurrentRow.Index), clsMesesMontos).NumNomina.ToString + "] del mes de [" + CType(Me.arrHMeses(Me.dgvTablaMeses.CurrentRow.Index), clsMesesMontos).Mes + "] del cliente [" + CType(Me.arrHMeses(Me.dgvTablaMeses.CurrentRow.Index), clsMesesMontos).Cliente + "] ?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
        '    Dim cH As clsHaberesHandler
        '    cH = New clsHaberesHandler(Funciones.GetConnectionStringHaberes)
        '    With CType(Me.arrHMeses(Me.lstView.SelectedItems(0).Index), clsMesesMontos)
        '        cH.EliminaHaberesNominaMes(.Cliente, .idMes, .NumNomina)
        '    End With
        '    'cH.EliminaHaberesMes(CType(Me.arrHMeses(Me.dgvTablaMeses.CurrentRow.Index), clsMesesMontos).idMes)

        '    Me.MuestraInformacion()
        Dim cliente As String

        If Me.lstView.Items.Count > 0 Then
            Dim i As Integer
            For Each i In Me.lstView.SelectedIndices
                cliente = Me.lstView.Items(i).Group.Header


            Next
        End If

        If MessageBox.Show("Realmente deseas eliminar la nomina:  [" + cliente + "] ?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
            'If MessageBox.Show("Realmente deseas eliminar la nomina: [" + CType(Me.arrHMeses(Me.dgvTablaMeses.CurrentRow.Index), clsMesesMontos).NumNomina.ToString + "] del mes de [" + CType(Me.arrHMeses(Me.dgvTablaMeses.CurrentRow.Index), clsMesesMontos).Mes + "] del cliente [" + CType(Me.arrHMeses(Me.dgvTablaMeses.CurrentRow.Index), clsMesesMontos).Cliente + "] ?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
            Dim cH As clsHaberesHandler
            cH = New clsHaberesHandler(Funciones.GetConnectionStringHaberes)
            With CType(Me.arrHMeses(Me.lstView.SelectedItems(0).Index), clsMesesMontos)
                cH.EliminaHaberesNominaMes(.Cliente, .idMes, .NumNomina)
            End With
            'cH.EliminaHaberesMes(CType(Me.arrHMeses(Me.dgvTablaMeses.CurrentRow.Index), clsMesesMontos).idMes)

            Me.MuestraInformacion()
        End If

    End Sub

    Private Sub DetallesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetallesToolStripMenuItem.Click
        Try

            Dim cliente As String
            If Me.lstView.Items.Count > 0 Then
                Dim i As Integer
                For Each i In Me.lstView.SelectedIndices
                    cliente = Me.lstView.Items(i).Group.Header

                Next
            End If
            Using ventana As New frmHaberesDetalles
                'ventana.ShowDialog(Me, CType(Me.arrHMeses(Me.lstView.SelectedItems(0).Index), clsMesesMontos).Cliente, CDbl(Me.txtHAnual.Text))
                ventana.ShowDialog(Me, cliente, Me.cbxlista.SelectedItem, CDbl(Me.txtHAnual.Text))
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiar.Click
        Clipboard.Clear()
        Me.CopyListViewToClipboard(Me.lstView)

        'Copia solo las celdas seleccionadas
        'Clipboard.SetText(ListView1.SelectedItems(0).Text)
        'Clipboard.SetText(Me.lstView.Items)
    End Sub
    Public Sub CopyListViewToClipboard(ByVal lv As ListView)
        Dim buffer As New StringBuilder

        If Me.arrHMeses.Count > 0 Then
            Dim j As Int16
            Dim c As clsMesesMontos

            For j = 0 To Me.arrHMeses.Count - 1
                c = Me.arrHMeses(j)
                With c
                    If j = 0 Then
                        buffer.Append("CLIENTE")
                        buffer.Append(vbTab)
                        buffer.Append("MES")
                        buffer.Append(vbTab)
                        buffer.Append("NOMINA")
                        buffer.Append(vbTab)
                        buffer.Append("MONTO")
                        buffer.Append(vbTab)
                        buffer.Append("AÑO")
                        buffer.Append(vbTab)
                        buffer.Append(vbCrLf)
                    End If
                    buffer.Append(.Cliente)
                    buffer.Append(vbTab)
                    buffer.Append(.idMes.ToString())
                    buffer.Append(vbTab)
                    buffer.Append(.NumNomina.ToString())
                    buffer.Append(vbTab)
                    buffer.Append(.Monto.ToString())
                    buffer.Append(vbTab)
                    buffer.Append(.an.ToString())
                    buffer.Append(vbTab)
                    buffer.Append(vbCrLf)
                End With
            Next
            My.Computer.Clipboard.SetText(buffer.ToString)
        End If
    End Sub

    Private Sub btnBuscarEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarEmp.Click
        Try
            Dim c As clsHaberesBusqueda
            Dim ch As New clsHaberesHandler(Funciones.GetConnectionStringHaberes)
            c = ch.ObtenerHabClienteEmpleado(Me.cmbBuscar.SelectedIndex + 1, Me.txtEmpleadoBuscar.Text.Trim(), Me.cmbann1.SelectedItem)
            If c Is Nothing Then
                MessageBox.Show("No se encontro ningun empleado")
            Else
                Using ventana As New frmEmpleadoNomina
                    ventana.ShowDialog(Me, c.Cliente, c.Empleado, CDbl(Me.txtHAnual.Text))
                    Me.txtEmpleadoBuscar.Clear()
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub EditarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarToolStripMenuItem.Click
        Me.txtHAnual.ReadOnly = False
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.MuestraInformacion()
    End Sub

  

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim conn As New SqlConnection("Data Source= 201.139.106.58;Initial Catalog= hitss;user id=sicossadmi;password=ipp2012") ' Remotamente
        'Dim conn As New SqlConnection("Data Source= 192.168.2.82;Initial Catalog= hitss;user id=sicossadmi;password=ipp2012") ' Cliente
        Dim dr As SqlDataReader
        'Dim arre As New ArrayList
        'Dim cNomina As clsNomina

        Try
            Using comm As New SqlCommand("reindexar", conn)
                With comm
                    .CommandType = CommandType.StoredProcedure
                    .CommandTimeout = 0

                End With
                conn.Open()
                dr = comm.ExecuteReader
                dr.Close()
            End Using

        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            MessageBox.Show("No se pudo realizar el proceso de actualización... " + ex.Message)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try

            MessageBox.Show("La base de datos a sido actualizada")
        End Try
    End Sub



   
End Class