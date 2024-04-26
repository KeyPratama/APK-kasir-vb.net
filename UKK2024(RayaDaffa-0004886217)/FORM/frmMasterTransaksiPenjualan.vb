Public Class frmMasterTransaksiPenjualan

    Dim Tampung As New DataTable 'sebuah variabel yang menampung objek DataTable untuk menampung data dari database
    Dim TotalPenjualan As Double

    Sub TampilTotalHarga() ' untuk menghitung dan menampilkan total harga dari transaksi penjualan yang ada dalam DataTable. Total harga kemudian ditampilkan dalam TextBox txtTotal.
        ' menghitung dan menampilkan kolom total harga pada tabel
        Dim Total As Double = 0
        For Each Isi In Tampung.Select()
            Total = Total + Isi.Item("Total_Harga")
        Next
        TotalPenjualan = Total
        txtTotal.Text = "Total Rp." & Format(Total, "#,##0") & " ,-"
        GridView1.BestFitColumns()
    End Sub

    Sub TampilPelanggan() ' Digunakan untuk menampilkan daftar pelanggan dalam kontrol ComboBox txtPelanggan.
        Dim Pelanggan = EksekusiSQL("select * from pelanggan")
        txtPelanggan.Properties.Items.Clear()
        For Each Isi In Pelanggan.Select()
            txtPelanggan.Properties.Items.Add(Isi.Item("NAMA_PELANGGAN") & ">" & Isi.Item("ID_PELANGGAN"))
        Next
    End Sub

    Sub TampilTabel() 'Menampilkan template untuk entri penjualan dengan mengambil data dari database menggunakan SQL query dan                           menampilkannya dalam GridControl.
        ' menampilkan template 
        Tampung = EksekusiSQL("SELECT JUMLAH,penjualan_detil.ID_BARANG,NAMA_BARANG,SATUAN,HARGA_SATUAN,TOTAL_HARGA from penjualan_detil,barang where penjualan_detil.ID_BARANG=barang.ID_BARANG and ID_PENJUALAN=''")
        GridControl1.DataSource = Tampung
        'disini ada tambahan bumbu nanti
    End Sub

    Sub Segarkan()  'form disegarkan dengan mengosongkan kontrol inputan
        TampilTabel() ' tampil ulang isi tabel
        txtCari.Text = ""
        txtTanggal.DateTime = Now
        TampilPelanggan() 'tampil ulang pilihan pemasok
        txtPelanggan.SelectedIndex = -1
        txtPotongan.Value = 0
        txtMetodePembayaran.SelectedIndex = 0
        TotalPenjualan = 0
        txtKeterangan.Text = ""
        TampilTotalHarga() ' tampil ulang label total
        txtCari.Focus()
    End Sub

    Sub TambahItem() 'Menambahkan item barang ke dalam transaksi penjualan. Melakukan pengecekan terlebih dahulu apakah barang                           sudah ada dalam tabel atau belum. Jika belum, maka data barang akan ditambahkan ke dalam DataTable.
        Dim CariBarang = EksekusiSQL("select * from barang where ID_BARANG='" & txtCari.Text & "' or NAMA_BARANG='" & txtCari.Text & "' or BARCODE= '" & txtCari.Text & "'").Select()
        If CariBarang.Length > 0 Then ' PENGECEKAN BARANG ADA ATAU TIDAK DISINI

            'disini lanjutkan
            Dim CariDataTabel = Tampung.Select("ID_BARANG='" & CariBarang(0).Item("ID_BARANG") & "'")
            If CariDataTabel.Length <= 0 Then
                'tambah ke tabel
                'pengecekan stok sebelum ditambahkan
                If CariBarang(0).Item("STOK") <= 0 Then
                    MessageBox.Show("Stok tidak ada.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub 'membatalkan penambahan
                End If
                Dim DataBaru = Tampung.NewRow 'buat baris baru pada tampung
                DataBaru.Item("JUMLAH") = 1
                DataBaru.Item("ID_BARANG") = CariBarang(0).Item("ID_BARANG")
                DataBaru.Item("NAMA_BARANG") = CariBarang(0).Item("NAMA_BARANG")
                DataBaru.Item("SATUAN") = CariBarang(0).Item("SATUAN")
                DataBaru.Item("HARGA_SATUAN") = CariBarang(0).Item("HARGA_BELI")
                DataBaru.Item("TOTAL_HARGA") = DataBaru.Item("JUMLAH") * DataBaru.Item("HARGA_SATUAN")
                Tampung.Rows.Add(DataBaru) ' TAMBAHKAN ISIAN BARIS BARU PADA TAMPUNG
                TampilTotalHarga()
                txtCari.Text = ""
                txtCari.Focus()


            Else
                'tambah jumlahnya dan hitung ulang total harga
                'pengecekan stok sebelum diubah di tabel
                If CariBarang(0).Item("STOK") < CariDataTabel(0).Item("JUMLAH") + 1 Then
                    MessageBox.Show("Stok tersedia '" & CariBarang(0).Item("STOK") & "'.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub 'membatalkan penambahan
                End If
                CariDataTabel(0).Item("JUMLAH") = CariDataTabel(0).Item("JUMLAH") + 1
                CariDataTabel(0).Item("TOTAL_HARGA") = CariDataTabel(0).Item("JUMLAH") * CariDataTabel(0).Item("HARGA_SATUAN")
                TampilTotalHarga()
                txtCari.Text = ""
                txtCari.Focus()
            End If
        Else
            MessageBox.Show("Barang Tidak Ditemukan.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCari.Text = ""
            txtCari.Focus()
        End If
    End Sub

    Sub HapusItem() 'Menghapus item barang dari transaksi penjualan yang dipilih oleh pengguna.
        If GridView1.RowCount <= 0 Then
            MessageBox.Show("Item barang belum ditambahkan", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("Item barang akan dihapus. Lanjutkan?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            GridView1.DeleteSelectedRows()
            TampilTotalHarga()
            txtCari.Text = ""
            txtCari.Focus()
        End If
    End Sub

    Sub ListBarang()
        SetupListBarang.NilaiKiriman = 2
        SetupListBarang.WindowState = FormWindowState.Maximized 'memperbesar tampilan form pada saat dipanggil
        SetupListBarang.ShowDialog()
    End Sub

    Sub Simpan() 'Menyimpan transaksi penjualan ke dalam database setelah dilakukan pengecekan validitas data.
        'pengecekan data
        If txtTanggal.Text = "" Or txtPelanggan.Text = "" Or txtMetodePembayaran.Text = "" Then
            MessageBox.Show("Tanggal, Pelanggan, dan Metode Pembayaran wajib diisini.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If GridView1.RowCount <= 0 Then
            MessageBox.Show("Data item barang belum ditambahkan.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        ' pembuatan kode otomatis (auto increment)
        Dim NomorTransaksi As Integer
        Try
            NomorTransaksi = EksekusiSQL("select max(ID_PENJUALAN) as ID_PENJUALAN from penjualan").Select()(0).Item("ID_PENJUALAN") + 1

        Catch ex As Exception
            NomorTransaksi = 1
        End Try
        'MENGISI TABEL PENJUALAN
        EksekusiSQL("insert into penjualan(ID_PENJUALAN, TANGGAL, ID_PELANGGAN, TOTAL_PENJUALAN, POTONGAN, METODE_PEMBAYARAN, KETERANGAN, ID_PENGGUNA) values ('" & NomorTransaksi & "', '" & Format(txtTanggal.DateTime, "yyyy-MM-dd") & "', '" & txtPelanggan.Text.Split(">")(1) & "', '" & TotalPenjualan & "', '" & txtPotongan.Value & "', '" & txtMetodePembayaran.Text & "', '" & txtKeterangan.Text & "', '" & My.Settings.lgnID & "')")
        ' mengisi tabel pembelian detil
        For Each Isi In Tampung.Select()
            EksekusiSQL("insert into penjualan_detil(ID_PENJUALAN, ID_BARANG, JUMLAH, HARGA_SATUAN, TOTAL_HARGA) values('" & NomorTransaksi & "', '" & Isi.Item("ID_BARANG") & "', '" & Isi.Item("JUMLAH") & "', '" & Isi.Item("HARGA_SATUAN") & "', '" & Isi.Item("TOTAL_HARGA") & "' )")
            'coding untuk merubah/menambah stok pada barang
            ' ambil data stok pada barang
            '  Dim Stok = EksekusiSQL("select STOK from barang where ID_BARANG='" & Isi.Item("ID_BARANG") & "'").Select()(0).Item("STOK")
            '   Dim stokBaru = Stok - Isi.Item("JUMLAH")
            'mengubah data stok dengan stok baru
            '  EksekusiSQL("update barang set STOK='" & stokBaru & "' where ID_BARANG='" & Isi.Item("ID_BARANG") & "'")

        Next
        ' pembersihan ulang
        Segarkan()
        MessageBox.Show("Transaksi berhasil.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)



    End Sub

    Sub Tutup()
        If GridView1.RowCount >= 0 Then
            If MessageBox.Show("Transaksi akan ditutup lanjutkan?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub
    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        TambahItem()
    End Sub

    Private Sub frmMasterTransaksiPenjualan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                TambahItem()
            Case e.Control And Keys.F5
                Simpan()
            Case Keys.F5
                Segarkan()
            Case e.Control And Keys.D
                HapusItem()
            Case Keys.F1
                ListBarang()
            Case Keys.Escape
                Tutup()
        End Select
    End Sub

    Private Sub frmMasterTransaksiPenjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        GridView1.OptionsView.ColumnAutoWidth = False 'supaya kolom tidak mengikuti ukuran tabel
        GridView1.OptionsView.ShowGroupPanel = False 'menghilangkan group panel
        txtPelanggan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        txtMetodePembayaran.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Segarkan()
        GridView1.Columns("ID_BARANG").OptionsColumn.AllowEdit = False
        GridView1.Columns("NAMA_BARANG").OptionsColumn.AllowEdit = False
        GridView1.Columns("TOTAL_HARGA").OptionsColumn.AllowEdit = False

    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Simpan()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Segarkan()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        HapusItem()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        ListBarang()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Tutup()
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        ' Menangani perubahan nilai sel pada GridView, khususnya pada kolom JUMLAH dan HARGA_SATUAN. Setiap kali nilai berubah,              total harga akan dihitung ulang.

        ' pengecekan kolom yang di rubah
        Select Case e.Column.GetTextCaption
            Case "JUMLAH"
                'pengecekan stok sebelum diubah di tabel

                Dim Barang = EksekusiSQL("select * from barang where ID_BARANG='" & GridView1.GetFocusedRowCellValue("ID_BARANG") & "'").Select()
                If Barang(0).Item("STOK") < GridView1.GetFocusedRowCellValue("JUMLAH") Then
                    MessageBox.Show("Stok tersedia '" & Barang(0).Item("STOK") & "'.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    GridView1.SetFocusedRowCellValue("JUMLAH", Barang(0).Item("STOK"))
                    Exit Sub 'membatalkan penambahan
                End If
                'hitung total harga

                Dim TotalHarga = GridView1.GetFocusedRowCellValue("JUMLAH") * GridView1.GetFocusedRowCellValue("HARGA_SATUAN")
                GridView1.SetFocusedRowCellValue("TOTAL_HARGA", TotalHarga)
            Case "HARGA_SATUAN"
                'hitung total harga

                Dim TotalHarga = GridView1.GetFocusedRowCellValue("JUMLAH") * GridView1.GetFocusedRowCellValue("HARGA_SATUAN")
                GridView1.SetFocusedRowCellValue("TOTAL_HARGA", TotalHarga)

        End Select
        TampilTotalHarga()
    End Sub
End Class