Public Class frmHaberesDetalles
    Private arrAnual As ArrayList
    Private mTitulo As String
    Private mann As String
    Private mTotalA As Double
    Private mTotalHaberes As Double

    Private Sub frmHaberesDetalles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
    Public Sub MuestraInformacion()
        Dim cH As clsHaberesHandler
        cH = New clsHaberesHandler(Funciones.GetConnectionStringHaberes)
        Dim bol As Boolean = False

        Me.arrAnual = New ArrayList

        Me.arrAnual = cH.ObtenerHaberesAnual(Me.mTitulo, Me.mann)
        Try
            If Me.arrAnual.Count > 0 Then
                Dim j As Int16
                Dim c As clsHaberesAnual
                Dim totalA, totalH, totalIAS As Double
                'Limpiamos el data grid
                Me.dgvEmpleadosHaberes.Rows.Clear()
                Me.mTotalHaberes = 0
                For j = 0 To Me.arrAnual.Count - 1
                    c = Me.arrAnual(j)
                    totalA = 0 : totalH = 0 : totalIAS = 0 : bol = False
                    With c
                        totalA = .M1 + .M2 + .M3 + .M4 + .M5 + .M6 + .M7 + .M8 + .M9 + .M10 + .M11 + .M12
                        Me.dgvEmpleadosHaberes.Rows.Add(c)
                        Me.dgvEmpleadosHaberes.Rows(j).Cells(0).Value = .Cliente
                        Me.dgvEmpleadosHaberes.Rows(j).Cells(1).Value = .Nomina
                        Me.dgvEmpleadosHaberes.Rows(j).Cells(2).Value = .Empleado
                        Me.dgvEmpleadosHaberes.Rows(j).Cells(3).Value = .NombreEmpleado

                        If .M1 >= Me.mTotalA Then 'Enero
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(4).Value = Me.mTotalA
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(5).Value = .M1 - Me.mTotalA 'IAS
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(4).Style.ForeColor = Color.Red
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(5).Style.ForeColor = Color.Red
                            totalH = Me.mTotalA
                            totalIAS = .M1 - Me.mTotalA
                            bol = True
                        Else
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(4).Value = .M1
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(5).Value = 0
                            totalH = .M1
                        End If

                        If bol = True Then 'Febrero
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(6).Value = 0
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(7).Value = .M2 'Se pasa el monto a IAS directamente
                            totalIAS += .M2
                        Else
                            If (.M2 + totalH) >= Me.mTotalA Then
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(6).Value = Me.mTotalA - totalH
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(7).Value = .M2 - (Me.mTotalA - totalH)
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(6).Style.ForeColor = Color.Red
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(7).Style.ForeColor = Color.Red
                                totalIAS = .M2 - (Me.mTotalA - totalH)
                                totalH = Me.mTotalA
                                bol = True
                            Else
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(6).Value = .M2
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(7).Value = 0
                                totalH += .M2
                            End If
                        End If

                        If bol = True Then 'Marzo
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(8).Value = 0
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(9).Value = .M3
                            totalIAS += .M3
                        Else
                            If (.M3 + totalH) >= Me.mTotalA Then
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(8).Value = Me.mTotalA - totalH
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(9).Value = .M3 - (Me.mTotalA - totalH)
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(8).Style.ForeColor = Color.Red
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(9).Style.ForeColor = Color.Red
                                totalIAS += .M3 - (Me.mTotalA - totalH)
                                totalH = Me.mTotalA
                                bol = True
                            Else
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(8).Value = .M3
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(9).Value = 0
                                totalH += .M3
                            End If
                        End If

                        If bol = True Then 'Abril
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(10).Value = 0
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(11).Value = .M4
                            totalIAS += .M4
                        Else
                            If (.M4 + totalH) >= Me.mTotalA Then
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(10).Value = Me.mTotalA - totalH
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(11).Value = .M4 - (Me.mTotalA - totalH)
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(10).Style.ForeColor = Color.Red
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(11).Style.ForeColor = Color.Red
                                totalIAS += .M4 - (Me.mTotalA - totalH)
                                totalH = Me.mTotalA
                                bol = True
                            Else
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(10).Value = .M4
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(11).Value = 0
                                totalH += .M4
                            End If
                        End If

                        If bol = True Then 'Mayo
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(12).Value = 0
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(13).Value = .M5
                            totalIAS += .M5
                        Else
                            If (.M5 + totalH) >= Me.mTotalA Then
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(12).Value = Me.mTotalA - totalH
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(13).Value = .M5 - (Me.mTotalA - totalH)
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(12).Style.ForeColor = Color.Red
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(13).Style.ForeColor = Color.Red
                                totalIAS += .M5 - (Me.mTotalA - totalH)
                                totalH = Me.mTotalA
                                bol = True
                            Else
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(12).Value = .M5
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(13).Value = 0
                                totalH += .M5
                            End If
                        End If

                        
                        If bol = True Then 'Junio
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(14).Value = 0
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(15).Value = .M6
                            totalIAS += .M6
                        Else
                            If (.M6 + totalH) >= Me.mTotalA Then
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(14).Value = Me.mTotalA - totalH
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(15).Value = .M6 - (Me.mTotalA - totalH)
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(14).Style.ForeColor = Color.Red
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(15).Style.ForeColor = Color.Red
                                totalIAS += .M6 - (Me.mTotalA - totalH)
                                totalH = Me.mTotalA
                                bol = True
                            Else
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(14).Value = .M6
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(15).Value = 0
                                totalH += .M6
                            End If
                        End If
                        
                        If bol = True Then 'Julio
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(16).Value = 0
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(17).Value = .M7
                            totalIAS += .M7
                        Else
                            If (.M7 + totalH) >= Me.mTotalA Then
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(16).Value = Me.mTotalA - totalH
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(17).Value = .M7 - (Me.mTotalA - totalH)
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(16).Style.ForeColor = Color.Red
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(17).Style.ForeColor = Color.Red
                                totalIAS += .M7 - (Me.mTotalA - totalH)
                                totalH += Me.mTotalA
                                bol = True
                            Else
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(16).Value = .M7
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(17).Value = 0
                                totalH += .M7
                            End If
                        End If
                        
                        If bol = True Then 'Agosto
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(18).Value = 0
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(19).Value = .M8
                            totalIAS += .M8
                        Else
                            If (.M8 + totalH) >= Me.mTotalA Then
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(18).Value = Me.mTotalA - totalH
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(19).Value = .M8 - (Me.mTotalA - totalH)
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(18).Style.ForeColor = Color.Red
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(19).Style.ForeColor = Color.Red
                                totalIAS += .M8 - (Me.mTotalA - totalH)
                                totalH += Me.mTotalA
                                bol = True
                            Else
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(18).Value = .M8
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(19).Value = 0
                                totalH += .M8
                            End If
                        End If
                        
                        If bol = True Then 'Septiembre
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(20).Value = 0
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(21).Value = .M9
                            totalIAS += .M9
                        Else
                            If (.M9 + totalH) >= Me.mTotalA Then
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(20).Value = Me.mTotalA - totalH
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(21).Value = .M9 - (Me.mTotalA - totalH)
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(20).Style.ForeColor = Color.Red
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(21).Style.ForeColor = Color.Red
                                totalIAS += .M9 - (Me.mTotalA - totalH)
                                totalH += Me.mTotalA
                                bol = True
                            Else
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(20).Value = .M9
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(21).Value = 0
                                totalH += .M9
                            End If
                        End If
                        
                        If bol = True Then 'octubre
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(22).Value = 0
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(23).Value = .M10
                            totalIAS += .M10
                        Else
                            If (.M10 + totalH) >= Me.mTotalA Then
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(22).Value = Me.mTotalA - totalH
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(23).Value = .M10 - (Me.mTotalA - totalH)
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(22).Style.ForeColor = Color.Red
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(23).Style.ForeColor = Color.Red
                                totalIAS += .M10 - (Me.mTotalA - totalH)
                                totalH += Me.mTotalA
                                bol = True
                            Else
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(22).Value = .M10
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(23).Value = 0
                                totalH += .M10
                            End If
                        End If
                        
                        If bol = True Then 'Noviembre
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(24).Value = 0
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(25).Value = .M11
                            totalIAS += .M11
                        Else
                            If (.M11 + totalH) >= Me.mTotalA Then
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(24).Value = Me.mTotalA - totalH
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(25).Value = .M11 - (Me.mTotalA - totalH)
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(24).Style.ForeColor = Color.Red
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(25).Style.ForeColor = Color.Red
                                totalIAS += .M11 - (Me.mTotalA - totalH)
                                totalH += Me.mTotalA
                                bol = True
                            Else
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(24).Value = .M11
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(25).Value = 0
                                totalH += .M11
                            End If
                        End If
                        
                        If bol = True Then 'Diciembre
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(26).Value = 0
                            Me.dgvEmpleadosHaberes.Rows(j).Cells(27).Value = .M12
                            totalH += .M12
                        Else
                            If (.M12 + totalH) >= Me.mTotalA Then
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(26).Value = Me.mTotalA - totalH
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(27).Value = .M12 - (Me.mTotalA - totalH)
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(26).Style.ForeColor = Color.Red
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(27).Style.ForeColor = Color.Red
                                totalIAS += .M12 - (Me.mTotalA - totalH)
                                totalH += Me.mTotalA
                                bol = True
                            Else
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(26).Value = .M12
                                Me.dgvEmpleadosHaberes.Rows(j).Cells(27).Value = 0
                                totalH += .M12
                            End If
                        End If
                        

                        Me.dgvEmpleadosHaberes.Rows(j).Cells(28).Value = totalH
                        Me.dgvEmpleadosHaberes.Rows(j).Cells(29).Value = totalIAS
                        Me.dgvEmpleadosHaberes.Rows(j).Cells(30).Value = totalA

                        'Me.dgvEmpleadosHaberes.Rows(j).Cells(5).Value = .M2
                        'Me.dgvEmpleadosHaberes.Rows(j).Cells(6).Value = .M3
                        'Me.dgvEmpleadosHaberes.Rows(j).Cells(7).Value = .M4
                        'Me.dgvEmpleadosHaberes.Rows(j).Cells(8).Value = .M5
                        'Me.dgvEmpleadosHaberes.Rows(j).Cells(9).Value = .M6
                        'Me.dgvEmpleadosHaberes.Rows(j).Cells(10).Value = .M7
                        'Me.dgvEmpleadosHaberes.Rows(j).Cells(11).Value = .M8
                        'Me.dgvEmpleadosHaberes.Rows(j).Cells(12).Value = .M9
                        'Me.dgvEmpleadosHaberes.Rows(j).Cells(13).Value = .M10
                        'Me.dgvEmpleadosHaberes.Rows(j).Cells(14).Value = .M11
                        'Me.dgvEmpleadosHaberes.Rows(j).Cells(15).Value = .M12
                        'Me.dgvEmpleadosHaberes.Rows(j).Cells(16).Value = totalA
                        'Me.dgvEmpleadosHaberes.Rows(j).Cells(17).Value = .Excedente

                        If totalA > Me.mTotalA Then : Me.dgvEmpleadosHaberes.Rows(j).DefaultCellStyle.BackColor = Color.LightBlue : End If

                        'If .M1 > Me.mTotalM Then : Me.dgvEmpleadosHaberes.Rows(j).Cells(4).Style.ForeColor = Color.Red : End If
                        'If .M2 > Me.mTotalM Then : Me.dgvEmpleadosHaberes.Rows(j).Cells(5).Style.ForeColor = Color.Red : End If
                        'If .M3 > Me.mTotalM Then : Me.dgvEmpleadosHaberes.Rows(j).Cells(6).Style.ForeColor = Color.Red : End If
                        'If .M4 > Me.mTotalM Then : Me.dgvEmpleadosHaberes.Rows(j).Cells(7).Style.ForeColor = Color.Red : End If
                        'If .M5 > Me.mTotalM Then : Me.dgvEmpleadosHaberes.Rows(j).Cells(8).Style.ForeColor = Color.Red : End If
                        'If .M6 > Me.mTotalM Then : Me.dgvEmpleadosHaberes.Rows(j).Cells(9).Style.ForeColor = Color.Red : End If
                        'If .M7 > Me.mTotalM Then : Me.dgvEmpleadosHaberes.Rows(j).Cells(10).Style.ForeColor = Color.Red : End If
                        'If .M8 > Me.mTotalM Then : Me.dgvEmpleadosHaberes.Rows(j).Cells(11).Style.ForeColor = Color.Red : End If
                        'If .M9 > Me.mTotalM Then : Me.dgvEmpleadosHaberes.Rows(j).Cells(12).Style.ForeColor = Color.Red : End If
                        'If .M10 > Me.mTotalM Then : Me.dgvEmpleadosHaberes.Rows(j).Cells(13).Style.ForeColor = Color.Red : End If
                        'If .M11 > Me.mTotalM Then : Me.dgvEmpleadosHaberes.Rows(j).Cells(14).Style.ForeColor = Color.Red : End If
                        'If .M12 > Me.mTotalM Then : Me.dgvEmpleadosHaberes.Rows(j).Cells(15).Style.ForeColor = Color.Red : End If
                    End With

                    Me.mTotalHaberes += totalA
                Next
                Me.txtMonto.Text = Me.mTotalHaberes.ToString
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Overloads Sub ShowDialog(ByRef frmParent As Form, ByVal titulo As String, ByVal ann As String, ByVal totalA As Double)
        Try
            Me.mTitulo = titulo
            Me.mann = ann
            Me.mTotalA = totalA
            Me.MuestraInformacion()
            MyBase.ShowDialog(frmParent)
        Catch ex As Exception
            MsgBox("Error no controlado", MsgBoxStyle.Critical, "Error")
            Me.Close()
        End Try
    End Sub


    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        For i As Integer = 0 To Me.dgvEmpleadosHaberes.Rows.Count - 1 '2
            For x As Integer = 0 To Me.dgvEmpleadosHaberes.ColumnCount - 1
                If Me.dgvEmpleadosHaberes.Rows(i).Cells(x).Value.ToString.Contains(Me.txtBuscar.Text) Then
                    Me.dgvEmpleadosHaberes.CurrentCell = Me.dgvEmpleadosHaberes.Rows(i).Cells(x)
                    Exit Sub
                End If
            Next x
        Next i
    End Sub

    Private Sub VerNominasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerNominasToolStripMenuItem.Click
        Using ventana As New frmEmpleadoNomina
            ventana.ShowDialog(Me, CType(Me.arrAnual(Me.dgvEmpleadosHaberes.CurrentRow.Index), clsHaberesAnual).Cliente, CType(Me.arrAnual(Me.dgvEmpleadosHaberes.CurrentRow.Index), clsHaberesAnual).Empleado, Me.mTotalA)
            'cH.EliminaHaberesMes(CType(Me.arrHMeses(Me.dgvTablaMeses.CurrentRow.Index), clsMesesMontos).idMes)
        End Using
    End Sub
End Class