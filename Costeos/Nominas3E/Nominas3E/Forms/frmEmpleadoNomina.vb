Public Class frmEmpleadoNomina
    Private m_Cliente As String
    Private m_Empleado As String
    Private m_ann As String
    Private m_arrNominasEmpleado As ArrayList
    Private m_LimiteAño As Double
    Private M1, M2, M3, M4, M5, M6, M7, M8, M9, M10, M11, M12 As Double

    Private obExcel As Object
    Private obLibro As Object
    Private obHoja As Object
    Private archivo As String

    Public Sub MuestraInformacion()
        Dim cH As clsHaberesHandler
        cH = New clsHaberesHandler(Funciones.GetConnectionStringHaberes)

        Dim bol As Boolean = False

        Me.m_arrNominasEmpleado = New ArrayList

        'Parametros para IAS
        Me.M1 = 0 : Me.M2 = 0 : Me.M3 = 0 : Me.M4 = 0 : Me.M5 = 0 : Me.M6 = 0 : Me.M7 = 0 : Me.M8 = 0 : Me.M9 = 0 : Me.M10 = 0 : Me.M11 = 0 : Me.M12 = 0

        Me.m_arrNominasEmpleado = cH.ObtenerHaberesNominaEmpleado(Me.m_Cliente, Me.m_Empleado, frmNomina.cmbann1.SelectedItem)
        Try
            If Me.m_arrNominasEmpleado.Count > 0 Then
                Dim j As Int16
                Dim c As clsHaberesNominaEmpleado
                Dim totalA As Double = 0
                Dim totalIAS As Double = 0
                Dim totalH As Double = 0

                'Limpiamos el data grid
                Me.dgvNominaEmpleado.Rows.Clear()
                'Me.mTotalHaberes = 0
                For j = 0 To Me.m_arrNominasEmpleado.Count - 1
                    c = Me.m_arrNominasEmpleado(j)
                    With c
                        totalA += .Monto
                        Me.dgvNominaEmpleado.Rows.Add(c)
                        Me.dgvNominaEmpleado.Rows(j).Cells(0).Value = .Cliente
                        Me.dgvNominaEmpleado.Rows(j).Cells(1).Value = .Nomina
                        Me.dgvNominaEmpleado.Rows(j).Cells(2).Value = .Empleado
                        Me.dgvNominaEmpleado.Rows(j).Cells(3).Value = .NombreEmpleado
                        Me.dgvNominaEmpleado.Rows(j).Cells(4).Value = .Mes
                        Me.dgvNominaEmpleado.Rows(j).Cells(5).Value = .NoNomina
                        If bol = True Then
                            Me.dgvNominaEmpleado.Rows(j).Cells(6).Value = 0
                            Me.dgvNominaEmpleado.Rows(j).Cells(7).Value = .Monto
                            totalIAS += .Monto

                            ''*** CASO PARA PIRAMIDADOR
                            Select Case .Mes  'Caso de IAS que se usara para piramidador
                                Case 1 : Me.M1 += .Monto
                                Case 2 : Me.M2 += .Monto
                                Case 3 : Me.M3 += .Monto
                                Case 4 : Me.M4 += .Monto
                                Case 5 : Me.M5 += .Monto
                                Case 6 : Me.M6 += .Monto
                                Case 7 : Me.M7 += .Monto
                                Case 8 : Me.M8 += .Monto
                                Case 9 : Me.M9 += .Monto
                                Case 10 : Me.M10 += .Monto
                                Case 11 : Me.M11 += .Monto
                                Case 12 : Me.M12 += .Monto
                            End Select
                            ''***
                        Else
                            If totalA >= Me.m_LimiteAño Then  ' Entra por primera vez a IAS pues rebasa Monto Anual
                                Me.dgvNominaEmpleado.Rows(j).Cells(6).Value = Me.m_LimiteAño - (totalA - .Monto)
                                Me.dgvNominaEmpleado.Rows(j).Cells(7).Value = .Monto - (Me.m_LimiteAño - (totalA - .Monto))
                                bol = True
                                totalH = Me.m_LimiteAño
                                totalIAS += .Monto - (Me.m_LimiteAño - (totalA - .Monto))

                                ''*** CASO PARA PIRAMIDADOR
                                Select Case .Mes  'Caso de IAS que se usara para piramidador
                                    Case 1 : Me.M1 += .Monto - (Me.m_LimiteAño - (totalA - .Monto))
                                    Case 2 : Me.M2 += .Monto - (Me.m_LimiteAño - (totalA - .Monto))
                                    Case 3 : Me.M3 += .Monto - (Me.m_LimiteAño - (totalA - .Monto))
                                    Case 4 : Me.M4 += .Monto - (Me.m_LimiteAño - (totalA - .Monto))
                                    Case 5 : Me.M5 += .Monto - (Me.m_LimiteAño - (totalA - .Monto))
                                    Case 6 : Me.M6 += .Monto - (Me.m_LimiteAño - (totalA - .Monto))
                                    Case 7 : Me.M7 += .Monto - (Me.m_LimiteAño - (totalA - .Monto))
                                    Case 8 : Me.M8 += .Monto - (Me.m_LimiteAño - (totalA - .Monto))
                                    Case 9 : Me.M9 += .Monto - (Me.m_LimiteAño - (totalA - .Monto))
                                    Case 10 : Me.M10 += .Monto - (Me.m_LimiteAño - (totalA - .Monto))
                                    Case 11 : Me.M11 += .Monto - (Me.m_LimiteAño - (totalA - .Monto))
                                    Case 12 : Me.M12 += .Monto - (Me.m_LimiteAño - (totalA - .Monto))
                                End Select
                                ''***
                            Else
                                Me.dgvNominaEmpleado.Rows(j).Cells(6).Value = .Monto
                                Me.dgvNominaEmpleado.Rows(j).Cells(7).Value = 0
                                totalH += .Monto
                            End If
                        End If
                        

                        'If totalA > Me.mTotalA Then : Me.dgvEmpleadosHaberes.Rows(j).DefaultCellStyle.BackColor = Color.Aqua : End If

                        'If .M1 > Me.mTotalM Then : Me.dgvEmpleadosHaberes.Rows(j).Cells(4).Style.ForeColor = Color.Red : End If
                    End With
                    'Me.mTotalHaberes += totalA
                Next
                Me.dgvNominaEmpleado.Rows.Add()
                Me.dgvNominaEmpleado.Rows(j).Cells(0).Value = "TOTAL ACUMULADO"
                Me.dgvNominaEmpleado.Rows(j).Cells(6).Value = totalH   'A
                Me.dgvNominaEmpleado.Rows(j).Cells(7).Value = totalIAS
                Me.dgvNominaEmpleado.Rows(j).DefaultCellStyle.Font = New Font(dgvNominaEmpleado.Font, FontStyle.Bold)

                'Me.txtMonto.Text = Me.mTotalHaberes.ToString
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Overloads Sub ShowDialog(ByRef frmParent As Form, ByVal titulo As String, ByVal empleado As String, ByVal limiteAño As Double)
        Try
            Me.m_Cliente = titulo
            Me.m_Empleado = empleado
            Me.m_LimiteAño = limiteAño   ''Agregar IAS cuando monto haya sobrepasado
            Me.MuestraInformacion()
            MyBase.ShowDialog(frmParent)
        Catch ex As Exception
            MsgBox("Error no controlado", MsgBoxStyle.Critical, "Error")
            Me.Close()
        End Try
    End Sub

    Private Sub frmEmpleadoNomina_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCalculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculo.Click

        Me.CopiarArchivo()
        Me.ObtenerDatosdeExcel()
        MessageBox.Show("Exportacion de datos correctamente....")
    End Sub


    Public Sub CopiarArchivo()
        Me.archivo = "C:\Nominas\IAS_Piramidador" & Me.m_Empleado & "_" & ConvierteFechaCadena(DateTime.Now()) & ".xlsx"
        FileCopy("C:\Nominas\IAS_Piramidador.xlsx", Me.archivo)
    End Sub
    Public Function ConvierteFechaCadena(ByVal fecha As Date) As String
        Dim fechaStr As String
        fechaStr = fecha.ToString("yyyyMMdd")
        Return fechaStr
    End Function

    Public Sub ObtenerDatosdeExcel()
        Try
            'Creamos una instancia de Excel
            Me.obExcel = CreateObject("Excel.Application")
            Me.obLibro = Me.obExcel.workbooks.open(Me.archivo)
            Me.obHoja = Me.obLibro.worksheets(3)
            Me.obHoja.activate()
            Me.obHoja.application.visible = True
            Me.CargarIAS_en_Excel()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub CargarIAS_en_Excel()
        Dim i As Int32
        'Dim c As clsNomina
        i = 3

        Me.obHoja.cells(i, 2) = Me.M1
        Me.obHoja.cells(i, 3) = Me.M2
        Me.obHoja.cells(i, 4) = Me.M3
        Me.obHoja.cells(i, 5) = Me.M4
        Me.obHoja.cells(i, 6) = Me.M5
        Me.obHoja.cells(i, 7) = Me.M6
        Me.obHoja.cells(i, 8) = Me.M7
        Me.obHoja.cells(i, 9) = Me.M8
        Me.obHoja.cells(i, 10) = Me.M9
        Me.obHoja.cells(i, 11) = Me.M10
        Me.obHoja.cells(i, 12) = Me.M11
        Me.obHoja.cells(i, 13) = Me.M12

        ' Cierra todo
        'oBook.Close(True)
        Me.obLibro.close(True)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(Me.obLibro)
        Me.obLibro = Nothing
        'System.Runtime.InteropServices.Marshal.ReleaseComObject(oBooks)
        'oBooks = Nothing
        Me.obExcel.Quit()
        System.Runtime.InteropServices.Marshal.ReleaseComObject(Me.obExcel)
        Me.obExcel = Nothing

    End Sub

   
    Private Sub frmEmpleadoNomina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class