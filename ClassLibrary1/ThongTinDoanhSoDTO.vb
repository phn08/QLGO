Public Class ThongTinDoanhSoDTO
    Private iMaTTDS As Integer
    Private iMaDoanhSoThang As Integer
    Private iMaHX As Integer
    Private iSoLuotSua As Integer
    Private iThanhTien As Integer
    Private dTiLe As Double
    Public Sub New()
        Me.iMaTTDS = 0
        Me.iMaDoanhSoThang = 0
        Me.iSoLuotSua = 0
        Me.iThanhTien = 0
        Me.dTiLe = 0
    End Sub

    Public Sub New(iMaTTDS As Integer, iMaDoanhSoThang As Integer, iMaHX As Integer, iSoLuotSua As Integer, iThanhTien As Integer, dTiLe As Double)
        Me.iMaTTDS = iMaTTDS
        Me.iMaDoanhSoThang = iMaDoanhSoThang
        Me.iMaHX = iMaHX
        Me.iSoLuotSua = iSoLuotSua
        Me.iThanhTien = iThanhTien
        Me.dTiLe = dTiLe
    End Sub

    Public Property MaTTDS As Integer
        Get
            Return iMaTTDS
        End Get
        Set(value As Integer)
            iMaTTDS = value
        End Set
    End Property
    Public Property MaDST As Integer
        Get
            Return iMaDoanhSoThang
        End Get
        Set(value As Integer)
            iMaDoanhSoThang = value
        End Set
    End Property
    Public Property MaHX As Integer
        Get
            Return iMaHX
        End Get
        Set(value As Integer)
            iMaHX = value
        End Set
    End Property
    Public Property SoLuotSua As Integer
        Get
            Return iSoLuotSua
        End Get
        Set(value As Integer)
            iSoLuotSua = value
        End Set
    End Property
    Public Property ThanhTien As Integer
        Get
            Return iThanhTien
        End Get
        Set(value As Integer)
            iThanhTien = value
        End Set
    End Property

    Public Property TiLe As Double
        Get
            Return dTiLe
        End Get
        Set(value As Double)
            dTiLe = value
        End Set
    End Property
End Class
