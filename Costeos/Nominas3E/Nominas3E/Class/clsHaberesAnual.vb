Public Class clsHaberesAnual
    Private m_Id As Int32
    Private m_Cliente As String
    Private m_Nomina As String
    Private m_Empleado As String
    Private m_NombreEmpleado As String
    Private m_Mes1 As Double
    Private m_Mes2 As Double
    Private m_Mes3 As Double
    Private m_Mes4 As Double
    Private m_Mes5 As Double
    Private m_Mes6 As Double
    Private m_Mes7 As Double
    Private m_Mes8 As Double
    Private m_Mes9 As Double
    Private m_Mes10 As Double
    Private m_Mes11 As Double
    Private m_Mes12 As Double
    Private m_Excedente As Double

    Public ReadOnly Property Id As Int32
        Get
            Return Me.m_Id
        End Get
    End Property
    Public ReadOnly Property Cliente As String
        Get
            Return Me.m_Cliente
        End Get
    End Property
    Public ReadOnly Property Nomina As String
        Get
            Return Me.m_Nomina
        End Get
    End Property
    Public ReadOnly Property Empleado As String
        Get
            Return Me.m_Empleado
        End Get
    End Property
    Public ReadOnly Property NombreEmpleado As String
        Get
            Return Me.m_NombreEmpleado
        End Get
    End Property
    Public ReadOnly Property M1 As Double
        Get
            Return Me.m_Mes1
        End Get
    End Property
    Public ReadOnly Property M2 As Double
        Get
            Return Me.m_Mes2
        End Get
    End Property
    Public ReadOnly Property M3 As Double
        Get
            Return Me.m_Mes3
        End Get
    End Property
    Public ReadOnly Property M4 As Double
        Get
            Return Me.m_Mes4
        End Get
    End Property
    Public ReadOnly Property M5 As Double
        Get
            Return Me.m_Mes5
        End Get
    End Property
    Public ReadOnly Property M6 As Double
        Get
            Return Me.m_Mes6
        End Get
    End Property
    Public ReadOnly Property M7 As Double
        Get
            Return Me.m_Mes7
        End Get
    End Property
    Public ReadOnly Property M8 As Double
        Get
            Return Me.m_Mes8
        End Get
    End Property
    Public ReadOnly Property M9 As Double
        Get
            Return Me.m_Mes9
        End Get
    End Property
    Public ReadOnly Property M10 As Double
        Get
            Return Me.m_Mes10
        End Get
    End Property
    Public ReadOnly Property M11 As Double
        Get
            Return Me.m_Mes11
        End Get
    End Property
    Public ReadOnly Property M12 As Double
        Get
            Return Me.m_Mes12
        End Get
    End Property
    Public ReadOnly Property Excedente As Double
        Get
            Return Me.m_Excedente
        End Get
    End Property

    Public Sub New(ByVal id As Int32, ByVal Cliente As String, ByVal Nomina As String, ByVal Empleado As String, ByVal NombreEmpleado As String, ByVal Ene As Double, ByVal Feb As Double, ByVal Mar As Double, ByVal Abr As Double, ByVal May As Double, ByVal Jun As Double, ByVal Jul As Double, ByVal Ago As Double, ByVal Sep As Double, ByVal Oct As Double, ByVal Nov As Double, ByVal Dic As Double, ByVal Exc As Double)
        Me.m_Id = id
        Me.m_Cliente = Cliente
        Me.m_Nomina = Nomina
        Me.m_Empleado = Empleado
        Me.m_NombreEmpleado = NombreEmpleado
        Me.m_Mes1 = Ene
        Me.m_Mes2 = Feb
        Me.m_Mes3 = Mar
        Me.m_Mes4 = Abr
        Me.m_Mes5 = May
        Me.m_Mes6 = Jun
        Me.m_Mes7 = Jul
        Me.m_Mes8 = Ago
        Me.m_Mes9 = Sep
        Me.m_Mes10 = Oct
        Me.m_Mes11 = Nov
        Me.m_Mes12 = Dic
        Me.m_Excedente = Exc
    End Sub

End Class
