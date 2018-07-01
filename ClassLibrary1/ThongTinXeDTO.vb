Public Class ThongTinXeDTO
    Private iMaTTXe As Integer
    Private iMaKH As Integer
    Private iMaHX As Integer
    Private strBienSo As String

    Public Sub New()
        Me.iMaTTXe = 0
        Me.iMaKH = 0
        Me.iMaHX = 0
        Me.strBienSo = String.Empty
    End Sub

    Public Sub New(iMaTTXe As Integer, iMaKH As Integer, iMaHX As Integer, strBienSo As String)
        Me.iMaTTXe = iMaTTXe
        Me.strBienSo = strBienSo
        Me.iMaKH = iMaKH
        Me.iMaHX = iMaHX
    End Sub

    Public Property MaTTXe As Integer
        Get
            Return iMaTTXe
        End Get
        Set(value As Integer)
            iMaTTXe = value
        End Set
    End Property

    Public Property BienSo As String
        Get
            Return strBienSo
        End Get
        Set(value As String)
            strBienSo = value
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

    Public Property MaKH As Integer
        Get
            Return iMaKH
        End Get
        Set(value As Integer)
            iMaKH = value
        End Set
    End Property
End Class

