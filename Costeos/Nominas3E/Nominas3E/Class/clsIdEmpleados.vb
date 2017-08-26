Public Class clsIdEmpleados
    Private m_IdEmpleado As Int32
    Private m_Cantidad As Int32
    Public ReadOnly Property IdEmpleado As Int32
        Get
            Return Me.m_IdEmpleado
        End Get
    End Property
    Public Property Cantidad As Int32
        Get
            Return Me.m_Cantidad
        End Get
        Set(ByVal value As Int32)
            Me.m_Cantidad = value
        End Set
    End Property
    Public Sub New(ByVal Empleado As Int32, ByVal Cant As Int32)
        Me.m_IdEmpleado = Empleado
        Me.m_Cantidad = Cant
    End Sub
End Class
