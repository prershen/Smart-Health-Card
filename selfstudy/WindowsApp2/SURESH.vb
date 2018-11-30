Public Class SURESH
    Public Property ret As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        VIEW_SURESH.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ret.StartsWith("RAMESHSURESH") Then
            RAMESH.ret = "SURESH"
            RAMESH.Show()

            Me.Close()
        ElseIf ret.StartsWith("RAMESH") Then
            RAMESH.ret = ""
            RAMESH.Show()

            Me.Close()

        End If

        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ADD_TO_SURESH.Show()

    End Sub

    Private Sub SURESH_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class