Public Class PhieuThuTienDTO
    Private iMaPhieuThuTien As Integer
    Private iMaPhieuTN As Integer
    Private dtNgayThuTien As DateTime
    Private iSoTienThu As Integer

    Public Sub New()
        Me.iMaPhieuThuTien = 0
        Me.iSoTienThu = 0
        Me.iMaPhieuTN = 0
        Me.dtNgayThuTien = DateTime.Now
    End Sub

    Public Sub New(iMaPhieuThuTien As Integer, iMaPhieuTN As Integer, iSoTienThu As Integer, dtNgayThuTien As DateTime)
        Me.iMaPhieuThuTien = iMaPhieuThuTien
        Me.iSoTienThu = iSoTienThu
        Me.iMaPhieuTN = iMaPhieuTN
        Me.dtNgayThuTien = dtNgayThuTien
    End Sub

    Public Property MaPhieuThuTien As Integer
        Get
            Return iMaPhieuThuTien
        End Get
        Set(value As Integer)
            iMaPhieuThuTien = value
        End Set
    End Property

    Public Property SoTienThu As Integer
        Get
            Return iSoTienThu
        End Get
        Set(value As Integer)
            iSoTienThu = value
        End Set
    End Property

    Public Property MaPhieuTN As Integer
        Get
            Return iMaPhieuTN
        End Get
        Set(value As Integer)
            iMaPhieuTN = value
        End Set
    End Property

    Public Property NgayThuTien As DateTime
        Get
            Return dtNgayThuTien
        End Get
        Set(value As DateTime)
            dtNgayThuTien = value
        End Set
    End Property
End Class
