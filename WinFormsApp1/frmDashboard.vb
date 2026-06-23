Imports System.Data.OleDb
Imports System.Data ' Added for DataTable

Public Class frmDashboard

    Private connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Database\GamePOS.accdb"
    Private _loggedInUserID As Integer ' To store the ID of the logged-in admin

    ' Property to set the username for the dashboard (similar to other forms)
    Public Sub SetUsername(username As String)
        ' Assuming you have a Label control named lblName on frmDashboard
        If lblName IsNot Nothing Then
            lblName.Text = username
        End If
    End Sub

    ' New method to set the UserID for the dashboard
    Public Sub SetUserID(userID As Integer)
        _loggedInUserID = userID
    End Sub

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load all the dashboard data when the form loads
        LoadCriticalLevelItems()
        LoadMostSoldItems()
        LoadLeastSoldItems()

        ' Load all user quotas (using the qryUsersQuota)
        LoadUserQuota() ' No UserID parameter needed for this query

        ' Show notification for critical level items
        CheckCriticalProductLevelsAndNotify()

        ' Start the timer for date/time display (assuming you have a Timer1 and lblDate/lblTime)
        Timer1.Start()
    End Sub

    ' --- Data Loading Methods ---

    Private Sub LoadCriticalLevelItems()
        Dim query As String = "SELECT P.ProductName, I.Quantity AS CurrentStock, I.CriticalLevel " &
                              "FROM Products AS P INNER JOIN Inventory AS I ON P.ProductID = I.ProductID " &
                              "WHERE I.Quantity <= I.CriticalLevel " &
                              "ORDER BY I.Quantity ASC;"

        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(query, connection)
            Dim adapter As New OleDbDataAdapter(command)
            Dim dataTable As New DataTable()

            Try
                connection.Open()
                adapter.Fill(dataTable)
                DataGridCriticalLevel.DataSource = dataTable
                FormatDataGridView(DataGridCriticalLevel) ' Apply basic formatting
            Catch ex As Exception
                MessageBox.Show("Error loading Critical Level Items: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub LoadMostSoldItems()
        Dim query As String = "SELECT TOP 5 P.ProductName, SUM(SD.Quantity) AS TotalQuantitySold " &
                              "FROM Products AS P INNER JOIN SalesDetails AS SD ON P.ProductID = SD.ProductID " &
                              "GROUP BY P.ProductName " &
                              "ORDER BY SUM(SD.Quantity) DESC;"

        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(query, connection)
            Dim adapter As New OleDbDataAdapter(command)
            Dim dataTable As New DataTable()

            Try
                connection.Open()
                adapter.Fill(dataTable)
                DataGridMostSold.DataSource = dataTable
                FormatDataGridView(DataGridMostSold) ' Apply basic formatting
            Catch ex As Exception
                MessageBox.Show("Error loading Most Sold Items: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub LoadLeastSoldItems()
        Dim query As String = "SELECT TOP 5 P.ProductName, SUM(SD.Quantity) AS TotalQuantitySold " &
                              "FROM Products AS P INNER JOIN SalesDetails AS SD ON P.ProductID = SD.ProductID " &
                              "GROUP BY P.ProductName " &
                              "ORDER BY SUM(SD.Quantity) ASC;"

        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(query, connection)
            Dim adapter As New OleDbDataAdapter(command)
            Dim dataTable As New DataTable()

            Try
                connection.Open()
                adapter.Fill(dataTable)
                DataGridLeastSold.DataSource = dataTable
                FormatDataGridView(DataGridLeastSold) ' Apply basic formatting
            Catch ex As Exception
                MessageBox.Show("Error loading Least Sold Items: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Updated to use the qryUsersQuota query
    Private Sub LoadUserQuota()
        ' This query fetches quota data for all users, including UserName and RoleName
        Dim query As String = "SELECT Quota.QuotaID, Users.UserName, Roles.RoleName, Quota.QuotaAmmount, Quota.QuotaDate, Quota.SalesID " &
                              "FROM Quota, Users, Roles " &
                              "WHERE Quota.UserID = Users.UserID AND Users.RoleID = Roles.RoleID;"

        Using connection As New OleDbConnection(connectionString)
            Using command As New OleDbCommand(query, connection)
                ' No parameters needed for this query as it fetches all quotas
                Dim adapter As New OleDbDataAdapter(command)
                Dim dataTable As New DataTable()

                Try
                    connection.Open()
                    adapter.Fill(dataTable)
                    DataGridQuota.DataSource = dataTable ' Assign to the new DataGridQuota
                    FormatDataGridView(DataGridQuota) ' Apply basic formatting
                Catch ex As Exception
                    MessageBox.Show("Error loading user quota data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' Helper method to apply basic formatting to DataGridViews
    Private Sub FormatDataGridView(dgv As DataGridView)
        With dgv
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill ' Make columns fill the width
            .AllowUserToAddRows = False ' Prevent the empty row at the bottom
            .ReadOnly = True ' Make all cells read-only
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect ' Select entire row
            .AllowUserToResizeRows = False ' Prevent users from resizing rows
            .RowHeadersVisible = False ' Hide row headers (the left-most column with arrows)

            ' Apply a simple dark theme (can be customized)
            Dim darkBlue As Color = Color.FromArgb(14, 20, 43)
            Dim silverGray As Color = Color.Silver

            .EnableHeadersVisualStyles = False
            .BackgroundColor = darkBlue
            .DefaultCellStyle.BackColor = darkBlue
            .DefaultCellStyle.ForeColor = silverGray
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 30, 53) ' Slightly different dark color for alternating rows
            .AlternatingRowsDefaultCellStyle.ForeColor = silverGray
            .ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .RowHeadersDefaultCellStyle.BackColor = darkBlue
            .RowHeadersDefaultCellStyle.ForeColor = silverGray
        End With
    End Sub

    ' --- Notification Method ---
    Private Sub CheckCriticalProductLevelsAndNotify()
        Dim query As String = "SELECT ProductName, Quantity, CriticalLevel FROM Products INNER JOIN Inventory ON Products.ProductID = Inventory.ProductID WHERE Quantity <= CriticalLevel"
        Using connection As New OleDbConnection(connectionString)
            Using command As New OleDbCommand(query, connection)
                Dim adapter As New OleDbDataAdapter(command)
                Dim dataTable As New DataTable()

                Try
                    connection.Open()
                    adapter.Fill(dataTable)

                    If dataTable.Rows.Count > 0 Then
                        Dim message As String = $"Attention, {lblName.Text}! The following products are at or below their critical level. Please Stock up the products:" & Environment.NewLine & Environment.NewLine
                        For Each row As DataRow In dataTable.Rows
                            message &= $"{row("ProductName")}: {row("Quantity")} units (Critical Level: {row("CriticalLevel")})" & Environment.NewLine
                        Next
                        MessageBox.Show(message, "Critical Product Levels Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error checking critical product levels for notification: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub


    ' --- Navigation Button Event Handlers ---

    Private Sub btnUserMan_Click(sender As Object, e As EventArgs) Handles btnUserMan.Click
        frmAdmin.SetUsername(lblName.Text)
        frmAdmin.Show()
        Me.Close()
    End Sub

    Private Sub btnProdMan_Click(sender As Object, e As EventArgs) Handles btnProdMan.Click
        frmProduct.SetUsername(lblName.Text)
        frmProduct.Show()
        Me.Close()
    End Sub

    Private Sub btnSales_Click(sender As Object, e As EventArgs) Handles btnSales.Click
        frmSales.SetUsername(lblName.Text)
        frmSales.Show()
        Me.Close()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Me.Close()
            Login.Show()
            Login.clearText()
            Login.CheckBox1.Checked = False
            Login.passwordtxtBox.UseSystemPasswordChar = True
        End If
    End Sub

    ' --- Timer Event Handler for Date/Time Display ---
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If lblDate IsNot Nothing Then lblDate.Text = Now.ToString("MMMM dd,yyyy")
        If lblTime IsNot Nothing Then lblTime.Text = Now.ToString("hh:mm:ss tt")
    End Sub

End Class
