Public Class KhachHangDTO
    Private iMaKH As Integer
    Private strTenKH As String
    Private strDiaChi As String
    Private strDienThoai As String
    Private iTienNo As Integer

    Public Sub New()
        Me.iMaKH = 0
        Me.strTenKH = String.Empty
        Me.strDiaChi = String.Empty
        Me.strDienThoai = String.Empty
        Me.iTienNo = 0
    End Sub

    Public Sub New(iMaKH As Integer, strTenKH As String, strDiaChi As String, strDienThoai As String, iTienNo As Integer)
        Me.iMaKH = iMaKH
        Me.strTenKH = strTenKH
        Me.strDiaChi = strDiaChi
        Me.strDienThoai = strDienThoai
        Me.iTienNo = iTienNo
    End Sub

    Public Property MaKH As Integer
        Get
            Return iMaKH
        End Get
        Set(value As Integer)
            iMaKH = value
        End Set
    End Property

    Public Property TenKH As String
        Get
            Return strTenKH
        End Get
        Set(value As String)
            strTenKH = value
        End Set
    End Property

    Public Property DiaChi As String
        Get
            Return strDiaChi
        End Get
        Set(value As String)
            strDiaChi = value
        End Set
    End Property

    Public Property DienThoai As String
        Get
            Return strDienThoai
        End Get
        Set(value As String)
            strDienThoai = value
        End Set
    End Property

    Public Property TienNo As Integer
        Get
            Return iTienNo
        End Get
        Set(value As Integer)
            iTienNo = value
        End Set
    End Property
End Class
