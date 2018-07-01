
Imports System.Configuration
Imports System.Data.SqlClient
Imports QLGO1DTO
Imports Utility

Public Class LoaiTienCongDAL
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
        query &= "SELECT TOP 1 [matiencong] "
        query &= "FROM [tblloaitiencong] "
        query &= "ORDER BY [matiencong] DESC "

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
                            idOnDB = reader("matiencong")
                        End While
                    End If
                    ' new ID = current ID + 1
                    nextID = idOnDB + 1
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    nextID = 1
                    Return New Result(False, "Lấy ID kế tiếp của Loại Tiền Công không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function insert(tc As LoaiTienCongDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [dbo].[tblloaitiencong] "
        query &= "(  [matiencong] "
        query &= "  ,[tenloaitiencong] "
        query &= "  ,[muctien]) "
        query &= "VALUES "
        query &= "(   @matiencong "
        query &= "   ,@tenloaitiencong"
        query &= "   ,@muctien) "

        Dim nextID = 0
        Dim result As Result
        result = getNextID(nextID)
        If (result.FlagResult = False) Then
            Return result
        End If
        tc.MaTienCong = nextID

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@matiencong", tc.MaTienCong)
                    .Parameters.AddWithValue("@tenloaitiencong", tc.TenLoaiTienCong)
                    .Parameters.AddWithValue("@muctien", tc.MucTien)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm Loại Tiền Công không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function delete(iMaTienCong As Integer) As Result
        Dim query As String = String.Empty
        query &= " DELETE FROM [dbo].[tblloaitiencong] "
        query &= " WHERE "
        query &= " [matiencong] = @matiencong "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@matiencong", iMaTienCong)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa Loại Tiền Công không thành công", ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True) ' thanh cong
    End Function

    Public Function select_byMaTienCong(iMaTienCong As Integer, listDS As List(Of LoaiTienCongDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [matiencong], [tenloaitiencong], [muctien]"
        query &= " FROM [tblloaitiencong]"
        query &= " WHERE "
        query &= " [matiencong] = @matiencong"


        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@matiencong", iMaTienCong)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        listDS.Clear()
                        While reader.Read()
                            listDS.Add(New LoaiTienCongDTO(reader("matiencong"), reader("tenloaitiencong"), reader("muctien")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Loại Tiền Công không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function selectALL(listKH As List(Of LoaiTienCongDTO)) As Result

        Dim query As String = String.Empty
        query &= " SELECT [matiencong], [tenloaitiencong], [muctien]"
        query &= " FROM [tblloaitiencong]"


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
                            listKH.Add(New LoaiTienCongDTO(reader("matiencong"), reader("tenloaitiencong"), reader("muctien")))
                        End While
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Lấy tất cả Loại Tiền Công không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function


    Public Function update(tc As LoaiTienCongDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tblloaitiencong] SET "
        query &= " [tenloaitiencong] = @tenloaitiencong, "
        query &= " [muctien] = @muctien "
        query &= "WHERE "
        query &= " [matiencong] = @matiencong"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@tenloaitiencong", tc.TenLoaiTienCong)
                    .Parameters.AddWithValue("@muctien", tc.MucTien)
                    .Parameters.AddWithValue("@matiencong", tc.MaTienCong)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật Loại Tiền Công không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
