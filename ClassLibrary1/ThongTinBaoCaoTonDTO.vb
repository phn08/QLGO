Public Class ThongTinBaoCaoTonDTO
    Private iMaTTBaoCao As Integer
    Private iMaBaoCaoTon As Integer
    Private iMaPhuTung As Integer
    Private iTonDau As Integer
    Private iPhatSinh As Integer
    Private iTonCuoi As Integer

    Public Sub New()
        Me.iMaTTBaoCao = 0
        Me.iMaBaoCaoTon = 0
        Me.iTonDau = 0
        Me.iPhatSinh = 0
        Me.iTonCuoi = 0
    End Sub

    Public Sub New(iMaTTBaoCao As Integer, iMaBaoCaoTon As Integer, iMaPhuTung As Integer, iTonDau As Integer, iPhatSinh As Integer, iTonCuoi As Integer)
        Me.iMaTTBaoCao = iMaTTBaoCao
        Me.iMaBaoCaoTon = iMaBaoCaoTon
        Me.iMaPhuTung = iMaPhuTung
        Me.iTonDau = iTonDau
        Me.iPhatSinh = iPhatSinh
        Me.iTonCuoi = iTonCuoi
    End Sub

    Public Property MaTTBC As Integer
        Get
            Return iMaTTBaoCao
        End Get
        Set(value As Integer)
            iMaTTBaoCao = value
        End Set
    End Property
    Public Property MaBCT As Integer
        Get
            Return iMaBaoCaoTon
        End Get
        Set(value As Integer)
            iMaBaoCaoTon = value
        End Set
    End Property
    Public Property MaPhuTung As Integer
        Get
            Return iMaPhuTung
        End Get
        Set(value As Integer)
            iMaPhuTung = value
        End Set
    End Property
    Public Property TonDau As Integer
        Get
            Return iTonDau
        End Get
        Set(value As Integer)
            iTonDau = value
        End Set
    End Property
    Public Property PhatSinh As Integer
        Get
            Return iPhatSinh
        End Get
        Set(value As Integer)
            iPhatSinh = value
        End Set
    End Property

    Public Property TonCuoi As Integer
        Get
            Return iTonCuoi
        End Get
        Set(value As Integer)
            iTonCuoi = value
        End Set
    End Property
End Class
