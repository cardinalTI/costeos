Public Class clsEmpleadoEdad
    Private m_TarjetaId As String
    Private m_FechaNacimiento As Date
    Private m_Sexo As Int32 '1-Mujer 0-Hombre
    Private m_SeguroGMM As Nullable(Of Double)
    Private m_Curp As String
    Private m_Mov As String 'Ultimo movimiento A-Alta, B-Baja, R-Reingreso
    Private m_FecMov As Date 'Fecha ultimo movimiento
    Private m_TipoCaso As Int32 'Tipo Caso
    Private m_Flexible As Double 'Flexible Bruto que se saca de la ultima quincena
    Public ReadOnly Property TarjetaId As String
        Get
            Return Me.m_TarjetaId
        End Get
    End Property
    Public ReadOnly Property FechaNacimiento As Date
        Get
            Return Me.m_FechaNacimiento
        End Get
    End Property
    Public ReadOnly Property Sexo As Int32
        Get
            Return Me.m_Sexo
        End Get
    End Property
    Public Property SeguroGMM As Nullable(Of Double)
        Get
            Return Me.m_SeguroGMM
        End Get
        Set(ByVal value As Nullable(Of Double))
            Me.m_SeguroGMM = value
        End Set
    End Property
    Public ReadOnly Property Curp As String
        Get
            Return Me.m_Curp
        End Get
    End Property
    Public ReadOnly Property Mov As String
        Get
            Return Me.m_Mov
        End Get
    End Property
    Public ReadOnly Property FechaMov As Date
        Get
            Return Me.m_FecMov
        End Get
    End Property
    Public ReadOnly Property TipoCaso As Int32
        Get
            Return Me.m_TipoCaso
        End Get
    End Property
    Public ReadOnly Property FlexibleBruto As Double
        Get
            Return Me.m_Flexible
        End Get
    End Property

    Public Sub New(ByVal Tarjeta_id As String, ByVal FechaNac As Date, ByVal Sexo As Int32, ByVal Curp As String)
        Me.m_TarjetaId = Tarjeta_id
        Me.m_FechaNacimiento = FechaNac
        Me.m_Sexo = Sexo
        Me.m_Curp = Curp
    End Sub
    'Public Sub New(ByVal Tarjeta_id As String, ByVal FechaNac As Date, ByVal Sexo As Int32, ByVal Curp As String, ByVal Mov As String, ByVal FechaMov As Date)
    '    Me.m_TarjetaId = Tarjeta_id
    '    Me.m_FechaNacimiento = FechaNac
    '    Me.m_Sexo = Sexo
    '    Me.m_Curp = Curp
    '    Me.m_Mov = Mov
    '    Me.m_FecMov = FechaMov
    'End Sub
    Public Sub New(ByVal Tarjeta_id As String, ByVal FechaNac As Date, ByVal Sexo As Int32, ByVal Curp As String, ByVal Mov As String, ByVal FechaMov As Date, ByVal TipoCaso As Int32, ByVal Flexible As Double)
        Me.m_TarjetaId = Tarjeta_id
        Me.m_FechaNacimiento = FechaNac
        Me.m_Sexo = Sexo
        Me.m_Curp = Curp
        Me.m_Mov = Mov
        Me.m_FecMov = FechaMov
        Me.m_TipoCaso = TipoCaso
        Me.m_Flexible = Flexible
    End Sub
    'Public Sub New(ByVal Tarjeta_id As String, ByVal FechaNac As Date, ByVal Sexo As Int32, ByVal Curp As String, ByVal SeguroGMM As Double)
    '    Me.m_TarjetaId = Tarjeta_id
    '    Me.m_FechaNacimiento = FechaNac
    '    Me.m_Sexo = Sexo
    '    Me.m_Curp = Curp
    '    Me.m_SeguroGMM = SeguroGMM
    'End Sub
End Class
