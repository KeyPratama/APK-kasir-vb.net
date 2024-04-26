' melakukan import namespace yang diperlukan untuk menggunakan fungsi dan objek tertentu dalam kode
Imports MySql.Data.MySqlClient
Imports DevExpress.XtraPrinting
Imports DevExpress.LookAndFeel
Imports System.Drawing.Printing
Module Module1

    'Fuction EksekusiSQL digunakan untuk menjalankan perintah SQL pada database MySQL. Fungsi ini menerima perintah SQL sebagai argumen dan mengembalikan objek DataTable yang berisi hasil dari perintah tersebut.

    Function EksekusiSQL(ByVal PerintahSQL) As DataTable
        Dim Alamat As String = "server=" & My.Settings.konNamaServer & ";user id=" & My.Settings.konNamaUser & ";password=" & My.Settings.konKataSandi & ";database= " & My.Settings.konNamaDatabase & ";port=" & My.Settings.konPortal & ""
        Dim Koneksi As New MySqlConnection(Alamat)
        Dim Eksekusi As New MySqlDataAdapter(PerintahSQL, Koneksi)
        Dim Tampung As New DataTable
        Eksekusi.Fill(Tampung)
        Return Tampung
    End Function

    'digunakan untuk mengatur tampilan GridView dari DevExpress agar sesuai dengan preferensi yang diinginkan. Misalnya, mengatur agar kolom tidak dapat diedit, menonaktifkan panel grup, dan menampilkan baris pencarian otomatis.

    Sub EksekusiRapikanGridView(ByVal NamaGridview As DevExpress.XtraGrid.Views.Grid.GridView)
        NamaGridview.OptionsBehavior.Editable = False 'supaya tidak bisa diedit data pada tabel
        NamaGridview.OptionsView.ColumnAutoWidth = False 'supaya kolom tidak mengikuti ukuran tabel
        NamaGridview.OptionsView.ShowGroupPanel = False 'menghilangkan group panel
        NamaGridview.OptionsView.ShowAutoFilterRow = True 'tampilkan pencarian berdasarkan kolom
        NamaGridview.OptionsFind.AlwaysVisible = True 'tampilkan pencarian keseluruhan kolom
    End Sub

    'digunakan untuk menambahkan tanda tangan pada pratinjau cetak GridView. Tanda tangan mencakup lokasi laporan, tanggal, dan         nama pimpinan.
    Sub TTD(ByVal GridViewName As DevExpress.XtraGrid.Views.Grid.GridView)
        GridViewName.OptionsPrint.RtfReportFooter = vbCrLf & IIf(My.Settings.LokasiLaporan <> Nothing, My.Settings.LokasiLaporan, ".........................") & ", " & Format(Now, "dd MMMM yyyy") & vbCrLf & "Mengesahkan/Mengetahui," & vbCrLf & vbCrLf & vbCrLf & vbCrLf & "_________" & vbCrLf & "Pimpinan"
    End Sub

    'digunakan untuk menampilkan pratinjau cetak dari suatu GridControl. Sub ini menerima beberapa argumen opsional seperti tata letak kertas, margin, dan status lanskap atau potret.
    Public Sub ExecuteGridControlPreview(ByVal GridControl As IPrintable, ByVal GridControlLookAndFeel As UserLookAndFeel, Optional ByVal StatusLandscape As Boolean = False, Optional ByVal PaperKind As System.Drawing.Printing.PaperKind = PaperKind.A4, Optional ByVal LeftMargin As Double = 50, Optional ByVal RightMargin As Double = 50, Optional ByVal TopMargin As Double = 50, Optional ByVal BottomMargin As Double = 50)
        Dim Link As New PrintableComponentLink() With {.PrintingSystemBase = New PrintingSystem(), .Component = GridControl, .Landscape = StatusLandscape, .PaperKind = PaperKind, .Margins = New Margins(LeftMargin, RightMargin, TopMargin, BottomMargin)}
        Link.ShowRibbonPreview(GridControlLookAndFeel)
    End Sub

    ' digunakan untuk mengatur menu pada tampilan utama aplikasi. Menu yang ditampilkan atau disembunyikan dapat dikontrol dengan        mengatur parameter boolean yang sesuai dengan masing-masing menu.
    Sub PortalMenu(ByVal sBarang As Boolean, ByVal sMenu As Boolean, ByVal sPemasok As Boolean, ByVal sPelanggan As Boolean, ByVal sPembelian As Boolean, ByVal sPenjualan As Boolean, ByVal sRekapPenjualan As Boolean, ByVal sRekapPembelian As Boolean, ByVal sKonfigurasiKoneksi As Boolean, ByVal sKonfigurasiSistem As Boolean, ByVal sPengguna As Boolean)
        With SetupMenuUtama
            'menu master
            .btnPelanggan.Enabled = sPelanggan
            .btnPemasok.Enabled = sPemasok
            .btnBarang.Enabled = sBarang


            'menu transaksi
            .btnPembelian.Enabled = sPembelian
            .btnPenjualan.Enabled = sPenjualan


            'menu laporan
            .btnRekapPembelian.Enabled = sRekapPembelian
            .btnRekapPenjualan.Enabled = sRekapPenjualan

            'menu pengaturan
            .btnPengguna.Enabled = sPengguna
            .btnKonfigurasiKoneksi.Enabled = sKonfigurasiKoneksi
            .btnKonfigurasiSistem.Enabled = sKonfigurasiSistem


        End With
    End Sub


End Module
