<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReceipt
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
        lblStoreName = New Label()
        lblReceiptDate = New Label()
        lblReceiptTime = New Label()
        lblReceiptCashier = New Label()
        lblReceiptTotal = New Label()
        lblReceiptPaid = New Label()
        lblReceiptChange = New Label()
        lblReceiptMOP = New Label()
        dgvReceiptItems = New DataGridView()
        ProductName = New DataGridViewTextBoxColumn()
        Quantity = New DataGridViewTextBoxColumn()
        Price = New DataGridViewTextBoxColumn()
        Total = New DataGridViewTextBoxColumn()
        btnPrintReceipt = New Button()
        lblReceiptVat = New Label()
        lblReceiptNonVat = New Label()
        CType(dgvReceiptItems, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblStoreName
        ' 
        lblStoreName.AutoSize = True
        lblStoreName.Font = New Font("Franklin Gothic Heavy", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblStoreName.Location = New Point(12, 0)
        lblStoreName.Name = "lblStoreName"
        lblStoreName.Size = New Size(110, 37)
        lblStoreName.TabIndex = 0
        lblStoreName.Text = "Label1"
        ' 
        ' lblReceiptDate
        ' 
        lblReceiptDate.AutoSize = True
        lblReceiptDate.Font = New Font("Franklin Gothic Book", 14.25F)
        lblReceiptDate.Location = New Point(12, 28)
        lblReceiptDate.Name = "lblReceiptDate"
        lblReceiptDate.Size = New Size(64, 24)
        lblReceiptDate.TabIndex = 1
        lblReceiptDate.Text = "Label2"
        ' 
        ' lblReceiptTime
        ' 
        lblReceiptTime.AutoSize = True
        lblReceiptTime.Font = New Font("Franklin Gothic Book", 14.25F)
        lblReceiptTime.Location = New Point(12, 52)
        lblReceiptTime.Name = "lblReceiptTime"
        lblReceiptTime.Size = New Size(64, 24)
        lblReceiptTime.TabIndex = 2
        lblReceiptTime.Text = "Label3"
        ' 
        ' lblReceiptCashier
        ' 
        lblReceiptCashier.AutoSize = True
        lblReceiptCashier.Font = New Font("Franklin Gothic Book", 14.25F)
        lblReceiptCashier.Location = New Point(12, 76)
        lblReceiptCashier.Name = "lblReceiptCashier"
        lblReceiptCashier.Size = New Size(64, 24)
        lblReceiptCashier.TabIndex = 3
        lblReceiptCashier.Text = "Label4"
        ' 
        ' lblReceiptTotal
        ' 
        lblReceiptTotal.AutoSize = True
        lblReceiptTotal.Font = New Font("Franklin Gothic Book", 14.25F)
        lblReceiptTotal.Location = New Point(12, 262)
        lblReceiptTotal.Name = "lblReceiptTotal"
        lblReceiptTotal.Size = New Size(64, 24)
        lblReceiptTotal.TabIndex = 4
        lblReceiptTotal.Text = "Label5"
        ' 
        ' lblReceiptPaid
        ' 
        lblReceiptPaid.AutoSize = True
        lblReceiptPaid.Font = New Font("Franklin Gothic Book", 14.25F)
        lblReceiptPaid.Location = New Point(12, 286)
        lblReceiptPaid.Name = "lblReceiptPaid"
        lblReceiptPaid.Size = New Size(64, 24)
        lblReceiptPaid.TabIndex = 5
        lblReceiptPaid.Text = "Label6"
        ' 
        ' lblReceiptChange
        ' 
        lblReceiptChange.AutoSize = True
        lblReceiptChange.Font = New Font("Franklin Gothic Book", 14.25F)
        lblReceiptChange.Location = New Point(12, 313)
        lblReceiptChange.Name = "lblReceiptChange"
        lblReceiptChange.Size = New Size(64, 24)
        lblReceiptChange.TabIndex = 6
        lblReceiptChange.Text = "Label7"
        ' 
        ' lblReceiptMOP
        ' 
        lblReceiptMOP.AutoSize = True
        lblReceiptMOP.Font = New Font("Franklin Gothic Book", 14.25F)
        lblReceiptMOP.Location = New Point(12, 340)
        lblReceiptMOP.Name = "lblReceiptMOP"
        lblReceiptMOP.Size = New Size(64, 24)
        lblReceiptMOP.TabIndex = 7
        lblReceiptMOP.Text = "Label8"
        ' 
        ' dgvReceiptItems
        ' 
        dgvReceiptItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvReceiptItems.Columns.AddRange(New DataGridViewColumn() {ProductName, Quantity, Price, Total})
        dgvReceiptItems.Location = New Point(12, 115)
        dgvReceiptItems.Name = "dgvReceiptItems"
        dgvReceiptItems.Size = New Size(330, 134)
        dgvReceiptItems.TabIndex = 9
        ' 
        ' ProductName
        ' 
        ProductName.HeaderText = "ProductName"
        ProductName.Name = "ProductName"
        ' 
        ' Quantity
        ' 
        Quantity.HeaderText = "Quantity"
        Quantity.Name = "Quantity"
        ' 
        ' Price
        ' 
        Price.HeaderText = "Price"
        Price.Name = "Price"
        ' 
        ' Total
        ' 
        Total.HeaderText = "Total"
        Total.Name = "Total"
        ' 
        ' btnPrintReceipt
        ' 
        btnPrintReceipt.Location = New Point(117, 507)
        btnPrintReceipt.Name = "btnPrintReceipt"
        btnPrintReceipt.Size = New Size(134, 40)
        btnPrintReceipt.TabIndex = 10
        btnPrintReceipt.Text = "Print"
        btnPrintReceipt.UseVisualStyleBackColor = True
        ' 
        ' lblReceiptVat
        ' 
        lblReceiptVat.AutoSize = True
        lblReceiptVat.Font = New Font("Franklin Gothic Book", 14.25F)
        lblReceiptVat.Location = New Point(12, 373)
        lblReceiptVat.Name = "lblReceiptVat"
        lblReceiptVat.Size = New Size(64, 24)
        lblReceiptVat.TabIndex = 12
        lblReceiptVat.Text = "Label8"
        ' 
        ' lblReceiptNonVat
        ' 
        lblReceiptNonVat.AutoSize = True
        lblReceiptNonVat.Font = New Font("Franklin Gothic Book", 14.25F)
        lblReceiptNonVat.Location = New Point(12, 400)
        lblReceiptNonVat.Name = "lblReceiptNonVat"
        lblReceiptNonVat.Size = New Size(64, 24)
        lblReceiptNonVat.TabIndex = 13
        lblReceiptNonVat.Text = "Label8"
        ' 
        ' frmReceipt
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(367, 559)
        Controls.Add(lblReceiptNonVat)
        Controls.Add(lblReceiptVat)
        Controls.Add(btnPrintReceipt)
        Controls.Add(dgvReceiptItems)
        Controls.Add(lblReceiptMOP)
        Controls.Add(lblReceiptChange)
        Controls.Add(lblReceiptPaid)
        Controls.Add(lblReceiptTotal)
        Controls.Add(lblReceiptCashier)
        Controls.Add(lblReceiptTime)
        Controls.Add(lblReceiptDate)
        Controls.Add(lblStoreName)
        Name = "frmReceipt"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmReceipt"
        CType(dgvReceiptItems, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblStoreName As Label
    Friend WithEvents lblReceiptDate As Label
    Friend WithEvents lblReceiptTime As Label
    Friend WithEvents lblReceiptCashier As Label
    Friend WithEvents lblReceiptTotal As Label
    Friend WithEvents lblReceiptPaid As Label
    Friend WithEvents lblReceiptChange As Label
    Friend WithEvents lblReceiptMOP As Label
    Friend WithEvents dgvReceiptItems As DataGridView
    Friend WithEvents btnPrintReceipt As Button
    Friend WithEvents ProductName As DataGridViewTextBoxColumn
    Friend WithEvents Quantity As DataGridViewTextBoxColumn
    Friend WithEvents Price As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents lblReceiptVat As Label
    Friend WithEvents lblReceiptNonVat As Label
End Class
