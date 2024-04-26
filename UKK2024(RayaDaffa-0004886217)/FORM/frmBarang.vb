Public Class frmBarang 

    Dim Tampung As New DataTable 'sebuah variabel yang menampung objek DataTable untuk menampung data dari database
    Dim ID As Integer
    Sub TampilData() 'digunakan untuk menampilkan data barang ke dalam GridView di form. Data diambil dari database dan ditampilkan dalam GridView.
        Tampung = EksekusiSQL("select * from barang")
        GridControl1.DataSource = Tampung
        GridView1.BestFitColumns() 'merapikan tampilan isi kolom dan baris
    End Sub
    Sub Simpan() ' Digunakan menyimpan atau mengubah data barang.
        'validasi inputan
        If txtNama.Text = "" Or txtKategori.Text = "" Or txtSatuan.Text = "" Then
            MessageBox.Show("Nama, Kategori, Satuan wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If ID = 0 Then 'Jika ID adalah 0, itu berarti data baru akan dimasukkan ke dalam database.
            'input data baru
            EksekusiSQL("INSERT INTO `barang`(`NAMA_BARANG`, `KATEGORI`, `SATUAN` , `HARGA_BELI` , `HARGA_JUAL` , `STOK` , `KETERANGAN` , `BARCODE`) VALUES ('" & txtNama.Text & "','" & txtKategori.Text & "','" & txtSatuan.Text & "' ,'" & txtHargaBeli.Value & "' ,'" & txtHargaJual.Value & "' ,'" & txtStok.Value & "' ,'" & txtKeterangan.Text & "' ,'" & txtBercode.Text & "')")
            Segarkan()
            MessageBox.Show("Data Berhasil Ditambahkan", "informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else 'Jika tidak, data yang ada akan diubah.
            'ubah data lama
            EksekusiSQL("UPDATE `barang` SET `NAMA_BARANG`='" & txtNama.Text & "',`KATEGORI`='" & txtKategori.Text & "',`SATUAN`='" & txtSatuan.Text & "',`HARGA_BELI`='" & txtHargaBeli.Value & "',`HARGA_JUAL`='" & txtHargaJual.Value & "',`STOK`='" & txtStok.Value & "',`KETERANGAN`='" & txtKeterangan.Text & "',`BARCODE`='" & txtBercode.Text & "' WHERE `ID_BARANG`='" & ID & "'")
            Segarkan()
            MessageBox.Show("Data Berhasil Diubah", "informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Sub Segarkan() ' Menyegarkan tampilan form, membersihkan inputan, dan menampilkan data baru.
        TampilData()
        ID = 0
        txtNama.Text = ""
        txtKategori.Text = ""
        txtSatuan.Text = ""
        txtHargaBeli.Value = 0
        txtHargaJual.Value = 0
        txtStok.Value = 0
        txtKeterangan.Text = ""
        txtBercode.Text = ""
        txtNama.Focus() 'arahkan kursor fokus ke txtNama
        TampilPilihanKategori()
        TampilPilihanSatuan()
    End Sub

    Sub Ubah() 'Mengisi inputan dengan data barang yang dipilih dari GridView untuk melakukan pengeditan.
        'pengecekan data pada tabel ada atau tidak
        If GridView1.RowCount <= 0 Then
            MessageBox.Show("Data tidak ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'menghasilkan
        ID = GridView1.GetFocusedRowCellValue("ID_BARANG")
        txtNama.Text = GridView1.GetFocusedRowCellValue("NAMA_BARANG")
        txtKategori.Text = GridView1.GetFocusedRowCellValue("KATEGORI")
        txtSatuan.Text = GridView1.GetFocusedRowCellValue("SATUAN")
        txtHargaBeli.Value = GridView1.GetFocusedRowCellValue("HARGA_BELI")
        txtHargaJual.Value = GridView1.GetFocusedRowCellValue("HARGA_JUAL")
        txtStok.Value = GridView1.GetFocusedRowCellValue("STOK")
        txtKeterangan.Text = GridView1.GetFocusedRowCellValue("KETERANGAN")
        txtBercode.Text = GridView1.GetFocusedRowCellValue("BARCODE")
        txtNama.Focus()

    End Sub

    Sub Hapus() 'Menghapus data barang yang dipilih dari GridView dan database.
        'pengecekan data pada tabel ada atau tidak
        If GridView1.RowCount <= 0 Then
            MessageBox.Show("Data tidak ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("Data akan dihapus. Lanjutkan?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'melakukan penghapusan data berdasarkan ID PENGGUNA yang kita pilih
            EksekusiSQL("delete from barang where ID_BARANG='" & GridView1.GetFocusedRowCellValue("ID_BARANG") & "'")
            Segarkan()
        End If

    End Sub

    Sub Cetak() 'Menampilkan preview cetak dari data barang.
        GridControl1.ShowRibbonPrintPreview()

    End Sub

    Sub Tutup() ' Menutup form.
        Me.Close()
    End Sub

    Sub TampilPilihanKategori() 'Mengambil data kategori dari database untuk dijadikan pilihan pada ComboBox.
        Dim kategori = EksekusiSQL("select distinct(KATEGORI) from barang").Select()
        txtKategori.Properties.Items.Clear() 'bersihkan pilihan pada kategori
        For Each Isi In kategori
            txtKategori.Properties.Items.Add(Isi.Item("KATEGORI"))
        Next
    End Sub

    Sub TampilPilihanSatuan() 'Mengambil data satuan dari database untuk dijadikan pilihan pada ComboBox.
        Dim satuan = EksekusiSQL("select distinct(SATUAN) from barang").Select()
        txtSatuan.Properties.Items.Clear() 'bersihkan pilihan pada kategori
        For Each Isi In satuan
            txtSatuan.Properties.Items.Add(Isi.Item("SATUAN"))
        Next
    End Sub



    Private Sub frmBarang_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown ' Mengatur penggunaan shortcut keyboard untuk melakukan tindakan seperti Simpan, Segarkan, Ubah, Hapus, Cetak, dan Tutup.
        Select Case e.KeyCode
            Case e.Control And Keys.S
                Simpan()
            Case Keys.F5
                Segarkan()
            Case Keys.F2
                Ubah()
            Case e.Control And Keys.D
                Hapus()
            Case e.Control And Keys.P
                Cetak()
            Case Keys.Escape
                Tutup()
        End Select
    End Sub

    Private Sub frmBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'Digunakan untuk melakukan inisialisasi saat form dimuat, seperti mengaktifkan preview keyboard, mengatur tampilan GridView, menonaktifkan pengeditan pada textbox txtStok, dan menyegarkan tampilan form.
        Me.KeyPreview = True 'mengaktifkan shortcut
        EksekusiRapikanGridView(GridView1)
        txtStok.ReadOnly = True ' menonaktifkan editan txtStok
        Segarkan()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Simpan()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Segarkan()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Ubah()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Hapus()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Cetak()
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Tutup()
    End Sub
End Class