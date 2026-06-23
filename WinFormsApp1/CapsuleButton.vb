Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class CapsuleButton
    Inherits Button

    Private _borderRadius As Integer = 20
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Me.Invalidate()
        End Set
    End Property

    Private _buttonColor As Color = Color.DodgerBlue
    Public Property ButtonColor As Color
        Get
            Return _buttonColor
        End Get
        Set(value As Color)
            _buttonColor = value
            Me.Invalidate()
        End Set
    End Property

    Private _borderColor As Color = Color.FromArgb(0, 100, 200)
    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Me.Invalidate()
        End Set
    End Property

    Private _borderThickness As Integer = 2
    Public Property BorderThickness As Integer
        Get
            Return _borderThickness
        End Get
        Set(value As Integer)
            _borderThickness = value
            Me.Invalidate()
        End Set
    End Property

    Public Sub New()
        Me.FlatStyle = FlatStyle.Flat
        Me.FlatAppearance.BorderSize = 0
        Me.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 70, 150)
        Me.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 120, 255)
        Me.Text = "Capsule Button"
        Me.ForeColor = Color.White
        Me.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        Me.Size = New Size(150, 45)
        Me.BackColor = Color.Transparent
    End Sub

    Protected Overrides Sub OnPaintBackground(pevent As PaintEventArgs)
        ' Do not call MyBase.OnPaintBackground(pevent)
    End Sub

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        If Me.IsDisposed Then Return

        MyBase.OnPaint(pe)

        Dim graphics As Graphics = pe.Graphics
        graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)

        Dim borderAdjustedRect As New Rectangle(
            Me.BorderThickness \ 2,
            Me.BorderThickness \ 2,
            Me.Width - Me.BorderThickness,
            Me.Height - Me.BorderThickness
        )

        Using path As New GraphicsPath()
            Dim diameter As Integer = Me.BorderRadius * 2
            If diameter > borderAdjustedRect.Height Then diameter = borderAdjustedRect.Height

            Dim arcRect As New Rectangle(borderAdjustedRect.X, borderAdjustedRect.Y, diameter, diameter)

            path.AddArc(arcRect, 180, 90)
            path.AddLine(borderAdjustedRect.X + diameter, borderAdjustedRect.Y, borderAdjustedRect.Right - diameter, borderAdjustedRect.Y)
            arcRect.X = borderAdjustedRect.Right - diameter
            path.AddArc(arcRect, 270, 90)
            path.AddLine(borderAdjustedRect.Right, borderAdjustedRect.Y + diameter, borderAdjustedRect.Right, borderAdjustedRect.Bottom - diameter)
            arcRect.Y = borderAdjustedRect.Bottom - diameter
            path.AddArc(arcRect, 0, 90)
            path.AddLine(borderAdjustedRect.Right - diameter, borderAdjustedRect.Bottom, borderAdjustedRect.X + diameter, borderAdjustedRect.Bottom)
            arcRect.X = borderAdjustedRect.X
            path.AddArc(arcRect, 90, 90)
            path.AddLine(borderAdjustedRect.X, borderAdjustedRect.Bottom - diameter, borderAdjustedRect.X, borderAdjustedRect.Y + diameter)

            path.CloseFigure()

            Using brush As New SolidBrush(Me.ButtonColor)
                graphics.FillPath(brush, path)
            End Using

            Using pen As New Pen(Me.BorderColor, Me.BorderThickness)
                graphics.DrawPath(pen, path)
            End Using
        End Using

        TextRenderer.DrawText(graphics, Me.Text, Me.Font, rect, Me.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        If Me.IsDisposed Then Return

        MyBase.OnResize(e)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        If Me.IsDisposed Then Return

        MyBase.OnMouseEnter(e)
        Try ' Added Try...Catch block
            If Me.ClientRectangle.Contains(Me.PointToClient(Cursor.Position)) Then
                Me.ButtonColor = Me.FlatAppearance.MouseOverBackColor
                Me.Invalidate()
            End If
        Catch ex As ObjectDisposedException
            ' Log the exception if necessary, but do nothing else to prevent crash
            System.Diagnostics.Debug.WriteLine("CapsuleButton OnMouseEnter: Object disposed during PointToClient. " & ex.Message)
        End Try
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        If Me.IsDisposed Then Return

        MyBase.OnMouseLeave(e)
        Me.ButtonColor = Color.DodgerBlue
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If Me.IsDisposed Then Return

        MyBase.OnMouseDown(e)
        Try ' Added Try...Catch block
            If Me.ClientRectangle.Contains(Me.PointToClient(Cursor.Position)) Then
                Me.ButtonColor = Me.FlatAppearance.MouseDownBackColor
                Me.Invalidate()
            End If
        Catch ex As ObjectDisposedException
            ' Log the exception if necessary, but do nothing else to prevent crash
            System.Diagnostics.Debug.WriteLine("CapsuleButton OnMouseDown: Object disposed during PointToClient. " & ex.Message)
        End Try
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        If Me.IsDisposed Then Return

        MyBase.OnMouseUp(e)
        Try ' Added Try...Catch block
            If Me.ClientRectangle.Contains(Me.PointToClient(Cursor.Position)) Then
                Me.ButtonColor = Me.FlatAppearance.MouseOverBackColor
            Else
                Me.ButtonColor = Color.DodgerBlue
            End If
            Me.Invalidate()
        Catch ex As ObjectDisposedException
            ' Log the exception if necessary, but do nothing else to prevent crash
            System.Diagnostics.Debug.WriteLine("CapsuleButton OnMouseUp: Object disposed during PointToClient. " & ex.Message)
        End Try
    End Sub

End Class
