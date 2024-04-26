Public Class frmLaporanDetail

    Dim Tampung As New DataTable 'sebuah variabel yang menampung objek DataTable untuk menampung data dari database
    Public NilaiKiriman As Integer 'digunakan untuk menentukan jenis transaksi (pembelian atau penjualan), dan 
    Public ID As Integer 'digunakan untuk menentukan ID transaksi tertentu yang akan ditampilkan.

    Sub TampilTabel() ' menampilkan detail transaksi pembelian atau penjualan berdasarkan nilai yang diberikan ke dalam                                    GridControl. Nilai 
        Select Case NilaiKiriman
            Case 1
                'untuk detail pembelian
                Tampung = EksekusiSQL("SELECT `pembelian_detil`.`ID_BARANG`, `NAMA_BARANG`, `SATUAN`, `HARGA_SATUAN`, `JUMLAH`, `TOTAL_HARGA` FROM `pembelian_detil`, `barang` WHERE `pembelian_detil`.`ID_BARANG` = `barang`.`ID_BARANG` AND `ID_PEMBELIAN` = '" & ID & "'")
                GridControl1.DataSource = Tampung
                'memberikan format pada kolom TOTAL_PEMBELIAN berupa numeric currency
                GridView1.Columns("HARGA_SATUAN").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("HARGA_SATUAN").DisplayFormat.FormatString = "c0"
                GridView1.Columns("JUMLAH").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("JUMLAH").DisplayFormat.FormatString = "n0"
                GridView1.Columns("TOTAL_HARGA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("TOTAL_HARGA").DisplayFormat.FormatString = "c0"
                'memberikan total pada kolom TOTAL_PEMBELIAN dan  format berupa numeric currenry
                GridView1.Columns("TOTAL_HARGA").SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0:c0}")
                GridView1.BestFitColumns()
            Case 2
                'untuk detail penjualan
                'untuk detail pembelian
                Tampung = EksekusiSQL("SELECT `penjualan_detil`.`ID_BARANG`, `NAMA_BARANG`, `SATUAN`, `HARGA_SATUAN`, `JUMLAH`, `TOTAL_HARGA` FROM `penjualan_detil`, `barang` WHERE `penjualan_detil`.`ID_BARANG` = `barang`.`ID_BARANG` AND `ID_PENJUALAN` = '" & ID & "'")
                GridControl1.DataSource = Tampung
                'memberikan format pada kolom TOTAL_PEMBELIAN berupa numeric currency
                GridView1.Columns("HARGA_SATUAN").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("HARGA_SATUAN").DisplayFormat.FormatString = "c0"
                GridView1.Columns("JUMLAH").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("JUMLAH").DisplayFormat.FormatString = "n0"
                GridView1.Columns("TOTAL_HARGA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GridView1.Columns("TOTAL_HARGA").DisplayFormat.FormatString = "c0"
                'memberikan total pada kolom TOTAL_PEMBELIAN dan  format berupa numeric currenry
                GridView1.Columns("TOTAL_HARGA").SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0:c0}")
                GridView1.BestFitColumns()
        End Select
    End Sub

    Sub CetakData() 'digunakan untuk mencetak detail transaksi pembelian atau penjualan. Bergantung pada nilai NilaiKiriman
        Select Case NilaiKiriman
            'untuk cetak detail pembelian
            Case 1
                '  judul header cetak akan disesuaikan untuk menunjukkan jenis transaksi dan nomor transaksi yang sesuai. Setelah                   menyiapkan judul dan mengatur tanda tangan ( TTD), GridControl akan dicetak menggunakan ExecuteGridControlPreview.
                GridView1.OptionsPrint.PrintFilterInfo = True
                GridView1.OptionsPrint.RtfReportHeader = " Detail LAPORAN PEMBELIAN" & vbCrLf & " NOMOR TRANSAKSI: " & ID & vbCrLf
                TTD(GridView1)
                ExecuteGridControlPreview(GridControl1, GridControl1.LookAndFeel, True, Printing.PaperKind.A4, 15, 15, 15, 15)
            Case 2
                'untuk cetak detail penjualan
                GridView1.OptionsPrint.PrintFilterInfo = True
                GridView1.OptionsPrint.RtfReportHeader = " Detail LAPORAN PENJUALAN" & vbCrLf & " NOMOR TRANSAKSI: " & ID & vbCrLf
                TTD(GridView1)
                ExecuteGridControlPreview(GridControl1, GridControl1.LookAndFeel, True, Printing.PaperKind.A4, 15, 15, 15, 15)
        End Select
    End Sub



    Sub Tutup() 'Digunakan untuk menutup form.
        Me.Close()
    End Sub

    Private Sub frmLaporanDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown 'mengatur penggunaan shortcut             keyboard untuk melakukan tindakan seperti Cetak dan Tutup.
        Select Case e.KeyCode
            Case e.Control And Keys.P
                CetakData()
            Case Keys.Escape
                Tutup()
        End Select
    End Sub

    Private Sub frmLaporanDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'Digunakan untuk melakukan inisialisasi        saat form dimuat, seperti mengaktifkan preview keyboard, mengatur tampilan GridView, dan menampilkan data detail transaksi.
        Me.KeyPreview = True
        EksekusiRapikanGridView(GridView1)
        GridView1.OptionsView.ShowFooter = True 'aktifkan report footer
        TampilTabel()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        CetakData()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Tutup()
    End Sub
End Class