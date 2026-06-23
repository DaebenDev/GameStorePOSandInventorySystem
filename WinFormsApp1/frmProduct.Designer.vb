<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProduct
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
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        ClearButton = New Button()
        Label8 = New Label()
        cmbProductCategory = New ComboBox()
        cmbCategory = New ComboBox()
        Label11 = New Label()
        Label9 = New Label()
        txtCriticalLvl = New TextBox()
        txtQuantity = New TextBox()
        txtPrice = New TextBox()
        txtProductDesc = New TextBox()
        txtProductName = New TextBox()
        Label7 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        txtProductID = New TextBox()
        dgvProducts = New DataGridView()
        SearchTxtbox = New TextBox()
        DeleteButton = New Button()
        EditButton = New Button()
        AddButton = New Button()
        Button7 = New Button()
        Sales = New Button()
        UserManagement = New Button()
        ProductManagement = New Button()
        Timer1 = New Timer(components)
        Label10 = New Label()
        lblName = New Label()
        Label13 = New Label()
        Label12 = New Label()
        lblTime = New Label()
        lblDate = New Label()
        Label6 = New Label()
        DashboardButton = New Button()
        txtPurchasePrice = New TextBox()
        Label14 = New Label()
        cmbSupplier = New ComboBox()
        Label15 = New Label()
        btnSuppliers = New Button()
        CType(dgvProducts, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ClearButton
        ' 
        ClearButton.BackColor = Color.Transparent
        ClearButton.FlatAppearance.BorderSize = 0
        ClearButton.FlatAppearance.CheckedBackColor = Color.Transparent
        ClearButton.FlatAppearance.MouseDownBackColor = Color.Transparent
        ClearButton.FlatAppearance.MouseOverBackColor = Color.Transparent
        ClearButton.FlatStyle = FlatStyle.Flat
        ClearButton.Font = New Font("Franklin Gothic Medium Cond", 12F)
        ClearButton.ForeColor = Color.Transparent
        ClearButton.Location = New Point(331, 651)
        ClearButton.Margin = New Padding(3, 2, 3, 2)
        ClearButton.Name = "ClearButton"
        ClearButton.Size = New Size(145, 62)
        ClearButton.TabIndex = 42
        ClearButton.UseVisualStyleBackColor = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.Transparent
        Label8.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label8.ForeColor = SystemColors.Control
        Label8.Location = New Point(324, 155)
        Label8.Name = "Label8"
        Label8.Size = New Size(64, 24)
        Label8.TabIndex = 41
        Label8.Text = "Search:"
        ' 
        ' cmbProductCategory
        ' 
        cmbProductCategory.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        cmbProductCategory.FormattingEnabled = True
        cmbProductCategory.Location = New Point(1008, 641)
        cmbProductCategory.Name = "cmbProductCategory"
        cmbProductCategory.Size = New Size(151, 32)
        cmbProductCategory.TabIndex = 41
        ' 
        ' cmbCategory
        ' 
        cmbCategory.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        cmbCategory.FormattingEnabled = True
        cmbCategory.Location = New Point(1008, 603)
        cmbCategory.Name = "cmbCategory"
        cmbCategory.Size = New Size(151, 32)
        cmbCategory.TabIndex = 40
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Franklin Gothic Medium Cond", 15.75F)
        Label11.ForeColor = SystemColors.Control
        Label11.Location = New Point(875, 568)
        Label11.Name = "Label11"
        Label11.Size = New Size(118, 26)
        Label11.TabIndex = 39
        Label11.Text = "Critical Level:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Franklin Gothic Medium Cond", 15.75F)
        Label9.ForeColor = SystemColors.Control
        Label9.Location = New Point(908, 536)
        Label9.Name = "Label9"
        Label9.Size = New Size(84, 26)
        Label9.TabIndex = 37
        Label9.Text = "Quantity:"
        ' 
        ' txtCriticalLvl
        ' 
        txtCriticalLvl.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtCriticalLvl.Location = New Point(1008, 568)
        txtCriticalLvl.Name = "txtCriticalLvl"
        txtCriticalLvl.ReadOnly = True
        txtCriticalLvl.Size = New Size(151, 29)
        txtCriticalLvl.TabIndex = 36
        ' 
        ' txtQuantity
        ' 
        txtQuantity.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtQuantity.Location = New Point(1008, 533)
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(151, 29)
        txtQuantity.TabIndex = 34
        ' 
        ' txtPrice
        ' 
        txtPrice.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtPrice.Location = New Point(1008, 498)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(151, 29)
        txtPrice.TabIndex = 32
        ' 
        ' txtProductDesc
        ' 
        txtProductDesc.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtProductDesc.Location = New Point(651, 556)
        txtProductDesc.Multiline = True
        txtProductDesc.Name = "txtProductDesc"
        txtProductDesc.Size = New Size(151, 122)
        txtProductDesc.TabIndex = 30
        ' 
        ' txtProductName
        ' 
        txtProductName.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtProductName.Location = New Point(651, 509)
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(151, 29)
        txtProductName.TabIndex = 29
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Franklin Gothic Medium Cond", 15.75F)
        Label7.ForeColor = SystemColors.Control
        Label7.Location = New Point(818, 644)
        Label7.Name = "Label7"
        Label7.Size = New Size(165, 26)
        Label7.TabIndex = 28
        Label7.Text = "Product Categories:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Franklin Gothic Medium Cond", 15.75F)
        Label5.ForeColor = SystemColors.Control
        Label5.Location = New Point(937, 501)
        Label5.Name = "Label5"
        Label5.Size = New Size(56, 26)
        Label5.TabIndex = 27
        Label5.Text = "Price:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Franklin Gothic Medium Cond", 15.75F)
        Label4.ForeColor = SystemColors.Control
        Label4.Location = New Point(906, 609)
        Label4.Name = "Label4"
        Label4.Size = New Size(86, 26)
        Label4.TabIndex = 26
        Label4.Text = "Category:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Franklin Gothic Medium Cond", 15.75F)
        Label3.ForeColor = SystemColors.Control
        Label3.Location = New Point(512, 557)
        Label3.Name = "Label3"
        Label3.Size = New Size(120, 26)
        Label3.TabIndex = 25
        Label3.Text = "Product Desc:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Franklin Gothic Medium Cond", 15.75F)
        Label2.ForeColor = SystemColors.Control
        Label2.Location = New Point(504, 509)
        Label2.Name = "Label2"
        Label2.Size = New Size(128, 26)
        Label2.TabIndex = 24
        Label2.Text = "Product Name:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Franklin Gothic Medium Cond", 15.75F)
        Label1.ForeColor = SystemColors.Control
        Label1.Location = New Point(537, 474)
        Label1.Name = "Label1"
        Label1.Size = New Size(95, 26)
        Label1.TabIndex = 23
        Label1.Text = "ProductID:"
        ' 
        ' txtProductID
        ' 
        txtProductID.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtProductID.Location = New Point(651, 471)
        txtProductID.Name = "txtProductID"
        txtProductID.ReadOnly = True
        txtProductID.Size = New Size(151, 29)
        txtProductID.TabIndex = 22
        ' 
        ' dgvProducts
        ' 
        dgvProducts.AllowUserToAddRows = False
        dgvProducts.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New Font("Franklin Gothic Medium Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        dgvProducts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvProducts.BackgroundColor = Color.Black
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProducts.Location = New Point(324, 195)
        dgvProducts.Name = "dgvProducts"
        dgvProducts.RowHeadersWidth = 51
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Franklin Gothic Medium Cond", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.Black
        DataGridViewCellStyle2.SelectionBackColor = Color.Gray
        DataGridViewCellStyle2.SelectionForeColor = Color.Black
        dgvProducts.RowsDefaultCellStyle = DataGridViewCellStyle2
        dgvProducts.Size = New Size(1000, 241)
        dgvProducts.TabIndex = 3
        ' 
        ' SearchTxtbox
        ' 
        SearchTxtbox.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        SearchTxtbox.Location = New Point(390, 152)
        SearchTxtbox.Name = "SearchTxtbox"
        SearchTxtbox.Size = New Size(434, 29)
        SearchTxtbox.TabIndex = 20
        ' 
        ' DeleteButton
        ' 
        DeleteButton.BackColor = Color.Transparent
        DeleteButton.FlatAppearance.BorderSize = 0
        DeleteButton.FlatAppearance.CheckedBackColor = Color.Transparent
        DeleteButton.FlatAppearance.MouseDownBackColor = Color.Transparent
        DeleteButton.FlatAppearance.MouseOverBackColor = Color.Transparent
        DeleteButton.FlatStyle = FlatStyle.Flat
        DeleteButton.Font = New Font("Franklin Gothic Medium Cond", 12F)
        DeleteButton.ForeColor = Color.Transparent
        DeleteButton.Location = New Point(331, 577)
        DeleteButton.Margin = New Padding(3, 2, 3, 2)
        DeleteButton.Name = "DeleteButton"
        DeleteButton.Size = New Size(145, 68)
        DeleteButton.TabIndex = 10
        DeleteButton.UseVisualStyleBackColor = False
        ' 
        ' EditButton
        ' 
        EditButton.BackColor = Color.Transparent
        EditButton.FlatAppearance.BorderSize = 0
        EditButton.FlatAppearance.CheckedBackColor = Color.Transparent
        EditButton.FlatAppearance.MouseDownBackColor = Color.Transparent
        EditButton.FlatAppearance.MouseOverBackColor = Color.Transparent
        EditButton.FlatStyle = FlatStyle.Flat
        EditButton.Font = New Font("Franklin Gothic Medium Cond", 12F)
        EditButton.ForeColor = Color.Transparent
        EditButton.Location = New Point(331, 511)
        EditButton.Margin = New Padding(3, 2, 3, 2)
        EditButton.Name = "EditButton"
        EditButton.Size = New Size(145, 62)
        EditButton.TabIndex = 9
        EditButton.UseVisualStyleBackColor = False
        ' 
        ' AddButton
        ' 
        AddButton.BackColor = Color.Transparent
        AddButton.FlatAppearance.BorderSize = 0
        AddButton.FlatAppearance.CheckedBackColor = Color.Transparent
        AddButton.FlatAppearance.MouseDownBackColor = Color.Transparent
        AddButton.FlatAppearance.MouseOverBackColor = Color.Transparent
        AddButton.FlatStyle = FlatStyle.Flat
        AddButton.Font = New Font("Franklin Gothic Medium Cond", 12F)
        AddButton.ForeColor = Color.Transparent
        AddButton.Location = New Point(331, 441)
        AddButton.Margin = New Padding(3, 2, 3, 2)
        AddButton.Name = "AddButton"
        AddButton.Size = New Size(145, 66)
        AddButton.TabIndex = 8
        AddButton.UseVisualStyleBackColor = False
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
        Button7.TextImageRelation = TextImageRelation.ImageBeforeText
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
        Sales.Location = New Point(56, 462)
        Sales.Margin = New Padding(3, 2, 3, 2)
        Sales.Name = "Sales"
        Sales.Size = New Size(229, 66)
        Sales.TabIndex = 27
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
        UserManagement.Location = New Point(56, 316)
        UserManagement.Margin = New Padding(3, 2, 3, 2)
        UserManagement.Name = "UserManagement"
        UserManagement.Size = New Size(229, 66)
        UserManagement.TabIndex = 26
        UserManagement.TextAlign = ContentAlignment.BottomRight
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
        ProductManagement.Location = New Point(56, 386)
        ProductManagement.Margin = New Padding(3, 2, 3, 2)
        ProductManagement.Name = "ProductManagement"
        ProductManagement.Size = New Size(229, 66)
        ProductManagement.TabIndex = 25
        ProductManagement.TextAlign = ContentAlignment.MiddleRight
        ProductManagement.UseVisualStyleBackColor = False
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 1000
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.Transparent
        Label10.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label10.ForeColor = SystemColors.Control
        Label10.Location = New Point(50, 215)
        Label10.Name = "Label10"
        Label10.Size = New Size(56, 24)
        Label10.TabIndex = 53
        Label10.Text = "Name:"
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.BackColor = Color.Transparent
        lblName.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        lblName.ForeColor = SystemColors.Control
        lblName.Location = New Point(113, 215)
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
        Label13.Location = New Point(56, 185)
        Label13.Name = "Label13"
        Label13.Size = New Size(47, 24)
        Label13.TabIndex = 51
        Label13.Text = "Time:"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.Transparent
        Label12.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label12.ForeColor = SystemColors.Control
        Label12.Location = New Point(56, 152)
        Label12.Name = "Label12"
        Label12.Size = New Size(48, 24)
        Label12.TabIndex = 50
        Label12.Text = "Date:"
        ' 
        ' lblTime
        ' 
        lblTime.AutoSize = True
        lblTime.BackColor = Color.Transparent
        lblTime.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        lblTime.ForeColor = SystemColors.Control
        lblTime.Location = New Point(113, 185)
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
        lblDate.Location = New Point(113, 152)
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
        Label6.Size = New Size(160, 24)
        Label6.TabIndex = 54
        Label6.Text = "Product Management"
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
        DashboardButton.Location = New Point(56, 533)
        DashboardButton.Margin = New Padding(3, 2, 3, 2)
        DashboardButton.Name = "DashboardButton"
        DashboardButton.Size = New Size(229, 66)
        DashboardButton.TabIndex = 71
        DashboardButton.UseVisualStyleBackColor = False
        ' 
        ' txtPurchasePrice
        ' 
        txtPurchasePrice.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtPurchasePrice.Location = New Point(1008, 466)
        txtPurchasePrice.Name = "txtPurchasePrice"
        txtPurchasePrice.Size = New Size(151, 29)
        txtPurchasePrice.TabIndex = 73
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = Color.Transparent
        Label14.Font = New Font("Franklin Gothic Medium Cond", 15.75F)
        Label14.ForeColor = SystemColors.Control
        Label14.Location = New Point(853, 471)
        Label14.Name = "Label14"
        Label14.Size = New Size(132, 26)
        Label14.TabIndex = 72
        Label14.Text = "Purchase Price:"
        ' 
        ' cmbSupplier
        ' 
        cmbSupplier.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        cmbSupplier.FormattingEnabled = True
        cmbSupplier.Location = New Point(1008, 685)
        cmbSupplier.Name = "cmbSupplier"
        cmbSupplier.Size = New Size(151, 32)
        cmbSupplier.TabIndex = 75
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.BackColor = Color.Transparent
        Label15.Font = New Font("Franklin Gothic Medium Cond", 15.75F)
        Label15.ForeColor = SystemColors.Control
        Label15.Location = New Point(907, 685)
        Label15.Name = "Label15"
        Label15.Size = New Size(83, 26)
        Label15.TabIndex = 74
        Label15.Text = "Supplier:"
        ' 
        ' btnSuppliers
        ' 
        btnSuppliers.BackColor = Color.Transparent
        btnSuppliers.FlatAppearance.BorderSize = 0
        btnSuppliers.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnSuppliers.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnSuppliers.FlatStyle = FlatStyle.Flat
        btnSuppliers.Location = New Point(1173, 442)
        btnSuppliers.Name = "btnSuppliers"
        btnSuppliers.Size = New Size(145, 62)
        btnSuppliers.TabIndex = 76
        btnSuppliers.UseVisualStyleBackColor = False
        ' 
        ' frmProduct
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        BackgroundImage = My.Resources.Resources.SalesNUsers3
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(1366, 761)
        Controls.Add(btnSuppliers)
        Controls.Add(cmbSupplier)
        Controls.Add(Label15)
        Controls.Add(txtPurchasePrice)
        Controls.Add(Label14)
        Controls.Add(DashboardButton)
        Controls.Add(Label6)
        Controls.Add(cmbProductCategory)
        Controls.Add(Label8)
        Controls.Add(cmbCategory)
        Controls.Add(SearchTxtbox)
        Controls.Add(Label11)
        Controls.Add(ClearButton)
        Controls.Add(Label9)
        Controls.Add(dgvProducts)
        Controls.Add(txtCriticalLvl)
        Controls.Add(txtQuantity)
        Controls.Add(Label10)
        Controls.Add(txtPrice)
        Controls.Add(Button7)
        Controls.Add(txtProductDesc)
        Controls.Add(lblName)
        Controls.Add(txtProductName)
        Controls.Add(Label13)
        Controls.Add(Label7)
        Controls.Add(Label12)
        Controls.Add(Label5)
        Controls.Add(DeleteButton)
        Controls.Add(Label4)
        Controls.Add(lblTime)
        Controls.Add(Label3)
        Controls.Add(EditButton)
        Controls.Add(Label2)
        Controls.Add(lblDate)
        Controls.Add(Label1)
        Controls.Add(txtProductID)
        Controls.Add(AddButton)
        Controls.Add(Sales)
        Controls.Add(UserManagement)
        Controls.Add(ProductManagement)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmProduct"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmProduct"
        CType(dgvProducts, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents SearchTxtbox As TextBox
    Friend WithEvents DeleteButton As Button
    Friend WithEvents EditButton As Button
    Friend WithEvents AddButton As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Sales As Button
    Friend WithEvents UserManagement As Button
    Friend WithEvents ProductManagement As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtProductID As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents txtProductDesc As TextBox
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCriticalLvl As TextBox
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents cmbProductCategory As ComboBox
    Friend WithEvents cmbCategory As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents lblName As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents ClearButton As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents DashboardButton As Button
    Friend WithEvents txtPurchasePrice As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbSupplier As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents btnSuppliers As Button
End Class
