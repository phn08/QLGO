Public Class BaoCaoTonDTO
    Private iMaBaoCaoTon As Integer
    Private dtThang As DateTime

    Private lsTTBaoCao As List(Of ThongTinBaoCaoTonDTO)
    Public Sub New()
        Me.iMaBaoCaoTon = 0
        Me.dtThang = DateTime.Now
        Me.lsTTBaoCao = New List(Of ThongTinBaoCaoTonDTO)
    End Sub

    Public Sub New(iMaBaoCaoTon As Integer, dtThang As DateTime, lsTTBaoCao As List(Of ThongTinBaoCaoTonDTO))
        Me.iMaBaoCaoTon = iMaBaoCaoTon
        Me.dtThang = dtThang
        Me.lsTTBaoCao = lsTTBaoCao
    End Sub

    Public Property MaBCT As Integer
        Get
            Return iMaBaoCaoTon
        End Get
        Set(value As Integer)
            iMaBaoCaoTon = value
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

    Public Property ListTTBC As List(Of ThongTinBaoCaoTonDTO)
        Get
            Return lsTTBaoCao
        End Get
        Set(value As List(Of ThongTinBaoCaoTonDTO))
            lsTTBaoCao = value
        End Set
    End Property
End Class
