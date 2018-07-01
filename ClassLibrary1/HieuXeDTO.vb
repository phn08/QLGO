Public Class HieuXeDTO
    Private iMaHX As Integer
    Private strTenHX As String

    Public Sub New()
        Me.iMaHX = 0
        Me.strTenHX = String.Empty
    End Sub

    Public Sub New(iMaHX As Integer, strTenHX As String)
        Me.iMaHX = iMaHX
        Me.strTenHX = strTenHX
    End Sub

    Public Property MaHX As Integer
        Get
            Return iMaHX
        End Get
        Set(value As Integer)
            iMaHX = value
        End Set
    End Property

    Public Property TenHX As String
        Get
            Return strTenHX
        End Get
        Set(value As String)
            strTenHX = value
        End Set
    End Property
End Class
