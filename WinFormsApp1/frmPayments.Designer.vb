<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payments
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
        CancelButton = New Button()
        ConfirmPaymentButton = New Button()
        dgvProductList = New DataGridView()
        Column1 = New DataGridViewTextBoxColumn()
        Column7 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        Column4 = New DataGridViewTextBoxColumn()
        Column5 = New DataGridViewTextBoxColumn()
        Column6 = New DataGridViewTextBoxColumn()
        txtAmountPaid = New TextBox()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        cmbModeofPayment = New ComboBox()
        Label5 = New Label()
        Label6 = New Label()
        Panel1 = New Panel()
        GroupBox1 = New GroupBox()
        lblNonVat = New Label()
        lvlVat = New Label()
        lblTotalQuantity = New Label()
        Label1 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        lblTotalAmount = New Label()
        lblChange = New Label()
        Label9 = New Label()
        Label10 = New Label()
        lblDate = New Label()
        lblTime = New Label()
        lblCashierName = New Label()
        Timer1 = New Timer(components)
        lblUserInfo = New Label()
        btnVoid = New Button()
        CType(dgvProductList, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' CancelButton
        ' 
        CancelButton.BackColor = Color.Maroon
        CancelButton.FlatStyle = FlatStyle.Flat
        CancelButton.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        CancelButton.Location = New Point(261, 662)
        CancelButton.Margin = New Padding(3, 2, 3, 2)
        CancelButton.Name = "CancelButton"
        CancelButton.Size = New Size(86, 41)
        CancelButton.TabIndex = 10
        CancelButton.Text = "Cancel"
        CancelButton.UseVisualStyleBackColor = False
        ' 
        ' ConfirmPaymentButton
        ' 
        ConfirmPaymentButton.BackColor = Color.SteelBlue
        ConfirmPaymentButton.FlatStyle = FlatStyle.Flat
        ConfirmPaymentButton.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ConfirmPaymentButton.Location = New Point(5, 662)
        ConfirmPaymentButton.Margin = New Padding(3, 2, 3, 2)
        ConfirmPaymentButton.Name = "ConfirmPaymentButton"
        ConfirmPaymentButton.Size = New Size(143, 41)
        ConfirmPaymentButton.TabIndex = 11
        ConfirmPaymentButton.Text = "Confirm Payment"
        ConfirmPaymentButton.UseVisualStyleBackColor = False
        ' 
        ' dgvProductList
        ' 
        dgvProductList.AllowUserToAddRows = False
        dgvProductList.AllowUserToDeleteRows = False
        dgvProductList.BackgroundColor = Color.FromArgb(CByte(14), CByte(20), CByte(43))
        dgvProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProductList.Columns.AddRange(New DataGridViewColumn() {Column1, Column7, Column2, Column3, Column4, Column5, Column6})
        dgvProductList.Location = New Point(6, 19)
        dgvProductList.Margin = New Padding(3, 2, 3, 2)
        dgvProductList.Name = "dgvProductList"
        dgvProductList.RowHeadersWidth = 51
        dgvProductList.Size = New Size(339, 183)
        dgvProductList.TabIndex = 13
        ' 
        ' Column1
        ' 
        Column1.HeaderText = "Product ID"
        Column1.MinimumWidth = 6
        Column1.Name = "Column1"
        Column1.Width = 125
        ' 
        ' Column7
        ' 
        Column7.HeaderText = "Product Name"
        Column7.MinimumWidth = 6
        Column7.Name = "Column7"
        Column7.Width = 125
        ' 
        ' Column2
        ' 
        Column2.HeaderText = "Quantity"
        Column2.MinimumWidth = 6
        Column2.Name = "Column2"
        Column2.Width = 125
        ' 
        ' Column3
        ' 
        Column3.HeaderText = "Price"
        Column3.MinimumWidth = 6
        Column3.Name = "Column3"
        Column3.Width = 125
        ' 
        ' Column4
        ' 
        Column4.HeaderText = "VAT"
        Column4.MinimumWidth = 6
        Column4.Name = "Column4"
        Column4.Width = 125
        ' 
        ' Column5
        ' 
        Column5.HeaderText = "Non-VAT"
        Column5.MinimumWidth = 6
        Column5.Name = "Column5"
        Column5.Width = 125
        ' 
        ' Column6
        ' 
        Column6.HeaderText = "Total"
        Column6.MinimumWidth = 6
        Column6.Name = "Column6"
        Column6.Width = 125
        ' 
        ' txtAmountPaid
        ' 
        txtAmountPaid.BackColor = Color.LightGray
        txtAmountPaid.Font = New Font("Franklin Gothic Medium Cond", 12F)
        txtAmountPaid.Location = New Point(161, 542)
        txtAmountPaid.Margin = New Padding(3, 2, 3, 2)
        txtAmountPaid.Name = "txtAmountPaid"
        txtAmountPaid.Size = New Size(133, 26)
        txtAmountPaid.TabIndex = 14
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Franklin Gothic Medium Cond", 12F)
        Label2.Location = New Point(39, 545)
        Label2.Name = "Label2"
        Label2.Size = New Size(88, 21)
        Label2.TabIndex = 17
        Label2.Text = "Amount Paid:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Franklin Gothic Medium Cond", 12F)
        Label3.Location = New Point(35, 584)
        Label3.Name = "Label3"
        Label3.Size = New Size(88, 21)
        Label3.TabIndex = 18
        Label3.Text = "Total Change:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Franklin Gothic Medium Cond", 12F)
        Label4.Location = New Point(35, 472)
        Label4.Name = "Label4"
        Label4.Size = New Size(89, 21)
        Label4.TabIndex = 19
        Label4.Text = "Total Amount:"
        ' 
        ' cmbModeofPayment
        ' 
        cmbModeofPayment.BackColor = Color.LightGray
        cmbModeofPayment.DropDownStyle = ComboBoxStyle.DropDownList
        cmbModeofPayment.Font = New Font("Franklin Gothic Medium Cond", 12F)
        cmbModeofPayment.FormattingEnabled = True
        cmbModeofPayment.Location = New Point(161, 503)
        cmbModeofPayment.Margin = New Padding(3, 2, 3, 2)
        cmbModeofPayment.Name = "cmbModeofPayment"
        cmbModeofPayment.Size = New Size(133, 29)
        cmbModeofPayment.TabIndex = 20
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Franklin Gothic Medium Cond", 12F)
        Label5.Location = New Point(5, 511)
        Label5.Name = "Label5"
        Label5.Size = New Size(114, 21)
        Label5.TabIndex = 21
        Label5.Text = "Mode of Payment:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Franklin Gothic Demi", 24F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(113, 9)
        Label6.Name = "Label6"
        Label6.Size = New Size(139, 37)
        Label6.TabIndex = 10
        Label6.Text = "Payment"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Black
        Panel1.Controls.Add(Label6)
        Panel1.ForeColor = Color.Silver
        Panel1.Location = New Point(-6, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(368, 60)
        Panel1.TabIndex = 22
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(dgvProductList)
        GroupBox1.Font = New Font("Franklin Gothic Medium Cond", 12F)
        GroupBox1.Location = New Point(2, 153)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(351, 217)
        GroupBox1.TabIndex = 23
        GroupBox1.TabStop = False
        GroupBox1.Text = "Item Sold"
        ' 
        ' lblNonVat
        ' 
        lblNonVat.AutoSize = True
        lblNonVat.Font = New Font("Franklin Gothic Medium Cond", 12F)
        lblNonVat.Location = New Point(161, 404)
        lblNonVat.Name = "lblNonVat"
        lblNonVat.Size = New Size(38, 21)
        lblNonVat.TabIndex = 28
        lblNonVat.Text = "0.00"
        ' 
        ' lvlVat
        ' 
        lvlVat.AutoSize = True
        lvlVat.Font = New Font("Franklin Gothic Medium Cond", 12F)
        lvlVat.Location = New Point(161, 373)
        lvlVat.Name = "lvlVat"
        lvlVat.Size = New Size(18, 21)
        lvlVat.TabIndex = 29
        lvlVat.Text = "0"
        ' 
        ' lblTotalQuantity
        ' 
        lblTotalQuantity.AutoSize = True
        lblTotalQuantity.Font = New Font("Franklin Gothic Medium Cond", 12F)
        lblTotalQuantity.Location = New Point(161, 439)
        lblTotalQuantity.Name = "lblTotalQuantity"
        lblTotalQuantity.Size = New Size(18, 21)
        lblTotalQuantity.TabIndex = 25
        lblTotalQuantity.Text = "0"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Franklin Gothic Medium Cond", 12F)
        Label1.Location = New Point(32, 439)
        Label1.Name = "Label1"
        Label1.Size = New Size(93, 21)
        Label1.TabIndex = 24
        Label1.Text = "Total Quantity:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Franklin Gothic Medium Cond", 12F)
        Label7.Location = New Point(72, 404)
        Label7.Name = "Label7"
        Label7.Size = New Size(60, 21)
        Label7.TabIndex = 27
        Label7.Text = "Non-Vat:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Franklin Gothic Medium Cond", 12F)
        Label8.Location = New Point(107, 373)
        Label8.Name = "Label8"
        Label8.Size = New Size(32, 21)
        Label8.TabIndex = 26
        Label8.Text = "Vat:"
        ' 
        ' lblTotalAmount
        ' 
        lblTotalAmount.AutoSize = True
        lblTotalAmount.Font = New Font("Franklin Gothic Medium Cond", 12F)
        lblTotalAmount.Location = New Point(161, 472)
        lblTotalAmount.Name = "lblTotalAmount"
        lblTotalAmount.Size = New Size(38, 21)
        lblTotalAmount.TabIndex = 30
        lblTotalAmount.Text = "0.00"
        ' 
        ' lblChange
        ' 
        lblChange.AutoSize = True
        lblChange.Font = New Font("Franklin Gothic Medium Cond", 12F)
        lblChange.Location = New Point(140, 584)
        lblChange.Name = "lblChange"
        lblChange.Size = New Size(38, 21)
        lblChange.TabIndex = 31
        lblChange.Text = "0.00"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Franklin Gothic Medium Cond", 12F)
        Label9.Location = New Point(82, 87)
        Label9.Name = "Label9"
        Label9.Size = New Size(41, 21)
        Label9.TabIndex = 32
        Label9.Text = "Date:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Franklin Gothic Medium Cond", 12F)
        Label10.Location = New Point(81, 108)
        Label10.Name = "Label10"
        Label10.Size = New Size(42, 21)
        Label10.TabIndex = 33
        Label10.Text = "Time:"
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.Font = New Font("Franklin Gothic Medium Cond", 12F)
        lblDate.Location = New Point(139, 87)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(34, 21)
        lblDate.TabIndex = 35
        lblDate.Text = "***"
        ' 
        ' lblTime
        ' 
        lblTime.AutoSize = True
        lblTime.Font = New Font("Franklin Gothic Medium Cond", 12F)
        lblTime.Location = New Point(139, 108)
        lblTime.Name = "lblTime"
        lblTime.Size = New Size(34, 21)
        lblTime.TabIndex = 36
        lblTime.Text = "***"
        ' 
        ' lblCashierName
        ' 
        lblCashierName.AutoSize = True
        lblCashierName.Font = New Font("Franklin Gothic Medium Cond", 12F)
        lblCashierName.Location = New Point(139, 66)
        lblCashierName.Name = "lblCashierName"
        lblCashierName.Size = New Size(34, 21)
        lblCashierName.TabIndex = 37
        lblCashierName.Text = "***"
        lblCashierName.Visible = False
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 1000
        ' 
        ' lblUserInfo
        ' 
        lblUserInfo.AutoSize = True
        lblUserInfo.Font = New Font("Franklin Gothic Medium Cond", 12F)
        lblUserInfo.Location = New Point(89, 129)
        lblUserInfo.Name = "lblUserInfo"
        lblUserInfo.Size = New Size(34, 21)
        lblUserInfo.TabIndex = 40
        lblUserInfo.Text = "***"
        lblUserInfo.Visible = False
        ' 
        ' btnVoid
        ' 
        btnVoid.BackColor = Color.Maroon
        btnVoid.FlatStyle = FlatStyle.Flat
        btnVoid.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnVoid.Location = New Point(154, 662)
        btnVoid.Margin = New Padding(3, 2, 3, 2)
        btnVoid.Name = "btnVoid"
        btnVoid.Size = New Size(101, 41)
        btnVoid.TabIndex = 41
        btnVoid.Text = "Void"
        btnVoid.UseVisualStyleBackColor = False
        ' 
        ' Payments
        ' 
        AutoScaleDimensions = New SizeF(6F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(355, 714)
        Controls.Add(btnVoid)
        Controls.Add(lblUserInfo)
        Controls.Add(lblCashierName)
        Controls.Add(lblTime)
        Controls.Add(lblDate)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(lblChange)
        Controls.Add(lblTotalAmount)
        Controls.Add(lblNonVat)
        Controls.Add(lvlVat)
        Controls.Add(lblTotalQuantity)
        Controls.Add(Label1)
        Controls.Add(Label7)
        Controls.Add(Label8)
        Controls.Add(GroupBox1)
        Controls.Add(Panel1)
        Controls.Add(Label5)
        Controls.Add(cmbModeofPayment)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(txtAmountPaid)
        Controls.Add(ConfirmPaymentButton)
        Controls.Add(CancelButton)
        Font = New Font("Franklin Gothic Medium Cond", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ForeColor = Color.Silver
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "Payments"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Payments"
        CType(dgvProductList, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        GroupBox1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents CancelButton As Button
    Friend WithEvents ConfirmPaymentButton As Button
    Friend WithEvents dgvProductList As DataGridView
    Friend WithEvents txtAmountPaid As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbModeofPayment As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblNonVat As Label
    Friend WithEvents lvlVat As Label
    Friend WithEvents lblTotalQuantity As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents lblCashierName As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblUserInfo As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents btnVoid As Button
End Class
