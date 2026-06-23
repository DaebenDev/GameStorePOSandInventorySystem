Imports System.Data.OleDb

Public Class Payments

    Private cashierID As Integer
    Private cashierForm As frmCashier

    Public Sub SetCashierForm(cashier As frmCashier)
        cashierForm = cashier
    End Sub

    Public Sub SetCashierName(cashierName As String)
        lblCashierName.Text = cashierName
    End Sub

    Public Sub SetPaymentDetails(totalAmount As Decimal, totalQuantity As Integer)
        lblTotalAmount.Text = totalAmount.ToString("N2")
        lblTotalQuantity.Text = totalQuantity.ToString()
    End Sub

    Public Sub SetUserID(userID As Integer)
        cashierID = userID
    End Sub

    Public Sub SetUserInfo(userID As Integer, username As String)
        cashierID = userID
        lblUserInfo.Text = "User ID: " & userID.ToString() & " | Name: " & username
        lblCashierName.Text = username
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Now.ToShortDateString()
        lblTime.Text = Now.ToShortTimeString()
    End Sub

    Public Sub SetPaymentAmounts(vat As Decimal, nonvat As Decimal, total As Decimal, quantity As Integer)
        lvlVat.Text = vat.ToString("N2")
        lblNonVat.Text = nonvat.ToString("N2")

        ' Calculate the correct total here
        Dim correctTotal As Decimal = vat + nonvat
        lblTotalAmount.Text = correctTotal.ToString("N2")

        lblTotalQuantity.Text = quantity.ToString()
    End Sub

    Private Sub ConfirmPaymentButton_Click(sender As Object, e As EventArgs) Handles ConfirmPaymentButton.Click
        Dim amountPaid As Decimal
        Dim totalAmount As Decimal

        If Not Decimal.TryParse(txtAmountPaid.Text, amountPaid) OrElse Not Decimal.TryParse(lblTotalAmount.Text, totalAmount) Then
            MessageBox.Show("Invalid payment amount.")
            Exit Sub
        End If

        If amountPaid < totalAmount Then
            MessageBox.Show("Amount paid is not enough.")
            Exit Sub
        End If

        If cmbModeofPayment.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a mode of payment.")
            Exit Sub
        End If

        Dim change As Decimal = amountPaid - totalAmount
        lblChange.Text = change.ToString("N2")
        MessageBox.Show("Payment successful! Change: " & change.ToString("N2"))


        Dim connStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Database\GamePOS.accdb"
        Using con As New OleDbConnection(connStr)
            con.Open()
            Dim trans As OleDbTransaction = con.BeginTransaction()

            Try
                ' Insert into Transactions
                Dim insertTransCmd As New OleDbCommand("INSERT INTO Transactions (UserID, TransDate, TotalAmount) VALUES (?, ?, ?)", con, trans)
                insertTransCmd.Parameters.Add("@UserID", OleDbType.Integer).Value = cashierID
                insertTransCmd.Parameters.Add("@TransDate", OleDbType.Date).Value = DateTime.Now
                insertTransCmd.Parameters.Add("@TotalAmount", OleDbType.Currency).Value = totalAmount
                insertTransCmd.ExecuteNonQuery()

                ' Get Transaction ID
                Dim getTransIDCmd As New OleDbCommand("SELECT @@IDENTITY", con, trans)
                Dim transIDObj = getTransIDCmd.ExecuteScalar()
                If transIDObj Is Nothing OrElse IsDBNull(transIDObj) Then
                    Throw New Exception("Failed to get Transaction ID.")
                End If
                Dim transID As Integer = Convert.ToInt32(transIDObj)

                ' Get MOP ID
                Dim mopName As String = cmbModeofPayment.SelectedItem.ToString()
                Dim mopIDCmd As New OleDbCommand("SELECT MOPID FROM MOP WHERE MOPName = ?", con, trans)
                mopIDCmd.Parameters.Add("@MOPName", OleDbType.VarChar).Value = mopName
                Dim mopIDObj = mopIDCmd.ExecuteScalar()
                If mopIDObj Is Nothing OrElse IsDBNull(mopIDObj) Then
                    Throw New Exception("Invalid mode of payment selected.")
                End If
                Dim mopID As Integer = Convert.ToInt32(mopIDObj)

                ' Insert into Payments
                Dim insPayment As New OleDbCommand("INSERT INTO Payments (TransID, MOPID, AmountPaid, AmountChange, PaymentDate, UserID) VALUES (?, ?, ?, ?, ?, ?)", con, trans)
                insPayment.Parameters.Add("@TransID", OleDbType.Integer).Value = transID
                insPayment.Parameters.Add("@MOPID", OleDbType.Integer).Value = mopID
                insPayment.Parameters.Add("@AmountPaid", OleDbType.Currency).Value = amountPaid
                insPayment.Parameters.Add("@AmountChange", OleDbType.Currency).Value = change
                insPayment.Parameters.Add("@PaymentDate", OleDbType.Date).Value = DateTime.Now
                insPayment.Parameters.Add("@UserID", OleDbType.Integer).Value = cashierID
                insPayment.ExecuteNonQuery()

                ' Get Payment ID
                Dim getPaymentIDCmd As New OleDbCommand("SELECT @@IDENTITY", con, trans)
                Dim paymentIDObj = getPaymentIDCmd.ExecuteScalar()
                If paymentIDObj Is Nothing OrElse IsDBNull(paymentIDObj) Then
                    Throw New Exception("Failed to get Payment ID.")
                End If
                Dim paymentID As Integer = Convert.ToInt32(paymentIDObj)

                ' Variables to hold VAT and Non-VAT for the whole transaction
                Dim transactionVat As Decimal = 0D
                Dim transactionNonVat As Decimal = 0D

                ' Insert into TransDetails and Purchase, Update Inventory
                For Each row As DataGridViewRow In dgvProductList.Rows
                    If row.IsNewRow Then Continue For

                    Dim productID As Integer = 0
                    Dim quantity As Integer = 0
                    Dim vat As Decimal = 0D
                    Dim nonvat As Decimal = 0D
                    Dim total As Decimal = 0D

                    ' Check if columns exist to avoid crash
                    If dgvProductList.Columns.Contains("ProductID") Then
                        Integer.TryParse(row.Cells("ProductID").Value?.ToString(), productID)
                    Else
                        Integer.TryParse(row.Cells(0).Value?.ToString(), productID)
                    End If

                    If dgvProductList.Columns.Contains("Quantity") Then
                        Integer.TryParse(row.Cells("Quantity").Value?.ToString(), quantity)
                    Else
                        Integer.TryParse(row.Cells(2).Value?.ToString(), quantity)
                    End If

                    If dgvProductList.Columns.Contains("VAT") Then
                        Decimal.TryParse(row.Cells("VAT").Value?.ToString(), vat)
                    Else
                        Decimal.TryParse(row.Cells(4).Value?.ToString(), vat)
                    End If

                    If dgvProductList.Columns.Contains("NonVAT") Then
                        Decimal.TryParse(row.Cells("NonVAT").Value?.ToString(), nonvat)
                    Else
                        Decimal.TryParse(row.Cells(5).Value?.ToString(), nonvat)
                    End If

                    If dgvProductList.Columns.Contains("Total") Then
                        Decimal.TryParse(row.Cells("Total").Value?.ToString(), total)
                    Else
                        Decimal.TryParse(row.Cells(6).Value?.ToString(), total)
                    End If

                    ' Accumulate VAT and Non-VAT
                    transactionVat += vat
                    transactionNonVat += nonvat

                    ' Insert TransDetails
                    Dim insTD As New OleDbCommand("INSERT INTO TransDetails (ProductID, UserID, TransID, TotalPrice, VAT, NONVAT) VALUES (?, ?, ?, ?, ?, ?)", con, trans)
                    insTD.Parameters.Add("@ProductID", OleDbType.Integer).Value = productID
                    insTD.Parameters.Add("@UserID", OleDbType.Integer).Value = cashierID
                    insTD.Parameters.Add("@TransID", OleDbType.Integer).Value = transID
                    insTD.Parameters.Add("@TotalPrice", OleDbType.Currency).Value = total
                    insTD.Parameters.Add("@VAT", OleDbType.Currency).Value = vat
                    insTD.Parameters.Add("@NONVAT", OleDbType.Currency).Value = nonvat
                    insTD.ExecuteNonQuery()

                    ' Insert Purchase
                    Dim insPurchase As New OleDbCommand("INSERT INTO Purchase (ProductID, Quantity, PurchaseDate) VALUES (?, ?, ?)", con, trans)
                    insPurchase.Parameters.Add("@ProductID", OleDbType.Integer).Value = productID
                    insPurchase.Parameters.Add("@Quantity", OleDbType.Integer).Value = quantity
                    insPurchase.Parameters.Add("@PurchaseDate", OleDbType.Date).Value = DateTime.Now
                    insPurchase.ExecuteNonQuery()

                    ' Update Inventory
                    Dim updateInv As New OleDbCommand("UPDATE Inventory SET Quantity = Quantity - ? WHERE ProductID = ?", con, trans)
                    updateInv.Parameters.Add("@Quantity", OleDbType.Integer).Value = quantity
                    updateInv.Parameters.Add("@ProductID", OleDbType.Integer).Value = productID
                    updateInv.ExecuteNonQuery()
                Next

                ' Insert into Sales
                Dim insSales As New OleDbCommand("INSERT INTO Sales (PaymentID, SalesDate, TotalSales) VALUES (?, ?, ?)", con, trans)
                insSales.Parameters.Add("@PaymentID", OleDbType.Integer).Value = paymentID
                insSales.Parameters.Add("@SalesDate", OleDbType.Date).Value = DateTime.Now
                insSales.Parameters.Add("@TotalSales", OleDbType.Currency).Value = totalAmount
                insSales.ExecuteNonQuery()

                ' Get Sales ID
                Dim getSalesIDCmd As New OleDbCommand("SELECT @@IDENTITY", con, trans)
                Dim salesIDObj = getSalesIDCmd.ExecuteScalar()
                If salesIDObj Is Nothing OrElse IsDBNull(salesIDObj) Then
                    Throw New Exception("Failed to get Sales ID.")
                End If
                Dim salesID As Integer = Convert.ToInt32(salesIDObj)

                ' Insert into SalesDetails
                For Each row As DataGridViewRow In dgvProductList.Rows
                    If row.IsNewRow Then Continue For

                    Dim productID As Integer = 0
                    Dim quantity As Integer = 0
                    Dim price As Decimal = 0D
                    Dim subtotal As Decimal = 0D

                    If dgvProductList.Columns.Contains("ProductID") Then
                        Integer.TryParse(row.Cells("ProductID").Value?.ToString(), productID)
                    Else
                        Integer.TryParse(row.Cells(0).Value?.ToString(), productID)
                    End If

                    If dgvProductList.Columns.Contains("Quantity") Then
                        Integer.TryParse(row.Cells("Quantity").Value?.ToString(), quantity)
                    Else
                        Integer.TryParse(row.Cells(2).Value?.ToString(), quantity)
                    End If

                    If dgvProductList.Columns.Contains("Price") Then
                        Decimal.TryParse(row.Cells("Price").Value?.ToString(), price)
                    Else
                        Decimal.TryParse(row.Cells(3).Value?.ToString(), price)
                    End If

                    If dgvProductList.Columns.Contains("Total") Then
                        Decimal.TryParse(row.Cells("Total").Value?.ToString(), subtotal)
                    Else
                        Decimal.TryParse(row.Cells(6).Value?.ToString(), subtotal)
                    End If

                    Dim insSD As New OleDbCommand("INSERT INTO SalesDetails (SalesID, ProductID, Quantity, UnitPrice, SubTotal) VALUES (?, ?, ?, ?, ?)", con, trans)
                    insSD.Parameters.Add("@SalesID", OleDbType.Integer).Value = salesID
                    insSD.Parameters.Add("@ProductID", OleDbType.Integer).Value = productID
                    insSD.Parameters.Add("@Quantity", OleDbType.Integer).Value = quantity
                    insSD.Parameters.Add("@UnitPrice", OleDbType.Currency).Value = price
                    insSD.Parameters.Add("@SubTotal", OleDbType.Currency).Value = subtotal
                    insSD.ExecuteNonQuery()
                Next
                ' Calculate Quota (₱50 per ₱3000 in total sales)
                Dim quotaAmount As Decimal = Math.Floor(totalAmount / 3000D) * 50D

                ' Insert into Quota table
                Dim insQuota As New OleDbCommand("INSERT INTO Quota (SalesID, QuotaAmmount, UserID, QuotaDate) VALUES (?, ?, ?, ?)", con, trans)
                insQuota.Parameters.Add("@SalesID", OleDbType.Integer).Value = salesID
                insQuota.Parameters.Add("@QuotaAmmount", OleDbType.Currency).Value = quotaAmount
                insQuota.Parameters.Add("@UserID", OleDbType.Integer).Value = cashierID
                insQuota.Parameters.Add("@QuotaDate", OleDbType.Date).Value = DateTime.Now
                insQuota.ExecuteNonQuery()


                trans.Commit()
                MessageBox.Show("Transaction successfully recorded!")

                ' *** NEW CODE TO SHOW RECEIPT ***
                Dim receiptForm As New frmReceipt()
                With receiptForm
                    .TransactionDate = DateTime.Now
                    .CashierName = lblCashierName.Text ' Assuming lblCashierName displays the cashier's name
                    .TotalAmount = totalAmount
                    .AmountPaid = amountPaid
                    .ChangeAmount = change
                    .ModeOfPayment = cmbModeofPayment.SelectedItem.ToString()
                    .ProductList = dgvProductList ' Pass the DataGridView containing the product list
                    .VatAmount = transactionVat ' Pass the accumulated VAT
                    .NonVatAmount = transactionNonVat ' Pass the accumulated Non-VAT
                End With
                receiptForm.ShowDialog()
                ' *** END NEW CODE ***


                dgvProductList.Rows.Clear()
                txtAmountPaid.Clear()
                lblTotalAmount.Text = "0.00"
                lblTotalQuantity.Text = "0"
                lblChange.Text = "0.00"
                dgvProductList.Rows.Clear()

                ' Reset labels and text boxes
                txtAmountPaid.Clear()
                lblTotalAmount.Text = "0.00"
                lblTotalQuantity.Text = "0"
                lblChange.Text = "0.00"


                ' Close the Payments form
                Me.Close()

            Catch ex As Exception
                trans.Rollback()
                MessageBox.Show("Error during transaction: " & ex.Message)
            End Try
        End Using
    End Sub






    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.Close()
    End Sub

    Private Sub LoadModesOfPayment()
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Database\GamePOS.accdb"
        Using conn As New OleDbConnection(connString)
            Dim query As String = "SELECT MOPName FROM MOP"
            Using cmd As New OleDbCommand(query, conn)
                Try
                    conn.Open()
                    cmbModeofPayment.Items.Clear()
                    Using reader As OleDbDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cmbModeofPayment.Items.Add(reader("MOPName").ToString())
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading modes of payment: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub Payments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadModesOfPayment()

        If dgvProductList.Columns.Count = 0 Then
            With dgvProductList.Columns
                .Add("ProductID", "Product ID")
                .Add("ProductName", "Product Name")
                .Add("Quantity", "Quantity")
                .Add("Price", "Price")
                .Add("VAT", "VAT")
                .Add("NonVAT", "Non-VAT")
                .Add("Total", "Total")
            End With

            For Each col As DataGridViewColumn In dgvProductList.Columns
                col.ReadOnly = True
            Next
        End If
        With dgvProductList
            ' Define your custom colors
            Dim darkBlue As Color = Color.FromArgb(14, 20, 43)
            Dim silverGray As Color = Color.Silver

            ' Background colors
            .BackgroundColor = darkBlue
            .DefaultCellStyle.BackColor = darkBlue
            .AlternatingRowsDefaultCellStyle.BackColor = darkBlue

            ' Text color
            .DefaultCellStyle.ForeColor = silverGray
            .AlternatingRowsDefaultCellStyle.ForeColor = silverGray

            ' Grid color (optional, to match theme)
            .GridColor = Color.DimGray

            ' Header styling
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 30, 60)
            .ColumnHeadersDefaultCellStyle.ForeColor = silverGray
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)

            ' Row selection colors
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 50, 80)
            .DefaultCellStyle.SelectionForeColor = Color.White

            ' Optional: remove row headers for cleaner look
            .RowHeadersVisible = False
        End With


    End Sub


    Public Sub LoadCartItems(cart As DataGridView)
        dgvProductList.Rows.Clear()

        ' Loop through each row in the DataGridView from the cashier form
        For Each row As DataGridViewRow In cart.Rows
            If Not row.IsNewRow Then
                ' Add each cell value from the cart DataGridView to dgvProductList
                dgvProductList.Rows.Add(
                row.Cells("ProductID").Value, ' Product ID
                row.Cells("ProductName").Value, ' Product Name
                row.Cells("Quantity").Value, ' Quantity
                row.Cells("Price").Value, ' Price
                row.Cells("VAT").Value, ' VAT
                row.Cells("NonVAT").Value, ' Non-VAT
                row.Cells("Total").Value ' Total
            )
            End If
        Next
    End Sub

    Private Sub txtAmountPaid_TextChanged(sender As Object, e As EventArgs) Handles txtAmountPaid.TextChanged
        Dim amountPaid As Decimal
        Dim totalAmount As Decimal

        If Decimal.TryParse(txtAmountPaid.Text, amountPaid) AndAlso Decimal.TryParse(lblTotalAmount.Text, totalAmount) Then
            Dim change As Decimal = amountPaid - totalAmount
            lblChange.Text = If(change >= 0, change.ToString("N2"), "0.00")
        Else
            lblChange.Text = "0.00"
        End If
    End Sub

    Private Function IsManagerAuthorized(username As String, password As String) As Boolean
        Dim connStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Database\GamePOS.accdb"
        Using con As New OleDbConnection(connStr)
            con.Open()
            Dim cmd As New OleDbCommand("SELECT COUNT(*) FROM Users WHERE UserName = ? AND [Password] = ? AND RoleID IN (SELECT RoleID FROM Roles WHERE RoleName = 'admin') AND Status = 'Active'", con)
            cmd.Parameters.AddWithValue("@Username", username)
            cmd.Parameters.AddWithValue("@Password", password)
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return count > 0
        End Using
    End Function

    Private Sub UpdateTotalsAfterVoid()
        Dim totalAmount As Decimal = 0D
        Dim totalQuantity As Integer = 0

        For Each row As DataGridViewRow In dgvProductList.Rows
            If Not row.IsNewRow Then
                Dim qty As Integer = 0
                Dim total As Decimal = 0D

                ' Replace 1 and 4 with actual indexes of Quantity and Total
                Integer.TryParse(row.Cells(1).Value?.ToString(), qty)
                Decimal.TryParse(row.Cells(4).Value?.ToString(), total)

                totalQuantity += qty
                totalAmount += total
            End If
        Next

        lblTotalAmount.Text = totalAmount.ToString("N2")
        lblTotalQuantity.Text = totalQuantity.ToString()
    End Sub



    Private Sub btnVoid_Click(sender As Object, e As EventArgs) Handles btnVoid.Click
        Dim selectedRow As DataGridViewRow = Nothing

        If dgvProductList.SelectedRows.Count > 0 Then
            selectedRow = dgvProductList.SelectedRows(0)
        ElseIf dgvProductList.CurrentRow IsNot Nothing Then
            selectedRow = dgvProductList.CurrentRow
        End If

        If selectedRow Is Nothing Then
            MessageBox.Show("Please select an item to void.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Show Manager Auth dialog instead of InputBoxes
        Dim authForm As New frmVoid()
        If authForm.ShowDialog() = DialogResult.OK Then
            Dim inputUsername As String = authForm.ManagerUsername
            Dim inputPassword As String = authForm.ManagerPassword

            If IsManagerAuthorized(inputUsername, inputPassword) Then
                dgvProductList.Rows.Remove(selectedRow)
                MessageBox.Show("Item voided successfully.", "Voided", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UpdateTotalsAfterVoid()
            Else
                MessageBox.Show("Invalid manager credentials. Void operation cancelled.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Void cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


End Class
