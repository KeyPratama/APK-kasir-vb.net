<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetupMenuUtama
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetupMenuUtama))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.ApplicationMenu1 = New DevExpress.XtraBars.Ribbon.ApplicationMenu(Me.components)
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarCheckItem1 = New DevExpress.XtraBars.BarCheckItem()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.btnBarang = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPelanggan = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPemasok = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPembelian = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPenjualan = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRekapPembelian = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRekapPenjualan = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem7 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem8 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem9 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem10 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnKonfigurasiKoneksi = New DevExpress.XtraBars.BarButtonItem()
        Me.btnKonfigurasiSistem = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.DocumentManager1 = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
        Me.TabbedView1 = New DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnPengguna = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocumentManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ApplicationButtonDropDownControl = Me.ApplicationMenu1
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Images = Me.ImageCollection1
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.btnBarang, Me.btnPelanggan, Me.btnPemasok, Me.btnPembelian, Me.btnPenjualan, Me.btnRekapPembelian, Me.btnRekapPenjualan, Me.BarButtonItem7, Me.BarButtonItem8, Me.BarButtonItem9, Me.BarButtonItem10, Me.btnKonfigurasiKoneksi, Me.btnKonfigurasiSistem, Me.BarButtonItem1, Me.BarButtonItem2, Me.BarCheckItem1, Me.BarButtonItem3, Me.btnPengguna})
        Me.RibbonControl.LargeImages = Me.ImageCollection1
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 21
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1, Me.RibbonPage2})
        Me.RibbonControl.Size = New System.Drawing.Size(1030, 219)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'ApplicationMenu1
        '
        Me.ApplicationMenu1.ItemLinks.Add(Me.BarButtonItem1)
        Me.ApplicationMenu1.ItemLinks.Add(Me.BarButtonItem2)
        Me.ApplicationMenu1.ItemLinks.Add(Me.BarButtonItem3)
        Me.ApplicationMenu1.ItemLinks.Add(Me.BarCheckItem1)
        Me.ApplicationMenu1.Name = "ApplicationMenu1"
        Me.ApplicationMenu1.Ribbon = Me.RibbonControl
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Ganti Password"
        Me.BarButtonItem1.Id = 16
        Me.BarButtonItem1.LargeImageIndex = 2
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Logout"
        Me.BarButtonItem2.Id = 17
        Me.BarButtonItem2.LargeImageIndex = 6
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Keluar"
        Me.BarButtonItem3.Id = 19
        Me.BarButtonItem3.LargeImageIndex = 1
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'BarCheckItem1
        '
        Me.BarCheckItem1.Id = 18
        Me.BarCheckItem1.Name = "BarCheckItem1"
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageSize = New System.Drawing.Size(48, 48)
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "C3M (607).png")
        Me.ImageCollection1.Images.SetKeyName(1, "C3M (197).png")
        Me.ImageCollection1.Images.SetKeyName(2, "C3M (193).png")
        Me.ImageCollection1.Images.SetKeyName(3, "C3M (912).png")
        Me.ImageCollection1.Images.SetKeyName(4, "C3M (918).png")
        Me.ImageCollection1.Images.SetKeyName(5, "C3M (911).png")
        Me.ImageCollection1.Images.SetKeyName(6, "C3M (200).png")
        Me.ImageCollection1.Images.SetKeyName(7, "C3M (183).png")
        Me.ImageCollection1.Images.SetKeyName(8, "C3M (150).png")
        Me.ImageCollection1.Images.SetKeyName(9, "C3M (109).png")
        Me.ImageCollection1.Images.SetKeyName(10, "C3M (539).png")
        Me.ImageCollection1.Images.SetKeyName(11, "C3M (160).png")
        Me.ImageCollection1.Images.SetKeyName(12, "C3M (653).png")
        Me.ImageCollection1.Images.SetKeyName(13, "C3M (652).png")
        Me.ImageCollection1.Images.SetKeyName(14, "C3M (607).png")
        Me.ImageCollection1.Images.SetKeyName(15, "C3M (619).png")
        '
        'btnBarang
        '
        Me.btnBarang.Caption = "Barang"
        Me.btnBarang.Id = 2
        Me.btnBarang.ImageIndex = 15
        Me.btnBarang.LargeImageIndex = 15
        Me.btnBarang.Name = "btnBarang"
        '
        'btnPelanggan
        '
        Me.btnPelanggan.Caption = "Pelanggan"
        Me.btnPelanggan.Id = 3
        Me.btnPelanggan.ImageIndex = 9
        Me.btnPelanggan.LargeImageIndex = 9
        Me.btnPelanggan.Name = "btnPelanggan"
        '
        'btnPemasok
        '
        Me.btnPemasok.Caption = "Pemasok"
        Me.btnPemasok.Id = 4
        Me.btnPemasok.ImageIndex = 10
        Me.btnPemasok.LargeImageIndex = 10
        Me.btnPemasok.Name = "btnPemasok"
        '
        'btnPembelian
        '
        Me.btnPembelian.Caption = "Pembelian"
        Me.btnPembelian.Id = 5
        Me.btnPembelian.ImageIndex = 13
        Me.btnPembelian.LargeImageIndex = 13
        Me.btnPembelian.Name = "btnPembelian"
        '
        'btnPenjualan
        '
        Me.btnPenjualan.Caption = "Penjualan"
        Me.btnPenjualan.Id = 6
        Me.btnPenjualan.LargeImageIndex = 12
        Me.btnPenjualan.Name = "btnPenjualan"
        '
        'btnRekapPembelian
        '
        Me.btnRekapPembelian.Caption = "Rekap Pembelian"
        Me.btnRekapPembelian.Id = 7
        Me.btnRekapPembelian.LargeImageIndex = 13
        Me.btnRekapPembelian.Name = "btnRekapPembelian"
        '
        'btnRekapPenjualan
        '
        Me.btnRekapPenjualan.Caption = "Rekap Penjualan"
        Me.btnRekapPenjualan.Id = 9
        Me.btnRekapPenjualan.LargeImageIndex = 12
        Me.btnRekapPenjualan.Name = "btnRekapPenjualan"
        '
        'BarButtonItem7
        '
        Me.BarButtonItem7.Caption = "Ready"
        Me.BarButtonItem7.Id = 10
        Me.BarButtonItem7.Name = "BarButtonItem7"
        '
        'BarButtonItem8
        '
        Me.BarButtonItem8.Caption = "Pengguna : XXX"
        Me.BarButtonItem8.Id = 11
        Me.BarButtonItem8.ImageIndex = 4
        Me.BarButtonItem8.LargeImageIndex = 4
        Me.BarButtonItem8.Name = "BarButtonItem8"
        '
        'BarButtonItem9
        '
        Me.BarButtonItem9.Caption = "Hak Akses : XXX"
        Me.BarButtonItem9.Id = 12
        Me.BarButtonItem9.ImageIndex = 3
        Me.BarButtonItem9.Name = "BarButtonItem9"
        '
        'BarButtonItem10
        '
        Me.BarButtonItem10.Caption = "Tanggal 22 April 2024, Pukul 09;18 "
        Me.BarButtonItem10.Id = 13
        Me.BarButtonItem10.ImageIndex = 5
        Me.BarButtonItem10.Name = "BarButtonItem10"
        '
        'btnKonfigurasiKoneksi
        '
        Me.btnKonfigurasiKoneksi.Caption = "Konfigurasi Koneksi"
        Me.btnKonfigurasiKoneksi.Id = 14
        Me.btnKonfigurasiKoneksi.LargeImageIndex = 8
        Me.btnKonfigurasiKoneksi.Name = "btnKonfigurasiKoneksi"
        '
        'btnKonfigurasiSistem
        '
        Me.btnKonfigurasiSistem.ActAsDropDown = True
        Me.btnKonfigurasiSistem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.btnKonfigurasiSistem.Caption = "Konfigurasi Sistem"
        Me.btnKonfigurasiSistem.Id = 15
        Me.btnKonfigurasiSistem.LargeImageIndex = 14
        Me.btnKonfigurasiSistem.Name = "btnKonfigurasiSistem"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1, Me.RibbonPageGroup2, Me.RibbonPageGroup3})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Menu"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnPelanggan)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnPemasok)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnBarang)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Master"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btnPembelian)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btnPenjualan)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "Transaksi"
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.btnRekapPembelian)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.btnRekapPenjualan)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        Me.RibbonPageGroup3.Text = "Laporan"
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup4})
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "Pengaturan"
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.btnPengguna)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.btnKonfigurasiKoneksi)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.btnKonfigurasiSistem)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        Me.RibbonPageGroup4.Text = "Umum"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.ItemLinks.Add(Me.BarButtonItem7)
        Me.RibbonStatusBar.ItemLinks.Add(Me.BarButtonItem8)
        Me.RibbonStatusBar.ItemLinks.Add(Me.BarButtonItem9)
        Me.RibbonStatusBar.ItemLinks.Add(Me.BarButtonItem10)
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 510)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(1030, 48)
        '
        'DocumentManager1
        '
        Me.DocumentManager1.MdiParent = Me
        Me.DocumentManager1.MenuManager = Me.RibbonControl
        Me.DocumentManager1.View = Me.TabbedView1
        Me.DocumentManager1.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() {Me.TabbedView1})
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'btnPengguna
        '
        Me.btnPengguna.Caption = "Pengguna"
        Me.btnPengguna.Id = 20
        Me.btnPengguna.LargeImageIndex = 7
        Me.btnPengguna.Name = "btnPengguna"
        '
        'SetupMenuUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 558)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.IsMdiContainer = True
        Me.Name = "SetupMenuUtama"
        Me.Ribbon = Me.RibbonControl
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "SetupMenuUtama"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocumentManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents ApplicationMenu1 As DevExpress.XtraBars.Ribbon.ApplicationMenu
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents DocumentManager1 As DevExpress.XtraBars.Docking2010.DocumentManager
    Friend WithEvents TabbedView1 As DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView
    Friend WithEvents btnBarang As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPelanggan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPemasok As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPembelian As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPenjualan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRekapPembelian As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRekapPenjualan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem7 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem8 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem9 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem10 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnKonfigurasiKoneksi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnKonfigurasiSistem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarCheckItem1 As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnPengguna As DevExpress.XtraBars.BarButtonItem


End Class
