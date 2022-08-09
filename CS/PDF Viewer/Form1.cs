using DevExpress.Pdf;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraPdfViewer;
using DevExpress.XtraPdfViewer.Commands;
using DevExpress.XtraPdfViewer.Localization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PDF_Viewer
{
    public partial class Form1 : RibbonForm
    {
        #region SaveAsCommand
        class CustomSaveAsCommand : PdfSaveAsFileCommand
        {
            readonly IList<GraphicsCoordinates> rectangles;

            public CustomSaveAsCommand(PdfViewer control, IList<GraphicsCoordinates> rectangles) : base(control)
            {
                this.rectangles = rectangles;
            }
            public override void Execute()
            {

                if (rectangles == null || rectangles.Count == 0)
                {
                    base.Execute();
                    return;
                }
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.OverwritePrompt = true;
                    saveFileDialog.Filter = XtraPdfViewerLocalizer.GetString(XtraPdfViewerStringId.PDFFileFilter);
                    if (saveFileDialog.ShowDialog() != DialogResult.OK)
                        return;
                    using (PdfDocumentProcessor processor = new PdfDocumentProcessor())
                    {
                        processor.LoadDocument(Control.DocumentFilePath);
                        foreach (var rect in rectangles)
                        {
                            using (PdfGraphics graph = processor.CreateGraphics())
                            {
                                PdfPage page = processor.Document.Pages[rect.PageIndex];
                                PdfRectangle pageCropBox = page.CropBox;
                                PdfPoint p1 = new PdfPoint(rect.Point1.X, pageCropBox.Height - rect.Point1.Y);
                                PdfPoint p2 = new PdfPoint(rect.Point2.X, pageCropBox.Height - rect.Point2.Y);
                                RectangleF bounds = RectangleF.FromLTRB(
                                    (float)Math.Min(p1.X, p2.X), (float)Math.Min(p1.Y, p2.Y),
                                    (float)Math.Max(p1.X, p2.X), (float)Math.Max(p1.Y, p2.Y));
                                graph.DrawRectangle(new Pen(Color.Red), bounds);
                                graph.AddToPageForeground(page, 72, 72);
                            }
                        }
                        processor.SaveDocument(saveFileDialog.FileName);
                    }
                }
            }
        }


        class CustomCommandService : IPdfViewerCommandFactoryService
        {
            readonly PdfViewer viewer;
            readonly IPdfViewerCommandFactoryService service;

            public IList<GraphicsCoordinates> Rectangles { get; set; }

            public CustomCommandService(IPdfViewerCommandFactoryService service, PdfViewer viewer)
            {
                this.viewer = viewer;
                this.service = service;
            }
            public PdfViewerCommand CreateCommand(PdfViewerCommandId commandId)
            {
                if (commandId == PdfViewerCommandId.SaveAsFile)
                    return new CustomSaveAsCommand(viewer, Rectangles);
                return service.CreateCommand(commandId);
            }
        }
        #endregion SaveAsCommand

        #region GraphicsCoordinates

        // This class is used to save
        // and restore the selection area coordinates
        class GraphicsCoordinates
        {
            public GraphicsCoordinates(int pageIndex, PdfPoint point1, PdfPoint point2) {
                PageIndex = pageIndex;
                Point1 = point1;
                Point2 = point2;
            }

            public int PageIndex { get; }
            public PdfPoint Point1 { get; }
            public PdfPoint Point2 { get; }
            public bool IsEmpty => Point1 == Point2;
        }

        List<GraphicsCoordinates> rectangleCoordinateList = new List<GraphicsCoordinates>();
        GraphicsCoordinates currentCoordinates;

        // This variable indicates whether the Drawing button
        // is activated
        bool ActivateDrawing = false;
        #endregion GraphicsCoordinates

        CustomCommandService commandService;

        public Form1() {
            InitializeComponent();
            pdfViewer.LoadDocument("Demo.pdf");
            pdfViewer.MouseDown += pdfViewer1_MouseDown;
            pdfViewer.MouseUp += pdfViewer1_MouseUp;
            pdfViewer.MouseMove += PdfViewer_MouseMove;
            pdfViewer.Paint += PdfViewer_Paint;
            pdfViewer.CursorMode = PdfCursorMode.Custom;
            pdfViewer.MouseWheel += PdfViewer_MouseWheel;

            var service = pdfViewer.GetService<IPdfViewerCommandFactoryService>();
            pdfViewer.RemoveService(typeof(IPdfViewerCommandFactoryService));
            commandService = new CustomCommandService(service, pdfViewer);
            commandService.Rectangles = rectangleCoordinateList;
            pdfViewer.AddService(typeof(IPdfViewerCommandFactoryService), commandService);
        }

        void PdfViewer_MouseWheel(object sender, MouseEventArgs e) {
            if (ModifierKeys == Keys.Control)
                pdfViewer.ZoomFactor += e.Delta / 100;
            else
                pdfViewer.ScrollVertical(-e.Delta);
        }

        #region MouseEvents
        void PdfViewer_MouseMove(object sender, MouseEventArgs e) {
            if (currentCoordinates != null) {
                UpdateCurrentRect(e.Location);
                pdfViewer.Invalidate();
            }
        }
        void pdfViewer1_MouseUp(object sender, MouseEventArgs e) {

            // Convert the retrieved coordinates 
            // to the page coordinates
            UpdateCurrentRect(e.Location);
            if (currentCoordinates != null) {
                if (!currentCoordinates.IsEmpty && ActivateDrawing)
                    // Add coordinates to the list
                    rectangleCoordinateList.Add(currentCoordinates);
                currentCoordinates = null;
            }
        }
        void pdfViewer1_MouseDown(object sender, MouseEventArgs e) {
            var position = pdfViewer.GetDocumentPosition(e.Location, true);
            currentCoordinates = new GraphicsCoordinates(position.PageNumber - 1, position.Point, position.Point);
        }

        void UpdateCurrentRect(Point location)
        {
            if (rectangleCoordinateList != null)
            {
                var documentPosition = pdfViewer.GetDocumentPosition(location, true);
                if (currentCoordinates.PageIndex == documentPosition.PageNumber - 1)
                    
                    currentCoordinates = new GraphicsCoordinates(currentCoordinates.PageIndex, currentCoordinates.Point1, documentPosition.Point);
            }
        }
        #endregion MouseEvents

        #region ActivateDrawing
        private void activateDrawingButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Changle the activation indicator
            ActivateDrawing = !ActivateDrawing;
            pdfViewer.Invalidate();
        }

        void PdfViewer_Paint(object sender, PaintEventArgs e) {
            if (ActivateDrawing)
            {
                foreach (var r in rectangleCoordinateList)
                    DrawImageRectangle(e.Graphics, r);
                if (currentCoordinates != null)
                    DrawImageRectangle(e.Graphics, currentCoordinates);
            }
        }

        void DrawImageRectangle(Graphics graphics, GraphicsCoordinates rect)
        {            
            PointF start = pdfViewer.GetClientPoint(new PdfDocumentPosition(rect.PageIndex + 1, rect.Point1));
            PointF end = pdfViewer.GetClientPoint(new PdfDocumentPosition(rect.PageIndex + 1, rect.Point2));
            // Create a rectangle where graphics should be drawn
            var r = Rectangle.FromLTRB((int)Math.Min(start.X, end.X), (int)Math.Min(start.Y, end.Y), (int)Math.Max(start.X, end.X), (int)Math.Max(start.Y, end.Y));
            
            // Draw a rectangle in the created area
            graphics.DrawRectangle(new Pen(Color.Red), r);
        }
        #endregion ActivateDrawing

        #region SaveGrahpics

        private void saveGraphicsButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveDrawingAndReload();
        }

        private void SaveDrawingAndReload()
        {
            string fileName = pdfViewer.DocumentFilePath;
            pdfViewer.CloseDocument();
            using (PdfDocumentProcessor processor = new PdfDocumentProcessor())
            {
                // Load a document to the PdfDocumentProcessor instance
                processor.LoadDocument(fileName);
                foreach (var rect in rectangleCoordinateList)
                {
                    // Create a PdfGraphics object
                    using (PdfGraphics graph = processor.CreateGraphics())
                    {
                        PdfPage page = processor.Document.Pages[rect.PageIndex];
                        PdfRectangle pageCropBox = page.CropBox;
                        PdfPoint p1 = new PdfPoint(rect.Point1.X, pageCropBox.Height - rect.Point1.Y);
                        PdfPoint p2 = new PdfPoint(rect.Point2.X, pageCropBox.Height - rect.Point2.Y);

                        // Create a rectangle where graphics should be drawn
                        RectangleF bounds = RectangleF.FromLTRB(
                            (float)Math.Min(p1.X, p2.X), (float)Math.Min(p1.Y, p2.Y),
                            (float)Math.Max(p1.X, p2.X), (float)Math.Max(p1.Y, p2.Y));
                        // Draw a rectangle in the created area
                        graph.DrawRectangle(new Pen(Color.Red), bounds);
                        
                        // Draw graphics content into a file
                        graph.AddToPageForeground(page, 72, 72);
                    }
                }
                // Save the document
                processor.SaveDocument(fileName);
            }
            rectangleCoordinateList.Clear();

            // Open the document in the PDF Viewer
            pdfViewer.LoadDocument(fileName);
        }
        #endregion SaveGraphics
    }
}
