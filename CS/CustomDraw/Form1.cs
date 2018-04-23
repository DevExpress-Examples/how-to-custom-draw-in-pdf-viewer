using DevExpress.Pdf;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomDraw {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
            pdfViewer1.MouseDown += pdfViewer1_MouseDown;
            pdfViewer1.MouseMove += pdfViewer1_MouseMove;
            pdfViewer1.MouseUp += pdfViewer1_MouseUp;
            pdfViewer1.Paint += pdfViewer1_Paint;
        }

        bool mouseButtonPressed = false;
        PdfDocumentPosition startPosition;
        PdfDocumentPosition endPosition;

        void pdfViewer1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                startPosition = pdfViewer1.GetDocumentPosition(e.Location);
                endPosition = null;
                mouseButtonPressed = true;
                pdfViewer1.Invalidate();
            }
        }

        void pdfViewer1_MouseMove(object sender, MouseEventArgs e) {
            if (mouseButtonPressed) {
                endPosition = pdfViewer1.GetDocumentPosition(e.Location);
                pdfViewer1.Invalidate();
            }
        }

        void pdfViewer1_MouseUp(object sender, MouseEventArgs e) {
            mouseButtonPressed = false;
        }

        void pdfViewer1_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.DrawRectangle(Pens.Red, new Rectangle(150, 150, 800, 50));

            if (startPosition != null && endPosition != null) {
                PointF startPoint = pdfViewer1.GetClientPoint(startPosition);
                PointF endPoint = pdfViewer1.GetClientPoint(endPosition);

                g.FillRectangle(new SolidBrush(Color.FromArgb(128, Color.Aqua)),
                    RectangleF.FromLTRB(Math.Min(startPoint.X, endPoint.X), Math.Min(startPoint.Y, endPoint.Y),
                    Math.Max(startPoint.X, endPoint.X), Math.Max(startPoint.Y, endPoint.Y)));
            }
        }
    }
}
