Imports System.Data.OleDb

Public Class frmAdmin

    Private connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Database\GamePOS.accdb"

    Public Sub SetUsername(username As String)
        lblName.Text = username
    End Sub

    Private Sub frmAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
        LoadUserComboBox()
    End Sub

    Private Sub LoadUsers()
        ' --- CHANGE: Updated query to select individual name parts and concatenate for display ---
        Dim query As String = "SELECT Users.Username, Users.[Password], Users.LastName, Users.FirstName, Users.MiddleInitial, Roles.RoleName, Users.Status FROM Users INNER JOIN Roles ON Users.RoleID = Roles.RoleID"

        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(query, connection)
            Dim adapter As New OleDbDataAdapter(command)
            Dim dataTable As New DataTable()

            Try
                connection.Open()
                adapter.Fill(dataTable)

                UsersDataGridView.DataSource = dataTable

                If UsersDataGridView.Columns.Count > 0 Then
                    UsersDataGridView.Columns("Username").Width = 150
                    UsersDataGridView.Columns("Password").Width = 150

                    UsersDataGridView.Columns("LastName").Visible = True
                    UsersDataGridView.Columns("LastName").HeaderText = "Last Name"
                    UsersDataGridView.Columns("LastName").Width = 150
                    UsersDataGridView.Columns("LastName").DisplayIndex = 2 ' Display Last Name after Username and Password

                    UsersDataGridView.Columns("FirstName").Visible = True
                    UsersDataGridView.Columns("FirstName").HeaderText = "First Name"
                    UsersDataGridView.Columns("FirstName").Width = 150
                    UsersDataGridView.Columns("FirstName").DisplayIndex = 3 ' Display First Name after Last Name

                    UsersDataGridView.Columns("MiddleInitial").Visible = True
                    UsersDataGridView.Columns("MiddleInitial").HeaderText = "MI"
                    UsersDataGridView.Columns("MiddleInitial").Width = 50
                    UsersDataGridView.Columns("MiddleInitial").DisplayIndex = 4 ' Display MI after First Name

                    UsersDataGridView.Columns("RoleName").HeaderText = "Role"
                    UsersDataGridView.Columns("RoleName").Width = 100
                    UsersDataGridView.Columns("RoleName").DisplayIndex = 5 ' Adjust display order for Role

                    UsersDataGridView.Columns("Status").Width = 80
                    UsersDataGridView.Columns("Status").DisplayIndex = 6 ' Adjust display order for Status
                End If
            Catch ex As Exception
                MessageBox.Show("Error loading users: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub AddUser()
        If PasswordTextBox.Text <> ConfirmPasswordTxtBox.Text Then
            MessageBox.Show("Passwords do not match.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim roleId As Integer = GetRoleIdByName(RoleComboBox.Text)
        If roleId = -1 Then
            MessageBox.Show("Invalid Role Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim status As String = StatusComboBox.Text.Trim()
        If status <> "Active" AndAlso status <> "Inactive" Then
            MessageBox.Show("Please select a valid Status (Active/Inactive).")
            Exit Sub
        End If

        ' --- NEW: Get individual name parts from textboxes ---
        Dim lastName As String = LastNameTextBox.Text.Trim()
        Dim firstName As String = FirstNameTextBox.Text.Trim()
        Dim middleInitial As String = MiddleInitialTextBox.Text.Trim()

        ' --- CHANGE: Update check query to use individual name fields instead of FullName ---
        Dim checkQuery As String = "SELECT COUNT(*) FROM Users WHERE Username = @Username OR (LastName = @LastName AND FirstName = @FirstName AND MiddleInitial = @MiddleInitial)"
        Using connection As New OleDbConnection(connectionString)
            Using checkCmd As New OleDbCommand(checkQuery, connection)
                checkCmd.Parameters.AddWithValue("@Username", UsernameTextBox.Text)
                checkCmd.Parameters.AddWithValue("@LastName", lastName)
                checkCmd.Parameters.AddWithValue("@FirstName", firstName)
                checkCmd.Parameters.AddWithValue("@MiddleInitial", middleInitial)

                Try
                    connection.Open()
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("A user with the same Username or similar full name already exists.", "Duplicate User", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error checking for existing user: " & ex.Message)
                    Exit Sub
                End Try
            End Using
        End Using

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to add this user?", "Confirm Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            ' --- CHANGE: Update INSERT query to use individual name fields ---
            Dim query As String = "INSERT INTO Users (Username, [Password], LastName, FirstName, MiddleInitial, RoleID, Status) VALUES (@Username, @Password, @LastName, @FirstName, @MiddleInitial, @RoleID, @Status)"

            Using connection As New OleDbConnection(connectionString)
                Using command As New OleDbCommand(query, connection)
                    command.Parameters.AddWithValue("@Username", UsernameTextBox.Text)
                    command.Parameters.AddWithValue("@Password", PasswordTextBox.Text)
                    ' --- NEW: Add parameters for individual name parts ---
                    command.Parameters.AddWithValue("@LastName", lastName)
                    command.Parameters.AddWithValue("@FirstName", firstName)
                    command.Parameters.AddWithValue("@MiddleInitial", middleInitial)
                    command.Parameters.AddWithValue("@RoleID", roleId)
                    command.Parameters.AddWithValue("@Status", status)

                    Try
                        connection.Open()
                        command.ExecuteNonQuery()
                        MessageBox.Show("User added successfully!")
                        LoadUsers()
                        ClearTextboxes()
                    Catch ex As Exception
                        MessageBox.Show("Error adding user: " & ex.Message)
                    End Try
                End Using
            End Using
        End If
    End Sub

    Private Sub EditUser()
        If PasswordTextBox.Text <> ConfirmPasswordTxtBox.Text Then
            MessageBox.Show("Passwords do not match.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim roleId As Integer = GetRoleIdByName(RoleComboBox.Text)
        If roleId = -1 Then
            MessageBox.Show("Invalid Role Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim status As String = StatusComboBox.Text.Trim()
        If status <> "Active" AndAlso status <> "Inactive" Then
            MessageBox.Show("Please select a valid Status (Active/Inactive).")
            Exit Sub
        End If

        ' --- NEW: Get individual name parts from textboxes ---
        Dim lastName As String = LastNameTextBox.Text.Trim()
        Dim firstName As String = FirstNameTextBox.Text.Trim()
        Dim middleInitial As String = MiddleInitialTextBox.Text.Trim()

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to update this user?", "Confirm Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            ' --- CHANGE: Update UPDATE query to use individual name fields ---
            Dim query As String = "UPDATE Users SET [Password] = @Password, LastName = @LastName, FirstName = @FirstName, MiddleInitial = @MiddleInitial, RoleID = @RoleID, Status = @Status WHERE Username = @Username"

            Using connection As New OleDbConnection(connectionString)
                Using command As New OleDbCommand(query, connection)
                    command.Parameters.AddWithValue("@Password", PasswordTextBox.Text)
                    ' --- NEW: Add parameters for individual name parts ---
                    command.Parameters.AddWithValue("@LastName", lastName)
                    command.Parameters.AddWithValue("@FirstName", firstName)
                    command.Parameters.AddWithValue("@MiddleInitial", middleInitial)
                    command.Parameters.AddWithValue("@RoleID", roleId)
                    command.Parameters.AddWithValue("@Status", status)
                    command.Parameters.AddWithValue("@Username", UsernameTextBox.Text)

                    Try
                        connection.Open()
                        command.ExecuteNonQuery()
                        MessageBox.Show("User updated successfully!")
                        LoadUsers()
                        ClearTextboxes()
                    Catch ex As Exception
                        MessageBox.Show("Error updating user: " & ex.Message)
                    End Try
                End Using
            End Using
        End If
    End Sub

    Private Sub DeleteUser()
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Dim query As String = "DELETE FROM Users WHERE Username = @Username"

            Using connection As New OleDbConnection(connectionString)
                Using command As New OleDbCommand(query, connection)
                    command.Parameters.AddWithValue("@Username", UsernameTextBox.Text)

                    Try
                        connection.Open()
                        command.ExecuteNonQuery()
                        MessageBox.Show("User deleted successfully!")
                        LoadUsers()
                        ClearTextboxes()
                    Catch ex As Exception
                        MessageBox.Show("Error deleting user: " & ex.Message)
                    End Try
                End Using
            End Using
        End If
    End Sub

    ' Button Events
    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        AddUser()
    End Sub

    Private Sub EditButton_Click(sender As Object, e As EventArgs) Handles EditButton.Click
        EditUser()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        DeleteUser()
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

    Private Sub UsersDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles UsersDataGridView.SelectionChanged
        If UsersDataGridView.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = UsersDataGridView.SelectedRows(0)
            UsernameTextBox.Text = row.Cells("Username").Value.ToString()
            PasswordTextBox.Text = row.Cells("Password").Value.ToString()
            ' --- CHANGE: Populate individual name textboxes ---
            LastNameTextBox.Text = If(row.Cells("LastName").Value IsNot DBNull.Value, row.Cells("LastName").Value.ToString(), "")
            FirstNameTextBox.Text = If(row.Cells("FirstName").Value IsNot DBNull.Value, row.Cells("FirstName").Value.ToString(), "")
            MiddleInitialTextBox.Text = If(row.Cells("MiddleInitial").Value IsNot DBNull.Value, row.Cells("MiddleInitial").Value.ToString(), "")
            RoleComboBox.Text = row.Cells("RoleName").Value.ToString()
            StatusComboBox.Text = row.Cells("Status").Value.ToString()
            ' Optionally, if you have a FullNameTextBox for display purposes
            ' FullNameTextBox.Text = row.Cells("FullName").Value.ToString() 
        End If
    End Sub

    Private Sub SearchUsers(keyword As String)
        ' --- CHANGE: Update search query to include individual name fields ---
        Dim query As String = "SELECT Users.Username, Users.[Password], Users.LastName, Users.FirstName, Users.MiddleInitial, Roles.RoleName, Users.Status " &
                              "FROM Users INNER JOIN Roles ON Users.RoleID = Roles.RoleID " &
                              "WHERE Users.Username LIKE ? OR Users.LastName LIKE ? OR Users.FirstName LIKE ? OR Users.MiddleInitial LIKE ?"

        Using connection As New OleDbConnection(connectionString)
            Using command As New OleDbCommand(query, connection)
                command.Parameters.AddWithValue("?", "%" & keyword & "%")
                command.Parameters.AddWithValue("?", "%" & keyword & "%")
                command.Parameters.AddWithValue("?", "%" & keyword & "%")
                command.Parameters.AddWithValue("?", "%" & keyword & "%")

                Dim adapter As New OleDbDataAdapter(command)
                Dim dataTable As New DataTable()

                Try
                    connection.Open()
                    adapter.Fill(dataTable)

                    ' --- CHANGE: Add FullName column after search for display ---
                    dataTable.Columns.Add("FullName", GetType(String))
                    For Each row As DataRow In dataTable.Rows
                        Dim lastName As String = If(row("LastName") IsNot DBNull.Value, row("LastName").ToString(), "")
                        Dim firstName As String = If(row("FirstName") IsNot DBNull.Value, row("FirstName").ToString(), "")
                        Dim middleInitial As String = If(row("MiddleInitial") IsNot DBNull.Value, row("MiddleInitial").ToString(), "")

                        Dim fullNameParts As New List(Of String)
                        If Not String.IsNullOrWhiteSpace(firstName) Then fullNameParts.Add(firstName)
                        If Not String.IsNullOrWhiteSpace(middleInitial) Then fullNameParts.Add(middleInitial)
                        If Not String.IsNullOrWhiteSpace(lastName) Then fullNameParts.Add(lastName)

                        row("FullName") = String.Join(" ", fullNameParts)
                    Next

                    UsersDataGridView.DataSource = dataTable

                    If UsersDataGridView.Columns.Count > 0 Then
                        UsersDataGridView.Columns("Username").Width = 150
                        UsersDataGridView.Columns("Password").Width = 150
                        UsersDataGridView.Columns("LastName").Visible = False
                        UsersDataGridView.Columns("FirstName").Visible = False
                        UsersDataGridView.Columns("MiddleInitial").Visible = False
                        UsersDataGridView.Columns("FullName").Width = 200
                        UsersDataGridView.Columns("FullName").DisplayIndex = 2 ' Adjust display order if needed
                        UsersDataGridView.Columns("RoleName").HeaderText = "Role"
                        UsersDataGridView.Columns("RoleName").Width = 100
                        UsersDataGridView.Columns("Status").Width = 80
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error searching users: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub SearchUserTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchUserTextBox.TextChanged
        If String.IsNullOrWhiteSpace(SearchUserTextBox.Text) Then
            LoadUsers()
        Else
            SearchUsers(SearchUserTextBox.Text.Trim())
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        frmProduct.SetUsername(lblName.Text)
        frmProduct.Show()
        Me.Close()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        frmSales.SetUsername(lblName.Text)
        frmSales.Show()
        Me.Close()
    End Sub

    Private Function GetRoleIdByName(roleName As String) As Integer
        Dim query As String = "SELECT RoleID FROM Roles WHERE RoleName = ?"
        Using connection As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand(query, connection)
                cmd.Parameters.AddWithValue("?", roleName)
                Try
                    connection.Open()
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return Convert.ToInt32(result)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Failed to get RoleID: " & ex.Message)
                End Try
            End Using
        End Using
        Return -1
    End Function

    Private Sub ClearTextboxes()
        UsernameTextBox.Clear()
        PasswordTextBox.Clear()
        ConfirmPasswordTxtBox.Clear()
        ' --- CHANGE: Clear individual name textboxes ---
        LastNameTextBox.Clear()
        FirstNameTextBox.Clear()
        MiddleInitialTextBox.Clear()
        RoleComboBox.SelectedIndex = -1
        StatusComboBox.SelectedIndex = -1
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        ClearTextboxes()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Now.ToShortDateString
        lblTime.Text = Now.ToShortTimeString
    End Sub

    Private Sub DgvQuota_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvQuota.CellContentClick

    End Sub

    Private Sub LoadUserComboBox()
        Dim query As String = "SELECT UserID, Username FROM Users"
        Using connection As New OleDbConnection(connectionString)
            Using command As New OleDbCommand(query, connection)
                Dim adapter As New OleDbDataAdapter(command)
                Dim dataTable As New DataTable()

                Try
                    connection.Open()
                    adapter.Fill(dataTable)
                    cmdUsers.DataSource = dataTable
                    cmdUsers.DisplayMember = "Username"
                    cmdUsers.ValueMember = "UserID"
                Catch ex As Exception
                    MessageBox.Show("Error loading users into dropdown: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub cmdUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmdUsers.SelectedIndexChanged
        If cmdUsers.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmdUsers.SelectedValue.ToString(), Nothing) Then
            Dim selectedUserId As Integer = Convert.ToInt32(cmdUsers.SelectedValue)
            LoadUserQuota(selectedUserId)
        End If
    End Sub

    Private Sub LoadUserQuota(userId As Integer)
        Dim query As String = "SELECT QuotaID, SalesID, QuotaAmmount, QuotaDate FROM Quota WHERE UserID = @UserID"
        Using connection As New OleDbConnection(connectionString)
            Using command As New OleDbCommand(query, connection)
                command.Parameters.AddWithValue("@UserID", userId)
                Dim adapter As New OleDbDataAdapter(command)
                Dim dataTable As New DataTable()

                Try
                    connection.Open()
                    adapter.Fill(dataTable)
                    DgvQuota.DataSource = dataTable
                Catch ex As Exception
                    MessageBox.Show("Error loading quota data: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If cmdUsers.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmdUsers.SelectedValue.ToString(), Nothing) Then
            Dim selectedUserId As Integer = Convert.ToInt32(cmdUsers.SelectedValue)
            Dim fromDate As DateTime = DateTimePicker1.Value.Date
            LoadUserQuota(selectedUserId, fromDate)
        End If
    End Sub



    Private Sub LoadUserQuota(userId As Integer, fromDate As DateTime)
        Dim toDate As DateTime = fromDate.AddDays(1)

        Dim query As String = "SELECT QuotaID, SalesID, QuotaAmmount, QuotaDate " &
                              "FROM Quota WHERE UserID = @UserID " &
                              "AND QuotaDate >= @FromDate AND QuotaDate <= @ToDate"

        Using connection As New OleDbConnection(connectionString)
            Using command As New OleDbCommand(query, connection)
                command.Parameters.AddWithValue("@UserID", userId)
                command.Parameters.AddWithValue("@FromDate", fromDate.Date)
                command.Parameters.AddWithValue("@ToDate", toDate.Date)

                Dim adapter As New OleDbDataAdapter(command)
                Dim dataTable As New DataTable()

                Try
                    connection.Open()
                    adapter.Fill(dataTable)
                    DgvQuota.DataSource = dataTable
                Catch ex As Exception
                    MessageBox.Show("Error loading quota data: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub



    Private Sub btnResetQuotaFilter_Click(sender As Object, e As EventArgs) Handles btnResetQuotaFilter.Click
        If cmdUsers.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmdUsers.SelectedValue.ToString(), Nothing) Then
            Dim selectedUserId As Integer = Convert.ToInt32(cmdUsers.SelectedValue)
            LoadUserQuota(selectedUserId)
        End If
        DateTimePicker1.Value = DateTime.Now.Date
    End Sub

    Public Sub CheckCriticalProductLevels()
        Dim query As String = "SELECT ProductName, Quantity, CriticalLevel FROM Products INNER JOIN Inventory ON Products.ProductID = Inventory.ProductID WHERE Quantity < CriticalLevel"
        Using connection As New OleDbConnection(connectionString)
            Using command As New OleDbCommand(query, connection)
                Dim adapter As New OleDbDataAdapter(command)
                Dim dataTable As New DataTable()

                Try
                    connection.Open()
                    adapter.Fill(dataTable)

                    If dataTable.Rows.Count > 0 Then
                        Dim message As String = "The following products are at a critical level:" & Environment.NewLine
                        For Each row As DataRow In dataTable.Rows
                            message &= $"{row("ProductName")}: {row("Quantity")} units" & Environment.NewLine
                        Next
                        MessageBox.Show(message, "Critical Product Levels", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error checking critical product levels: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub DashboardButton_Click(sender As Object, e As EventArgs) Handles DashboardButton.Click
        frmDashboard.SetUsername(lblName.Text)
        frmDashboard.Show()
        Close()
    End Sub
End Class