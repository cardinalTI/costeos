Public Class clsRT
    Private m_Centro As Integer
    Private m_RegPat_ID As Integer
    Private m_Ano As Integer
    Private m_Mes As Integer
    Private m_RT As Double
    Public ReadOnly Property Centro As Integer
        Get
            Return Me.m_Centro
        End Get
    End Property
    Public ReadOnly Property RegPat_ID As Integer
        Get
            Return Me.m_RegPat_ID
        End Get
    End Property
    Public ReadOnly Property Ano As Integer
        Get
            Return Me.m_Ano
        End Get
    End Property
    Public ReadOnly Property Mes As Integer
        Get
            Return Me.m_Mes
        End Get
    End Property
    Public ReadOnly Property RT As Double
        Get
            Return Me.m_RT
        End Get
    End Property
    Public ReadOnly Property MensajeRT As String
        Get
            Return "La columna IMSS-SAR-INFONAVIT esta tomando la prima de riesgo de Sicoss, es necesario ejecutar los procesos en Sicoss: " & Me.m_Ano.ToString() & "-" & Me.m_Mes.ToString() & "-->" & Me.m_RT.ToString()
        End Get
    End Property
    Public Sub New(ByVal Centro As Integer, ByVal RegPat_ID As Integer, ByVal Ano As Integer, ByVal Mes As Integer, ByVal RT As Double)
        Me.m_Centro = Centro
        Me.m_RegPat_ID = RegPat_ID
        Me.m_Ano = Ano
        Me.m_Mes = Mes
        Me.m_RT = RT
    End Sub
End Class
