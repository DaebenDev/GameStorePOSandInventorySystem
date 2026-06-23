<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSales
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Button7 = New Button()
        Sales = New Button()
        UserManagement = New Button()
        ProductManagement = New Button()
        lblDailySalesTotal = New Label()
        btnRefresh = New Button()
        DateTimePickerTo = New DateTimePicker()
        DateTimePickerFrom = New DateTimePicker()
        Label2 = New Label()
        Label1 = New Label()
        SalesDataGridView = New DataGridView()
        Timer1 = New Timer(components)
        Label5 = New Label()
        lblName = New Label()
        Label13 = New Label()
        Label7 = New Label()
        lblTime = New Label()
        lblDate = New Label()
        Label6 = New Label()
        DashboardButton = New Button()
        CType(SalesDataGridView, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button7
        ' 
        Button7.BackColor = Color.Transparent
        Button7.FlatAppearance.BorderSize = 0
        Button7.FlatAppearance.CheckedBackColor = Color.Transparent
        Button7.FlatAppearance.MouseDownBackColor = Color.Transparent
        Button7.FlatAppearance.MouseOverBackColor = Color.Transparent
        Button7.FlatStyle = FlatStyle.Flat
        Button7.Font = New Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button7.Location = New Point(1264, 11)
        Button7.Margin = New Padding(3, 2, 3, 2)
        Button7.Name = "Button7"
        Button7.Size = New Size(73, 76)
        Button7.TabIndex = 17
        Button7.TextAlign = ContentAlignment.MiddleRight
        Button7.UseVisualStyleBackColor = False
        ' 
        ' Sales
        ' 
        Sales.BackColor = Color.Transparent
        Sales.FlatAppearance.BorderSize = 0
        Sales.FlatAppearance.CheckedBackColor = Color.Transparent
        Sales.FlatAppearance.MouseDownBackColor = Color.Transparent
        Sales.FlatAppearance.MouseOverBackColor = Color.Transparent
        Sales.FlatStyle = FlatStyle.Flat
        Sales.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Sales.Location = New Point(55, 462)
        Sales.Margin = New Padding(3, 2, 3, 2)
        Sales.Name = "Sales"
        Sales.Size = New Size(229, 66)
        Sales.TabIndex = 30
        Sales.UseVisualStyleBackColor = False
        ' 
        ' UserManagement
        ' 
        UserManagement.BackColor = Color.Transparent
        UserManagement.FlatAppearance.BorderSize = 0
        UserManagement.FlatAppearance.CheckedBackColor = Color.Transparent
        UserManagement.FlatAppearance.MouseDownBackColor = Color.Transparent
        UserManagement.FlatAppearance.MouseOverBackColor = Color.Transparent
        UserManagement.FlatStyle = FlatStyle.Flat
        UserManagement.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        UserManagement.Location = New Point(55, 314)
        UserManagement.Margin = New Padding(3, 2, 3, 2)
        UserManagement.Name = "UserManagement"
        UserManagement.Size = New Size(229, 66)
        UserManagement.TabIndex = 29
        UserManagement.TextAlign = ContentAlignment.MiddleRight
        UserManagement.UseVisualStyleBackColor = False
        ' 
        ' ProductManagement
        ' 
        ProductManagement.BackColor = Color.Transparent
        ProductManagement.FlatAppearance.BorderSize = 0
        ProductManagement.FlatAppearance.CheckedBackColor = Color.Transparent
        ProductManagement.FlatAppearance.MouseDownBackColor = Color.Transparent
        ProductManagement.FlatAppearance.MouseOverBackColor = Color.Transparent
        ProductManagement.FlatStyle = FlatStyle.Flat
        ProductManagement.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ProductManagement.Location = New Point(55, 390)
        ProductManagement.Margin = New Padding(3, 2, 3, 2)
        ProductManagement.Name = "ProductManagement"
        ProductManagement.Size = New Size(229, 66)
        ProductManagement.TabIndex = 28
        ProductManagement.TextAlign = ContentAlignment.MiddleRight
        ProductManagement.UseVisualStyleBackColor = False
        ' 
        ' lblDailySalesTotal
        ' 
        lblDailySalesTotal.AutoSize = True
        lblDailySalesTotal.BackColor = Color.Transparent
        lblDailySalesTotal.Font = New Font("Franklin Gothic Medium Cond", 15.75F)
        lblDailySalesTotal.ForeColor = SystemColors.Control
        lblDailySalesTotal.Location = New Point(1087, 691)
        lblDailySalesTotal.Name = "lblDailySalesTotal"
        lblDailySalesTotal.Size = New Size(50, 26)
        lblDailySalesTotal.TabIndex = 20
        lblDailySalesTotal.Text = "0.00"
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.SteelBlue
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        btnRefresh.ForeColor = SystemColors.Control
        btnRefresh.Location = New Point(674, 150)
        btnRefresh.Margin = New Padding(3, 2, 3, 2)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(146, 29)
        btnRefresh.TabIndex = 18
        btnRefresh.Text = "Refresh"
        btnRefresh.TextImageRelation = TextImageRelation.ImageBeforeText
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' DateTimePickerTo
        ' 
        DateTimePickerTo.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        DateTimePickerTo.Format = DateTimePickerFormat.Short
        DateTimePickerTo.Location = New Point(543, 150)
        DateTimePickerTo.Name = "DateTimePickerTo"
        DateTimePickerTo.Size = New Size(125, 29)
        DateTimePickerTo.TabIndex = 5
        ' 
        ' DateTimePickerFrom
        ' 
        DateTimePickerFrom.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        DateTimePickerFrom.Format = DateTimePickerFormat.Short
        DateTimePickerFrom.Location = New Point(378, 151)
        DateTimePickerFrom.Name = "DateTimePickerFrom"
        DateTimePickerFrom.Size = New Size(124, 29)
        DateTimePickerFrom.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label2.ForeColor = SystemColors.Control
        Label2.Location = New Point(508, 155)
        Label2.Name = "Label2"
        Label2.Size = New Size(29, 24)
        Label2.TabIndex = 2
        Label2.Text = "to:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label1.ForeColor = SystemColors.Control
        Label1.Location = New Point(324, 155)
        Label1.Name = "Label1"
        Label1.Size = New Size(48, 24)
        Label1.TabIndex = 1
        Label1.Text = "Date:"
        ' 
        ' SalesDataGridView
        ' 
        SalesDataGridView.AllowDrop = True
        SalesDataGridView.AllowUserToAddRows = False
        SalesDataGridView.AllowUserToDeleteRows = False
        SalesDataGridView.BackgroundColor = SystemColors.ActiveCaptionText
        SalesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        SalesDataGridView.Location = New Point(324, 195)
        SalesDataGridView.Name = "SalesDataGridView"
        SalesDataGridView.RowHeadersWidth = 51
        DataGridViewCellStyle1.ForeColor = Color.Black
        SalesDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle1
        SalesDataGridView.Size = New Size(1000, 478)
        SalesDataGridView.TabIndex = 0
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
        Label5.Location = New Point(49, 213)
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
        lblName.Location = New Point(112, 213)
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
        Label13.Location = New Point(55, 183)
        Label13.Name = "Label13"
        Label13.Size = New Size(47, 24)
        Label13.TabIndex = 51
        Label13.Text = "Time:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label7.ForeColor = SystemColors.Control
        Label7.Location = New Point(55, 150)
        Label7.Name = "Label7"
        Label7.Size = New Size(48, 24)
        Label7.TabIndex = 50
        Label7.Text = "Date:"
        ' 
        ' lblTime
        ' 
        lblTime.AutoSize = True
        lblTime.BackColor = Color.Transparent
        lblTime.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        lblTime.ForeColor = SystemColors.Control
        lblTime.Location = New Point(112, 183)
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
        lblDate.Location = New Point(112, 150)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(40, 24)
        lblDate.TabIndex = 48
        lblDate.Text = "***"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label6.ForeColor = SystemColors.Control
        Label6.Location = New Point(324, 107)
        Label6.Name = "Label6"
        Label6.Size = New Size(48, 24)
        Label6.TabIndex = 55
        Label6.Text = "Sales"
        ' 
        ' DashboardButton
        ' 
        DashboardButton.BackColor = Color.Transparent
        DashboardButton.FlatAppearance.BorderSize = 0
        DashboardButton.FlatAppearance.CheckedBackColor = Color.Transparent
        DashboardButton.FlatAppearance.MouseDownBackColor = Color.Transparent
        DashboardButton.FlatAppearance.MouseOverBackColor = Color.Transparent
        DashboardButton.FlatStyle = FlatStyle.Flat
        DashboardButton.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DashboardButton.Location = New Point(55, 532)
        DashboardButton.Margin = New Padding(3, 2, 3, 2)
        DashboardButton.Name = "DashboardButton"
        DashboardButton.Size = New Size(229, 66)
        DashboardButton.TabIndex = 70
        DashboardButton.UseVisualStyleBackColor = False
        ' 
        ' frmSales
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = My.Resources.Resources._6
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(1366, 761)
        Controls.Add(DashboardButton)
        Controls.Add(Label6)
        Controls.Add(btnRefresh)
        Controls.Add(lblDailySalesTotal)
        Controls.Add(DateTimePickerTo)
        Controls.Add(Label5)
        Controls.Add(DateTimePickerFrom)
        Controls.Add(Label2)
        Controls.Add(Button7)
        Controls.Add(Label1)
        Controls.Add(lblName)
        Controls.Add(Label13)
        Controls.Add(SalesDataGridView)
        Controls.Add(Label7)
        Controls.Add(lblTime)
        Controls.Add(lblDate)
        Controls.Add(Sales)
        Controls.Add(UserManagement)
        Controls.Add(ProductManagement)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmSales"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmSales"
        CType(SalesDataGridView, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Button7 As Button
    Friend WithEvents Sales As Button
    Friend WithEvents UserManagement As Button
    Friend WithEvents ProductManagement As Button
    Friend WithEvents DateTimePickerTo As DateTimePicker
    Friend WithEvents DateTimePickerFrom As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SalesDataGridView As DataGridView
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label5 As Label
    Friend WithEvents lblName As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblDailySalesTotal As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents DashboardButton As Button
End Class
