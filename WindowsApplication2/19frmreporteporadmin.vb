Imports System.Data.SqlClient
Imports System.Configuration
Public Class reporteporadministrador
    Private fcampocontrato As String
    

    Private Sub reporteporadministrador_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.CampoTableAdapter.Fill(Me.Adminco_MasterDataSet.Campo)
        ComboBox1.DataSource = Datos1.CargarCategoria()
        ComboBox1.DisplayMember = "Campo"
        ComboBox1.ValueMember = "Id"
        ComboBox1.SelectedIndex = -1

        Dim da As Adminco_MasterDataSet = Datos1.CargarArticulos()

        Dim report As New CrystalReport3()
        report.SetDataSource(da)
        CrystalReportViewer1.ReportSource = report
    End Sub
End Class


