Public Class Form1
    Dim check1 = 0
    Dim intermitencia = 0
    Dim estado = 0
    Dim ip = "8.8.8.8"
    Dim timeout = 1000
    Dim sw = New Stopwatch()
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        MsgBox("Se aceptan donaciones en BTC o bandeja paisa")
    End Sub



   








    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.iw



        Label1.ForeColor = Color.ForestGreen
        Timer1.Enabled = True
        ContextMenuStrip1.Visible = False
        NotifyIcon1.Icon = Me.Icon
        NotifyIcon1.ContextMenuStrip = ContextMenuStrip1


    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick


        Try
            Dim ping As Long = -1
            sw.Start()
            If My.Computer.Network.Ping(ip, timeout) Then
                sw.Stop()
                ping = sw.ElapsedMilliseconds

            End If
            If ping < 0 Then
                Label1.ForeColor = Color.DarkRed
                Label3.Show()

                Label1.Text = "Intentos Fallidos: "
                check1 = check1 + 1
                Label3.Text = check1
            ElseIf ping > 0 Then
                Label1.ForeColor = Color.ForestGreen
                Label3.Show()

                Label1.Text = "Internet"
                Label3.Text = "OK"
                check1 = 0
            Else

            End If
        Catch ex As Exception
            Label4.Text = ex.Message
            Label4.BackColor = Color.Red
            Console.WriteLine(ex.ToString())
        End Try

        If check1 = 9 Then
            My.Computer.Audio.Play(My.Resources.alarma, AudioPlayMode.Background)
            Label3.Hide()
            Label1.Text = "Sin Internet :("
            NotifyIcon1.ShowBalloonTip(5, "ATENCION", "No hay Internet", ToolTipIcon.Warning)
            intermitencia = 0
            Timer1.Enabled = False
            Timer2.Enabled = True


        End If

        If check1 = 4 Then
            intermitencia = intermitencia + 1
        End If
        If intermitencia = 7 Then
            Label1.Text = "Internet Inestable"
            MsgBox("Mucha intermitencia", MsgBoxStyle.Critical)
            Label3.Hide()
            intermitencia = 0

        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try
            Dim ping As Long = -1
            sw.Start()
            If My.Computer.Network.Ping(ip, timeout) Then
                sw.Stop()
                ping = sw.ElapsedMilliseconds

            End If
            If ping < 0 Then
                Label1.ForeColor = Color.DarkRed
                Label3.Show()

                Label1.Text = "Intentos Fallidos: "
                check1 = check1 + 1
                Label3.Text = check1
            ElseIf ping > 0 Then
                Label1.ForeColor = Color.ForestGreen
                Label3.Show()
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
                Label1.Text = "Internet"
                Label3.Text = "OK"
                check1 = 0
                Timer1.Enabled = True
                Timer2.Enabled = False
            Else

            End If
        Catch ex As Exception
            Label4.Text = ex.Message
            Label4.BackColor = Color.Red
            Console.WriteLine(ex.ToString())
        End Try
        If check1 = 20 Then
            My.Computer.Audio.Play(My.Resources.alarma, AudioPlayMode.Background)
            NotifyIcon1.ShowBalloonTip(5, "ATENCION", "No hay Internet", ToolTipIcon.Warning)
        End If
        If check1 = 30 Then
            My.Computer.Audio.Play(My.Resources.alarma, AudioPlayMode.Background)
            NotifyIcon1.ShowBalloonTip(5, "ATENCION", "No hay Internet", ToolTipIcon.Warning)
        End If
        If check1 = 40 Then
            My.Computer.Audio.Play(My.Resources.alarma, AudioPlayMode.Background)
            NotifyIcon1.ShowBalloonTip(5, "ATENCION", "No hay Internet", ToolTipIcon.Warning)
        End If
        If check1 = 50 Then
            My.Computer.Audio.Play(My.Resources.alarma, AudioPlayMode.Background)
            NotifyIcon1.ShowBalloonTip(5, "ATENCION", "No hay Internet", ToolTipIcon.Warning)
        End If
        If check1 = 60 Then
            My.Computer.Audio.Play(My.Resources.alarma, AudioPlayMode.Background)
            NotifyIcon1.ShowBalloonTip(5, "ATENCION", "No hay Internet", ToolTipIcon.Warning)
        End If


    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

        estado = estado + 1
        If estado = 2 Then
            Label1.ForeColor = Color.ForestGreen
            Label3.Hide()
            Label1.Text = "Sistema Activado"
            estado = 0
            Timer1.Enabled = True

        Else
            Label1.ForeColor = Color.OrangeRed
            Label3.Hide()
            Label1.Text = "Sistema Desactivado"
            Timer1.Enabled = False
            Timer2.Enabled = False

        End If
        

    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click

        Me.Close()



    End Sub

    Private Sub MostrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MostrarToolStripMenuItem.Click
        Me.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()

    End Sub

    
   
End Class
