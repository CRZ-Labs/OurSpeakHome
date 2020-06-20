<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainSV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainSV))
        Me.TextBoxCHAT = New System.Windows.Forms.TextBox()
        Me.TextBoxMENSAJE = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.menuUsuarios = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.KickearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BannearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrivadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBoxPUERTO1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.menuUsuarios.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxCHAT
        '
        Me.TextBoxCHAT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCHAT.Location = New System.Drawing.Point(3, 3)
        Me.TextBoxCHAT.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxCHAT.Multiline = True
        Me.TextBoxCHAT.Name = "TextBoxCHAT"
        Me.TextBoxCHAT.ReadOnly = True
        Me.TextBoxCHAT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxCHAT.Size = New System.Drawing.Size(448, 330)
        Me.TextBoxCHAT.TabIndex = 15
        '
        'TextBoxMENSAJE
        '
        Me.TextBoxMENSAJE.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxMENSAJE.Location = New System.Drawing.Point(19, 421)
        Me.TextBoxMENSAJE.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxMENSAJE.Name = "TextBoxMENSAJE"
        Me.TextBoxMENSAJE.Size = New System.Drawing.Size(448, 20)
        Me.TextBoxMENSAJE.TabIndex = 14
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.ContextMenuStrip = Me.menuUsuarios
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(479, 58)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(144, 342)
        Me.ListBox1.TabIndex = 13
        '
        'menuUsuarios
        '
        Me.menuUsuarios.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KickearToolStripMenuItem, Me.BannearToolStripMenuItem, Me.ToolStripMenuItem1, Me.PrivadoToolStripMenuItem})
        Me.menuUsuarios.Name = "menuUsuarios"
        Me.menuUsuarios.Size = New System.Drawing.Size(118, 76)
        '
        'KickearToolStripMenuItem
        '
        Me.KickearToolStripMenuItem.Name = "KickearToolStripMenuItem"
        Me.KickearToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.KickearToolStripMenuItem.Text = "Kickear"
        '
        'BannearToolStripMenuItem
        '
        Me.BannearToolStripMenuItem.Name = "BannearToolStripMenuItem"
        Me.BannearToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.BannearToolStripMenuItem.Text = "Bannear"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(114, 6)
        Me.ToolStripMenuItem1.Visible = False
        '
        'PrivadoToolStripMenuItem
        '
        Me.PrivadoToolStripMenuItem.Name = "PrivadoToolStripMenuItem"
        Me.PrivadoToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.PrivadoToolStripMenuItem.Text = "Privado"
        Me.PrivadoToolStripMenuItem.Visible = False
        '
        'TextBoxPUERTO1
        '
        Me.TextBoxPUERTO1.Location = New System.Drawing.Point(53, 13)
        Me.TextBoxPUERTO1.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxPUERTO1.Name = "TextBoxPUERTO1"
        Me.TextBoxPUERTO1.ReadOnly = True
        Me.TextBoxPUERTO1.Size = New System.Drawing.Size(68, 20)
        Me.TextBoxPUERTO1.TabIndex = 17
        Me.TextBoxPUERTO1.Text = "55555"
        Me.TextBoxPUERTO1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 16)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Puerto"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 38)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(462, 362)
        Me.TabControl1.TabIndex = 21
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TextBoxCHAT)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(454, 336)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Publico"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(566, 417)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 26)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "CMD"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MainSV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 452)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxPUERTO1)
        Me.Controls.Add(Me.TextBoxMENSAJE)
        Me.Controls.Add(Me.ListBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(650, 490)
        Me.Name = "MainSV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OurSpeakHome | Server"
        Me.menuUsuarios.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxCHAT As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxMENSAJE As System.Windows.Forms.TextBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents TextBoxPUERTO1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents menuUsuarios As ContextMenuStrip
    Friend WithEvents KickearToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BannearToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents PrivadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Button1 As Button
End Class
