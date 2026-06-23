<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        btnSales = New Button()
        btnUserMan = New Button()
        btnProdMan = New Button()
        Label6 = New Label()
        DataGridQuota = New DataGridView()
        Label4 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        DataGridMostSold = New DataGridView()
        DataGridLeastSold = New DataGridView()
        DataGridCriticalLevel = New DataGridView()
        btnLogout = New Button()
        Timer1 = New Timer(components)
        BindingSource1 = New BindingSource(components)
        Label5 = New Label()
        lblName = New Label()
        Label13 = New Label()
        Label3 = New Label()
        lblTime = New Label()
        lblDate = New Label()
        CType(DataGridQuota, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridMostSold, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridLeastSold, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridCriticalLevel, ComponentModel.ISupportInitialize).BeginInit()
        CType(BindingSource1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnSales
        ' 
        btnSales.BackColor = Color.Transparent
        btnSales.FlatAppearance.BorderSize = 0
        btnSales.FlatAppearance.CheckedBackColor = Color.Transparent
        btnSales.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnSales.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnSales.FlatStyle = FlatStyle.Flat
        btnSales.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSales.Location = New Point(55, 459)
        btnSales.Margin = New Padding(3, 2, 3, 2)
        btnSales.Name = "btnSales"
        btnSales.Size = New Size(229, 66)
        btnSales.TabIndex = 27
        btnSales.UseVisualStyleBackColor = False
        ' 
        ' btnUserMan
        ' 
        btnUserMan.BackColor = Color.Transparent
        btnUserMan.FlatAppearance.BorderSize = 0
        btnUserMan.FlatAppearance.CheckedBackColor = Color.Transparent
        btnUserMan.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnUserMan.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnUserMan.FlatStyle = FlatStyle.Flat
        btnUserMan.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUserMan.Location = New Point(54, 312)
        btnUserMan.Margin = New Padding(3, 2, 3, 2)
        btnUserMan.Name = "btnUserMan"
        btnUserMan.Size = New Size(229, 66)
        btnUserMan.TabIndex = 26
        btnUserMan.TextAlign = ContentAlignment.MiddleRight
        btnUserMan.UseVisualStyleBackColor = False
        ' 
        ' btnProdMan
        ' 
        btnProdMan.BackColor = Color.Transparent
        btnProdMan.FlatAppearance.BorderSize = 0
        btnProdMan.FlatAppearance.CheckedBackColor = Color.Transparent
        btnProdMan.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnProdMan.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnProdMan.FlatStyle = FlatStyle.Flat
        btnProdMan.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnProdMan.Location = New Point(55, 387)
        btnProdMan.Margin = New Padding(3, 2, 3, 2)
        btnProdMan.Name = "btnProdMan"
        btnProdMan.Size = New Size(229, 66)
        btnProdMan.TabIndex = 25
        btnProdMan.TextAlign = ContentAlignment.MiddleRight
        btnProdMan.UseVisualStyleBackColor = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(748, 125)
        Label6.Name = "Label6"
        Label6.Size = New Size(116, 25)
        Label6.TabIndex = 7
        Label6.Text = "User Quotas"
        ' 
        ' DataGridQuota
        ' 
        DataGridQuota.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridQuota.Location = New Point(748, 153)
        DataGridQuota.Name = "DataGridQuota"
        DataGridQuota.Size = New Size(553, 225)
        DataGridQuota.TabIndex = 6
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(334, 512)
        Label4.Name = "Label4"
        Label4.Size = New Size(151, 25)
        Label4.TabIndex = 5
        Label4.Text = "Least Sold Items"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(334, 320)
        Label2.Name = "Label2"
        Label2.Size = New Size(151, 25)
        Label2.TabIndex = 4
        Label2.Text = "Most Sold Items"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(334, 125)
        Label1.Name = "Label1"
        Label1.Size = New Size(174, 25)
        Label1.TabIndex = 3
        Label1.Text = "Critical Level Items"
        ' 
        ' DataGridMostSold
        ' 
        DataGridMostSold.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridMostSold.Location = New Point(334, 348)
        DataGridMostSold.Name = "DataGridMostSold"
        DataGridMostSold.Size = New Size(345, 149)
        DataGridMostSold.TabIndex = 2
        ' 
        ' DataGridLeastSold
        ' 
        DataGridLeastSold.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridLeastSold.Location = New Point(334, 540)
        DataGridLeastSold.Name = "DataGridLeastSold"
        DataGridLeastSold.Size = New Size(345, 149)
        DataGridLeastSold.TabIndex = 1
        ' 
        ' DataGridCriticalLevel
        ' 
        DataGridCriticalLevel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridCriticalLevel.Location = New Point(334, 153)
        DataGridCriticalLevel.Name = "DataGridCriticalLevel"
        DataGridCriticalLevel.Size = New Size(340, 149)
        DataGridCriticalLevel.TabIndex = 0
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.Transparent
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatAppearance.CheckedBackColor = Color.Transparent
        btnLogout.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnLogout.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLogout.Location = New Point(1267, 8)
        btnLogout.Margin = New Padding(3, 2, 3, 2)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(73, 76)
        btnLogout.TabIndex = 29
        btnLogout.TextAlign = ContentAlignment.MiddleRight
        btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 1000
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label5.ForeColor = SystemColors.Control
        Label5.Location = New Point(48, 183)
        Label5.Name = "Label5"
        Label5.Size = New Size(56, 24)
        Label5.TabIndex = 53
        Label5.Text = "Name:"
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.BackColor = Color.Transparent
        lblName.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        lblName.ForeColor = SystemColors.Control
        lblName.Location = New Point(111, 183)
        lblName.Name = "lblName"
        lblName.Size = New Size(40, 24)
        lblName.TabIndex = 52
        lblName.Text = "***"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = Color.Transparent
        Label13.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label13.ForeColor = SystemColors.Control
        Label13.Location = New Point(54, 153)
        Label13.Name = "Label13"
        Label13.Size = New Size(47, 24)
        Label13.TabIndex = 51
        Label13.Text = "Time:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label3.ForeColor = SystemColors.Control
        Label3.Location = New Point(54, 120)
        Label3.Name = "Label3"
        Label3.Size = New Size(48, 24)
        Label3.TabIndex = 50
        Label3.Text = "Date:"
        ' 
        ' lblTime
        ' 
        lblTime.AutoSize = True
        lblTime.BackColor = Color.Transparent
        lblTime.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        lblTime.ForeColor = SystemColors.Control
        lblTime.Location = New Point(111, 153)
        lblTime.Name = "lblTime"
        lblTime.Size = New Size(40, 24)
        lblTime.TabIndex = 49
        lblTime.Text = "***"
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.BackColor = Color.Transparent
        lblDate.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        lblDate.ForeColor = SystemColors.Control
        lblDate.Location = New Point(111, 120)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(40, 24)
        lblDate.TabIndex = 48
        lblDate.Text = "***"
        ' 
        ' frmDashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources._6
        ClientSize = New Size(1366, 761)
        Controls.Add(Label4)
        Controls.Add(Label6)
        Controls.Add(Label2)
        Controls.Add(Label5)
        Controls.Add(Label1)
        Controls.Add(DataGridMostSold)
        Controls.Add(DataGridQuota)
        Controls.Add(DataGridLeastSold)
        Controls.Add(lblName)
        Controls.Add(DataGridCriticalLevel)
        Controls.Add(Label13)
        Controls.Add(Label3)
        Controls.Add(lblTime)
        Controls.Add(lblDate)
        Controls.Add(btnLogout)
        Controls.Add(btnSales)
        Controls.Add(btnUserMan)
        Controls.Add(btnProdMan)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmDashboard"
        CType(DataGridQuota, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridMostSold, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridLeastSold, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridCriticalLevel, ComponentModel.ISupportInitialize).EndInit()
        CType(BindingSource1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnSales As Button
    Friend WithEvents btnUserMan As Button
    Friend WithEvents btnProdMan As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents DataGridCriticalLevel As DataGridView
    Friend WithEvents DataGridMostSold As DataGridView
    Friend WithEvents DataGridLeastSold As DataGridView
    Friend WithEvents Timer1 As Timer
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Label5 As Label
    Friend WithEvents lblName As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents DataGridQuota As DataGridView
End Class
