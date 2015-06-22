Imports System.Data.SqlClient
Imports System.Configuration
Module Datos1
    Public Function CargarCategoria() As DataTable
        Using conexion = ADONETUtil.cn
            Dim dt As New DataTable()
            Dim query As String = "SELECT * FROM Campo"
            Dim cmd As New SqlCommand(query, cn)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Return dt
        End Using
    End Function

    Public Function CargarArticulos() As Adminco_MasterDataSet
        Dim ds As New Adminco_MasterDataSet()
        Using conexion = ADONETUtil.cn
            Dim query As String = "SELECT * FROM Articulo"
            Dim cmd As New SqlCommand(query, cn)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "Articulo")
            Return ds
        End Using

    End Function

    Public Function FiltrarArticulos(ByVal categoria As Integer) As Adminco_MasterDataSet
        Dim ds As New Adminco_MasterDataSet()
        Using conexion = ADONETUtil.cn
            Dim query As String = "SELECT * FROM Articulo WHERE CatId=@cat"
            Dim cmd As New SqlCommand(query, cn)
            cmd.Parameters.AddWithValue("@cat", categoria)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds, "Articulo")
            Return ds
        End Using
    End Function
End Module
