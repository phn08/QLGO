Public Class PhieuTiepNhanDTO
    Private iMaPhieuTN As Integer
    Private iMaTTXe As Integer
    Private dtNgayNhan As DateTime

    Public Sub New()
        Me.iMaPhieuTN = 0
        Me.dtNgayNhan = DateTime.Now
        Me.iMaTTXe = 0
    End Sub

    Public Sub New(iMaPhieuTN As Integer, iMaTTXe As Integer, dtNgayNhan As DateTime)
        Me.iMaPhieuTN = iMaPhieuTN
        Me.iMaTTXe = iMaTTXe
        Me.dtNgayNhan = dtNgayNhan
    End Sub

    Public Property MaPhieuTN As Integer
        Get
            Return iMaPhieuTN
        End Get
        Set(value As Integer)
            iMaPhieuTN = value
        End Set
    End Property
    Public Property MaTTXe As Integer
        Get
            Return iMaTTXe
        End Get
        Set(value As Integer)
            iMaTTXe = value
        End Set
    End Property

    Public Property NgayNhan As DateTime
        Get
            Return dtNgayNhan
        End Get
        Set(value As DateTime)
            dtNgayNhan = value
        End Set
    End Property
End Class
