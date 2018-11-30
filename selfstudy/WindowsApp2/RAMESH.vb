
Public Class RAMESH
    Public Property ret As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        VIEW_RAMESH.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ret.StartsWith("SURESHRAMESH") Then
            SURESH.ret = "RAMESH"
            SURESH.Show()

            Me.Close()
        ElseIf ret.StartsWith("SURESH") Then
            SURESH.ret = ""
            SURESH.Show()

            Me.Close()

        End If
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ADD_TO_RAMESH.Show()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub RAMESH_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class