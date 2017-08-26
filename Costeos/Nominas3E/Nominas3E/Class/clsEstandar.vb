Public Class clsEstandar
    Private m_IdEmpleado As String
    Private m_Nombre As String
    Private m_IdEmpresa As String
    Private m_IdEmpresa_Intelisis As Int32
    Private m_RegistroPatronal As String
    Private m_Departamento As String
    Private m_Puesto As String
    Private m_CentroCosto As Int32
    Private m_FechaAntiguedad As Date
    Private m_AAntiguedad As Int32
    Private m_DiasVacaciones As Int32
    Private m_Moneda As String
    Private m_FechaConversion As Date
    Private m_FechaInicio As Date
    Private m_FechaFin As Date
    Private m_SueldoAnual As Double
    Private m_PrevisionSocial As Double
    Private m_Ias As Double
    Private m_AguinaldoAnual As Double
    Private m_PrimaVacAnual As Double
    Private m_BonoAnual As Double
    Private m_ImssSarInfonavitAnual As Double
    Private m_Isn As Double
    Private m_Sgmm As Double
    Private m_SeguroVida As Double
    Private m_ComisionNomina As Double
    'Se agregan
    Private m_SDI As Double
    Private m_Curp As String
    Private m_D3 As Double
    Private m_ProvisionBono As Double
    Private m_bonounico As Double
    Private m_bonoNegociacion As Double
    Private m_bonoEspecial As Double

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

    Public Property Antiguedad As Int32
        Get
            Return Me.m_AAntiguedad
        End Get
        Set(ByVal value As Int32)
            Me.m_AAntiguedad = value
        End Set
    End Property
    Public Property DiasVacaciones As Int32
        Get
            Return Me.m_DiasVacaciones
        End Get
        Set(ByVal value As Int32)
            Me.m_DiasVacaciones = value
        End Set
    End Property
   
    Public ReadOnly Property IdEmpleado As String
        Get
            Return m_IdEmpleado
        End Get
    End Property
    Public ReadOnly Property Nombre As String
        Get
            Return m_Nombre
        End Get
    End Property
    Public ReadOnly Property IdEmpresa As String
        Get
            Return m_IdEmpresa
        End Get
    End Property
    Public ReadOnly Property IdEmpresa_Intelisis As Int32
        Get
            Return m_IdEmpresa_Intelisis
        End Get
    End Property
    Public ReadOnly Property RegistroPatronal As String
        Get
            Return m_RegistroPatronal
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
    Public ReadOnly Property CentroCosto As Int32
        Get
            Return m_CentroCosto
        End Get
    End Property
    Public ReadOnly Property FechaAntiguedad As Date
        Get
            Return m_FechaAntiguedad
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
    Public ReadOnly Property FechaFin As Date
        Get
            Return m_FechaFin
        End Get
    End Property
    Public ReadOnly Property SueldoAnual As Double
        Get
            Return m_SueldoAnual
        End Get
    End Property
    Public ReadOnly Property PrevisionSocial As Double
        Get
            Return m_PrevisionSocial
        End Get
    End Property
    Public ReadOnly Property Ias As Double
        Get
            Return m_Ias
        End Get
    End Property
    Public ReadOnly Property AguinaldoAnual As Double
        Get
            Return m_AguinaldoAnual
        End Get
    End Property
    Public ReadOnly Property PrimaVacAnual As Double
        Get
            Return m_PrimaVacAnual
        End Get
    End Property
    Public ReadOnly Property BonoAnual As Double
        Get
            Return m_BonoAnual
        End Get
    End Property
    Public ReadOnly Property ImssSarInfonavitAnual As Double
        Get
            Return m_ImssSarInfonavitAnual
        End Get
    End Property
    Public ReadOnly Property Isn As Double
        Get
            Return m_Isn
        End Get
    End Property
    Public ReadOnly Property Sgmm As Double
        Get
            Return m_Sgmm
        End Get
    End Property
    Public ReadOnly Property SeguroVida As Double
        Get
            Return m_SeguroVida
        End Get
    End Property
    Public ReadOnly Property ComisionNomina As Double
        Get
            Return m_ComisionNomina
        End Get
    End Property
    Public ReadOnly Property SDI As Double
        Get
            Return Me.m_SDI
        End Get
    End Property
    Public ReadOnly Property Curp As String
        Get
            Return Me.m_Curp
        End Get
    End Property
    Public ReadOnly Property D3 As Double
        Get
            Return Me.m_D3
        End Get
    End Property
    Public ReadOnly Property ProvisionBono As Double
        Get
            Return Me.m_ProvisionBono
        End Get
    End Property
    Public Sub New(ByVal Id_Empleado As String, ByVal Nombre As String, ByVal Id_Empresa As String, ByVal Id_Empresa_Intelisis As Int32, ByVal Registro_Patronal As String,
                    ByVal Departamento As String, ByVal Puesto As String, ByVal Centro_Costo As Int32, ByVal Fecha_Antiguedad As Date, ByVal A_Antiguedad As Int32,
                    ByVal Dias_Vacaciones As Int32, ByVal Moneda As String, ByVal Fecha_Conversion As Date, ByVal Fecha_Inicio As Date, ByVal Fecha_Fin As Date,
                    ByVal Sueldo_Anual As Double, ByVal Prevision_Social As Double, ByVal Ias As Double, ByVal Aguinaldo_Anual As Double, ByVal Prima_Vac_Anual As Double,
                    ByVal Bono_Anual As Double, ByVal Imss_Sar_Infonavit_Anual As Double, ByVal Isn As Double, ByVal Sgmm As Double, ByVal Seguro_Vida As Double,
                    ByVal Comision_Nomina As Double, ByVal D3 As Double, ByVal ProvisionBono As Double, ByVal SDI As Double, ByVal Curp As String, ByVal bonounico As Double, ByVal bonoEpecial As Double, ByVal bonoNegociacion As Double)
        Me.m_IdEmpleado = Id_Empleado
        Me.m_Nombre = Nombre
        Me.m_IdEmpresa = Id_Empresa
        Me.m_IdEmpresa_Intelisis = Id_Empresa_Intelisis
        Me.m_RegistroPatronal = Registro_Patronal
        Me.m_Departamento = Departamento
        Me.m_Puesto = Puesto
        Me.m_CentroCosto = Centro_Costo
        Me.m_FechaAntiguedad = Fecha_Antiguedad
        Me.m_AAntiguedad = A_Antiguedad
        Me.m_DiasVacaciones = Dias_Vacaciones
        Me.m_Moneda = Moneda
        Me.m_FechaConversion = Fecha_Conversion
        Me.m_FechaInicio = Fecha_Inicio
        Me.m_FechaFin = Fecha_Fin
        Me.m_SueldoAnual = Sueldo_Anual
        Me.m_PrevisionSocial = Prevision_Social
        Me.m_Ias = Ias
        Me.m_AguinaldoAnual = Aguinaldo_Anual
        Me.m_PrimaVacAnual = Prima_Vac_Anual
        Me.m_BonoAnual = Bono_Anual
        Me.m_ImssSarInfonavitAnual = Imss_Sar_Infonavit_Anual
        Me.m_Isn = Isn
        Me.m_Sgmm = Sgmm
        Me.m_SeguroVida = Seguro_Vida
        Me.m_ComisionNomina = Comision_Nomina
        Me.m_D3 = D3
        Me.m_ProvisionBono = ProvisionBono
        Me.m_SDI = SDI
        Me.m_Curp = Curp
        Me.m_bonounico = bonounico
        Me.m_bonoNegociacion = bonoNegociacion
        Me.m_bonoEspecial = bonoEpecial
    End Sub
End Class
