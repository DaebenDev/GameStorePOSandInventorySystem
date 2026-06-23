Imports System.IO

Public Class frmReceipt

    '=========  1) Public data coming from Payments form  =========
    Public Property TransactionDate As DateTime
    Public Property CashierName As String
    Public Property TotalAmount As Decimal
    Public Property AmountPaid As Decimal
    Public Property ChangeAmount As Decimal
    Public Property ModeOfPayment As String
    Public Property ProductList As DataGridView
    Public Property VatAmount As Decimal
    Public Property NonVatAmount As Decimal

    '=========  2) Absolute folder where we’ll store .txt files  =========
    Private Const RECEIPT_BASE_PATH As String =
        "C:\Users\Mindoro\Desktop\GameStorePOSandInventorySystemWorking\WinFormsApp1\bin\Debug\net8.0-windows"

    '=========  3) Form-load: build on-screen DataGridView  =========
    Private Sub frmReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblStoreName.Text = "GamePOS Store"
        lblReceiptDate.Text = TransactionDate.ToShortDateString()
        lblReceiptTime.Text = TransactionDate.ToShortTimeString()
        lblReceiptCashier.Text = "Cashier: " & CashierName
        lblReceiptTotal.Text = "Total: " & TotalAmount.ToString("N2")
        lblReceiptPaid.Text = "Amount Paid: " & AmountPaid.ToString("N2")
        lblReceiptChange.Text = "Change: " & ChangeAmount.ToString("N2")
        lblReceiptMOP.Text = "Mode of Payment: " & ModeOfPayment
        lblReceiptVat.Text = "VAT: " & VatAmount.ToString("N2")
        lblReceiptNonVat.Text = "Non-VAT: " & NonVatAmount.ToString("N2")

        dgvReceiptItems.Columns.Clear()
        With dgvReceiptItems.Columns
            .Add("ProductName", "Product Name")
            .Add("Quantity", "Qty")
            .Add("UnitPrice", "Unit Price")
            .Add("SubTotal", "SubTotal")
        End With
        For Each c As DataGridViewColumn In dgvReceiptItems.Columns
            c.ReadOnly = True
        Next

        '—Copy rows from the Payment-form grid—
        If ProductList IsNot Nothing Then
            For Each src As DataGridViewRow In ProductList.Rows
                If src.IsNewRow Then Continue For
                Dim pName As String = "", qty As Integer = 0, uPrice As Decimal = 0D, subTot As Decimal = 0D

                If ProductList.Columns.Contains("ProductName") AndAlso src.Cells("ProductName").Value IsNot Nothing Then
                    pName = src.Cells("ProductName").Value.ToString()
                Else
                    pName = src.Cells(1).Value?.ToString()
                End If

                If ProductList.Columns.Contains("Quantity") AndAlso src.Cells("Quantity").Value IsNot Nothing Then
                    Integer.TryParse(src.Cells("Quantity").Value.ToString(), qty)
                Else
                    Integer.TryParse(src.Cells(2).Value?.ToString(), qty)
                End If

                If ProductList.Columns.Contains("Price") AndAlso src.Cells("Price").Value IsNot Nothing Then
                    Decimal.TryParse(src.Cells("Price").Value.ToString(), uPrice)
                Else
                    Decimal.TryParse(src.Cells(3).Value?.ToString(), uPrice)
                End If

                If ProductList.Columns.Contains("Total") AndAlso src.Cells("Total").Value IsNot Nothing Then
                    Decimal.TryParse(src.Cells("Total").Value.ToString(), subTot)
                Else
                    Decimal.TryParse(src.Cells(6).Value?.ToString(), subTot)
                End If

                dgvReceiptItems.Rows.Add(pName, qty, uPrice.ToString("N2"), subTot.ToString("N2"))
            Next
        End If

        With dgvReceiptItems
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ColumnHeadersVisible = True
            .RowHeadersVisible = False
            .ReadOnly = True
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    '=========  4) Build plain-text receipt  =========
    Private Function BuildReceiptText() As String
        Dim sb As New Text.StringBuilder()

        sb.AppendLine("========== GAMEPOS STORE ==========")
        sb.AppendLine("Date/Time : " & TransactionDate.ToString("yyyy-MM-dd HH:mm:ss"))
        sb.AppendLine("Cashier   : " & CashierName)
        sb.AppendLine("Pay-Mode  : " & ModeOfPayment)
        sb.AppendLine("-----------------------------------")
        sb.AppendLine("Item".PadRight(20) &
                  "Qty".PadLeft(4) &
                  "Price".PadLeft(10) &
                  "SubTot".PadLeft(10))
        sb.AppendLine("-----------------------------------")

        For Each r As DataGridViewRow In dgvReceiptItems.Rows
            Dim nm As String = r.Cells("ProductName").Value.ToString()
            Dim q As String = r.Cells("Quantity").Value.ToString()
            Dim pr As String = r.Cells("UnitPrice").Value.ToString()
            Dim st As String = r.Cells("SubTotal").Value.ToString()
            If nm.Length > 20 Then nm = nm.Substring(0, 20)

            sb.AppendLine(nm.PadRight(20) & q.PadLeft(4) & pr.PadLeft(10) & st.PadLeft(10))
        Next

        sb.AppendLine("-----------------------------------")
        sb.AppendLine("VAT       : " & VatAmount.ToString("N2"))
        sb.AppendLine("Non-VAT   : " & NonVatAmount.ToString("N2"))
        sb.AppendLine("TOTAL     : " & TotalAmount.ToString("N2"))
        sb.AppendLine("PAID      : " & AmountPaid.ToString("N2"))
        sb.AppendLine("CHANGE    : " & ChangeAmount.ToString("N2"))
        sb.AppendLine("-----------------------------------")

        ' ==== New rating & thank-you section ====
        sb.AppendLine("How was your shopping experience?")
        sb.AppendLine("Please rate us:  ☆ ☆ ☆ ☆ ☆   (1-Poor  5-Excellent)")
        sb.AppendLine()
        sb.AppendLine("Thank you for choosing GamePOS Store!")
        sb.AppendLine("We appreciate your business and hope")
        sb.AppendLine("to see you again soon.")
        sb.AppendLine("===================================")

        Return sb.ToString()
    End Function


    '=========  5) Save the text into <BASE>\Receipts\Receipt_*.txt  =========
    Private Function SaveReceiptToTxt(receiptText As String) As String
        Dim receiptsDir As String = Path.Combine(RECEIPT_BASE_PATH, "Receipts")
        If Not Directory.Exists(receiptsDir) Then Directory.CreateDirectory(receiptsDir)

        Dim fileName As String = "Receipt_" & TransactionDate.ToString("yyyyMMdd_HHmmss") & ".txt"
        Dim fullPath As String = Path.Combine(receiptsDir, fileName)

        File.WriteAllText(fullPath, receiptText)
        Return fullPath
    End Function

    '=========  6) “Print” button → actually save .txt  =========
    Private Sub btnPrintReceipt_Click(sender As Object, e As EventArgs) Handles btnPrintReceipt.Click
        Try
            Dim txt As String = BuildReceiptText()
            Dim savedPath As String = SaveReceiptToTxt(txt)

            MessageBox.Show("Receipt saved to:" & vbCrLf & savedPath,
                            "Receipt Saved",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            ' Optional: open immediately in Notepad
            'Process.Start("notepad.exe", savedPath)

        Catch ex As Exception
            MessageBox.Show("Error saving receipt: " & ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub
End Class
