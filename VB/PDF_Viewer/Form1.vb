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

#Region "SaveAsCommand"
        Private Class CustomSaveAsCommand
            Inherits PdfSaveAsFileCommand

            Private ReadOnly rectangles As IList(Of GraphicsCoordinates)

            Public Sub New(ByVal control As PdfViewer, ByVal rectangles As IList(Of GraphicsCoordinates))
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

            Public Property Rectangles As IList(Of GraphicsCoordinates)

            Public Sub New(ByVal service As IPdfViewerCommandFactoryService, ByVal viewer As PdfViewer)
                Me.viewer = viewer
                Me.service = service
            End Sub

            Public Function CreateCommand(ByVal commandId As PdfViewerCommandId) As PdfViewerCommand Implements IPdfViewerCommandFactoryService.CreateCommand
                If commandId = PdfViewerCommandId.SaveAsFile Then Return New CustomSaveAsCommand(viewer, Rectangles)
                Return service.CreateCommand(commandId)
            End Function
        End Class

#End Region  ' SaveAsCommand
#Region "GraphicsCoordinates"
        ' This class is used to save
        ' and restore the selection area coordinates
        Private Class GraphicsCoordinates

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

        Private rectangleCoordinateList As List(Of GraphicsCoordinates) = New List(Of GraphicsCoordinates)()

        Private currentCoordinates As GraphicsCoordinates

        ' This variable indicates whether the Drawing button
        ' is activated
        Private ActivateDrawing As Boolean = False

#End Region  ' GraphicsCoordinates
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
            commandService.Rectangles = rectangleCoordinateList
            pdfViewer.AddService(GetType(IPdfViewerCommandFactoryService), commandService)
        End Sub

        Private Sub PdfViewer_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
            If ModifierKeys = Keys.Control Then
                pdfViewer.ZoomFactor += e.Delta \ 100
            Else
                pdfViewer.ScrollVertical(-e.Delta)
            End If
        End Sub

#Region "MouseEvents"
        Private Sub PdfViewer_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            If currentCoordinates IsNot Nothing Then
                UpdateCurrentRect(e.Location)
                pdfViewer.Invalidate()
            End If
        End Sub

        Private Sub pdfViewer1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
            ' Convert the retrieved coordinates 
            ' to the page coordinates
            UpdateCurrentRect(e.Location)
            If currentCoordinates IsNot Nothing Then
                ' Add coordinates to the list
                If Not currentCoordinates.IsEmpty AndAlso ActivateDrawing Then rectangleCoordinateList.Add(currentCoordinates)
                currentCoordinates = Nothing
            End If
        End Sub

        Private Sub pdfViewer1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim position = pdfViewer.GetDocumentPosition(e.Location, True)
            currentCoordinates = New GraphicsCoordinates(position.PageNumber - 1, position.Point, position.Point)
        End Sub

        Private Sub UpdateCurrentRect(ByVal location As Point)
            If rectangleCoordinateList IsNot Nothing Then
                Dim documentPosition = pdfViewer.GetDocumentPosition(location, True)
                If currentCoordinates.PageIndex = documentPosition.PageNumber - 1 Then currentCoordinates = New GraphicsCoordinates(currentCoordinates.PageIndex, currentCoordinates.Point1, documentPosition.Point)
            End If
        End Sub

#End Region  ' MouseEvents
#Region "ActivateDrawing"
        Private Sub activateDrawingButton_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
            ' Change the activation indicator
            ActivateDrawing = Not ActivateDrawing
            pdfViewer.Invalidate()
        End Sub

        Private Sub PdfViewer_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
            If ActivateDrawing Then
                For Each r In rectangleCoordinateList
                    DrawImageRectangle(e.Graphics, r)
                Next

                If currentCoordinates IsNot Nothing Then DrawImageRectangle(e.Graphics, currentCoordinates)
            End If
        End Sub

        Private Sub DrawImageRectangle(ByVal graphics As Graphics, ByVal rect As GraphicsCoordinates)
            Dim start As PointF = pdfViewer.GetClientPoint(New PdfDocumentPosition(rect.PageIndex + 1, rect.Point1))
            Dim [end] As PointF = pdfViewer.GetClientPoint(New PdfDocumentPosition(rect.PageIndex + 1, rect.Point2))
            ' Create a rectangle where graphics should be drawn
            Dim r = Rectangle.FromLTRB(CInt(Math.Min(start.X, [end].X)), CInt(Math.Min(start.Y, [end].Y)), CInt(Math.Max(start.X, [end].X)), CInt(Math.Max(start.Y, [end].Y)))
            ' Draw a rectangle in the created area
            graphics.DrawRectangle(New Pen(Color.Red), r)
        End Sub

#End Region  ' ActivateDrawing
#Region "SaveGraphics"
        Private Sub saveGraphicsButton_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
            SaveDrawingAndReload()
        End Sub

        Private Sub SaveDrawingAndReload()
            Dim fileName As String = pdfViewer.DocumentFilePath
            pdfViewer.CloseDocument()
            Using processor As PdfDocumentProcessor = New PdfDocumentProcessor()
                ' Load a document to the PdfDocumentProcessor instance
                processor.LoadDocument(fileName)
                For Each rect In rectangleCoordinateList
                    ' Create a PdfGraphics object
                    Using graph As PdfGraphics = processor.CreateGraphics()
                        Dim page As PdfPage = processor.Document.Pages(rect.PageIndex)
                        Dim pageCropBox As PdfRectangle = page.CropBox
                        Dim p1 As PdfPoint = New PdfPoint(rect.Point1.X, pageCropBox.Height - rect.Point1.Y)
                        Dim p2 As PdfPoint = New PdfPoint(rect.Point2.X, pageCropBox.Height - rect.Point2.Y)
                        ' Create a rectangle where graphics should be drawn
                        Dim bounds As RectangleF = RectangleF.FromLTRB(CSng(Math.Min(p1.X, p2.X)), CSng(Math.Min(p1.Y, p2.Y)), CSng(Math.Max(p1.X, p2.X)), CSng(Math.Max(p1.Y, p2.Y)))
                        ' Draw a rectangle in the created area
                        graph.DrawRectangle(New Pen(Color.Red), bounds)
                        ' Draw graphics content into a file
                        graph.AddToPageForeground(page, 72, 72)
                    End Using
                Next

                ' Save the document
                processor.SaveDocument(fileName)
            End Using

            rectangleCoordinateList.Clear()
            ' Open the document in the PDF Viewer
            pdfViewer.LoadDocument(fileName)
        End Sub
#End Region  ' SaveGraphics
    End Class
End Namespace
