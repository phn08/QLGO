Public Class DoanhSoDTO
    Private iMaDoanhSoThang As Integer
    Private iTongDoanhThu As Integer
    Private dtThang As DateTime

    Private lsTTDS As List(Of ThongTinDoanhSoDTO)
    Public Sub New()
        Me.iMaDoanhSoThang = 0
        Me.dtThang = DateTime.Now
        Me.iTongDoanhThu = 0
        Me.lsTTDS = New List(Of ThongTinDoanhSoDTO)
    End Sub

    Public Sub New(iMaDoanhSoThang As Integer, iTongDoanhThu As Integer, dtThang As DateTime, lsTTDS As List(Of ThongTinDoanhSoDTO))
        Me.iMaDoanhSoThang = iMaDoanhSoThang
        Me.iTongDoanhThu = iTongDoanhThu
        Me.dtThang = dtThang
        Me.lsTTDS = lsTTDS
    End Sub

    Public Property MaDST As Integer
        Get
            Return iMaDoanhSoThang
        End Get
        Set(value As Integer)
            iMaDoanhSoThang = value
        End Set
    End Property
    Public Property TongDoanhThu As Integer
        Get
            Return iTongDoanhThu
        End Get
        Set(value As Integer)
            iTongDoanhThu = value
        End Set
    End Property

    Public Property Thang As DateTime
        Get
            Return dtThang
        End Get
        Set(value As DateTime)
            dtThang = value
        End Set
    End Property

    Public Property ListTTDS As List(Of ThongTinDoanhSoDTO)
        Get
            Return lsTTDS
        End Get
        Set(value As List(Of ThongTinDoanhSoDTO))
            lsTTDS = value
        End Set
    End Property
End Class
