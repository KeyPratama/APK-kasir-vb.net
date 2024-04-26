Public Class frmPengguna
    Dim Tampung As New DataTable 'sebuah variabel yang menampung objek DataTable untuk menampung data dari database
    Dim ID As Integer

    Sub TampilData()  'menampilkan data pengguna dari tabel Pengguna dalam GridControl. Kolom PASSWORD disembunyikan agar tidak                          terlihat dalam tampilan.
        Tampung = EksekusiSQL("select * from Pengguna")
        GridControl1.DataSource = Tampung
        GridView1.Columns("PASSWORD").Visible = False 'sembunyikan kolom PASSWORD
        GridView1.BestFitColumns() 'merapikan tampilan isi kolom dan baris
    End Sub

    Sub Simpan() ' menyimpan data pengguna ke dalam database. Melakukan validasi terlebih dahulu untuk memastikan bahwa inputan tidak kosong. Jika ID masih bernilai 0, maka data baru akan ditambahkan ke dalam tabel, jika tidak, maka data lama akan diubah.

        'validasi inputan
        If txtNama.Text = "" Or txtUsername.Text = "" Or txtPassword.Text = "" Or txtHakAkses.Text = "" Then
            MessageBox.Show("Nama, Username, Password, dan Hak Akses wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If ID = 0 Then
            'input data baru
            EksekusiSQL("INSERT INTO `pengguna`(`NAMA_PENGGUNA`, `ALAMAT`, `NOMOR_TELEPON`, `USERNAME`, `PASSWORD`, `HAK_AKSES`) VALUES ('" & txtNama.Text & "','" & txtAlamat.Text & "','" & txtNoTelepon.Text & "','" & txtUsername.Text & "','" & txtPassword.Text & "','" & txtHakAkses.Text & "')")
            Segarkan()
            MessageBox.Show("Data Berhasil Ditambahkan", "informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'ubah data lama
            EksekusiSQL("UPDATE `pengguna` SET `NAMA_PENGGUNA`='" & txtNama.Text & "',`ALAMAT`='" & txtAlamat.Text & "',`NOMOR_TELEPON`='" & txtNoTelepon.Text & "',`USERNAME`='" & txtUsername.Text & "',`PASSWORD`='" & txtPassword.Text & "',`HAK_AKSES`='" & txtHakAkses.Text & "' WHERE `ID_PENGGUNA`='" & ID & "'")
            Segarkan()
            MessageBox.Show("Data Berhasil Diubah", "informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Sub Segarkan() ' Membersihkan form dan mengosongkan inputan, kemudian memanggil sub TampilData. Selain itu, mengatur ulang nilai ID dan memfokuskan kursor ke inputan txtNama.
        TampilData()
        ID = 0
        txtNama.Text = ""
        txtAlamat.Text = ""
        txtNoTelepon.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtHakAkses.SelectedIndex = -1
        txtNama.Focus() 'arahkan kursor fokus ke txtNama
    End Sub

    Sub Ubah() ' Mengisi inputan form dengan data pengguna yang dipilih dari GridControl untuk kemungkinan pengubahan data.
        'pengecekan data pada tabel ada atau tidak
        If GridView1.RowCount <= 0 Then
            MessageBox.Show("Data tidak ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'menghasilkan
        ID = GridView1.GetFocusedRowCellValue("ID_PENGGUNA")
        txtNama.Text = GridView1.GetFocusedRowCellValue("NAMA_PENGGUNA")
        txtAlamat.Text = GridView1.GetFocusedRowCellValue("ALAMAT")
        txtNoTelepon.Text = GridView1.GetFocusedRowCellValue("NOMOR_TELEPON")
        txtUsername.Text = GridView1.GetFocusedRowCellValue("USERNAME")
        txtPassword.Text = GridView1.GetFocusedRowCellValue("PASSWORD")
        txtHakAkses.Text = GridView1.GetFocusedRowCellValue("HAK_AKSES")
        txtNama.Focus()

    End Sub

    Sub Hapus() 'Menghapus data pengguna yang dipilih dari GridControl setelah konfirmasi dari pengguna.
        'pengecekan data pada tabel ada atau tidak
        If GridView1.RowCount <= 0 Then
            MessageBox.Show("Data tidak ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("Data akan dihapus. Lanjutkan?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'melakukan penghapusan data berdasarkan ID PENGGUNA yang kita pilih
            EksekusiSQL("delete from pengguna where ID_PENGGUNA='" & GridView1.GetFocusedRowCellValue("ID_PENGGUNA") & "'")
            Segarkan()
        End If

    End Sub

    Sub Cetak()
        GridControl1.ShowRibbonPrintPreview()

    End Sub

    Sub Tutup()
        Me.Close()
    End Sub

    Private Sub frmMasterPengguna_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub frmMasterPengguna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True 'mengaktifkan shortcut
        EksekusiRapikanGridView(GridView1)
        txtPassword.Properties.UseSystemPasswordChar = True
        txtHakAkses.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
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