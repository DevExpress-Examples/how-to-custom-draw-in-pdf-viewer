Imports DevExpress.Pdf
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace CustomDraw
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
			AddHandler pdfViewer1.MouseDown, AddressOf pdfViewer1_MouseDown
			AddHandler pdfViewer1.MouseMove, AddressOf pdfViewer1_MouseMove
			AddHandler pdfViewer1.MouseUp, AddressOf pdfViewer1_MouseUp
			AddHandler pdfViewer1.Paint, AddressOf pdfViewer1_Paint
		End Sub

		Private mouseButtonPressed As Boolean = False
'INSTANT VB NOTE: The field startPosition was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private startPosition_Conflict As PdfDocumentPosition
		Private endPosition As PdfDocumentPosition

		Private Sub pdfViewer1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
			If e.Button = MouseButtons.Left Then
				startPosition_Conflict = pdfViewer1.GetDocumentPosition(e.Location)
				endPosition = Nothing
				mouseButtonPressed = True
				pdfViewer1.Invalidate()
			End If
		End Sub

		Private Sub pdfViewer1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			If mouseButtonPressed Then
				endPosition = pdfViewer1.GetDocumentPosition(e.Location)
				pdfViewer1.Invalidate()
			End If
		End Sub

		Private Sub pdfViewer1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
			mouseButtonPressed = False
		End Sub

		Private Sub pdfViewer1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
			Dim g As Graphics = e.Graphics
			g.DrawRectangle(Pens.Red, New Rectangle(150, 150, 800, 50))

			If startPosition_Conflict IsNot Nothing AndAlso endPosition IsNot Nothing Then
				Dim startPoint As PointF = pdfViewer1.GetClientPoint(startPosition_Conflict)
				Dim endPoint As PointF = pdfViewer1.GetClientPoint(endPosition)

				Using blueBrush As New SolidBrush(Color.FromArgb(128, Color.Aqua))
					g.FillRectangle(blueBrush, RectangleF.FromLTRB(Math.Min(startPoint.X, endPoint.X), Math.Min(startPoint.Y, endPoint.Y), Math.Max(startPoint.X, endPoint.X), Math.Max(startPoint.Y, endPoint.Y)))
				End Using
			End If
		End Sub
	End Class
End Namespace
