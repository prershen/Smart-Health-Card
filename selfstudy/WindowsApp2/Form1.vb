' Arduino and Visual Basic: Receiving Data From the Arduino
' A simple example of recing data from an Arduino
'


Imports System
Imports System.IO.Ports

Public Class Form1
    Public Property ret As String
    Dim comPORT As String
    Dim receivedData As String = ""


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        comPORT = ""
        For Each sp As String In My.Computer.Ports.SerialPortNames
            comPort_ComboBox.Items.Add(sp)
        Next
    End Sub


    Private Sub comPort_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comPort_ComboBox.SelectedIndexChanged
        If (comPort_ComboBox.SelectedItem <> "") Then
            comPORT = comPort_ComboBox.SelectedItem
        End If
    End Sub


    Private Sub connect_BTN_Click(sender As Object, e As EventArgs) Handles connect_BTN.Click
        Dim ram As New RAMESH
        Dim sur As New SURESH
        If (connect_BTN.Text = "Connect") Then
            If (comPORT <> "") Then
                SerialPort1.Close()
                SerialPort1.PortName = comPORT
                SerialPort1.BaudRate = 9600
                SerialPort1.DataBits = 8
                SerialPort1.Parity = Parity.None
                SerialPort1.StopBits = StopBits.One
                SerialPort1.Handshake = Handshake.None
                SerialPort1.Encoding = System.Text.Encoding.Default 'very important!
                SerialPort1.ReadTimeout = 10000

                SerialPort1.Open()
                connect_BTN.Text = "Dis-connect"
                TIMER_LBL.Text = "SERIAL PORT: OPENED"
                Dim Incoming As String

                Dim name1 As String = "RAMESH"
                Dim name2 As String = "SURESH"

                Try
                    Incoming = SerialPort1.ReadLine()
                    If Incoming IsNot Nothing Then
                        ret = Incoming
                        RichTextBox1.Text &= ret
                    End If
                Catch ex As TimeoutException
                    RichTextBox1.Text &= "Error: Serial Port read timed out."
                End Try

                If ret.StartsWith("RAMESHSURESHRAMESH") Then

                    RichTextBox1.Text &= "Opening RAMESH..."
                    ram.ret = "SURESHRAMESH"
                    ram.ShowDialog()

                    SerialPort1.Close()
                    connect_BTN.Text = "Connect"
                    TIMER_LBL.Text = "SERIAL PORT: CLOSED"

                ElseIf ret.StartsWith("SURESHRAMESHSURESH") Then

                    RichTextBox1.Text &= "Opening SURESH..."
                    sur.ret = "RAMESHSURESH"
                    sur.ShowDialog()

                    SerialPort1.Close()
                    connect_BTN.Text = "Connect"
                    TIMER_LBL.Text = "SERIAL PORT: CLOSED"


                End If
            Else
                MsgBox("Select a COM port first")
            End If
        Else
            SerialPort1.Close()
            connect_BTN.Text = "Connect"
            TIMER_LBL.Text = "SERIAL PORT: CLOSED"
        End If


    End Sub

    Private Sub clear_BTN_Click(sender As Object, e As EventArgs) Handles clear_BTN.Click
        RichTextBox1.Text = ""
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub
End Class
