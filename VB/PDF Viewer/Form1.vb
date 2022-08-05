Imports DevExpress.Pdf
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraPdfViewer
Imports DevExpress.XtraPdfViewer.Commands
Imports DevExpress.XtraPdfViewer.Localization
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms

Namespace PDF_Viewer

    Public Partial Class Form1
        Inherits RibbonForm

        Private Class CustomSaveAsCommand
            Inherits PdfSaveAsFileCommand

            Private ReadOnly rectangles As IList(Of GraphicsRect)

            Public Sub New(ByVal control As PdfViewer, ByVal rectangles As IList(Of GraphicsRect))
                MyBase.New(control)
                Me.rectangles = rectangles
            End Sub

            Public Overrides Sub Execute()
                If rectangles Is Nothing OrElse rectangles.Count = 0 Then
                    MyBase.Execute()
                    Return
                End If

                Using saveFileDialog As SaveFileDialog = New SaveFileDialog()
                    saveFileDialog.OverwritePrompt = True
                    saveFileDialog.Filter = XtraPdfViewerLocalizer.GetString(XtraPdfViewerStringId.PDFFileFilter)
                    If saveFileDialog.ShowDialog() <> DialogResult.OK Then Return
                    Using processor As PdfDocumentProcessor = New PdfDocumentProcessor()
                        processor.LoadDocument(Control.DocumentFilePath)
                        For Each rect In rectangles
                            Using graph As PdfGraphics = processor.CreateGraphics()
                                Dim page As PdfPage = processor.Document.Pages(rect.PageIndex)
                                Dim pageCropBox As PdfRectangle = page.CropBox
                                Dim p1 As PdfPoint = New PdfPoint(rect.Point1.X, pageCropBox.Height - rect.Point1.Y)
                                Dim p2 As PdfPoint = New PdfPoint(rect.Point2.X, pageCropBox.Height - rect.Point2.Y)
                                Dim bounds As RectangleF = RectangleF.FromLTRB(CSng(Math.Min(p1.X, p2.X)), CSng(Math.Min(p1.Y, p2.Y)), CSng(Math.Max(p1.X, p2.X)), CSng(Math.Max(p1.Y, p2.Y)))
                                graph.DrawRectangle(New Pen(Color.Red), bounds)
                                graph.AddToPageForeground(page, 72, 72)
                            End Using
                        Next

                        processor.SaveDocument(saveFileDialog.FileName)
                    End Using
                End Using
            End Sub
        End Class

        Private Class CustomCommandService
            Implements IPdfViewerCommandFactoryService

            Private ReadOnly viewer As PdfViewer

            Private ReadOnly service As IPdfViewerCommandFactoryService

            Public Property Rectangles As IList(Of GraphicsRect)

            Public Sub New(ByVal service As IPdfViewerCommandFactoryService, ByVal viewer As PdfViewer)
                Me.viewer = viewer
                Me.service = service
            End Sub

            Public Function CreateCommand(ByVal commandId As PdfViewerCommandId) As PdfViewerCommand Implements IPdfViewerCommandFactoryService.CreateCommand
                If commandId = PdfViewerCommandId.SaveAsFile Then Return New CustomSaveAsCommand(viewer, Rectangles)
                Return service.CreateCommand(commandId)
            End Function
        End Class

        Private Class GraphicsRect

            Public Sub New(ByVal pageIndex As Integer, ByVal point1 As PdfPoint, ByVal point2 As PdfPoint)
                Me.PageIndex = pageIndex
                Me.Point1 = point1
                Me.Point2 = point2
            End Sub

            Public ReadOnly Property PageIndex As Integer

            Public ReadOnly Property Point1 As PdfPoint

            Public ReadOnly Property Point2 As PdfPoint

            Public ReadOnly Property IsEmpty As Boolean
                Get
                    Return Point1 = Point2
                End Get
            End Property
        End Class

        Private imageRectangleList As List(Of GraphicsRect) = New List(Of GraphicsRect)()

        Private currentImageRect As GraphicsRect

        Private ActivateDrawing As Boolean = False

        Private commandService As CustomCommandService

        Public Sub New()
            InitializeComponent()
            pdfViewer.LoadDocument("Demo.pdf")
            AddHandler pdfViewer.MouseDown, AddressOf pdfViewer1_MouseDown
            AddHandler pdfViewer.MouseUp, AddressOf pdfViewer1_MouseUp
            AddHandler pdfViewer.MouseMove, AddressOf PdfViewer_MouseMove
            AddHandler pdfViewer.Paint, AddressOf PdfViewer_Paint
            pdfViewer.CursorMode = PdfCursorMode.Custom
            AddHandler pdfViewer.MouseWheel, AddressOf PdfViewer_MouseWheel
            Dim service = pdfViewer.GetService(Of IPdfViewerCommandFactoryService)()
            pdfViewer.RemoveService(GetType(IPdfViewerCommandFactoryService))
            commandService = New CustomCommandService(service, pdfViewer)
            commandService.Rectangles = imageRectangleList
            pdfViewer.AddService(GetType(IPdfViewerCommandFactoryService), commandService)
        End Sub

        Private Sub PdfViewer_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
            If ModifierKeys = Keys.Control Then
                pdfViewer.ZoomFactor += e.Delta \ 100
            Else
                pdfViewer.ScrollVertical(-e.Delta)
            End If
        End Sub

        Private Sub UpdateCurrentRect(ByVal location As Point)
            If currentImageRect IsNot Nothing Then
                Dim documentPosition = pdfViewer.GetDocumentPosition(location, True)
                If currentImageRect.PageIndex = documentPosition.PageNumber - 1 Then currentImageRect = New GraphicsRect(currentImageRect.PageIndex, currentImageRect.Point1, documentPosition.Point)
            End If
        End Sub

        Private Sub PdfViewer_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            If currentImageRect IsNot Nothing Then
                UpdateCurrentRect(e.Location)
                pdfViewer.Invalidate()
            End If
        End Sub

        Private Sub pdfViewer1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
            UpdateCurrentRect(e.Location)
            If currentImageRect IsNot Nothing Then
                If Not currentImageRect.IsEmpty AndAlso ActivateDrawing Then imageRectangleList.Add(currentImageRect)
                currentImageRect = Nothing
            End If
        End Sub

        Private Sub pdfViewer1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim position = pdfViewer.GetDocumentPosition(e.Location, True)
            currentImageRect = New GraphicsRect(position.PageNumber - 1, position.Point, position.Point)
        End Sub

        Private Sub DrawImageRectangle(ByVal graphics As Graphics, ByVal rect As GraphicsRect)
            Dim start As PointF = pdfViewer.GetClientPoint(New PdfDocumentPosition(rect.PageIndex + 1, rect.Point1))
            Dim [end] As PointF = pdfViewer.GetClientPoint(New PdfDocumentPosition(rect.PageIndex + 1, rect.Point2))
            Dim r = Rectangle.FromLTRB(CInt(Math.Min(start.X, [end].X)), CInt(Math.Min(start.Y, [end].Y)), CInt(Math.Max(start.X, [end].X)), CInt(Math.Max(start.Y, [end].Y)))
            graphics.DrawRectangle(New Pen(Color.Red), r)
        End Sub

        Private Sub PdfViewer_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
            If ActivateDrawing Then
                For Each r In imageRectangleList
                    DrawImageRectangle(e.Graphics, r)
                Next

                If currentImageRect IsNot Nothing Then DrawImageRectangle(e.Graphics, currentImageRect)
            End If
        End Sub

        Private Sub SaveDrawingAndReload()
            Dim fileName As String = pdfViewer.DocumentFilePath
            pdfViewer.CloseDocument()
            Using processor As PdfDocumentProcessor = New PdfDocumentProcessor()
                processor.LoadDocument(fileName)
                For Each rect In imageRectangleList
                    Using graph As PdfGraphics = processor.CreateGraphics()
                        Dim page As PdfPage = processor.Document.Pages(rect.PageIndex)
                        Dim pageCropBox As PdfRectangle = page.CropBox
                        Dim p1 As PdfPoint = New PdfPoint(rect.Point1.X, pageCropBox.Height - rect.Point1.Y)
                        Dim p2 As PdfPoint = New PdfPoint(rect.Point2.X, pageCropBox.Height - rect.Point2.Y)
                        Dim bounds As RectangleF = RectangleF.FromLTRB(CSng(Math.Min(p1.X, p2.X)), CSng(Math.Min(p1.Y, p2.Y)), CSng(Math.Max(p1.X, p2.X)), CSng(Math.Max(p1.Y, p2.Y)))
                        graph.DrawRectangle(New Pen(Color.Red), bounds)
                        graph.AddToPageForeground(page, 72, 72)
                    End Using
                Next

                processor.SaveDocument(fileName)
            End Using

            imageRectangleList.Clear()
            pdfViewer.LoadDocument(fileName)
        End Sub

        Private Sub barButtonItem2_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
            ActivateDrawing = Not ActivateDrawing
            pdfViewer.Invalidate()
        End Sub

        Private Sub barButtonItem3_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
            SaveDrawingAndReload()
        End Sub
    End Class
End Namespace
