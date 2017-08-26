Imports Microsoft.Win32

Module Funciones
    Private ConnectionString As String = Nothing
    Private ConnectionString2 As String = Nothing

    'Para conectarse al servidor
    'Public Nombre_Servidor As String = "192.168.2.82"  ' Cliente
    Public Nombre_Servidor As String = "201.139.106.58"   'Remotamente 
    'Public Nombre_Servidor As String = "localhost"
    Public Nombre_Bd As String = Nothing
    'Para acceder a la base

    Public UsuarioBD As String = Nothing
    Public PasswordBD As String = Nothing

    Public Function GetConnectionStringIpp() As String
        ConnectionString = "Data Source= " + Nombre_Servidor + ";"
        ConnectionString += "Initial Catalog= ipp;user id=sicossadmi;password=ipp2012;"
        'ConnectionString += "Initial Catalog= ipp;user id=jessyka;password=atajessyka;"
        Return ConnectionString
    End Function
    Public Function GetConnectionStringHitss() As String
        ConnectionString = "Data Source= " + Nombre_Servidor + ";"
        ConnectionString += "Initial Catalog= hitss;user id=sicossadmi;password=ipp2012;"
        'ConnectionString += "Initial Catalog= hitss;user id=jessyka;password=atajessyka;"
        Return ConnectionString
    End Function
    Public Function GetConnectionStringHaberes() As String
        ConnectionString = "Data Source= " + Nombre_Servidor + ";"
        ConnectionString += "Initial Catalog= Haberes;user id=sicossadmi;password=ipp2012;"
        'ConnectionString += "Initial Catalog= Haberes;Integrated Security=True;"
        Return ConnectionString
    End Function
 
    Public Function CalculaEdad(ByVal fechaNac) As Int32
        Dim fecha As Date
        Dim edad As Int32
        fecha = Now()
        edad = DatePart(DateInterval.Year, fecha) - DatePart(DateInterval.Year, fechaNac)
        Return edad
    End Function

    Public Function ObtieneSeguroVida(ByVal c As clsEmpleadoEdad) As Double
        Select Case CalculaEdad(c.FechaNacimiento) '1-Mujer 0-Hombre
            Case 0 To 19
                If c.Sexo = 0 Then : Return 2833.27
                Else : Return 2833.57 : End If
            Case 20 To 24
                If c.Sexo = 0 Then : Return 4001.13
                Else : Return 5778.66 : End If
            Case 25 To 29
                If c.Sexo = 0 Then : Return 4071.69
                Else : Return 6718.63 : End If
            Case 30 To 34
                If c.Sexo = 0 Then : Return 4251.49
                Else : Return 7613.08 : End If
            Case 35 To 39
                If c.Sexo = 0 Then : Return 4604.26
                Else : Return 8423.32 : End If
            Case 40 To 44
                If c.Sexo = 0 Then : Return 5175.53
                Else : Return 9149.35 : End If
            Case 45 To 49
                If c.Sexo = 0 Then : Return 6591.18
                Else : Return 10592.31 : End If
            Case 50 To 54
                If c.Sexo = 0 Then : Return 8559.88
                Else : Return 12388.04 : End If
            Case 55 To 59
                If c.Sexo = 0 Then : Return 11270.55
                Else : Return 13985.76 : End If
            Case 60 To 64
                If c.Sexo = 0 Then : Return 15178.37
                Else : Return 15178.37 : End If
            Case 65 To 69
                If c.Sexo = 0 Then : Return 18194.01
                Else : Return 18194.01 : End If
            Case 70 To 74
                If c.Sexo = 0 Then : Return 27291.02
                Else : Return 27291.02 : End If
        End Select
        Return 0
    End Function

    Public Function ObtieneSeguroVidaBaja(ByVal c As clsEmpleadoBaja) As Double
        Select Case CalculaEdad(c.FechaNacimiento) '1-Mujer 0-Hombre
            Case 0 To 19
                If c.sexo = 0 Then : Return 2833.27
                Else : Return 2833.57 : End If
            Case 20 To 24
                If c.sexo = 0 Then : Return 4001.13
                Else : Return 5778.66 : End If
            Case 25 To 29
                If c.sexo = 0 Then : Return 4071.69
                Else : Return 6718.63 : End If
            Case 30 To 34
                If c.sexo = 0 Then : Return 4251.49
                Else : Return 7613.08 : End If
            Case 35 To 39
                If c.sexo = 0 Then : Return 4604.26
                Else : Return 8423.32 : End If
            Case 40 To 44
                If c.sexo = 0 Then : Return 5175.53
                Else : Return 9149.35 : End If
            Case 45 To 49
                If c.sexo = 0 Then : Return 6591.18
                Else : Return 10592.31 : End If
            Case 50 To 54
                If c.sexo = 0 Then : Return 8559.88
                Else : Return 12388.04 : End If
            Case 55 To 59
                If c.sexo = 0 Then : Return 11270.55
                Else : Return 13985.76 : End If
            Case 60 To 64
                If c.sexo = 0 Then : Return 15178.37
                Else : Return 15178.37 : End If
            Case 65 To 69
                If c.sexo = 0 Then : Return 18194.01
                Else : Return 18194.01 : End If
            Case 70 To 74
                If c.sexo = 0 Then : Return 27291.02
                Else : Return 27291.02 : End If
        End Select
        Return 0
    End Function

    Public Function ObtieneSeguroVida(ByVal c As clsNomina) As Double
        Select Case CalculaEdad(c.FechaNacimiento) '1-Mujer 0-Hombre
            Case 0 To 19
                If c.sexo = 0 Then : Return 2833.27
                Else : Return 2833.57 : End If
            Case 20 To 24
                If c.sexo = 0 Then : Return 4001.13
                Else : Return 5778.66 : End If
            Case 25 To 29
                If c.sexo = 0 Then : Return 4071.69
                Else : Return 6718.63 : End If
            Case 30 To 34
                If c.sexo = 0 Then : Return 4251.49
                Else : Return 7613.08 : End If
            Case 35 To 39
                If c.sexo = 0 Then : Return 4604.26
                Else : Return 8423.32 : End If
            Case 40 To 44
                If c.sexo = 0 Then : Return 5175.53
                Else : Return 9149.35 : End If
            Case 45 To 49
                If c.sexo = 0 Then : Return 6591.18
                Else : Return 10592.31 : End If
            Case 50 To 54
                If c.sexo = 0 Then : Return 8559.88
                Else : Return 12388.04 : End If
            Case 55 To 59
                If c.sexo = 0 Then : Return 11270.55
                Else : Return 13985.76 : End If
            Case 60 To 64
                If c.sexo = 0 Then : Return 15178.37
                Else : Return 15178.37 : End If
            Case 65 To 69
                If c.sexo = 0 Then : Return 18194.01
                Else : Return 18194.01 : End If
            Case 70 To 74
                If c.sexo = 0 Then : Return 27291.02
                Else : Return 27291.02 : End If
        End Select
        Return 0
    End Function

    Public Function FechaUltimo(ByVal FActual As Date) As Date
        Return DateSerial(Year(FActual), Month(FActual) + 1, 0) 'Ultimo dia del mes
    End Function

    Public Function FechaInicio(ByVal FActual As Date) As Date
        Return DateSerial(Year(FActual), Month(FActual) + 0, 1) 'Primer dia del mes
    End Function

    Public Function ConvierteSexoDeCURP(ByVal curp As String) As Int32
        If curp.Substring(10, 1) = "M" Then
            Return 1
        Else
            Return 0
        End If
    End Function
    Public Function ConvierteFechaNacDeCURP(ByVal curp As String) As Date
        Try
            Return CDate(curp.Substring(8, 2) & "/" & curp.Substring(6, 2) & "/" & curp.Substring(4, 2))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error en CURP")
        End Try
    End Function
    Public Class InvalidRegistryException
        Inherits ApplicationException

        Public Sub New(ByVal Message As String)
            MyBase.New(Message)
        End Sub
    End Class
End Module
