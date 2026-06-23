Imports System.Data.OleDb
Imports System.Data

Public Class frmSales

    Private connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Database\GamePOS.accdb"
    Private connection As New OleDbConnection(connectionString)
    Private dt As DataTable
    Private da As OleDbDataAdapter

    ' Flag to control whether to show "No sales found" message
    Private showNoSalesMessage As Boolean = False

    Public Sub SetUsername(username As String)
        lblName.Text = username
    End Sub

    Private Sub frmSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSalesData()
        Timer1.Start()
    End Sub

    Private Sub LoadSalesData()
        Try
            dt = New DataTable()

            If connection.State = ConnectionState.Open Then connection.Close()

            Dim dateFrom As Date = DateTimePickerFrom.Value.Date
            Dim dateTo As Date = DateTimePickerTo.Value.Date.AddDays(1)

            Dim query As String = ""
            query &= "SELECT Sales.SalesID, Sales.SalesDate, Products.ProductName, SalesDetails.Quantity, "
            query &= "SalesDetails.UnitPrice, SalesDetails.SubTotal, Payments.AmountPaid, Payments.AmountChange, "
            query &= "MOP.MOPName, "
            ' --- START CHANGE ---
            ' Concatenate LastName, FirstName, and MiddleInitial to form CashierName
            ' Use Nz (Null to Zero/Empty) to handle potential NULL values in Access database fields
            query &= "TRIM(IIF(ISNULL(Users.FirstName), '', Users.FirstName) & ' ' & IIF(ISNULL(Users.MiddleInitial), '', Users.MiddleInitial) & ' ' & IIF(ISNULL(Users.LastName), '', Users.LastName)) AS CashierName "
            ' --- END CHANGE ---
            query &= "FROM ((((Sales "
            query &= "INNER JOIN SalesDetails ON Sales.SalesID = SalesDetails.SalesID) "
            query &= "INNER JOIN Products ON SalesDetails.ProductID = Products.ProductID) "
            query &= "INNER JOIN Payments ON Sales.PaymentID = Payments.PaymentID) "
            query &= "INNER JOIN MOP ON Payments.MOPID = MOP.MOPID) "
            query &= "INNER JOIN Users ON Payments.UserID = Users.UserID "
            query &= "WHERE Sales.SalesDate >= ? AND Sales.SalesDate < ? "
            query &= "ORDER BY Sales.SalesDate DESC;"

            Using cmd As New OleDbCommand(query, connection)
                cmd.Parameters.AddWithValue("?", dateFrom)
                cmd.Parameters.AddWithValue("?", dateTo)

                da = New OleDbDataAdapter(cmd)
                da.Fill(dt)
            End Using

            If dt.Rows.Count = 0 AndAlso showNoSalesMessage Then
                MessageBox.Show("No sales found within the selected date range.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            SalesDataGridView.DataSource = dt
            FormatSalesGrid()

            ' Calculate total sales amount (sum of SubTotal)
            Dim totalSales As Decimal = 0D
            For Each row As DataRow In dt.Rows
                totalSales += Convert.ToDecimal(row("SubTotal"))
            Next

            lblDailySalesTotal.Text = "Total Sales: " & totalSales.ToString("C2")

        Catch ex As Exception
            MessageBox.Show("Error loading sales data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub FormatSalesGrid()
        With SalesDataGridView
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .Columns("UnitPrice").DefaultCellStyle.Format = "C2"
            .Columns("SubTotal").DefaultCellStyle.Format = "C2"
            .Columns("AmountPaid").DefaultCellStyle.Format = "C2"
            .Columns("AmountChange").DefaultCellStyle.Format = "C2"
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .RowHeadersVisible = False
        End With
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Close()
            Login.Show()
            Login.clearText()
            Login.CheckBox1.Checked = False
            Login.passwordtxtBox.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub UserManagement_Click(sender As Object, e As EventArgs) Handles UserManagement.Click
        frmAdmin.SetUsername(lblName.Text)
        frmAdmin.Show()
        Close()
    End Sub

    Private Sub ProductManagement_Click(sender As Object, e As EventArgs) Handles ProductManagement.Click
        frmProduct.SetUsername(lblName.Text)
        frmProduct.Show()
        Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Now.ToString("MMMM dd, yyyy")
        lblTime.Text = Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        showNoSalesMessage = True
        LoadSalesData()
        showNoSalesMessage = False
    End Sub

    Private Sub DashboardButton_Click(sender As Object, e As EventArgs) Handles DashboardButton.Click
        frmDashboard.SetUsername(lblName.Text)
        frmDashboard.Show()
        Close()
    End Sub

End Class