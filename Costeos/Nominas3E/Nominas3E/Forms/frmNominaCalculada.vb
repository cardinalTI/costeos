Public Class frmNominaCalculada
    Public NominasCalculadas As Int32 = Nothing
    Private Sub frmNominaCalculada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        Me.NominasCalculadas = 1
        Me.Close()
    End Sub

    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        Me.NominasCalculadas = 2
        Me.Close()
    End Sub


    Public Overloads Sub Show(ByRef frmParent As Form)
        Try
            Me.ShowDialog()
            MyBase.ShowDialog(frmParent)
        Catch ex As Exception
            MsgBox("Error no controlado", MsgBoxStyle.Critical, "Error")
            Me.Close()
        End Try
    End Sub
End Class