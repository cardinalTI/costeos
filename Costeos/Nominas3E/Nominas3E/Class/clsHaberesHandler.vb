
Imports System.Data.SqlClient
Public Class clsHaberesHandler
    Private m_Conn As String

    Public Sub New(ByVal connectionString As String)
        Me.m_Conn = connectionString
    End Sub
    Public Function AgregarHaberesT(ByVal c As clsHaberes) As Int32
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Dim idHaberes As Int32

            Using comm As New SqlCommand("spAgregarHaberesT", conn)
                With comm
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.AddWithValue("@Cliente", c.Cliente)
                    .Parameters.AddWithValue("@Nomina", c.Nomina)
                    .Parameters.AddWithValue("@Mes", c.Mes)
                    .Parameters.AddWithValue("@NumeroNomina", c.NumeroNomina)
                    .Parameters.AddWithValue("@Año", c.Año)
                    .Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output
                End With

                comm.CommandTimeout = 20000
                conn.Open()
                comm.ExecuteNonQuery()
                idHaberes = comm.Parameters("@id").Value
            End Using
            Return idHaberes
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo insertar los haberes... " + ex.Message)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function
    Public Function AgregarHaberesEmpleadosT(ByVal c As clsHaberesEmpleado) As Int32
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Using comm As New SqlCommand("spAgregarHaberesEmpleadoT", conn)
                With comm
                    .CommandType = CommandType.StoredProcedure
                    .CommandTimeout = 20000
                    .Parameters.AddWithValue("@id", c.IdHaberes)
                    .Parameters.AddWithValue("@NumeroEmpleado", c.NumeroEmpleado)
                    .Parameters.AddWithValue("@NombreEmpleado", c.NombreEmpleado)
                    .Parameters.AddWithValue("@Monto", c.Haberes)
                    .Parameters.AddWithValue("@IAS", c.IAS)
                End With

                conn.Open()
                comm.ExecuteNonQuery()
            End Using
            Return c.Haberes
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo insertar los haberes del empleado (" + c.NombreEmpleado + ")... " + ex.Message)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function
    Public Sub EliminaHaberesNominaMes(ByVal Cliente As String, ByVal Mes As Int32, ByVal NumNom As Int32)
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Using comm As New SqlCommand("spEliminaNominaMes", conn)
                With comm
                    .CommandType = CommandType.StoredProcedure
                    .CommandTimeout = 20000
                    .Parameters.AddWithValue("@cliente", Cliente)
                    .Parameters.AddWithValue("@mes", Mes)
                    .Parameters.AddWithValue("@numNomina", NumNom)
                End With

                conn.Open()
                comm.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo eliminar los haberes del mes (" + Mes + ")... " + ex.Message)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Sub

    Public Function ObtenerHaberesAnual(ByVal Cliente As String, ByVal aann As String) As ArrayList


        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Dim arrHAnual As ArrayList
            arrHAnual = New ArrayList
            Using comm As New SqlCommand("spObtenerHaberesAnual", conn)
                comm.CommandType = CommandType.StoredProcedure
                comm.Parameters.AddWithValue("@cliente", Cliente)
                comm.Parameters.AddWithValue("@annn", aann)

                conn.Open()
                dr = comm.ExecuteReader
                While dr.Read
                    Dim c As clsHaberesAnual
                    c = New clsHaberesAnual(dr("id"), dr("Cliente"), dr("Nomina"), dr("Empleado"), dr("Nombre"), CDbl(dr("Enero")), CDbl(dr("Febrero")), CDbl(dr("Marzo")), CDbl(dr("Abril")), CDbl(dr("Mayo")), CDbl(dr("Junio")), CDbl(dr("Julio")), CDbl(dr("Agosto")), CDbl(dr("Septiembre")), CDbl(dr("Octubre")), CDbl(dr("Noviembre")), CDbl(dr("Diciembre")), CDbl(dr("Excedente")))
                    arrHAnual.Add(c)
                End While
                dr.Close()
            End Using
            Return arrHAnual
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo obtener Haberes Anual de: " & Cliente)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function
    Public Function ObtenerHaberesNominaEmpleado(ByVal Cliente As String, ByVal Empleado As String, ByVal an As String) As ArrayList
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Dim arrHAnual As ArrayList
            arrHAnual = New ArrayList
            Using comm As New SqlCommand("spObtenerNominaEmpleado", conn)
                comm.CommandType = CommandType.StoredProcedure
                comm.Parameters.AddWithValue("@Cliente", Cliente)
                comm.Parameters.AddWithValue("@NumeroEmpleado", Empleado)
                comm.Parameters.AddWithValue("@an", an)
                conn.Open()
                dr = comm.ExecuteReader
                While dr.Read
                    Dim c As clsHaberesNominaEmpleado
                    c = New clsHaberesNominaEmpleado(dr("Cliente"), dr("Nomina"), dr("NumeroEmpleado"), dr("NombreEmpleado"), CInt(dr("Mes")), CInt(dr("NumeroNomina")), CDbl(dr("Monto")))
                    arrHAnual.Add(c)
                End While
                dr.Close()
            End Using
            Return arrHAnual
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo obtener la Nomina del Empleado: " & Empleado)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function
    Public Function ObtenerHabClienteEmpleado(ByVal TipoB As Int32, ByVal Buscar As String, ByVal an As String) As clsHaberesBusqueda
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Dim c As clsHaberesBusqueda
            Using comm As New SqlCommand("spBuscarEmpleado", conn)
                comm.CommandType = CommandType.StoredProcedure
                comm.Parameters.AddWithValue("@TipoB", TipoB)
                comm.Parameters.AddWithValue("@Buscar", Buscar)
                comm.Parameters.AddWithValue("@an", an)

                conn.Open()
                dr = comm.ExecuteReader
                If dr.Read Then
                    c = New clsHaberesBusqueda(dr("Cliente"), dr("NumeroEmpleado"), dr("Año"))
                End If
                dr.Close()
            End Using
            Return c
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo obtener los datos del empleado")
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function
    Public Sub PasarTablaTemporal()
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Using comm As New SqlCommand("spPasarTemporal_A_Haberes", conn)
                comm.CommandType = CommandType.StoredProcedure
                comm.CommandTimeout = 20000
                conn.Open()
                comm.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo pasar la informacion a la Base de Datos... " + ex.Message)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Sub
    Public Sub EliminaTemporal()
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Using comm As New SqlCommand("spEliminaTemporal", conn)
                comm.CommandType = CommandType.StoredProcedure
                comm.CommandTimeout = 20000
                conn.Open()
                comm.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo eliminar la informacion a la Base de Datos... " + ex.Message)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Sub
    
    Public Function ObtenerInfoAnterior() As String
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Dim info As String = ""
            Dim nom As String = ""
            Dim ban As Boolean = False
            Using comm As New SqlCommand("select h.Cliente, h.Nomina, h.Mes, h.NumeroNomina, sum(e.Monto) as Monto from HaberesT h inner join EmpleadoHaberesT e on h.idHaberes=e.idHaberes group by h.Cliente,h.Nomina, h.Mes, h.NumeroNomina,e.idHaberes", conn)
                comm.CommandType = CommandType.Text
                comm.CommandTimeout = 20000
                conn.Open()
                dr = comm.ExecuteReader
                While dr.Read
                    If ban = False Then
                        info = dr("Cliente") & vbCrLf & dr("Nomina") & vbCrLf & "MES: " & dr("Mes") & vbCrLf & vbCrLf
                        Select Case dr("Nomina")
                            Case "NOMINA SEMANAL"
                                nom = "Semana "
                            Case "NOMINA QUINCENAL"
                                nom = "Quincena "
                        End Select
                        ban = True
                    End If
                    info += nom & dr("NumeroNomina") & ": " & dr("Monto") & vbCrLf
                End While
                dr.Close()
            End Using
            Return info
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo obtener los datos en Base de Datos... " + ex.Message)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function
    Public Function ObtenerInfoMeses() As ArrayList
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Dim arrInfo As ArrayList
            arrInfo = New ArrayList
            Dim c As clsMesesMontos
            Dim nom As String = ""
            Dim ban As Boolean = False
            'Using comm As New SqlCommand("select h.Cliente, h.Mes,DATENAME(Month,DATEADD(month,h.Mes,0)-1) as NMes, sum(e.Monto)as Monto from Haberes h inner join EmpleadoHaberes e on h.idHaberes=e.idHaberes group by h.Cliente, h.Mes", conn)
            Using comm As New SqlCommand("select h.Cliente,h.Nomina,h.Mes,h.Año,DATENAME(Month,DATEADD(month,h.Mes,0)-1) as NMes,h.NumeroNomina, sum(e.Monto)as Monto from Haberes h inner join EmpleadoHaberes e on h.idHaberes=e.idHaberes group by h.Cliente,h.Nomina, h.Mes, h.NumeroNomina, h.Año order by h.Cliente", conn)
                comm.CommandType = CommandType.Text
                comm.CommandTimeout = 20000
                conn.Open()
                dr = comm.ExecuteReader
                While dr.Read
                    c = New clsMesesMontos(dr("Cliente"), dr("Nomina"), dr("Mes"), dr("NMes"), dr("NumeroNomina"), CDbl(dr("Monto")), dr("Año"))
                    arrInfo.Add(c)
                End While
                dr.Close()
            End Using
            Return arrInfo
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo obtener los datos en Base de Datos... " + ex.Message)
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function


    Public Function ObtieneTotalAnualHaberes() As Double
        Dim conn As New SqlConnection(Me.m_Conn)
        Dim dr As SqlDataReader
        Try
            Dim total As Double
            Using comm As New SqlCommand("select case when SUM(Monto) is null then 0 else SUM(Monto) end as Total from EmpleadoHaberes", conn)
                comm.CommandType = CommandType.Text
                conn.Open()
                dr = comm.ExecuteReader
                If (dr.Read) Then
                    total = CDbl(dr("Total"))
                End If
                dr.Close()
            End Using
            Return total
        Catch ex As Exception
            Try
                dr.Close()
            Catch ex1 As Exception
            End Try
            Throw New ObtenerListaEdadesException("No se pudo obtener el total de Haberes")
        Finally
            Try
                conn.Close()
            Catch ex As Exception
            End Try
            Try
                conn.Dispose()
            Catch ex As Exception
            End Try
        End Try
    End Function

    

    Public Class ObtenerListaEdadesException
        Inherits ApplicationException
        Public Sub New(ByVal strMessage As String)
            MyBase.New(strMessage)
        End Sub
    End Class
End Class