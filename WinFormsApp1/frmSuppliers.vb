Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class frmSuppliers
    Private _currentUsername As String = ""
    Private connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Database\GamePOS.accdb"
    Private connection As New OleDbConnection(connectionString)

    Public Sub SetUsername(username As String)
        _currentUsername = username
        ' Optional: If you have a label named lblName on frmSuppliers
        ' and want to display the username on this form, uncomment the line below.
        If Not lblName Is Nothing Then
            lblName.Text = username
        End If
    End Sub

    Private Sub frmSuppliers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtSupplierID.ReadOnly = True ' Make Supplier ID read-only
        LoadSuppliers()
        SetFormMode("New") ' Set initial form mode to 'New'
        If Not lblName Is Nothing Then
                lblName.Text = _currentUsername
            End If
    End Sub

    Private Sub LoadSuppliers()
        Dim query As String = "SELECT SupplierID, SupplierName, ContactPerson, PhoneNumber, Email, Address FROM Suppliers"
        Using command As New OleDbCommand(query, connection)
            Dim adapter As New OleDbDataAdapter(command)
            Dim dataTable As New DataTable()

            Try
                If connection.State <> ConnectionState.Open Then
                    connection.Open()
                End If
                adapter.Fill(dataTable)
                dgvSuppliers.DataSource = dataTable
                dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                ' Optional: Set user-friendly column headers
                If dgvSuppliers.Columns.Contains("SupplierID") Then dgvSuppliers.Columns("SupplierID").HeaderText = "Supplier ID"
                If dgvSuppliers.Columns.Contains("SupplierName") Then dgvSuppliers.Columns("SupplierName").HeaderText = "Supplier Name"
                If dgvSuppliers.Columns.Contains("ContactPerson") Then dgvSuppliers.Columns("ContactPerson").HeaderText = "Contact Person"
                If dgvSuppliers.Columns.Contains("PhoneNumber") Then dgvSuppliers.Columns("PhoneNumber").HeaderText = "Phone Number"
                If dgvSuppliers.Columns.Contains("Email") Then dgvSuppliers.Columns("Email").HeaderText = "Email"
                If dgvSuppliers.Columns.Contains("Address") Then dgvSuppliers.Columns("Address").HeaderText = "Address"

            Catch ex As Exception
                MsgBox("Error loading suppliers: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
            Finally
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
            End Try
        End Using
    End Sub

    Private Sub GenerateNextSupplierID()
        ' Note: If SupplierID is an AutoNumber field in your Access database,
        ' you generally do NOT need to manually generate it here. The database
        ' will assign it automatically upon insertion. In such a case, you would
        ' remove this method and ensure txtSupplierID is not used for input.
        ' If it's a manually managed ID, this code is correct.
        Dim query As String = "SELECT MAX(SupplierID) FROM Suppliers"
        Using command As New OleDbCommand(query, connection)
            Try
                connection.Open()
                Dim result = command.ExecuteScalar()
                Dim nextID As Integer = If(IsDBNull(result), 1, Convert.ToInt32(result) + 1)
                txtSupplierID.Text = nextID.ToString()
            Catch ex As Exception
                MsgBox("Error generating Supplier ID: " & ex.Message, MsgBoxStyle.Critical)
            Finally
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
            End Try
        End Using
    End Sub

    Private Sub ClearFields()
        txtSupplierID.Clear()
        txtSupplierName.Clear()
        txtContactPerson.Clear()
        txtPhoneNumber.Clear()
        txtEmail.Clear()
        txtAddress.Clear()
        GenerateNextSupplierID() ' Generate new ID after clearing for new entry
        txtSupplierName.Focus() ' Set focus to the first input field
    End Sub

    Private Sub SetFormMode(mode As String)
        Select Case mode
            Case "New"
                btnAdd.Enabled = True
                btnEdit.Enabled = False
                btnDelete.Enabled = False
                btnClear.Enabled = True ' Always allow clearing for a new entry
                ClearFields() ' Ensure fields are clear and ready for new entry
            Case "Edit"
                btnAdd.Enabled = False
                btnEdit.Enabled = True
                btnDelete.Enabled = True
                btnClear.Enabled = True ' Allow clearing even when editing (e.g., "Cancel")
                txtSupplierName.Focus() ' Focus on name for immediate editing
            Case Else ' Default or initial state, same as "New"
                btnAdd.Enabled = True
                btnEdit.Enabled = False
                btnDelete.Enabled = False
                btnClear.Enabled = True
                ClearFields()
        End Select
    End Sub

    ' --- CRUD Operations ---
    Private Sub AddSupplier()
        ' Input validation
        If String.IsNullOrWhiteSpace(txtSupplierName.Text) Then
            MsgBox("Supplier Name cannot be empty.", MsgBoxStyle.Exclamation, "Validation Error")
            txtSupplierName.Focus()
            Exit Sub
        End If

        ' Validate Phone Number using a more robust regex
        If Not String.IsNullOrWhiteSpace(txtPhoneNumber.Text) Then
            Dim phoneRegex As New Regex("^\+?[0-9\s\-()\.]+$")
            If Not phoneRegex.IsMatch(txtPhoneNumber.Text.Trim()) Then
                MsgBox("Please enter a valid phone number. It should contain only digits, spaces, hyphens, parentheses, or a leading plus sign.", MsgBoxStyle.Exclamation, "Validation Error")
                txtPhoneNumber.Focus()
                Exit Sub
            End If
        End If

        ' Validate Email using a standard email regex
        If Not String.IsNullOrWhiteSpace(txtEmail.Text) Then
            Dim emailRegex As New Regex("^[^@\s]+@[^@\s]+\.[^@\s]+$")
            If Not emailRegex.IsMatch(txtEmail.Text.Trim()) Then
                MsgBox("Please enter a valid email address (e.g., example@domain.com).", MsgBoxStyle.Exclamation, "Validation Error")
                txtEmail.Focus()
                Exit Sub
            End If
        End If

        ' Validate Contact Person (optional, but ensure it's not just whitespace if entered)
        If Not String.IsNullOrWhiteSpace(txtContactPerson.Text) AndAlso String.IsNullOrWhiteSpace(txtContactPerson.Text.Trim()) Then
            MsgBox("Contact Person cannot be just spaces.", MsgBoxStyle.Exclamation, "Validation Error")
            txtContactPerson.Focus()
            Exit Sub
        End If

        ' Validate Address (optional, but ensure it's not just whitespace if entered)
        If Not String.IsNullOrWhiteSpace(txtAddress.Text) AndAlso String.IsNullOrWhiteSpace(txtAddress.Text.Trim()) Then
            MsgBox("Address cannot be just spaces.", MsgBoxStyle.Exclamation, "Validation Error")
            txtAddress.Focus()
            Exit Sub
        End If

        Dim supplierName As String = txtSupplierName.Text.Trim()
        Dim contactPerson As String = txtContactPerson.Text.Trim()
        Dim phoneNumber As String = txtPhoneNumber.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()
        Dim address As String = txtAddress.Text.Trim()

        ' Check if supplier already exists
        Dim checkQuery As String = "SELECT COUNT(*) FROM Suppliers WHERE SupplierName = ?"
        Using checkCmd As New OleDbCommand(checkQuery, connection)
            checkCmd.Parameters.AddWithValue("?", supplierName)
            Try
                connection.Open()
                Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                If exists > 0 Then
                    MsgBox("A supplier with this name already exists.", MsgBoxStyle.Exclamation, "Supplier Exists")
                    txtSupplierName.Focus()
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("Error checking supplier existence: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
                Exit Sub
            Finally
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
            End Try
        End Using

        Dim message As String = $"Please confirm the following supplier details before adding:" & vbCrLf &
                                $"Name: {supplierName}" & vbCrLf &
                                $"Contact Person: {contactPerson}" & vbCrLf &
                                $"Phone Number: {phoneNumber}" & vbCrLf &
                                $"Email: {email}" & vbCrLf &
                                $"Address: {address}"

        If MessageBox.Show(message, "Confirm Add Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim insertQuery As String = "INSERT INTO Suppliers (SupplierName, ContactPerson, PhoneNumber, Email, Address) VALUES (?, ?, ?, ?, ?)"
            Using command As New OleDbCommand(insertQuery, connection)
                command.Parameters.AddWithValue("?", supplierName)
                command.Parameters.AddWithValue("?", If(contactPerson = "", DBNull.Value, contactPerson)) ' Handle empty strings for DBNull
                command.Parameters.AddWithValue("?", If(phoneNumber = "", DBNull.Value, phoneNumber))
                command.Parameters.AddWithValue("?", If(email = "", DBNull.Value, email))
                command.Parameters.AddWithValue("?", If(address = "", DBNull.Value, address))

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    MsgBox("Supplier added successfully!", MsgBoxStyle.Information, "Success")
                    LoadSuppliers()
                    SetFormMode("New") ' Reset form for new entry
                Catch ex As Exception
                    MsgBox("Error adding supplier: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
                Finally
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                End Try
            End Using
        End If
    End Sub

    Private Sub EditSupplier()
        Dim supplierId As Integer
        If Not Integer.TryParse(txtSupplierID.Text, supplierId) Then
            MsgBox("Please select a supplier to edit.", MsgBoxStyle.Exclamation, "No Supplier Selected")
            Return
        End If

        ' Input validation
        If String.IsNullOrWhiteSpace(txtSupplierName.Text) Then
            MsgBox("Supplier Name cannot be empty.", MsgBoxStyle.Exclamation, "Validation Error")
            txtSupplierName.Focus()
            Exit Sub
        End If

        ' Validate Phone Number using a more robust regex
        If Not String.IsNullOrWhiteSpace(txtPhoneNumber.Text) Then
            Dim phoneRegex As New Regex("^\+?[0-9\s\-()\.]+$")
            If Not phoneRegex.IsMatch(txtPhoneNumber.Text.Trim()) Then
                MsgBox("Please enter a valid phone number. It should contain only digits, spaces, hyphens, parentheses, or a leading plus sign.", MsgBoxStyle.Exclamation, "Validation Error")
                txtPhoneNumber.Focus()
                Exit Sub
            End If
        End If

        ' Validate Email using a standard email regex
        If Not String.IsNullOrWhiteSpace(txtEmail.Text) Then
            Dim emailRegex As New Regex("^[^@\s]+@[^@\s]+\.[^@\s]+$")
            If Not emailRegex.IsMatch(txtEmail.Text.Trim()) Then
                MsgBox("Please enter a valid email address (e.g., example@domain.com).", MsgBoxStyle.Exclamation, "Validation Error")
                txtEmail.Focus()
                Exit Sub
            End If
        End If

        ' Validate Contact Person (optional, but ensure it's not just whitespace if entered)
        If Not String.IsNullOrWhiteSpace(txtContactPerson.Text) AndAlso String.IsNullOrWhiteSpace(txtContactPerson.Text.Trim()) Then
            MsgBox("Contact Person cannot be just spaces.", MsgBoxStyle.Exclamation, "Validation Error")
            txtContactPerson.Focus()
            Exit Sub
        End If

        ' Validate Address (optional, but ensure it's not just whitespace if entered)
        If Not String.IsNullOrWhiteSpace(txtAddress.Text) AndAlso String.IsNullOrWhiteSpace(txtAddress.Text.Trim()) Then
            MsgBox("Address cannot be just spaces.", MsgBoxStyle.Exclamation, "Validation Error")
            txtAddress.Focus()
            Exit Sub
        End If

        Dim supplierName As String = txtSupplierName.Text.Trim()
        Dim contactPerson As String = txtContactPerson.Text.Trim()
        Dim phoneNumber As String = txtPhoneNumber.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()
        Dim address As String = txtAddress.Text.Trim()

        ' Check for duplicate supplier name (excluding the current supplier being edited)
        Dim checkQuery As String = "SELECT COUNT(*) FROM Suppliers WHERE SupplierName = ? AND SupplierID <> ?"
        Using checkCmd As New OleDbCommand(checkQuery, connection)
            checkCmd.Parameters.AddWithValue("?", supplierName)
            checkCmd.Parameters.AddWithValue("?", supplierId)
            Try
                connection.Open()
                Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                If exists > 0 Then
                    MsgBox("Another supplier with this name already exists.", MsgBoxStyle.Exclamation, "Duplicate Supplier Name")
                    txtSupplierName.Focus()
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("Error checking for duplicate supplier name: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
                Exit Sub
            Finally
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
            End Try
        End Using

        Dim message As String = $"Are you sure you want to update this supplier with the following details?" & vbCrLf &
                                $"ID: {supplierId}" & vbCrLf &
                                $"Name: {supplierName}" & vbCrLf &
                                $"Contact Person: {contactPerson}" & vbCrLf &
                                $"Phone Number: {phoneNumber}" & vbCrLf &
                                $"Email: {email}" & vbCrLf &
                                $"Address: {address}"

        If MessageBox.Show(message, "Confirm Edit Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim updateQuery As String = "UPDATE Suppliers SET SupplierName = ?, ContactPerson = ?, PhoneNumber = ?, Email = ?, Address = ? WHERE SupplierID = ?"
            Using command As New OleDbCommand(updateQuery, connection)
                command.Parameters.AddWithValue("?", supplierName)
                command.Parameters.AddWithValue("?", If(contactPerson = "", DBNull.Value, contactPerson)) ' Handle empty strings for DBNull
                command.Parameters.AddWithValue("?", If(phoneNumber = "", DBNull.Value, phoneNumber))
                command.Parameters.AddWithValue("?", If(email = "", DBNull.Value, email))
                command.Parameters.AddWithValue("?", If(address = "", DBNull.Value, address))
                command.Parameters.AddWithValue("?", supplierId)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    MsgBox("Supplier updated successfully!", MsgBoxStyle.Information, "Success")
                    LoadSuppliers()
                    SetFormMode("New") ' Reset form after successful edit
                Catch ex As Exception
                    MsgBox("Error updating supplier: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
                Finally
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                End Try
            End Using
        End If
    End Sub

    Private Sub DeleteSupplier()
        Dim supplierId As Integer
        If Not Integer.TryParse(txtSupplierID.Text, supplierId) Then
            MsgBox("Please select a supplier to delete.", MsgBoxStyle.Exclamation, "No Supplier Selected")
            Return
        End If

        ' Check for existing related records in Inventory table
        Dim checkInventoryQuery As String = "SELECT COUNT(*) FROM Inventory WHERE SupplierID = ?"
        Using checkInvCmd As New OleDbCommand(checkInventoryQuery, connection)
            checkInvCmd.Parameters.AddWithValue("?", supplierId)
            Try
                connection.Open()
                Dim relatedRecords As Integer = Convert.ToInt32(checkInvCmd.ExecuteScalar())
                If relatedRecords > 0 Then
                    MsgBox($"Cannot delete this supplier. It is currently associated with {relatedRecords} product(s) in the inventory. Please update or remove these products first.", MsgBoxStyle.Exclamation, "Deletion Restricted")
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("Error checking related inventory records: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
                Exit Sub
            Finally
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
            End Try
        End Using

        If MessageBox.Show($"Are you sure you want to delete supplier '{txtSupplierName.Text}' (ID: {supplierId})?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim deleteQuery As String = "DELETE FROM Suppliers WHERE SupplierID = ?"
            Using command As New OleDbCommand(deleteQuery, connection)
                command.Parameters.AddWithValue("?", supplierId)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    MsgBox("Supplier deleted successfully!", MsgBoxStyle.Information, "Success")
                    LoadSuppliers()
                    SetFormMode("New") ' Reset form after successful deletion
                Catch ex As Exception
                    MsgBox("Error deleting supplier: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
                Finally
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                End Try
            End Using
        End If
    End Sub

    ' --- Search Functionality ---
    Private Sub SearchSuppliers(keyword As String)
        Dim query As String = "SELECT SupplierID, SupplierName, ContactPerson, PhoneNumber, Email, Address FROM Suppliers " &
                                "WHERE SupplierName LIKE ? OR ContactPerson LIKE ? OR PhoneNumber LIKE ? OR Email LIKE ? OR Address LIKE ?"
        Using command As New OleDbCommand(query, connection)
            Dim searchParam As String = "%" & keyword & "%"
            command.Parameters.AddWithValue("?", searchParam)
            command.Parameters.AddWithValue("?", searchParam)
            command.Parameters.AddWithValue("?", searchParam)
            command.Parameters.AddWithValue("?", searchParam)
            command.Parameters.AddWithValue("?", searchParam)

            Dim adapter As New OleDbDataAdapter(command)
            Dim dataTable As New DataTable()

            Try
                If connection.State <> ConnectionState.Open Then
                    connection.Open()
                End If
                adapter.Fill(dataTable)
                dgvSuppliers.DataSource = dataTable
            Catch ex As Exception
                MsgBox("Error searching suppliers: " & ex.Message, MsgBoxStyle.Critical, "Search Error")
            Finally
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
            End Try
        End Using
    End Sub

    ' --- Event Handlers for UI elements (you'll need to create these buttons/textboxes on your form) ---
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddSupplier()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        EditSupplier()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteSupplier()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        SetFormMode("New") ' Reset to new entry mode
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        SearchSuppliers(txtSearch.Text)
    End Sub

    Private Sub dgvSuppliers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSuppliers.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvSuppliers.Rows(e.RowIndex)
            txtSupplierID.Text = row.Cells("SupplierID").Value.ToString()
            txtSupplierName.Text = row.Cells("SupplierName").Value.ToString()
            txtContactPerson.Text = If(row.Cells("ContactPerson").Value Is DBNull.Value, "", row.Cells("ContactPerson").Value.ToString())
            txtPhoneNumber.Text = If(row.Cells("PhoneNumber").Value Is DBNull.Value, "", row.Cells("PhoneNumber").Value.ToString())
            txtEmail.Text = If(row.Cells("Email").Value Is DBNull.Value, "", row.Cells("Email").Value.ToString())
            txtAddress.Text = If(row.Cells("Address").Value Is DBNull.Value, "", row.Cells("Address").Value.ToString())
            SetFormMode("Edit") ' Switch to edit mode when a row is selected
        End If
    End Sub

    ' --- Navigation Button (assuming you want to go back to Product form or Dashboard) ---
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        Dim productForm As New frmProduct()
        productForm.SetUsername(lblName.Text) ' If you have lblName on this form
        productForm.Show()
        Me.Close()


    End Sub

End Class