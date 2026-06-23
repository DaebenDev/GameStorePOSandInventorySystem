Imports System.Data.OleDb

Public Class Login
    ' Keep the connection string, but use it to create local connections in methods
    Dim connStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Database\GamePOS.accdb"
    Dim conn As New OleDbConnection(connStr) ' Still keep for loginBtn_Click for now

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        passwordtxtBox.UseSystemPasswordChar = True
        CheckBox1.Checked = False
        Roles.Text = ""
        lblUserInfo.Text = ""
    End Sub

    Private Sub loginBtn_Click(sender As Object, e As EventArgs) Handles loginBtn.Click
        ' It's generally safer to wrap the connection in a Using block here too
        Using localConn As New OleDbConnection(connStr) ' Create a local connection for this method
            Try
                localConn.Open()
                Dim cmd As New OleDbCommand("SELECT * FROM Users WHERE UserName=? AND [Password]=? AND Status='Active'", localConn)
                cmd.Parameters.AddWithValue("?", usernametxtBox.Text.Trim)
                cmd.Parameters.AddWithValue("?", passwordtxtBox.Text.Trim)

                Dim reader = cmd.ExecuteReader
                If reader.HasRows Then
                    reader.Read()
                    Dim userID As Integer = reader("UserID")
                    Dim username As String = reader("UserName").ToString()
                    Dim roleID As Integer = reader("RoleID") ' Assuming RoleID 2 is for Admin

                    MessageBox.Show("Welcome to the system, " & username & "!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Navigate and pass user info based on roleID
                    If roleID = 1 Then ' Example: Cashier Role
                        frmCashier.SetUserInfo(userID, username)
                        frmCashier.Show()
                        Hide()
                    ElseIf roleID = 2 Then ' Admin Role: Now goes to frmDashboard
                        Dim dashboardForm As New frmDashboard()
                        ' Assuming frmDashboard has a SetUsername method
                        dashboardForm.SetUsername(username)
                        dashboardForm.Show()
                        Hide()
                    Else ' For any other roleID not explicitly handled
                        MessageBox.Show("Access denied. User does not have a recognized role.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Else
                    MessageBox.Show("Invalid username or password, or your account is inactive. Please contact administrator.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                ' No need for localConn.Close() here, the Using block handles disposal
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' If an error occurs before localConn.Open(), it won't be open, so no need to check state
            End Try
        End Using ' localConn is guaranteed to be closed and disposed here
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        passwordtxtBox.UseSystemPasswordChar = Not CheckBox1.Checked
        CheckBox1.Text = If(CheckBox1.Checked, "Hide Password", "Show Password")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Do you want to close the system?", vbQuestion + vbYesNo) = vbYes Then
            MsgBox("Thank you for using the system", MsgBoxStyle.Information)
            Me.Close()
            Application.Exit()
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        clearText()
        If MsgBox("Are you sure you want to cancel the login?", vbQuestion + vbYesNo) = vbYes Then
            MsgBox("Thank you for using the system", MsgBoxStyle.Information)
            Me.Close()
            Application.Exit()
        End If
    End Sub

    Public Sub clearText()
        passwordtxtBox.Clear()
        usernametxtBox.Clear()
        Roles.Text = ""
        lblUserInfo.Text = ""
    End Sub

    Private Sub usernametxtBox_TextChanged(sender As Object, e As EventArgs) Handles usernametxtBox.TextChanged
        If usernametxtBox.Text.Trim = "" Then
            Roles.Text = ""
            lblUserInfo.Text = ""
            Exit Sub
        End If

        ' *** CRITICAL CHANGE HERE: Use a LOCAL connection and wrap it in a Using block ***
        Using localConn As New OleDbConnection(connStr)
            Try
                localConn.Open()

                Dim sql As String = "SELECT Users.UserID, Users.UserName, Roles.RoleName FROM Users INNER JOIN Roles ON Users.RoleID = Roles.RoleID WHERE Users.UserName = ?"
                Using cmd As New OleDbCommand(sql, localConn)
                    cmd.Parameters.AddWithValue("?", usernametxtBox.Text.Trim)

                    Using dr As OleDbDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            Dim userID As Integer = dr("UserID")
                            Dim username As String = dr("UserName").ToString()
                            Dim roleName As String = dr("RoleName").ToString()

                            Roles.Text = roleName
                            lblUserInfo.Text = "User ID: " & userID.ToString() & " | Name: " & username
                        Else
                            Roles.Text = ""
                            lblUserInfo.Text = ""
                        End If
                    End Using ' DataReader is disposed here
                End Using ' Command is disposed here
                ' No need for localConn.Close() here, the Using block handles disposal
            Catch ex As Exception
                ' Consider logging this error instead of a MessageBox for every keystroke error
                ' MessageBox.Show("Error retrieving user info: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Roles.Text = "Error" ' Indicate an error without a popup
                lblUserInfo.Text = "Database Error"
            End Try
        End Using ' Connection is guaranteed to be closed and disposed here
    End Sub
End Class