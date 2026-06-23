<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Button1 = New Button()
        usernametxtBox = New TextBox()
        passwordtxtBox = New TextBox()
        loginBtn = New Button()
        CheckBox1 = New CheckBox()
        Label5 = New Label()
        Roles = New Label()
        Cancel = New Button()
        lblUserInfo = New Label()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Transparent
        Button1.BackgroundImageLayout = ImageLayout.Center
        Button1.Enabled = False
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatAppearance.CheckedBackColor = Color.Transparent
        Button1.FlatAppearance.MouseDownBackColor = Color.Transparent
        Button1.FlatAppearance.MouseOverBackColor = Color.Transparent
        Button1.FlatStyle = FlatStyle.Flat
        Button1.ForeColor = Color.Black
        Button1.Location = New Point(628, 8)
        Button1.Name = "Button1"
        Button1.Size = New Size(55, 53)
        Button1.TabIndex = 11
        Button1.UseVisualStyleBackColor = False
        Button1.Visible = False
        ' 
        ' usernametxtBox
        ' 
        usernametxtBox.BackColor = SystemColors.Control
        usernametxtBox.BorderStyle = BorderStyle.FixedSingle
        usernametxtBox.Font = New Font("Franklin Gothic Medium Cond", 20.25F)
        usernametxtBox.Location = New Point(209, 135)
        usernametxtBox.Name = "usernametxtBox"
        usernametxtBox.Size = New Size(423, 38)
        usernametxtBox.TabIndex = 6
        ' 
        ' passwordtxtBox
        ' 
        passwordtxtBox.BackColor = SystemColors.Control
        passwordtxtBox.BorderStyle = BorderStyle.FixedSingle
        passwordtxtBox.Font = New Font("Franklin Gothic Medium Cond", 20.25F)
        passwordtxtBox.Location = New Point(209, 195)
        passwordtxtBox.Name = "passwordtxtBox"
        passwordtxtBox.Size = New Size(423, 38)
        passwordtxtBox.TabIndex = 7
        passwordtxtBox.UseSystemPasswordChar = True
        ' 
        ' loginBtn
        ' 
        loginBtn.BackColor = Color.Transparent
        loginBtn.FlatAppearance.BorderSize = 0
        loginBtn.FlatAppearance.CheckedBackColor = Color.Transparent
        loginBtn.FlatAppearance.MouseDownBackColor = Color.Transparent
        loginBtn.FlatAppearance.MouseOverBackColor = Color.Transparent
        loginBtn.FlatStyle = FlatStyle.Flat
        loginBtn.Font = New Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        loginBtn.ForeColor = Color.Black
        loginBtn.Location = New Point(320, 309)
        loginBtn.Name = "loginBtn"
        loginBtn.Size = New Size(173, 69)
        loginBtn.TabIndex = 8
        loginBtn.Text = "Login"
        loginBtn.UseVisualStyleBackColor = False
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.BackColor = Color.Transparent
        CheckBox1.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        CheckBox1.ForeColor = SystemColors.Control
        CheckBox1.Location = New Point(474, 245)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(138, 28)
        CheckBox1.TabIndex = 10
        CheckBox1.Text = "Show Password"
        CheckBox1.UseVisualStyleBackColor = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label5.ForeColor = SystemColors.Control
        Label5.Location = New Point(27, 309)
        Label5.Name = "Label5"
        Label5.Size = New Size(73, 24)
        Label5.TabIndex = 11
        Label5.Text = "Login as:"
        ' 
        ' Roles
        ' 
        Roles.AutoSize = True
        Roles.BackColor = Color.Transparent
        Roles.Font = New Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Roles.ForeColor = SystemColors.Control
        Roles.Location = New Point(106, 309)
        Roles.Name = "Roles"
        Roles.Size = New Size(0, 24)
        Roles.TabIndex = 10
        ' 
        ' Cancel
        ' 
        Cancel.BackColor = Color.Transparent
        Cancel.BackgroundImageLayout = ImageLayout.None
        Cancel.FlatAppearance.BorderSize = 0
        Cancel.FlatAppearance.CheckedBackColor = Color.Transparent
        Cancel.FlatAppearance.MouseDownBackColor = Color.Transparent
        Cancel.FlatAppearance.MouseOverBackColor = Color.Transparent
        Cancel.FlatStyle = FlatStyle.Flat
        Cancel.Font = New Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Cancel.ForeColor = Color.Black
        Cancel.Location = New Point(509, 309)
        Cancel.Name = "Cancel"
        Cancel.Size = New Size(173, 69)
        Cancel.TabIndex = 13
        Cancel.Text = "Cancel"
        Cancel.UseVisualStyleBackColor = False
        ' 
        ' lblUserInfo
        ' 
        lblUserInfo.AutoSize = True
        lblUserInfo.BackColor = Color.Transparent
        lblUserInfo.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        lblUserInfo.ForeColor = SystemColors.Control
        lblUserInfo.Location = New Point(27, 337)
        lblUserInfo.Name = "lblUserInfo"
        lblUserInfo.Size = New Size(40, 24)
        lblUserInfo.TabIndex = 55
        lblUserInfo.Text = "***"
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(6F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveBorder
        BackgroundImage = My.Resources.Resources.Login_imresizer
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(694, 390)
        Controls.Add(Button1)
        Controls.Add(usernametxtBox)
        Controls.Add(CheckBox1)
        Controls.Add(lblUserInfo)
        Controls.Add(passwordtxtBox)
        Controls.Add(Cancel)
        Controls.Add(Label5)
        Controls.Add(Roles)
        Controls.Add(loginBtn)
        Font = New Font("Franklin Gothic Medium Cond", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.None
        Name = "Login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents usernametxtBox As TextBox
    Friend WithEvents passwordtxtBox As TextBox
    Friend WithEvents loginBtn As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Roles As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Cancel As Button
    Friend WithEvents lblUserInfo As Label

End Class
