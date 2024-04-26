Public Class SetupListBarang


    Dim Tampung As New DataTable 'sebuah variabel yang menampung objek DataTable untuk menampung data dari database

    Public NilaiKiriman As Integer

    Sub TampilTabel()
        '  Mengambil data barang dari database menggunakan fungsi EksekusiSQL.
        Tampung = EksekusiSQL("select * from barang")
        GridControl1.DataSource = Tampung
        GridView1.BestFitColumns()
    End Sub

    Sub Pilih()
        Select Case NilaiKiriman
            Case 1 'Jika NilaiKiriman sama dengan 1, data barang akan dikembalikan ke form frmMasterTransaksiPembelian.
                'kembalikan data ke pembelian
                frmMasterTransaksiPembelian.txtCari.Text = GridView1.GetFocusedRowCellValue("ID_BARANG")
                frmMasterTransaksiPembelian.TambahItem()
                Me.Close()
            Case 2 'Jika NilaiKiriman sama dengan 2, data barang akan dikembalikan ke form frmMasterTransaksiPenjualan.
                'kembalikan data ke penjual
                frmMasterTransaksiPenjualan.txtCari.Text = GridView1.GetFocusedRowCellValue("ID_BARANG")
                frmMasterTransaksiPenjualan.TambahItem()
                Me.Close()
        End Select
    End Sub

    Sub Tutup()
        Me.Close()
    End Sub



    Private Sub frmListBarang_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case e.Control And Keys.S
                Pilih()
            Case Keys.Escape
                Tutup()
        End Select
    End Sub



    Private Sub frmListBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        EksekusiRapikanGridView(GridView1)
        GridView1.FindFilterText = Nothing 'kosongin pencarian di list barang
        TampilTabel()
    End Sub



    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Pilih()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Pilih()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Tutup()
    End Sub
End Class