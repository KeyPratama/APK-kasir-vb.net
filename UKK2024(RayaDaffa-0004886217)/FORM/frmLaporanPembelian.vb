Public Class frmLaporanPembelian


    Dim Tampung As New DataTable 'sebuah variabel yang menampung objek DataTable untuk menampung data dari database

    Sub TampilTabel() ' digunakan untuk menampilkan data transaksi pembelian dalam GridControl. Query SQL digunakan untuk mengambil          data pembelian dari database berdasarkan periode waktu yang ditentukan oleh tanggal awal dan tanggal akhir. Data kemudian          ditampilkan dalam GridControl. 
        Tampung = EksekusiSQL("SELECT  TANGGAL , ID_PEMBELIAN , pembelian. ID_PEMASOK , pemasok. NAMA_PEMASOK ,  TOTAL_PEMBELIAN ,  POTONGAN ,  METODE_PEMBAYARAN , pembelian. ID_PENGGUNA , NAMA_PENGGUNA FROM pembelian , pemasok,  pengguna  WHERE  pembelian.ID_PEMASOK  =  pemasok.ID_PEMASOK  AND  pembelian.ID_PENGGUNA  =  pengguna . ID_PENGGUNA AND TANGGAL BETWEEN  '" & Format(txtTanggalAwal.DateTime, "yyyy-MM-dd") & "' AND '" & Format(txtTanggalAkhir.DateTime, "yyyy-MM-dd") & "'")
        GridControl1.DataSource = Tampung

        'disini masih banyak pengaturan
        'memberikan format pada kolom TOTAL_PEMBELIAN berupa numeric currency
        GridView1.Columns("TOTAL_PEMBELIAN").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns("TOTAL_PEMBELIAN").DisplayFormat.FormatString = "c0"

        'memberikan total pada kolom TOTAL_PEMBELIAN dan  format berupa numeric currenry
        GridView1.Columns("TOTAL_PEMBELIAN").SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0:c0}")

        GridView1.BestFitColumns()

    End Sub

    Sub DetailLaporan() 'dipanggil saat pengguna ingin melihat detail dari sebuah transaksi pembelian yang dipilih dari     GridControl. Formulir frmLaporanDetailakan dipanggil dan ditampilkan untuk menampilkan detail transaksi 

        'memanggil frmLaporanDetail
        'cetak dahulu isi tabel
        If GridView1.RowCount > 0 Then
            frmLaporanDetail.NilaiKiriman = 1
            frmLaporanDetail.ID = GridView1.GetFocusedRowCellValue("ID_PEMBELIAN")
            frmLaporanDetail.WindowState = FormWindowState.Maximized
            frmLaporanDetail.ShowDialog()
        End If
    End Sub


    Sub Cetak() 'digunakan untuk mencetak laporan transaksi pembelian. Judul header cetak akan disesuaikan dengan periode waktu                     laporan, dan tanda tangan ( TTD) juga ditambahkan. GridControl kemudian dicetak menggunakan 
        GridView1.OptionsPrint.PrintFilterInfo = True
        GridView1.OptionsPrint.RtfReportHeader = "LAPORAN PEMBELIAN" & vbCrLf & "PERIODE" & Format(txtTanggalAwal.DateTime, "dd MMMM yyyy") & "S/D" & Format(txtTanggalAkhir.DateTime, "dd MMMM yyyy") & vbCrLf
        TTD(GridView1)
        ExecuteGridControlPreview(GridControl1, GridControl1.LookAndFeel, True, Printing.PaperKind.A4, 15, 15, 15, 15)
    End Sub

    Sub Tutup()
        Me.Close()
    End Sub

    Private Sub frmLaporanPembelian_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                ' Segarkan()
                TampilTabel()
            Case Keys.F1
                DetailLaporan()
            Case e.Control And Keys.P
                Cetak()
            Case Keys.Escape
                Tutup()
        End Select
    End Sub

    Private Sub frmLaporanPembelian_Load(sender As Object, e As EventArgs) Handles Me.Load 'mengaktifkan preview keyboard, mengatur  tampilan GridView, menampilkan tanggal hari ini sebagai tanggal awal dan tanggal akhir, dan menampilkan data transaksi pembelian.
        Me.KeyPreview = True
        EksekusiRapikanGridView(GridView1)
        GridView1.OptionsView.ShowFooter = True 'aktifkan report footer
        'menampilkan tanggal hari ke tanggal awal dan tanggal akhir
        txtTanggalAwal.DateTime = Now
        txtTanggalAkhir.DateTime = Now
        TampilTabel()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        TampilTabel()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        DetailLaporan()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Cetak()
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Tutup()
    End Sub
End Class