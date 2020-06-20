Imports System.Net.Sockets
Imports System.Threading
Imports System.Net
Imports System.Text
Imports System.IO
Public Class MainSV
    'PARA CONEXION
    Dim SERVIDOR As TcpListener
    Dim THREADSERVIDOR As Thread
    Dim PuertoSV As String
    Dim PuertoDB As String
    Dim ServerIP As String
    Dim RetroConnect As String
    Dim SeeAllCMD As Boolean
    Dim SaveChats As Boolean
    'NECESARIO PARA PODER TRABAJAR CON VARIOS CLIENTES A LA VEZ. CADA CLIENTE TIENE SU CONEXION, THREAD Y MENSAJE
    Private Structure NUEVOCLIENTE
        Public SOCKETCLIENTE As Socket
        Public THREADCLIENTE As Thread
        Public MENSAJE As String
    End Structure
    Dim CLIENTES As New Hashtable 'PARA ALMACENAR LOS NUEVOCLIENTE's ORDENADOS POR IP
    'PARA IDENTIFICACION
    Dim CLIENTEIP As IPEndPoint
    Dim USUARIO As String
    'PARA CHAT PRIVADOS
    Dim NOMBREPRIVADO As String
    Dim IPPRIVADO As String
    Dim PUERTOPRIVADO As String
    Private Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Our Speak Home | Server @ " & Environment.MachineName.ToString & "\" & Environment.UserName
        Try 'ELIMINA EL REGISTRO DE CONEXIONES POR SI NO FUE ELIMINADO AL CERRARSE ANTERIORMENTE
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\OSH_Connections.ini")
        Catch ex As Exception
        End Try
        Try
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\OSH_Config.ini") = False Then
                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\OSH_Config.ini", "#OSH Server Configuration File" &
                                                    vbCrLf & "PortSV>55555" &
                                                    vbCrLf & "PortDB>55556" &
                                                    vbCrLf & "IPSV>localhost" &
                                                    vbCrLf & "RetroConnect>False" &
                                                    vbCrLf & "SeeAllCMD>False" &
                                                    vbCrLf & "SaveChats>False", False)
            End If
            Dim ConfigFile = IO.File.ReadAllLines(Application.StartupPath & "\OSH_Config.ini")
            PuertoSV = ConfigFile(1).Split(">"c)(1).Trim() 'Al iniciar toma este string como puerto
            PuertoDB = ConfigFile(2).Split(">"c)(1).Trim() 'Puerto para la base de datos (inutil)
            ServerIP = ConfigFile(3).Split(">"c)(1).Trim() 'Indica la Ip en donde esta el servidor (inutil)
            RetroConnect = ConfigFile(4).Split(">"c)(1).Trim() 'Indica si los complementos pueden postear en el servidor
            SeeAllCMD = Boolean.Parse(ConfigFile(5).Split(">"c)(1).Trim()) 'Indica si el Servidor puede ver o no todo lo que los usuarios envian (Para privacidad de los usuarios mantener en False)
            SaveChats = Boolean.Parse(ConfigFile(6).Split(">"c)(1).Trim()) 'Indica si se debe guardar un registro del chat
            TextBoxPUERTO1.Text = PuertoSV
        Catch ex As Exception
            Console.WriteLine("[Main@Form1_Load(LoadConfig)]Error: " & ex.Message)
        End Try
        Start()
    End Sub

    Sub Start()
        CheckForIllegalCrossThreadCalls = False 'PARA PODER ES CRIBIR EN EL CHAT DURANTE EL THREAD
        SERVIDOR = New TcpListener(IPAddress.Any, PuertoSV) 'CONEXION
        SERVIDOR.Start()
        THREADSERVIDOR = New Thread(AddressOf ESCUCHAR) 'PARA RECIBIR LAS CONEXIONES DE LOS CLIENTES
        THREADSERVIDOR.Start()
        TextBoxCHAT.AppendText("Esperando conexiones..." & vbCrLf)
    End Sub

    Public Sub ESCUCHAR() 'PARA RECIBIR LAS CONEXIONES DE LOS CLIENTES
        Dim CLIENTE As New NUEVOCLIENTE
        While True
            Try
                CLIENTE.SOCKETCLIENTE = SERVIDOR.AcceptSocket 'NUEVA CONEXION DE CLIENTE
                CLIENTEIP = CLIENTE.SOCKETCLIENTE.RemoteEndPoint 'IP DEL CLIENTE
                CLIENTE.THREADCLIENTE = New Thread(AddressOf LEER) 'PARA RECIBIR LOS MENSAJES DE LOS CLIENTES
                CLIENTES.Add(CLIENTEIP, CLIENTE) 'LO AÑADE AL HASTABLE CLIENTES
                CLIENTE.THREADCLIENTE.Start()
            Catch ex As Exception
            End Try
        End While
    End Sub

    Public Sub LEER() 'PARA RECIBIR LOS MENSAJES DE LOS CLIENTES
        Dim CLIENTE As New NUEVOCLIENTE
        Dim DATOS() As Byte
        Dim IP As IPEndPoint = CLIENTEIP 'OBTIENE LA IP Y PUERTO DEL CLIENTE
        CLIENTE = CLIENTES(IP)
        While True
            If CLIENTE.SOCKETCLIENTE.Connected Then
                DATOS = New Byte(1024) {}
                Try
                    If CLIENTE.SOCKETCLIENTE.Receive(DATOS, DATOS.Length, 0) > 0 Then
                        CLIENTE.MENSAJE = Encoding.UTF8.GetString(DATOS) 'MENSAJE RECIBIDO
                        CLIENTES(IP) = CLIENTE
                        ACCIONES(IP) 'EJECUTA LA ACCION CORRESPONDIENTE EN FUNCION DEL MENSAJE RECIBIDO
                    Else
                        Exit While
                    End If
                Catch ex As Exception
                    Exit While
                End Try
            End If
        End While
        CERRARTHREAD(IP) 'FINALIZA LA CONEXION CON UN CLIENTE
    End Sub

    Private Sub ACCIONES(ByVal IDTerminal As IPEndPoint) 'EJECUTA LA ACCION CORRESPONDIENTE EN FUNCION DEL MENSAJE RECIBIDO
        Dim MENSAJE As String = OBTENERDATOS(IDTerminal) 'LEE EL MENSAJE DEL CLIENTE
        USUARIO = MENSAJE.Split(":")(1) 'NOMBRE DEL CLIENTE
        USUARIO = USUARIO.Trim("")
        If MENSAJE.StartsWith("Conexion:") Then 'Usuario conectado
            ListBox1.Items.Add(USUARIO)
            For I = 0 To ListBox1.Items.Count - 1
                ENVIARTODOS("Lista:" & ListBox1.Items(I) & "/")
            Next
            ENVIARTODOS("Conexion:" & USUARIO)
            If SeeAllCMD = True Then
                TextBoxCHAT.AppendText(vbCrLf & "[" & IDTerminal.ToString & "]Conexion:" & USUARIO)
            End If
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\OSH_Connections.ini", USUARIO & ":" & IDTerminal.ToString & vbCrLf, True)
        ElseIf MENSAJE.StartsWith("Desconexion:") Then 'Usuario desconectado
            ListBox1.Items.Remove(USUARIO)
            Try
                For I = 0 To ListBox1.Items.Count - 1
                    ENVIARTODOS("Lista:" & ListBox1.Items(I) & "/")
                Next
            Catch ex As Exception
            End Try
            ENVIARTODOS("Desconexion:" & USUARIO)
            If SeeAllCMD = True Then
                TextBoxCHAT.AppendText(vbCrLf & MENSAJE)
            End If
            DESCONEXIONES(USUARIO)
        ElseIf MENSAJE.StartsWith("CallBack:") Then 'CallBack
            Dim Quit As String() = MENSAJE.Split(":")
            Dim Args As String() = Quit(1).Split("|")
            If SeeAllCMD = True Then
                TextBoxCHAT.AppendText(vbCrLf & "[CallBACK]" & Args(0) & "\" & Args(1) & " in " & Args(2))
            End If
        ElseIf MENSAJE.StartsWith("Privado:") Then 'Mensaje privado
            Dim MIPRIVADO As String() = MENSAJE.Split(":")
            USUARIO = MIPRIVADO(1)
            Dim MENSAJERETORNO As String = "Privado:" & MIPRIVADO(2) & ":" & "Tú> " & MIPRIVADO(3)
            ENVIARUNO(IDTerminal, MENSAJERETORNO)
            NOMBREPRIVADO = MIPRIVADO(2)
            CONEXIONES(NOMBREPRIVADO)
            Dim DESTINO As New IPEndPoint(IPAddress.Parse(IPPRIVADO), CInt(PUERTOPRIVADO))
            Dim MENSAJEPRIVADO As String = "Privado:" & USUARIO & ":" & MIPRIVADO(3)
            ENVIARUNO(DESTINO, MENSAJEPRIVADO)
            If SeeAllCMD = True Then
                TextBoxCHAT.AppendText(vbCrLf & "[" & USUARIO & " to " & IPPRIVADO & "]: " & MIPRIVADO(3))
            End If
        Else 'Mensaje publico
            ENVIARTODOS(MENSAJE)
            TextBoxCHAT.AppendText(vbCrLf & MENSAJE)
        End If
    End Sub

    Public Function OBTENERDATOS(ByVal IDCliente As IPEndPoint) As String 'ENTREGA EL MENSAJE DEL CLIENTE
        Dim CLIENTE As NUEVOCLIENTE
        CLIENTE = CLIENTES(IDCliente)
        Return CLIENTE.MENSAJE
    End Function

    Public Function LOGIN(ByVal CREDENCIALES As String) As Boolean 'COMPRUEBA QUE EL CLIENTE ESTE REGISTRADO
        Dim IDENTIDAD As String = CREDENCIALES.Remove(0, CREDENCIALES.IndexOf(":") + 1)
        For Each LINEA In IO.File.ReadLines(Application.StartupPath & "\OSH_Users.ini")
            Dim NOMBRE As String = LINEA.Split(":")(0)
            Dim CONTRASEÑA As String = LINEA.Split(":")(1)
            Dim LOGINOK As String = NOMBRE & ":" & CONTRASEÑA
            If IDENTIDAD.Trim("") = LOGINOK Then
                Return True
                Exit For
            End If
        Next
        Return False
    End Function

    Public Sub ENVIARUNO(ByVal IDCliente As IPEndPoint, ByVal Datos As String) 'ENVIA MENSAJES A UN SOLO CLIENTE
        Dim Cliente As NUEVOCLIENTE
        Cliente = CLIENTES(IDCliente)
        Cliente.SOCKETCLIENTE.Send(Encoding.UTF8.GetBytes(Datos))
    End Sub

    Public Sub ENVIARTODOS(ByVal Datos As String) 'ENVIA MENSAJES A TODOS LOS CLIENTES
        Dim CLIENTE As NUEVOCLIENTE
        For Each CLIENTE In CLIENTES.Values
            CLIENTE.SOCKETCLIENTE.Send(Encoding.UTF8.GetBytes(Datos))
        Next
    End Sub

    Public Sub CONEXIONES(ByVal NOMBRE As String) 'REGISTRA LOS DATOS DE UNA NUEVA CONEXION
        Dim RUTA As String = Application.StartupPath & "\OSH_Connections.ini"
        Dim LECTOR As New StreamReader(RUTA)
        While LECTOR.EndOfStream = False
            Dim CAPTURA As String = LECTOR.ReadLine
            If CAPTURA.StartsWith(NOMBRE) Then
                IPPRIVADO = CAPTURA
                IPPRIVADO = IPPRIVADO.Remove(0, IPPRIVADO.IndexOf(":") + 1)
                IPPRIVADO = IPPRIVADO.Substring(0, IPPRIVADO.IndexOf(":"))
                PUERTOPRIVADO = CAPTURA
                PUERTOPRIVADO = PUERTOPRIVADO.Remove(0, PUERTOPRIVADO.LastIndexOf(":") + 1)
                Exit While
            End If
        End While
        LECTOR.Close()
    End Sub

    Public Sub DESCONEXIONES(ByVal NOMBRE As String) 'ELIMINA LOS DATOS DE UNA CONEXION CERRADA
        Dim RUTA As String = Application.StartupPath & "\OSH_Connections.ini"
        Dim LECTOR As New StreamReader(RUTA)
        Dim NUEVACONEXIONES As New ArrayList
        While LECTOR.EndOfStream = False
            Dim CAPTURA As String = LECTOR.ReadLine
            If CAPTURA.StartsWith(NOMBRE) Then
                NUEVACONEXIONES.Add(LECTOR.ReadToEnd)
                Exit While
            Else
                NUEVACONEXIONES.Add(CAPTURA)
            End If
        End While
        LECTOR.Close()
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\OSH_Connections.ini", Nothing, False)
        For I = 0 To NUEVACONEXIONES.Count - 1
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\OSH_Connections.ini", NUEVACONEXIONES(I) & vbCrLf, True)
        Next
    End Sub

    'ENVIA MENSAJES NO AUTOMATICOS DESDE SU TEXTBOX
    Private Sub TextBoxMENSAJE_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBoxMENSAJE.KeyDown
        If TextBoxMENSAJE.Text <> Nothing Then
            If e.KeyCode = Keys.Enter Then
                If TextBoxCHAT.Text = "" Then
                Else
                    ENVIARTODOS("[Servidor]: " & TextBoxMENSAJE.Text)
                    TextBoxCHAT.AppendText(vbCrLf & "[Servidor]: " & TextBoxMENSAJE.Text)
                    TextBoxMENSAJE.Clear()
                End If
            End If
        End If
    End Sub

    Public Sub CERRARTHREAD(ByVal IP As IPEndPoint) 'FINALIZA LA CONEXION CON UN CLIENTE
        Dim CLIENTE As NUEVOCLIENTE = CLIENTES(IP)
        Try
            CLIENTE.THREADCLIENTE.Abort()
        Catch ex As Exception
            CLIENTES.Remove(IP)
        End Try
    End Sub

    Public Sub CERRARTODO() 'FINALIZA LA CONEXION CON TODOS LOS CLIENTES
        Dim CLIENTE As NUEVOCLIENTE
        For Each CLIENTE In CLIENTES.Values
            CLIENTE.SOCKETCLIENTE.Close()
            CLIENTE.THREADCLIENTE.Abort()
        Next
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ENVIARTODOS("[Servidor]:Desconectado") 'ENVIA UN MENSAJE DE DESCONEXION A TODOS LOS CLIENTES
        Threading.Thread.Sleep(1000) 'PARA DAR TIEMPO A QUE LOS CLIENTES LO RECIBAN
        CERRARTODO() 'FINALIZA LA CONEXION CON TODOS LOS CLIENTES
        SERVIDOR.Stop() 'FINALIZA EL SERVIDOR
        THREADSERVIDOR.Abort() 'FINALIZA EL THREAD PRINCIPAL
    End Sub

#Region "ContextMenuUsuario"
    Private Sub KickearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KickearToolStripMenuItem.Click
        Dim Reason = InputBox("Razon de expulsion", "Kick", "Mal comportamiento :/")
        ENVIARTODOS("@CMD|Kicked|" & ListBox1.SelectedItem & "|" & Reason)
        TextBoxCHAT.AppendText(vbCrLf & "Expulsaste a " & ListBox1.SelectedItem & ".")
    End Sub

    Private Sub BannearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BannearToolStripMenuItem.Click
        Dim Reason = InputBox("Razon del ban", "Ban", "Continuo mal comportamiento :/")
        ENVIARTODOS("@CMD|Banned|" & ListBox1.SelectedItem & "|" & Reason)
        TextBoxCHAT.AppendText(vbCrLf & "Banneaste a " & ListBox1.SelectedItem & ".")
    End Sub

    Private Sub PrivadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrivadoToolStripMenuItem.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CMD.Show()
        CMD.Focus()
    End Sub
#End Region
End Class
'Sistema para guardar el chat. Solo 3 registros luego comenzara a sobreescribir desde el uno hasta llegar al 3