Public Class clsReal
    Private m_Tarjeta_Id As String
    Private m_Nombre As String
    Private m_IdEmpresa As Int32
    Private m_IdEmpresaIntelisis As Int32
    Private m_Empresa As String
    Private m_Departamento As String
    Private m_Puesto As String
    Private m_CentroDeCostos As Int32
    Private m_Moneda As String
    Private m_FechaConversion As Date
    Private m_FechaInicio As Date
    Private m_FechaFinal As Date
    Private m_Sueldo As Double
    Private m_Sub_Eg_3 As Double
    Private m_Sub_Eg_4 As Double
    Private m_SubsidioMaternidad As Double
    Private m_BonosUnico As Double
    Private m_NegociacionGravada As Double
    Private m_Ps As Double
    Private m_Bono_Ps As Double
    Private m_Ias As Double
    Private m_FlexiblesSubsidiosIncap As Double
    Private m_SubsidioAlEmpleo As Double
    Private m_PrimaDominical As Double
    Private m_DescansoLaborado As Double
    Private m_HorasExtra As Double
    Private m_HorasExtraTriples As Double
    Private m_Aguinaldo As Double
    Private m_FiniquitoVacaciones As Double
    Private m_PrimaVac As Double
    Private m_FiniqitoPrimaVacExcento As Double
    Private m_FiniquitoPrimaVacGravado As Double
    Private m_FiniquitoAguinaldoExcento As Double
    Private m_FiniquitoAguinaldoGravado As Double
    Private m_Ptu As Double
    Private m_LiquidacionPrimaAntiguedad As Double
    Private m_Liquidacion3meses As Double
    Private m_Liquidacion20diaspora As Double
    Private m_CuotaImss As Double
    Private m_CreditoInfona As Double
    Private m_AjusteCreditoIn As Double
    Private m_DescuentoComedor As Double
    Private m_FondodeAhorro As Double
    Private m_DescuentoOtro As Double
    Private m_DescuentoSeguroGmm As Double
    Private m_DescuentoEquipoComputo As Double
    Private m_PrestamoPersonal As Double
    Private m_OtrasDeducciones As Double
    Private m_Fonacot As Double
    Private m_Isr As Double
    Private m_IsrFiniquito As Double
    Private m_DiferenciaIsrAjuste As Double
    Private m_PensionAlimenticia As Double
    Private m_ProvisionAguinaldo As Double
    Private m_ProvisionPrimaVac As Double
    Private m_Isn As Double
    Private m_ImssPatronal As Double
    Private m_SareInfonavit As Double
    Private m_SgmmMensual As Double
    Private m_SeguroVidaMensual As Double
    Private m_Iva As Double
    Private m_ComisionNomina As Double

    Private m_D3 As Double
    Private m_ProvisionBono As Double
    Private m_SalarioDiario As Double
    Private m_SalarioDiarioDelEsquemaFlexible As Double

    Public ReadOnly Property Tarjeta_Id As String
        Get
            Return m_Tarjeta_Id
        End Get
    End Property
    Public ReadOnly Property Nombre As String
        Get
            Return m_Nombre
        End Get
    End Property
    Public ReadOnly Property IdEmpresa As Int32
        Get
            Return m_IdEmpresa
        End Get
    End Property
    Public ReadOnly Property IdEmpresaIntelisis As Int32
        Get
            Return m_IdEmpresaIntelisis
        End Get
    End Property
    Public ReadOnly Property Empresa As String
        Get
            Return m_Empresa
        End Get
    End Property
    Public ReadOnly Property Departamento As String
        Get
            Return m_Departamento
        End Get
    End Property
    Public ReadOnly Property Puesto As String
        Get
            Return m_Puesto
        End Get
    End Property
    Public ReadOnly Property CentroDeCostos As Int32
        Get
            Return m_CentroDeCostos
        End Get
    End Property
    Public ReadOnly Property Moneda As String
        Get
            Return m_Moneda
        End Get
    End Property
    Public ReadOnly Property FechaConversion As Date
        Get
            Return m_FechaConversion
        End Get
    End Property
    Public ReadOnly Property FechaInicio As Date
        Get
            Return m_FechaInicio
        End Get
    End Property
    Public ReadOnly Property FechaFinal As Date
        Get
            Return m_FechaFinal
        End Get
    End Property
    Public ReadOnly Property Sueldo As Double
        Get
            Return m_Sueldo
        End Get
    End Property
    Public ReadOnly Property Sub_Eg_3 As Double
        Get
            Return m_Sub_Eg_3
        End Get
    End Property
    Public ReadOnly Property Sub_Eg_4 As Double
        Get
            Return m_Sub_Eg_4
        End Get
    End Property
    Public ReadOnly Property SubsidioMaternidad As Double
        Get
            Return m_SubsidioMaternidad
        End Get
    End Property
    Public ReadOnly Property BonosUnico As Double
        Get
            Return m_BonosUnico
        End Get
    End Property
    Public ReadOnly Property NegociacionGravada As Double
        Get
            Return m_NegociacionGravada
        End Get
    End Property
    Public ReadOnly Property Ps As Double
        Get
            Return m_Ps
        End Get
    End Property
    Public ReadOnly Property Bono_Ps As Double
        Get
            Return m_Bono_Ps
        End Get
    End Property
    Public ReadOnly Property Ias As Double
        Get
            Return m_Ias
        End Get
    End Property
    Public ReadOnly Property FlexiblesSubsidiosIncap As Double
        Get
            Return m_FlexiblesSubsidiosIncap
        End Get
    End Property
    Public ReadOnly Property SubsidioAlEmpleo As Double
        Get
            Return m_SubsidioAlEmpleo
        End Get
    End Property
    Public ReadOnly Property PrimaDominical As Double
        Get
            Return m_PrimaDominical
        End Get
    End Property
    Public ReadOnly Property DescansoLaborado As Double
        Get
            Return m_DescansoLaborado
        End Get
    End Property
    Public ReadOnly Property HorasExtra As Double
        Get
            Return m_HorasExtra
        End Get
    End Property
    Public ReadOnly Property HorasExtraTriples As Double
        Get
            Return m_HorasExtraTriples
        End Get
    End Property
    Public ReadOnly Property Aguinaldo As Double
        Get
            Return m_Aguinaldo
        End Get
    End Property
    Public ReadOnly Property FiniquitoVacaciones As Double
        Get
            Return m_FiniquitoVacaciones
        End Get
    End Property
    Public ReadOnly Property PrimaVac As Double
        Get
            Return m_PrimaVac
        End Get
    End Property
    Public ReadOnly Property FiniqitoPrimaVacExcento As Double
        Get
            Return m_FiniqitoPrimaVacExcento
        End Get
    End Property
    Public ReadOnly Property FiniquitoPrimaVacGravado As Double
        Get
            Return m_FiniquitoPrimaVacGravado
        End Get
    End Property
    Public ReadOnly Property FiniquitoAguinaldoExcento As Double
        Get
            Return m_FiniquitoAguinaldoExcento
        End Get
    End Property
    Public ReadOnly Property FiniquitoAguinaldoGravado As Double
        Get
            Return m_FiniquitoAguinaldoGravado
        End Get
    End Property
    Public ReadOnly Property Ptu As Double
        Get
            Return m_Ptu
        End Get
    End Property
    Public ReadOnly Property LiquidacionPrimaAntiguedad As Double
        Get
            Return m_LiquidacionPrimaAntiguedad
        End Get
    End Property
    Public ReadOnly Property Liquidacion3meses As Double
        Get
            Return m_Liquidacion3meses
        End Get
    End Property
    Public ReadOnly Property Liquidacion20diaspora As Double
        Get
            Return m_Liquidacion20diaspora
        End Get
    End Property
    Public ReadOnly Property CuotaImss As Double
        Get
            Return m_CuotaImss
        End Get
    End Property
    Public ReadOnly Property CreditoInfona As Double
        Get
            Return m_CreditoInfona
        End Get
    End Property
    Public ReadOnly Property AjusteCreditoIn As Double
        Get
            Return m_AjusteCreditoIn
        End Get
    End Property
    Public ReadOnly Property DescuentoComedor As Double
        Get
            Return m_DescuentoComedor
        End Get
    End Property
    Public ReadOnly Property FondodeAhorro As Double
        Get
            Return m_FondodeAhorro
        End Get
    End Property
    Public ReadOnly Property DescuentoOtro As Double
        Get
            Return m_DescuentoOtro
        End Get
    End Property
    Public ReadOnly Property DescuentoSeguroGmm As Double
        Get
            Return m_DescuentoSeguroGmm
        End Get
    End Property
    Public ReadOnly Property DescuentoEquipoComputo As Double
        Get
            Return m_DescuentoEquipoComputo
        End Get
    End Property
    Public ReadOnly Property PrestamoPersonal As Double
        Get
            Return m_PrestamoPersonal
        End Get
    End Property
    Public ReadOnly Property OtrasDeducciones As Double
        Get
            Return m_OtrasDeducciones
        End Get
    End Property
    Public ReadOnly Property Fonacot As Double
        Get
            Return m_Fonacot
        End Get
    End Property
    Public ReadOnly Property Isr As Double
        Get
            Return m_Isr
        End Get
    End Property
    Public ReadOnly Property IsrFiniquito As Double
        Get
            Return m_IsrFiniquito
        End Get
    End Property
    Public ReadOnly Property DiferenciaIsrAjuste As Double
        Get
            Return m_DiferenciaIsrAjuste
        End Get
    End Property
    Public ReadOnly Property PensionAlimenticia As Double
        Get
            Return m_PensionAlimenticia
        End Get
    End Property
    Public ReadOnly Property ProvisionAguinaldo As Double
        Get
            Return m_ProvisionAguinaldo
        End Get
    End Property
    Public ReadOnly Property ProvisionPrimaVac As Double
        Get
            Return m_ProvisionPrimaVac
        End Get
    End Property
    Public ReadOnly Property Isn As Double
        Get
            Return m_Isn
        End Get
    End Property
    Public ReadOnly Property ImssPatronal As Double
        Get
            Return m_ImssPatronal
        End Get
    End Property
    Public ReadOnly Property SareInfonavit As Double
        Get
            Return m_SareInfonavit
        End Get
    End Property
    Public ReadOnly Property SgmmMensual As Double
        Get
            Return m_SgmmMensual
        End Get
    End Property
    Public ReadOnly Property SeguroVidaMensual As Double
        Get
            Return m_SeguroVidaMensual
        End Get
    End Property
    Public ReadOnly Property Iva As Double
        Get
            Return m_Iva
        End Get
    End Property
    Public ReadOnly Property ComisionNomina As Double
        Get
            Return m_ComisionNomina
        End Get
    End Property

    Public ReadOnly Property D3 As Double
        Get
            Return Me.m_D3
        End Get
    End Property
    Public ReadOnly Property ProvisionBono As Double
        Get
            Return m_ProvisionBono
        End Get
    End Property
    Public ReadOnly Property SalarioDiario As Double
        Get
            Return m_SalarioDiario
        End Get
    End Property
    Public ReadOnly Property SalarioDiarioDelEsquemaFlexible As Double
        Get
            Return m_SalarioDiarioDelEsquemaFlexible
        End Get
    End Property

    Public Sub New(ByVal Tarjeta_Id As String, ByVal Nombre As String, ByVal IdEmpresa As Int32, ByVal IdEmpresaIntelisis As Int32, ByVal Empresa As String, _
                   ByVal Departamento As String, ByVal Puesto As String, ByVal CentroDeCostos As Int32, ByVal Moneda As String, ByVal FechaConversion As Date, _
                   ByVal FechaInicio As Date, ByVal FechaFinal As Date, ByVal Sueldo As Double, ByVal Sub_Eg_3 As Double, ByVal Sub_Eg_4 As Double, _
                   ByVal SubsidioMaternidad As Double, ByVal BonosUnico As Double, ByVal NegociacionGravada As Double, ByVal Ps As Double, ByVal Bono_Ps As Double, _
                   ByVal Ias As Double, ByVal FlexiblesSubsidiosIncap As Double, ByVal SubsidioAlEmpleo As Double, ByVal PrimaDominical As Double, _
                   ByVal DescansoLaborado As Double, ByVal HorasExtra As Double, ByVal HorasExtraTriples As Double, ByVal Aguinaldo As Double, ByVal FiniquitoVacaciones As Double, _
                   ByVal PrimaVac As Double, ByVal FiniqitoPrimaVacExcento As Double, ByVal FiniquitoPrimaVacGravado As Double, ByVal FiniquitoAguinaldoExcento As Double, _
                   ByVal FiniquitoAguinaldoGravado As Double, ByVal Ptu As Double, ByVal LiquidacionPrimaAntiguedad As Double, ByVal Liquidacion3meses As Double, _
                   ByVal Liquidacion20diaspora As Double, ByVal CuotaImss As Double, ByVal CreditoInfona As Double, ByVal AjusteCreditoIn As Double, _
                   ByVal DescuentoComedor As Double, ByVal FondodeAhorro As Double, ByVal DescuentoOtro As Double, ByVal DescuentoSeguroGmm As Double, _
                   ByVal DescuentoEquipoComputo As Double, ByVal PrestamoPersonal As Double, ByVal OtrasDeducciones As Double, ByVal Fonacot As Double, ByVal Isr As Double, _
                   ByVal IsrFiniquito As Double, ByVal DiferenciaIsrAjuste As Double, ByVal PensionAlimenticia As Double, ByVal ProvisionAguinaldo As Double, _
                   ByVal ProvisionPrimaVac As Double, ByVal Isn As Double, ByVal ImssPatronal As Double, ByVal SareInfonavit As Double, ByVal SgmmMensual As Double, _
                   ByVal SeguroVidaMensual As Double, ByVal Iva As Double, ByVal ComisionNomina As Double, ByVal D3 As Double, ByVal ProvisionBono As Double, ByVal SalarioDiario As Double, ByVal SalarioEsqFlex As Double)
        Me.m_Tarjeta_Id = Tarjeta_Id
        Me.m_Nombre = Nombre
        Me.m_IdEmpresa = IdEmpresa
        Me.m_IdEmpresaIntelisis = IdEmpresaIntelisis
        Me.m_Empresa = Empresa
        Me.m_Departamento = Departamento
        Me.m_Puesto = Puesto
        Me.m_CentroDeCostos = CentroDeCostos
        Me.m_Moneda = Moneda
        Me.m_FechaConversion = FechaConversion
        Me.m_FechaInicio = FechaInicio
        Me.m_FechaFinal = FechaFinal
        Me.m_Sueldo = Sueldo
        Me.m_Sub_Eg_3 = Sub_Eg_3
        Me.m_Sub_Eg_4 = Sub_Eg_4
        Me.m_SubsidioMaternidad = SubsidioMaternidad
        Me.m_BonosUnico = BonosUnico
        Me.m_NegociacionGravada = NegociacionGravada
        Me.m_Ps = Ps
        Me.m_Bono_Ps = Bono_Ps
        Me.m_Ias = Ias
        Me.m_FlexiblesSubsidiosIncap = FlexiblesSubsidiosIncap
        Me.m_SubsidioAlEmpleo = SubsidioAlEmpleo
        Me.m_PrimaDominical = PrimaDominical
        Me.m_DescansoLaborado = DescansoLaborado
        Me.m_HorasExtra = HorasExtra
        Me.m_HorasExtraTriples = HorasExtraTriples
        Me.m_Aguinaldo = Aguinaldo
        Me.m_FiniquitoVacaciones = FiniquitoVacaciones
        Me.m_PrimaVac = PrimaVac
        Me.m_FiniqitoPrimaVacExcento = FiniqitoPrimaVacExcento
        Me.m_FiniquitoPrimaVacGravado = FiniquitoPrimaVacGravado
        Me.m_FiniquitoAguinaldoExcento = FiniquitoAguinaldoExcento
        Me.m_FiniquitoAguinaldoGravado = FiniquitoAguinaldoGravado
        Me.m_Ptu = Ptu
        Me.m_LiquidacionPrimaAntiguedad = LiquidacionPrimaAntiguedad
        Me.m_Liquidacion3meses = Liquidacion3meses
        Me.m_Liquidacion20diaspora = Liquidacion20diaspora
        Me.m_CuotaImss = CuotaImss
        Me.m_CreditoInfona = CreditoInfona
        Me.m_AjusteCreditoIn = AjusteCreditoIn
        Me.m_DescuentoComedor = DescuentoComedor
        Me.m_FondodeAhorro = FondodeAhorro
        Me.m_DescuentoOtro = DescuentoOtro
        Me.m_DescuentoSeguroGmm = DescuentoSeguroGmm
        Me.m_DescuentoEquipoComputo = DescuentoEquipoComputo
        Me.m_PrestamoPersonal = PrestamoPersonal
        Me.m_OtrasDeducciones = OtrasDeducciones
        Me.m_Fonacot = Fonacot
        Me.m_Isr = Isr
        Me.m_IsrFiniquito = IsrFiniquito
        Me.m_DiferenciaIsrAjuste = DiferenciaIsrAjuste
        Me.m_PensionAlimenticia = PensionAlimenticia
        Me.m_ProvisionAguinaldo = ProvisionAguinaldo
        Me.m_ProvisionPrimaVac = ProvisionPrimaVac
        Me.m_Isn = Isn
        Me.m_ImssPatronal = ImssPatronal
        Me.m_SareInfonavit = SareInfonavit
        Me.m_SgmmMensual = SgmmMensual
        Me.m_SeguroVidaMensual = SeguroVidaMensual
        Me.m_Iva = Iva
        Me.m_ComisionNomina = ComisionNomina
        Me.m_D3 = D3
        Me.m_ProvisionBono = ProvisionBono
        Me.m_SalarioDiario = SalarioDiario
        Me.m_SalarioDiarioDelEsquemaFlexible = SalarioEsqFlex
    End Sub

End Class
