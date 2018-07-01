Imports System.Configuration
Imports System.Data.SqlClient
Imports QLGO1DTO
Imports Utility

Public Class KhachHangDAL
    Private connectionString As String

    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub

    Public Function getNextID(ByRef nextID As Integer) As Result

        Dim query As String = String.Empty
        query &= "SELECT TOP 1 [makh] "
        query &= "FROM [tblkhachhang] "
        query &= "ORDER BY [makh] DESC "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    Dim idOnDB As Integer
                    idOnDB = Nothing
                    If reader.HasRows = True Then
                        While reader.Read()
                            idOnDB = reader("makh")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextID = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextID = 1
                    Return New Result(False, "Lấy ID kế tiếp của Khách Hàng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function insert(kh As KhachHangDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [dbo].[tblkhachhang] "
        query &= "(  [makh] "
        query &= "  ,[tenkh] "
        query &= "  ,[diachi] "
        query &= "  ,[dienthoai]"
        query &= "  ,[tienno])"
        query &= "VALUES "
        query &= "(  @makh "
        query &= "  ,@tenkh "
        query &= "  ,@diachi "
        query &= "  ,@dienthoai "
        query &= "  ,@tienno) "

        Dim nextID = 0
        Dim result As Result
        result = getNextID(nextID)
        If (result.FlagResult = False) Then
            Return result
        End If
        kh.MaKH = nextID

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mahx", kh.MaKH)
                    .Parameters.AddWithValue("@tenhx", kh.TenKH)
                    .Parameters.AddWithValue("@diachi", kh.DiaChi)
                    .Parameters.AddWithValue("@dienthoai", kh.DienThoai)
                    .Parameters.AddWithValue("@tienno", kh.TienNo)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm Khách Hàng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function delete(iMaKH) As Result
        Dim query As String = String.Empty
        query &= " DELETE FROM [dbo].[tblkhachhang] "
        query &= " WHERE "
        query &= " [makh] = @makh "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@makh", iMaKH)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Khách Hàng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True) ' thanh cong
    End Function

    Public Function select_byMaKH(iMaKH As Integer, listKH As List(Of KhachHangDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [makh], [tenkh], [diachi], [dienthoai], [tienno]"
        query &= " FROM [tblkhachhang]"
        query &= " WHERE "
        query &= " [makh] = @makh"


        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@makh", iMaKH)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listKH.Clear()
                        While reader.Read()
                            listKH.Add(New KhachHangDTO(reader("mahx"), reader("tenhx"), reader("diachi"), reader("dienthoai"), reader("tienno")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Khách Hàng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALL(listKH As List(Of KhachHangDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [makh], [tenkh], [diachi], [dienthoai], [tienno]"
        query &= " FROM [tblkhachhang]"


        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listKH.Clear()
                        While reader.Read()
                            listKH.Add(New KhachHangDTO(reader("mahx"), reader("tenhx"), reader("diachi"), reader("dienthoai"), reader("tienno")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Khách Hàng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function


    Public Function update(kh As KhachHangDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblkhachhang] SET "
        query &= "   [tenkh] = @tenkh "
        query &= "  ,[diachi] = @diachi "
        query &= "  ,[dienthoai] = @dienthoai "
        query &= "  ,[tienno] = @tienno"
        query &= "WHERE "
        query &= " [makh] = @makh"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@tenkh", kh.TenKH)
                    .Parameters.AddWithValue("@diachi", kh.DiaChi)
                    .Parameters.AddWithValue("@dienthoai", kh.DienThoai)
                    .Parameters.AddWithValue("@tienno", kh.TienNo)
                    .Parameters.AddWithValue("@makh", kh.MaKH)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật Khách Hàng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
