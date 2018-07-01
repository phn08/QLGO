Public Class LoaiTienCongDTO
    Private iMaTienCong As Integer
    Private strTenLoaiTienCong As String
    Private iMucTien As Integer
    Public Sub New()
        Me.iMaTienCong = 0
        Me.iMucTien = 0
        Me.strTenLoaiTienCong = String.Empty
    End Sub

    Public Sub New(iMaTienCong As Integer, strTenLoaiTienCong As String, iMucTien As Integer)
        Me.iMaTienCong = iMaTienCong
        Me.strTenLoaiTienCong = strTenLoaiTienCong
        Me.iMucTien = iMucTien
    End Sub

    Public Property MaTienCong As Integer
        Get
            Return iMaTienCong
        End Get
        Set(value As Integer)
            iMaTienCong = value
        End Set
    End Property
    Public Property TenLoaiTienCong As String
        Get
            Return strTenLoaiTienCong
        End Get
        Set(value As String)
            strTenLoaiTienCong = value
        End Set
    End Property

    Public Property MucTien As Integer
        Get
            Return iMucTien
        End Get
        Set(value As Integer)
            iMucTien = value
        End Set
    End Property

End Class
