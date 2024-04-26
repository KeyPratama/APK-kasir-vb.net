<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetupKonfigurasiKoneksi
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetupKonfigurasiKoneksi))
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPortal = New DevExpress.XtraEditors.SpinEdit()
        Me.txtNamaDatabase = New DevExpress.XtraEditors.TextEdit()
        Me.txtKataSandi = New DevExpress.XtraEditors.TextEdit()
        Me.txtNamaUser = New DevExpress.XtraEditors.TextEdit()
        Me.txtNamaServer = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtPortal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNamaDatabase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKataSandi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNamaUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNamaServer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureEdit1
        '
        Me.PictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureEdit1.EditValue = CType(resources.GetObject("PictureEdit1.EditValue"), Object)
        Me.PictureEdit1.Location = New System.Drawing.Point(0, -1)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(96, 85)
        Me.PictureEdit1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(99, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(344, 33)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "KONFIGURASI KONEKSI"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.txtPortal)
        Me.GroupControl1.Controls.Add(Me.txtNamaDatabase)
        Me.GroupControl1.Controls.Add(Me.txtKataSandi)
        Me.GroupControl1.Controls.Add(Me.txtNamaUser)
        Me.GroupControl1.Controls.Add(Me.txtNamaServer)
        Me.GroupControl1.Location = New System.Drawing.Point(12, 90)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(539, 289)
        Me.GroupControl1.TabIndex = 3
        Me.GroupControl1.Text = "Detail Konfigurasi Koneksi"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(11, 249)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(52, 19)
        Me.LabelControl5.TabIndex = 13
        Me.LabelControl5.Text = "Portal :"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(10, 197)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(121, 19)
        Me.LabelControl4.TabIndex = 12
        Me.LabelControl4.Text = "Nama Database :"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(10, 156)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(85, 19)
        Me.LabelControl3.TabIndex = 11
        Me.LabelControl3.Text = "Kata Sandi :"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(11, 106)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(89, 19)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "Nama User :"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(10, 61)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(102, 19)
        Me.LabelControl1.TabIndex = 10
        Me.LabelControl1.Text = "Nama Server :"
        '
        'txtPortal
        '
        Me.txtPortal.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPortal.Location = New System.Drawing.Point(142, 246)
        Me.txtPortal.Name = "txtPortal"
        Me.txtPortal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPortal.Size = New System.Drawing.Size(391, 26)
        Me.txtPortal.TabIndex = 9
        '
        'txtNamaDatabase
        '
        Me.txtNamaDatabase.Location = New System.Drawing.Point(142, 194)
        Me.txtNamaDatabase.Name = "txtNamaDatabase"
        Me.txtNamaDatabase.Size = New System.Drawing.Size(391, 26)
        Me.txtNamaDatabase.TabIndex = 7
        '
        'txtKataSandi
        '
        Me.txtKataSandi.Location = New System.Drawing.Point(142, 149)
        Me.txtKataSandi.Name = "txtKataSandi"
        Me.txtKataSandi.Size = New System.Drawing.Size(391, 26)
        Me.txtKataSandi.TabIndex = 6
        '
        'txtNamaUser
        '
        Me.txtNamaUser.Location = New System.Drawing.Point(142, 103)
        Me.txtNamaUser.Name = "txtNamaUser"
        Me.txtNamaUser.Size = New System.Drawing.Size(391, 26)
        Me.txtNamaUser.TabIndex = 5
        '
        'txtNamaServer
        '
        Me.txtNamaServer.Location = New System.Drawing.Point(142, 58)
        Me.txtNamaServer.Name = "txtNamaServer"
        Me.txtNamaServer.Size = New System.Drawing.Size(391, 26)
        Me.txtNamaServer.TabIndex = 4
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageIndex = 0
        Me.SimpleButton1.ImageList = Me.ImageCollection1
        Me.SimpleButton1.Location = New System.Drawing.Point(10, 385)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(148, 56)
        Me.SimpleButton1.TabIndex = 4
        Me.SimpleButton1.Text = "Tes Koneksi"
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "C3M (685).png")
        Me.ImageCollection1.Images.SetKeyName(1, "C3M (686).png")
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageIndex = 0
        Me.SimpleButton2.ImageList = Me.ImageCollection1
        Me.SimpleButton2.Location = New System.Drawing.Point(181, 385)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(118, 56)
        Me.SimpleButton2.TabIndex = 5
        Me.SimpleButton2.Text = "Simpan"
        '
        'frmSetupKonfigurasiKoneksi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 446)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureEdit1)
        Me.Name = "frmSetupKonfigurasiKoneksi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Konfigurasi Koneksi"
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtPortal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNamaDatabase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKataSandi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNamaUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNamaServer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPortal As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtNamaDatabase As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtKataSandi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNamaUser As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNamaServer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
End Class
