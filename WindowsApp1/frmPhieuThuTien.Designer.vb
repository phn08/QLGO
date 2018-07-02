<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPhieuThuTien
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cbTN = New System.Windows.Forms.ComboBox()
        Me.tbKH = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbPhone = New System.Windows.Forms.TextBox()
        Me.tbSoTien = New System.Windows.Forms.TextBox()
        Me.tbBienSo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpNgayThuTien = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbTN
        '
        Me.cbTN.FormattingEnabled = True
        Me.cbTN.Location = New System.Drawing.Point(12, 52)
        Me.cbTN.Name = "cbTN"
        Me.cbTN.Size = New System.Drawing.Size(160, 31)
        Me.cbTN.TabIndex = 14
        '
        'tbKH
        '
        Me.tbKH.Location = New System.Drawing.Point(30, 204)
        Me.tbKH.Name = "tbKH"
        Me.tbKH.ReadOnly = True
        Me.tbKH.Size = New System.Drawing.Size(193, 32)
        Me.tbKH.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 21)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Mã phiếu tiếp nhận"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpNgayThuTien)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.tbPhone)
        Me.GroupBox1.Controls.Add(Me.tbSoTien)
        Me.GroupBox1.Controls.Add(Me.tbBienSo)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbTN)
        Me.GroupBox1.Controls.Add(Me.tbKH)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(800, 450)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(528, 287)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(180, 64)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "Lập phiếu thu"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbPhone
        '
        Me.tbPhone.Location = New System.Drawing.Point(30, 305)
        Me.tbPhone.Name = "tbPhone"
        Me.tbPhone.ReadOnly = True
        Me.tbPhone.Size = New System.Drawing.Size(193, 32)
        Me.tbPhone.TabIndex = 23
        '
        'tbSoTien
        '
        Me.tbSoTien.Location = New System.Drawing.Point(528, 204)
        Me.tbSoTien.Name = "tbSoTien"
        Me.tbSoTien.Size = New System.Drawing.Size(193, 32)
        Me.tbSoTien.TabIndex = 22
        '
        'tbBienSo
        '
        Me.tbBienSo.Location = New System.Drawing.Point(275, 204)
        Me.tbBienSo.Name = "tbBienSo"
        Me.tbBienSo.ReadOnly = True
        Me.tbBienSo.Size = New System.Drawing.Size(193, 32)
        Me.tbBienSo.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 26.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(283, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(283, 41)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "PHIẾU THU TIỀN"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(271, 269)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 21)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Ngày thu tiền"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 269)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 21)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Số điện thoại"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(524, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 21)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Số tiền thu"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(271, 180)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 21)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Biển số xe"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 180)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 21)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Tên chủ xe"
        '
        'dtpNgayThuTien
        '
        Me.dtpNgayThuTien.CustomFormat = "dd/MM/yyyy"
        Me.dtpNgayThuTien.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgayThuTien.Location = New System.Drawing.Point(275, 305)
        Me.dtpNgayThuTien.Name = "dtpNgayThuTien"
        Me.dtpNgayThuTien.Size = New System.Drawing.Size(200, 32)
        Me.dtpNgayThuTien.TabIndex = 26
        '
        'frmPhieuThuTien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmPhieuThuTien"
        Me.Text = "Phiếu thu tiền"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cbTN As ComboBox
    Friend WithEvents tbKH As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents tbPhone As TextBox
    Friend WithEvents tbSoTien As TextBox
    Friend WithEvents tbBienSo As TextBox
    Friend WithEvents dtpNgayThuTien As DateTimePicker
End Class
