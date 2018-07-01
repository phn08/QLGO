Public Class ThongTinPhieuSuaChuaDTO
    Private iMaTTPhieuSC
    Private iMaPhuTung As Integer
    Private iMaPhieuSC As Integer
    Private strNoiDung As String
    Private iSoLuong As Integer
    Private iMaTienCong As Integer

    Public Sub New()
        Me.iMaTTPhieuSC = 0
        Me.iMaPhuTung = 0
        Me.strNoiDung = String.Empty
        Me.iMaPhieuSC = 0
        Me.iSoLuong = 0
        Me.iMaTienCong = 0
    End Sub

    Public Sub New(iMaTTPhieuSC As Integer, iMaPhieuSC As Integer, iMaPhuTung As Integer, strNoiDung As String, iSoLuong As Integer, iMaTienCong As Integer)
        Me.iMaTTPhieuSC = iMaTTPhieuSC
        Me.iMaPhuTung = iMaPhuTung
        Me.iMaPhieuSC = iMaPhieuSC
        Me.strNoiDung = strNoiDung
        Me.iSoLuong = iSoLuong
        Me.iMaTienCong = iMaTienCong
    End Sub

    Public Property MaTTPSC As Integer
        Get
            Return iMaTTPhieuSC
        End Get
        Set(value As Integer)
            iMaTTPhieuSC = value
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
    Public Property MaPhieuSC As Integer
        Get
            Return iMaPhieuSC
        End Get
        Set(value As Integer)
            iMaPhieuSC = value
        End Set
    End Property

    Public Property NoiDung As DateTime
        Get
            Return strNoiDung
        End Get
        Set(value As DateTime)
            strNoiDung = value
        End Set
    End Property

    Public Property SoLuong As Integer
        Get
            Return iSoLuong
        End Get
        Set(value As Integer)
            iSoLuong = value
        End Set
    End Property

    Public Property MaTienCong As Integer
        Get
            Return iMaTienCong
        End Get
        Set(value As Integer)
            iMaTienCong = value
        End Set
    End Property
End Class


