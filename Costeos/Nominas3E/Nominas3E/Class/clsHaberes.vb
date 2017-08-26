Public Class clsHaberes
    Private m_idHaberes As Int32
    Private m_Cliente As String
    Private m_Nomina As String
    Private m_Mes As Int32
    Private m_Año As Int32
    Private m_NumeroNomina As Int32
    Private m_arrEmpleados As ArrayList

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
    Public ReadOnly Property Mes As Int32
        Get
            Return Me.m_Mes
        End Get
    End Property
    Public ReadOnly Property Año As Int32
        Get
            Return Me.m_Año
        End Get
    End Property
    Public ReadOnly Property NumeroNomina As Int32
        Get
            Return Me.m_NumeroNomina
        End Get
    End Property

    Public Property IdHaberes As Int32
        Set(ByVal value As Int32)
            Me.m_idHaberes = value
        End Set
        Get
            Return Me.m_idHaberes
        End Get
    End Property

    Public Property arrEmpleadosHaberes As ArrayList
        Set(ByVal value As ArrayList)
            Me.m_arrEmpleados = value
        End Set
        Get
            Return Me.m_arrEmpleados
        End Get
    End Property

    Public Sub New(ByVal Cliente As String, ByVal Nomina As String, ByVal Mes As Int32, ByVal NumeroNomina As Int32, ByVal Año As Int32) ', ByVal NumeroEmpleado As String, ByVal NombreEmpleado As String, ByVal Haberes As Double, ByVal IAS As Int32)
        Me.m_Cliente = Cliente
        Me.m_Nomina = Nomina
        Me.m_Mes = Mes
        Me.m_Año = Año
        Me.m_NumeroNomina = NumeroNomina
    End Sub
    Public Sub New(ByVal Cliente As String, ByVal Nomina As String, ByVal Mes As Int32, ByVal NumeroNomina As Int32, ByVal arrEmpleados As ArrayList)
        Me.m_Cliente = Cliente
        Me.m_Nomina = Nomina
        Me.m_Mes = Mes
        Me.m_NumeroNomina = NumeroNomina
        Me.arrEmpleadosHaberes = arrEmpleados
    End Sub
End Class

Public Class clsHaberesBusqueda
    Private m_Cliente As String
    Private m_Empleado As String
    Private m_ann As String

    Public ReadOnly Property Cliente As String
        Get
            Return Me.m_Cliente
        End Get
    End Property
    Public ReadOnly Property Empleado As String
        Get
            Return Me.m_Empleado
        End Get
    End Property
    Public ReadOnly Property ann As String
        Get
            Return Me.m_ann
        End Get
    End Property
    Public Sub New(ByVal Cliente As String, ByVal Empleado As String, ByVal ann As String)
        Me.m_Cliente = Cliente
        Me.m_Empleado = Empleado
        Me.m_ann = ann
    End Sub
End Class

Public Class clsHaberesEmpleado
    Private m_IdHaberes As Int32
    Private m_NumeroEmpleado As String
    Private m_NombreEmpleado As String
    Private m_Haberes As Double ' Monto
    Private m_IAS As Int32
    Public ReadOnly Property IdHaberes As Int32
        Get
            Return Me.m_IdHaberes
        End Get
    End Property
    Public ReadOnly Property NumeroEmpleado As String
        Get
            Return Me.m_NumeroEmpleado
        End Get
    End Property
    Public ReadOnly Property NombreEmpleado As String
        Get
            Return Me.m_NombreEmpleado
        End Get
    End Property
    Public ReadOnly Property Haberes As Double
        Get
            Return Me.m_Haberes
        End Get
    End Property
    Public ReadOnly Property IAS As Int32
        Get
            Return Me.m_IAS
        End Get
    End Property

    Public Sub New(ByVal idHaberes As Int32, ByVal NumeroEmpleado As String, ByVal NombreEmpleado As String, ByVal Haberes As Double, ByVal IAS As Int32)
        Me.m_IdHaberes = idHaberes
        Me.m_NumeroEmpleado = NumeroEmpleado
        Me.m_NombreEmpleado = NombreEmpleado
        Me.m_Haberes = Haberes
        Me.m_IAS = IAS
    End Sub
End Class

Public Class clsMesesMontos
    Private m_Cliente As String
    Private m_Nomina As String
    Private m_idMes As Int32
    Private m_Mes As String
    Private m_NumNomina As Int32
    Private m_Monto As Double
    Private m_an As String
    Public ReadOnly Property Cliente As String
        Get
            Return Me.m_Cliente
        End Get
    End Property
    Public ReadOnly Property Nomina As String 'Nomina Quincenal, Mensual, Semana, Catorcenal
        Get
            Return Me.m_Nomina
        End Get
    End Property
    Public ReadOnly Property idMes As Int32
        Get
            Return Me.m_idMes
        End Get
    End Property
    Public ReadOnly Property Mes As String
        Get
            Return Me.m_Mes
        End Get
    End Property
    Public ReadOnly Property an As String
        Get
            Return Me.m_an
        End Get
    End Property
    Public ReadOnly Property NumNomina As Int32
        Get
            Return Me.m_NumNomina
        End Get
    End Property
    Public ReadOnly Property Monto As Double
        Get
            Return Me.m_Monto
        End Get
    End Property
    Public Sub New(ByVal Cliente As String, ByVal Nomina As String, ByVal idMes As Int32, ByVal Mes As String, ByVal NumNomina As Int32, ByVal Monto As Double, ByVal an As String)
        Me.m_Cliente = Cliente
        Me.m_Nomina = Nomina
        Me.m_idMes = idMes
        Me.m_Mes = Mes
        Me.m_NumNomina = NumNomina
        Me.m_Monto = Monto
        Me.m_an = an

    End Sub
End Class
