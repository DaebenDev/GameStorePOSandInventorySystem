Imports System.Data.OleDb

Public Class frmCashier

    Public Sub SetUserInfo(userID As Integer, username As String)
        lblUserInfo.Text = $"User ID: {userID} | Name: {username}"
    End Sub

    Public Sub SetUsername(name As String)
        lblName.Text = name
    End Sub

    Private Sub frmCashier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup columns if not added yet
        If DataGridViewCart.Columns.Count = 0 Then
            With DataGridViewCart.Columns
                .Add("ProductID", "Product ID")
                .Add("ProductName", "Product Name")
                .Add("Quantity", "Quantity")
                .Add("Price", "Price")
                .Add("VAT", "VAT")
                .Add("NonVAT", "Non-VAT")
                .Add("Total", "Total")
            End With
        End If

        ' Make all columns readonly
        For Each col As DataGridViewColumn In DataGridViewCart.Columns
            col.ReadOnly = True
        Next

        ' IMPORTANT: Disable the "AllowUserToAddRows" property for DataGridViewCart
        ' This prevents the empty new row from appearing at the end, which can cause issues.
        DataGridViewCart.AllowUserToAddRows = False

        ' Define custom colors
        Dim darkBlue As Color = Color.FromArgb(14, 20, 43)
        Dim silverGray As Color = Color.Silver

        ' Apply theme to DataGridViewCart
        With DataGridViewCart
            .EnableHeadersVisualStyles = False
            .BackgroundColor = darkBlue
            .DefaultCellStyle.BackColor = darkBlue
            .DefaultCellStyle.ForeColor = silverGray
            .AlternatingRowsDefaultCellStyle.BackColor = darkBlue
            .AlternatingRowsDefaultCellStyle.ForeColor = silverGray
            .ColumnHeadersDefaultCellStyle.BackColor = darkBlue
            .ColumnHeadersDefaultCellStyle.ForeColor = silverGray
            .RowHeadersDefaultCellStyle.BackColor = darkBlue
            .RowHeadersDefaultCellStyle.ForeColor = silverGray
        End With

        ' Apply theme to DataGridView1
        With DataGridView1
            .EnableHeadersVisualStyles = False
            .BackgroundColor = darkBlue
            .DefaultCellStyle.BackColor = darkBlue
            .DefaultCellStyle.ForeColor = silverGray
            .AlternatingRowsDefaultCellStyle.BackColor = darkBlue
            .AlternatingRowsDefaultCellStyle.ForeColor = silverGray
            .ColumnHeadersDefaultCellStyle.BackColor = darkBlue
            .ColumnHeadersDefaultCellStyle.ForeColor = silverGray
            .RowHeadersDefaultCellStyle.BackColor = darkBlue
            .RowHeadersDefaultCellStyle.ForeColor = silverGray
        End With

        ' Load product data
        LoadProductData()
    End Sub

    Private Sub LoadProductData(Optional search As String = "")
        Dim query As String = "SELECT Products.ProductID, Products.ProductName, Products.ProductDesc, Categories.CategoryName, ProductCategories.PCategoryName, Products.Price, Inventory.Quantity, Inventory.StockInDate, Inventory.CriticalLevel " &
                                  "FROM ((Products " &
                                  "INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID) " &
                                  "INNER JOIN ProductCategories ON Products.PCategoriesID = ProductCategories.PCategoriesID) " &
                                  "INNER JOIN Inventory ON Products.ProductID = Inventory.ProductID " &
                                  "WHERE 1=1"

        Dim parameters As New List(Of OleDbParameter)

        If search <> "" Then
            query &= " AND (Products.ProductName LIKE ? OR Products.ProductID LIKE ?)"
            parameters.Add(New OleDbParameter("ProductName", "%" & search & "%"))
            parameters.Add(New OleDbParameter("ProductID", "%" & search & "%"))
        End If

        Dim dt As New DataTable()
        Using con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Database\GamePOS.accdb")
            Using cmd As New OleDbCommand(query, con)
                cmd.Parameters.AddRange(parameters.ToArray())
                Dim adapter As New OleDbDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        End Using

        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles CheckoutButton.Click
        ' Check if there are any non-new, valid rows in the cart
        Dim hasValidItems As Boolean = False
        For Each row As DataGridViewRow In DataGridViewCart.Rows
            If Not row.IsNewRow AndAlso row.Cells("ProductID").Value IsNot Nothing AndAlso row.Cells("ProductID").Value.ToString().Trim() <> "" Then
                hasValidItems = True
                Exit For
            End If
        Next

        If Not hasValidItems Then
            MessageBox.Show("There are no items in the cart to checkout.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim totalAmount As Decimal = Convert.ToDecimal(lblTotalAmount.Text)
        Dim totalQuantity As Integer = Convert.ToInt32(lblTotalQuantity.Text)
        Dim userID As Integer = GetUserIDFromLabel(lblUserInfo.Text)

        ' Setup payments form
        Payments.SetUserID(userID)
        Payments.SetCashierName(lblName.Text)
        Payments.SetPaymentDetails(totalAmount, totalQuantity)
        Payments.LoadCartItems(DataGridViewCart)

        ' Handle closing to refresh cashier form
        AddHandler Payments.FormClosed, AddressOf Payments_FormClosed
        Payments.Show()
    End Sub

    Private Sub Payments_FormClosed(sender As Object, e As FormClosedEventArgs)

        DataGridViewCart.Rows.Clear()

        ' Reload inventory or product list to reflect updated quantities
        LoadProductData()

        ' Optionally reset search box
        txtSearch.Text = ""

        ' Remove handler to avoid duplicate triggers if form is reused
        RemoveHandler Payments.FormClosed, AddressOf Payments_FormClosed
    End Sub

    Private Function GetUserIDFromLabel(labelText As String) As Integer
        Dim parts() As String = labelText.Split("|"c)
        If parts.Length > 0 Then
            Dim idPart As String = parts(0).Trim().Replace("User ID:", "").Trim()
            If Integer.TryParse(idPart, Nothing) Then
                Return Convert.ToInt32(idPart)
            End If
        End If
        Return -1
    End Function

    Private Sub LogOutButton_Click(sender As Object, e As EventArgs) Handles LogOutButton.Click
        If MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Me.Close()
            Login.Show()
            Login.clearText()
            Login.CheckBox1.Checked = False
            Login.passwordtxtBox.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            txtProID.Text = row.Cells("ProductID").Value.ToString()
            txtProdName.Text = row.Cells("ProductName").Value.ToString()
            txtQuantity.Text = "1"

            Dim price As Decimal = Convert.ToDecimal(row.Cells("Price").Value)
            Dim vat, nonvat, total As Decimal
            CalculatePriceDetails(price, 1, vat, nonvat, total)

            lvlVat.Text = vat.ToString("N2")
            lblNonVat.Text = nonvat.ToString("N2")
            lblTotalAmount.Text = total.ToString("N2")
        End If
    End Sub

    Private Sub AddtoCartButton_Click(sender As Object, e As EventArgs) Handles AddtoCartButton.Click
        If txtProID.Text = "" Or txtQuantity.Text = "" Then
            MessageBox.Show("Please select a product and enter quantity.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim quantityToAdd As Integer
        If Not Integer.TryParse(txtQuantity.Text, quantityToAdd) OrElse quantityToAdd <= 0 Then
            MessageBox.Show("Please enter a valid quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim productID As String = txtProID.Text
        Dim productName As String = txtProdName.Text
        Dim unitPrice As Decimal = Decimal.Parse(DataGridView1.CurrentRow.Cells("Price").Value.ToString())
        Dim availableQty As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("Quantity").Value)
        ' Get the critical level for the selected product
        Dim criticalLevel As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("CriticalLevel").Value)

        ' Get the cashier's name from the label
        Dim cashierName As String = lblName.Text

        ' --- Stock Level Notifications ---
        If availableQty <= 0 Then
            ' Product is out of stock
            MessageBox.Show($"Attention, {cashierName}! The product '{productName}' is currently OUT OF STOCK. Please inform an administrator immediately.", "No Stock Available", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub ' Prevent adding to cart if out of stock
        ElseIf availableQty <= criticalLevel Then
            ' Product is at or below critical level
            MessageBox.Show($"Attention, {cashierName}! The stock for '{productName}' is critically low ({availableQty} units remaining). Please inform an administrator as it is almost gone.", "Low Stock Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        ' --- End Stock Level Notifications ---

        ' 🔁 Check if product already in the cart
        Dim existingRow As DataGridViewRow = Nothing
        For Each row As DataGridViewRow In DataGridViewCart.Rows
            If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(0).Value.ToString() = productID Then
                existingRow = row
                Exit For
            End If
        Next

        Dim totalDesiredQty As Integer = quantityToAdd

        If existingRow IsNot Nothing Then
            Dim currentCartQty As Integer = Convert.ToInt32(existingRow.Cells(2).Value)
            totalDesiredQty = currentCartQty + quantityToAdd
        End If

        ' 🚫 Limit total quantity to available stock
        If totalDesiredQty > availableQty Then
            totalDesiredQty = availableQty
            txtQuantity.Text = availableQty.ToString()
            MessageBox.Show("Only " & availableQty.ToString() & " units available. Quantity adjusted.", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        If totalDesiredQty <= 0 Then
            ' This condition should ideally be caught by the "availableQty <= 0" check above,
            ' but kept here as a safeguard if logic changes.
            MessageBox.Show("This product cannot be added as the adjusted quantity is zero or less.", "Cannot Add Item", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 💵 Recalculate price details
        Dim vat, nonvat, total As Decimal
        CalculatePriceDetails(unitPrice, totalDesiredQty, vat, nonvat, total)

        If existingRow IsNot Nothing Then
            ' ✅ Update existing row
            existingRow.Cells(2).Value = totalDesiredQty
            existingRow.Cells(4).Value = vat.ToString("N2")
            existingRow.Cells(5).Value = nonvat.ToString("N2")
            existingRow.Cells(6).Value = total.ToString("N2")
        Else
            ' ➕ Add new row
            DataGridViewCart.Rows.Add(productID, productName, totalDesiredQty, unitPrice.ToString("N2"), vat.ToString("N2"), nonvat.ToString("N2"), total.ToString("N2"))
        End If

        UpdateTotals()
    End Sub



    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        If DataGridViewCart.SelectedRows.Count > 0 Then
            DataGridViewCart.Rows.RemoveAt(DataGridViewCart.SelectedRows(0).Index)
            UpdateTotals()
        End If
    End Sub

    Private Sub UpdateTotals()
        Dim totalQty As Integer = 0
        Dim grandTotal As Decimal = 0

        For Each row As DataGridViewRow In DataGridViewCart.Rows
            If Not row.IsNewRow Then
                totalQty += Convert.ToInt32(row.Cells("Quantity").Value)
                grandTotal += Convert.ToDecimal(row.Cells("Total").Value)
            End If
        Next

        lblTotalQuantity.Text = totalQty.ToString()
        lblTotalAmount.Text = grandTotal.ToString("N2")
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadProductData(txtSearch.Text)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Now.ToShortDateString()
        lblTime.Text = Now.ToShortTimeString()
    End Sub

    ' Helper Method
    Private Sub CalculatePriceDetails(price As Decimal, quantity As Integer, ByRef vat As Decimal, ByRef nonvat As Decimal, ByRef total As Decimal)
        Dim subtotal As Decimal = price * quantity
        vat = subtotal * 0.05D
        nonvat = 20D
        total = subtotal + vat + nonvat
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        ' Allow only digits and control keys (like backspace)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class
