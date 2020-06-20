<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainCL
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainCL))
        Me.TextBoxIP = New System.Windows.Forms.TextBox()
        Me.TextBoxMENSAJE = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonPRIVADO = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBoxCHAT = New System.Windows.Forms.RichTextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.TextBoxPUERTO1 = New System.Windows.Forms.TextBox()
        Me.TextBoxPUERTO2 = New System.Windows.Forms.TextBox()
        Me.ButtonCONECTAR = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxIP
        '
        Me.TextBoxIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxIP.Location = New System.Drawing.Point(109, 12)
        Me.TextBoxIP.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxIP.Name = "TextBoxIP"
        Me.TextBoxIP.Size = New System.Drawing.Size(131, 20)
        Me.TextBoxIP.TabIndex = 30
        Me.TextBoxIP.Text = "192.168.8.132"
        Me.TextBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxMENSAJE
        '
        Me.TextBoxMENSAJE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxMENSAJE.Enabled = False
        Me.TextBoxMENSAJE.Location = New System.Drawing.Point(36, 439)
        Me.TextBoxMENSAJE.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxMENSAJE.Name = "TextBoxMENSAJE"
        Me.TextBoxMENSAJE.Size = New System.Drawing.Size(372, 20)
        Me.TextBoxMENSAJE.TabIndex = 20
        '
        'Timer1
        '
        Me.Timer1.Interval = 555
        '
        'ButtonPRIVADO
        '
        Me.ButtonPRIVADO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonPRIVADO.Enabled = False
        Me.ButtonPRIVADO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPRIVADO.Location = New System.Drawing.Point(459, 402)
        Me.ButtonPRIVADO.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonPRIVADO.Name = "ButtonPRIVADO"
        Me.ButtonPRIVADO.Size = New System.Drawing.Size(164, 33)
        Me.ButtonPRIVADO.TabIndex = 27
        Me.ButtonPRIVADO.Text = "Privado"
        Me.ButtonPRIVADO.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(11, 75)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(444, 360)
        Me.TabControl1.TabIndex = 24
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.TextBoxCHAT)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Size = New System.Drawing.Size(436, 334)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Principal"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(171, 307)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(95, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Enviar archivo"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'TextBoxCHAT
        '
        Me.TextBoxCHAT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCHAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCHAT.Location = New System.Drawing.Point(21, 15)
        Me.TextBoxCHAT.Name = "TextBoxCHAT"
        Me.TextBoxCHAT.ReadOnly = True
        Me.TextBoxCHAT.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.TextBoxCHAT.Size = New System.Drawing.Size(394, 304)
        Me.TextBoxCHAT.TabIndex = 5
        Me.TextBoxCHAT.Text = ">Hello, World!_"
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(459, 95)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(164, 303)
        Me.ListBox1.TabIndex = 23
        '
        'TextBoxPUERTO1
        '
        Me.TextBoxPUERTO1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPUERTO1.Location = New System.Drawing.Point(109, 40)
        Me.TextBoxPUERTO1.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxPUERTO1.Name = "TextBoxPUERTO1"
        Me.TextBoxPUERTO1.Size = New System.Drawing.Size(64, 20)
        Me.TextBoxPUERTO1.TabIndex = 22
        Me.TextBoxPUERTO1.Text = "55555"
        Me.TextBoxPUERTO1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxPUERTO2
        '
        Me.TextBoxPUERTO2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPUERTO2.Location = New System.Drawing.Point(176, 40)
        Me.TextBoxPUERTO2.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxPUERTO2.Name = "TextBoxPUERTO2"
        Me.TextBoxPUERTO2.Size = New System.Drawing.Size(64, 20)
        Me.TextBoxPUERTO2.TabIndex = 31
        Me.TextBoxPUERTO2.Text = "55556"
        Me.TextBoxPUERTO2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxPUERTO2.Visible = False
        '
        'ButtonCONECTAR
        '
        Me.ButtonCONECTAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCONECTAR.Location = New System.Drawing.Point(244, 11)
        Me.ButtonCONECTAR.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCONECTAR.Name = "ButtonCONECTAR"
        Me.ButtonCONECTAR.Size = New System.Drawing.Size(79, 49)
        Me.ButtonCONECTAR.TabIndex = 21
        Me.ButtonCONECTAR.Text = "Conectar"
        Me.ButtonCONECTAR.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "IP Servidor: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Puerto Server"
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(346, 4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(88, 17)
        Me.CheckBox1.TabIndex = 36
        Me.CheckBox1.Text = "Modo oscuro"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(440, 4)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(93, 17)
        Me.CheckBox2.TabIndex = 37
        Me.CheckBox2.Text = "Notificaciones"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = "Running..."
        Me.NotifyIcon1.BalloonTipTitle = "OSH"
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Our Speak Home"
        Me.NotifyIcon1.Visible = True
        '
        'CheckBox3
        '
        Me.CheckBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.Location = New System.Drawing.Point(539, 4)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(91, 17)
        Me.CheckBox3.TabIndex = 38
        Me.CheckBox3.Text = "Enter to Send"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Enabled = False
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(413, 439)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(42, 31)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "Send"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'MainCL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 482)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxPUERTO2)
        Me.Controls.Add(Me.TextBoxIP)
        Me.Controls.Add(Me.TextBoxMENSAJE)
        Me.Controls.Add(Me.ButtonPRIVADO)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.TextBoxPUERTO1)
        Me.Controls.Add(Me.ButtonCONECTAR)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(650, 520)
        Me.Name = "MainCL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Our Speak Home | Client"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxIP As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxMENSAJE As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ButtonPRIVADO As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents TextBoxPUERTO1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPUERTO2 As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCONECTAR As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TextBoxCHAT As RichTextBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
