<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128595721/15.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T328482)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/CustomDraw/Form1.cs) (VB: [Form1.vb](./VB/CustomDraw/Form1.vb))
<!-- default file list end -->
# How to custom draw in  PDF Viewer


The [PDF Viewer control](https://www.devexpress.com/products/net/controls/winforms/pdf-viewer/) can draw graphics in the PDF document in the <strong>Control.Paint</strong> event handler. <br><br>In this example, the filled rectangle is drawn at any document space when you hold down the left mouse button and move it. 


<h3>Description</h3>

The PDF Viewer gets the mouse position relative to the PDF Viewer by calling the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraPdfViewerPdfViewer_GetDocumentPositiontopic">PdfViewer.GetDocumentPosition</a> method in the <strong>MouseDown</strong> (when the left mouse is pressed), and&nbsp; <strong>MouseMove</strong> event handlers (when the mouse is moving). <br><br>To draw a filled rectangle in the PDF document, the<strong> RectangleF.FromLTRB</strong> method is called in the Paint event handler. The start and end client points are obtained using the document position in the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraPdfViewerPdfViewer_GetClientPointtopic">PdfViewer.GetClientPoint</a> method.

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-custom-draw-in-pdf-viewer&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-custom-draw-in-pdf-viewer&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
