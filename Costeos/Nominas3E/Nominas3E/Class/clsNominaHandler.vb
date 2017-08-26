Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Public Class clsNominaHandler
    Private m_Conn As String
    Public mensajelog As String

    Public Sub New(ByVal connectionString As String)
        Me.m_Conn = connectionString
    End Sub
    Public Function ObtenerNomina(ByVal Centro As String, ByVal FInicio As Date, ByVal FFin As Date, ByVal arrBajas As ArrayList) As ArrayList
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Dim j, i As Int32
            j = 0 : i = 0
            If FFin.Month <> FInicio.Month Then
                MessageBox.Show("Advertencia, el tipo caso se vera afectado por las fechas ingresadas que no corresponden al mismo mes...")
            End If

            Dim arrNominas As New ArrayList

            If FFin.Month = 12 And FInicio.Month = 12 Then

                Using comm As New SqlCommand("SELECT TBDEPTO.DESCRIPCION AS 'CLIENTE', TBPUESTO.DESCRIPCION AS 'PUESTO', E.TARJETA_ID AS 'NO. EMPLEADO', CONVERT(VARCHAR(10), E.FECHAINGRESO, 103) AS 'FECHA ALTA', " + _
                                         "CASE WHEN M.Mov_ID='B' THEN CONVERT(VARCHAR(10), M.FechaMov, 103) END AS 'FECHA BAJA', M.Mov_ID as MOV, E.PATERNO + ' ' + E.MATERNO + ' ' + E.NOMBRE AS 'NOMBRE DE EMPLEADO',  " + _
                                         "CONCEPTOS.[51] AS 'TIPO CASO', (M.SALARIO * 30) AS 'SUELDO NOMINAL MENSUAL', ISNULL(CONCEPTOS.[50], 0.00) AS 'FLEXIBLE BRUTO MENSUAL(PS/IAS)', ISNULL(CONCEPTOS.[53], 0) AS '5 Ó 7%',  " + _
                                         "M.SALARIO AS 'SUELDO DIARIO', M.INTEGRADOIMSS AS SDI, ISNULL(CONCEPTOS.[30], 0.00) AS 'DÍAS LABORADOS',  ISNULL(DATOS.[63], 0.00) AS 'DÍAS RETROACTIVOS',  " + _
                                         "ISNULL(CONCEPTOS.[14], 0.00) AS 'DÍAS FALTAS', ISNULL(DATOS.[6], 0.00) AS 'DIAS DE INC.ENF.GRAL.', ISNULL(DATOS.[9], 0.00) AS 'DIAS DE INC.MATERNIDAD',   " + _
                                         "ISNULL(DATOS.[7], 0.00)+ISNULL(DATOS.[8], 0.00) AS 'DIAS DE INC.RT O TRAYECTO', ISNULL(CONCEPTOS.[52], 0.00) AS 'FLEXIBLE QUINCENAL', ISNULL(CONCEPTOS.[54], 0.00) + ISNULL(CONCEPTOS.[64], 0.00)+ISNULL(CONCEPTOS.[80], 0.00) AS 'BONO UNICO BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[55], 0.00) AS 'BONO NEGOCIACION BR PS/IAS', ISNULL(CONCEPTOS.[56], 0.00) AS 'BONO ESPECIAL BR PS/IAS', ISNULL(CONCEPTOS.[57], 0.00) AS 'SUBSIDIO ENFERMEDAD GENERAL BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[58], 0.00) AS 'SUBSIDIO ACCIDENTE TRABAJO BR PS/IAS', ISNULL(CONCE PTOS.[59], 0.00) AS 'SUBSIDIO ACCIDENTE TRAYECTO BR PS/IAS', ISNULL(CONCEPTOS.[60], 0.00) AS 'SUBSIDIO MATERNIDAD BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[61], 0.00) AS 'BONO POR HORAS EXTRAS BR PS/IAS', ISNULL(CONCEPTOS.[63], 0.00) AS 'RETROACTIVO BR PS/IAS', ISNULL(CONCEPTOS.[201], 0.00) AS 'SUELDO', " + _
                                         "ISNULL(CONCEPTOS.[204], 0.00) AS 'RETROACTIVO SUELDO', ISNULL(CONCEPTOS.[212], 0.00) AS 'REEMBOLSO INFONAVIT', ISNULL(CONCEPTOS.[78], 0.00) AS 'PRIMA VACACIONAL ANIVERSARIO', " + _
                                         "ISNULL(CONCEPTOS.[231], 0.00) AS 'SUBSIDIO EG 1-3 DIAS', ISNULL(CONCEPTOS.[232], 0.00) AS 'SUBSIDIO EG 4 EN ADELANTE', ISNULL(CONCEPTOS.[79], 0.00) AS 'AGUINALDO ANUAL', " + _
                                         "ISNULL(CONCEPTOS.[77], 0.00) AS 'AGUINALDO FINIQUITO', ISNULL(CONCEPTOS.[282], 0.00) AS 'VACACIONES FINIQUITO', ISNULL(CONCEPTOS.[75], 0.00) AS 'PRIMA VACACIONAL FINIQUITO', " + _
                                         "ISNULL(CONCEPTOS.[233], 0.00) AS 'INDEMNIZACION 3 MESES', ISNULL(CONCEPTOS.[234], 0.00) AS 'INDEMNIZACION 20 DIAS', ISNULL(CONCEPTOS.[237], 0.00) AS 'NEGOCIACION GRAVADA', " + _
                                         "ISNULL(CONCEPTOS.[74], 0.00) AS 'PRIMA ANTIGÜEDAD 12 DIAS', ISNULL(CONCEPTOS.[211], 0.00) AS 'PTU', ISNULL(CONCEPTOS.[240], 0.00) AS 'SUBSIDIO PARA EL EMPLEO PAGADO', ISNULL(CONCEPTOS.[498], 0.00) AS 'PS DIAS LABORADOS', " + _
                                         "ISNULL(CONCEPTOS.[229], 0.00) AS 'PS RETROACTIVO', ISNULL(CONCEPTOS.[499], 0.00) AS 'IAS DIAS LABORADOS', ISNULL(CONCEPTOS.[230], 0.00) AS 'IAS DIAS PENDIENTES', ISNULL(CONCEPTOS.[494], 0.00) AS 'FLEXIBLE SUBSIDIOS INCAP.', " + _
                                         "ISNULL(CONCEPTOS.[495], 0.00)+ISNULL(CONCEPTOS.[492], 0.00)+ISNULL(CONCEPTOS.[493], 0.00) AS 'FLEXIBLE BONO', ISNULL(CONCEPTOS.[496], 0.00) AS 'FLEXIBLE BONO NEGOCIACION', " + _
                                         "ISNULL(CONCEPTOS.[497], 0.00) AS 'FLEXIBLE BONO ESPECIAL', ISNULL(CONCEPTOS.[500], 0.00) AS 'TOTAL PERCEPCIONES', ISNULL(CONCEPTOS.[501], 0.00) AS 'IMPUESTO RETENIDO', " + _
                                         "ISNULL(CONCEPTOS.[514], 0.00) AS 'IMPUESTO INDEMNIZACIÓN', ISNULL(CONCEPTOS.[503], 0.00) AS 'ISR AJUSTE ANNUAL 177', ISNULL(CONCEPTOS.[510], 0.00) AS 'IMSS', ISNULL(CONCEPTOS.[511], 0.00) AS 'DESC CREDITO INFONAVIT', " + _
                                         "ISNULL(CONCEPTOS.[525], 0.00) AS 'AJUSTE DIFERENCIA CRED INFONAVIT', ISNULL(CONCEPTOS.[521], 0.00) +ISNULL(CONCEPTOS.[513], 0.00) +ISNULL(CONCEPTOS.[515], 0.00)+ISNULL(CONCEPTOS.[516], 0.00) AS 'OTROS DESCUENTOS', " + _
                                         "ISNULL(CONCEPTOS.[520], 0.00) AS 'FONACOT', ISNULL(CONCEPTOS.[523], 0.00) AS 'PRESTAMO PERSONAL', ISNULL(CONCEPTOS.[524], 0.00) +ISNULL(CONCEPTOS.[552], 0.00) AS 'OTRAS DEDUCCIONES', " + _
                                         "ISNULL(CONCEPTOS.[522], 0.00) AS 'DESCUENTO PENSION ALIMENTICIA', ISNULL(CONCEPTOS.[700], 0.00) AS 'TOTAL DEDUCCIONES', ISNULL(CONCEPTOS.[900], 0.00) AS 'NETO A PAGAR', ISNULL(CONCEPTOS.[915], 0.00) AS 'IMSS EXCEDENTE PATRON', " + _
                                         "ISNULL(CONCEPTOS.[916], 0.00) AS 'IMSS PRESTACIONES EN DINERO', ISNULL(CONCEPTOS.[917], 0.00) AS 'IMSS PRESTACIONES EN ESPECIE', ISNULL(CONCEPTOS.[918], 0.00) AS 'IMSS IV PATRONAL', " + _
                                         "ISNULL(CONCEPTOS.[919], 0.00) AS 'IMSS PROVISION GUARDERIA', ISNULL(CONCEPTOS.[920], 0.00) AS 'IMSS RIESGO DE TRABAJO',ISNULL(CONCEPTOS.[921], 0.00) AS 'PROVISION SAR', ISNULL(CONCEPTOS.[922], 0.00) AS 'PROVISION INFONAVIT', " + _
                                         "ISNULL(CONCEPTOS.[923], 0.00) AS 'IMSS CV PATRONAL', ISNULL(CONCEPTOS.[924], 0.00) AS 'IMSS CUOTA FIJA', ISNULL(CONCEPTOS.[925], 0.00) AS 'IMSS PATRONAL', ISNULL(CONCEPTOS.[927], 0.00) AS 'IMSS OBRERO', " + _
                                         "ISNULL(CONCEPTOS.[976], 0.00) AS 'ISN', ISNULL(CONCEPTOS.[926], 0.00) AS 'CARGA SOCIAL', ISNULL(CONCEPTOS.[928], 0.00) AS 'COMISION NOMINA', ISNULL(CONCEPTOS.[962], 0.00) AS 'IVA',  ISNULL(CONCEPTOS.[975], 0.00) AS 'TOTAL A FACTURAR', " + _
                                         "(char(39)+E.CUENTADEPOSITO) AS CUENTA, (char(39)+E.CLABE)  AS CLABE, CASE WHEN E.BANCODEPOSITO=0 THEN ' ' WHEN E.BANCODEPOSITO=1 THEN 'BANCOMER' WHEN E.BANCODEPOSITO=2 THEN 'BANAMEX' WHEN E.BANCODEPOSITO=3 THEN 'COMERMEX' " + _
                                         "WHEN E.BANCODEPOSITO=4 THEN 'SERFIN' WHEN E.BANCODEPOSITO=5 THEN 'BANOBRAS' WHEN E.BANCODEPOSITO=6 THEN 'ATLANTCO'  WHEN E.BANCODEPOSITO=7 THEN 'CITIBANK'  WHEN E.BANCODEPOSITO=8 THEN  'CONFIA'  WHEN E.BANCODEPOSITO=9 THEN  'SANTANDER' " + _
                                         "WHEN E.BANCODEPOSITO=10 THEN 'MEXICANO'  WHEN E.BANCODEPOSITO=11 THEN  'IXE' WHEN E.BANCODEPOSITO=12 THEN 'FIN COMUN' WHEN E.BANCODEPOSITO=13 THEN 'SCOTIABANK'  WHEN E.BANCODEPOSITO=14 THEN 'BANORTE'  WHEN E.BANCODEPOSITO=15 THEN  'INBURSA' " + _
                                         "WHEN E.BANCODEPOSITO=16 THEN 'HSBC'  WHEN E.BANCODEPOSITO=17 THEN  'BANREGIO'  WHEN E.BANCODEPOSITO=18 THEN 'BANCO AZTECA'  WHEN E.BANCODEPOSITO=21 THEN 'BITAL' WHEN E.BANCODEPOSITO=30 THEN 'BBVA'  END AS BANCO " + _
                                         "FROM  EMPLEADO AS E INNER JOIN MOVIMIENTO AS M ON E.TRAB_ID = M.TRAB_ID INNER JOIN (SELECT  TRAB_ID, MAX(PTR) AS PTR FROM   MOVIMIENTO AS MOVIMIENTO_1 WHERE ( FECHAMOV <= '" + Format(FFin.Date, "dd/MM/yyyy") + "' ) and Centro_ID=" + Centro + " GROUP BY TRAB_ID) AS LM ON M.TRAB_ID = LM.TRAB_ID AND M.PTR = LM.PTR  " + _
                                         "INNER JOIN TBCENTROS  ON M.CENTRO_ID = TBCENTROS.CENTRO_ID INNER JOIN TBREGPAT  ON TBCENTROS.REGPAT_ID = TBREGPAT.REGPAT_ID INNER JOIN TBPUESTO  ON M.PUESTO_ID = TBPUESTO.PUESTO_ID INNER JOIN TBDEPTO  ON M.DEPTO_ID = TBDEPTO.DEPTO_ID " + _
                                         "INNER JOIN ANTIGUEDAD ON E.TRAB_ID = ANTIGUEDAD.TRAB_ID INNER JOIN (SELECT  ANTIGEMPL.TRAB_ID, TBFACTORINTEGRA.VACACIONES, TBFACTORINTEGRA.AGUINALDO, TBFACTORINTEGRA.PRIMA FROM TBFACTORINTEGRA  " + _
                                         "INNER JOIN (SELECT ANTFACT.TRAB_ID, MAX(TBFI.ANTIGUEDAD) AS ANTIG, ANTFACT.TIPOEMPLEADO_ID  FROM  TBFACTORINTEGRA AS TBFI INNER JOIN (SELECT  ANT.TRAB_ID, ANT.ANO + CAST(ANT.DIAS AS MONEY) / 1000 AS ANTIGUEDAD, " + _
                                         "MOVIMIENTO.TIPOEMPLEADO_ID FROM ANTIGUEDAD AS ANT INNER JOIN (SELECT  TRAB_ID, MAX(PTR) AS PTR FROM MOVIMIENTO AS MOVIMIENTO_2  WHERE ( FECHAMOV <= '" + Format(FFin.Date, "dd/MM/yyyy") + "' ) GROUP  BY TRAB_ID) AS LM_1 ON ANT.TRAB_ID = LM_1.TRAB_ID " + _
                                         "INNER JOIN MOVIMIENTO ON LM_1.TRAB_ID = MOVIMIENTO.TRAB_ID  AND LM_1.PTR = MOVIMIENTO.PTR) AS ANTFACT ON TBFI.ANTIGUEDAD <= ANTFACT.ANTIGUEDAD AND TBFI.TIPOEMPLEADO_ID = ANTFACT.TIPOEMPLEADO_ID " + _
                                         "GROUP  BY ANTFACT.TRAB_ID, ANTFACT.TIPOEMPLEADO_ID) AS ANTIGEMPL  ON TBFACTORINTEGRA.TIPOEMPLEADO_ID = ANTIGEMPL.TIPOEMPLEADO_ID AND TBFACTORINTEGRA.ANTIGUEDAD = ANTIGEMPL.ANTIG) AS FACTEMPL ON M.TRAB_ID = FACTEMPL.TRAB_ID " + _
                                         "INNER JOIN (SELECT * FROM (SELECT TRAB_ID, CONCEPTO_ID, IMPORTE FROM NomCalculohistorico WHERE ( INICIO >= '" + Format(FInicio.Date, "dd/MM/yyyy") + "' ) AND ( FINAL <= '" + Format(FFin.Date, "dd/MM/yyyy") + "') and Centro_ID =" + Centro + "  and tiponomina_id in (1,8) " + _
                                         "AND CONCEPTO_ID IN (51,50,30,14,6,9,7,8,52,54,57,58,59,60,61,63,201,204,78,231,232,79,77,282,503, 75,233,234,237,74,240,498,229,499,230,500,501,514,510,511,525,521,520,522,552,513,515,516,64,80,492,493,212,927, " + _
                                         "700,900,915,916,917,918,919,920,921,922,923,924,925,976,926,928,962,975,523,524,53,55,56,211,494,495,496,497)) AS CONCEPTOS  PIVOT (SUM(CONCEPTOS.IMPORTE) FOR CONCEPTOS.CONCEPTO_ID " + _
                                         "IN ([51],[50],[30],[14],[6],[9],[7],[8],[52],[54],[57],[58],[59],[60],[61],[63],[201],[204],[78],[231],[232],[79],[77],[282],  " + _
                                         "[75],[233],[234],[237],[74],[240],[498],[229],[499],[230],[500],[501],[514],[510],[511],[525],[521],[520],[522],[552],[513],[515],[516],[64],[80],[492],[493],[212],[927],[503],  " + _
                                         "[700],[900],[915],[916],[917],[918],[919],[920],[921],[922],[923],[924],[925],[976],[926],[928],[962],[975],[523],[524],[53],[55],[56],[211],[494],[495],[496],[497])) AS PIVOTTABLE) AS CONCEPTOS " + _
                                         "ON M.TRAB_ID = CONCEPTOS.TRAB_ID  /*para traer DATO */  INNER JOIN (SELECT * FROM (SELECT TRAB_ID, CONCEPTO_ID, Dato FROM NomCalculohistorico " + _
                                         "WHERE ( INICIO >= '" + Format(FInicio.Date, "dd/MM/yyyy") + "' ) AND ( FINAL <='" + Format(FFin.Date, "dd/MM/yyyy") + "' )  and Centro_ID =" + Centro + " and tiponomina_id in (1,8) " + _
                                         "AND CONCEPTO_ID IN (51,50,30,14,6,9,7,8,52,54,57,58,59,60,61,63,201,204,78,231,232,79,77,282,503, 75,233,234,237,74,240,498,229,499,230,500,501,514,510,511,525,521,520,522,552,513,515,516,64,80,492,493,212,927, " + _
                                         "700,900,915,916,917,918,919,920,921,922,923,924,925,976,926,928,962,975,523,524,53,55,56,211,494,495,496,497)) AS CONCEPTOS  PIVOT (SUM(Conceptos.DATO)  FOR CONCEPTOS.CONCEPTO_ID " + _
                                         "IN ([51],[50],[30],[14],[6],[9],[7],[8],[52],[54],[57],[58],[59],[60],[61],[63],[201],[204],[78],[231],[232],[79],[77],[282], " + _
                                         "[75],[233],[234],[237],[74],[240],[498],[229],[499],[230],[500],[501],[514],[510],[511],[525],[521],[520],[522],[552],[513],[515],[516],[64],[80],[492],[493],[212],[927],[503], " + _
                                         "[700],[900],[915],[916],[917],[918],[919],[920],[921],[922],[923],[924],[925],[976],[926],[928],[962],[975],[523],[524],[53],[55],[56],[211],[494],[495],[496],[497]) ) AS PIVOTTABLE) AS DATOS " + _
                                         "ON M.TRAB_ID = DATOS.TRAB_ID order by 'NOMBRE DE EMPLEADO'", conn)
                    comm.CommandType = CommandType.Text
                    comm.CommandTimeout = 20000
                    conn.Open()
                    dr = comm.ExecuteReader
                    While dr.Read
                        Dim c As clsNomina
                        Dim clabe As String
                        Dim banco As String
                        Dim tipoCaso As Int32 = 0
                        tipoCaso = CInt(dr("TIPO CASO"))

                        If IsDBNull(dr("CLABE")) Then
                            clabe = ""
                        Else
                            clabe = dr("CLABE")
                        End If

                        If IsDBNull(dr("BANCO")) Then
                            banco = ""
                        Else
                            banco = dr("BANCO")
                        End If

                        c = New clsNomina(dr("CLIENTE"), dr("PUESTO"), dr("NO. EMPLEADO"), CDate(dr("FECHA ALTA")), dr("MOV"), dr("NOMBRE DE EMPLEADO"), tipoCaso, dr("SUELDO NOMINAL MENSUAL"), dr("FLEXIBLE BRUTO MENSUAL(PS/IAS)"), _
                                          CInt(dr("5 Ó 7%")), dr("SUELDO DIARIO"), dr("SDI"), dr("DÍAS LABORADOS"), dr("DÍAS RETROACTIVOS"), dr("DÍAS FALTAS"), dr("DIAS DE INC.ENF.GRAL."), dr("DIAS DE INC.MATERNIDAD"), dr("DIAS DE INC.RT O TRAYECTO"), dr("FLEXIBLE QUINCENAL"), _
                                          dr("BONO UNICO BR PS/IAS"), dr("BONO NEGOCIACION BR PS/IAS"), dr("BONO ESPECIAL BR PS/IAS"), dr("SUBSIDIO ENFERMEDAD GENERAL BR PS/IAS"), dr("SUBSIDIO ACCIDENTE TRABAJO BR PS/IAS"), dr("SUBSIDIO ACCIDENTE TRAYECTO BR PS/IAS"), dr("SUBSIDIO MATERNIDAD BR PS/IAS"), dr("BONO POR HORAS EXTRAS BR PS/IAS"), dr("RETROACTIVO BR PS/IAS"), dr("SUELDO"), _
                                          dr("RETROACTIVO SUELDO"), dr("REEMBOLSO INFONAVIT"), dr("PRIMA VACACIONAL ANIVERSARIO"), dr("SUBSIDIO EG 1-3 DIAS"), dr("SUBSIDIO EG 4 EN ADELANTE"), dr("AGUINALDO ANUAL"), dr("AGUINALDO FINIQUITO"), dr("VACACIONES FINIQUITO"), dr("PRIMA VACACIONAL FINIQUITO"), dr("INDEMNIZACION 3 MESES"), _
                                          dr("INDEMNIZACION 20 DIAS"), dr("NEGOCIACION GRAVADA"), dr("PRIMA ANTIGÜEDAD 12 DIAS"), dr("PTU"), dr("SUBSIDIO PARA EL EMPLEO PAGADO"), dr("PS DIAS LABORADOS"), dr("PS RETROACTIVO"), dr("IAS DIAS LABORADOS"), dr("IAS DIAS PENDIENTES"), dr("FLEXIBLE SUBSIDIOS INCAP."), _
                                          CDbl(dr("FLEXIBLE BONO")), dr("FLEXIBLE BONO NEGOCIACION"), dr("FLEXIBLE BONO ESPECIAL"), dr("TOTAL PERCEPCIONES"), dr("IMPUESTO RETENIDO"), dr("IMPUESTO INDEMNIZACIÓN"), dr("ISR AJUSTE ANNUAL 177"), dr("IMSS"), dr("DESC CREDITO INFONAVIT"), dr("AJUSTE DIFERENCIA CRED INFONAVIT"), _
                                          dr("OTROS DESCUENTOS"), dr("FONACOT"), dr("PRESTAMO PERSONAL"), dr("OTRAS DEDUCCIONES"), dr("DESCUENTO PENSION ALIMENTICIA"), dr("TOTAL DEDUCCIONES"), dr("NETO A PAGAR"), dr("IMSS EXCEDENTE PATRON"), dr("IMSS PRESTACIONES EN DINERO"), dr("IMSS PRESTACIONES EN ESPECIE"), _
                                          dr("IMSS IV PATRONAL"), dr("IMSS PROVISION GUARDERIA"), dr("IMSS RIESGO DE TRABAJO"), dr("PROVISION SAR"), dr("PROVISION INFONAVIT"), dr("IMSS CV PATRONAL"), dr("IMSS CUOTA FIJA"), dr("IMSS PATRONAL"), dr("IMSS OBRERO"), dr("ISN"), _
                                          dr("CARGA SOCIAL"), dr("COMISION NOMINA"), dr("IVA"), dr("TOTAL A FACTURAR"), dr("CUENTA"), clabe, banco)
                        If Not IsDBNull(dr("FECHA BAJA")) Then
                            'MessageBox.Show(dr("FECHA BAJA").ToString & " --> " & dr("NO. EMPLEADO"))
                            c.FechaBaja = CDate(dr("FECHA BAJA"))
                            For i = j To arrBajas.Count - 1
                                If CType(arrBajas(i), clsEmpleadoBaja).TarjetaID = dr("NO. EMPLEADO") Then
                                    CType(arrBajas(i), clsEmpleadoBaja).NominaActual = True
                                    j = i + 1
                                    Exit For
                                End If
                            Next
                        End If

                        arrNominas.Add(c)
                    End While
                    dr.Close()
                End Using

            End If


            Using comm As New SqlCommand("SELECT TBDEPTO.DESCRIPCION AS 'CLIENTE', TBPUESTO.DESCRIPCION AS 'PUESTO', E.TARJETA_ID AS 'NO. EMPLEADO', CONVERT(VARCHAR(10), E.FECHAINGRESO, 103) AS 'FECHA ALTA', " + _
                                         "CASE WHEN M.Mov_ID='B' THEN CONVERT(VARCHAR(10), M.FechaMov, 103) END AS 'FECHA BAJA', M.Mov_ID as MOV, E.PATERNO + ' ' + E.MATERNO + ' ' + E.NOMBRE AS 'NOMBRE DE EMPLEADO',  " + _
                                         "CONCEPTOS.[51] AS 'TIPO CASO', (M.SALARIO * 30) AS 'SUELDO NOMINAL MENSUAL', ISNULL(CONCEPTOS.[50], 0.00) AS 'FLEXIBLE BRUTO MENSUAL(PS/IAS)', ISNULL(CONCEPTOS.[53], 0) AS '5 Ó 7%',  " + _
                                         "M.SALARIO AS 'SUELDO DIARIO', M.INTEGRADOIMSS AS SDI, ISNULL(CONCEPTOS.[30], 0.00) AS 'DÍAS LABORADOS',  ISNULL(DATOS.[63], 0.00) AS 'DÍAS RETROACTIVOS',  " + _
                                         "ISNULL(CONCEPTOS.[14], 0.00) AS 'DÍAS FALTAS', ISNULL(DATOS.[6], 0.00) AS 'DIAS DE INC.ENF.GRAL.', ISNULL(DATOS.[9], 0.00) AS 'DIAS DE INC.MATERNIDAD',   " + _
                                         "ISNULL(DATOS.[7], 0.00)+ISNULL(DATOS.[8], 0.00) AS 'DIAS DE INC.RT O TRAYECTO', ISNULL(CONCEPTOS.[52], 0.00) AS 'FLEXIBLE QUINCENAL', ISNULL(CONCEPTOS.[54], 0.00) + ISNULL(CONCEPTOS.[64], 0.00)+ISNULL(CONCEPTOS.[80], 0.00) AS 'BONO UNICO BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[55], 0.00) AS 'BONO NEGOCIACION BR PS/IAS', ISNULL(CONCEPTOS.[56], 0.00) AS 'BONO ESPECIAL BR PS/IAS', ISNULL(CONCEPTOS.[57], 0.00) AS 'SUBSIDIO ENFERMEDAD GENERAL BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[58], 0.00) AS 'SUBSIDIO ACCIDENTE TRABAJO BR PS/IAS', ISNULL(CONCEPTOS.[59], 0.00) AS 'SUBSIDIO ACCIDENTE TRAYECTO BR PS/IAS', ISNULL(CONCEPTOS.[60], 0.00) AS 'SUBSIDIO MATERNIDAD BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[61], 0.00) AS 'BONO POR HORAS EXTRAS BR PS/IAS', ISNULL(CONCEPTOS.[63], 0.00) AS 'RETROACTIVO BR PS/IAS', ISNULL(CONCEPTOS.[201], 0.00) AS 'SUELDO', " + _
                                         "ISNULL(CONCEPTOS.[204], 0.00) AS 'RETROACTIVO SUELDO', ISNULL(CONCEPTOS.[212], 0.00) AS 'REEMBOLSO INFONAVIT', ISNULL(CONCEPTOS.[78], 0.00) AS 'PRIMA VACACIONAL ANIVERSARIO', " + _
                                         "ISNULL(CONCEPTOS.[231], 0.00) AS 'SUBSIDIO EG 1-3 DIAS', ISNULL(CONCEPTOS.[232], 0.00) AS 'SUBSIDIO EG 4 EN ADELANTE', ISNULL(CONCEPTOS.[79], 0.00) AS 'AGUINALDO ANUAL', " + _
                                         "ISNULL(CONCEPTOS.[77], 0.00) AS 'AGUINALDO FINIQUITO', ISNULL(CONCEPTOS.[282], 0.00) AS 'VACACIONES FINIQUITO', ISNULL(CONCEPTOS.[75], 0.00) AS 'PRIMA VACACIONAL FINIQUITO', " + _
                                         "ISNULL(CONCEPTOS.[233], 0.00) AS 'INDEMNIZACION 3 MESES', ISNULL(CONCEPTOS.[234], 0.00) AS 'INDEMNIZACION 20 DIAS', ISNULL(CONCEPTOS.[237], 0.00) AS 'NEGOCIACION GRAVADA', " + _
                                         "ISNULL(CONCEPTOS.[74], 0.00) AS 'PRIMA ANTIGÜEDAD 12 DIAS', ISNULL(CONCEPTOS.[211], 0.00) AS 'PTU', ISNULL(CONCEPTOS.[240], 0.00) AS 'SUBSIDIO PARA EL EMPLEO PAGADO', ISNULL(CONCEPTOS.[498], 0.00) AS 'PS DIAS LABORADOS', " + _
                                         "ISNULL(CONCEPTOS.[229], 0.00) AS 'PS RETROACTIVO', ISNULL(CONCEPTOS.[499], 0.00) AS 'IAS DIAS LABORADOS', ISNULL(CONCEPTOS.[230], 0.00) AS 'IAS DIAS PENDIENTES', ISNULL(CONCEPTOS.[494], 0.00) AS 'FLEXIBLE SUBSIDIOS INCAP.', " + _
                                         "ISNULL(CONCEPTOS.[495], 0.00)+ISNULL(CONCEPTOS.[492], 0.00)+ISNULL(CONCEPTOS.[493], 0.00) AS 'FLEXIBLE BONO', ISNULL(CONCEPTOS.[496], 0.00) AS 'FLEXIBLE BONO NEGOCIACION', " + _
                                         "ISNULL(CONCEPTOS.[497], 0.00) AS 'FLEXIBLE BONO ESPECIAL', ISNULL(CONCEPTOS.[500], 0.00) AS 'TOTAL PERCEPCIONES', ISNULL(CONCEPTOS.[501], 0.00) AS 'IMPUESTO RETENIDO', " + _
                                         "ISNULL(CONCEPTOS.[514], 0.00) AS 'IMPUESTO INDEMNIZACIÓN', ISNULL(CONCEPTOS.[503], 0.00) AS 'ISR AJUSTE ANNUAL 177', ISNULL(CONCEPTOS.[510], 0.00) AS 'IMSS', ISNULL(CONCEPTOS.[511], 0.00) AS 'DESC CREDITO INFONAVIT', " + _
                                         "ISNULL(CONCEPTOS.[525], 0.00) AS 'AJUSTE DIFERENCIA CRED INFONAVIT', ISNULL(CONCEPTOS.[521], 0.00) +ISNULL(CONCEPTOS.[513], 0.00) +ISNULL(CONCEPTOS.[515], 0.00)+ISNULL(CONCEPTOS.[516], 0.00) AS 'OTROS DESCUENTOS', " + _
                                         "ISNULL(CONCEPTOS.[520], 0.00) AS 'FONACOT', ISNULL(CONCEPTOS.[523], 0.00) AS 'PRESTAMO PERSONAL', ISNULL(CONCEPTOS.[524], 0.00) +ISNULL(CONCEPTOS.[552], 0.00) AS 'OTRAS DEDUCCIONES', " + _
                                         "ISNULL(CONCEPTOS.[522], 0.00) AS 'DESCUENTO PENSION ALIMENTICIA', ISNULL(CONCEPTOS.[700], 0.00) AS 'TOTAL DEDUCCIONES', ISNULL(CONCEPTOS.[900], 0.00) AS 'NETO A PAGAR', ISNULL(CONCEPTOS.[915], 0.00) AS 'IMSS EXCEDENTE PATRON', " + _
                                         "ISNULL(CONCEPTOS.[916], 0.00) AS 'IMSS PRESTACIONES EN DINERO', ISNULL(CONCEPTOS.[917], 0.00) AS 'IMSS PRESTACIONES EN ESPECIE', ISNULL(CONCEPTOS.[918], 0.00) AS 'IMSS IV PATRONAL', " + _
                                         "ISNULL(CONCEPTOS.[919], 0.00) AS 'IMSS PROVISION GUARDERIA', ISNULL(CONCEPTOS.[920], 0.00) AS 'IMSS RIESGO DE TRABAJO',ISNULL(CONCEPTOS.[921], 0.00) AS 'PROVISION SAR', ISNULL(CONCEPTOS.[922], 0.00) AS 'PROVISION INFONAVIT', " + _
                                         "ISNULL(CONCEPTOS.[923], 0.00) AS 'IMSS CV PATRONAL', ISNULL(CONCEPTOS.[924], 0.00) AS 'IMSS CUOTA FIJA', ISNULL(CONCEPTOS.[925], 0.00) AS 'IMSS PATRONAL', ISNULL(CONCEPTOS.[927], 0.00) AS 'IMSS OBRERO', " + _
                                         "ISNULL(CONCEPTOS.[976], 0.00) AS 'ISN', ISNULL(CONCEPTOS.[926], 0.00) AS 'CARGA SOCIAL', ISNULL(CONCEPTOS.[928], 0.00) AS 'COMISION NOMINA', ISNULL(CONCEPTOS.[962], 0.00) AS 'IVA',  ISNULL(CONCEPTOS.[975], 0.00) AS 'TOTAL A FACTURAR', " + _
                                         "(char(39)+E.CUENTADEPOSITO) AS CUENTA, (char(39)+E.CLABE)  AS CLABE, CASE WHEN E.BANCODEPOSITO=0 THEN ' ' WHEN E.BANCODEPOSITO=1 THEN 'BANCOMER' WHEN E.BANCODEPOSITO=2 THEN 'BANAMEX' WHEN E.BANCODEPOSITO=3 THEN 'COMERMEX' " + _
                                         "WHEN E.BANCODEPOSITO=4 THEN 'SERFIN' WHEN E.BANCODEPOSITO=5 THEN 'BANOBRAS' WHEN E.BANCODEPOSITO=6 THEN 'ATLANTCO'  WHEN E.BANCODEPOSITO=7 THEN 'CITIBANK'  WHEN E.BANCODEPOSITO=8 THEN  'CONFIA'  WHEN E.BANCODEPOSITO=9 THEN  'SANTANDER' " + _
                                         "WHEN E.BANCODEPOSITO=10 THEN 'MEXICANO'  WHEN E.BANCODEPOSITO=11 THEN  'IXE' WHEN E.BANCODEPOSITO=12 THEN 'FIN COMUN' WHEN E.BANCODEPOSITO=13 THEN 'SCOTIABANK'  WHEN E.BANCODEPOSITO=14 THEN 'BANORTE'  WHEN E.BANCODEPOSITO=15 THEN  'INBURSA' " + _
                                         "WHEN E.BANCODEPOSITO=16 THEN 'HSBC'  WHEN E.BANCODEPOSITO=17 THEN  'BANREGIO'  WHEN E.BANCODEPOSITO=18 THEN 'BANCO AZTECA'  WHEN E.BANCODEPOSITO=21 THEN 'BITAL' WHEN E.BANCODEPOSITO=30 THEN 'BBVA'  END AS BANCO " + _
                                         "FROM  EMPLEADO AS E INNER JOIN MOVIMIENTO AS M ON E.TRAB_ID = M.TRAB_ID INNER JOIN (SELECT  TRAB_ID, MAX(PTR) AS PTR FROM   MOVIMIENTO AS MOVIMIENTO_1 WHERE ( FECHAMOV <= '" + Format(FFin.Date, "dd/MM/yyyy") + "' ) and Centro_ID=" + Centro + " GROUP BY TRAB_ID) AS LM ON M.TRAB_ID = LM.TRAB_ID AND M.PTR = LM.PTR  " + _
                                         "INNER JOIN TBCENTROS  ON M.CENTRO_ID = TBCENTROS.CENTRO_ID INNER JOIN TBREGPAT  ON TBCENTROS.REGPAT_ID = TBREGPAT.REGPAT_ID INNER JOIN TBPUESTO  ON M.PUESTO_ID = TBPUESTO.PUESTO_ID INNER JOIN TBDEPTO  ON M.DEPTO_ID = TBDEPTO.DEPTO_ID " + _
                                         "INNER JOIN ANTIGUEDAD ON E.TRAB_ID = ANTIGUEDAD.TRAB_ID INNER JOIN (SELECT  ANTIGEMPL.TRAB_ID, TBFACTORINTEGRA.VACACIONES, TBFACTORINTEGRA.AGUINALDO, TBFACTORINTEGRA.PRIMA FROM TBFACTORINTEGRA  " + _
                                         "INNER JOIN (SELECT ANTFACT.TRAB_ID, MAX(TBFI.ANTIGUEDAD) AS ANTIG, ANTFACT.TIPOEMPLEADO_ID  FROM  TBFACTORINTEGRA AS TBFI INNER JOIN (SELECT  ANT.TRAB_ID, ANT.ANO + CAST(ANT.DIAS AS MONEY) / 1000 AS ANTIGUEDAD, " + _
                                         "MOVIMIENTO.TIPOEMPLEADO_ID FROM ANTIGUEDAD AS ANT INNER JOIN (SELECT  TRAB_ID, MAX(PTR) AS PTR FROM MOVIMIENTO AS MOVIMIENTO_2  WHERE ( FECHAMOV <= '" + Format(FFin.Date, "dd/MM/yyyy") + "' ) GROUP  BY TRAB_ID) AS LM_1 ON ANT.TRAB_ID = LM_1.TRAB_ID " + _
                                         "INNER JOIN MOVIMIENTO ON LM_1.TRAB_ID = MOVIMIENTO.TRAB_ID  AND LM_1.PTR = MOVIMIENTO.PTR) AS ANTFACT ON TBFI.ANTIGUEDAD <= ANTFACT.ANTIGUEDAD AND TBFI.TIPOEMPLEADO_ID = ANTFACT.TIPOEMPLEADO_ID " + _
                                         "GROUP  BY ANTFACT.TRAB_ID, ANTFACT.TIPOEMPLEADO_ID) AS ANTIGEMPL  ON TBFACTORINTEGRA.TIPOEMPLEADO_ID = ANTIGEMPL.TIPOEMPLEADO_ID AND TBFACTORINTEGRA.ANTIGUEDAD = ANTIGEMPL.ANTIG) AS FACTEMPL ON M.TRAB_ID = FACTEMPL.TRAB_ID " + _
                                         "INNER JOIN (SELECT * FROM (SELECT TRAB_ID, CONCEPTO_ID, IMPORTE FROM NomCalculohistorico WHERE ( INICIO >= '" + Format(FInicio.Date, "dd/MM/yyyy") + "' ) AND ( FINAL <= '" + Format(FFin.Date, "dd/MM/yyyy") + "') and Centro_ID =" + Centro + "  and tiponomina_id in (1) " + _
                                         "AND CONCEPTO_ID IN (51,50,30,14,6,9,7,8,52,54,57,58,59,60,61,63,201,204,78,231,232,79,77,282,503, 75,233,234,237,74,240,498,229,499,230,500,501,514,510,511,525,521,520,522,552,513,515,516,64,80,492,493,212,927, " + _
                                         "700,900,915,916,917,918,919,920,921,922,923,924,925,976,926,928,962,975,523,524,53,55,56,211,494,495,496,497)) AS CONCEPTOS  PIVOT (SUM(CONCEPTOS.IMPORTE) FOR CONCEPTOS.CONCEPTO_ID " + _
                                         "IN ([51],[50],[30],[14],[6],[9],[7],[8],[52],[54],[57],[58],[59],[60],[61],[63],[201],[204],[78],[231],[232],[79],[77],[282],  " + _
                                         "[75],[233],[234],[237],[74],[240],[498],[229],[499],[230],[500],[501],[514],[510],[511],[525],[521],[520],[522],[552],[513],[515],[516],[64],[80],[492],[493],[212],[927],[503],  " + _
                                         "[700],[900],[915],[916],[917],[918],[919],[920],[921],[922],[923],[924],[925],[976],[926],[928],[962],[975],[523],[524],[53],[55],[56],[211],[494],[495],[496],[497])) AS PIVOTTABLE) AS CONCEPTOS " + _
                                         "ON M.TRAB_ID = CONCEPTOS.TRAB_ID  /*para traer DATO */  INNER JOIN (SELECT * FROM (SELECT TRAB_ID, CONCEPTO_ID, Dato FROM NomCalculohistorico " + _
                                         "WHERE ( INICIO >= '" + Format(FInicio.Date, "dd/MM/yyyy") + "' ) AND ( FINAL <='" + Format(FFin.Date, "dd/MM/yyyy") + "' )  and Centro_ID =" + Centro + " and tiponomina_id in (1) " + _
                                         "AND CONCEPTO_ID IN (51,50,30,14,6,9,7,8,52,54,57,58,59,60,61,63,201,204,78,231,232,79,77,282,503, 75,233,234,237,74,240,498,229,499,230,500,501,514,510,511,525,521,520,522,552,513,515,516,64,80,492,493,212,927, " + _
                                         "700,900,915,916,917,918,919,920,921,922,923,924,925,976,926,928,962,975,523,524,53,55,56,211,494,495,496,497)) AS CONCEPTOS  PIVOT (SUM(Conceptos.DATO)  FOR CONCEPTOS.CONCEPTO_ID " + _
                                         "IN ([51],[50],[30],[14],[6],[9],[7],[8],[52],[54],[57],[58],[59],[60],[61],[63],[201],[204],[78],[231],[232],[79],[77],[282], " + _
                                         "[75],[233],[234],[237],[74],[240],[498],[229],[499],[230],[500],[501],[514],[510],[511],[525],[521],[520],[522],[552],[513],[515],[516],[64],[80],[492],[493],[212],[927],[503], " + _
                                         "[700],[900],[915],[916],[917],[918],[919],[920],[921],[922],[923],[924],[925],[976],[926],[928],[962],[975],[523],[524],[53],[55],[56],[211],[494],[495],[496],[497]) ) AS PIVOTTABLE) AS DATOS " + _
                                         "ON M.TRAB_ID = DATOS.TRAB_ID order by 'NOMBRE DE EMPLEADO'", conn)
                comm.CommandType = CommandType.Text
                comm.CommandTimeout = 20000
                conn.Open()
                dr = comm.ExecuteReader
                While dr.Read
                    Dim c As clsNomina
                    Dim clabe As String
                    Dim banco As String
                    Dim tipoCaso As Int32 = 0
                    tipoCaso = CInt(dr("TIPO CASO"))

                    If IsDBNull(dr("BANCO")) Then
                        banco = ""
                    Else
                        banco = dr("BANCO")
                    End If

                    If IsDBNull(dr("CLABE")) Then
                        clabe = ""
                    Else
                        clabe = dr("CLABE")
                    End If
                    c = New clsNomina(dr("CLIENTE"), dr("PUESTO"), dr("NO. EMPLEADO"), CDate(dr("FECHA ALTA")), dr("MOV"), dr("NOMBRE DE EMPLEADO"), tipoCaso, dr("SUELDO NOMINAL MENSUAL"), dr("FLEXIBLE BRUTO MENSUAL(PS/IAS)"), _
                                      CInt(dr("5 Ó 7%")), dr("SUELDO DIARIO"), dr("SDI"), dr("DÍAS LABORADOS"), dr("DÍAS RETROACTIVOS"), dr("DÍAS FALTAS"), dr("DIAS DE INC.ENF.GRAL."), dr("DIAS DE INC.MATERNIDAD"), dr("DIAS DE INC.RT O TRAYECTO"), dr("FLEXIBLE QUINCENAL"), _
                                      dr("BONO UNICO BR PS/IAS"), dr("BONO NEGOCIACION BR PS/IAS"), dr("BONO ESPECIAL BR PS/IAS"), dr("SUBSIDIO ENFERMEDAD GENERAL BR PS/IAS"), dr("SUBSIDIO ACCIDENTE TRABAJO BR PS/IAS"), dr("SUBSIDIO ACCIDENTE TRAYECTO BR PS/IAS"), dr("SUBSIDIO MATERNIDAD BR PS/IAS"), dr("BONO POR HORAS EXTRAS BR PS/IAS"), dr("RETROACTIVO BR PS/IAS"), dr("SUELDO"), _
                                      dr("RETROACTIVO SUELDO"), dr("REEMBOLSO INFONAVIT"), dr("PRIMA VACACIONAL ANIVERSARIO"), dr("SUBSIDIO EG 1-3 DIAS"), dr("SUBSIDIO EG 4 EN ADELANTE"), dr("AGUINALDO ANUAL"), dr("AGUINALDO FINIQUITO"), dr("VACACIONES FINIQUITO"), dr("PRIMA VACACIONAL FINIQUITO"), dr("INDEMNIZACION 3 MESES"), _
                                      dr("INDEMNIZACION 20 DIAS"), dr("NEGOCIACION GRAVADA"), dr("PRIMA ANTIGÜEDAD 12 DIAS"), dr("PTU"), dr("SUBSIDIO PARA EL EMPLEO PAGADO"), dr("PS DIAS LABORADOS"), dr("PS RETROACTIVO"), dr("IAS DIAS LABORADOS"), dr("IAS DIAS PENDIENTES"), dr("FLEXIBLE SUBSIDIOS INCAP."), _
                                      CDbl(dr("FLEXIBLE BONO")), dr("FLEXIBLE BONO NEGOCIACION"), dr("FLEXIBLE BONO ESPECIAL"), dr("TOTAL PERCEPCIONES"), dr("IMPUESTO RETENIDO"), dr("IMPUESTO INDEMNIZACIÓN"), dr("ISR AJUSTE ANNUAL 177"), dr("IMSS"), dr("DESC CREDITO INFONAVIT"), dr("AJUSTE DIFERENCIA CRED INFONAVIT"), _
                                      dr("OTROS DESCUENTOS"), dr("FONACOT"), dr("PRESTAMO PERSONAL"), dr("OTRAS DEDUCCIONES"), dr("DESCUENTO PENSION ALIMENTICIA"), dr("TOTAL DEDUCCIONES"), dr("NETO A PAGAR"), dr("IMSS EXCEDENTE PATRON"), dr("IMSS PRESTACIONES EN DINERO"), dr("IMSS PRESTACIONES EN ESPECIE"), _
                                      dr("IMSS IV PATRONAL"), dr("IMSS PROVISION GUARDERIA"), dr("IMSS RIESGO DE TRABAJO"), dr("PROVISION SAR"), dr("PROVISION INFONAVIT"), dr("IMSS CV PATRONAL"), dr("IMSS CUOTA FIJA"), dr("IMSS PATRONAL"), dr("IMSS OBRERO"), dr("ISN"), _
                                      dr("CARGA SOCIAL"), dr("COMISION NOMINA"), dr("IVA"), dr("TOTAL A FACTURAR"), dr("CUENTA"), clabe, banco)
                    If Not IsDBNull(dr("FECHA BAJA")) Then
                        'MessageBox.Show(dr("FECHA BAJA").ToString & " --> " & dr("NO. EMPLEADO"))
                        c.FechaBaja = CDate(dr("FECHA BAJA"))
                        For i = j To arrBajas.Count - 1
                            If CType(arrBajas(i), clsEmpleadoBaja).TarjetaID = dr("NO. EMPLEADO") Then
                                CType(arrBajas(i), clsEmpleadoBaja).NominaActual = True
                                j = i + 1
                                Exit For
                            End If
                        Next
                    End If

                    arrNominas.Add(c)
                End While
                dr.Close()
            End Using
            Return arrNominas
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo obtener la lista de la Nomina... " + ex.Message)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function
    Public Function ObtenerNominaReal(ByVal Centro As String, ByVal FInicio As Date, ByVal FFin As Date, ByVal arrBajas As ArrayList) As ArrayList
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Dim j, i As Int32
            j = 0 : i = 0

            If FFin.Month <> FInicio.Month Then
                MessageBox.Show("Advertencia, el tipo caso se vera afectado por las fechas ingresadas que no corresponden al mismo mes...")
            End If

            Dim arrNominas As New ArrayList

            If FFin.Month = 12 And FInicio.Month = 12 Then
                Using comm As New SqlCommand("SELECT TBDEPTO.DESCRIPCION AS 'CLIENTE', TBPUESTO.DESCRIPCION AS 'PUESTO', E.TARJETA_ID AS 'NO. EMPLEADO', CONVERT(VARCHAR(10), E.FECHAINGRESO, 103) AS 'FECHA ALTA', " + _
                                         "CASE WHEN M.Mov_ID='B' THEN CONVERT(VARCHAR(10), M.FechaMov, 103) END AS 'FECHA BAJA', M.Mov_ID as MOV, E.PATERNO + ' ' + E.MATERNO + ' ' + E.NOMBRE AS 'NOMBRE DE EMPLEADO',  " + _
                                         "CONCEPTOS.[51] AS 'TIPO CASO', (M.SALARIO * 30) AS 'SUELDO NOMINAL MENSUAL', ISNULL(CONCEPTOS.[50], 0.00) AS 'FLEXIBLE BRUTO MENSUAL(PS/IAS)', ISNULL(CONCEPTOS.[53], 0) AS '5 Ó 7%',  " + _
                                         "M.SALARIO AS 'SUELDO DIARIO', M.INTEGRADOIMSS AS SDI, ISNULL(CONCEPTOS.[30], 0.00) AS 'DÍAS LABORADOS',  ISNULL(DATOS.[63], 0.00) AS 'DÍAS RETROACTIVOS',  " + _
                                         "ISNULL(CONCEPTOS.[14], 0.00) AS 'DÍAS FALTAS', ISNULL(DATOS.[6], 0.00) AS 'DIAS DE INC.ENF.GRAL.', ISNULL(DATOS.[9], 0.00) AS 'DIAS DE INC.MATERNIDAD',   " + _
                                         "ISNULL(DATOS.[7], 0.00)+ISNULL(DATOS.[8], 0.00) AS 'DIAS DE INC.RT O TRAYECTO', ISNULL(CONCEPTOS.[52], 0.00) AS 'FLEXIBLE QUINCENAL', ISNULL(CONCEPTOS.[54], 0.00) + ISNULL(CONCEPTOS.[64], 0.00)+ISNULL(CONCEPTOS.[80], 0.00) AS 'BONO UNICO BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[55], 0.00) AS 'BONO NEGOCIACION BR PS/IAS', ISNULL(CONCEPTOS.[56], 0.00) AS 'BONO ESPECIAL BR PS/IAS', ISNULL(CONCEPTOS.[57], 0.00) AS 'SUBSIDIO ENFERMEDAD GENERAL BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[58], 0.00) AS 'SUBSIDIO ACCIDENTE TRABAJO BR PS/IAS', ISNULL(CONCEPTOS.[59], 0.00) AS 'SUBSIDIO ACCIDENTE TRAYECTO BR PS/IAS', ISNULL(CONCEPTOS.[60], 0.00) AS 'SUBSIDIO MATERNIDAD BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[61], 0.00) AS 'BONO POR HORAS EXTRAS BR PS/IAS', ISNULL(CONCEPTOS.[63], 0.00) AS 'RETROACTIVO BR PS/IAS', ISNULL(CONCEPTOS.[201], 0.00) AS 'SUELDO', " + _
                                         "ISNULL(CONCEPTOS.[204], 0.00) AS 'RETROACTIVO SUELDO', ISNULL(CONCEPTOS.[212], 0.00) AS 'REEMBOLSO INFONAVIT', ISNULL(CONCEPTOS.[78], 0.00) AS 'PRIMA VACACIONAL ANIVERSARIO', " + _
                                         "ISNULL(CONCEPTOS.[231], 0.00) AS 'SUBSIDIO EG 1-3 DIAS', ISNULL(CONCEPTOS.[232], 0.00) AS 'SUBSIDIO EG 4 EN ADELANTE', ISNULL(CONCEPTOS.[79], 0.00) AS 'AGUINALDO ANUAL', " + _
                                         "ISNULL(CONCEPTOS.[77], 0.00) AS 'AGUINALDO FINIQUITO', ISNULL(CONCEPTOS.[282], 0.00) AS 'VACACIONES FINIQUITO', ISNULL(CONCEPTOS.[75], 0.00) AS 'PRIMA VACACIONAL FINIQUITO', " + _
                                         "ISNULL(CONCEPTOS.[233], 0.00) AS 'INDEMNIZACION 3 MESES', ISNULL(CONCEPTOS.[234], 0.00) AS 'INDEMNIZACION 20 DIAS', ISNULL(CONCEPTOS.[237], 0.00) AS 'NEGOCIACION GRAVADA', " + _
                                         "ISNULL(CONCEPTOS.[74], 0.00) AS 'PRIMA ANTIGÜEDAD 12 DIAS', ISNULL(CONCEPTOS.[211], 0.00) AS 'PTU', ISNULL(CONCEPTOS.[240], 0.00) AS 'SUBSIDIO PARA EL EMPLEO PAGADO', ISNULL(CONCEPTOS.[498], 0.00) AS 'PS DIAS LABORADOS', " + _
                                         "ISNULL(CONCEPTOS.[229], 0.00) AS 'PS RETROACTIVO', ISNULL(CONCEPTOS.[499], 0.00) AS 'IAS DIAS LABORADOS', ISNULL(CONCEPTOS.[230], 0.00) AS 'IAS DIAS PENDIENTES', ISNULL(CONCEPTOS.[494], 0.00) AS 'FLEXIBLE SUBSIDIOS INCAP.', " + _
                                         "ISNULL(CONCEPTOS.[495], 0.00)+ISNULL(CONCEPTOS.[492], 0.00)+ISNULL(CONCEPTOS.[493], 0.00) AS 'FLEXIBLE BONO', ISNULL(CONCEPTOS.[496], 0.00) AS 'FLEXIBLE BONO NEGOCIACION', " + _
                                         "ISNULL(CONCEPTOS.[497], 0.00) AS 'FLEXIBLE BONO ESPECIAL', ISNULL(CONCEPTOS.[500], 0.00) AS 'TOTAL PERCEPCIONES', ISNULL(CONCEPTOS.[501], 0.00) AS 'IMPUESTO RETENIDO', " + _
                                         "ISNULL(CONCEPTOS.[514], 0.00) AS 'IMPUESTO INDEMNIZACIÓN', ISNULL(CONCEPTOS.[503], 0.00) AS 'ISR AJUSTE ANNUAL 177', ISNULL(CONCEPTOS.[510], 0.00) AS 'IMSS', ISNULL(CONCEPTOS.[511], 0.00) AS 'DESC CREDITO INFONAVIT', " + _
                                         "ISNULL(CONCEPTOS.[525], 0.00) AS 'AJUSTE DIFERENCIA CRED INFONAVIT', ISNULL(CONCEPTOS.[521], 0.00) +ISNULL(CONCEPTOS.[513], 0.00) +ISNULL(CONCEPTOS.[515], 0.00)+ISNULL(CONCEPTOS.[516], 0.00) AS 'OTROS DESCUENTOS', " + _
                                         "ISNULL(CONCEPTOS.[520], 0.00) AS 'FONACOT', ISNULL(CONCEPTOS.[523], 0.00) AS 'PRESTAMO PERSONAL', ISNULL(CONCEPTOS.[524], 0.00) +ISNULL(CONCEPTOS.[552], 0.00) AS 'OTRAS DEDUCCIONES', " + _
                                         "ISNULL(CONCEPTOS.[522], 0.00) AS 'DESCUENTO PENSION ALIMENTICIA', ISNULL(CONCEPTOS.[700], 0.00) AS 'TOTAL DEDUCCIONES', ISNULL(CONCEPTOS.[900], 0.00) AS 'NETO A PAGAR', ISNULL(CONCEPTOS.[915], 0.00) AS 'IMSS EXCEDENTE PATRON', " + _
                                         "ISNULL(CONCEPTOS.[916], 0.00) AS 'IMSS PRESTACIONES EN DINERO', ISNULL(CONCEPTOS.[917], 0.00) AS 'IMSS PRESTACIONES EN ESPECIE', ISNULL(CONCEPTOS.[918], 0.00) AS 'IMSS IV PATRONAL', " + _
                                         "ISNULL(CONCEPTOS.[919], 0.00) AS 'IMSS PROVISION GUARDERIA', ISNULL(CONCEPTOS.[920], 0.00) AS 'IMSS RIESGO DE TRABAJO',ISNULL(CONCEPTOS.[921], 0.00) AS 'PROVISION SAR', ISNULL(CONCEPTOS.[922], 0.00) AS 'PROVISION INFONAVIT', " + _
                                         "ISNULL(CONCEPTOS.[923], 0.00) AS 'IMSS CV PATRONAL', ISNULL(CONCEPTOS.[924], 0.00) AS 'IMSS CUOTA FIJA', ISNULL(CONCEPTOS.[925], 0.00) AS 'IMSS PATRONAL', ISNULL(CONCEPTOS.[927], 0.00) AS 'IMSS OBRERO', " + _
                                         "ISNULL(CONCEPTOS.[976], 0.00) AS 'ISN', ISNULL(CONCEPTOS.[926], 0.00) AS 'CARGA SOCIAL', ISNULL(CONCEPTOS.[928], 0.00) AS 'COMISION NOMINA', ISNULL(CONCEPTOS.[962], 0.00) AS 'IVA',  ISNULL(CONCEPTOS.[975], 0.00) AS 'TOTAL A FACTURAR', " + _
                                         "(char(39)+E.CUENTADEPOSITO) AS CUENTA, (char(39)+E.CLABE)  AS CLABE, CASE WHEN E.BANCODEPOSITO=0 THEN ' ' WHEN E.BANCODEPOSITO=1 THEN 'BANCOMER' WHEN E.BANCODEPOSITO=2 THEN 'BANAMEX' WHEN E.BANCODEPOSITO=3 THEN 'COMERMEX' " + _
                                         "WHEN E.BANCODEPOSITO=4 THEN 'SERFIN' WHEN E.BANCODEPOSITO=5 THEN 'BANOBRAS' WHEN E.BANCODEPOSITO=6 THEN 'ATLANTCO'  WHEN E.BANCODEPOSITO=7 THEN 'CITIBANK'  WHEN E.BANCODEPOSITO=8 THEN  'CONFIA'  WHEN E.BANCODEPOSITO=9 THEN  'SANTANDER' " + _
                                         "WHEN E.BANCODEPOSITO=10 THEN 'MEXICANO'  WHEN E.BANCODEPOSITO=11 THEN  'IXE' WHEN E.BANCODEPOSITO=12 THEN 'FIN COMUN' WHEN E.BANCODEPOSITO=13 THEN 'SCOTIABANK'  WHEN E.BANCODEPOSITO=14 THEN 'BANORTE'  WHEN E.BANCODEPOSITO=15 THEN  'INBURSA' " + _
                                         "WHEN E.BANCODEPOSITO=16 THEN 'HSBC'  WHEN E.BANCODEPOSITO=17 THEN  'BANREGIO'  WHEN E.BANCODEPOSITO=18 THEN 'BANCO AZTECA'  WHEN E.BANCODEPOSITO=21 THEN 'BITAL' WHEN E.BANCODEPOSITO=30 THEN 'BBVA'  END AS BANCO " + _
                                         "FROM  EMPLEADO AS E INNER JOIN MOVIMIENTO AS M ON E.TRAB_ID = M.TRAB_ID INNER JOIN (SELECT  TRAB_ID, MAX(PTR) AS PTR FROM   MOVIMIENTO AS MOVIMIENTO_1 WHERE ( FECHAMOV <= '" + Format(FFin.Date, "dd/MM/yyyy") + "' ) and Centro_ID=" + Centro + " GROUP BY TRAB_ID) AS LM ON M.TRAB_ID = LM.TRAB_ID AND M.PTR = LM.PTR  " + _
                                         "INNER JOIN TBCENTROS  ON M.CENTRO_ID = TBCENTROS.CENTRO_ID INNER JOIN TBREGPAT  ON TBCENTROS.REGPAT_ID = TBREGPAT.REGPAT_ID INNER JOIN TBPUESTO  ON M.PUESTO_ID = TBPUESTO.PUESTO_ID INNER JOIN TBDEPTO  ON M.DEPTO_ID = TBDEPTO.DEPTO_ID " + _
                                         "INNER JOIN ANTIGUEDAD ON E.TRAB_ID = ANTIGUEDAD.TRAB_ID INNER JOIN (SELECT  ANTIGEMPL.TRAB_ID, TBFACTORINTEGRA.VACACIONES, TBFACTORINTEGRA.AGUINALDO, TBFACTORINTEGRA.PRIMA FROM TBFACTORINTEGRA  " + _
                                         "INNER JOIN (SELECT ANTFACT.TRAB_ID, MAX(TBFI.ANTIGUEDAD) AS ANTIG, ANTFACT.TIPOEMPLEADO_ID  FROM  TBFACTORINTEGRA AS TBFI INNER JOIN (SELECT  ANT.TRAB_ID, ANT.ANO + CAST(ANT.DIAS AS MONEY) / 1000 AS ANTIGUEDAD, " + _
                                         "MOVIMIENTO.TIPOEMPLEADO_ID FROM ANTIGUEDAD AS ANT INNER JOIN (SELECT  TRAB_ID, MAX(PTR) AS PTR FROM MOVIMIENTO AS MOVIMIENTO_2  WHERE ( FECHAMOV <= '" + Format(FFin.Date, "dd/MM/yyyy") + "' ) GROUP  BY TRAB_ID) AS LM_1 ON ANT.TRAB_ID = LM_1.TRAB_ID " + _
                                         "INNER JOIN MOVIMIENTO ON LM_1.TRAB_ID = MOVIMIENTO.TRAB_ID  AND LM_1.PTR = MOVIMIENTO.PTR) AS ANTFACT ON TBFI.ANTIGUEDAD <= ANTFACT.ANTIGUEDAD AND TBFI.TIPOEMPLEADO_ID = ANTFACT.TIPOEMPLEADO_ID " + _
                                         "GROUP  BY ANTFACT.TRAB_ID, ANTFACT.TIPOEMPLEADO_ID) AS ANTIGEMPL  ON TBFACTORINTEGRA.TIPOEMPLEADO_ID = ANTIGEMPL.TIPOEMPLEADO_ID AND TBFACTORINTEGRA.ANTIGUEDAD = ANTIGEMPL.ANTIG) AS FACTEMPL ON M.TRAB_ID = FACTEMPL.TRAB_ID " + _
                                         "INNER JOIN (SELECT * FROM (SELECT TRAB_ID, CONCEPTO_ID, IMPORTE FROM NomCalculohistorico WHERE ( INICIO >= '" + Format(FInicio.Date, "dd/MM/yyyy") + "' ) AND ( FINAL <= '" + Format(FFin.Date, "dd/MM/yyyy") + "') and Centro_ID =" + Centro + "  and tiponomina_id in (1,2,9,8,23) " + _
                                         "AND CONCEPTO_ID IN (51,50,30,14,6,9,7,8,52,54,57,58,59,60,61,63,201,204,78,231,232,79,77,282,503, 75,233,234,237,74,240,498,229,499,230,500,501,514,510,511,525,521,520,522,552,513,515,516,64,80,492,493,212,927, " + _
                                         "700,900,915,916,917,918,919,920,921,922,923,924,925,976,926,928,962,975,523,524,53,55,56,211,494,495,496,497)) AS CONCEPTOS  PIVOT (SUM(CONCEPTOS.IMPORTE) FOR CONCEPTOS.CONCEPTO_ID " + _
                                         "IN ([51],[50],[30],[14],[6],[9],[7],[8],[52],[54],[57],[58],[59],[60],[61],[63],[201],[204],[78],[231],[232],[79],[77],[282],  " + _
                                         "[75],[233],[234],[237],[74],[240],[498],[229],[499],[230],[500],[501],[514],[510],[511],[525],[521],[520],[522],[552],[513],[515],[516],[64],[80],[492],[493],[212],[927],[503],  " + _
                                         "[700],[900],[915],[916],[917],[918],[919],[920],[921],[922],[923],[924],[925],[976],[926],[928],[962],[975],[523],[524],[53],[55],[56],[211],[494],[495],[496],[497])) AS PIVOTTABLE) AS CONCEPTOS " + _
                                         "ON M.TRAB_ID = CONCEPTOS.TRAB_ID  /*para traer DATO */  INNER JOIN (SELECT * FROM (SELECT TRAB_ID, CONCEPTO_ID, Dato FROM NomCalculohistorico " + _
                                         "WHERE ( INICIO >= '" + Format(FInicio.Date, "dd/MM/yyyy") + "' ) AND ( FINAL <='" + Format(FFin.Date, "dd/MM/yyyy") + "' )  and Centro_ID =" + Centro + " and tiponomina_id in (1,2,9,8,23) " + _
                                         "AND CONCEPTO_ID IN (51,50,30,14,6,9,7,8,52,54,57,58,59,60,61,63,201,204,78,231,232,79,77,282,503, 75,233,234,237,74,240,498,229,499,230,500,501,514,510,511,525,521,520,522,552,513,515,516,64,80,492,493,212,927, " + _
                                         "700,900,915,916,917,918,919,920,921,922,923,924,925,976,926,928,962,975,523,524,53,55,56,211,494,495,496,497)) AS CONCEPTOS  PIVOT (SUM(Conceptos.DATO)  FOR CONCEPTOS.CONCEPTO_ID " + _
                                         "IN ([51],[50],[30],[14],[6],[9],[7],[8],[52],[54],[57],[58],[59],[60],[61],[63],[201],[204],[78],[231],[232],[79],[77],[282], " + _
                                         "[75],[233],[234],[237],[74],[240],[498],[229],[499],[230],[500],[501],[514],[510],[511],[525],[521],[520],[522],[552],[513],[515],[516],[64],[80],[492],[493],[212],[927],[503], " + _
                                         "[700],[900],[915],[916],[917],[918],[919],[920],[921],[922],[923],[924],[925],[976],[926],[928],[962],[975],[523],[524],[53],[55],[56],[211],[494],[495],[496],[497]) ) AS PIVOTTABLE) AS DATOS " + _
                                         "ON M.TRAB_ID = DATOS.TRAB_ID order by 'NOMBRE DE EMPLEADO'", conn)
                    comm.CommandType = CommandType.Text
                    comm.CommandTimeout = 20000
                    conn.Open()
                    dr = comm.ExecuteReader
                    While dr.Read
                        Dim c As clsNomina
                        Dim clabe As String
                        Dim banco As String
                        Dim tipoCaso As Int32 = 0

                        tipoCaso = CInt(dr("TIPO CASO"))


                        If IsDBNull(dr("BANCO")) Then
                            banco = ""
                        Else
                            banco = dr("BANCO")
                        End If

                        If IsDBNull(dr("CLABE")) Then
                            clabe = ""
                        Else
                            clabe = dr("CLABE")
                        End If
                        c = New clsNomina(dr("CLIENTE"), dr("PUESTO"), dr("NO. EMPLEADO"), CDate(dr("FECHA ALTA")), dr("MOV"), dr("NOMBRE DE EMPLEADO"), tipoCaso, dr("SUELDO NOMINAL MENSUAL"), dr("FLEXIBLE BRUTO MENSUAL(PS/IAS)"), _
                                          CInt(dr("5 Ó 7%")), dr("SUELDO DIARIO"), dr("SDI"), dr("DÍAS LABORADOS"), dr("DÍAS RETROACTIVOS"), dr("DÍAS FALTAS"), dr("DIAS DE INC.ENF.GRAL."), dr("DIAS DE INC.MATERNIDAD"), dr("DIAS DE INC.RT O TRAYECTO"), dr("FLEXIBLE QUINCENAL"), _
                                          dr("BONO UNICO BR PS/IAS"), dr("BONO NEGOCIACION BR PS/IAS"), dr("BONO ESPECIAL BR PS/IAS"), dr("SUBSIDIO ENFERMEDAD GENERAL BR PS/IAS"), dr("SUBSIDIO ACCIDENTE TRABAJO BR PS/IAS"), dr("SUBSIDIO ACCIDENTE TRAYECTO BR PS/IAS"), dr("SUBSIDIO MATERNIDAD BR PS/IAS"), dr("BONO POR HORAS EXTRAS BR PS/IAS"), dr("RETROACTIVO BR PS/IAS"), dr("SUELDO"), _
                                          dr("RETROACTIVO SUELDO"), dr("REEMBOLSO INFONAVIT"), dr("PRIMA VACACIONAL ANIVERSARIO"), dr("SUBSIDIO EG 1-3 DIAS"), dr("SUBSIDIO EG 4 EN ADELANTE"), dr("AGUINALDO ANUAL"), dr("AGUINALDO FINIQUITO"), dr("VACACIONES FINIQUITO"), dr("PRIMA VACACIONAL FINIQUITO"), dr("INDEMNIZACION 3 MESES"), _
                                          dr("INDEMNIZACION 20 DIAS"), dr("NEGOCIACION GRAVADA"), dr("PRIMA ANTIGÜEDAD 12 DIAS"), dr("PTU"), dr("SUBSIDIO PARA EL EMPLEO PAGADO"), dr("PS DIAS LABORADOS"), dr("PS RETROACTIVO"), dr("IAS DIAS LABORADOS"), dr("IAS DIAS PENDIENTES"), dr("FLEXIBLE SUBSIDIOS INCAP."), _
                                          CDbl(dr("FLEXIBLE BONO")), dr("FLEXIBLE BONO NEGOCIACION"), dr("FLEXIBLE BONO ESPECIAL"), dr("TOTAL PERCEPCIONES"), dr("IMPUESTO RETENIDO"), dr("IMPUESTO INDEMNIZACIÓN"), dr("ISR AJUSTE ANNUAL 177"), dr("IMSS"), dr("DESC CREDITO INFONAVIT"), dr("AJUSTE DIFERENCIA CRED INFONAVIT"), _
                                          dr("OTROS DESCUENTOS"), dr("FONACOT"), dr("PRESTAMO PERSONAL"), dr("OTRAS DEDUCCIONES"), dr("DESCUENTO PENSION ALIMENTICIA"), dr("TOTAL DEDUCCIONES"), dr("NETO A PAGAR"), dr("IMSS EXCEDENTE PATRON"), dr("IMSS PRESTACIONES EN DINERO"), dr("IMSS PRESTACIONES EN ESPECIE"), _
                                          dr("IMSS IV PATRONAL"), dr("IMSS PROVISION GUARDERIA"), dr("IMSS RIESGO DE TRABAJO"), dr("PROVISION SAR"), dr("PROVISION INFONAVIT"), dr("IMSS CV PATRONAL"), dr("IMSS CUOTA FIJA"), dr("IMSS PATRONAL"), dr("IMSS OBRERO"), dr("ISN"), _
                                          dr("CARGA SOCIAL"), dr("COMISION NOMINA"), dr("IVA"), dr("TOTAL A FACTURAR"), dr("CUENTA"), clabe, banco)
                        If Not IsDBNull(dr("FECHA BAJA")) Then
                            'MessageBox.Show(dr("FECHA BAJA").ToString & " --> " & dr("NO. EMPLEADO"))
                            c.FechaBaja = CDate(dr("FECHA BAJA"))
                            For i = j To arrBajas.Count - 1
                                If CType(arrBajas(i), clsEmpleadoBaja).TarjetaID = dr("NO. EMPLEADO") Then
                                    CType(arrBajas(i), clsEmpleadoBaja).NominaActual = True
                                    j = i + 1
                                    Exit For
                                End If
                            Next
                        End If

                        arrNominas.Add(c)
                    End While
                    dr.Close()
                End Using
            End If


            Using comm As New SqlCommand("SELECT TBDEPTO.DESCRIPCION AS 'CLIENTE', TBPUESTO.DESCRIPCION AS 'PUESTO', E.TARJETA_ID AS 'NO. EMPLEADO', CONVERT(VARCHAR(10), E.FECHAINGRESO, 103) AS 'FECHA ALTA', " + _
                                         "CASE WHEN M.Mov_ID='B' THEN CONVERT(VARCHAR(10), M.FechaMov, 103) END AS 'FECHA BAJA', M.Mov_ID as MOV, E.PATERNO + ' ' + E.MATERNO + ' ' + E.NOMBRE AS 'NOMBRE DE EMPLEADO',  " + _
                                         "CONCEPTOS.[51] AS 'TIPO CASO', (M.SALARIO * 30) AS 'SUELDO NOMINAL MENSUAL', ISNULL(CONCEPTOS.[50], 0.00) AS 'FLEXIBLE BRUTO MENSUAL(PS/IAS)', ISNULL(CONCEPTOS.[53], 0) AS '5 Ó 7%',  " + _
                                         "M.SALARIO AS 'SUELDO DIARIO', M.INTEGRADOIMSS AS SDI, ISNULL(CONCEPTOS.[30], 0.00) AS 'DÍAS LABORADOS',  ISNULL(DATOS.[63], 0.00) AS 'DÍAS RETROACTIVOS',  " + _
                                         "ISNULL(CONCEPTOS.[14], 0.00) AS 'DÍAS FALTAS', ISNULL(DATOS.[6], 0.00) AS 'DIAS DE INC.ENF.GRAL.', ISNULL(DATOS.[9], 0.00) AS 'DIAS DE INC.MATERNIDAD',   " + _
                                         "ISNULL(DATOS.[7], 0.00)+ISNULL(DATOS.[8], 0.00) AS 'DIAS DE INC.RT O TRAYECTO', ISNULL(CONCEPTOS.[52], 0.00) AS 'FLEXIBLE QUINCENAL', ISNULL(CONCEPTOS.[54], 0.00) + ISNULL(CONCEPTOS.[64], 0.00)+ISNULL(CONCEPTOS.[80], 0.00) AS 'BONO UNICO BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[55], 0.00) AS 'BONO NEGOCIACION BR PS/IAS', ISNULL(CONCEPTOS.[56], 0.00) AS 'BONO ESPECIAL BR PS/IAS', ISNULL(CONCEPTOS.[57], 0.00) AS 'SUBSIDIO ENFERMEDAD GENERAL BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[58], 0.00) AS 'SUBSIDIO ACCIDENTE TRABAJO BR PS/IAS', ISNULL(CONCEPTOS.[59], 0.00) AS 'SUBSIDIO ACCIDENTE TRAYECTO BR PS/IAS', ISNULL(CONCEPTOS.[60], 0.00) AS 'SUBSIDIO MATERNIDAD BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[61], 0.00) AS 'BONO POR HORAS EXTRAS BR PS/IAS', ISNULL(CONCEPTOS.[63], 0.00) AS 'RETROACTIVO BR PS/IAS', ISNULL(CONCEPTOS.[201], 0.00) AS 'SUELDO', " + _
                                         "ISNULL(CONCEPTOS.[204], 0.00) AS 'RETROACTIVO SUELDO', ISNULL(CONCEPTOS.[212], 0.00) AS 'REEMBOLSO INFONAVIT', ISNULL(CONCEPTOS.[78], 0.00) AS 'PRIMA VACACIONAL ANIVERSARIO', " + _
                                         "ISNULL(CONCEPTOS.[231], 0.00) AS 'SUBSIDIO EG 1-3 DIAS', ISNULL(CONCEPTOS.[232], 0.00) AS 'SUBSIDIO EG 4 EN ADELANTE', ISNULL(CONCEPTOS.[79], 0.00) AS 'AGUINALDO ANUAL', " + _
                                         "ISNULL(CONCEPTOS.[77], 0.00) AS 'AGUINALDO FINIQUITO', ISNULL(CONCEPTOS.[282], 0.00) AS 'VACACIONES FINIQUITO', ISNULL(CONCEPTOS.[75], 0.00) AS 'PRIMA VACACIONAL FINIQUITO', " + _
                                         "ISNULL(CONCEPTOS.[233], 0.00) AS 'INDEMNIZACION 3 MESES', ISNULL(CONCEPTOS.[234], 0.00) AS 'INDEMNIZACION 20 DIAS', ISNULL(CONCEPTOS.[237], 0.00) AS 'NEGOCIACION GRAVADA', " + _
                                         "ISNULL(CONCEPTOS.[74], 0.00) AS 'PRIMA ANTIGÜEDAD 12 DIAS', ISNULL(CONCEPTOS.[211], 0.00) AS 'PTU', ISNULL(CONCEPTOS.[240], 0.00) AS 'SUBSIDIO PARA EL EMPLEO PAGADO', ISNULL(CONCEPTOS.[498], 0.00) AS 'PS DIAS LABORADOS', " + _
                                         "ISNULL(CONCEPTOS.[229], 0.00) AS 'PS RETROACTIVO', ISNULL(CONCEPTOS.[499], 0.00) AS 'IAS DIAS LABORADOS', ISNULL(CONCEPTOS.[230], 0.00) AS 'IAS DIAS PENDIENTES', ISNULL(CONCEPTOS.[494], 0.00) AS 'FLEXIBLE SUBSIDIOS INCAP.', " + _
                                         "ISNULL(CONCEPTOS.[495], 0.00)+ISNULL(CONCEPTOS.[492], 0.00)+ISNULL(CONCEPTOS.[493], 0.00) AS 'FLEXIBLE BONO', ISNULL(CONCEPTOS.[496], 0.00) AS 'FLEXIBLE BONO NEGOCIACION', " + _
                                         "ISNULL(CONCEPTOS.[497], 0.00) AS 'FLEXIBLE BONO ESPECIAL', ISNULL(CONCEPTOS.[500], 0.00) AS 'TOTAL PERCEPCIONES', ISNULL(CONCEPTOS.[501], 0.00) AS 'IMPUESTO RETENIDO', " + _
                                         "ISNULL(CONCEPTOS.[514], 0.00) AS 'IMPUESTO INDEMNIZACIÓN', ISNULL(CONCEPTOS.[503], 0.00) AS 'ISR AJUSTE ANNUAL 177', ISNULL(CONCEPTOS.[510], 0.00) AS 'IMSS', ISNULL(CONCEPTOS.[511], 0.00) AS 'DESC CREDITO INFONAVIT', " + _
                                         "ISNULL(CONCEPTOS.[525], 0.00) AS 'AJUSTE DIFERENCIA CRED INFONAVIT', ISNULL(CONCEPTOS.[521], 0.00) +ISNULL(CONCEPTOS.[513], 0.00) +ISNULL(CONCEPTOS.[515], 0.00)+ISNULL(CONCEPTOS.[516], 0.00) AS 'OTROS DESCUENTOS', " + _
                                         "ISNULL(CONCEPTOS.[520], 0.00) AS 'FONACOT', ISNULL(CONCEPTOS.[523], 0.00) AS 'PRESTAMO PERSONAL', ISNULL(CONCEPTOS.[524], 0.00) +ISNULL(CONCEPTOS.[552], 0.00) AS 'OTRAS DEDUCCIONES', " + _
                                         "ISNULL(CONCEPTOS.[522], 0.00) AS 'DESCUENTO PENSION ALIMENTICIA', ISNULL(CONCEPTOS.[700], 0.00) AS 'TOTAL DEDUCCIONES', ISNULL(CONCEPTOS.[900], 0.00) AS 'NETO A PAGAR', ISNULL(CONCEPTOS.[915], 0.00) AS 'IMSS EXCEDENTE PATRON', " + _
                                         "ISNULL(CONCEPTOS.[916], 0.00) AS 'IMSS PRESTACIONES EN DINERO', ISNULL(CONCEPTOS.[917], 0.00) AS 'IMSS PRESTACIONES EN ESPECIE', ISNULL(CONCEPTOS.[918], 0.00) AS 'IMSS IV PATRONAL', " + _
                                         "ISNULL(CONCEPTOS.[919], 0.00) AS 'IMSS PROVISION GUARDERIA', ISNULL(CONCEPTOS.[920], 0.00) AS 'IMSS RIESGO DE TRABAJO',ISNULL(CONCEPTOS.[921], 0.00) AS 'PROVISION SAR', ISNULL(CONCEPTOS.[922], 0.00) AS 'PROVISION INFONAVIT', " + _
                                         "ISNULL(CONCEPTOS.[923], 0.00) AS 'IMSS CV PATRONAL', ISNULL(CONCEPTOS.[924], 0.00) AS 'IMSS CUOTA FIJA', ISNULL(CONCEPTOS.[925], 0.00) AS 'IMSS PATRONAL', ISNULL(CONCEPTOS.[927], 0.00) AS 'IMSS OBRERO', " + _
                                         "ISNULL(CONCEPTOS.[976], 0.00) AS 'ISN', ISNULL(CONCEPTOS.[926], 0.00) AS 'CARGA SOCIAL', ISNULL(CONCEPTOS.[928], 0.00) AS 'COMISION NOMINA', ISNULL(CONCEPTOS.[962], 0.00) AS 'IVA',  ISNULL(CONCEPTOS.[975], 0.00) AS 'TOTAL A FACTURAR', " + _
                                         "(char(39)+E.CUENTADEPOSITO) AS CUENTA, (char(39)+E.CLABE)  AS CLABE, CASE WHEN E.BANCODEPOSITO=0 THEN ' ' WHEN E.BANCODEPOSITO=1 THEN 'BANCOMER' WHEN E.BANCODEPOSITO=2 THEN 'BANAMEX' WHEN E.BANCODEPOSITO=3 THEN 'COMERMEX' " + _
                                         "WHEN E.BANCODEPOSITO=4 THEN 'SERFIN' WHEN E.BANCODEPOSITO=5 THEN 'BANOBRAS' WHEN E.BANCODEPOSITO=6 THEN 'ATLANTCO'  WHEN E.BANCODEPOSITO=7 THEN 'CITIBANK'  WHEN E.BANCODEPOSITO=8 THEN  'CONFIA'  WHEN E.BANCODEPOSITO=9 THEN  'SANTANDER' " + _
                                         "WHEN E.BANCODEPOSITO=10 THEN 'MEXICANO'  WHEN E.BANCODEPOSITO=11 THEN  'IXE' WHEN E.BANCODEPOSITO=12 THEN 'FIN COMUN' WHEN E.BANCODEPOSITO=13 THEN 'SCOTIABANK'  WHEN E.BANCODEPOSITO=14 THEN 'BANORTE'  WHEN E.BANCODEPOSITO=15 THEN  'INBURSA' " + _
                                         "WHEN E.BANCODEPOSITO=16 THEN 'HSBC'  WHEN E.BANCODEPOSITO=17 THEN  'BANREGIO'  WHEN E.BANCODEPOSITO=18 THEN 'BANCO AZTECA'  WHEN E.BANCODEPOSITO=21 THEN 'BITAL' WHEN E.BANCODEPOSITO=30 THEN 'BBVA'  END AS BANCO " + _
                                         "FROM  EMPLEADO AS E INNER JOIN MOVIMIENTO AS M ON E.TRAB_ID = M.TRAB_ID INNER JOIN (SELECT  TRAB_ID, MAX(PTR) AS PTR FROM   MOVIMIENTO AS MOVIMIENTO_1 WHERE ( FECHAMOV <= '" + Format(FFin.Date, "dd/MM/yyyy") + "' ) and Centro_ID=" + Centro + " GROUP BY TRAB_ID) AS LM ON M.TRAB_ID = LM.TRAB_ID AND M.PTR = LM.PTR  " + _
                                         "INNER JOIN TBCENTROS  ON M.CENTRO_ID = TBCENTROS.CENTRO_ID INNER JOIN TBREGPAT  ON TBCENTROS.REGPAT_ID = TBREGPAT.REGPAT_ID INNER JOIN TBPUESTO  ON M.PUESTO_ID = TBPUESTO.PUESTO_ID INNER JOIN TBDEPTO  ON M.DEPTO_ID = TBDEPTO.DEPTO_ID " + _
                                         "INNER JOIN ANTIGUEDAD ON E.TRAB_ID = ANTIGUEDAD.TRAB_ID INNER JOIN (SELECT  ANTIGEMPL.TRAB_ID, TBFACTORINTEGRA.VACACIONES, TBFACTORINTEGRA.AGUINALDO, TBFACTORINTEGRA.PRIMA FROM TBFACTORINTEGRA  " + _
                                         "INNER JOIN (SELECT ANTFACT.TRAB_ID, MAX(TBFI.ANTIGUEDAD) AS ANTIG, ANTFACT.TIPOEMPLEADO_ID  FROM  TBFACTORINTEGRA AS TBFI INNER JOIN (SELECT  ANT.TRAB_ID, ANT.ANO + CAST(ANT.DIAS AS MONEY) / 1000 AS ANTIGUEDAD, " + _
                                         "MOVIMIENTO.TIPOEMPLEADO_ID FROM ANTIGUEDAD AS ANT INNER JOIN (SELECT  TRAB_ID, MAX(PTR) AS PTR FROM MOVIMIENTO AS MOVIMIENTO_2  WHERE ( FECHAMOV <= '" + Format(FFin.Date, "dd/MM/yyyy") + "' ) GROUP  BY TRAB_ID) AS LM_1 ON ANT.TRAB_ID = LM_1.TRAB_ID " + _
                                         "INNER JOIN MOVIMIENTO ON LM_1.TRAB_ID = MOVIMIENTO.TRAB_ID  AND LM_1.PTR = MOVIMIENTO.PTR) AS ANTFACT ON TBFI.ANTIGUEDAD <= ANTFACT.ANTIGUEDAD AND TBFI.TIPOEMPLEADO_ID = ANTFACT.TIPOEMPLEADO_ID " + _
                                         "GROUP  BY ANTFACT.TRAB_ID, ANTFACT.TIPOEMPLEADO_ID) AS ANTIGEMPL  ON TBFACTORINTEGRA.TIPOEMPLEADO_ID = ANTIGEMPL.TIPOEMPLEADO_ID AND TBFACTORINTEGRA.ANTIGUEDAD = ANTIGEMPL.ANTIG) AS FACTEMPL ON M.TRAB_ID = FACTEMPL.TRAB_ID " + _
                                         "INNER JOIN (SELECT * FROM (SELECT TRAB_ID, CONCEPTO_ID, IMPORTE FROM NomCalculohistorico WHERE ( INICIO >= '" + Format(FInicio.Date, "dd/MM/yyyy") + "' ) AND ( FINAL <= '" + Format(FFin.Date, "dd/MM/yyyy") + "') and Centro_ID =" + Centro + "  and tiponomina_id in (1,2,9,23) " + _
                                         "AND CONCEPTO_ID IN (51,50,30,14,6,9,7,8,52,54,57,58,59,60,61,63,201,204,78,231,232,79,77,282,503, 75,233,234,237,74,240,498,229,499,230,500,501,514,510,511,525,521,520,522,552,513,515,516,64,80,492,493,212,927, " + _
                                         "700,900,915,916,917,918,919,920,921,922,923,924,925,976,926,928,962,975,523,524,53,55,56,211,494,495,496,497)) AS CONCEPTOS  PIVOT (SUM(CONCEPTOS.IMPORTE) FOR CONCEPTOS.CONCEPTO_ID " + _
                                         "IN ([51],[50],[30],[14],[6],[9],[7],[8],[52],[54],[57],[58],[59],[60],[61],[63],[201],[204],[78],[231],[232],[79],[77],[282],  " + _
                                         "[75],[233],[234],[237],[74],[240],[498],[229],[499],[230],[500],[501],[514],[510],[511],[525],[521],[520],[522],[552],[513],[515],[516],[64],[80],[492],[493],[212],[927],[503],  " + _
                                         "[700],[900],[915],[916],[917],[918],[919],[920],[921],[922],[923],[924],[925],[976],[926],[928],[962],[975],[523],[524],[53],[55],[56],[211],[494],[495],[496],[497])) AS PIVOTTABLE) AS CONCEPTOS " + _
                                         "ON M.TRAB_ID = CONCEPTOS.TRAB_ID  /*para traer DATO */  INNER JOIN (SELECT * FROM (SELECT TRAB_ID, CONCEPTO_ID, Dato FROM NomCalculohistorico " + _
                                         "WHERE ( INICIO >= '" + Format(FInicio.Date, "dd/MM/yyyy") + "' ) AND ( FINAL <='" + Format(FFin.Date, "dd/MM/yyyy") + "' )  and Centro_ID =" + Centro + " and tiponomina_id in (1,2,9,23) " + _
                                         "AND CONCEPTO_ID IN (51,50,30,14,6,9,7,8,52,54,57,58,59,60,61,63,201,204,78,231,232,79,77,282,503, 75,233,234,237,74,240,498,229,499,230,500,501,514,510,511,525,521,520,522,552,513,515,516,64,80,492,493,212,927, " + _
                                         "700,900,915,916,917,918,919,920,921,922,923,924,925,976,926,928,962,975,523,524,53,55,56,211,494,495,496,497)) AS CONCEPTOS  PIVOT (SUM(Conceptos.DATO)  FOR CONCEPTOS.CONCEPTO_ID " + _
                                         "IN ([51],[50],[30],[14],[6],[9],[7],[8],[52],[54],[57],[58],[59],[60],[61],[63],[201],[204],[78],[231],[232],[79],[77],[282], " + _
                                         "[75],[233],[234],[237],[74],[240],[498],[229],[499],[230],[500],[501],[514],[510],[511],[525],[521],[520],[522],[552],[513],[515],[516],[64],[80],[492],[493],[212],[927],[503], " + _
                                         "[700],[900],[915],[916],[917],[918],[919],[920],[921],[922],[923],[924],[925],[976],[926],[928],[962],[975],[523],[524],[53],[55],[56],[211],[494],[495],[496],[497]) ) AS PIVOTTABLE) AS DATOS " + _
                                         "ON M.TRAB_ID = DATOS.TRAB_ID order by 'NOMBRE DE EMPLEADO'", conn)
                comm.CommandType = CommandType.Text
                comm.CommandTimeout = 20000
                conn.Open()
                dr = comm.ExecuteReader
                While dr.Read
                    Dim c As clsNomina
                    Dim clabe As String
                    Dim banco As String
                    Dim tipoCaso As Int32 = 0

                    tipoCaso = CInt(dr("TIPO CASO"))

                    If IsDBNull(dr("BANCO")) Then
                        banco = ""
                    Else
                        banco = dr("BANCO")
                    End If

                    If IsDBNull(dr("CLABE")) Then
                        clabe = ""
                    Else
                        clabe = dr("CLABE")
                    End If
                    c = New clsNomina(dr("CLIENTE"), dr("PUESTO"), dr("NO. EMPLEADO"), CDate(dr("FECHA ALTA")), dr("MOV"), dr("NOMBRE DE EMPLEADO"), tipoCaso, dr("SUELDO NOMINAL MENSUAL"), dr("FLEXIBLE BRUTO MENSUAL(PS/IAS)"), _
                                      CInt(dr("5 Ó 7%")), dr("SUELDO DIARIO"), dr("SDI"), dr("DÍAS LABORADOS"), dr("DÍAS RETROACTIVOS"), dr("DÍAS FALTAS"), dr("DIAS DE INC.ENF.GRAL."), dr("DIAS DE INC.MATERNIDAD"), dr("DIAS DE INC.RT O TRAYECTO"), dr("FLEXIBLE QUINCENAL"), _
                                      dr("BONO UNICO BR PS/IAS"), dr("BONO NEGOCIACION BR PS/IAS"), dr("BONO ESPECIAL BR PS/IAS"), dr("SUBSIDIO ENFERMEDAD GENERAL BR PS/IAS"), dr("SUBSIDIO ACCIDENTE TRABAJO BR PS/IAS"), dr("SUBSIDIO ACCIDENTE TRAYECTO BR PS/IAS"), dr("SUBSIDIO MATERNIDAD BR PS/IAS"), dr("BONO POR HORAS EXTRAS BR PS/IAS"), dr("RETROACTIVO BR PS/IAS"), dr("SUELDO"), _
                                      dr("RETROACTIVO SUELDO"), dr("REEMBOLSO INFONAVIT"), dr("PRIMA VACACIONAL ANIVERSARIO"), dr("SUBSIDIO EG 1-3 DIAS"), dr("SUBSIDIO EG 4 EN ADELANTE"), dr("AGUINALDO ANUAL"), dr("AGUINALDO FINIQUITO"), dr("VACACIONES FINIQUITO"), dr("PRIMA VACACIONAL FINIQUITO"), dr("INDEMNIZACION 3 MESES"), _
                                      dr("INDEMNIZACION 20 DIAS"), dr("NEGOCIACION GRAVADA"), dr("PRIMA ANTIGÜEDAD 12 DIAS"), dr("PTU"), dr("SUBSIDIO PARA EL EMPLEO PAGADO"), dr("PS DIAS LABORADOS"), dr("PS RETROACTIVO"), dr("IAS DIAS LABORADOS"), dr("IAS DIAS PENDIENTES"), dr("FLEXIBLE SUBSIDIOS INCAP."), _
                                      CDbl(dr("FLEXIBLE BONO")), dr("FLEXIBLE BONO NEGOCIACION"), dr("FLEXIBLE BONO ESPECIAL"), dr("TOTAL PERCEPCIONES"), dr("IMPUESTO RETENIDO"), dr("IMPUESTO INDEMNIZACIÓN"), dr("ISR AJUSTE ANNUAL 177"), dr("IMSS"), dr("DESC CREDITO INFONAVIT"), dr("AJUSTE DIFERENCIA CRED INFONAVIT"), _
                                      dr("OTROS DESCUENTOS"), dr("FONACOT"), dr("PRESTAMO PERSONAL"), dr("OTRAS DEDUCCIONES"), dr("DESCUENTO PENSION ALIMENTICIA"), dr("TOTAL DEDUCCIONES"), dr("NETO A PAGAR"), dr("IMSS EXCEDENTE PATRON"), dr("IMSS PRESTACIONES EN DINERO"), dr("IMSS PRESTACIONES EN ESPECIE"), _
                                      dr("IMSS IV PATRONAL"), dr("IMSS PROVISION GUARDERIA"), dr("IMSS RIESGO DE TRABAJO"), dr("PROVISION SAR"), dr("PROVISION INFONAVIT"), dr("IMSS CV PATRONAL"), dr("IMSS CUOTA FIJA"), dr("IMSS PATRONAL"), dr("IMSS OBRERO"), dr("ISN"), _
                                      dr("CARGA SOCIAL"), dr("COMISION NOMINA"), dr("IVA"), dr("TOTAL A FACTURAR"), dr("CUENTA"), clabe, banco)
                    If Not IsDBNull(dr("FECHA BAJA")) Then
                        'MessageBox.Show(dr("FECHA BAJA").ToString & " --> " & dr("NO. EMPLEADO"))
                        c.FechaBaja = CDate(dr("FECHA BAJA"))
                        For i = j To arrBajas.Count - 1
                            If CType(arrBajas(i), clsEmpleadoBaja).TarjetaID = dr("NO. EMPLEADO") Then
                                CType(arrBajas(i), clsEmpleadoBaja).NominaActual = True
                                j = i + 1
                                Exit For
                            End If
                        Next
                    End If

                    arrNominas.Add(c)
                End While
                dr.Close()
            End Using
            Return arrNominas
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo obtener la lista de la Nomina... " + ex.Message)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function
    Public Function ObtenerEmpleadosBaja(ByVal Centro As String, ByVal FInicio As Date, ByVal FFin As Date) As ArrayList
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Dim arrEmpleadosBaja As New ArrayList
            Using comm As New SqlCommand("select E.Tarjeta_ID,E.Trab_ID,M.FechaMov,E.PATERNO + ' ' + E.MATERNO + ' ' + E.NOMBRE AS 'NOMBRE DE EMPLEADO', M.Mov_ID as MOV " + _
                                         "from Movimiento M inner join Empleado E on E.Trab_ID=M.Trab_ID where FechaMov between '" + Format(FInicio.Date, "dd/MM/yyyy") + "' and '" + Format(FFin.Date, "dd/MM/yyyy") + "' " + _
                                         "and Centro_ID= " + Centro + " and Mov_ID in ('B') order by 'NOMBRE DE EMPLEADO'", conn)
                comm.CommandType = CommandType.Text
                comm.CommandTimeout = 20000
                conn.Open()
                dr = comm.ExecuteReader
                While dr.Read
                    Dim c As clsEmpleadoBaja
                    c = New clsEmpleadoBaja(dr("Tarjeta_ID"), dr("Trab_ID"), CDate(dr("FechaMov")), dr("MOV"), False)

                    arrEmpleadosBaja.Add(c)
                End While
                dr.Close()
            End Using
            Return arrEmpleadosBaja
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo obtener la lista de la Nomina dados de baja... " + ex.Message)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function

    Public Function sp_ObtenerEmpleadosBaja(ByVal Centro As String, ByVal FInicio As Date, ByVal FFin As Date) As ArrayList
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Dim tipocaso As Integer
        Dim flexible As Double
        Try
            Dim arrEmpleadosBaja As New ArrayList
            Using comm As New SqlCommand("sp_ObtenEmpleadoBaja", conn)
                comm.CommandType = CommandType.StoredProcedure
                comm.CommandTimeout = 20000
                conn.Open()
                dr = comm.ExecuteReader
                While dr.Read
                    Dim c As clsEmpleadoBaja
                    c = New clsEmpleadoBaja(dr("Tarjeta_ID"), dr("Trab_ID"), CDate(dr("FechaMov")), dr("MOV"), False)
                    If IsDBNull(dr("TipoCaso")) Then
                        tipoCaso = 1
                        Dim cEmpleado As clsEmpleadoEdad
                        cEmpleado = ObtieneEdadesPorPersonaBajaSinNomina(c.TarjetaID, Centro, FInicio, FInicio)
                        If IsDBNull(dr("Flexible")) Then
                            Flexible = 0.0
                        Else
                            Flexible = CDbl(dr("Flexible"))
                        End If
                        ''NUEVO
                        If IsDBNull(dr("Tarjeta_ID")) Then
                            MsgBox("No es posible continuar revise el dato: (Tarjeta de usuario) para el usuario con el CURP" + (dr("CURP")))
                        End If

                        If IsDBNull(dr("CURP")) Then
                            MsgBox("No es posible continuar revise el dato: (CURP) para el usuario " + (dr("Tarjeta_ID")))
                        End If

                        If IsDBNull(dr("Mov_ID")) Then
                            MsgBox("No es posible continuar revise el dato: (Mov_ID) para el usuario " + (dr("Tarjeta_ID")))
                        End If

                        If IsDBNull(dr("FechaMov")) Then
                            MsgBox("No es posible continuar revise el dato: (FechaMov) para el usuario " + (dr("Tarjeta_ID")))
                        End If

                        c.Tarjeta_Id = cEmpleado.TarjetaId
                        c.fechanacimiento = cEmpleado.FechaNacimiento
                        c.sexo = cEmpleado.Sexo
                        c.curp = cEmpleado.Curp
                        c.movi = cEmpleado.Mov
                        c.fecmov = cEmpleado.FechaMov
                        c.tipocaso2 = tipocaso
                        c.flexible = flexible

                        c.segurogmm = Funciones.ObtieneSeguroVidaBaja(c)
                    Else
                        tipoCaso = CInt(dr("TipoCaso"))
                        If IsDBNull(dr("Flexible")) Then
                            Flexible = 0.0
                        Else
                            Flexible = CDbl(dr("Flexible"))
                        End If
                        ''NUEVO
                        If IsDBNull(dr("Tarjeta_ID")) Then
                            MsgBox("No es posible continuar revise el dato: (Tarjeta de usuario) para el usuario con el CURP" + (dr("CURP")))
                        End If

                        If IsDBNull(dr("CURP")) Then
                            MsgBox("No es posible continuar revise el dato: (CURP) para el usuario " + (dr("Tarjeta_ID")))
                        End If

                        If IsDBNull(dr("Mov_ID")) Then
                            MsgBox("No es posible continuar revise el dato: (Mov_ID) para el usuario " + (dr("Tarjeta_ID")))
                        End If

                        If IsDBNull(dr("FechaMov")) Then
                            MsgBox("No es posible continuar revise el dato: (FechaMov) para el usuario " + (dr("Tarjeta_ID")))
                        End If

                        c.Tarjeta_Id = dr("Tarjeta_ID")
                        c.fechanacimiento = ConvierteFechaNacDeCURP(dr("CURP"))
                        c.sexo = ConvierteSexoDeCURP(dr("CURP"))
                        c.curp = dr("CURP")
                        c.movi = dr("Mov_ID")
                        c.fecmov = CDate(dr("FechaMov"))
                        c.tipocaso2 = tipocaso
                        c.flexible = flexible

                        c.segurogmm = Funciones.ObtieneSeguroVidaBaja(c)

                        'mensajelog = mensajelog + " El calculo del empleado con ID " + cNomina.TarjetaId + " Ok... " + vbCrLf
                        'frmNomina.txtlog.Text += mensajelog
                    End If
                    arrEmpleadosBaja.Add(c)
                End While
                dr.Close()
            End Using
            Return arrEmpleadosBaja
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo obtener la lista de la Nomina dados de baja... " + ex.Message)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function
    ''metodos nuevos

    ''metodo1

    Public Function pGenerarReporteNominaXML(ByVal arre As ArrayList, ByVal fecha1 As Date _
                                             , ByVal fecha2 As Date, ByVal centro As Integer, ByVal arrBajas As ArrayList) As ArrayList

        Dim memory_stream2 As New MemoryStream()
        Dim xml_text_writer2 As New XmlTextWriter(memory_stream2, System.Text.Encoding.Default)

        xml_text_writer2.Formatting = Formatting.Indented
        xml_text_writer2.Indentation = 4
        xml_text_writer2.WriteStartDocument(True)
        xml_text_writer2.WriteStartElement("tn")


        For Each a As Integer In arre
            Me.HacerInfoAsignacion(xml_text_writer2, a)
        Next


        xml_text_writer2.WriteEndElement()
        xml_text_writer2.WriteEndDocument()
        xml_text_writer2.Flush()

        Dim stream_reader2 As New StreamReader(memory_stream2)
        memory_stream2.Seek(0, SeekOrigin.Begin)

        Dim reader2 As New XmlTextReader(memory_stream2)

        Try
            Return pGenerarReporteNomina(reader2, fecha1, fecha2, centro, arrBajas)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    ' ''metodo2

    Private Shared Sub HacerInfoAsignacion(ByVal xml_text_writer As XmlTextWriter, ByVal numero As Integer)

        xml_text_writer.WriteStartElement("i")

        xml_text_writer.WriteStartAttribute("id")
        xml_text_writer.WriteString(numero)
        xml_text_writer.WriteEndAttribute()

        xml_text_writer.WriteEndElement()

    End Sub

    ''metodo3
    Private Function pGenerarReporteNomina(ByVal X As XmlTextReader, ByVal fecha1 As Date _
                                             , ByVal fecha2 As Date, ByVal centro As Integer, ByVal arrBajas As ArrayList) As ArrayList
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Dim arre As New ArrayList
        Dim cNomina As clsNomina

        Try
            Dim j, i As Int32
            j = 0 : i = 0

            If fecha1.Month <> fecha2.Month Then
                MessageBox.Show("Advertencia, el tipo caso se vera afectado por las fechas ingresadas que no corresponden al mismo mes...")
            End If


            Using comm As New SqlCommand("pGenerarReporteNomina", conn)
                With comm
                    .CommandType = CommandType.StoredProcedure
                    .CommandTimeout = 0
                    .Parameters.AddWithValue("@FechaInicio", fecha1)
                    .Parameters.AddWithValue("@FechaFin", fecha2)
                    .Parameters.AddWithValue("@CentroID", centro)
                    .Parameters.Add("@TiposNominaXML", SqlDbType.Xml).Value = X
                End With
                conn.Open()
                dr = comm.ExecuteReader

                While dr.Read
                    'guardar en array todos los datos
                    'Dim c As clsNomina
                    Dim clabe As String
                    Dim banco As String
                    Dim tipoCaso As Int32 = 0
                    Dim Flexible As Double

                    If IsDBNull(dr("BANCO")) Then
                        banco = ""
                    Else
                        banco = dr("BANCO")
                    End If

                    If IsDBNull(dr("CLABE")) Then
                        clabe = ""
                    Else
                        clabe = dr("CLABE")
                    End If
                    If IsDBNull(dr("TIPO CASO")) Then
                        tipoCaso = 1
                    Else
                        tipoCaso = dr("TIPO CASO")
                    End If
                    cNomina = New clsNomina(dr("CLIENTE"), dr("PUESTO"), dr("NO. EMPLEADO"), CDate(dr("FECHA ALTA")), dr("MOV"), dr("NOMBRE DE EMPLEADO"), tipoCaso, dr("SUELDO NOMINAL MENSUAL"), dr("FLEXIBLE BRUTO MENSUAL(PS/IAS)"), _
                                      CInt(dr("5 Ó 7%")), dr("SUELDO DIARIO"), dr("SDI"), dr("DÍAS LABORADOS"), dr("DÍAS RETROACTIVOS"), dr("DÍAS FALTAS"), dr("DIAS DE INC.ENF.GRAL."), dr("DIAS DE INC.MATERNIDAD"), dr("DIAS DE INC.RT O TRAYECTO"), dr("FLEXIBLE QUINCENAL"), _
                                      dr("BONO UNICO BR PS/IAS"), dr("BONO NEGOCIACION BR PS/IAS"), dr("BONO ESPECIAL BR PS/IAS"), dr("SUBSIDIO ENFERMEDAD GENERAL BR PS/IAS"), dr("SUBSIDIO ACCIDENTE TRABAJO BR PS/IAS"), dr("SUBSIDIO ACCIDENTE TRAYECTO BR PS/IAS"), dr("SUBSIDIO MATERNIDAD BR PS/IAS"), dr("BONO POR HORAS EXTRAS BR PS/IAS"), dr("RETROACTIVO BR PS/IAS"), dr("SUELDO"), _
                                      dr("RETROACTIVO SUELDO"), dr("REEMBOLSO INFONAVIT"), dr("PRIMA VACACIONAL ANIVERSARIO"), dr("SUBSIDIO EG 1-3 DIAS"), dr("SUBSIDIO EG 4 EN ADELANTE"), dr("AGUINALDO ANUAL"), dr("AGUINALDO FINIQUITO"), dr("VACACIONES FINIQUITO"), dr("PRIMA VACACIONAL FINIQUITO"), dr("INDEMNIZACION 3 MESES"), _
                                      dr("INDEMNIZACION 20 DIAS"), dr("NEGOCIACION GRAVADA"), dr("PRIMA ANTIGÜEDAD 12 DIAS"), dr("PTU"), dr("SUBSIDIO PARA EL EMPLEO PAGADO"), dr("PS DIAS LABORADOS"), dr("PS RETROACTIVO"), dr("IAS DIAS LABORADOS"), dr("IAS DIAS PENDIENTES"), dr("FLEXIBLE SUBSIDIOS INCAP."), _
                                      CDbl(dr("FLEXIBLE BONO")), dr("FLEXIBLE BONO NEGOCIACION"), dr("FLEXIBLE BONO ESPECIAL"), dr("TOTAL PERCEPCIONES"), dr("IMPUESTO RETENIDO"), dr("IMPUESTO INDEMNIZACIÓN"), dr("ISR AJUSTE ANNUAL 177"), dr("IMSS"), dr("DESC CREDITO INFONAVIT"), dr("AJUSTE DIFERENCIA CRED INFONAVIT"), _
                                      dr("OTROS DESCUENTOS"), dr("FONACOT"), dr("PRESTAMO PERSONAL"), dr("OTRAS DEDUCCIONES"), dr("DESCUENTO PENSION ALIMENTICIA"), dr("TOTAL DEDUCCIONES"), dr("NETO A PAGAR"), dr("IMSS EXCEDENTE PATRON"), dr("IMSS PRESTACIONES EN DINERO"), dr("IMSS PRESTACIONES EN ESPECIE"), _
                                      dr("IMSS IV PATRONAL"), dr("IMSS PROVISION GUARDERIA"), dr("IMSS RIESGO DE TRABAJO"), dr("PROVISION SAR"), dr("PROVISION INFONAVIT"), dr("IMSS CV PATRONAL"), dr("IMSS CUOTA FIJA"), dr("IMSS PATRONAL"), dr("IMSS OBRERO"), dr("ISN"), _
                                      dr("CARGA SOCIAL"), dr("COMISION NOMINA"), dr("IVA"), dr("TOTAL A FACTURAR"), dr("CUENTA"), clabe, banco)
                    If Not IsDBNull(dr("FECHA BAJA")) Then
                        'MessageBox.Show(dr("FECHA BAJA").ToString & " --> " & dr("NO. EMPLEADO"))
                        cNomina.FechaBaja = CDate(dr("FECHA BAJA"))

                        For i = j To arrBajas.Count - 1
                            If CType(arrBajas(i), clsEmpleadoBaja).TarjetaID = dr("NO. EMPLEADO") Then
                                CType(arrBajas(i), clsEmpleadoBaja).NominaActual = True
                                j = i + 1
                                Exit For
                            End If
                        Next
                    End If
                    If IsDBNull(dr("TipoCaso")) Then
                        tipoCaso = 1
                        Dim cEmpleado As clsEmpleadoEdad
                        cEmpleado = ObtieneEdadesPorPersonaBajaSinNomina(cNomina.Empleado, centro, fecha1, fecha2)
                        If IsDBNull(dr("Flexible")) Then
                            Flexible = 0.0
                        Else
                            Flexible = CDbl(dr("Flexible"))
                        End If
                        ''NUEVO
                        If IsDBNull(dr("Tarjeta_ID")) Then
                            MsgBox("No es posible continuar revise el dato: (Tarjeta de usuario) para el usuario con el CURP" + (dr("CURP")))
                        End If

                        If IsDBNull(dr("CURP")) Then
                            MsgBox("No es posible continuar revise el dato: (CURP) para el usuario " + (dr("Tarjeta_ID")))
                        End If

                        If IsDBNull(dr("Mov_ID")) Then
                            MsgBox("No es posible continuar revise el dato: (Mov_ID) para el usuario " + (dr("Tarjeta_ID")))
                        End If

                        If IsDBNull(dr("FechaMov")) Then
                            MsgBox("No es posible continuar revise el dato: (FechaMov) para el usuario " + (dr("Tarjeta_ID")))
                        End If

                        cNomina.TarjetaId = cEmpleado.TarjetaId
                        cNomina.fechanacimiento = cEmpleado.FechaNacimiento
                        cNomina.sexo = cEmpleado.Sexo
                        cNomina.curp = cEmpleado.Curp
                        cNomina.movi = cEmpleado.Mov
                        cNomina.fecmov = cEmpleado.FechaMov
                        cNomina.tipocaso2 = tipoCaso
                        cNomina.flexible = Flexible

                        cNomina.segurogmm = Funciones.ObtieneSeguroVida(cNomina)
                    Else
                        tipoCaso = CInt(dr("TipoCaso"))
                        If IsDBNull(dr("Flexible")) Then
                            Flexible = 0.0
                        Else
                            Flexible = CDbl(dr("Flexible"))
                        End If
                        ''NUEVO
                        If IsDBNull(dr("Tarjeta_ID")) Then
                            MsgBox("No es posible continuar revise el dato: (Tarjeta de usuario) para el usuario con el CURP" + (dr("CURP")))
                        End If

                        If IsDBNull(dr("CURP")) Then
                            MsgBox("No es posible continuar revise el dato: (CURP) para el usuario " + (dr("Tarjeta_ID")))
                        End If

                        If IsDBNull(dr("Mov_ID")) Then
                            MsgBox("No es posible continuar revise el dato: (Mov_ID) para el usuario " + (dr("Tarjeta_ID")))
                        End If

                        If IsDBNull(dr("FechaMov")) Then
                            MsgBox("No es posible continuar revise el dato: (FechaMov) para el usuario " + (dr("Tarjeta_ID")))
                        End If

                        cNomina.TarjetaId = dr("Tarjeta_ID")
                        cNomina.fechanacimiento = ConvierteFechaNacDeCURP(dr("CURP"))
                        cNomina.sexo = ConvierteSexoDeCURP(dr("CURP"))
                        cNomina.curp = dr("CURP")
                        cNomina.movi = dr("Mov_ID")
                        cNomina.fecmov = CDate(dr("FechaMov"))
                        cNomina.tipocaso2 = tipoCaso
                        cNomina.flexible = Flexible

                        cNomina.segurogmm = Funciones.ObtieneSeguroVida(cNomina)

                        'mensajelog = mensajelog + " El calculo del empleado con ID " + cNomina.TarjetaId + " Ok... " + vbCrLf
                        'frmNomina.txtlog.Text += mensajelog
                    End If
                    

                    'If tipoCaso = "" Or " " Then
                    '    MsgBox("No es posible continuar revise el Tipo de Caso  para el usuario " + (dr("Tarjeta_ID")))
                    'End If

                    'If Flexible = "" Or " " Then
                    '    MsgBox("No es posible continuar revise el dato Flexible  para el usuario " + (dr("Tarjeta_ID")))
                    'End If

                    '' NUEVO



                    arre.Add(cNomina)
                End While
                dr.Close()
            End Using

            Return arre

        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo obtener la lista de la Nomina... " + ex.Message)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function



    ''metodos nuevos
    Public Function ObtenerNominaEmpleadoBaja(ByVal Centro As String, ByVal Empleado As String, ByVal FInicial As Date, ByVal FBaja As Date) As clsNomina
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Dim FInicio, FFin As Date

            If FInicial.Day = 1 Then
                FInicio = DateSerial(Year(FInicial.Date), Month(FInicial.Date) - 1, 15) 'Ultimo dia del mes
                FFin = DateSerial(Year(FInicial.Date), Month(FInicial.Date), 0) 'Ultimo dia del mes
            ElseIf FInicial.Day = 15 Then
                FInicio = DateSerial(Year(FInicial.Date), Month(FInicial.Date), 1) 'Ultimo dia del mes
                FFin = DateSerial(Year(FInicial.Date), Month(FInicial.Date), 15) 'Ultimo dia del mes
            End If


            Dim cNomina As clsNomina


            Using comm As New SqlCommand("SELECT TBDEPTO.DESCRIPCION AS 'CLIENTE', TBPUESTO.DESCRIPCION AS 'PUESTO', E.TARJETA_ID AS 'NO. EMPLEADO', CONVERT(VARCHAR(10), E.FECHAINGRESO, 103) AS 'FECHA ALTA', " + _
                                         "CASE WHEN M.Mov_ID='B' THEN CONVERT(VARCHAR(10), M.FechaMov, 103) END AS 'FECHA BAJA',M.Mov_ID as MOV,  E.PATERNO + ' ' + E.MATERNO + ' ' + E.NOMBRE AS 'NOMBRE DE EMPLEADO',  " + _
                                         "CONCEPTOS.[51] AS 'TIPO CASO', (M.SALARIO * 30) AS 'SUELDO NOMINAL MENSUAL', ISNULL(CONCEPTOS.[50], 0.00) AS 'FLEXIBLE BRUTO MENSUAL(PS/IAS)', ISNULL(CONCEPTOS.[53], 0) AS '5 Ó 7%',  " + _
                                         "M.SALARIO AS 'SUELDO DIARIO', M.INTEGRADOIMSS AS SDI, ISNULL(CONCEPTOS.[30], 0.00) AS 'DÍAS LABORADOS',  ISNULL(DATOS.[63], 0.00) AS 'DÍAS RETROACTIVOS',  " + _
                                         "ISNULL(CONCEPTOS.[14], 0.00) AS 'DÍAS FALTAS', ISNULL(DATOS.[6], 0.00) AS 'DIAS DE INC.ENF.GRAL.', ISNULL(DATOS.[9], 0.00) AS 'DIAS DE INC.MATERNIDAD',   " + _
                                         "ISNULL(DATOS.[7], 0.00)+ISNULL(DATOS.[8], 0.00) AS 'DIAS DE INC.RT O TRAYECTO', ISNULL(CONCEPTOS.[52], 0.00) AS 'FLEXIBLE QUINCENAL', ISNULL(CONCEPTOS.[54], 0.00) + ISNULL(CONCEPTOS.[64], 0.00)+ISNULL(CONCEPTOS.[80], 0.00) AS 'BONO UNICO BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[55], 0.00) AS 'BONO NEGOCIACION BR PS/IAS', ISNULL(CONCEPTOS.[56], 0.00) AS 'BONO ESPECIAL BR PS/IAS', ISNULL(CONCEPTOS.[57], 0.00) AS 'SUBSIDIO ENFERMEDAD GENERAL BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[58], 0.00) AS 'SUBSIDIO ACCIDENTE TRABAJO BR PS/IAS', ISNULL(CONCEPTOS.[59], 0.00) AS 'SUBSIDIO ACCIDENTE TRAYECTO BR PS/IAS', ISNULL(CONCEPTOS.[60], 0.00) AS 'SUBSIDIO MATERNIDAD BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[61], 0.00) AS 'BONO POR HORAS EXTRAS BR PS/IAS', ISNULL(CONCEPTOS.[63], 0.00) AS 'RETROACTIVO BR PS/IAS', ISNULL(CONCEPTOS.[201], 0.00) AS 'SUELDO', " + _
                                         "ISNULL(CONCEPTOS.[204], 0.00) AS 'RETROACTIVO SUELDO', ISNULL(CONCEPTOS.[212], 0.00) AS 'REEMBOLSO INFONAVIT', ISNULL(CONCEPTOS.[78], 0.00) AS 'PRIMA VACACIONAL ANIVERSARIO', " + _
                                         "ISNULL(CONCEPTOS.[231], 0.00) AS 'SUBSIDIO EG 1-3 DIAS', ISNULL(CONCEPTOS.[232], 0.00) AS 'SUBSIDIO EG 4 EN ADELANTE', ISNULL(CONCEPTOS.[79], 0.00) AS 'AGUINALDO ANUAL', " + _
                                         "ISNULL(CONCEPTOS.[77], 0.00) AS 'AGUINALDO FINIQUITO', ISNULL(CONCEPTOS.[282], 0.00) AS 'VACACIONES FINIQUITO', ISNULL(CONCEPTOS.[75], 0.00) AS 'PRIMA VACACIONAL FINIQUITO', " + _
                                         "ISNULL(CONCEPTOS.[233], 0.00) AS 'INDEMNIZACION 3 MESES', ISNULL(CONCEPTOS.[234], 0.00) AS 'INDEMNIZACION 20 DIAS', ISNULL(CONCEPTOS.[237], 0.00) AS 'NEGOCIACION GRAVADA', " + _
                                         "ISNULL(CONCEPTOS.[74], 0.00) AS 'PRIMA ANTIGÜEDAD 12 DIAS', ISNULL(CONCEPTOS.[211], 0.00) AS 'PTU', ISNULL(CONCEPTOS.[240], 0.00) AS 'SUBSIDIO PARA EL EMPLEO PAGADO', ISNULL(CONCEPTOS.[498], 0.00) AS 'PS DIAS LABORADOS', " + _
                                         "ISNULL(CONCEPTOS.[229], 0.00) AS 'PS RETROACTIVO', ISNULL(CONCEPTOS.[499], 0.00) AS 'IAS DIAS LABORADOS', ISNULL(CONCEPTOS.[230], 0.00) AS 'IAS DIAS PENDIENTES', ISNULL(CONCEPTOS.[494], 0.00) AS 'FLEXIBLE SUBSIDIOS INCAP.', " + _
                                         "ISNULL(CONCEPTOS.[495], 0.00)+ISNULL(CONCEPTOS.[492], 0.00)+ISNULL(CONCEPTOS.[493], 0.00) AS 'FLEXIBLE BONO', ISNULL(CONCEPTOS.[496], 0.00) AS 'FLEXIBLE BONO NEGOCIACION', " + _
                                         "ISNULL(CONCEPTOS.[497], 0.00) AS 'FLEXIBLE BONO ESPECIAL', ISNULL(CONCEPTOS.[500], 0.00) AS 'TOTAL PERCEPCIONES', ISNULL(CONCEPTOS.[501], 0.00) AS 'IMPUESTO RETENIDO', " + _
                                         "ISNULL(CONCEPTOS.[514], 0.00) AS 'IMPUESTO INDEMNIZACIÓN', ISNULL(CONCEPTOS.[503], 0.00) AS 'ISR AJUSTE ANNUAL 177', ISNULL(CONCEPTOS.[510], 0.00) AS 'IMSS', ISNULL(CONCEPTOS.[511], 0.00) AS 'DESC CREDITO INFONAVIT', " + _
                                         "ISNULL(CONCEPTOS.[525], 0.00) AS 'AJUSTE DIFERENCIA CRED INFONAVIT', ISNULL(CONCEPTOS.[521], 0.00) +ISNULL(CONCEPTOS.[513], 0.00) +ISNULL(CONCEPTOS.[515], 0.00)+ISNULL(CONCEPTOS.[516], 0.00) AS 'OTROS DESCUENTOS', " + _
                                         "ISNULL(CONCEPTOS.[520], 0.00) AS 'FONACOT', ISNULL(CONCEPTOS.[523], 0.00) AS 'PRESTAMO PERSONAL', ISNULL(CONCEPTOS.[524], 0.00) +ISNULL(CONCEPTOS.[552], 0.00) AS 'OTRAS DEDUCCIONES', " + _
                                         "ISNULL(CONCEPTOS.[522], 0.00) AS 'DESCUENTO PENSION ALIMENTICIA', ISNULL(CONCEPTOS.[700], 0.00) AS 'TOTAL DEDUCCIONES', ISNULL(CONCEPTOS.[900], 0.00) AS 'NETO A PAGAR', ISNULL(CONCEPTOS.[915], 0.00) AS 'IMSS EXCEDENTE PATRON', " + _
                                         "ISNULL(CONCEPTOS.[916], 0.00) AS 'IMSS PRESTACIONES EN DINERO', ISNULL(CONCEPTOS.[917], 0.00) AS 'IMSS PRESTACIONES EN ESPECIE', ISNULL(CONCEPTOS.[918], 0.00) AS 'IMSS IV PATRONAL', " + _
                                         "ISNULL(CONCEPTOS.[919], 0.00) AS 'IMSS PROVISION GUARDERIA', ISNULL(CONCEPTOS.[920], 0.00) AS 'IMSS RIESGO DE TRABAJO',ISNULL(CONCEPTOS.[921], 0.00) AS 'PROVISION SAR', ISNULL(CONCEPTOS.[922], 0.00) AS 'PROVISION INFONAVIT', " + _
                                         "ISNULL(CONCEPTOS.[923], 0.00) AS 'IMSS CV PATRONAL', ISNULL(CONCEPTOS.[924], 0.00) AS 'IMSS CUOTA FIJA', ISNULL(CONCEPTOS.[925], 0.00) AS 'IMSS PATRONAL', ISNULL(CONCEPTOS.[927], 0.00) AS 'IMSS OBRERO', " + _
                                         "ISNULL(CONCEPTOS.[976], 0.00) AS 'ISN', ISNULL(CONCEPTOS.[926], 0.00) AS 'CARGA SOCIAL', ISNULL(CONCEPTOS.[928], 0.00) AS 'COMISION NOMINA', ISNULL(CONCEPTOS.[962], 0.00) AS 'IVA',  ISNULL(CONCEPTOS.[975], 0.00) AS 'TOTAL A FACTURAR', " + _
                                         "(char(39)+E.CUENTADEPOSITO) AS CUENTA, (char(39)+E.CLABE)  AS CLABE, CASE WHEN E.BANCODEPOSITO=0 THEN ' ' WHEN E.BANCODEPOSITO=1 THEN 'BANCOMER' WHEN E.BANCODEPOSITO=2 THEN 'BANAMEX' WHEN E.BANCODEPOSITO=3 THEN 'COMERMEX' " + _
                                         "WHEN E.BANCODEPOSITO=4 THEN 'SERFIN' WHEN E.BANCODEPOSITO=5 THEN 'BANOBRAS' WHEN E.BANCODEPOSITO=6 THEN 'ATLANTCO'  WHEN E.BANCODEPOSITO=7 THEN 'CITIBANK'  WHEN E.BANCODEPOSITO=8 THEN  'CONFIA'  WHEN E.BANCODEPOSITO=9 THEN  'SANTANDER' " + _
                                         "WHEN E.BANCODEPOSITO=10 THEN 'MEXICANO'  WHEN E.BANCODEPOSITO=11 THEN  'IXE' WHEN E.BANCODEPOSITO=12 THEN 'FIN COMUN' WHEN E.BANCODEPOSITO=13 THEN 'SCOTIABANK'  WHEN E.BANCODEPOSITO=14 THEN 'BANORTE'  WHEN E.BANCODEPOSITO=15 THEN  'INBURSA' " + _
                                         "WHEN E.BANCODEPOSITO=16 THEN 'HSBC'  WHEN E.BANCODEPOSITO=17 THEN  'BANREGIO'  WHEN E.BANCODEPOSITO=18 THEN 'BANCO AZTECA'  WHEN E.BANCODEPOSITO=21 THEN 'BITAL' WHEN E.BANCODEPOSITO=30 THEN 'BBVA'  END AS BANCO " + _
                                         "FROM  EMPLEADO AS E INNER JOIN MOVIMIENTO AS M ON E.TRAB_ID = M.TRAB_ID INNER JOIN (SELECT  TRAB_ID, MAX(PTR) AS PTR FROM   MOVIMIENTO AS MOVIMIENTO_1 WHERE ( FECHAMOV <= '" + Format(FFin.Date, "dd/MM/yyyy") + "' ) GROUP BY TRAB_ID) AS LM ON M.TRAB_ID = LM.TRAB_ID AND M.PTR = LM.PTR  " + _
                                         "INNER JOIN TBCENTROS  ON M.CENTRO_ID = TBCENTROS.CENTRO_ID INNER JOIN TBREGPAT  ON TBCENTROS.REGPAT_ID = TBREGPAT.REGPAT_ID INNER JOIN TBPUESTO  ON M.PUESTO_ID = TBPUESTO.PUESTO_ID INNER JOIN TBDEPTO  ON M.DEPTO_ID = TBDEPTO.DEPTO_ID " + _
                                         "INNER JOIN ANTIGUEDAD ON E.TRAB_ID = ANTIGUEDAD.TRAB_ID INNER JOIN (SELECT  ANTIGEMPL.TRAB_ID, TBFACTORINTEGRA.VACACIONES, TBFACTORINTEGRA.AGUINALDO, TBFACTORINTEGRA.PRIMA FROM TBFACTORINTEGRA  " + _
                                         "INNER JOIN (SELECT ANTFACT.TRAB_ID, MAX(TBFI.ANTIGUEDAD) AS ANTIG, ANTFACT.TIPOEMPLEADO_ID  FROM  TBFACTORINTEGRA AS TBFI INNER JOIN (SELECT  ANT.TRAB_ID, ANT.ANO + CAST(ANT.DIAS AS MONEY) / 1000 AS ANTIGUEDAD, " + _
                                         "MOVIMIENTO.TIPOEMPLEADO_ID FROM ANTIGUEDAD AS ANT INNER JOIN (SELECT  TRAB_ID, MAX(PTR) AS PTR FROM MOVIMIENTO AS MOVIMIENTO_2  WHERE ( FECHAMOV <= '" + Format(FFin.Date, "dd/MM/yyyy") + "' ) GROUP  BY TRAB_ID) AS LM_1 ON ANT.TRAB_ID = LM_1.TRAB_ID " + _
                                         "INNER JOIN MOVIMIENTO ON LM_1.TRAB_ID = MOVIMIENTO.TRAB_ID  AND LM_1.PTR = MOVIMIENTO.PTR) AS ANTFACT ON TBFI.ANTIGUEDAD <= ANTFACT.ANTIGUEDAD AND TBFI.TIPOEMPLEADO_ID = ANTFACT.TIPOEMPLEADO_ID " + _
                                         "GROUP  BY ANTFACT.TRAB_ID, ANTFACT.TIPOEMPLEADO_ID) AS ANTIGEMPL  ON TBFACTORINTEGRA.TIPOEMPLEADO_ID = ANTIGEMPL.TIPOEMPLEADO_ID AND TBFACTORINTEGRA.ANTIGUEDAD = ANTIGEMPL.ANTIG) AS FACTEMPL ON M.TRAB_ID = FACTEMPL.TRAB_ID " + _
                                         "INNER JOIN (SELECT * FROM (SELECT TRAB_ID, CONCEPTO_ID, IMPORTE FROM NomCalculohistorico WHERE ( INICIO >= '" + Format(FInicio.Date, "dd/MM/yyyy") + "' ) AND ( FINAL <= '" + Format(FFin.Date, "dd/MM/yyyy") + "') and Centro_ID =" + Centro + "  and tiponomina_id in (1) " + _
                                         "AND CONCEPTO_ID IN (51,50,30,14,6,9,7,8,52,54,57,58,59,60,61,63,201,204,78,231,232,79,77,282,503, 75,233,234,237,74,240,498,229,499,230,500,501,514,510,511,525,521,520,522,552,513,515,516,64,80,492,493,212,927, " + _
                                         "700,900,915,916,917,918,919,920,921,922,923,924,925,976,926,928,962,975,523,524,53,55,56,211,494,495,496,497)) AS CONCEPTOS  PIVOT (SUM(CONCEPTOS.IMPORTE) FOR CONCEPTOS.CONCEPTO_ID " + _
                                         "IN ([51],[50],[30],[14],[6],[9],[7],[8],[52],[54],[57],[58],[59],[60],[61],[63],[201],[204],[78],[231],[232],[79],[77],[282],  " + _
                                         "[75],[233],[234],[237],[74],[240],[498],[229],[499],[230],[500],[501],[514],[510],[511],[525],[521],[520],[522],[552],[513],[515],[516],[64],[80],[492],[493],[212],[927],[503],  " + _
                                         "[700],[900],[915],[916],[917],[918],[919],[920],[921],[922],[923],[924],[925],[976],[926],[928],[962],[975],[523],[524],[53],[55],[56],[211],[494],[495],[496],[497])) AS PIVOTTABLE) AS CONCEPTOS " + _
                                         "ON M.TRAB_ID = CONCEPTOS.TRAB_ID  /*para traer DATO */  INNER JOIN (SELECT * FROM (SELECT TRAB_ID, CONCEPTO_ID, Dato FROM NomCalculohistorico " + _
                                         "WHERE ( INICIO >= '" + Format(FInicio.Date, "dd/MM/yyyy") + "' ) AND ( FINAL <='" + Format(FFin.Date, "dd/MM/yyyy") + "' )  and Centro_ID =" + Centro + " and tiponomina_id in(1) " + _
                                         "AND CONCEPTO_ID IN (51,50,30,14,6,9,7,8,52,54,57,58,59,60,61,63,201,204,78,231,232,79,77,282,503, 75,233,234,237,74,240,498,229,499,230,500,501,514,510,511,525,521,520,522,552,513,515,516,64,80,492,493,212,927, " + _
                                         "700,900,915,916,917,918,919,920,921,922,923,924,925,976,926,928,962,975,523,524,53,55,56,211,494,495,496,497)) AS CONCEPTOS  PIVOT (SUM(Conceptos.DATO)  FOR CONCEPTOS.CONCEPTO_ID " + _
                                         "IN ([51],[50],[30],[14],[6],[9],[7],[8],[52],[54],[57],[58],[59],[60],[61],[63],[201],[204],[78],[231],[232],[79],[77],[282], " + _
                                         "[75],[233],[234],[237],[74],[240],[498],[229],[499],[230],[500],[501],[514],[510],[511],[525],[521],[520],[522],[552],[513],[515],[516],[64],[80],[492],[493],[212],[927],[503], " + _
                                         "[700],[900],[915],[916],[917],[918],[919],[920],[921],[922],[923],[924],[925],[976],[926],[928],[962],[975],[523],[524],[53],[55],[56],[211],[494],[495],[496],[497]) ) AS PIVOTTABLE) AS DATOS " + _
                                         "ON M.TRAB_ID = DATOS.TRAB_ID where E.TARJETA_ID = '" + Empleado + "'", conn)
                comm.CommandType = CommandType.Text
                comm.CommandTimeout = 20000
                conn.Open()
                dr = comm.ExecuteReader

                If dr.IsClosed Then
                    MsgBox("Sin datos de Baja")
                End If
                'Try
                'cNomina = ObtenerNominaEmpleadoBajaSinNomina(Centro, Empleado, FInicial, FBaja)
                'cNomina = New clsNomina("CLIENTE", "PUESTO", Empleado, FInicio, "B", "", 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "")
                'Catch ex As Exception
                'End Try

                If dr.Read Then
                    'Dim c As clsNomina
                    Dim clabe As String
                    Dim banco As String
                    Dim tipoCaso As Int32

                    If IsDBNull(dr("BANCO")) Then
                        banco = ""
                    Else
                        banco = dr("BANCO")
                    End If

                    If IsDBNull(dr("CLABE")) Then
                        clabe = ""
                    Else
                        clabe = dr("CLABE")
                    End If
                    If IsDBNull(dr("TIPO CASO")) Then
                        tipoCaso = 1
                    Else
                        tipoCaso = dr("TIPO CASO")
                    End If
                    cNomina = New clsNomina(dr("CLIENTE"), dr("PUESTO"), dr("NO. EMPLEADO"), CDate(dr("FECHA ALTA")), dr("MOV"), dr("NOMBRE DE EMPLEADO"), tipoCaso, dr("SUELDO NOMINAL MENSUAL"), dr("FLEXIBLE BRUTO MENSUAL(PS/IAS)"), _
                                      CInt(dr("5 Ó 7%")), dr("SUELDO DIARIO"), dr("SDI"), dr("DÍAS LABORADOS"), dr("DÍAS RETROACTIVOS"), dr("DÍAS FALTAS"), dr("DIAS DE INC.ENF.GRAL."), dr("DIAS DE INC.MATERNIDAD"), dr("DIAS DE INC.RT O TRAYECTO"), dr("FLEXIBLE QUINCENAL"), _
                                      dr("BONO UNICO BR PS/IAS"), dr("BONO NEGOCIACION BR PS/IAS"), dr("BONO ESPECIAL BR PS/IAS"), dr("SUBSIDIO ENFERMEDAD GENERAL BR PS/IAS"), dr("SUBSIDIO ACCIDENTE TRABAJO BR PS/IAS"), dr("SUBSIDIO ACCIDENTE TRAYECTO BR PS/IAS"), dr("SUBSIDIO MATERNIDAD BR PS/IAS"), dr("BONO POR HORAS EXTRAS BR PS/IAS"), dr("RETROACTIVO BR PS/IAS"), dr("SUELDO"), _
                                      dr("RETROACTIVO SUELDO"), dr("REEMBOLSO INFONAVIT"), dr("PRIMA VACACIONAL ANIVERSARIO"), dr("SUBSIDIO EG 1-3 DIAS"), dr("SUBSIDIO EG 4 EN ADELANTE"), dr("AGUINALDO ANUAL"), dr("AGUINALDO FINIQUITO"), dr("VACACIONES FINIQUITO"), dr("PRIMA VACACIONAL FINIQUITO"), dr("INDEMNIZACION 3 MESES"), _
                                      dr("INDEMNIZACION 20 DIAS"), dr("NEGOCIACION GRAVADA"), dr("PRIMA ANTIGÜEDAD 12 DIAS"), dr("PTU"), dr("SUBSIDIO PARA EL EMPLEO PAGADO"), dr("PS DIAS LABORADOS"), dr("PS RETROACTIVO"), dr("IAS DIAS LABORADOS"), dr("IAS DIAS PENDIENTES"), dr("FLEXIBLE SUBSIDIOS INCAP."), _
                                      CDbl(dr("FLEXIBLE BONO")), dr("FLEXIBLE BONO NEGOCIACION"), dr("FLEXIBLE BONO ESPECIAL"), dr("TOTAL PERCEPCIONES"), dr("IMPUESTO RETENIDO"), dr("IMPUESTO INDEMNIZACIÓN"), dr("ISR AJUSTE ANNUAL 177"), dr("IMSS"), dr("DESC CREDITO INFONAVIT"), dr("AJUSTE DIFERENCIA CRED INFONAVIT"), _
                                      dr("OTROS DESCUENTOS"), dr("FONACOT"), dr("PRESTAMO PERSONAL"), dr("OTRAS DEDUCCIONES"), dr("DESCUENTO PENSION ALIMENTICIA"), dr("TOTAL DEDUCCIONES"), dr("NETO A PAGAR"), dr("IMSS EXCEDENTE PATRON"), dr("IMSS PRESTACIONES EN DINERO"), dr("IMSS PRESTACIONES EN ESPECIE"), _
                                      dr("IMSS IV PATRONAL"), dr("IMSS PROVISION GUARDERIA"), dr("IMSS RIESGO DE TRABAJO"), dr("PROVISION SAR"), dr("PROVISION INFONAVIT"), dr("IMSS CV PATRONAL"), dr("IMSS CUOTA FIJA"), dr("IMSS PATRONAL"), dr("IMSS OBRERO"), dr("ISN"), _
                                      dr("CARGA SOCIAL"), dr("COMISION NOMINA"), dr("IVA"), dr("TOTAL A FACTURAR"), dr("CUENTA"), clabe, banco)


                    If Not IsDBNull(dr("FECHA BAJA")) Then
                        'MessageBox.Show(dr("FECHA BAJA").ToString & " --> " & dr("NO. EMPLEADO"))
                        cNomina.FechaBaja = FBaja
                    End If
                Else ''28/03/2015 
                    cNomina = ObtenerNominaEmpleadoBajaSinNomina(Centro, Empleado, FInicial, FBaja)
                End If
                dr.Close()
            End Using
            Return cNomina
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            'Throw New ObtenerListaEdadesException("No se pudo obtener la Nomina del empleado dado de baja:  " + Empleado + "  " + ex.Message)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function
    Public Function ObtenerNominaEmpleadoBajaSinNomina(ByVal Centro As String, ByVal Empleado As String, ByVal FInicio As Date, ByVal FBaja As Date) As clsNomina
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Dim FFin As Date

            FFin = FechaUltimo(FInicio)

            Dim cNomina As clsNomina



            Using comm As New SqlCommand("SELECT TBDEPTO.DESCRIPCION AS 'CLIENTE', TBPUESTO.DESCRIPCION AS 'PUESTO', E.TARJETA_ID AS 'NO. EMPLEADO', CONVERT(VARCHAR(10), E.FECHAINGRESO, 103) AS 'FECHA ALTA', " + _
                                         "CASE WHEN M.Mov_ID='B' THEN CONVERT(VARCHAR(10), M.FechaMov, 103) END AS 'FECHA BAJA',M.Mov_ID as MOV,  E.PATERNO + ' ' + E.MATERNO + ' ' + E.NOMBRE AS 'NOMBRE DE EMPLEADO',  " + _
                                         "CONCEPTOS.[51] AS 'TIPO CASO', (M.SALARIO * 30) AS 'SUELDO NOMINAL MENSUAL', ISNULL(CONCEPTOS.[50], 0.00) AS 'FLEXIBLE BRUTO MENSUAL(PS/IAS)', ISNULL(CONCEPTOS.[53], 0) AS '5 Ó 7%',  " + _
                                         "M.SALARIO AS 'SUELDO DIARIO', M.INTEGRADOIMSS AS SDI, ISNULL(CONCEPTOS.[30], 0.00) AS 'DÍAS LABORADOS',  ISNULL(DATOS.[63], 0.00) AS 'DÍAS RETROACTIVOS',  " + _
                                         "ISNULL(CONCEPTOS.[14], 0.00) AS 'DÍAS FALTAS', ISNULL(DATOS.[6], 0.00) AS 'DIAS DE INC.ENF.GRAL.', ISNULL(DATOS.[9], 0.00) AS 'DIAS DE INC.MATERNIDAD',   " + _
                                         "ISNULL(DATOS.[7], 0.00)+ISNULL(DATOS.[8], 0.00) AS 'DIAS DE INC.RT O TRAYECTO', ISNULL(CONCEPTOS.[52], 0.00) AS 'FLEXIBLE QUINCENAL', ISNULL(CONCEPTOS.[54], 0.00) + ISNULL(CONCEPTOS.[64], 0.00)+ISNULL(CONCEPTOS.[80], 0.00) AS 'BONO UNICO BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[55], 0.00) AS 'BONO NEGOCIACION BR PS/IAS', ISNULL(CONCEPTOS.[56], 0.00) AS 'BONO ESPECIAL BR PS/IAS', ISNULL(CONCEPTOS.[57], 0.00) AS 'SUBSIDIO ENFERMEDAD GENERAL BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[58], 0.00) AS 'SUBSIDIO ACCIDENTE TRABAJO BR PS/IAS', ISNULL(CONCEPTOS.[59], 0.00) AS 'SUBSIDIO ACCIDENTE TRAYECTO BR PS/IAS', ISNULL(CONCEPTOS.[60], 0.00) AS 'SUBSIDIO MATERNIDAD BR PS/IAS', " + _
                                         "ISNULL(CONCEPTOS.[61], 0.00) AS 'BONO POR HORAS EXTRAS BR PS/IAS', ISNULL(CONCEPTOS.[63], 0.00) AS 'RETROACTIVO BR PS/IAS', ISNULL(CONCEPTOS.[201], 0.00) AS 'SUELDO', " + _
                                         "ISNULL(CONCEPTOS.[204], 0.00) AS 'RETROACTIVO SUELDO', ISNULL(CONCEPTOS.[212], 0.00) AS 'REEMBOLSO INFONAVIT', ISNULL(CONCEPTOS.[78], 0.00) AS 'PRIMA VACACIONAL ANIVERSARIO', " + _
                                         "ISNULL(CONCEPTOS.[231], 0.00) AS 'SUBSIDIO EG 1-3 DIAS', ISNULL(CONCEPTOS.[232], 0.00) AS 'SUBSIDIO EG 4 EN ADELANTE', ISNULL(CONCEPTOS.[79], 0.00) AS 'AGUINALDO ANUAL', " + _
                                         "ISNULL(CONCEPTOS.[77], 0.00) AS 'AGUINALDO FINIQUITO', ISNULL(CONCEPTOS.[282], 0.00) AS 'VACACIONES FINIQUITO', ISNULL(CONCEPTOS.[75], 0.00) AS 'PRIMA VACACIONAL FINIQUITO', " + _
                                         "ISNULL(CONCEPTOS.[233], 0.00) AS 'INDEMNIZACION 3 MESES', ISNULL(CONCEPTOS.[234], 0.00) AS 'INDEMNIZACION 20 DIAS', ISNULL(CONCEPTOS.[237], 0.00) AS 'NEGOCIACION GRAVADA', " + _
                                         "ISNULL(CONCEPTOS.[74], 0.00) AS 'PRIMA ANTIGÜEDAD 12 DIAS', ISNULL(CONCEPTOS.[211], 0.00) AS 'PTU', ISNULL(CONCEPTOS.[240], 0.00) AS 'SUBSIDIO PARA EL EMPLEO PAGADO', ISNULL(CONCEPTOS.[498], 0.00) AS 'PS DIAS LABORADOS', " + _
                                         "ISNULL(CONCEPTOS.[229], 0.00) AS 'PS RETROACTIVO', ISNULL(CONCEPTOS.[499], 0.00) AS 'IAS DIAS LABORADOS', ISNULL(CONCEPTOS.[230], 0.00) AS 'IAS DIAS PENDIENTES', ISNULL(CONCEPTOS.[494], 0.00) AS 'FLEXIBLE SUBSIDIOS INCAP.', " + _
                                         "ISNULL(CONCEPTOS.[495], 0.00)+ISNULL(CONCEPTOS.[492], 0.00)+ISNULL(CONCEPTOS.[493], 0.00) AS 'FLEXIBLE BONO', ISNULL(CONCEPTOS.[496], 0.00) AS 'FLEXIBLE BONO NEGOCIACION', " + _
                                         "ISNULL(CONCEPTOS.[497], 0.00) AS 'FLEXIBLE BONO ESPECIAL', ISNULL(CONCEPTOS.[500], 0.00) AS 'TOTAL PERCEPCIONES', ISNULL(CONCEPTOS.[501], 0.00) AS 'IMPUESTO RETENIDO', " + _
                                         "ISNULL(CONCEPTOS.[514], 0.00) AS 'IMPUESTO INDEMNIZACIÓN', ISNULL(CONCEPTOS.[503], 0.00) AS 'ISR AJUSTE ANNUAL 177', ISNULL(CONCEPTOS.[510], 0.00) AS 'IMSS', ISNULL(CONCEPTOS.[511], 0.00) AS 'DESC CREDITO INFONAVIT', " + _
                                         "ISNULL(CONCEPTOS.[525], 0.00) AS 'AJUSTE DIFERENCIA CRED INFONAVIT', ISNULL(CONCEPTOS.[521], 0.00) +ISNULL(CONCEPTOS.[513], 0.00) +ISNULL(CONCEPTOS.[515], 0.00)+ISNULL(CONCEPTOS.[516], 0.00) AS 'OTROS DESCUENTOS', " + _
                                         "ISNULL(CONCEPTOS.[520], 0.00) AS 'FONACOT', ISNULL(CONCEPTOS.[523], 0.00) AS 'PRESTAMO PERSONAL', ISNULL(CONCEPTOS.[524], 0.00) +ISNULL(CONCEPTOS.[552], 0.00) AS 'OTRAS DEDUCCIONES', " + _
                                         "ISNULL(CONCEPTOS.[522], 0.00) AS 'DESCUENTO PENSION ALIMENTICIA', ISNULL(CONCEPTOS.[700], 0.00) AS 'TOTAL DEDUCCIONES', ISNULL(CONCEPTOS.[900], 0.00) AS 'NETO A PAGAR', ISNULL(CONCEPTOS.[915], 0.00) AS 'IMSS EXCEDENTE PATRON', " + _
                                         "ISNULL(CONCEPTOS.[916], 0.00) AS 'IMSS PRESTACIONES EN DINERO', ISNULL(CONCEPTOS.[917], 0.00) AS 'IMSS PRESTACIONES EN ESPECIE', ISNULL(CONCEPTOS.[918], 0.00) AS 'IMSS IV PATRONAL', " + _
                                         "ISNULL(CONCEPTOS.[919], 0.00) AS 'IMSS PROVISION GUARDERIA', ISNULL(CONCEPTOS.[920], 0.00) AS 'IMSS RIESGO DE TRABAJO',ISNULL(CONCEPTOS.[921], 0.00) AS 'PROVISION SAR', ISNULL(CONCEPTOS.[922], 0.00) AS 'PROVISION INFONAVIT', " + _
                                         "ISNULL(CONCEPTOS.[923], 0.00) AS 'IMSS CV PATRONAL', ISNULL(CONCEPTOS.[924], 0.00) AS 'IMSS CUOTA FIJA', ISNULL(CONCEPTOS.[925], 0.00) AS 'IMSS PATRONAL', ISNULL(CONCEPTOS.[927], 0.00) AS 'IMSS OBRERO', " + _
                                         "ISNULL(CONCEPTOS.[976], 0.00) AS 'ISN', ISNULL(CONCEPTOS.[926], 0.00) AS 'CARGA SOCIAL', ISNULL(CONCEPTOS.[928], 0.00) AS 'COMISION NOMINA', ISNULL(CONCEPTOS.[962], 0.00) AS 'IVA',  ISNULL(CONCEPTOS.[975], 0.00) AS 'TOTAL A FACTURAR', " + _
                                         "(char(39)+E.CUENTADEPOSITO) AS CUENTA, (char(39)+E.CLABE)  AS CLABE, CASE WHEN E.BANCODEPOSITO=0 THEN ' ' WHEN E.BANCODEPOSITO=1 THEN 'BANCOMER' WHEN E.BANCODEPOSITO=2 THEN 'BANAMEX' WHEN E.BANCODEPOSITO=3 THEN 'COMERMEX' " + _
                                         "WHEN E.BANCODEPOSITO=4 THEN 'SERFIN' WHEN E.BANCODEPOSITO=5 THEN 'BANOBRAS' WHEN E.BANCODEPOSITO=6 THEN 'ATLANTCO'  WHEN E.BANCODEPOSITO=7 THEN 'CITIBANK'  WHEN E.BANCODEPOSITO=8 THEN  'CONFIA'  WHEN E.BANCODEPOSITO=9 THEN  'SANTANDER' " + _
                                         "WHEN E.BANCODEPOSITO=10 THEN 'MEXICANO'  WHEN E.BANCODEPOSITO=11 THEN  'IXE' WHEN E.BANCODEPOSITO=12 THEN 'FIN COMUN' WHEN E.BANCODEPOSITO=13 THEN 'SCOTIABANK'  WHEN E.BANCODEPOSITO=14 THEN 'BANORTE'  WHEN E.BANCODEPOSITO=15 THEN  'INBURSA' " + _
                                         "WHEN E.BANCODEPOSITO=16 THEN 'HSBC'  WHEN E.BANCODEPOSITO=17 THEN  'BANREGIO'  WHEN E.BANCODEPOSITO=18 THEN 'BANCO AZTECA'  WHEN E.BANCODEPOSITO=21 THEN 'BITAL' WHEN E.BANCODEPOSITO=30 THEN 'BBVA'  END AS BANCO " + _
                                         "FROM  EMPLEADO AS E INNER JOIN MOVIMIENTO AS M ON E.TRAB_ID = M.TRAB_ID INNER JOIN (SELECT  TRAB_ID, MAX(PTR) AS PTR FROM   MOVIMIENTO AS MOVIMIENTO_1 WHERE ( FECHAMOV <= '" + Format(FFin.Date, "dd/MM/yyyy") + "' ) GROUP BY TRAB_ID) AS LM ON M.TRAB_ID = LM.TRAB_ID AND M.PTR = LM.PTR  " + _
                                         "INNER JOIN TBCENTROS  ON M.CENTRO_ID = TBCENTROS.CENTRO_ID INNER JOIN TBREGPAT  ON TBCENTROS.REGPAT_ID = TBREGPAT.REGPAT_ID INNER JOIN TBPUESTO  ON M.PUESTO_ID = TBPUESTO.PUESTO_ID INNER JOIN TBDEPTO  ON M.DEPTO_ID = TBDEPTO.DEPTO_ID " + _
                                         "INNER JOIN ANTIGUEDAD ON E.TRAB_ID = ANTIGUEDAD.TRAB_ID INNER JOIN (SELECT  ANTIGEMPL.TRAB_ID, TBFACTORINTEGRA.VACACIONES, TBFACTORINTEGRA.AGUINALDO, TBFACTORINTEGRA.PRIMA FROM TBFACTORINTEGRA  " + _
                                         "INNER JOIN (SELECT ANTFACT.TRAB_ID, MAX(TBFI.ANTIGUEDAD) AS ANTIG, ANTFACT.TIPOEMPLEADO_ID  FROM  TBFACTORINTEGRA AS TBFI INNER JOIN (SELECT  ANT.TRAB_ID, ANT.ANO + CAST(ANT.DIAS AS MONEY) / 1000 AS ANTIGUEDAD, " + _
                                         "MOVIMIENTO.TIPOEMPLEADO_ID FROM ANTIGUEDAD AS ANT INNER JOIN (SELECT  TRAB_ID, MAX(PTR) AS PTR FROM MOVIMIENTO AS MOVIMIENTO_2  WHERE ( FECHAMOV <= '" + Format(FFin.Date, "dd/MM/yyyy") + "' ) GROUP  BY TRAB_ID) AS LM_1 ON ANT.TRAB_ID = LM_1.TRAB_ID " + _
                                         "INNER JOIN MOVIMIENTO ON LM_1.TRAB_ID = MOVIMIENTO.TRAB_ID  AND LM_1.PTR = MOVIMIENTO.PTR) AS ANTFACT ON TBFI.ANTIGUEDAD <= ANTFACT.ANTIGUEDAD AND TBFI.TIPOEMPLEADO_ID = ANTFACT.TIPOEMPLEADO_ID " + _
                                         "GROUP  BY ANTFACT.TRAB_ID, ANTFACT.TIPOEMPLEADO_ID) AS ANTIGEMPL  ON TBFACTORINTEGRA.TIPOEMPLEADO_ID = ANTIGEMPL.TIPOEMPLEADO_ID AND TBFACTORINTEGRA.ANTIGUEDAD = ANTIGEMPL.ANTIG) AS FACTEMPL ON M.TRAB_ID = FACTEMPL.TRAB_ID " + _
                                         "INNER JOIN (SELECT * FROM (SELECT TRAB_ID, CONCEPTO_ID, IMPORTE FROM NomMovimientos WHERE ( Fecha >= '" + Format(FInicio.Date, "dd/MM/yyyy") + "' ) AND ( Fecha <= '" + Format(FFin.Date, "dd/MM/yyyy") + "')  and tiponomina_id in (1) " + _
                                         "AND CONCEPTO_ID IN (51,50,30,14,6,9,7,8,52,54,57,58,59,60,61,63,201,204,78,231,232,79,77,282,503, 75,233,234,237,74,240,498,229,499,230,500,501,514,510,511,525,521,520,522,552,513,515,516,64,80,492,493,212,927, " + _
                                         "700,900,915,916,917,918,919,920,921,922,923,924,925,976,926,928,962,975,523,524,53,55,56,211,494,495,496,497)) AS CONCEPTOS  PIVOT (SUM(CONCEPTOS.IMPORTE) FOR CONCEPTOS.CONCEPTO_ID " + _
                                         "IN ([51],[50],[30],[14],[6],[9],[7],[8],[52],[54],[57],[58],[59],[60],[61],[63],[201],[204],[78],[231],[232],[79],[77],[282],  " + _
                                         "[75],[233],[234],[237],[74],[240],[498],[229],[499],[230],[500],[501],[514],[510],[511],[525],[521],[520],[522],[552],[513],[515],[516],[64],[80],[492],[493],[212],[927],[503],  " + _
                                         "[700],[900],[915],[916],[917],[918],[919],[920],[921],[922],[923],[924],[925],[976],[926],[928],[962],[975],[523],[524],[53],[55],[56],[211],[494],[495],[496],[497])) AS PIVOTTABLE) AS CONCEPTOS " + _
                                         "ON M.TRAB_ID = CONCEPTOS.TRAB_ID  /*para traer DATO */  INNER JOIN (SELECT * FROM (SELECT TRAB_ID, CONCEPTO_ID, Dato FROM NomMovimientos " + _
                                         "WHERE ( Fecha >= '" + Format(FInicio.Date, "dd/MM/yyyy") + "' ) AND ( Fecha <='" + Format(FFin.Date, "dd/MM/yyyy") + "' )  and tiponomina_id in (1) " + _
                                         "AND CONCEPTO_ID IN (51,50,30,14,6,9,7,8,52,54,57,58,59,60,61,63,201,204,78,231,232,79,77,282,503, 75,233,234,237,74,240,498,229,499,230,500,501,514,510,511,525,521,520,522,552,513,515,516,64,80,492,493,212,927, " + _
                                         "700,900,915,916,917,918,919,920,921,922,923,924,925,976,926,928,962,975,523,524,53,55,56,211,494,495,496,497)) AS CONCEPTOS  PIVOT (SUM(Conceptos.DATO)  FOR CONCEPTOS.CONCEPTO_ID " + _
                                         "IN ([51],[50],[30],[14],[6],[9],[7],[8],[52],[54],[57],[58],[59],[60],[61],[63],[201],[204],[78],[231],[232],[79],[77],[282], " + _
                                         "[75],[233],[234],[237],[74],[240],[498],[229],[499],[230],[500],[501],[514],[510],[511],[525],[521],[520],[522],[552],[513],[515],[516],[64],[80],[492],[493],[212],[927],[503], " + _
                                         "[700],[900],[915],[916],[917],[918],[919],[920],[921],[922],[923],[924],[925],[976],[926],[928],[962],[975],[523],[524],[53],[55],[56],[211],[494],[495],[496],[497]) ) AS PIVOTTABLE) AS DATOS " + _
                                        "ON M.TRAB_ID = DATOS.TRAB_ID where E.TARJETA_ID = '" + Empleado + "'", conn)
                comm.CommandType = CommandType.Text
                comm.CommandTimeout = 20000
                conn.Open()
                dr = comm.ExecuteReader
                While dr.Read
                    'Dim c As clsNomina
                    Dim clabe As String
                    Dim banco As String
                    Dim tipoCaso As Int32

                    If IsDBNull(dr("BANCO")) Then
                        banco = ""
                    Else
                        banco = dr("BANCO")
                    End If

                    If IsDBNull(dr("CLABE")) Then
                        clabe = ""
                    Else
                        clabe = dr("CLABE")
                    End If
                    If IsDBNull(dr("TIPO CASO")) Then
                        tipoCaso = 1
                    Else
                        tipoCaso = dr("TIPO CASO")
                    End If
                    cNomina = New clsNomina(dr("CLIENTE"), dr("PUESTO"), dr("NO. EMPLEADO"), CDate(dr("FECHA ALTA")), dr("MOV"), dr("NOMBRE DE EMPLEADO"), tipoCaso, dr("SUELDO NOMINAL MENSUAL"), dr("FLEXIBLE BRUTO MENSUAL(PS/IAS)"), _
                                      CInt(dr("5 Ó 7%")), dr("SUELDO DIARIO"), dr("SDI"), dr("DÍAS LABORADOS"), dr("DÍAS RETROACTIVOS"), dr("DÍAS FALTAS"), dr("DIAS DE INC.ENF.GRAL."), dr("DIAS DE INC.MATERNIDAD"), dr("DIAS DE INC.RT O TRAYECTO"), dr("FLEXIBLE QUINCENAL"), _
                                      dr("BONO UNICO BR PS/IAS"), dr("BONO NEGOCIACION BR PS/IAS"), dr("BONO ESPECIAL BR PS/IAS"), dr("SUBSIDIO ENFERMEDAD GENERAL BR PS/IAS"), dr("SUBSIDIO ACCIDENTE TRABAJO BR PS/IAS"), dr("SUBSIDIO ACCIDENTE TRAYECTO BR PS/IAS"), dr("SUBSIDIO MATERNIDAD BR PS/IAS"), dr("BONO POR HORAS EXTRAS BR PS/IAS"), dr("RETROACTIVO BR PS/IAS"), dr("SUELDO"), _
                                      dr("RETROACTIVO SUELDO"), dr("REEMBOLSO INFONAVIT"), dr("PRIMA VACACIONAL ANIVERSARIO"), dr("SUBSIDIO EG 1-3 DIAS"), dr("SUBSIDIO EG 4 EN ADELANTE"), dr("AGUINALDO ANUAL"), dr("AGUINALDO FINIQUITO"), dr("VACACIONES FINIQUITO"), dr("PRIMA VACACIONAL FINIQUITO"), dr("INDEMNIZACION 3 MESES"), _
                                      dr("INDEMNIZACION 20 DIAS"), dr("NEGOCIACION GRAVADA"), dr("PRIMA ANTIGÜEDAD 12 DIAS"), dr("PTU"), dr("SUBSIDIO PARA EL EMPLEO PAGADO"), dr("PS DIAS LABORADOS"), dr("PS RETROACTIVO"), dr("IAS DIAS LABORADOS"), dr("IAS DIAS PENDIENTES"), dr("FLEXIBLE SUBSIDIOS INCAP."), _
                                      CDbl(dr("FLEXIBLE BONO")), dr("FLEXIBLE BONO NEGOCIACION"), dr("FLEXIBLE BONO ESPECIAL"), dr("TOTAL PERCEPCIONES"), dr("IMPUESTO RETENIDO"), dr("IMPUESTO INDEMNIZACIÓN"), dr("ISR AJUSTE ANNUAL 177"), dr("IMSS"), dr("DESC CREDITO INFONAVIT"), dr("AJUSTE DIFERENCIA CRED INFONAVIT"), _
                                      dr("OTROS DESCUENTOS"), dr("FONACOT"), dr("PRESTAMO PERSONAL"), dr("OTRAS DEDUCCIONES"), dr("DESCUENTO PENSION ALIMENTICIA"), dr("TOTAL DEDUCCIONES"), dr("NETO A PAGAR"), dr("IMSS EXCEDENTE PATRON"), dr("IMSS PRESTACIONES EN DINERO"), dr("IMSS PRESTACIONES EN ESPECIE"), _
                                      dr("IMSS IV PATRONAL"), dr("IMSS PROVISION GUARDERIA"), dr("IMSS RIESGO DE TRABAJO"), dr("PROVISION SAR"), dr("PROVISION INFONAVIT"), dr("IMSS CV PATRONAL"), dr("IMSS CUOTA FIJA"), dr("IMSS PATRONAL"), dr("IMSS OBRERO"), dr("ISN"), _
                                      dr("CARGA SOCIAL"), dr("COMISION NOMINA"), dr("IVA"), dr("TOTAL A FACTURAR"), dr("CUENTA"), clabe, banco)

                    If Not IsDBNull(dr("FECHA BAJA")) Then
                        'MessageBox.Show(dr("FECHA BAJA").ToString & " --> " & dr("NO. EMPLEADO"))
                        cNomina.FechaBaja = FBaja
                    End If
                End While
                dr.Close()
            End Using
            Return cNomina
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo obtener la Nomina del empleado dado de baja:  " + Empleado + "  " + ex.Message)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function


    'Public Function ObtieneEdades(ByVal Centro As String, ByVal FInicio As Date, ByVal FFin As Date) As ArrayList
    '    Dim conn As New SqlConnection(Me.m_Conn)
    '    Dim dr As SqlDataReader
    '    Try
    '        Dim arrEmpEdades As New ArrayList
    '        Using comm As New SqlCommand("select  E.Tarjeta_ID,E.FechaNacimiento,E.Sexo_IDa, E.CURP	from Empleado E inner join NOMCALCULOHISTORICO C on C.Trab_ID=E.Trab_ID	where C.Centro_ID = " + Centro + _
    '                                     " and Fecha  BETWEEN '" + Format(FInicio.Date, "dd/MM/yyyy") + "' AND '" + Format(FFin.Date, "dd/MM/yyyy") + "' group by E.Tarjeta_ID,E.FechaNacimiento,E.Sexo_IDa,E.CURP order by E.Tarjeta_ID", conn)
    '            '" and Fecha  BETWEEN '" + Format(FInicio.Date, "MM/dd/yyyy") + "' AND '" + Format(FFin.Date, "MM/dd/yyyy") + "' group by E.Tarjeta_ID,E.FechaNacimiento,E.Sexo_IDa order by E.Tarjeta_ID", conn)
    '            comm.CommandType = CommandType.Text
    '            conn.Open()
    '            dr = comm.ExecuteReader
    '            While dr.Read
    '                Dim c As clsEmpleadoEdad
    '                c = New clsEmpleadoEdad(dr("Tarjeta_ID"), dr("FechaNacimiento"), dr("Sexo_IDa"), dr("CURP"))
    '                c.SeguroGMM = Funciones.ObtieneSeguroVida(c)
    '                arrEmpEdades.Add(c)
    '            End While
    '            dr.Close()
    '        End Using
    '        Return arrEmpEdades
    '    Catch ex As Exception
    '        Try
    '            dr.Close()
    '        Catch ex1 As Exception
    '        End Try
    '        Throw New ObtenerListaEdadesException("No se pudo obtener la lista de edades")
    '    Finally
    '        Try
    '            conn.Close()
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            conn.Dispose()
    '        Catch ex As Exception
    '        End Try
    '    End Try
    'End Function

    Public Function ObtieneEdadesPorPersona(ByVal TarjetaID As String, ByVal centro As String, ByVal FechaI As Date, ByVal FechaF As Date) As clsEmpleadoEdad
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Dim c As clsEmpleadoEdad
        'MsgBox("Obteniendo edad por persona Tarjeta ID :" + TarjetaID)
        'mensajelog = mensajelog + "Obteniendo edad por persona Tarjeta ID : " + TarjetaID + " " + Now.TimeOfDay.ToString + vbCrLf
        'frmNomina.txtlog.Text = Me.mensajelog
        Try
            Using comm As New SqlCommand("select top 1 E.Tarjeta_ID,E.FechaNacimiento,E.Sexo_IDa, E.CURP, M.Mov_ID, M.FechaMov, N.Importe as TipoCaso,NN.Importe as Flexible from Empleado E " + _
                                     "inner join Movimiento M on M.Trab_ID=E.Trab_ID and M.Centro_ID=  " + centro + " " + _
                                     "left join NomCalculoHistorico N on N.Trab_ID=E.Trab_ID and N.Centro_ID=" + centro + " and N.Concepto_ID=51 " + _
                                     "left join NomCalculoHistorico NN on NN.Trab_ID=E.Trab_ID and NN.Centro_ID=" + centro + " and NN.Concepto_ID=50 " + _
                                     "where E.Tarjeta_ID='" + TarjetaID + "' order by NN.Inicio desc, N.Inicio desc, M.FechaMov desc", conn)
                '"left join NomCalculoHistorico N on N.Trab_ID=E.Trab_ID and N.Centro_ID=" + centro + " and N.Concepto_ID=51 and N.Fecha between '" + Format(FechaI.Date, "dd/MM/yyyy") + "' and '" + Format(FechaF.Date, "dd/MM/yyyy") + "' " + _
                'Using comm As New SqlCommand("select top 1 E.Tarjeta_ID,E.FechaNacimiento,E.Sexo_IDa, E.CURP, M.Mov_ID, M.FechaMov from Empleado E inner join Movimiento M on M.Trab_ID=E.Trab_ID and M.Centro_ID= " + centro + _
                '                         " where E.Tarjeta_ID=" + TarjetaID + "order by FechaMov desc", conn)
                comm.CommandType = CommandType.Text
                comm.CommandTimeout = 20000
                conn.Open()
                dr = comm.ExecuteReader

                While dr.Read
                    Dim tipoCaso As Int32
                    Dim Flexible As Double
                    If IsDBNull(dr("TipoCaso")) Then
                        tipoCaso = 1
                        c = ObtieneEdadesPorPersonaBajaSinNomina(TarjetaID, centro, FechaI, FechaF)
                    Else
                        tipoCaso = CInt(dr("TipoCaso"))
                        If IsDBNull(dr("Flexible")) Then
                            Flexible = 0.0
                        Else
                            Flexible = CDbl(dr("Flexible"))
                        End If
                        ''NUEVO
                        If IsDBNull(dr("Tarjeta_ID")) Then
                            MsgBox("No es posible continuar revise el dato: (Tarjeta de usuario) para el usuario con el CURP" + (dr("CURP")))
                        End If

                        If IsDBNull(dr("CURP")) Then
                            MsgBox("No es posible continuar revise el dato: (CURP) para el usuario " + (dr("Tarjeta_ID")))
                        End If

                        If IsDBNull(dr("Mov_ID")) Then
                            MsgBox("No es posible continuar revise el dato: (Mov_ID) para el usuario " + (dr("Tarjeta_ID")))
                        End If

                        If IsDBNull(dr("FechaMov")) Then
                            MsgBox("No es posible continuar revise el dato: (FechaMov) para el usuario " + (dr("Tarjeta_ID")))
                        End If

                        'If tipoCaso = "" Or " " Then
                        '    MsgBox("No es posible continuar revise el Tipo de Caso  para el usuario " + (dr("Tarjeta_ID")))
                        'End If

                        'If Flexible = "" Or " " Then
                        '    MsgBox("No es posible continuar revise el dato Flexible  para el usuario " + (dr("Tarjeta_ID")))
                        'End If

                        '' NUEVO
                        c = New clsEmpleadoEdad(dr("Tarjeta_ID"), ConvierteFechaNacDeCURP(dr("CURP")), ConvierteSexoDeCURP(dr("CURP")), dr("CURP"), dr("Mov_ID"), CDate(dr("FechaMov")), tipoCaso, Flexible)
                        c.SeguroGMM = Funciones.ObtieneSeguroVida(c)
                    End If
                    'c = New clsEmpleadoEdad(dr("Tarjeta_ID"), dr("FechaNacimiento"), dr("Sexo_IDa"), dr("CURP"))
                End While
                dr.Close()
            End Using
            Return c
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo obtener la edad del empleado: " & TarjetaID)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function
    Public Function ObtieneEdadesPorPersonaBajaSinNomina(ByVal TarjetaID As String, ByVal centro As String, ByVal FechaI As Date, ByVal FechaF As Date) As clsEmpleadoEdad
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Dim c As clsEmpleadoEdad
        Try
            Using comm As New SqlCommand("select top 1 E.Tarjeta_ID,E.FechaNacimiento,E.Sexo_IDa, E.CURP, M.Mov_ID, M.FechaMov, N.Importe as TipoCaso,NN.Importe as Flexible from Empleado E " + _
                                     "inner join Movimiento M on M.Trab_ID=E.Trab_ID and M.Centro_ID=  " + centro + " " + _
                                     "inner join NomCalculo N on N.Trab_ID=E.Trab_ID and N.Centro_ID=" + centro + " and N.Concepto_ID=51 and N.Fecha between '" + Format(FechaI.Date, "dd/MM/yyyy") + "' and '" + Format(FechaF.Date, "dd/MM/yyyy") + "' " + _
                                     "inner join NomCalculo NN on NN.Trab_ID=E.Trab_ID and NN.Centro_ID=" + centro + " and NN.Concepto_ID=50 and NN.Fecha between '" + Format(FechaI.Date, "dd/MM/yyyy") + "' and '" + Format(FechaF.Date, "dd/MM/yyyy") + "' " + _
                                         "where E.Tarjeta_ID=" + TarjetaID + " order by NN.Inicio desc, N.Inicio desc, M.FechaMov desc", conn)
                'Using comm As New SqlCommand("select top 1 E.Tarjeta_ID,E.FechaNacimiento,E.Sexo_IDa, E.CURP, M.Mov_ID, M.FechaMov from Empleado E inner join Movimiento M on M.Trab_ID=E.Trab_ID and M.Centro_ID= " + centro + _
                '                         " where E.Tarjeta_ID=" + TarjetaID + "order by FechaMov desc", conn)
                comm.CommandType = CommandType.Text
                comm.CommandTimeout = 20000
                conn.Open()
                dr = comm.ExecuteReader

                While dr.Read
                    Dim tipoCaso As Int32
                    Dim Flexible As Double
                    If IsDBNull(dr("TipoCaso")) Then
                        tipoCaso = 1
                    Else
                        tipoCaso = CInt(dr("TipoCaso"))
                        If IsDBNull(dr("Flexible")) Then
                            Flexible = 0.0
                        Else
                            Flexible = CDbl(dr("Flexible"))
                        End If
                    End If
                    'c = New clsEmpleadoEdad(dr("Tarjeta_ID"), dr("FechaNacimiento"), dr("Sexo_IDa"), dr("CURP"))
                    c = New clsEmpleadoEdad(dr("Tarjeta_ID"), ConvierteFechaNacDeCURP(dr("CURP")), ConvierteSexoDeCURP(dr("CURP")), dr("CURP"), dr("Mov_ID"), CDate(dr("FechaMov")), tipoCaso, Flexible)
                    c.SeguroGMM = Funciones.ObtieneSeguroVida(c)
                End While
                dr.Close()
            End Using
            Return c
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo obtener la edad del empleado(sin nomina): " & TarjetaID)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function
    Public Function ObtienePRT(ByVal Centro As String) As clsRT
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Dim c As clsRT
            Using comm As New SqlCommand("select top 1 C.Centro_ID,T.RegPat_ID,t.Ano,t.Mes,t.RT from TBCentros C inner join TBRiesgoTrabajo T on C.RegPat_ID=T.RegPat_ID where Centro_ID= " + Centro + _
                                         " order by Ano desc,Mes desc", conn)
                comm.CommandType = CommandType.Text
                conn.Open()
                dr = comm.ExecuteReader
                While dr.Read
                    c = New clsRT(dr("Centro_ID"), dr("RegPat_ID"), dr("Ano"), dr("Mes"), dr("RT"))
                End While
                dr.Close()
            End Using
            Return c
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo obtener el PRT")
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function

    Public Class ObtenerListaEdadesException
        Inherits ApplicationException
        Public Sub New(ByVal strMessage As String)
            MyBase.New(strMessage)
        End Sub
    End Class

    Public Function pReindexar()
        Dim conn As New SqlConnection(Me.m_Conn)
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
            MessageBox.Show("No se pudo obtener la lista de la Nomina... " + ex.Message)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function
End Class
