<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHome
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PhiếuTiếpNhậnXeSửaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PhiếuThuTiềnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PhiếuSửaChữaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DanhSáchXeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BáoCáoTồnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoanhSốToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PhiếuTiếpNhậnXeSửaToolStripMenuItem, Me.PhiếuThuTiềnToolStripMenuItem, Me.PhiếuSửaChữaToolStripMenuItem, Me.DanhSáchXeToolStripMenuItem, Me.BáoCáoTồnToolStripMenuItem, Me.DoanhSốToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'PhiếuTiếpNhậnXeSửaToolStripMenuItem
        '
        Me.PhiếuTiếpNhậnXeSửaToolStripMenuItem.Name = "PhiếuTiếpNhậnXeSửaToolStripMenuItem"
        Me.PhiếuTiếpNhậnXeSửaToolStripMenuItem.Size = New System.Drawing.Size(145, 20)
        Me.PhiếuTiếpNhậnXeSửaToolStripMenuItem.Text = "Phiếu Tiếp Nhận Xe Sửa"
        '
        'PhiếuThuTiềnToolStripMenuItem
        '
        Me.PhiếuThuTiềnToolStripMenuItem.Name = "PhiếuThuTiềnToolStripMenuItem"
        Me.PhiếuThuTiềnToolStripMenuItem.Size = New System.Drawing.Size(99, 20)
        Me.PhiếuThuTiềnToolStripMenuItem.Text = "Phiếu Thu Tiền"
        '
        'PhiếuSửaChữaToolStripMenuItem
        '
        Me.PhiếuSửaChữaToolStripMenuItem.Name = "PhiếuSửaChữaToolStripMenuItem"
        Me.PhiếuSửaChữaToolStripMenuItem.Size = New System.Drawing.Size(102, 20)
        Me.PhiếuSửaChữaToolStripMenuItem.Text = "Phiếu Sửa Chữa"
        '
        'DanhSáchXeToolStripMenuItem
        '
        Me.DanhSáchXeToolStripMenuItem.Name = "DanhSáchXeToolStripMenuItem"
        Me.DanhSáchXeToolStripMenuItem.Size = New System.Drawing.Size(91, 20)
        Me.DanhSáchXeToolStripMenuItem.Text = "Danh Sách Xe"
        '
        'BáoCáoTồnToolStripMenuItem
        '
        Me.BáoCáoTồnToolStripMenuItem.Name = "BáoCáoTồnToolStripMenuItem"
        Me.BáoCáoTồnToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.BáoCáoTồnToolStripMenuItem.Text = "Báo Cáo Tồn"
        '
        'DoanhSốToolStripMenuItem
        '
        Me.DoanhSốToolStripMenuItem.Name = "DoanhSốToolStripMenuItem"
        Me.DoanhSốToolStripMenuItem.Size = New System.Drawing.Size(117, 20)
        Me.DoanhSốToolStripMenuItem.Text = "Báo Cáo Doanh Số"
        '
        'frmHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmHome"
        Me.Text = "frmHome"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents PhiếuTiếpNhậnXeSửaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PhiếuThuTiềnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PhiếuSửaChữaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DanhSáchXeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BáoCáoTồnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DoanhSốToolStripMenuItem As ToolStripMenuItem
End Class
