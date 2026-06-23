<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSuppliers
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
        txtSupplierID = New TextBox()
        txtSupplierName = New TextBox()
        txtContactPerson = New TextBox()
        txtPhoneNumber = New TextBox()
        txtEmail = New TextBox()
        txtAddress = New TextBox()
        txtSearch = New TextBox()
        btnAdd = New Button()
        btnEdit = New Button()
        btnClear = New Button()
        btnDelete = New Button()
        dgvSuppliers = New DataGridView()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        btnBack = New Button()
        lblName = New Label()
        CType(dgvSuppliers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtSupplierID
        ' 
        txtSupplierID.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtSupplierID.Location = New Point(348, 341)
        txtSupplierID.Name = "txtSupplierID"
        txtSupplierID.Size = New Size(178, 29)
        txtSupplierID.TabIndex = 0
        ' 
        ' txtSupplierName
        ' 
        txtSupplierName.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtSupplierName.Location = New Point(348, 378)
        txtSupplierName.Name = "txtSupplierName"
        txtSupplierName.Size = New Size(178, 29)
        txtSupplierName.TabIndex = 1
        ' 
        ' txtContactPerson
        ' 
        txtContactPerson.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtContactPerson.Location = New Point(348, 413)
        txtContactPerson.Name = "txtContactPerson"
        txtContactPerson.Size = New Size(178, 29)
        txtContactPerson.TabIndex = 2
        ' 
        ' txtPhoneNumber
        ' 
        txtPhoneNumber.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtPhoneNumber.Location = New Point(348, 448)
        txtPhoneNumber.Name = "txtPhoneNumber"
        txtPhoneNumber.Size = New Size(178, 29)
        txtPhoneNumber.TabIndex = 3
        ' 
        ' txtEmail
        ' 
        txtEmail.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtEmail.Location = New Point(348, 483)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(178, 29)
        txtEmail.TabIndex = 4
        ' 
        ' txtAddress
        ' 
        txtAddress.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtAddress.Location = New Point(348, 518)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(178, 29)
        txtAddress.TabIndex = 5
        ' 
        ' txtSearch
        ' 
        txtSearch.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        txtSearch.Location = New Point(95, 98)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(297, 29)
        txtSearch.TabIndex = 6
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.Transparent
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.FlatAppearance.CheckedBackColor = Color.Transparent
        btnAdd.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnAdd.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        btnAdd.Location = New Point(21, 333)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(95, 46)
        btnAdd.TabIndex = 7
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = Color.Transparent
        btnEdit.FlatAppearance.BorderSize = 0
        btnEdit.FlatAppearance.CheckedBackColor = Color.Transparent
        btnEdit.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnEdit.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnEdit.FlatStyle = FlatStyle.Flat
        btnEdit.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        btnEdit.Location = New Point(21, 390)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(95, 46)
        btnEdit.TabIndex = 8
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.Transparent
        btnClear.FlatAppearance.BorderSize = 0
        btnClear.FlatAppearance.CheckedBackColor = Color.Transparent
        btnClear.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnClear.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        btnClear.Location = New Point(21, 491)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(95, 46)
        btnClear.TabIndex = 9
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Transparent
        btnDelete.FlatAppearance.BorderSize = 0
        btnDelete.FlatAppearance.CheckedBackColor = Color.Transparent
        btnDelete.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnDelete.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        btnDelete.Location = New Point(21, 441)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(95, 46)
        btnDelete.TabIndex = 10
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' dgvSuppliers
        ' 
        dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSuppliers.Location = New Point(21, 137)
        dgvSuppliers.Name = "dgvSuppliers"
        dgvSuppliers.Size = New Size(857, 181)
        dgvSuppliers.TabIndex = 11
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(21, 101)
        Label1.Name = "Label1"
        Label1.Size = New Size(68, 24)
        Label1.TabIndex = 12
        Label1.Text = "Search :"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(245, 344)
        Label2.Name = "Label2"
        Label2.Size = New Size(97, 24)
        Label2.TabIndex = 13
        Label2.Text = "Supplier ID :"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(220, 383)
        Label3.Name = "Label3"
        Label3.Size = New Size(122, 24)
        Label3.TabIndex = 14
        Label3.Text = "Supplier Name :"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(217, 416)
        Label4.Name = "Label4"
        Label4.Size = New Size(125, 24)
        Label4.TabIndex = 15
        Label4.Text = "Contact Person :"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(220, 451)
        Label5.Name = "Label5"
        Label5.Size = New Size(122, 24)
        Label5.TabIndex = 16
        Label5.Text = "Phone Number :"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(284, 486)
        Label6.Name = "Label6"
        Label6.Size = New Size(58, 24)
        Label6.TabIndex = 17
        Label6.Text = "Email :"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.Transparent
        Label7.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        Label7.ForeColor = Color.White
        Label7.Location = New Point(269, 521)
        Label7.Name = "Label7"
        Label7.Size = New Size(73, 24)
        Label7.TabIndex = 18
        Label7.Text = "Address :"
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.Transparent
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.FlatAppearance.CheckedBackColor = Color.Transparent
        btnBack.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnBack.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Font = New Font("Franklin Gothic Medium Cond", 14.25F)
        btnBack.Location = New Point(773, 488)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(95, 46)
        btnBack.TabIndex = 20
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.BackColor = Color.White
        lblName.Location = New Point(12, 9)
        lblName.Name = "lblName"
        lblName.Size = New Size(0, 15)
        lblName.TabIndex = 21
        lblName.Visible = False
        ' 
        ' frmSuppliers
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.GameHUb_imresizer
        ClientSize = New Size(896, 579)
        Controls.Add(lblName)
        Controls.Add(btnBack)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(dgvSuppliers)
        Controls.Add(btnDelete)
        Controls.Add(btnClear)
        Controls.Add(btnEdit)
        Controls.Add(btnAdd)
        Controls.Add(txtSearch)
        Controls.Add(txtAddress)
        Controls.Add(txtEmail)
        Controls.Add(txtPhoneNumber)
        Controls.Add(txtContactPerson)
        Controls.Add(txtSupplierName)
        Controls.Add(txtSupplierID)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmSuppliers"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmSuppliers"
        CType(dgvSuppliers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtSupplierID As TextBox
    Friend WithEvents txtSupplierName As TextBox
    Friend WithEvents txtContactPerson As TextBox
    Friend WithEvents txtPhoneNumber As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents dgvSuppliers As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents lblName As Label
End Class
