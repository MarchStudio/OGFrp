<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServerSelectionWindow
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lb_Server = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt_launch = New System.Windows.Forms.Button()
        Me.cb_Server = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb_Server
        '
        Me.lb_Server.AutoSize = True
        Me.lb_Server.Location = New System.Drawing.Point(0, 8)
        Me.lb_Server.Name = "lb_Server"
        Me.lb_Server.Size = New System.Drawing.Size(88, 31)
        Me.lb_Server.TabIndex = 0
        Me.lb_Server.Text = "Label1"
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.bt_launch)
        Me.Panel1.Controls.Add(Me.cb_Server)
        Me.Panel1.Controls.Add(Me.lb_Server)
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(63, 83)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(423, 168)
        Me.Panel1.TabIndex = 1
        '
        'bt_launch
        '
        Me.bt_launch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_launch.Location = New System.Drawing.Point(217, 113)
        Me.bt_launch.Name = "bt_launch"
        Me.bt_launch.Size = New System.Drawing.Size(203, 52)
        Me.bt_launch.TabIndex = 2
        Me.bt_launch.Text = "Button1"
        Me.bt_launch.UseVisualStyleBackColor = True
        '
        'cb_Server
        '
        Me.cb_Server.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cb_Server.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Server.FormattingEnabled = True
        Me.cb_Server.Items.AddRange(New Object() {"hk1.ogfrp.cn", "sh1.ogfrp.cn", "ct1.ogfrp.cn", "bj1.ogfrp.cn", "bj2.ogfrp.cn", "hk2.ogfrp.cn"})
        Me.cb_Server.Location = New System.Drawing.Point(3, 54)
        Me.cb_Server.Name = "cb_Server"
        Me.cb_Server.Size = New System.Drawing.Size(417, 39)
        Me.cb_Server.TabIndex = 1
        '
        'ServerSelectionWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(548, 334)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("微软雅黑", 18.0!)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(8, 9, 8, 9)
        Me.Name = "ServerSelectionWindow"
        Me.Opacity = 0.8R
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ServerSelectionWindow"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lb_Server As Forms.Label
    Friend WithEvents Panel1 As Forms.Panel
    Friend WithEvents cb_Server As Forms.ComboBox
    Friend WithEvents bt_launch As Forms.Button
End Class
