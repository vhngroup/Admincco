Imports System.Data.SqlClient
Imports System.Data.OleDb

Friend Module ADONETUtil
    Friend db As IDbConnection
    Friend midataset As DataSet
    Friend mienlazador As New BindingSource
    Friend comandos As New SqlCommand
    Friend dbConnection As Data.SqlClient.SqlConnection
    Friend dbCommand As Data.SqlClient.SqlCommand
    Friend dbDataTable As Data.DataTable
    Friend dbDataSet As Data.DataSet
    Friend dbDataAdapter As Data.SqlClient.SqlDataAdapter
    Friend CadenaConexion As String
    Friend CadenaSelect As String
    Friend ArchivoDatos As String
    Friend cn As New SqlConnection("Data Source=BOGSSGV110P1521\OILGASAPPDES;Initial Catalog=Adminco_Master;Integrated Security=SSPI")
    Friend cn2 As New SqlConnection("Data Source=BOGSSGV110P1521\OILGASAPPDES;Initial Catalog=Stadistic_Admincco;Integrated Security=SSPI")
End Module