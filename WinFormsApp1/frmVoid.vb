Public Class frmVoid
    Public Property ManagerUsername As String
    Public Property ManagerPassword As String

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If txtUsername.Text.Trim() = "" OrElse txtPassword.Text = "" Then
            MessageBox.Show("Please enter both username and password.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ManagerUsername = txtUsername.Text.Trim()
        ManagerPassword = txtPassword.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class