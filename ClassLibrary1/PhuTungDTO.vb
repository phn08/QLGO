Public Class PhuTungDTO
    Private iMaPhuTung As Integer
    Private strTenPhuTung As String
    Private iDonGia As Integer
    Private iSoLuongCon As Integer

    Public Sub New()
        Me.iMaPhuTung = 0
        Me.strTenPhuTung = String.Empty
        Me.iDonGia = 0
        Me.iSoLuongCon = 0
    End Sub

    Public Sub New(iMaPhuTung As Integer, strTenPhuTung As String, iDonGia As Integer, iSoLuongCon As Integer)
        Me.iMaPhuTung = iMaPhuTung
        Me.strTenPhuTung = strTenPhuTung
        Me.iDonGia = iDonGia
        Me.iSoLuongCon = iSoLuongCon
    End Sub

    Public Property MaPhuTung As Integer
        Get
            Return iMaPhuTung
        End Get
        Set(value As Integer)
            iMaPhuTung = value
        End Set
    End Property

    Public Property TenPhuTung As String
        Get
            Return strTenPhuTung
        End Get
        Set(value As String)
            strTenPhuTung = value
        End Set
    End Property

    Public Property SoLuongCon As Integer
        Get
            Return iSoLuongCon
        End Get
        Set(value As Integer)
            iSoLuongCon = value
        End Set
    End Property

    Public Property DonGia As Integer
        Get
            Return iDonGia
        End Get
        Set(value As Integer)
            iDonGia = value
        End Set
    End Property
End Class

