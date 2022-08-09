Namespace PDF_Viewer

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PDF_Viewer.Form1))
            Me.pdfViewer = New DevExpress.XtraPdfViewer.PdfViewer()
            Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
            Me.pdfFileOpenBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfFileOpenBarItem()
            Me.pdfFileSaveAsBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfFileSaveAsBarItem()
            Me.pdfFilePrintBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfFilePrintBarItem()
            Me.pdfFindTextBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfFindTextBarItem()
            Me.pdfPreviousPageBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfPreviousPageBarItem()
            Me.pdfNextPageBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfNextPageBarItem()
            Me.pdfSetPageNumberBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfSetPageNumberBarItem()
            Me.repositoryItemPageNumberEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPageNumberEdit()
            Me.pdfZoomOutBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoomOutBarItem()
            Me.pdfZoomInBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoomInBarItem()
            Me.pdfExactZoomListBarSubItem1 = New DevExpress.XtraPdfViewer.Bars.PdfExactZoomListBarSubItem()
            Me.pdfZoom10CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom10CheckItem()
            Me.pdfZoom25CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom25CheckItem()
            Me.pdfZoom50CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom50CheckItem()
            Me.pdfZoom75CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom75CheckItem()
            Me.pdfZoom100CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom100CheckItem()
            Me.pdfZoom125CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom125CheckItem()
            Me.pdfZoom150CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom150CheckItem()
            Me.pdfZoom200CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom200CheckItem()
            Me.pdfZoom400CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom400CheckItem()
            Me.pdfZoom500CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom500CheckItem()
            Me.pdfSetActualSizeZoomModeCheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfSetActualSizeZoomModeCheckItem()
            Me.pdfSetPageLevelZoomModeCheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfSetPageLevelZoomModeCheckItem()
            Me.pdfSetFitWidthZoomModeCheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfSetFitWidthZoomModeCheckItem()
            Me.pdfSetFitVisibleZoomModeCheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfSetFitVisibleZoomModeCheckItem()
            Me.pdfTextHighlightBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfTextHighlightBarItem()
            Me.pdfTextStrikethroughBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfTextStrikethroughBarItem()
            Me.pdfTextUnderlineBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfTextUnderlineBarItem()
            Me.pdfStickyNoteBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfStickyNoteBarItem()
            Me.pdfExportFormDataBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfExportFormDataBarItem()
            Me.pdfImportFormDataBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfImportFormDataBarItem()
            Me.barButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
            Me.activateDrawingButton = New DevExpress.XtraBars.BarButtonItem()
            Me.saveGraphicsButton = New DevExpress.XtraBars.BarButtonItem()
            Me.pdfRibbonPage1 = New DevExpress.XtraPdfViewer.Bars.PdfRibbonPage()
            Me.pdfFileRibbonPageGroup1 = New DevExpress.XtraPdfViewer.Bars.PdfFileRibbonPageGroup()
            Me.pdfFindRibbonPageGroup1 = New DevExpress.XtraPdfViewer.Bars.PdfFindRibbonPageGroup()
            Me.pdfNavigationRibbonPageGroup1 = New DevExpress.XtraPdfViewer.Bars.PdfNavigationRibbonPageGroup()
            Me.pdfZoomRibbonPageGroup1 = New DevExpress.XtraPdfViewer.Bars.PdfZoomRibbonPageGroup()
            Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.pdfCommentRibbonPage1 = New DevExpress.XtraPdfViewer.Bars.PdfCommentRibbonPage()
            Me.pdfTextCommentPageGroup1 = New DevExpress.XtraPdfViewer.Bars.PdfTextCommentPageGroup()
            Me.pdfNoteCommentPageGroup1 = New DevExpress.XtraPdfViewer.Bars.PdfNoteCommentPageGroup()
            Me.pdfFormDataRibbonPage1 = New DevExpress.XtraPdfViewer.Bars.PdfFormDataRibbonPage()
            Me.pdfFormDataBarPageGroup1 = New DevExpress.XtraPdfViewer.Bars.PdfFormDataBarPageGroup()
            Me.pdfBarController1 = New DevExpress.XtraPdfViewer.Bars.PdfBarController(Me.components)
            CType((Me.ribbonControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.repositoryItemPageNumberEdit1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.pdfBarController1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' pdfViewer
            ' 
            Me.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pdfViewer.Location = New System.Drawing.Point(0, 310)
            Me.pdfViewer.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
            Me.pdfViewer.MenuManager = Me.ribbonControl1
            Me.pdfViewer.Name = "pdfViewer"
            Me.pdfViewer.NavigationPaneWidth = 400
            Me.pdfViewer.Size = New System.Drawing.Size(1886, 784)
            Me.pdfViewer.TabIndex = 0
            Me.pdfViewer.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToWidth
            ' 
            ' ribbonControl1
            ' 
            Me.ribbonControl1.EmptyAreaImageOptions.ImagePadding = New System.Windows.Forms.Padding(122, 112, 122, 112)
            Me.ribbonControl1.ExpandCollapseItem.Id = 0
            Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl1.ExpandCollapseItem, Me.ribbonControl1.SearchEditItem, Me.pdfFileOpenBarItem1, Me.pdfFileSaveAsBarItem1, Me.pdfFilePrintBarItem1, Me.pdfFindTextBarItem1, Me.pdfPreviousPageBarItem1, Me.pdfNextPageBarItem1, Me.pdfSetPageNumberBarItem1, Me.pdfZoomOutBarItem1, Me.pdfZoomInBarItem1, Me.pdfExactZoomListBarSubItem1, Me.pdfZoom10CheckItem1, Me.pdfZoom25CheckItem1, Me.pdfZoom50CheckItem1, Me.pdfZoom75CheckItem1, Me.pdfZoom100CheckItem1, Me.pdfZoom125CheckItem1, Me.pdfZoom150CheckItem1, Me.pdfZoom200CheckItem1, Me.pdfZoom400CheckItem1, Me.pdfZoom500CheckItem1, Me.pdfSetActualSizeZoomModeCheckItem1, Me.pdfSetPageLevelZoomModeCheckItem1, Me.pdfSetFitWidthZoomModeCheckItem1, Me.pdfSetFitVisibleZoomModeCheckItem1, Me.pdfTextHighlightBarItem1, Me.pdfTextStrikethroughBarItem1, Me.pdfTextUnderlineBarItem1, Me.pdfStickyNoteBarItem1, Me.pdfExportFormDataBarItem1, Me.pdfImportFormDataBarItem1, Me.barButtonItem1, Me.activateDrawingButton, Me.saveGraphicsButton})
            Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
            Me.ribbonControl1.Margin = New System.Windows.Forms.Padding(14, 12, 14, 12)
            Me.ribbonControl1.MaxItemId = 37
            Me.ribbonControl1.Name = "ribbonControl1"
            Me.ribbonControl1.OptionsMenuMinWidth = 1380
            Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.pdfRibbonPage1, Me.pdfCommentRibbonPage1, Me.pdfFormDataRibbonPage1})
            Me.ribbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repositoryItemPageNumberEdit1})
            Me.ribbonControl1.Size = New System.Drawing.Size(1886, 310)
            ' 
            ' pdfFileOpenBarItem1
            ' 
            Me.pdfFileOpenBarItem1.Id = 1
            Me.pdfFileOpenBarItem1.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O))
            Me.pdfFileOpenBarItem1.Name = "pdfFileOpenBarItem1"
            ' 
            ' pdfFileSaveAsBarItem1
            ' 
            Me.pdfFileSaveAsBarItem1.Id = 2
            Me.pdfFileSaveAsBarItem1.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S))
            Me.pdfFileSaveAsBarItem1.Name = "pdfFileSaveAsBarItem1"
            ' 
            ' pdfFilePrintBarItem1
            ' 
            Me.pdfFilePrintBarItem1.Id = 3
            Me.pdfFilePrintBarItem1.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P))
            Me.pdfFilePrintBarItem1.Name = "pdfFilePrintBarItem1"
            ' 
            ' pdfFindTextBarItem1
            ' 
            Me.pdfFindTextBarItem1.Id = 4
            Me.pdfFindTextBarItem1.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F))
            Me.pdfFindTextBarItem1.Name = "pdfFindTextBarItem1"
            ' 
            ' pdfPreviousPageBarItem1
            ' 
            Me.pdfPreviousPageBarItem1.Id = 5
            Me.pdfPreviousPageBarItem1.Name = "pdfPreviousPageBarItem1"
            ' 
            ' pdfNextPageBarItem1
            ' 
            Me.pdfNextPageBarItem1.Id = 6
            Me.pdfNextPageBarItem1.Name = "pdfNextPageBarItem1"
            ' 
            ' pdfSetPageNumberBarItem1
            ' 
            Me.pdfSetPageNumberBarItem1.Edit = Me.repositoryItemPageNumberEdit1
            Me.pdfSetPageNumberBarItem1.Id = 7
            Me.pdfSetPageNumberBarItem1.Name = "pdfSetPageNumberBarItem1"
            ' 
            ' repositoryItemPageNumberEdit1
            ' 
            Me.repositoryItemPageNumberEdit1.AutoHeight = False
            Me.repositoryItemPageNumberEdit1.Mask.EditMask = "########;"
            Me.repositoryItemPageNumberEdit1.Name = "repositoryItemPageNumberEdit1"
            ' 
            ' pdfZoomOutBarItem1
            ' 
            Me.pdfZoomOutBarItem1.Id = 8
            Me.pdfZoomOutBarItem1.Name = "pdfZoomOutBarItem1"
            ' 
            ' pdfZoomInBarItem1
            ' 
            Me.pdfZoomInBarItem1.Id = 9
            Me.pdfZoomInBarItem1.Name = "pdfZoomInBarItem1"
            ' 
            ' pdfExactZoomListBarSubItem1
            ' 
            Me.pdfExactZoomListBarSubItem1.Id = 10
            Me.pdfExactZoomListBarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom10CheckItem1, True), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom25CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom50CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom75CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom100CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom125CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom150CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom200CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom400CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom500CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfSetActualSizeZoomModeCheckItem1, True), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfSetPageLevelZoomModeCheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfSetFitWidthZoomModeCheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfSetFitVisibleZoomModeCheckItem1)})
            Me.pdfExactZoomListBarSubItem1.Name = "pdfExactZoomListBarSubItem1"
            Me.pdfExactZoomListBarSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu
            ' 
            ' pdfZoom10CheckItem1
            ' 
            Me.pdfZoom10CheckItem1.Id = 11
            Me.pdfZoom10CheckItem1.Name = "pdfZoom10CheckItem1"
            ' 
            ' pdfZoom25CheckItem1
            ' 
            Me.pdfZoom25CheckItem1.Id = 12
            Me.pdfZoom25CheckItem1.Name = "pdfZoom25CheckItem1"
            ' 
            ' pdfZoom50CheckItem1
            ' 
            Me.pdfZoom50CheckItem1.Id = 13
            Me.pdfZoom50CheckItem1.Name = "pdfZoom50CheckItem1"
            ' 
            ' pdfZoom75CheckItem1
            ' 
            Me.pdfZoom75CheckItem1.Id = 14
            Me.pdfZoom75CheckItem1.Name = "pdfZoom75CheckItem1"
            ' 
            ' pdfZoom100CheckItem1
            ' 
            Me.pdfZoom100CheckItem1.Id = 15
            Me.pdfZoom100CheckItem1.Name = "pdfZoom100CheckItem1"
            ' 
            ' pdfZoom125CheckItem1
            ' 
            Me.pdfZoom125CheckItem1.Id = 16
            Me.pdfZoom125CheckItem1.Name = "pdfZoom125CheckItem1"
            ' 
            ' pdfZoom150CheckItem1
            ' 
            Me.pdfZoom150CheckItem1.Id = 17
            Me.pdfZoom150CheckItem1.Name = "pdfZoom150CheckItem1"
            ' 
            ' pdfZoom200CheckItem1
            ' 
            Me.pdfZoom200CheckItem1.Id = 18
            Me.pdfZoom200CheckItem1.Name = "pdfZoom200CheckItem1"
            ' 
            ' pdfZoom400CheckItem1
            ' 
            Me.pdfZoom400CheckItem1.Id = 19
            Me.pdfZoom400CheckItem1.Name = "pdfZoom400CheckItem1"
            ' 
            ' pdfZoom500CheckItem1
            ' 
            Me.pdfZoom500CheckItem1.Id = 20
            Me.pdfZoom500CheckItem1.Name = "pdfZoom500CheckItem1"
            ' 
            ' pdfSetActualSizeZoomModeCheckItem1
            ' 
            Me.pdfSetActualSizeZoomModeCheckItem1.Id = 21
            Me.pdfSetActualSizeZoomModeCheckItem1.Name = "pdfSetActualSizeZoomModeCheckItem1"
            ' 
            ' pdfSetPageLevelZoomModeCheckItem1
            ' 
            Me.pdfSetPageLevelZoomModeCheckItem1.Id = 22
            Me.pdfSetPageLevelZoomModeCheckItem1.Name = "pdfSetPageLevelZoomModeCheckItem1"
            ' 
            ' pdfSetFitWidthZoomModeCheckItem1
            ' 
            Me.pdfSetFitWidthZoomModeCheckItem1.Id = 23
            Me.pdfSetFitWidthZoomModeCheckItem1.Name = "pdfSetFitWidthZoomModeCheckItem1"
            ' 
            ' pdfSetFitVisibleZoomModeCheckItem1
            ' 
            Me.pdfSetFitVisibleZoomModeCheckItem1.Id = 24
            Me.pdfSetFitVisibleZoomModeCheckItem1.Name = "pdfSetFitVisibleZoomModeCheckItem1"
            ' 
            ' pdfTextHighlightBarItem1
            ' 
            Me.pdfTextHighlightBarItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown
            Me.pdfTextHighlightBarItem1.Id = 25
            Me.pdfTextHighlightBarItem1.Name = "pdfTextHighlightBarItem1"
            ' 
            ' pdfTextStrikethroughBarItem1
            ' 
            Me.pdfTextStrikethroughBarItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown
            Me.pdfTextStrikethroughBarItem1.Id = 26
            Me.pdfTextStrikethroughBarItem1.Name = "pdfTextStrikethroughBarItem1"
            ' 
            ' pdfTextUnderlineBarItem1
            ' 
            Me.pdfTextUnderlineBarItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown
            Me.pdfTextUnderlineBarItem1.Id = 27
            Me.pdfTextUnderlineBarItem1.Name = "pdfTextUnderlineBarItem1"
            ' 
            ' pdfStickyNoteBarItem1
            ' 
            Me.pdfStickyNoteBarItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown
            Me.pdfStickyNoteBarItem1.Id = 28
            Me.pdfStickyNoteBarItem1.Name = "pdfStickyNoteBarItem1"
            ' 
            ' pdfExportFormDataBarItem1
            ' 
            Me.pdfExportFormDataBarItem1.Id = 29
            Me.pdfExportFormDataBarItem1.Name = "pdfExportFormDataBarItem1"
            ' 
            ' pdfImportFormDataBarItem1
            ' 
            Me.pdfImportFormDataBarItem1.Id = 30
            Me.pdfImportFormDataBarItem1.Name = "pdfImportFormDataBarItem1"
            ' 
            ' barButtonItem1
            ' 
            Me.barButtonItem1.Id = 33
            Me.barButtonItem1.Name = "barButtonItem1"
            ' 
            ' activateDrawingButton
            ' 
            Me.activateDrawingButton.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
            Me.activateDrawingButton.Caption = "Activate Drawing"
            Me.activateDrawingButton.Id = 35
            Me.activateDrawingButton.ImageOptions.SvgImage = CType((resources.GetObject("barButtonItem2.ImageOptions.SvgImage")), DevExpress.Utils.Svg.SvgImage)
            Me.activateDrawingButton.Name = "activateDrawingButton"
            AddHandler Me.activateDrawingButton.ItemClick, New DevExpress.XtraBars.ItemClickEventHandler(AddressOf Me.activateDrawingButton_ItemClick)
            ' 
            ' saveGraphicsButton
            ' 
            Me.saveGraphicsButton.Caption = "Save Graphics and Reload"
            Me.saveGraphicsButton.Id = 36
            Me.saveGraphicsButton.ImageOptions.SvgImage = CType((resources.GetObject("barButtonItem3.ImageOptions.SvgImage")), DevExpress.Utils.Svg.SvgImage)
            Me.saveGraphicsButton.Name = "saveGraphicsButton"
            AddHandler Me.saveGraphicsButton.ItemClick, New DevExpress.XtraBars.ItemClickEventHandler(AddressOf Me.saveGraphicsButton_ItemClick)
            ' 
            ' pdfRibbonPage1
            ' 
            Me.pdfRibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.pdfFileRibbonPageGroup1, Me.pdfFindRibbonPageGroup1, Me.pdfNavigationRibbonPageGroup1, Me.pdfZoomRibbonPageGroup1, Me.ribbonPageGroup1})
            Me.pdfRibbonPage1.Name = "pdfRibbonPage1"
            ' 
            ' pdfFileRibbonPageGroup1
            ' 
            Me.pdfFileRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
            Me.pdfFileRibbonPageGroup1.ItemLinks.Add(Me.pdfFileOpenBarItem1)
            Me.pdfFileRibbonPageGroup1.ItemLinks.Add(Me.pdfFileSaveAsBarItem1)
            Me.pdfFileRibbonPageGroup1.ItemLinks.Add(Me.pdfFilePrintBarItem1)
            Me.pdfFileRibbonPageGroup1.Name = "pdfFileRibbonPageGroup1"
            ' 
            ' pdfFindRibbonPageGroup1
            ' 
            Me.pdfFindRibbonPageGroup1.AllowTextClipping = False
            Me.pdfFindRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
            Me.pdfFindRibbonPageGroup1.ItemLinks.Add(Me.pdfFindTextBarItem1)
            Me.pdfFindRibbonPageGroup1.Name = "pdfFindRibbonPageGroup1"
            ' 
            ' pdfNavigationRibbonPageGroup1
            ' 
            Me.pdfNavigationRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
            Me.pdfNavigationRibbonPageGroup1.ItemLinks.Add(Me.pdfPreviousPageBarItem1)
            Me.pdfNavigationRibbonPageGroup1.ItemLinks.Add(Me.pdfNextPageBarItem1)
            Me.pdfNavigationRibbonPageGroup1.ItemLinks.Add(Me.pdfSetPageNumberBarItem1)
            Me.pdfNavigationRibbonPageGroup1.Name = "pdfNavigationRibbonPageGroup1"
            ' 
            ' pdfZoomRibbonPageGroup1
            ' 
            Me.pdfZoomRibbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
            Me.pdfZoomRibbonPageGroup1.ItemLinks.Add(Me.pdfZoomOutBarItem1)
            Me.pdfZoomRibbonPageGroup1.ItemLinks.Add(Me.pdfZoomInBarItem1)
            Me.pdfZoomRibbonPageGroup1.ItemLinks.Add(Me.pdfExactZoomListBarSubItem1)
            Me.pdfZoomRibbonPageGroup1.Name = "pdfZoomRibbonPageGroup1"
            ' 
            ' ribbonPageGroup1
            ' 
            Me.ribbonPageGroup1.ItemLinks.Add(Me.activateDrawingButton)
            Me.ribbonPageGroup1.ItemLinks.Add(Me.saveGraphicsButton)
            Me.ribbonPageGroup1.Name = "ribbonPageGroup1"
            Me.ribbonPageGroup1.Text = "Draw Content"
            ' 
            ' pdfCommentRibbonPage1
            ' 
            Me.pdfCommentRibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.pdfTextCommentPageGroup1, Me.pdfNoteCommentPageGroup1})
            Me.pdfCommentRibbonPage1.Name = "pdfCommentRibbonPage1"
            ' 
            ' pdfTextCommentPageGroup1
            ' 
            Me.pdfTextCommentPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
            Me.pdfTextCommentPageGroup1.ItemLinks.Add(Me.pdfTextHighlightBarItem1)
            Me.pdfTextCommentPageGroup1.ItemLinks.Add(Me.pdfTextStrikethroughBarItem1)
            Me.pdfTextCommentPageGroup1.ItemLinks.Add(Me.pdfTextUnderlineBarItem1)
            Me.pdfTextCommentPageGroup1.Name = "pdfTextCommentPageGroup1"
            ' 
            ' pdfNoteCommentPageGroup1
            ' 
            Me.pdfNoteCommentPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
            Me.pdfNoteCommentPageGroup1.ItemLinks.Add(Me.pdfStickyNoteBarItem1)
            Me.pdfNoteCommentPageGroup1.Name = "pdfNoteCommentPageGroup1"
            ' 
            ' pdfFormDataRibbonPage1
            ' 
            Me.pdfFormDataRibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.pdfFormDataBarPageGroup1})
            Me.pdfFormDataRibbonPage1.Name = "pdfFormDataRibbonPage1"
            ' 
            ' pdfFormDataBarPageGroup1
            ' 
            Me.pdfFormDataBarPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
            Me.pdfFormDataBarPageGroup1.ItemLinks.Add(Me.pdfExportFormDataBarItem1)
            Me.pdfFormDataBarPageGroup1.ItemLinks.Add(Me.pdfImportFormDataBarItem1)
            Me.pdfFormDataBarPageGroup1.ItemLinks.Add(Me.barButtonItem1)
            Me.pdfFormDataBarPageGroup1.Name = "pdfFormDataBarPageGroup1"
            ' 
            ' pdfBarController1
            ' 
            Me.pdfBarController1.BarItems.Add(Me.pdfFileOpenBarItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfFileSaveAsBarItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfFilePrintBarItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfFindTextBarItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfPreviousPageBarItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfNextPageBarItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfSetPageNumberBarItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfZoomOutBarItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfZoomInBarItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfZoom10CheckItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfZoom25CheckItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfZoom50CheckItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfZoom75CheckItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfZoom100CheckItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfZoom125CheckItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfZoom150CheckItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfZoom200CheckItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfZoom400CheckItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfZoom500CheckItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfSetActualSizeZoomModeCheckItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfSetPageLevelZoomModeCheckItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfSetFitWidthZoomModeCheckItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfSetFitVisibleZoomModeCheckItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfExactZoomListBarSubItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfTextHighlightBarItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfTextStrikethroughBarItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfTextUnderlineBarItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfStickyNoteBarItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfExportFormDataBarItem1)
            Me.pdfBarController1.BarItems.Add(Me.pdfImportFormDataBarItem1)
            Me.pdfBarController1.Control = Me.pdfViewer
            ' 
            ' Form1
            ' 
            Me.AllowFormGlass = DevExpress.Utils.DefaultBoolean.[False]
            Me.AutoScaleDimensions = New System.Drawing.SizeF(12F, 25F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1886, 1094)
            Me.Controls.Add(Me.pdfViewer)
            Me.Controls.Add(Me.ribbonControl1)
            Me.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
            Me.Name = "Form1"
            Me.Ribbon = Me.ribbonControl1
            Me.Text = "PDF Viewer"
            CType((Me.ribbonControl1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.repositoryItemPageNumberEdit1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.pdfBarController1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

#End Region
        Private pdfViewer As DevExpress.XtraPdfViewer.PdfViewer

        Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl

        Private pdfFileOpenBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfFileOpenBarItem

        Private pdfFileSaveAsBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfFileSaveAsBarItem

        Private pdfFilePrintBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfFilePrintBarItem

        Private pdfFindTextBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfFindTextBarItem

        Private pdfPreviousPageBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfPreviousPageBarItem

        Private pdfNextPageBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfNextPageBarItem

        Private pdfSetPageNumberBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfSetPageNumberBarItem

        Private repositoryItemPageNumberEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPageNumberEdit

        Private pdfZoomOutBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoomOutBarItem

        Private pdfZoomInBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoomInBarItem

        Private pdfExactZoomListBarSubItem1 As DevExpress.XtraPdfViewer.Bars.PdfExactZoomListBarSubItem

        Private pdfZoom10CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom10CheckItem

        Private pdfZoom25CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom25CheckItem

        Private pdfZoom50CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom50CheckItem

        Private pdfZoom75CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom75CheckItem

        Private pdfZoom100CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom100CheckItem

        Private pdfZoom125CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom125CheckItem

        Private pdfZoom150CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom150CheckItem

        Private pdfZoom200CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom200CheckItem

        Private pdfZoom400CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom400CheckItem

        Private pdfZoom500CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom500CheckItem

        Private pdfSetActualSizeZoomModeCheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfSetActualSizeZoomModeCheckItem

        Private pdfSetPageLevelZoomModeCheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfSetPageLevelZoomModeCheckItem

        Private pdfSetFitWidthZoomModeCheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfSetFitWidthZoomModeCheckItem

        Private pdfSetFitVisibleZoomModeCheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfSetFitVisibleZoomModeCheckItem

        Private pdfTextHighlightBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfTextHighlightBarItem

        Private pdfTextStrikethroughBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfTextStrikethroughBarItem

        Private pdfTextUnderlineBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfTextUnderlineBarItem

        Private pdfStickyNoteBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfStickyNoteBarItem

        Private pdfExportFormDataBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfExportFormDataBarItem

        Private pdfImportFormDataBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfImportFormDataBarItem

        Private pdfRibbonPage1 As DevExpress.XtraPdfViewer.Bars.PdfRibbonPage

        Private pdfFileRibbonPageGroup1 As DevExpress.XtraPdfViewer.Bars.PdfFileRibbonPageGroup

        Private pdfFindRibbonPageGroup1 As DevExpress.XtraPdfViewer.Bars.PdfFindRibbonPageGroup

        Private pdfNavigationRibbonPageGroup1 As DevExpress.XtraPdfViewer.Bars.PdfNavigationRibbonPageGroup

        Private pdfZoomRibbonPageGroup1 As DevExpress.XtraPdfViewer.Bars.PdfZoomRibbonPageGroup

        Private pdfCommentRibbonPage1 As DevExpress.XtraPdfViewer.Bars.PdfCommentRibbonPage

        Private pdfTextCommentPageGroup1 As DevExpress.XtraPdfViewer.Bars.PdfTextCommentPageGroup

        Private pdfNoteCommentPageGroup1 As DevExpress.XtraPdfViewer.Bars.PdfNoteCommentPageGroup

        Private pdfFormDataRibbonPage1 As DevExpress.XtraPdfViewer.Bars.PdfFormDataRibbonPage

        Private pdfFormDataBarPageGroup1 As DevExpress.XtraPdfViewer.Bars.PdfFormDataBarPageGroup

        Private pdfBarController1 As DevExpress.XtraPdfViewer.Bars.PdfBarController

        Private barButtonItem1 As DevExpress.XtraBars.BarButtonItem

        Private activateDrawingButton As DevExpress.XtraBars.BarButtonItem

        Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup

        Private saveGraphicsButton As DevExpress.XtraBars.BarButtonItem
    End Class
End Namespace
