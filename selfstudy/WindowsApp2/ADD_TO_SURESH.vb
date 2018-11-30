Imports System
Imports MySql.Data.MySqlClient
Public Class ADD_TO_SURESH
    Dim mysqlconn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;persistsecurityinfo=True;database=tequed;SslMode=none"

        Try
            mysqlconn.Open()
            MessageBox.Show("Connection successfull!")
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim todaysdate As Date = Date.Today
        'Dim thisDate As Date
        'thisDate = Today
        Dim dt As String = todaysdate.ToString("dd/MM/yyyy")
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=localhost;user id=root;persistsecurityinfo=True;database=tequed;SslMode=none"
        Dim READER As MySqlDataReader

        Dim blood As String

        blood = "O+"
        Try
            mysqlconn.Open()
            Dim Query As String
            Query = "insert into tequed.suresh(date,age,bloodgroup,source,history,fhm,fhf,symptoms,phyexam,diagnosis,plan) values ('" & dt & "','" & AGE.Text & "','" & blood & "','" & SOURCE.Text & "','" & HISTORY.Text & "','" & FHM.Text & "','" & FHF.Text & "','" & SYMPTOMS.Text & "','" & PHYEXAM.Text & "','" & DIAG.Text & "','" & PLAN.Text & "')"
            COMMAND = New MySqlCommand(Query, mysqlconn)
            READER = COMMAND.ExecuteReader

            MessageBox.Show("DATA SAVED!")
            Me.Close()
            mysqlconn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub ADD_TO_SURESH_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class