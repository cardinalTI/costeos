Public Class clsHaberesNominaEmpleado
    Private m_Cliente As String
    Private m_Nomina As String
    Private m_Empleado As String
    Private m_NombreEmpleado As String
    Private m_Mes As Int32
    Private m_NoNomina As Int32
    Private m_Monto As Double

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
    Public ReadOnly Property Mes As Int32
        Get
            Return Me.m_Mes
        End Get
    End Property
    Public ReadOnly Property NoNomina As Int32
        Get
            Return Me.m_NoNomina
        End Get
    End Property
    Public ReadOnly Property Monto As Double
        Get
            Return Me.m_Monto
        End Get
    End Property

    Public Sub New(ByVal cliente As String, ByVal nomina As String, ByVal empleado As String, ByVal nombre As String, ByVal mes As Int32, ByVal noNomina As Int16, ByVal monto As Double)
        Me.m_Cliente = cliente
        Me.m_Nomina = nomina
        Me.m_Empleado = empleado
        Me.m_NombreEmpleado = nombre
        Me.m_Mes = mes
        Me.m_NoNomina = noNomina
        Me.m_Monto = monto
    End Sub

End Class
