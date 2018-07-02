Imports System.Configuration
Imports System.Data.SqlClient
Imports QLGO1DTO
Imports Utility

Public Class PhuTungDAL
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
        query &= "SELECT TOP 1 [maphutung] "
        query &= "FROM [tblphutung] "
        query &= "ORDER BY [maphutung] DESC "

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
                            idOnDB = reader("maphutung")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextID = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextID = 1
                    Return New Result(False, "Lấy ID kế tiếp của Phụ Tùng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function insert(pt As PhuTungDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [dbo].[tblphutung] "
        query &= "(  [maphutung] "
        query &= "  ,[tenphutung] "
        query &= "  ,[dongia] "
        query &= "  ,[soluongcon]) "
        query &= "VALUES "
        query &= "(  @maphutung "
        query &= "  ,@tenphutung "
        query &= "  ,@dongia "
        query &= "  ,@soluongcon) "

        Dim nextID = 0
        Dim result As Result
        result = getNextID(nextID)
        If (result.FlagResult = False) Then
            Return result
        End If
        pt.MaPhuTung = nextID

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maphutung", pt.MaPhuTung)
                    .Parameters.AddWithValue("@tenphutung", pt.TenPhuTung)
                    .Parameters.AddWithValue("@dongia", pt.DonGia)
                    .Parameters.AddWithValue("@soluongcon", pt.SoLuongCon)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm Phụ Tùng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function delete(iMaPhuTung As Integer) As Result
        Dim query As String = String.Empty
        query &= " DELETE FROM [dbo].[tblphutung] "
        query &= " WHERE "
        query &= " [maphutung] = @maphutung "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maphutung", iMaPhuTung)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Phụ Tùng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True) ' thanh cong
    End Function

    Public Function select_byMaPhuTung(iMaPhuTung As Integer, listPT As List(Of PhuTungDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [maphutung], [tenphutung], [dongia], [soluongcon]"
        query &= " FROM [tblphutung]"
        query &= " WHERE "
        query &= " [maphutung] = @maphutung"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@maphutung", iMaPhuTung)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listPT.Clear()
                        While reader.Read()
                            listPT.Add(New PhuTungDTO(reader("maphutung"), reader("tenphutung"), reader("dongia"), reader("soluongcon")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Phụ Tùng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALL(listPT As List(Of PhuTungDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [maphutung], [tenphutung], [dongia], [soluongcon]"
        query &= " FROM [tblphutung]"

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
                        listPT.Clear()
                        While reader.Read()
                            listPT.Add(New PhuTungDTO(reader("maphutung"), reader("tenphutung"), reader("dongia"), reader("soluongcon")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Phụ Tùng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function update(pt As PhuTungDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblphutung] SET "
        query &= "   [tenphutung] = @tenphutung "
        query &= "  ,[dongia] = @dongia"
        query &= "  ,[soluongcon] = @soluongcon "
        query &= "WHERE "
        query &= " [maphutung] = @maphutung"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@tenphutung", pt.TenPhuTung)
                    .Parameters.AddWithValue("@dongia", pt.DonGia)
                    .Parameters.AddWithValue("@soluongcon", pt.SoLuongCon)
                    .Parameters.AddWithValue("@maphutung", pt.MaPhuTung)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật Phụ Tùng không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
