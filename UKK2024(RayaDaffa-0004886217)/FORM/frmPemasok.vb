Public Class frmPemasok 

    Dim Tampung As New DataTable 'sebuah variabel yang menampung objek DataTable untuk menampung data dari database
    Dim ID As Integer
    Sub TampilData()
        Tampung = EksekusiSQL("select * from pemasok") ' untuk menampilkan data pemasok dari tabel pemasok dalam GridControl.
        GridControl1.DataSource = Tampung

        GridView1.BestFitColumns() 'merapikan tampilan isi kolom dan baris
    End Sub

    Sub Simpan() 'menyimpan data pemasok ke dalam database. Melakukan validasi terlebih dahulu untuk memastikan bahwa inputan tidak kosong. Jika ID masih bernilai 0, maka data baru akan ditambahkan ke dalam tabel, jika tidak, maka data lama akan diubah.

        'validasi inputan
        If txtNama.Text = "" Then
            MessageBox.Show("Nama,wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If ID = 0 Then
            'input data baru
            EksekusiSQL("INSERT INTO `pemasok`(`NAMA_PEMASOK`, `ALAMAT`, `NOMOR_TELEPON`) VALUES ('" & txtNama.Text & "','" & txtAlamat.Text & "','" & txtTelepon.Text & "')")
            Segarkan()
            MessageBox.Show("Data Berhasil Ditambahkan", "informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'ubah data lama
            EksekusiSQL("UPDATE `pemasok` SET `NAMA_PEMASOK`='" & txtNama.Text & "',`ALAMAT`='" & txtAlamat.Text & "',`NOMOR_TELEPON`='" & txtTelepon.Text & "' WHERE `ID_PEMASOK`='" & ID & "'")
            Segarkan()
            MessageBox.Show("Data Berhasil Diubah", "informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Sub Segarkan() 'Membersihkan form dan mengosongkan inputan, kemudian memanggil sub TampilData.
        TampilData()
        ID = 0
        txtNama.Text = ""
        txtAlamat.Text = ""
        txtTelepon.Text = ""
        txtNama.Focus() 'arahkan kursor fokus ke txtNama
    End Sub

    Sub Ubah() ' Mengisi inputan form dengan data pemasok yang dipilih dari GridControl untuk kemungkinan pengubahan data.
        'pengecekan data pada tabel ada atau tidak
        If GridView1.RowCount <= 0 Then
            MessageBox.Show("Data tidak ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'menghasilkan
        ID = GridView1.GetFocusedRowCellValue("ID_PEMASOK")
        txtNama.Text = GridView1.GetFocusedRowCellValue("NAMA_PEMASOK")
        txtAlamat.Text = GridView1.GetFocusedRowCellValue("ALAMAT")
        txtTelepon.Text = GridView1.GetFocusedRowCellValue("NOMOR_TELEPON")
        txtNama.Focus()

    End Sub

    Sub Hapus() ' Menghapus data pemasok yang dipilih dari GridControl setelah konfirmasi dari pengguna.
        'pengecekan data pada tabel ada atau tidak
        If GridView1.RowCount <= 0 Then
            MessageBox.Show("Data tidak ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("Data akan dihapus. Lanjutkan?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'melakukan penghapusan data berdasarkan ID PENGGUNA yang kita pilih
            EksekusiSQL("delete from pemasok where ID_PEMASOK='" & GridView1.GetFocusedRowCellValue("ID_PEMASOK") & "'")
            Segarkan()
        End If

    End Sub

    Sub Cetak()
        GridControl1.ShowRibbonPrintPreview()

    End Sub

    Sub Tutup()
        Me.Close()
    End Sub

    Private Sub frmPemasok_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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


    Private Sub frmPemasok_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.KeyPreview = True 'mengaktifkan shortcut
        EksekusiRapikanGridView(GridView1)
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