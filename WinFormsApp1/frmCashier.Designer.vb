<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashier
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
        DataGridView1 = New DataGridView()
        AddtoCartButton = New Button()
        RemoveButton = New Button()
        CheckoutButton = New Button()
        LogOutButton = New Button()
        Label2 = New Label()
        lblTotalAmount = New Label()
        Label4 = New Label()
        lblTotalQuantity = New Label()
        lblSearch = New Label()
        txtSearch = New TextBox()
        lvlVat = New Label()
        lblNonVat = New Label()
        DataGridViewCart = New DataGridView()
        Label7 = New Label()
        Label1 = New Label()
        txtQuantity = New TextBox()
        txtProdName = New TextBox()
        txtProID = New TextBox()
        Label10 = New Label()
        Label9 = New Label()
        Label8 = New Label()
        Label11 = New Label()
        lblDate = New Label()
        Label3 = New Label()
        lblTime = New Label()
        Timer1 = New Timer(components)
        lblUserInfo = New Label()
        lblName = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridViewCart, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.BackgroundColor = Color.FromArgb(CByte(14), CByte(20), CByte(43))
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.GridColor = Color.Black
        DataGridView1.Location = New Point(325, 159)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(1000, 243)
        DataGridView1.TabIndex = 5
        ' 
        ' AddtoCartButton
        ' 
        AddtoCartButton.BackColor = Color.Transparent
        AddtoCartButton.BackgroundImageLayout = ImageLayout.Zoom
        AddtoCartButton.FlatAppearance.BorderSize = 0
        AddtoCartButton.FlatAppearance.CheckedBackColor = Color.Transparent
        AddtoCartButton.FlatAppearance.MouseDownBackColor = Color.Transparent
        AddtoCartButton.FlatAppearance.MouseOverBackColor = Color.Transparent
        AddtoCartButton.FlatStyle = FlatStyle.Flat
        AddtoCartButton.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        AddtoCartButton.ForeColor = Color.Black
        AddtoCartButton.Location = New Point(56, 172)
        AddtoCartButton.Margin = New Padding(3, 2, 3, 2)
        AddtoCartButton.Name = "AddtoCartButton"
        AddtoCartButton.Size = New Size(229, 66)
        AddtoCartButton.TabIndex = 9
        AddtoCartButton.TextAlign = ContentAlignment.MiddleRight
        AddtoCartButton.TextImageRelation = TextImageRelation.ImageBeforeText
        AddtoCartButton.UseVisualStyleBackColor = False
        ' 
        ' RemoveButton
        ' 
        RemoveButton.BackColor = Color.Transparent
        RemoveButton.FlatAppearance.BorderSize = 0
        RemoveButton.FlatAppearance.CheckedBackColor = Color.Transparent
        RemoveButton.FlatAppearance.MouseDownBackColor = Color.Transparent
        RemoveButton.FlatAppearance.MouseOverBackColor = Color.Transparent
        RemoveButton.FlatStyle = FlatStyle.Flat
        RemoveButton.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        RemoveButton.ForeColor = Color.Black
        RemoveButton.Location = New Point(56, 244)
        RemoveButton.Margin = New Padding(3, 2, 3, 2)
        RemoveButton.Name = "RemoveButton"
        RemoveButton.Size = New Size(229, 66)
        RemoveButton.TabIndex = 10
        RemoveButton.TextAlign = ContentAlignment.MiddleRight
        RemoveButton.TextImageRelation = TextImageRelation.ImageBeforeText
        RemoveButton.UseVisualStyleBackColor = False
        ' 
        ' CheckoutButton
        ' 
        CheckoutButton.BackColor = Color.Transparent
        CheckoutButton.FlatAppearance.BorderSize = 0
        CheckoutButton.FlatAppearance.CheckedBackColor = Color.Transparent
        CheckoutButton.FlatAppearance.MouseDownBackColor = Color.Transparent
        CheckoutButton.FlatAppearance.MouseOverBackColor = Color.Transparent
        CheckoutButton.FlatStyle = FlatStyle.Flat
        CheckoutButton.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        CheckoutButton.ForeColor = Color.Black
        CheckoutButton.ImageAlign = ContentAlignment.MiddleRight
        CheckoutButton.Location = New Point(56, 317)
        CheckoutButton.Margin = New Padding(3, 2, 3, 2)
        CheckoutButton.Name = "CheckoutButton"
        CheckoutButton.Size = New Size(229, 66)
        CheckoutButton.TabIndex = 11
        CheckoutButton.TextImageRelation = TextImageRelation.ImageBeforeText
        CheckoutButton.UseVisualStyleBackColor = False
        ' 
        ' LogOutButton
        ' 
        LogOutButton.BackColor = Color.Transparent
        LogOutButton.FlatAppearance.BorderSize = 0
        LogOutButton.FlatAppearance.CheckedBackColor = Color.Transparent
        LogOutButton.FlatAppearance.MouseDownBackColor = Color.Transparent
        LogOutButton.FlatAppearance.MouseOverBackColor = Color.Transparent
        LogOutButton.FlatStyle = FlatStyle.Flat
        LogOutButton.Font = New Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LogOutButton.ForeColor = Color.Black
        LogOutButton.Location = New Point(1264, 11)
        LogOutButton.Margin = New Padding(3, 2, 3, 2)
        LogOutButton.Name = "LogOutButton"
        LogOutButton.Size = New Size(73, 76)
        LogOutButton.TabIndex = 18
        LogOutButton.TextAlign = ContentAlignment.MiddleRight
        LogOutButton.TextImageRelation = TextImageRelation.ImageBeforeText
        LogOutButton.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label2.ForeColor = SystemColors.Control
        Label2.Location = New Point(840, 665)
        Label2.Name = "Label2"
        Label2.Size = New Size(107, 24)
        Label2.TabIndex = 14
        Label2.Text = "Total Amount:"
        ' 
        ' lblTotalAmount
        ' 
        lblTotalAmount.AutoSize = True
        lblTotalAmount.BackColor = Color.Transparent
        lblTotalAmount.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        lblTotalAmount.ForeColor = SystemColors.Control
        lblTotalAmount.Location = New Point(970, 667)
        lblTotalAmount.Name = "lblTotalAmount"
        lblTotalAmount.Size = New Size(45, 24)
        lblTotalAmount.TabIndex = 15
        lblTotalAmount.Text = "0.00"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label4.ForeColor = SystemColors.Control
        Label4.Location = New Point(835, 634)
        Label4.Name = "Label4"
        Label4.Size = New Size(112, 24)
        Label4.TabIndex = 16
        Label4.Text = "Total Quantity:"
        ' 
        ' lblTotalQuantity
        ' 
        lblTotalQuantity.AutoSize = True
        lblTotalQuantity.BackColor = Color.Transparent
        lblTotalQuantity.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        lblTotalQuantity.ForeColor = SystemColors.Control
        lblTotalQuantity.Location = New Point(970, 636)
        lblTotalQuantity.Name = "lblTotalQuantity"
        lblTotalQuantity.Size = New Size(20, 24)
        lblTotalQuantity.TabIndex = 17
        lblTotalQuantity.Text = "0"
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.BackColor = Color.Transparent
        lblSearch.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        lblSearch.ForeColor = SystemColors.Control
        lblSearch.Location = New Point(325, 130)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(64, 24)
        lblSearch.TabIndex = 24
        lblSearch.Text = "Search:"
        ' 
        ' txtSearch
        ' 
        txtSearch.BackColor = Color.LightGray
        txtSearch.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtSearch.Location = New Point(390, 124)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(329, 29)
        txtSearch.TabIndex = 23
        ' 
        ' lvlVat
        ' 
        lvlVat.AutoSize = True
        lvlVat.BackColor = Color.Transparent
        lvlVat.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        lvlVat.ForeColor = SystemColors.Control
        lvlVat.Location = New Point(970, 570)
        lvlVat.Name = "lvlVat"
        lvlVat.Size = New Size(20, 24)
        lvlVat.TabIndex = 22
        lvlVat.Text = "0"
        ' 
        ' lblNonVat
        ' 
        lblNonVat.AutoSize = True
        lblNonVat.BackColor = Color.Transparent
        lblNonVat.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        lblNonVat.ForeColor = SystemColors.Control
        lblNonVat.Location = New Point(970, 601)
        lblNonVat.Name = "lblNonVat"
        lblNonVat.Size = New Size(45, 24)
        lblNonVat.TabIndex = 21
        lblNonVat.Text = "0.00"
        ' 
        ' DataGridViewCart
        ' 
        DataGridViewCart.AllowUserToAddRows = False
        DataGridViewCart.AllowUserToDeleteRows = False
        DataGridViewCart.BackgroundColor = Color.FromArgb(CByte(14), CByte(20), CByte(43))
        DataGridViewCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCart.GridColor = Color.Black
        DataGridViewCart.Location = New Point(332, 477)
        DataGridViewCart.Name = "DataGridViewCart"
        DataGridViewCart.RowHeadersWidth = 51
        DataGridViewCart.Size = New Size(482, 239)
        DataGridViewCart.TabIndex = 20
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label7.ForeColor = SystemColors.Control
        Label7.Location = New Point(874, 603)
        Label7.Name = "Label7"
        Label7.Size = New Size(73, 24)
        Label7.TabIndex = 19
        Label7.Text = "Non-Vat:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label1.ForeColor = SystemColors.Control
        Label1.Location = New Point(909, 568)
        Label1.Name = "Label1"
        Label1.Size = New Size(38, 24)
        Label1.TabIndex = 18
        Label1.Text = "Vat:"
        ' 
        ' txtQuantity
        ' 
        txtQuantity.BackColor = Color.LightGray
        txtQuantity.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtQuantity.ForeColor = Color.Black
        txtQuantity.Location = New Point(953, 534)
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(206, 29)
        txtQuantity.TabIndex = 11
        ' 
        ' txtProdName
        ' 
        txtProdName.BackColor = Color.LightGray
        txtProdName.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtProdName.ForeColor = Color.Black
        txtProdName.Location = New Point(953, 504)
        txtProdName.Name = "txtProdName"
        txtProdName.ReadOnly = True
        txtProdName.Size = New Size(206, 29)
        txtProdName.TabIndex = 10
        ' 
        ' txtProID
        ' 
        txtProID.BackColor = Color.LightGray
        txtProID.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtProID.ForeColor = Color.Black
        txtProID.Location = New Point(953, 474)
        txtProID.Name = "txtProID"
        txtProID.ReadOnly = True
        txtProID.Size = New Size(206, 29)
        txtProID.TabIndex = 9
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.Transparent
        Label10.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label10.ForeColor = SystemColors.Control
        Label10.Location = New Point(873, 539)
        Label10.Name = "Label10"
        Label10.Size = New Size(74, 24)
        Label10.TabIndex = 8
        Label10.Text = "Quantity:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.Transparent
        Label9.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label9.ForeColor = SystemColors.Control
        Label9.Location = New Point(837, 507)
        Label9.Name = "Label9"
        Label9.Size = New Size(110, 24)
        Label9.TabIndex = 7
        Label9.Text = "ProductName:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.Transparent
        Label8.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label8.ForeColor = SystemColors.Control
        Label8.Location = New Point(862, 477)
        Label8.Name = "Label8"
        Label8.Size = New Size(85, 24)
        Label8.TabIndex = 6
        Label8.Text = "ProductID:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.Transparent
        Label11.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label11.ForeColor = SystemColors.Control
        Label11.Location = New Point(75, 462)
        Label11.Name = "Label11"
        Label11.Size = New Size(48, 24)
        Label11.TabIndex = 26
        Label11.Text = "Date:"
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.BackColor = Color.Transparent
        lblDate.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        lblDate.ForeColor = SystemColors.Control
        lblDate.Location = New Point(129, 462)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(40, 24)
        lblDate.TabIndex = 27
        lblDate.Text = "***"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label3.ForeColor = SystemColors.Control
        Label3.Location = New Point(76, 491)
        Label3.Name = "Label3"
        Label3.Size = New Size(47, 24)
        Label3.TabIndex = 28
        Label3.Text = "Time:"
        ' 
        ' lblTime
        ' 
        lblTime.AutoSize = True
        lblTime.BackColor = Color.Transparent
        lblTime.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        lblTime.ForeColor = SystemColors.Control
        lblTime.Location = New Point(129, 491)
        lblTime.Name = "lblTime"
        lblTime.Size = New Size(40, 24)
        lblTime.TabIndex = 29
        lblTime.Text = "***"
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 1000
        ' 
        ' lblUserInfo
        ' 
        lblUserInfo.AutoSize = True
        lblUserInfo.BackColor = Color.Transparent
        lblUserInfo.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        lblUserInfo.ForeColor = SystemColors.Control
        lblUserInfo.Location = New Point(83, 528)
        lblUserInfo.Name = "lblUserInfo"
        lblUserInfo.Size = New Size(40, 24)
        lblUserInfo.TabIndex = 30
        lblUserInfo.Text = "***"
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.BackColor = Color.Transparent
        lblName.Font = New Font("Franklin Gothic Medium Cond", 12F)
        lblName.Location = New Point(73, 615)
        lblName.Name = "lblName"
        lblName.Size = New Size(34, 21)
        lblName.TabIndex = 24
        lblName.Text = "***"
        lblName.Visible = False
        ' 
        ' frmCashier
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        BackgroundImage = My.Resources.Resources.Cashier
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(1366, 761)
        Controls.Add(LogOutButton)
        Controls.Add(lblNonVat)
        Controls.Add(DataGridView1)
        Controls.Add(txtQuantity)
        Controls.Add(lblSearch)
        Controls.Add(Label2)
        Controls.Add(lblUserInfo)
        Controls.Add(lvlVat)
        Controls.Add(DataGridViewCart)
        Controls.Add(txtProdName)
        Controls.Add(txtSearch)
        Controls.Add(lblTotalQuantity)
        Controls.Add(lblTime)
        Controls.Add(lblTotalAmount)
        Controls.Add(CheckoutButton)
        Controls.Add(Label8)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label9)
        Controls.Add(RemoveButton)
        Controls.Add(txtProID)
        Controls.Add(lblDate)
        Controls.Add(Label7)
        Controls.Add(AddtoCartButton)
        Controls.Add(Label1)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(lblName)
        ForeColor = Color.Black
        FormBorderStyle = FormBorderStyle.None
        Name = "frmCashier"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmCashier"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridViewCart, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents AddtoCartButton As Button
    Friend WithEvents RemoveButton As Button
    Friend WithEvents CheckoutButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTotalQuantity As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents txtProdName As TextBox
    Friend WithEvents txtProID As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents LogOutButton As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lvlVat As Label
    Friend WithEvents lblNonVat As Label
    Friend WithEvents DataGridViewCart As DataGridView
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblUserInfo As Label
    Friend WithEvents lblName As Label
End Class
