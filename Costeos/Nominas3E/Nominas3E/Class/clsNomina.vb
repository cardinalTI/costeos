Public Class clsNomina
    Private m_Cliente As String
    Private m_Puesto As String
    Private m_Empleado As String
    Private m_FechaAlta As Date
    Private m_FechaBaja As Nullable(Of Date)
    Private m_Mov As String
    Private m_Nombre As String
    Private m_TipoCaso As Int32
    Private m_SueldoNominalMensual As Double
    Private m_FlexBrutoMensual As Double
    'D1 FLOAT,
    'D2 FLOAT,
    Private m_D5o7 As Double
    Private m_SueldoDiario As Double
    Private m_SDI As Double
    Private m_DiasLaborables As Int32
    Private m_DiasRetroactivos As Int32
    Private m_DiasFalta As Int32
    Private m_DiasIncEnfGral As Int32
    Private m_DiasIncMaternidad As Int32
    Private m_DiasIncTrayecto As Int32
    Private m_FlexQuincenal As Double
    Private m_BonoUnico As Double
    Private m_BonoNegociacion As Double
    Private m_BonoEspecial As Double
    Private m_SubEnfermedadGral As Double
    Private m_SubAccidenteTrabajo As Double
    Private m_SubAccidenteTrayecto As Double
    Private m_SubMaternidad As Double
    Private m_BonoHrsExtras As Double
    Private m_Retroactivo As Double
    Private m_Sueldo As Double
    Private m_RetroactivoSueldo As Double
    Private m_ReembolsoInfonavit As Double
    Private m_PrimaVacacionalAni As Double
    Private m_SubEg1_3Dias As Double
    Private m_SubEg4_Adelante As Double
    Private m_AguinaldoAnual As Double
    Private m_AguinaldoFiniquito As Double
    Private m_VacacionesFiniquito As Double
    Private m_PrimaVacacionalFiniquito As Double
    Private m_Indemnizacion3Meses As Double
    Private m_Indemnizacion20Dias As Double
    Private m_NegociacionGravada As Double
    Private m_PrimaAnt12Dias As Double
    Private m_PTU As Double
    Private m_SubsidioEmpleoPagado As Double
    Private m_PsDiasLaborados As Double
    Private m_PsRetroactivo As Double
    Private m_IasDiasLaborados As Int32
    Private m_IasDiasPendientes As Int32
    Private m_FlexSubsidiosIncap As Double
    Private m_FlexBono As Double
    Private m_FlexBonoNegociacion As Double
    Private m_FlexBonoEspecial As Double
    Private m_TotalPercepciones As Double
    Private m_ImpuestoRetenido As Double
    Private m_ImpuestoIndemnizacion As Double
    Private m_ISR_AjusteAnual177 As Double
    Private m_IMSS As Double
    Private m_DescCreditoInfonavit As Double
    Private m_AjusteDifCredInfonavit As Double
    Private m_OtrosDescuentos As Double
    Private m_Fonacot As Double
    Private m_PrestamoPersonal As Double
    Private m_OtrasDeducciones As Double
    Private m_DescPensionAlimenticia As Double
    Private m_TotalDeducciones As Double
    Private m_NetoAPagar As Double
    Private m_ImssExcedentePatron As Double
    Private m_ImssPrestacionesDinero As Double
    Private m_ImssPrestacionesEspecie As Double
    Private m_ImssIVPatronal As Double
    Private m_ImssProvisionGuarderia As Double
    Private m_ImssRiesgoTrabajo As Double
    Private m_ProvisionSAR As Double
    Private m_ProvisionInfonavit As Double
    Private m_ImssCVPatronal As Double
    Private m_ImssCuotaFija As Double
    Private m_ImssPatronal As Double
    Private m_ImssObrero As Double
    Private m_ISN As Double
    Private m_CargaSocial As Double
    Private m_ComisionNomina As Double
    Private m_IVA As Double
    Private m_TotalFacturar As Double
    Private m_Cuenta As String
    Private m_Clabe As String
    Private m_Banco As String

    
    Private m_TarjetaId As String
    Private m_FechaNacimiento As Date
    Private m_Sexo As Int32 '1-Mujer 0-Hombre
    Private m_SeguroGMM As Nullable(Of Double)
    Private m_Curp As String
    Private m_Movi As String 'Ultimo movimiento A-Alta, B-Baja, R-Reingreso
    Private m_FecMov As Date 'Fecha ultimo movimiento
    Private m_TipoCaso2 As Int32 'Tipo Caso
    Private m_Flexible As Double 'Flexible Bruto que se saca de la ultima quincena

    Public Property TarjetaId() As String
        Get
            Return Me.m_TarjetaId
        End Get
        Set(value As String)
            Me.m_TarjetaId = value
        End Set
    End Property

    'Private m_FechaNacimiento As Date
    Public Property fechanacimiento() As Date
        Get
            Return Me.m_FechaNacimiento
        End Get
        Set(value As Date)
            Me.m_FechaNacimiento = value
        End Set
    End Property

    'Private m_Sexo As Int32 '1-Mujer 0-Hombre
    Public Property sexo() As Int32
        Get
            Return Me.m_Sexo
        End Get
        Set(value As Int32)
            Me.m_Sexo = value
        End Set
    End Property
    'Private m_SeguroGMM As Nullable(Of Double)
    Public Property segurogmm() As Nullable(Of Double)
        Get
            Return Me.m_SeguroGMM
        End Get
        Set(value As Nullable(Of Double))
            Me.m_SeguroGMM = value
        End Set
    End Property
    'Private m_Curp As String
    Public Property curp() As String
        Get
            Return Me.m_Curp
        End Get
        Set(value As String)
            Me.m_Curp = value
        End Set
    End Property
    'Private m_Movi As String 'Ultimo movimiento A-Alta, B-Baja, R-Reingreso
    Public Property movi() As String
        Get
            Return Me.m_Movi
        End Get
        Set(value As String)
            Me.m_Movi = value
        End Set
    End Property
    'Private m_FecMov As Date 'Fecha ultimo movimiento
    Public Property fecmov() As Date
        Get
            Return Me.m_FecMov
        End Get
        Set(value As Date)
            Me.m_FecMov = value
        End Set
    End Property
    'Private m_TipoCaso2 As Int32 'Tipo Caso
    Public Property tipocaso2() As Int32
        Get
            Return Me.m_TipoCaso2
        End Get
        Set(value As Int32)
            Me.m_TipoCaso2 = value
        End Set
    End Property
    'Private m_Flexible As Double 'Flexible Bruto que se saca de la ultima quincena
    Public Property flexible() As Double
        Get
            Return Me.m_Flexible
        End Get
        Set(value As Double)
            Me.m_Flexible = value
        End Set
    End Property

    Public Property Bono_Especial() As Double
        Get
            Return Me.m_BonoEspecial
        End Get
        Set(value As Double)
            Me.m_BonoEspecial = value
        End Set
    End Property

    Public Property Bono_Unico As Double
        Get
            Return Me.m_BonoUnico
        End Get
        Set(value As Double)
            Me.m_BonoUnico = value
        End Set
    End Property

    Public Property Bono_Negociacion As Double
        Get
            Return Me.m_BonoNegociacion
        End Get
        Set(value As Double)
            Me.m_BonoNegociacion = value
        End Set
    End Property


    Public ReadOnly Property Cliente() As String
        Get
            Return Me.m_Cliente
        End Get
    End Property
    Public ReadOnly Property Puesto() As String
        Get
            Return Me.m_Puesto
        End Get
    End Property
    Public ReadOnly Property Empleado() As String
        Get
            Return Me.m_Empleado
        End Get
    End Property
    Public ReadOnly Property FechaAlta() As Date
        Get
            Return Me.m_FechaAlta
        End Get
    End Property
    Public ReadOnly Property Mov As String
        Get
            Return Me.m_Mov
        End Get
    End Property
    Public Property FechaBaja() As Nullable(Of Date)
        Get
            Return Me.m_FechaBaja
        End Get
        Set(ByVal value As Nullable(Of Date))
            Me.m_FechaBaja = value
        End Set
    End Property
    
    Public ReadOnly Property Nombre() As String
        Get
            Return Me.m_Nombre
        End Get
    End Property
    Public ReadOnly Property TipoCaso() As Int32
        Get
            Return Me.m_TipoCaso
        End Get
    End Property
    Public ReadOnly Property SueldoNominalMensual() As Double
        Get
            Return Me.m_SueldoNominalMensual
        End Get
    End Property
    Public ReadOnly Property FlexBrutoMensual() As Double
        Get
            Return Me.m_FlexBrutoMensual
        End Get
    End Property
    Public ReadOnly Property D5o7() As Double
        Get
            Return Me.m_D5o7
        End Get
    End Property
    Public ReadOnly Property SueldoDiario() As Double
        Get
            Return Me.m_SueldoDiario
        End Get
    End Property
    Public ReadOnly Property SDI() As Double
        Get
            Return Me.m_SDI
        End Get
    End Property
    Public ReadOnly Property DiasLaborables() As Int32
        Get
            Return Me.m_DiasLaborables
        End Get
    End Property
    Public ReadOnly Property DiasRetroactivos() As Int32
        Get
            Return Me.m_DiasRetroactivos
        End Get
    End Property
    Public ReadOnly Property DiasFalta() As Int32
        Get
            Return Me.m_DiasFalta
        End Get
    End Property
    Public ReadOnly Property DiasIncEnfGral() As Int32
        Get
            Return Me.m_DiasIncTrayecto
        End Get
    End Property
    Public ReadOnly Property DiasIncMaternidad() As Int32
        Get
            Return Me.m_DiasIncMaternidad
        End Get
    End Property
    Public ReadOnly Property DiasIncTrayecto() As Int32
        Get
            Return Me.m_DiasIncTrayecto
        End Get
    End Property
    Public ReadOnly Property FlexQuincenal() As Double
        Get
            Return Me.m_FlexQuincenal
        End Get
    End Property
    Public ReadOnly Property BonoUnico() As Double
        Get
            Return Me.m_BonoUnico
        End Get
    End Property
    Public ReadOnly Property BonoNegociacion() As Double
        Get
            Return Me.m_BonoNegociacion
        End Get
    End Property
    Public ReadOnly Property BonoEspecial() As Double
        Get
            Return Me.m_BonoEspecial
        End Get
    End Property
    Public ReadOnly Property SubEnfermedadGral() As Double
        Get
            Return Me.m_SubEnfermedadGral
        End Get
    End Property
    Public ReadOnly Property SubAccidenteTrabajo() As Double
        Get
            Return Me.m_SubAccidenteTrabajo
        End Get
    End Property
    Public ReadOnly Property SubAccidenteTrayecto() As Double
        Get
            Return Me.m_SubAccidenteTrayecto
        End Get
    End Property
    Public ReadOnly Property SubMaternidad() As Double
        Get
            Return Me.m_SubMaternidad
        End Get
    End Property
    Public ReadOnly Property BonoHrsExtras() As Double
        Get
            Return Me.m_BonoHrsExtras
        End Get
    End Property
    Public ReadOnly Property Retroactivo() As Double
        Get
            Return Me.m_Retroactivo
        End Get
    End Property
    Public ReadOnly Property Sueldo() As Double
        Get
            Return Me.m_Sueldo
        End Get
    End Property
    Public ReadOnly Property RetroactivoSueldo() As Double
        Get
            Return Me.m_RetroactivoSueldo
        End Get
    End Property
    Public ReadOnly Property ReembolsoInfonavit() As Double
        Get
            Return Me.m_ReembolsoInfonavit
        End Get
    End Property
    Public ReadOnly Property PrimaVacacionalAni() As Double
        Get
            Return Me.m_PrimaVacacionalAni
        End Get
    End Property
    Public ReadOnly Property SubEg1_3Dias() As Double
        Get
            Return Me.m_SubEg1_3Dias
        End Get
    End Property
    Public ReadOnly Property SubEg4_Adelante() As Double
        Get
            Return Me.m_SubEg4_Adelante
        End Get
    End Property
    Public ReadOnly Property AguinaldoAnual() As Double
        Get
            Return Me.m_AguinaldoAnual
        End Get
    End Property
    Public ReadOnly Property AguinaldoFiniquito() As Double
        Get
            Return Me.m_AguinaldoFiniquito
        End Get
    End Property
    Public ReadOnly Property VacacionesFiniquito() As Double
        Get
            Return Me.m_VacacionesFiniquito
        End Get
    End Property
    Public ReadOnly Property PrimaVacacionalFiniquito() As Double
        Get
            Return Me.m_PrimaVacacionalFiniquito
        End Get
    End Property
    Public ReadOnly Property Indemnizacion3Meses() As Double
        Get
            Return Me.m_Indemnizacion3Meses
        End Get
    End Property
    Public ReadOnly Property Indemnizacion20Dias() As Double
        Get
            Return Me.m_Indemnizacion20Dias
        End Get
    End Property
    Public ReadOnly Property NegociacionGravada() As Double
        Get
            Return Me.m_NegociacionGravada
        End Get
    End Property
    Public ReadOnly Property PrimaAnt12Dias() As Double
        Get
            Return Me.m_PrimaAnt12Dias
        End Get
    End Property
    Public ReadOnly Property PTU() As Double
        Get
            Return Me.m_PTU
        End Get
    End Property
    Public ReadOnly Property SubsidioEmpleoPagado() As Double
        Get
            Return Me.m_SubsidioEmpleoPagado
        End Get
    End Property
    Public ReadOnly Property PsDiasLaborados() As Double
        Get
            Return Me.m_PsDiasLaborados
        End Get
    End Property
    Public ReadOnly Property PsRetroactivo() As Double
        Get
            Return Me.m_PsRetroactivo
        End Get
    End Property
    Public ReadOnly Property IasDiasLaborados() As Int32
        Get
            Return Me.m_IasDiasLaborados
        End Get
    End Property
    Public ReadOnly Property IasDiasPendientes() As Int32
        Get
            Return Me.m_IasDiasPendientes
        End Get
    End Property
    Public ReadOnly Property FlexSubsidiosIncap() As Double
        Get
            Return Me.m_FlexSubsidiosIncap
        End Get
    End Property
    Public ReadOnly Property FlexBono() As Double
        Get
            Return Me.m_FlexBono
        End Get
    End Property
    Public ReadOnly Property FlexBonoNegociacion() As Double
        Get
            Return Me.m_FlexBonoNegociacion
        End Get
    End Property
    Public ReadOnly Property FlexBonoEspecial() As Double
        Get
            Return Me.m_FlexBonoEspecial
        End Get
    End Property
    Public ReadOnly Property TotalPercepciones() As Double
        Get
            Return Me.m_TotalPercepciones
        End Get
    End Property
    Public ReadOnly Property ImpuestoRetenido() As Double
        Get
            Return Me.m_ImpuestoRetenido
        End Get
    End Property
    Public ReadOnly Property ImpuestoIndemnizacion() As Double
        Get
            Return Me.m_ImpuestoIndemnizacion
        End Get
    End Property
    Public ReadOnly Property ISR_AjusteAnual177() As Double
        Get
            Return Me.m_ISR_AjusteAnual177
        End Get
    End Property
    Public ReadOnly Property IMSS() As Double
        Get
            Return Me.m_IMSS
        End Get
    End Property
    Public ReadOnly Property DescCreditoInfonavit() As Double
        Get
            Return Me.m_DescCreditoInfonavit
        End Get
    End Property
    Public ReadOnly Property AjusteDifCredInfonavit() As Double
        Get
            Return Me.m_AjusteDifCredInfonavit
        End Get
    End Property
    Public ReadOnly Property OtrosDescuentos() As Double
        Get
            Return Me.m_OtrosDescuentos
        End Get
    End Property
    Public ReadOnly Property Fonacot() As Double
        Get
            Return Me.m_Fonacot
        End Get
    End Property
    Public ReadOnly Property PrestamoPersonal() As Double
        Get
            Return Me.m_PrestamoPersonal
        End Get
    End Property
    Public ReadOnly Property OtrasDeducciones() As Double
        Get
            Return Me.m_OtrasDeducciones
        End Get
    End Property
    Public ReadOnly Property DescPensionAlimenticia() As Double
        Get
            Return Me.m_DescPensionAlimenticia
        End Get
    End Property
    Public ReadOnly Property TotalDeducciones() As Double
        Get
            Return Me.m_TotalDeducciones
        End Get
    End Property
    Public ReadOnly Property NetoAPagar() As Double
        Get
            Return Me.m_NetoAPagar
        End Get
    End Property
    Public ReadOnly Property ImssExcedentePatron() As Double
        Get
            Return Me.m_ImssExcedentePatron
        End Get
    End Property
    Public ReadOnly Property ImssPrestacionesDinero() As Double
        Get
            Return Me.m_ImssPrestacionesDinero
        End Get
    End Property
    Public ReadOnly Property ImssPrestacionesEspecie() As Double
        Get
            Return Me.m_ImssPrestacionesEspecie
        End Get
    End Property
    Public ReadOnly Property ImssIVPatronal() As Double
        Get
            Return Me.m_ImssIVPatronal
        End Get
    End Property
    Public ReadOnly Property ImssProvisionGuarderia() As Double
        Get
            Return Me.m_ImssProvisionGuarderia
        End Get
    End Property
    Public ReadOnly Property ImssRiesgoTrabajo() As Double
        Get
            Return Me.m_ImssRiesgoTrabajo
        End Get
    End Property
    Public ReadOnly Property ProvisionSAR() As Double
        Get
            Return Me.m_ProvisionSAR
        End Get
    End Property
    Public ReadOnly Property ProvisionInfonavit() As Double
        Get
            Return Me.m_ProvisionInfonavit
        End Get
    End Property
    Public ReadOnly Property ImssCVPatronal() As Double
        Get
            Return Me.m_ImssCVPatronal
        End Get
    End Property
    Public ReadOnly Property ImssCuotaFija() As Double
        Get
            Return Me.m_ImssCuotaFija
        End Get
    End Property
    Public ReadOnly Property ImssPatronal() As Double
        Get
            Return Me.m_ImssPatronal
        End Get
    End Property
    Public ReadOnly Property ImssObrero() As Double
        Get
            Return Me.m_ImssObrero
        End Get
    End Property
    Public ReadOnly Property ISN() As Double
        Get
            Return Me.m_ISN
        End Get
    End Property
    Public ReadOnly Property CargaSocial() As Double
        Get
            Return Me.m_CargaSocial
        End Get
    End Property
    Public ReadOnly Property ComisionNomina() As Double
        Get
            Return Me.m_ComisionNomina
        End Get
    End Property
    Public ReadOnly Property IVA() As Double
        Get
            Return Me.m_IVA
        End Get
    End Property
    Public ReadOnly Property TotalFacturar() As Double
        Get
            Return Me.m_TotalFacturar
        End Get
    End Property
    Public ReadOnly Property Cuenta() As String
        Get
            Return Me.m_Cuenta
        End Get
    End Property
    Public ReadOnly Property Clabe() As String
        Get
            Return Me.m_Clabe
        End Get
    End Property
    Public ReadOnly Property Banco() As String
        Get
            Return Me.m_Banco
        End Get
    End Property


    Public Sub New(ByVal Cliente As String, ByVal Puesto As String, ByVal Empleado As String, ByVal Fecha_Alta As Date, ByVal Nombre As String, ByVal Tipo_Caso As Int32,
                    ByVal Sueldo_Nmensual As Double, ByVal Flex_Bmensual As Double, ByVal D5o7 As Int32, ByVal Sueldo_Diario As Double, ByVal Sdi As Double, ByVal Dias_Lab As Int32, ByVal Dias_Retro As Int32,
                    ByVal Dias_Faltas As Int32, ByVal Dias_Inc_Gral As Int32, ByVal Dias_Inc_Mate As Int32, ByVal Dias_Inc_Tray As Int32, ByVal Flex_Quincenal As Double, ByVal Bono_Unico As Double,
                    ByVal Bono_Negociacion As Double, ByVal Bono_Especial As Double, ByVal Sub_Enfermedad_Gral As Double, ByVal Sub_Accidente_Trabajo As Double, ByVal Sub_Accidente_Trayecto As Double,
                    ByVal Sub_Maternidad As Double, ByVal Bono_Horasextras As Double, ByVal Retroactivo As Double, ByVal Sueldo As Double, ByVal Retroactivo_Sueldo As Double, ByVal Reembolso_Infonavit As Double,
                    ByVal Prima_Vacacional_Ani As Double, ByVal Subsidio_Eg1_3dias As Double, ByVal Subsidio_Eg4_Adelante As Double, ByVal Aguinaldo_Anual As Double, ByVal Aguinaldo_Finiquito As Double,
                    ByVal Vacaciones_Finiquito As Double, ByVal Prima_Vacacional_Finiquito As Double, ByVal Indemnizacion_3meses As Double, ByVal Indemnizacion_20dias As Double, ByVal Negociacion_Gravada As Double,
                    ByVal Prima_Ant_12dias As Double, ByVal Ptu As Double, ByVal Subsidio_Empleopagado As Double, ByVal Ps_Dias_Laborados As Double, ByVal Ps_Retroactivo As Double,
                    ByVal Ias_Dias_Laborados As Int32, ByVal Ias_Dias_Pendientes As Int32, ByVal Flex_Subsidios_Incap As Double, ByVal Flex_Bono As Double, ByVal Flex_Bono_Negociacion As Double,
                    ByVal Flex_Bono_Especial As Double, ByVal Total_Percepciones As Double, ByVal Impuesto_Retenido As Double, ByVal Impuesto_Indemnizacion As Double, ByVal Isr_Ajuste_Anual_177 As Double,
                    ByVal Imss As Double, ByVal Desc_Credito_Infonavit As Double, ByVal Ajuste_Dif_Cred_Infonavit As Double, ByVal Otros_Descuentos As Double, ByVal Fonacot As Double, ByVal Prestamo_Personal As Double,
                    ByVal Otras_Deducciones As Double, ByVal Desc_Pension_Alimenticia As Double, ByVal Total_Deducciones As Double, ByVal Neto_A_Pagar As Double, ByVal Imss_Excedente_Patron As Double,
                    ByVal Imss_Prestaciones_Dinero As Double, ByVal Imss_Prestaciones_Especie As Double, ByVal Imss_Iv_Patronal As Double, ByVal Imss_Provision_Guarderia As Double, ByVal Imss_Riesgotrabajo As Double,
                    ByVal Provision_Sar As Double, ByVal Provision_Infonavit As Double, ByVal Imss_Cv_Patronal As Double, ByVal Imss_Cuota_Fija As Double, ByVal Imss_Patronal As Double, ByVal Imss_Obrero As Double,
                    ByVal Isn As Double, ByVal Carga_Social As Double, ByVal Comision_Nomina As Double, ByVal Iva As Double, ByVal Total_Facturar As Double, ByVal Cuenta As String, ByVal Clabe As String, ByVal Banco As String)

        Me.m_Cliente = Cliente
        Me.m_Puesto = Puesto
        Me.m_Empleado = Empleado
        Me.m_FechaAlta = Fecha_Alta
        'Me.m_FechaBaja = Fecha_Baja
        Me.m_Nombre = Nombre
        Me.m_TipoCaso = Tipo_Caso
        Me.m_SueldoNominalMensual = Sueldo_Nmensual
        Me.m_FlexBrutoMensual = Flex_Bmensual
        Me.m_D5o7 = D5o7
        Me.m_SueldoDiario = Sueldo_Diario
        Me.m_SDI = Sdi
        Me.m_DiasLaborables = Dias_Lab
        Me.m_DiasRetroactivos = Dias_Retro
        Me.m_DiasFalta = Dias_Faltas
        Me.m_DiasIncEnfGral = Dias_Inc_Gral
        Me.m_DiasIncMaternidad = Dias_Inc_Mate
        Me.m_DiasIncTrayecto = Dias_Inc_Tray
        Me.m_FlexQuincenal = Flex_Quincenal
        Me.m_BonoUnico = Bono_Unico
        Me.m_BonoNegociacion = Bono_Negociacion
        Me.m_BonoEspecial = Bono_Especial
        Me.m_SubEnfermedadGral = Sub_Enfermedad_Gral
        Me.m_SubAccidenteTrabajo = Sub_Accidente_Trabajo
        Me.m_SubAccidenteTrayecto = Sub_Accidente_Trayecto
        Me.m_SubMaternidad = Sub_Maternidad
        Me.m_BonoHrsExtras = Bono_Horasextras
        Me.m_Retroactivo = Retroactivo
        Me.m_Sueldo = Sueldo
        Me.m_RetroactivoSueldo = Retroactivo_Sueldo
        Me.m_ReembolsoInfonavit = Reembolso_Infonavit
        Me.m_PrimaVacacionalAni = Prima_Vacacional_Ani
        Me.m_SubEg1_3Dias = Subsidio_Eg1_3dias
        Me.m_SubEg4_Adelante = Subsidio_Eg4_Adelante
        Me.m_AguinaldoAnual = Aguinaldo_Anual
        Me.m_AguinaldoFiniquito = Aguinaldo_Finiquito
        Me.m_VacacionesFiniquito = Vacaciones_Finiquito
        Me.m_PrimaVacacionalFiniquito = Prima_Vacacional_Finiquito
        Me.m_Indemnizacion3Meses = Indemnizacion_3meses
        Me.m_Indemnizacion20Dias = Indemnizacion_20dias
        Me.m_NegociacionGravada = Negociacion_Gravada
        Me.m_PrimaAnt12Dias = Prima_Ant_12dias
        Me.m_PTU = Ptu
        Me.m_SubsidioEmpleoPagado = Subsidio_Empleopagado
        Me.m_PsDiasLaborados = Ps_Dias_Laborados
        Me.m_PsRetroactivo = Ps_Retroactivo
        Me.m_IasDiasLaborados = Ias_Dias_Laborados
        Me.m_IasDiasPendientes = Ias_Dias_Pendientes
        Me.m_FlexSubsidiosIncap = Flex_Subsidios_Incap
        Me.m_FlexBono = Flex_Bono
        Me.m_FlexBonoNegociacion = Flex_Bono_Negociacion
        Me.m_FlexBonoEspecial = Flex_Bono_Especial
        Me.m_TotalPercepciones = Total_Percepciones
        Me.m_ImpuestoRetenido = Impuesto_Retenido
        Me.m_ImpuestoIndemnizacion = Impuesto_Indemnizacion
        Me.m_ISR_AjusteAnual177 = Isr_Ajuste_Anual_177
        Me.m_IMSS = Imss
        Me.m_DescCreditoInfonavit = Desc_Credito_Infonavit
        Me.m_AjusteDifCredInfonavit = Ajuste_Dif_Cred_Infonavit
        Me.m_OtrosDescuentos = Otros_Descuentos
        Me.m_Fonacot = Fonacot
        Me.m_PrestamoPersonal = Prestamo_Personal
        Me.m_OtrasDeducciones = Otras_Deducciones
        Me.m_DescPensionAlimenticia = Desc_Pension_Alimenticia
        Me.m_TotalDeducciones = Total_Deducciones
        Me.m_NetoAPagar = Neto_A_Pagar
        Me.m_ImssExcedentePatron = Imss_Excedente_Patron
        Me.m_ImssPrestacionesDinero = Imss_Prestaciones_Dinero
        Me.m_ImssPrestacionesEspecie = Imss_Prestaciones_Especie
        Me.m_ImssIVPatronal = Imss_Iv_Patronal
        Me.m_ImssProvisionGuarderia = Imss_Provision_Guarderia
        Me.m_ImssRiesgoTrabajo = Imss_Riesgotrabajo
        Me.m_ProvisionSAR = Provision_Sar
        Me.m_ProvisionInfonavit = Provision_Infonavit
        Me.m_ImssCVPatronal = Imss_Cv_Patronal
        Me.m_ImssCuotaFija = Imss_Cuota_Fija
        Me.m_ImssPatronal = Imss_Patronal
        Me.m_ImssObrero = Imss_Obrero
        Me.m_ISN = Isn
        Me.m_CargaSocial = Carga_Social
        Me.m_ComisionNomina = Comision_Nomina
        Me.m_IVA = Iva
        Me.m_TotalFacturar = Total_Facturar
        Me.m_Cuenta = Cuenta
        Me.m_Clabe = Clabe
        Me.m_Banco = Banco
    End Sub
    Public Sub New(ByVal Cliente As String, ByVal Puesto As String, ByVal Empleado As String, ByVal Fecha_Alta As Date, ByVal Mov As String, ByVal Nombre As String, ByVal Tipo_Caso As Int32,
                   ByVal Sueldo_Nmensual As Double, ByVal Flex_Bmensual As Double, ByVal D5o7 As Int32, ByVal Sueldo_Diario As Double, ByVal Sdi As Double, ByVal Dias_Lab As Int32, ByVal Dias_Retro As Int32,
                   ByVal Dias_Faltas As Int32, ByVal Dias_Inc_Gral As Int32, ByVal Dias_Inc_Mate As Int32, ByVal Dias_Inc_Tray As Int32, ByVal Flex_Quincenal As Double, ByVal Bono_Unico As Double,
                   ByVal Bono_Negociacion As Double, ByVal Bono_Especial As Double, ByVal Sub_Enfermedad_Gral As Double, ByVal Sub_Accidente_Trabajo As Double, ByVal Sub_Accidente_Trayecto As Double,
                   ByVal Sub_Maternidad As Double, ByVal Bono_Horasextras As Double, ByVal Retroactivo As Double, ByVal Sueldo As Double, ByVal Retroactivo_Sueldo As Double, ByVal Reembolso_Infonavit As Double,
                   ByVal Prima_Vacacional_Ani As Double, ByVal Subsidio_Eg1_3dias As Double, ByVal Subsidio_Eg4_Adelante As Double, ByVal Aguinaldo_Anual As Double, ByVal Aguinaldo_Finiquito As Double,
                   ByVal Vacaciones_Finiquito As Double, ByVal Prima_Vacacional_Finiquito As Double, ByVal Indemnizacion_3meses As Double, ByVal Indemnizacion_20dias As Double, ByVal Negociacion_Gravada As Double,
                   ByVal Prima_Ant_12dias As Double, ByVal Ptu As Double, ByVal Subsidio_Empleopagado As Double, ByVal Ps_Dias_Laborados As Double, ByVal Ps_Retroactivo As Double,
                   ByVal Ias_Dias_Laborados As Int32, ByVal Ias_Dias_Pendientes As Int32, ByVal Flex_Subsidios_Incap As Double, ByVal Flex_Bono As Double, ByVal Flex_Bono_Negociacion As Double,
                   ByVal Flex_Bono_Especial As Double, ByVal Total_Percepciones As Double, ByVal Impuesto_Retenido As Double, ByVal Impuesto_Indemnizacion As Double, ByVal Isr_Ajuste_Anual_177 As Double,
                   ByVal Imss As Double, ByVal Desc_Credito_Infonavit As Double, ByVal Ajuste_Dif_Cred_Infonavit As Double, ByVal Otros_Descuentos As Double, ByVal Fonacot As Double, ByVal Prestamo_Personal As Double,
                   ByVal Otras_Deducciones As Double, ByVal Desc_Pension_Alimenticia As Double, ByVal Total_Deducciones As Double, ByVal Neto_A_Pagar As Double, ByVal Imss_Excedente_Patron As Double,
                   ByVal Imss_Prestaciones_Dinero As Double, ByVal Imss_Prestaciones_Especie As Double, ByVal Imss_Iv_Patronal As Double, ByVal Imss_Provision_Guarderia As Double, ByVal Imss_Riesgotrabajo As Double,
                   ByVal Provision_Sar As Double, ByVal Provision_Infonavit As Double, ByVal Imss_Cv_Patronal As Double, ByVal Imss_Cuota_Fija As Double, ByVal Imss_Patronal As Double, ByVal Imss_Obrero As Double,
                   ByVal Isn As Double, ByVal Carga_Social As Double, ByVal Comision_Nomina As Double, ByVal Iva As Double, ByVal Total_Facturar As Double, ByVal Cuenta As String, ByVal Clabe As String, ByVal Banco As String)

        Me.m_Cliente = Cliente
        Me.m_Puesto = Puesto
        Me.m_Empleado = Empleado
        Me.m_FechaAlta = Fecha_Alta
        Me.m_Mov = Mov
        'Me.m_FechaBaja = Fecha_Baja
        Me.m_Nombre = Nombre
        Me.m_TipoCaso = Tipo_Caso
        Me.m_SueldoNominalMensual = Sueldo_Nmensual
        Me.m_FlexBrutoMensual = Flex_Bmensual
        Me.m_D5o7 = D5o7
        Me.m_SueldoDiario = Sueldo_Diario
        Me.m_SDI = Sdi
        Me.m_DiasLaborables = Dias_Lab
        Me.m_DiasRetroactivos = Dias_Retro
        Me.m_DiasFalta = Dias_Faltas
        Me.m_DiasIncEnfGral = Dias_Inc_Gral
        Me.m_DiasIncMaternidad = Dias_Inc_Mate
        Me.m_DiasIncTrayecto = Dias_Inc_Tray
        Me.m_FlexQuincenal = Flex_Quincenal
        Me.m_BonoUnico = Bono_Unico
        Me.m_BonoNegociacion = Bono_Negociacion
        Me.m_BonoEspecial = Bono_Especial
        Me.m_SubEnfermedadGral = Sub_Enfermedad_Gral
        Me.m_SubAccidenteTrabajo = Sub_Accidente_Trabajo
        Me.m_SubAccidenteTrayecto = Sub_Accidente_Trayecto
        Me.m_SubMaternidad = Sub_Maternidad
        Me.m_BonoHrsExtras = Bono_Horasextras
        Me.m_Retroactivo = Retroactivo
        Me.m_Sueldo = Sueldo
        Me.m_RetroactivoSueldo = Retroactivo_Sueldo
        Me.m_ReembolsoInfonavit = Reembolso_Infonavit
        Me.m_PrimaVacacionalAni = Prima_Vacacional_Ani
        Me.m_SubEg1_3Dias = Subsidio_Eg1_3dias
        Me.m_SubEg4_Adelante = Subsidio_Eg4_Adelante
        Me.m_AguinaldoAnual = Aguinaldo_Anual
        Me.m_AguinaldoFiniquito = Aguinaldo_Finiquito
        Me.m_VacacionesFiniquito = Vacaciones_Finiquito
        Me.m_PrimaVacacionalFiniquito = Prima_Vacacional_Finiquito
        Me.m_Indemnizacion3Meses = Indemnizacion_3meses
        Me.m_Indemnizacion20Dias = Indemnizacion_20dias
        Me.m_NegociacionGravada = Negociacion_Gravada
        Me.m_PrimaAnt12Dias = Prima_Ant_12dias
        Me.m_PTU = Ptu
        Me.m_SubsidioEmpleoPagado = Subsidio_Empleopagado
        Me.m_PsDiasLaborados = Ps_Dias_Laborados
        Me.m_PsRetroactivo = Ps_Retroactivo
        Me.m_IasDiasLaborados = Ias_Dias_Laborados
        Me.m_IasDiasPendientes = Ias_Dias_Pendientes
        Me.m_FlexSubsidiosIncap = Flex_Subsidios_Incap
        Me.m_FlexBono = Flex_Bono
        Me.m_FlexBonoNegociacion = Flex_Bono_Negociacion
        Me.m_FlexBonoEspecial = Flex_Bono_Especial
        Me.m_TotalPercepciones = Total_Percepciones
        Me.m_ImpuestoRetenido = Impuesto_Retenido
        Me.m_ImpuestoIndemnizacion = Impuesto_Indemnizacion
        Me.m_ISR_AjusteAnual177 = Isr_Ajuste_Anual_177
        Me.m_IMSS = Imss
        Me.m_DescCreditoInfonavit = Desc_Credito_Infonavit
        Me.m_AjusteDifCredInfonavit = Ajuste_Dif_Cred_Infonavit
        Me.m_OtrosDescuentos = Otros_Descuentos
        Me.m_Fonacot = Fonacot
        Me.m_PrestamoPersonal = Prestamo_Personal
        Me.m_OtrasDeducciones = Otras_Deducciones
        Me.m_DescPensionAlimenticia = Desc_Pension_Alimenticia
        Me.m_TotalDeducciones = Total_Deducciones
        Me.m_NetoAPagar = Neto_A_Pagar
        Me.m_ImssExcedentePatron = Imss_Excedente_Patron
        Me.m_ImssPrestacionesDinero = Imss_Prestaciones_Dinero
        Me.m_ImssPrestacionesEspecie = Imss_Prestaciones_Especie
        Me.m_ImssIVPatronal = Imss_Iv_Patronal
        Me.m_ImssProvisionGuarderia = Imss_Provision_Guarderia
        Me.m_ImssRiesgoTrabajo = Imss_Riesgotrabajo
        Me.m_ProvisionSAR = Provision_Sar
        Me.m_ProvisionInfonavit = Provision_Infonavit
        Me.m_ImssCVPatronal = Imss_Cv_Patronal
        Me.m_ImssCuotaFija = Imss_Cuota_Fija
        Me.m_ImssPatronal = Imss_Patronal
        Me.m_ImssObrero = Imss_Obrero
        Me.m_ISN = Isn
        Me.m_CargaSocial = Carga_Social
        Me.m_ComisionNomina = Comision_Nomina
        Me.m_IVA = Iva
        Me.m_TotalFacturar = Total_Facturar
        Me.m_Cuenta = Cuenta
        Me.m_Clabe = Clabe
        Me.m_Banco = Banco
    End Sub
End Class
