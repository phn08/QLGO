Public Class PhieuSuaChuaDTO
    Private iMaPhieuTN As Integer
    Private iMaPhieuSC As Integer
    Private dtNgaySC As DateTime

    Private lsTTSC As List(Of ThongTinPhieuSuaChuaDTO)

    Public Sub New()
        Me.iMaPhieuTN = 0
        Me.dtNgaySC = DateTime.Now
        Me.iMaPhieuSC = 0
        Me.lsTTSC = New List(Of ThongTinPhieuSuaChuaDTO)
    End Sub

    Public Sub New(iMaPhieuSC As Integer, iMaPhieuTN As Integer, dtNgaySC As DateTime, lsTTSC As List(Of ThongTinPhieuSuaChuaDTO))
        Me.iMaPhieuTN = iMaPhieuTN
        Me.iMaPhieuSC = iMaPhieuSC
        Me.dtNgaySC = dtNgaySC
        Me.lsTTSC = lsTTSC
    End Sub

    Public Property MaPhieuTN As Integer
        Get
            Return iMaPhieuTN
        End Get
        Set(value As Integer)
            iMaPhieuTN = value
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

    Public Property NgaySC As DateTime
        Get
            Return dtNgaySC
        End Get
        Set(value As DateTime)
            dtNgaySC = value
        End Set
    End Property

    Public Property ListTTSC As List(Of ThongTinPhieuSuaChuaDTO)
        Get
            Return lsTTSC
        End Get
        Set(value As List(Of ThongTinPhieuSuaChuaDTO))
            lsTTSC = value
        End Set
    End Property
End Class

