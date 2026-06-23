Imports System.Data.OleDb

Public Class frmProduct

    Private connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Database\GamePOS.accdb"
    Private connection As New OleDbConnection(connectionString)

    Public Sub SetUsername(username As String)
        lblName.Text = username
    End Sub

    Private Sub frmProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtProductID.ReadOnly = True
        LoadProducts()
        LoadCategoriesAndProductCategories()
        GenerateNextProductID()
        LoadSuppliersComboBox()
    End Sub

    Private Sub LoadProducts()
        Dim query As String = "SELECT Products.ProductID, Products.ProductName, Products.ProductDesc, " &
                          "Categories.CategoryName, ProductCategories.PCategoryName, Products.Price, Products.PurchasePrice, " &
                          "Inventory.Quantity, Inventory.StockInDate, Inventory.CriticalLevel, Suppliers.SupplierName " & ' <--- ADDED: Suppliers.SupplierName
                          "FROM (((Products INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID) " &
                          "INNER JOIN ProductCategories ON Products.PCategoriesID = ProductCategories.PCategoriesID) " &
                          "INNER JOIN Inventory ON Products.ProductID = Inventory.ProductID) " &
                          "INNER JOIN Suppliers ON Inventory.SupplierID = Suppliers.SupplierID" ' <--- ADDED: Join to Suppliers table

        Dim command As New OleDbCommand(query, connection)
        Dim adapter As New OleDbDataAdapter(command)
        Dim dataTable As New DataTable()

        Try
            If connection.State <> ConnectionState.Open Then
                connection.Open()
            End If
            adapter.Fill(dataTable)
            dgvProducts.DataSource = dataTable
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Optional: Adjust column header and width for SupplierName
            If dgvProducts.Columns.Contains("SupplierName") Then
                dgvProducts.Columns("SupplierName").HeaderText = "Supplier"
                dgvProducts.Columns("SupplierName").Width = 150 ' Adjust as needed
            End If

            ' Check for critical stock levels
            Dim criticalProducts As New List(Of String)()
            For Each row As DataRow In dataTable.Rows
                Dim quantity As Integer = Convert.ToInt32(row("Quantity"))
                Dim criticalLevel As Integer = Convert.ToInt32(row("CriticalLevel"))
                If quantity < criticalLevel Then
                    criticalProducts.Add(row("ProductName").ToString())
                End If
            Next

            If criticalProducts.Count > 0 Then
                Dim message As String = "The following products are at a critical level:" & vbCrLf & String.Join(vbCrLf, criticalProducts)
                MsgBox(message, MsgBoxStyle.Exclamation, "Critical Stock Level Warning")
            End If

        Catch ex As Exception
            MsgBox("Error loading products: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub InsertInventory(productId As Integer)
        Dim query As String = "INSERT INTO Inventory (ProductID, Quantity, StockInDate, CriticalLevel) VALUES (?, ?, ?, ?)"
        Using command As New OleDbCommand(query, connection)
            command.Parameters.AddWithValue("?", productId)
            command.Parameters.AddWithValue("?", Convert.ToInt32(txtQuantity.Text))
            command.Parameters.AddWithValue("?", Convert.ToDateTime(lblDate.Text))
            command.Parameters.AddWithValue("?", Convert.ToInt32(txtCriticalLvl.Text))

            Try
                command.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Error inserting inventory: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End Using
    End Sub

    Private Sub AddProduct()
        ' 1. Initial field validation
        If String.IsNullOrWhiteSpace(txtProductName.Text) OrElse
       String.IsNullOrWhiteSpace(txtPrice.Text) OrElse
       String.IsNullOrWhiteSpace(txtPurchasePrice.Text) OrElse
       String.IsNullOrWhiteSpace(txtQuantity.Text) OrElse ' Ensure quantity is not empty
       String.IsNullOrWhiteSpace(txtCriticalLvl.Text) OrElse ' Ensure critical level is not empty
       cmbCategory.SelectedIndex = -1 OrElse
       cmbProductCategory.SelectedIndex = -1 OrElse
       cmbSupplier.SelectedIndex = -1 Then
            MsgBox("Please fill in all required fields.", MsgBoxStyle.Exclamation, "Missing Information")
            Exit Sub
        End If

        ' 2. Quantity validation
        Dim quantity As Integer
        If Not Integer.TryParse(txtQuantity.Text, quantity) OrElse quantity <= 0 Then ' Added check for quantity > 0
            MsgBox("Please enter a valid positive quantity.", MsgBoxStyle.Exclamation, "Invalid Quantity")
            Exit Sub
        End If

        If quantity > 60 Then
            MsgBox("Quantity cannot exceed 60. Please enter a valid quantity.", MsgBoxStyle.Exclamation, "Quantity Limit Exceeded")
            Exit Sub
        End If

        ' 3. Critical Level validation
        Dim criticalLevel As Integer
        If Not Integer.TryParse(txtCriticalLvl.Text, criticalLevel) OrElse criticalLevel < 0 Then ' Critical level can be 0, but not negative
            MsgBox("Please enter a valid non-negative critical level.", MsgBoxStyle.Exclamation, "Invalid Critical Level")
            Exit Sub
        End If


        ' 4. Parse and validate prices
        Dim productName As String = txtProductName.Text.Trim()
        Dim productDesc As String = txtProductDesc.Text.Trim()
        Dim categoryID As Integer = Convert.ToInt32(cmbCategory.SelectedValue)
        Dim pCategoryID As Integer = Convert.ToInt32(cmbProductCategory.SelectedValue)
        Dim supplierID As Integer = Convert.ToInt32(cmbSupplier.SelectedValue)
        Dim price As Decimal
        Dim purchasePrice As Decimal

        If Not Decimal.TryParse(txtPrice.Text, price) OrElse price <= 0 Then ' Price must be a positive number
            MsgBox("Invalid sales price. Please enter a valid positive number.", MsgBoxStyle.Exclamation, "Invalid Sales Price")
            Exit Sub
        End If

        If Not Decimal.TryParse(txtPurchasePrice.Text, purchasePrice) OrElse purchasePrice <= 0 Then ' Purchase price must be a positive number
            MsgBox("Invalid purchase price. Please enter a valid positive number.", MsgBoxStyle.Exclamation, "Invalid Purchase Price")
            Exit Sub
        End If

        ' 5. Price relationship validation (PurchasePrice vs SalesPrice)
        If purchasePrice > price Then
            MsgBox("Purchase price cannot be greater than the sales price.", MsgBoxStyle.Exclamation, "Price Mismatch")
            Exit Sub
        End If

        ' 6. Markup Confirmation Prompt
        Dim minRecommendedPrice As Decimal = purchasePrice * 1.05D ' D for Decimal literal
        Dim markupMessage As String = ""

        If price < minRecommendedPrice Then
            markupMessage = $"Warning: Your sales price ({price:C}) is less than 5% above the purchase price ({purchasePrice:C})." & vbCrLf &
                        $"The recommended minimum sales price (5% markup) is {minRecommendedPrice:C}." & vbCrLf &
                        "Do you wish to proceed with this pricing?"
        Else
            Dim currentMarkupPercentage As Decimal = 0
            If purchasePrice > 0 Then
                currentMarkupPercentage = ((price - purchasePrice) / purchasePrice) * 100
            End If
            markupMessage = $"Your sales price ({price:C}) represents a markup of {currentMarkupPercentage:N2}% over the purchase price ({purchasePrice:C})." & vbCrLf &
                        "Do you wish to confirm these prices?"
        End If

        If MessageBox.Show(markupMessage, "Confirm Product Pricing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub ' User chose not to proceed with the pricing
        End If

        ' 7. Check if product already exists (database interaction starts here)
        Dim checkQuery As String = "SELECT COUNT(*) FROM Products WHERE ProductName = ? AND PCategoriesID = ?"
        Using checkCmd As New OleDbCommand(checkQuery, connection)
            checkCmd.Parameters.AddWithValue("?", productName)
            checkCmd.Parameters.AddWithValue("?", pCategoryID)

            Try
                connection.Open()
                Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                If exists > 0 Then
                    MsgBox("Product already exists. Please choose a different Product Category or Product Name.", MsgBoxStyle.Exclamation, "Product Exists")
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("Error checking product: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
                Exit Sub
            Finally
                If connection.State = ConnectionState.Open Then
                    connection.Close() ' Ensure connection is closed on error or exit
                End If
            End Try
        End Using

        ' 8. Final Confirmation prompt with all product details
        Dim message As String = $"Please confirm the following details before adding:" & vbCrLf &
                            $"Name: {productName}" & vbCrLf &
                            $"Description: {productDesc}" & vbCrLf &
                            $"Category: {cmbCategory.Text}" & vbCrLf &
                            $"Product Category: {cmbProductCategory.Text}" & vbCrLf &
                            $"Sales Price: {price:C}" & vbCrLf &
                            $"Purchase Price: {purchasePrice:C}" & vbCrLf &
                            $"Quantity: {quantity}" & vbCrLf &
                            $"Critical Level: {criticalLevel}" & vbCrLf & ' Use parsed integer
                            $"Stock-In Date: {lblDate.Text}" & vbCrLf &
                            $"Supplier: {cmbSupplier.Text}"

        If MessageBox.Show(message, "Confirm Add Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim insertProductQuery As String = "INSERT INTO Products (ProductName, ProductDesc, CategoryID, Price, PCategoriesID, PurchasePrice) VALUES (?, ?, ?, ?, ?, ?)"
            Using insertCmd As New OleDbCommand(insertProductQuery, connection)
                insertCmd.Parameters.AddWithValue("?", productName)
                insertCmd.Parameters.AddWithValue("?", productDesc)
                insertCmd.Parameters.AddWithValue("?", categoryID)
                insertCmd.Parameters.AddWithValue("?", price)
                insertCmd.Parameters.AddWithValue("?", pCategoryID)
                insertCmd.Parameters.AddWithValue("?", purchasePrice)

                Try
                    connection.Open() ' Open connection for product insertion
                    insertCmd.ExecuteNonQuery()
                    insertCmd.CommandText = "SELECT @@IDENTITY"
                    Dim newProductId = Convert.ToInt32(insertCmd.ExecuteScalar())

                    InsertInventory(newProductId, supplierID) ' Pass CriticalLevel as well if InsertInventory needs it from here

                    MsgBox("Product added!", MsgBoxStyle.Information, "Product Added Successfully")
                    LoadProducts()
                    ClearFields()
                Catch ex As Exception
                    MsgBox("Error adding product: " & ex.Message, MsgBoxStyle.Critical, "Product Add Error")
                Finally
                    If connection.State = ConnectionState.Open Then
                        connection.Close() ' Ensure connection is closed after product and inventory insertion
                    End If
                End Try
            End Using
        End If
    End Sub


    Private Sub InsertInventory(ByVal productId As Integer, ByVal supplierId As Integer)

        Dim insertInventoryQuery As String = "INSERT INTO Inventory (ProductID, Quantity, StockInDate, CriticalLevel, SupplierID) VALUES (?, ?, ?, ?, ?)" ' <--- ADDED: SupplierID column
        Using insertInvCmd As New OleDbCommand(insertInventoryQuery, connection)
            insertInvCmd.Parameters.AddWithValue("?", productId)
            insertInvCmd.Parameters.AddWithValue("?", Convert.ToInt32(txtQuantity.Text))
            insertInvCmd.Parameters.AddWithValue("?", lblDate.Text)
            insertInvCmd.Parameters.AddWithValue("?", Convert.ToInt32(txtCriticalLvl.Text))
            insertInvCmd.Parameters.AddWithValue("?", supplierId)
            Try

                insertInvCmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Error inserting inventory: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End Using
    End Sub
    Private Sub LoadSuppliersComboBox()
        Dim query As String = "SELECT SupplierID, SupplierName FROM Suppliers ORDER BY SupplierName"
        Dim command As New OleDbCommand(query, connection)
        Dim adapter As New OleDbDataAdapter(command)
        Dim dataTable As New DataTable()

        Try
            If connection.State <> ConnectionState.Open Then
                connection.Open()
            End If
            adapter.Fill(dataTable)

            cmbSupplier.DataSource = dataTable
            cmbSupplier.DisplayMember = "SupplierName" ' What the user sees
            cmbSupplier.ValueMember = "SupplierID"   ' The actual ID to use in the database
            cmbSupplier.SelectedIndex = -1 ' Clear initial selection
        Catch ex As Exception
            MsgBox("Error loading suppliers: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub
    Private Sub EditProduct()
        Dim productId As Integer

        If Not Integer.TryParse(txtProductID.Text, productId) Then
            MsgBox("Invalid product ID.", MsgBoxStyle.Critical)
            Return
        End If

        Dim quantity As Integer
        If Not Integer.TryParse(txtQuantity.Text, quantity) Then
            MsgBox("Invalid quantity.", MsgBoxStyle.Exclamation)
            Return
        End If

        If quantity > 60 Then
            MsgBox("Quantity cannot exceed 60. Please enter a valid quantity.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim message As String = $"Are you sure you want to update this product?" & vbCrLf &
                            $"Name: {txtProductName.Text}" & vbCrLf &
                            $"Description: {txtProductDesc.Text}" & vbCrLf &
                            $"Category: {cmbCategory.Text}" & vbCrLf &
                            $"Product Category: {cmbProductCategory.Text}" & vbCrLf &
                            $"Price: {txtPrice.Text}" & vbCrLf &
                            $"Quantity: {quantity}" & vbCrLf &
                            $"Critical Level: {txtCriticalLvl.Text}" & vbCrLf &
                            $"Stock-In Date: {lblDate.Text}"

        If MessageBox.Show(message, "Confirm Edit Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim query As String = "UPDATE Products SET ProductName = ?, ProductDesc = ?, CategoryID = ?, Price = ?, PCategoriesID = ? WHERE ProductID = ?"
            Using command As New OleDbCommand(query, connection)
                command.Parameters.AddWithValue("?", txtProductName.Text)
                command.Parameters.AddWithValue("?", txtProductDesc.Text)
                command.Parameters.AddWithValue("?", Convert.ToInt32(cmbCategory.SelectedValue))
                command.Parameters.AddWithValue("?", Convert.ToDecimal(txtPrice.Text))
                command.Parameters.AddWithValue("?", Convert.ToInt32(cmbProductCategory.SelectedValue))
                command.Parameters.AddWithValue("?", productId)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()

                    Dim updateInventoryQuery As String = "UPDATE Inventory SET Quantity = ?, StockInDate = ?, CriticalLevel = ? WHERE ProductID = ?"
                    Using inventoryCmd As New OleDbCommand(updateInventoryQuery, connection)
                        inventoryCmd.Parameters.AddWithValue("?", quantity)
                        inventoryCmd.Parameters.AddWithValue("?", Convert.ToDateTime(lblDate.Text))
                        inventoryCmd.Parameters.AddWithValue("?", Convert.ToInt32(txtCriticalLvl.Text))
                        inventoryCmd.Parameters.AddWithValue("?", productId)
                        inventoryCmd.ExecuteNonQuery()
                    End Using

                    MsgBox("Product updated!", MsgBoxStyle.Information)
                    LoadProducts()
                    ClearFields()
                Catch ex As Exception
                    MsgBox("Error updating product: " & ex.Message, MsgBoxStyle.Critical)
                Finally
                    connection.Close()
                End Try
            End Using
        End If
    End Sub


    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        Dim quantity As Integer
        If Integer.TryParse(txtQuantity.Text, quantity) Then
            Dim criticalLevel As Integer = Math.Ceiling(quantity * 0.1)
            txtCriticalLvl.Text = criticalLevel.ToString()
        Else
            txtCriticalLvl.Clear()
        End If
    End Sub

    Private Sub DeleteProduct()
        Dim productId As Integer

        If Not Integer.TryParse(txtProductID.Text, productId) Then
            MsgBox("Invalid product ID.", MsgBoxStyle.Critical)
            Return
        End If

        If MessageBox.Show("Are you sure you want to delete this product and its inventory?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Try
                connection.Open()

                Dim deleteInventoryQuery As String = "DELETE FROM Inventory WHERE ProductID = ?"
                Using deleteInventoryCmd As New OleDbCommand(deleteInventoryQuery, connection)
                    deleteInventoryCmd.Parameters.Add("?", OleDbType.Integer).Value = productId
                    deleteInventoryCmd.ExecuteNonQuery()
                End Using

                Dim deleteProductQuery As String = "DELETE FROM Products WHERE ProductID = ?"
                Using deleteProductCmd As New OleDbCommand(deleteProductQuery, connection)
                    deleteProductCmd.Parameters.Add("?", OleDbType.Integer).Value = productId
                    deleteProductCmd.ExecuteNonQuery()
                End Using

                MsgBox("Product deleted!", MsgBoxStyle.Information)
                LoadProducts()
                ClearFields()

            Catch ex As Exception
                MsgBox("Error deleting product: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                connection.Close()
            End Try
        End If
    End Sub

    Private Sub ClearFields()
        txtProductID.Clear()
        txtProductName.Clear()
        txtProductDesc.Clear()
        cmbCategory.SelectedIndex = -1
        txtPrice.Clear()
        cmbProductCategory.SelectedIndex = -1
        txtQuantity.Clear()
        txtCriticalLvl.Clear()
        GenerateNextProductID()
        cmbSupplier.SelectedIndex = -1
        txtPurchasePrice.Clear()
    End Sub

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        AddProduct()
    End Sub

    Private Sub EditButton_Click(sender As Object, e As EventArgs) Handles EditButton.Click
        EditProduct()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        DeleteProduct()
    End Sub

    Private Sub dgvProducts_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProducts.SelectionChanged
        If dgvProducts.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = dgvProducts.SelectedRows(0)
            txtProductID.Text = row.Cells("ProductID").Value.ToString()
            txtProductName.Text = row.Cells("ProductName").Value.ToString()
            txtProductDesc.Text = row.Cells("ProductDesc").Value.ToString()
            cmbCategory.Text = row.Cells("CategoryName").Value.ToString()
            txtPrice.Text = row.Cells("Price").Value.ToString()
            cmbProductCategory.Text = row.Cells("PCategoryName").Value.ToString()
            txtQuantity.Text = row.Cells("Quantity").Value.ToString()
            txtCriticalLvl.Text = row.Cells("CriticalLevel").Value.ToString()
            lblDate.Text = Convert.ToDateTime(row.Cells("StockInDate").Value).ToShortDateString()
        End If
    End Sub

    Private Sub dgvProducts_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellDoubleClick
        dgvProducts_SelectionChanged(sender, e)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Me.Close()
            Login.Show()
            Login.clearText()
            Login.CheckBox1.Checked = False
            Login.passwordtxtBox.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub UserManagement_Click(sender As Object, e As EventArgs) Handles UserManagement.Click
        frmAdmin.SetUsername(lblName.Text)
        frmAdmin.Show()
        Me.Close()
    End Sub

    Private Sub SearchTxtbox_TextChanged(sender As Object, e As EventArgs) Handles SearchTxtbox.TextChanged
        SearchProducts(SearchTxtbox.Text)
    End Sub

    Private Sub SearchProducts(keyword As String)
        Dim query As String = "SELECT * FROM Products WHERE ProductName LIKE ? OR ProductID LIKE ?"
        Using command As New OleDbCommand(query, connection)
            command.Parameters.AddWithValue("?", "%" & keyword & "%")
            command.Parameters.AddWithValue("?", "%" & keyword & "%")

            Dim adapter As New OleDbDataAdapter(command)
            Dim dataTable As New DataTable()

            Try
                connection.Open()
                adapter.Fill(dataTable)
                dgvProducts.DataSource = dataTable
            Catch ex As Exception
                MsgBox("Error searching products: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Private Sub Sales_Click(sender As Object, e As EventArgs) Handles Sales.Click
        frmSales.SetUsername(lblName.Text)
        frmSales.Show()
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Now.ToShortDateString
        lblTime.Text = Now.ToShortTimeString
    End Sub

    Private Sub LoadCategoriesAndProductCategories()
        Dim categoryQuery As String = "SELECT CategoryID, CategoryName FROM Categories"
        Dim categoryAdapter As New OleDbDataAdapter(categoryQuery, connection)
        Dim categoryTable As New DataTable()
        categoryAdapter.Fill(categoryTable)

        cmbCategory.DataSource = categoryTable
        cmbCategory.DisplayMember = "CategoryName"
        cmbCategory.ValueMember = "CategoryID"

        Dim productCatQuery As String = "SELECT PCategoriesID, PCategoryName FROM ProductCategories"
        Dim productCatAdapter As New OleDbDataAdapter(productCatQuery, connection)
        Dim productCatTable As New DataTable()
        productCatAdapter.Fill(productCatTable)

        cmbProductCategory.DataSource = productCatTable
        cmbProductCategory.DisplayMember = "PCategoryName"
        cmbProductCategory.ValueMember = "PCategoriesID"
    End Sub

    Private Sub GenerateNextProductID()
        If txtProductID.Text = "" Then
            Dim query As String = "SELECT MAX(ProductID) FROM Products"
            Using command As New OleDbCommand(query, connection)
                Try
                    connection.Open()
                    Dim result = command.ExecuteScalar()
                    Dim nextID As Integer = If(IsDBNull(result), 1, Convert.ToInt32(result) + 1)
                    txtProductID.Text = nextID.ToString()
                Catch ex As Exception
                    MsgBox("Error generating ProductID: " & ex.Message, MsgBoxStyle.Critical)
                Finally
                    connection.Close()
                End Try
            End Using
        End If
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs)
        ' Create a new instance of the Dashboard form
        Dim dashboardForm As New frmDashboard

        ' Assuming frmDashboard has a SetUsername method to display the current user's name
        ' You'll need to get the current user's name from a label or variable on the current form.
        ' For example, if the current form has a label named lblName displaying the username:
        dashboardForm.SetUsername(lblName.Text) ' Pass the current user's name to the dashboard

        ' Show the Dashboard form
        dashboardForm.Show

        ' Close the current form
        Close
    End Sub
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        ClearFields()
    End Sub

    Private Sub DashboardButton_Click(sender As Object, e As EventArgs) Handles DashboardButton.Click
        frmDashboard.SetUsername(lblName.Text)
        frmDashboard.Show()
        Close()
    End Sub

    Private Sub btnSuppliers_Click(sender As Object, e As EventArgs) Handles btnSuppliers.Click
        Dim supplierForm As New frmSuppliers()
        ' Optionally pass the username if frmSuppliers has a label for it
        supplierForm.SetUsername(lblName.Text)
        supplierForm.Show()
        Me.Close() ' Close the current product form
    End Sub

End Class
