Public Class clsEmpleadoBaja
    Private m_TarjetaID As String
    Private m_TrabID As String
    Private m_FechaBaja As Date
    Private m_Mov As String
    Private m_Nomina As Boolean
    Private m_cNomina As clsNomina
    Private m_cEdad As clsEmpleadoEdad


    Private m_Tarjeta_Id As String
    Private m_FechaNacimiento As Date
    Private m_Sexo As Int32 '1-Mujer 0-Hombre
    Private m_SeguroGMM As Nullable(Of Double)
    Private m_Curp As String
    Private m_Movi As String 'Ultimo movimiento A-Alta, B-Baja, R-Reingreso
    Private m_FecMov As Date 'Fecha ultimo movimiento
    Private m_TipoCaso2 As Int32 'Tipo Caso
    Private m_Flexible As Double 'Flexible Bruto que se saca de la ultima quincena

    Public Property Tarjeta_Id() As String
        Get
            Return Me.m_Tarjeta_Id
        End Get
        Set(value As String)
            Me.m_Tarjeta_Id = value
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

    Public ReadOnly Property TarjetaID As String
        Get
            Return m_TarjetaID
        End Get
    End Property
    Public ReadOnly Property TrabID As String
        Get
            Return m_TrabID
        End Get
    End Property
    Public ReadOnly Property FechaBaja As Date
        Get
            Return m_FechaBaja
        End Get
    End Property
    Public ReadOnly Property Mov As String
        Get
            Return Me.m_Mov
        End Get
    End Property
    Public Property NominaActual As Boolean
        Set(ByVal value As Boolean)
            Me.m_Nomina = value
        End Set
        Get
            Return Me.m_Nomina
        End Get
    End Property
    Public Property NominaEmpleado As clsNomina
        Set(ByVal value As clsNomina)
            Me.m_cNomina = value
        End Set
        Get
            Return Me.m_cNomina
        End Get
    End Property
    Public Property EdadEmpleado As clsEmpleadoEdad
        Set(ByVal value As clsEmpleadoEdad)
            Me.m_cEdad = value
        End Set
        Get
            Return Me.m_cEdad
        End Get
    End Property
    Public Sub New(ByVal m_TarjetaID As String, ByVal m_TrabID As String, ByVal m_FechaBaja As Date, ByVal m_Mov As String, ByVal m_NominaActual As Boolean)
        Me.m_TarjetaID = m_TarjetaID
        Me.m_TrabID = m_TrabID
        Me.m_FechaBaja = m_FechaBaja
        Me.m_Mov = m_Mov
        Me.m_Nomina = m_NominaActual
    End Sub
End Class
