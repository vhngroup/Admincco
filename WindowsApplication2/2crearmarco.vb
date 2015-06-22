Option Explicit On
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.ErrorProvider
Imports Microsoft.Office.Interop
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports System.Diagnostics
Imports System.Linq
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Drawing
Public Class frmformulario
    Dim conexion = ADONETUtil.cn
    Dim comandos As New SqlCommand
    Dim comandos1 As New SqlCommand
    Friend modo As Integer
    Friend impcontratista As String
    Friend impnit As String
    Friend impcm As String
    Friend servicio(7) As String
    Friend nservicio(7) As String
    Friend costod(7) As Double
    Friend admin(7) As Double
    Friend impre(7) As Double
    Friend util(7) As Double
    Friend subt(7) As Double
    Friend iva(7) As Double
    Friend total(7) As Double
    Friend a(7) As Double
    Friend i(7) As Double
    Friend u(7) As Double
    Friend impproyectom1 As String
    Friend impproyecto1 As String
    Friend impprogramam1 As String
    Friend impprograma1 As String
    Friend subprograma1 As String
    Friend imptxtcostadminglobal As String
    Friend imptxtcostimpglobal As String
    Friend imptxtcostutilglobal As String
    Friend imptxtcostsubglobal As String
    Friend imptxtcostivaglobal As String
    Friend impvrgtotal As String
    Friend cosdirecto As String
    Friend hoy As Date
    Private Sub form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.disciplina2' Puede moverla o quitarla según sea necesario.
        Me.Disciplina2TableAdapter.Fill(Me.Adminco_MasterDataSet.disciplina2)
        Me.DisciplinaTableAdapter.Fill(Me.Adminco_MasterDataSet.Disciplina)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.spadmin' Puede moverla o quitarla según sea necesario.
        Me.SpadminTableAdapter1.Fill(Me.Adminco_MasterDataSet.spadmin)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.Admin' Puede moverla o quitarla según sea necesario.
        Me.AdminTableAdapter1.Fill(Me.Adminco_MasterDataSet.Admin)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet3.CMOriginales' Puede moverla o quitarla según sea necesario.
        Me.CMNuevosTableAdapter.Fill(Me.Adminco_MasterDataSet.CMNuevos)
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
        modo = "0"
        hoy = System.DateTime.Now.Date
        dtfecha.Value = hoy
        dtfechai.Value = hoy
        dtfechaf.Value = hoy
        cmbcontrato.Focus()
        nuevoproceso()
        If (cmbestado.Items.Count > 0) Then
            cmbestado.SelectedIndex = "0"
        End If
        vlencarta.Text = FormatNumber(vlencarta.Text, 2)
        ComboBox2.SelectedIndex = 0
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
    End Sub
    Friend Sub nuevoproceso()
        If modo = "0" Then
            spadmin.Text = My.Settings.usuario2
            txtcreado.Text = SystemInformation.UserName
            cmbmoneda.Enabled = False
            btndistribuir.Enabled = False
            nivel1.Enabled = False
            nivel2.Enabled = False
            nivel3.Enabled = False
            nivel4.Enabled = False
            nivel5.Enabled = False
            nivel7.Enabled = False
            btguardar.Enabled = False
            txtadministrator.Enabled = False
            listdisciplina.Enabled = False
            cmbdisciplina.Enabled = False
            REM consecutivo()
            Label14.Visible = False
            Label27.Visible = False
            spname.Visible = False
            esoporte.Visible = False
            adname.Visible = False
            cname.Visible = False
            eadmin.Visible = False
            ecreado.Visible = False
            cfinanciero.Visible = False
        End If
        If modo = 2 Then
            cmbcontratista.Text = impcontratista
            txtnit.Text = impnit
        End If
        If modo = 3 Then
            cmbcontrato.Text = impcm
            txtcreado.Text = SystemInformation.UserName
        End If
        If modo = 4 Then
            nivel7.Enabled = True
            cosd.Text = cosdirecto
            cosa.Text = imptxtcostadminglobal
            cosi.Text = imptxtcostimpglobal
            cosu.Text = imptxtcostutilglobal
            cosdsu.Text = imptxtcostsubglobal
            cosdiva.Text = imptxtcostivaglobal
            costotal.Text = impvrgtotal
            vlfaltante.Text = -(costotal.Text)
            txtvigencia.Enabled = True
            If txtvigencia.Text > "0" Then
                Select Case txtvigencia.Text
                    Case 1
                        txtano1.Enabled = True
                        txtano2.Enabled = False
                        txtano3.Enabled = False
                        txtano4.Enabled = False
                        txtano5.Enabled = False
                    Case 2
                        txtano1.Enabled = True
                        txtano2.Enabled = True
                        txtano3.Enabled = False
                        txtano4.Enabled = False
                        txtano5.Enabled = False
                    Case 3
                        txtano1.Enabled = True
                        txtano2.Enabled = True
                        txtano3.Enabled = True
                        txtano4.Enabled = False
                        txtano5.Enabled = False
                    Case 4
                        txtano1.Enabled = True
                        txtano2.Enabled = True
                        txtano3.Enabled = True
                        txtano4.Enabled = True
                        txtano5.Enabled = False
                    Case 5
                        txtano1.Enabled = True
                        txtano2.Enabled = True
                        txtano3.Enabled = True
                        txtano4.Enabled = True
                        txtano5.Enabled = True
                End Select
            Else
                txtano1.Enabled = False
                txtano2.Enabled = False
                txtano3.Enabled = False
                txtano4.Enabled = False
                txtano5.Enabled = False
            End If
        End If
    End Sub
    Private Sub frmformulario_close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosed
        frmmenu.retorno = 1
        frmmenu.Show()
        Me.Close()
    End Sub
    Private Sub btlimpiar_Click(sender As System.Object, e As System.EventArgs)
        Dim x As Control
        For Each x In Me.Controls
            If TypeOf x Is System.Windows.Forms.TextBox Then x.Text = ""
        Next
        txtcreado.Text = SystemInformation.UserName
    End Sub
    Private Sub dtfechai_TextChanged(sender As Object, e As System.EventArgs) Handles dtfechai.TextChanged
        calcfeccha()
    End Sub
    Private Sub dtfechaf_TextChanged(sender As Object, e As System.EventArgs) Handles dtfechaf.TextChanged
        calcfeccha()
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btndistribuir.Click
        If vlencarta.Text = "" Or "0" Then
            MsgBox("Por favor ingrese el valor del contrato tal como aparece en la carta", MsgBoxStyle.Critical)
            vlencarta.Focus()
        Else
            REM llama a 6estructuracm
            form6.valornet = vlencarta.Text
            form6.ShowDialog()
            form6.Dispose()
        End If
    End Sub
    Private Sub txtdias_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtdias.TextChanged
        Dim number As Integer
        If txtdias.Text > 0 Then
            number = Val(txtdias.Text) / 365
            Math.Ceiling(number)
            txtvigencia.Text = number + 1
        End If
        txtquedan.Text = dtfechaf.Value.Subtract(Date.Today).TotalDays
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        frmmenu.Show()
        frmmenu.retorno = 1
        conexion.Close()
        Me.Close()
    End Sub
    Private Sub calcfeccha()
        txtdias.Text = dtfechaf.Value.Subtract(dtfechai.Value).TotalDays
    End Sub
    Private Sub vlencarta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles vlencarta.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            vlencarta.Text = FormatNumber(CDbl(vlencarta.Text), 2)
        End If
    End Sub

    Private Sub vlencarta_LostFocus(sender As Object, e As System.EventArgs) Handles vlencarta.LostFocus
        vlencarta.Text = FormatNumber(CDbl(vlencarta.Text), 2)
    End Sub
    Private Sub vlencarta_TextChanged(sender As System.Object, e As System.EventArgs) Handles vlencarta.TextChanged
        vlencarta.Text = Trim(dejarNumerosPuntos(vlencarta.Text))
        If (String.IsNullOrEmpty(vlencarta.Text.Trim())) Then
            Me.ErrorProvider1.SetError(vlencarta, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider1.Clear()
            If vlencarta.Text <> 0 Then
                cmbmoneda.Enabled = True
            End If
        End If
    End Sub

    Private Sub cmbadmin_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbdisciplina.SelectedIndexChanged
        nivel1.Enabled = True
    End Sub

    Private Sub txtnit_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtnit.TextChanged
        nivel2.Enabled = True
    End Sub
    Private Sub txtvigencia_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtvigencia.TextChanged
        If (String.IsNullOrEmpty(txtvigencia.Text.Trim())) Then
            Me.ErrorProvider1.SetError(txtvigencia, "Cuidado, espacio vacio")
        Else
            Dim r As New Regex("^[0-9-]*$")
            If Not r.IsMatch(txtvigencia.Text) Then
            Else
                nivel4.Enabled = True
                If txtvigencia.Text > 0 And txtvigencia.Text <> "" Then
                    Me.ErrorProvider1.Clear()
                    Select Case txtvigencia.Text
                        Case 1
                            txtano1.Enabled = True
                            txtano2.Enabled = False
                            txtano3.Enabled = False
                            txtano4.Enabled = False
                            txtano5.Enabled = False
                        Case 2
                            txtano1.Enabled = True
                            txtano2.Enabled = True
                            txtano3.Enabled = False
                            txtano4.Enabled = False
                            txtano5.Enabled = False
                        Case 3
                            txtano1.Enabled = True
                            txtano2.Enabled = True
                            txtano3.Enabled = True
                            txtano4.Enabled = False
                            txtano5.Enabled = False
                        Case 4
                            txtano1.Enabled = True
                            txtano2.Enabled = True
                            txtano3.Enabled = True
                            txtano4.Enabled = True
                            txtano5.Enabled = False
                        Case 5
                            txtano1.Enabled = True
                            txtano2.Enabled = True
                            txtano3.Enabled = True
                            txtano4.Enabled = True
                            txtano5.Enabled = True
                        Case Is > 5
                            MsgBox("El programa solo soporta 5 vigencias, por favor redistribuya fechas")
                            txtano1.Enabled = False
                            txtano2.Enabled = False
                            txtano3.Enabled = False
                            txtano4.Enabled = False
                            txtano5.Enabled = False
                    End Select
                Else
                    txtano1.Enabled = False
                    txtano2.Enabled = False
                    txtano3.Enabled = False
                    txtano4.Enabled = False
                    txtano5.Enabled = False
                    textObjeto.Enabled = False
                End If
            End If


        End If

    End Sub
    Private Sub TextBox5_TextChanged(sender As System.Object, e As System.EventArgs) Handles textObjeto.TextChanged
        nivel5.Enabled = True
        vlencarta.Enabled = True
        vlencarta.BackColor = Color.Turquoise
    End Sub

    Private Sub moneda_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbmoneda.SelectedIndexChanged
        btndistribuir.Enabled = True
        vlencarta.Enabled = False
    End Sub
    Private Sub cmbcontratista_Click(sender As Object, e As System.EventArgs) Handles cmbcontratista.Click
        frmcontatista.ShowDialog()
        frmcontatista.Dispose()
        txtproceso.Focus()
    End Sub

    Private Sub cmbcontratista_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcontratista.KeyPress
        frmcontatista.ShowDialog()
        frmcontatista.Dispose()
        txtproceso.Focus()
    End Sub

    Private Sub cmbcontratista_TabIndexChanged(sender As Object, e As System.EventArgs) Handles cmbcontratista.TabIndexChanged
        txtproceso.Focus()
    End Sub
    Private Sub consecutivo()
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Dim read As Data.SqlClient.SqlDataReader
        Dim maximo As Integer = "0"
        comandos = conexion.CreateCommand()
        comandos.CommandText = "select * from CMNuevos"
        maximo = CType(comandos.ExecuteScalar, Integer) + 1
        comandos.CommandText = "select count(*) FROM CMNuevos"
        read = comandos.ExecuteReader()
        TextBox4.Text = ("00000" + maximo.ToString())
        conexion.Close()
    End Sub
    Private Sub btguardar_Click(sender As System.Object, e As System.EventArgs) Handles btguardar.Click
        consecutivo()
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Try
            comandos.CommandType = CommandType.StoredProcedure
            comandos.CommandText = "guardarcmnuevos"
            comandos.Connection = conexion
            comandos.Parameters.Add("@Fechcontrato", SqlDbType.DateTime).Value = dtfecha.Value()
            comandos.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato.Text()
            comandos.Parameters.Add("@Creadopor", SqlDbType.NVarChar).Value = txtcreado.Text()
            comandos.Parameters.Add("@Administrador", SqlDbType.NVarChar).Value = txtadministrator.Text()
            comandos.Parameters.Add("@Disciplina", SqlDbType.NVarChar).Value = cmbdisciplina.Text()
            comandos.Parameters.Add("@PROVEEDOR", SqlDbType.NVarChar).Value = cmbcontratista.Text()
            comandos.Parameters.Add("@txtnit", SqlDbType.NVarChar).Value = txtnit.Text()
            comandos.Parameters.Add("@PROCESO", SqlDbType.NVarChar).Value = txtproceso.Text()
            comandos.Parameters.Add("@Asociacion", SqlDbType.NVarChar).Value = cmbasociacion.Text()
            comandos.Parameters.Add("@proyecto", SqlDbType.NVarChar).Value = cmbproyecto.Text()
            comandos.Parameters.Add("@Programa", SqlDbType.NVarChar).Value = programap.Text()
            comandos.Parameters.Add("@ProgramaM", SqlDbType.NVarChar).Value = programam.Text()
            comandos.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = cmbestado.Text()
            comandos.Parameters.Add("@FechInicio", SqlDbType.DateTime).Value = dtfechai.Value.Date()
            comandos.Parameters.Add("@FechaFinal", SqlDbType.DateTime).Value = dtfechaf.Value.Date()
            comandos.Parameters.Add("@spadmin", SqlDbType.NVarChar).Value = spadmin.Text()
            comandos.Parameters.Add("@diasv", SqlDbType.Float).Value = CLng(txtdias.Text())
            comandos.Parameters.Add("@anosvigencia", SqlDbType.NVarChar).Value = txtvigencia.Text()
            comandos.Parameters.Add("@observaciones", SqlDbType.NText).Value = textObjeto.Text()
            comandos.Parameters.Add("@moneda", SqlDbType.NVarChar).Value = cmbmoneda.Text()
            comandos.Parameters.Add("@VrCtoFirmado", SqlDbType.Float).Value = costotal.Text()
            comandos.Parameters.Add("@Costodirecto", SqlDbType.Float).Value = cosd.Text()
            comandos.Parameters.Add("@Administracion", SqlDbType.Float).Value = cosa.Text()
            comandos.Parameters.Add("@Imprevisto", SqlDbType.Float).Value = cosi.Text()
            comandos.Parameters.Add("@Utilidad", SqlDbType.Float).Value = cosu.Text()
            comandos.Parameters.Add("@Subtotal", SqlDbType.Float).Value = cosdsu.Text()
            comandos.Parameters.Add("@iva", SqlDbType.NVarChar).Value = cosdiva.Text()
            comandos.Parameters.Add("@VrContrato", SqlDbType.Float).Value = costotal.Text()
            comandos.Parameters.Add("@Nuevovalor", SqlDbType.Float).Value = 0
            comandos.Parameters.Add("@Tiposervicio1", SqlDbType.NVarChar).Value = servicio(0)
            comandos.Parameters.Add("@SERVICIO1", SqlDbType.NVarChar).Value = nservicio(0)
            comandos.Parameters.Add("@ADM1", SqlDbType.Float).Value = a(0)
            comandos.Parameters.Add("@IMP1", SqlDbType.Float).Value = i(0)
            comandos.Parameters.Add("@UTIL1", SqlDbType.Float).Value = u(0)
            comandos.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = costod(0)
            comandos.Parameters.Add("@Administracion1", SqlDbType.Float).Value = admin(0)
            comandos.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = impre(0)
            comandos.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = util(0)
            comandos.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = subt(0)
            comandos.Parameters.Add("@IVA1", SqlDbType.NVarChar).Value = iva(0)
            comandos.Parameters.Add("@Vrtotal1", SqlDbType.Float).Value = total(0)
            comandos.Parameters.Add("@Tiposervicio2", SqlDbType.NVarChar).Value = servicio(1)
            comandos.Parameters.Add("@SERVICIO2", SqlDbType.NVarChar).Value = nservicio(1)
            comandos.Parameters.Add("@ADM2", SqlDbType.Float).Value = a(1)
            comandos.Parameters.Add("@IMP2", SqlDbType.Float).Value = i(1)
            comandos.Parameters.Add("@UTIL2", SqlDbType.Float).Value = u(1)
            comandos.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = costod(1)
            comandos.Parameters.Add("@Administracion2", SqlDbType.Float).Value = admin(1)
            comandos.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = impre(1)
            comandos.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = util(1)
            comandos.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = subt(1)
            comandos.Parameters.Add("@IVA2", SqlDbType.NVarChar).Value = iva(1)
            comandos.Parameters.Add("@Vrtotal2", SqlDbType.Float).Value = total(1)
            comandos.Parameters.Add("@Tiposervicio3", SqlDbType.NVarChar).Value = servicio(2)
            comandos.Parameters.Add("@SERVICIO3", SqlDbType.NVarChar).Value = nservicio(2)
            comandos.Parameters.Add("@ADM3", SqlDbType.Float).Value = a(2)
            comandos.Parameters.Add("@IMP3", SqlDbType.Float).Value = i(2)
            comandos.Parameters.Add("@UTIL3", SqlDbType.Float).Value = u(2)
            comandos.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = costod(2)
            comandos.Parameters.Add("@Administracion3", SqlDbType.Float).Value = admin(2)
            comandos.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = impre(2)
            comandos.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = util(2)
            comandos.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = subt(2)
            comandos.Parameters.Add("@IVA3", SqlDbType.NVarChar).Value = iva(2)
            comandos.Parameters.Add("@Vrtotal3", SqlDbType.Float).Value = total(2)
            comandos.Parameters.Add("@Tiposervicio4", SqlDbType.NVarChar).Value = servicio(3)
            comandos.Parameters.Add("@SERVICIO4", SqlDbType.NVarChar).Value = nservicio(3)
            comandos.Parameters.Add("@ADM4", SqlDbType.Float).Value = a(3)
            comandos.Parameters.Add("@IMP4", SqlDbType.Float).Value = i(3)
            comandos.Parameters.Add("@UTIL4", SqlDbType.Float).Value = u(3)
            comandos.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = costod(3)
            comandos.Parameters.Add("@Administracion4", SqlDbType.Float).Value = admin(3)
            comandos.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = impre(3)
            comandos.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = util(3)
            comandos.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = subt(3)
            comandos.Parameters.Add("@IVA4", SqlDbType.NVarChar).Value = iva(3)
            comandos.Parameters.Add("@Vrtotal4", SqlDbType.Float).Value = total(3)
            comandos.Parameters.Add("@Tiposervicio5", SqlDbType.NVarChar).Value = servicio(4)
            comandos.Parameters.Add("@SERVICIO5", SqlDbType.NVarChar).Value = nservicio(4)
            comandos.Parameters.Add("@ADM5", SqlDbType.Float).Value = a(4)
            comandos.Parameters.Add("@IMP5", SqlDbType.Float).Value = i(4)
            comandos.Parameters.Add("@UTIL5", SqlDbType.Float).Value = u(4)
            comandos.Parameters.Add("@CostoDirecto5", SqlDbType.Float).Value = costod(4)
            comandos.Parameters.Add("@Administracion5", SqlDbType.Float).Value = admin(4)
            comandos.Parameters.Add("@Imprevistos5", SqlDbType.Float).Value = impre(4)
            comandos.Parameters.Add("@Utilidad5", SqlDbType.Float).Value = util(4)
            comandos.Parameters.Add("@Subtotal5", SqlDbType.Float).Value = subt(4)
            comandos.Parameters.Add("@IVA5", SqlDbType.NVarChar).Value = iva(4)
            comandos.Parameters.Add("@Vrtotal5", SqlDbType.Float).Value = total(4)
            comandos.Parameters.Add("@Tiposervicio6", SqlDbType.NVarChar).Value = servicio(5)
            comandos.Parameters.Add("@SERVICIO6", SqlDbType.NVarChar).Value = nservicio(5)
            comandos.Parameters.Add("@ADM6", SqlDbType.Float).Value = a(5)
            comandos.Parameters.Add("@IMP6", SqlDbType.Float).Value = i(5)
            comandos.Parameters.Add("@UTIL6", SqlDbType.Float).Value = u(5)
            comandos.Parameters.Add("@CostoDirecto6", SqlDbType.Float).Value = costod(5)
            comandos.Parameters.Add("@Administracion6", SqlDbType.Float).Value = admin(5)
            comandos.Parameters.Add("@Imprevistos6", SqlDbType.Float).Value = impre(5)
            comandos.Parameters.Add("@Utilidad6", SqlDbType.Float).Value = util(5)
            comandos.Parameters.Add("@Subtotal6", SqlDbType.Float).Value = subt(5)
            comandos.Parameters.Add("@IVA6", SqlDbType.NVarChar).Value = iva(5)
            comandos.Parameters.Add("@Vrtotal6", SqlDbType.Float).Value = total(5)
            comandos.Parameters.Add("@Tiposervicio7", SqlDbType.NVarChar).Value = servicio(6)
            comandos.Parameters.Add("@SERVICIO7", SqlDbType.NVarChar).Value = nservicio(6)
            comandos.Parameters.Add("@ADM7", SqlDbType.Float).Value = a(6)
            comandos.Parameters.Add("@IMP7", SqlDbType.Float).Value = i(6)
            comandos.Parameters.Add("@UTIL7", SqlDbType.Float).Value = u(6)
            comandos.Parameters.Add("@CostoDirecto7", SqlDbType.Float).Value = costod(6)
            comandos.Parameters.Add("@Administracion7", SqlDbType.Float).Value = admin(6)
            comandos.Parameters.Add("@Imprevistos7", SqlDbType.Float).Value = impre(6)
            comandos.Parameters.Add("@Utilidad7", SqlDbType.Float).Value = util(6)
            comandos.Parameters.Add("@Subtotal7", SqlDbType.Float).Value = subt(6)
            comandos.Parameters.Add("@IVA7", SqlDbType.NVarChar).Value = iva(6)
            comandos.Parameters.Add("@Vrtotal7", SqlDbType.Float).Value = total(6)
            comandos.Parameters.Add("@Tiposervicio8", SqlDbType.NVarChar).Value = servicio(7)
            comandos.Parameters.Add("@SERVICIO8", SqlDbType.NVarChar).Value = nservicio(7)
            comandos.Parameters.Add("@ADM8", SqlDbType.Float).Value = a(7)
            comandos.Parameters.Add("@IMP8", SqlDbType.Float).Value = i(7)
            comandos.Parameters.Add("@UTIL8", SqlDbType.Float).Value = u(7)
            comandos.Parameters.Add("@CostoDirecto8", SqlDbType.Float).Value = costod(7)
            comandos.Parameters.Add("@Administracion8", SqlDbType.Float).Value = admin(7)
            comandos.Parameters.Add("@Imprevistos8", SqlDbType.Float).Value = impre(7)
            comandos.Parameters.Add("@Utilidad8", SqlDbType.Float).Value = util(7)
            comandos.Parameters.Add("@Subtotal8", SqlDbType.Float).Value = subt(7)
            comandos.Parameters.Add("@IVA8", SqlDbType.NVarChar).Value = iva(7)
            comandos.Parameters.Add("@Vrtotal8", SqlDbType.Float).Value = total(7)
            comandos.Parameters.Add("@VIGENCIA1", SqlDbType.NVarChar).Value = lblano1.Text()
            comandos.Parameters.Add("@VALOR1", SqlDbType.Float).Value = txtano1.Text() REM guarda el valor la vigencia
            comandos.Parameters.Add("@VIGENCIA2", SqlDbType.NVarChar).Value = lblano2.Text()
            comandos.Parameters.Add("@VALOR2", SqlDbType.Float).Value = txtano2.Text()
            comandos.Parameters.Add("@VIGENCIA3", SqlDbType.NVarChar).Value = lblano3.Text()
            comandos.Parameters.Add("@VALOR3", SqlDbType.Float).Value = txtano3.Text()
            comandos.Parameters.Add("@VIGENCIA4", SqlDbType.NVarChar).Value = lblano4.Text()
            comandos.Parameters.Add("@VALOR4", SqlDbType.Float).Value = txtano4.Text()
            comandos.Parameters.Add("@VIGENCIA5", SqlDbType.NVarChar).Value = lblano5.Text()
            comandos.Parameters.Add("@VALOR5", SqlDbType.Float).Value = txtano5.Text()
            comandos.Parameters.Add("@REEMBOLSABLE", SqlDbType.NVarChar).Value = coorfinaciero.Text() 'Guarda el nombre del cordinador finaciero
            comandos.Parameters.Add("@VALIDAU", SqlDbType.NVarChar).Value = spadmin.Text()
            comandos.Parameters.Add("@otrosi", SqlDbType.NVarChar).Value = 0
            comandos.Parameters.Add("@porcentajedinero", SqlDbType.NVarChar).Value = 0
            comandos.Parameters.Add("@porcentajedvigencia", SqlDbType.NVarChar).Value = 0
            comandos.Parameters.Add("@saldoglobal", SqlDbType.Float).Value = costotal.Text()
            comandos.Parameters.Add("@acumuladovigencia", SqlDbType.Float).Value = 0
            comandos.Parameters.Add("@porcentajeanticipo", SqlDbType.Int).Value = TextBox1.Text()
            comandos.Parameters.Add("@valoranticipo", SqlDbType.Float).Value = TextBox2.Text()
            comandos.Parameters.Add("@saldodirecto", SqlDbType.Float).Value = cosd.Text()
            comandos.Parameters.Add("@saldoadmin", SqlDbType.Float).Value = cosa.Text()
            comandos.Parameters.Add("@saldoimpre", SqlDbType.Float).Value = cosi.Text()
            comandos.Parameters.Add("@saldoutil", SqlDbType.Float).Value = cosu.Text()
            comandos.Parameters.Add("@saldosubtotal", SqlDbType.Float).Value = cosdsu.Text()
            comandos.Parameters.Add("@saldoiva", SqlDbType.Float).Value = cosdiva.Text()
            comandos.Parameters.Add("@saldototal", SqlDbType.Float).Value = costotal.Text()
            comandos.Parameters.Add("@vigenciast1", SqlDbType.Float).Value = txtano1.Text()
            comandos.Parameters.Add("@vigenciast2", SqlDbType.Float).Value = txtano2.Text()
            comandos.Parameters.Add("@vigenciast3", SqlDbType.Float).Value = txtano3.Text()
            comandos.Parameters.Add("@vigenciast4", SqlDbType.Float).Value = txtano4.Text()
            comandos.Parameters.Add("@vigenciast5", SqlDbType.Float).Value = txtano5.Text()
            comandos.Parameters.Add("@gastovigenciast1", SqlDbType.Float).Value = 0
            comandos.Parameters.Add("@gastovigenciast2", SqlDbType.Float).Value = 0
            comandos.Parameters.Add("@gastovigenciast3", SqlDbType.Float).Value = 0
            comandos.Parameters.Add("@gastovigenciast4", SqlDbType.Float).Value = 0
            comandos.Parameters.Add("@gastovigenciast5", SqlDbType.Float).Value = 0
            comandos.ExecuteNonQuery()
            comandos.Dispose()
            conexion.close()
            GroupBox1.Enabled = False
            nivel1.Enabled = False
            nivel2.Enabled = False
            nivel3.Enabled = False
            cmbestado.Enabled = False
            textObjeto.Enabled = False
            nivel5.Enabled = False
            nivel7.Enabled = False
            btguardar.Enabled = False
            cmbmoneda.Enabled = False
            btndistribuir.Enabled = False
            GroupBox2.Enabled = False
            cmbproyecto.Enabled = True
            guardar2()
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod2-fun-01:" & "_" & ex.Message)
        End Try
    End Sub
    Private Sub guardar2()
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Try
            comandos1.CommandType = CommandType.StoredProcedure
            comandos1.CommandText = "guardarcmoriginales"
            comandos1.Connection = conexion
            comandos1.Parameters.Add("@Fechcontrato", SqlDbType.DateTime).Value = dtfecha.Value()
            comandos1.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato.Text()
            comandos1.Parameters.Add("@Creadopor", SqlDbType.NVarChar).Value = txtcreado.Text()
            comandos1.Parameters.Add("@Administrador", SqlDbType.NVarChar).Value = txtadministrator.Text()
            comandos1.Parameters.Add("@Disciplina", SqlDbType.NVarChar).Value = cmbdisciplina.Text()
            comandos1.Parameters.Add("@PROVEEDOR", SqlDbType.NVarChar).Value = cmbcontratista.Text()
            comandos1.Parameters.Add("@txtnit", SqlDbType.NVarChar).Value = txtnit.Text()
            comandos1.Parameters.Add("@PROCESO", SqlDbType.NVarChar).Value = txtproceso.Text()
            comandos1.Parameters.Add("@Asociacion", SqlDbType.NVarChar).Value = cmbasociacion.Text()
            comandos1.Parameters.Add("@proyecto", SqlDbType.NVarChar).Value = cmbproyecto.Text()
            comandos1.Parameters.Add("@Programa", SqlDbType.NVarChar).Value = programap.Text()
            comandos1.Parameters.Add("@ProgramaM", SqlDbType.NVarChar).Value = programam.Text()
            comandos1.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = cmbestado.Text()
            comandos1.Parameters.Add("@FechInicio", SqlDbType.DateTime).Value = dtfechai.Value.Date()
            comandos1.Parameters.Add("@FechaFinal", SqlDbType.DateTime).Value = dtfechaf.Value.Date()
            comandos1.Parameters.Add("@spadmin", SqlDbType.NVarChar).Value = spadmin.Text()
            comandos1.Parameters.Add("@diasv", SqlDbType.Float).Value = CLng(txtdias.Text())
            comandos1.Parameters.Add("@anosvigencia", SqlDbType.NVarChar).Value = txtvigencia.Text()
            comandos1.Parameters.Add("@observaciones", SqlDbType.NText).Value = textObjeto.Text()
            comandos1.Parameters.Add("@moneda", SqlDbType.NVarChar).Value = cmbmoneda.Text()
            comandos1.Parameters.Add("@VrCtoFirmado", SqlDbType.Float).Value = costotal.Text()
            comandos1.Parameters.Add("@Costodirecto", SqlDbType.Float).Value = cosd.Text()
            comandos1.Parameters.Add("@Administracion", SqlDbType.Float).Value = cosa.Text()
            comandos1.Parameters.Add("@Imprevisto", SqlDbType.Float).Value = cosi.Text()
            comandos1.Parameters.Add("@Utilidad", SqlDbType.Float).Value = cosu.Text()
            comandos1.Parameters.Add("@Subtotal", SqlDbType.Float).Value = cosdsu.Text()
            comandos1.Parameters.Add("@iva", SqlDbType.NVarChar).Value = cosdiva.Text()
            comandos1.Parameters.Add("@VrContrato", SqlDbType.Float).Value = costotal.Text()
            comandos1.Parameters.Add("@Nuevovalor", SqlDbType.Float).Value = 0
            comandos1.Parameters.Add("@Tiposervicio1", SqlDbType.NVarChar).Value = servicio((0))
            comandos1.Parameters.Add("@SERVICIO1", SqlDbType.NVarChar).Value = nservicio((0))
            comandos1.Parameters.Add("@ADM1", SqlDbType.Float).Value = a((0))
            comandos1.Parameters.Add("@IMP1", SqlDbType.Float).Value = i((0))
            comandos1.Parameters.Add("@UTIL1", SqlDbType.Float).Value = u(0)
            comandos1.Parameters.Add("@CostoDirecto1", SqlDbType.Float).Value = costod((0))
            comandos1.Parameters.Add("@Administracion1", SqlDbType.Float).Value = admin((0))
            comandos1.Parameters.Add("@Imprevistos1", SqlDbType.Float).Value = impre((0))
            comandos1.Parameters.Add("@Utilidad1", SqlDbType.Float).Value = util((0))
            comandos1.Parameters.Add("@Subtotal1", SqlDbType.Float).Value = subt((0))
            comandos1.Parameters.Add("@IVA1", SqlDbType.NVarChar).Value = iva((0))
            comandos1.Parameters.Add("@Vrtotal1", SqlDbType.Float).Value = total((0))
            comandos1.Parameters.Add("@Tiposervicio2", SqlDbType.NVarChar).Value = servicio((1))
            comandos1.Parameters.Add("@SERVICIO2", SqlDbType.NVarChar).Value = nservicio((1))
            comandos1.Parameters.Add("@ADM2", SqlDbType.Float).Value = a((1))
            comandos1.Parameters.Add("@IMP2", SqlDbType.Float).Value = i((1))
            comandos1.Parameters.Add("@UTIL2", SqlDbType.Float).Value = u((1))
            comandos1.Parameters.Add("@CostoDirecto2", SqlDbType.Float).Value = costod((1))
            comandos1.Parameters.Add("@Administracion2", SqlDbType.Float).Value = admin((1))
            comandos1.Parameters.Add("@Imprevistos2", SqlDbType.Float).Value = impre((1))
            comandos1.Parameters.Add("@Utilidad2", SqlDbType.Float).Value = util((1))
            comandos1.Parameters.Add("@Subtotal2", SqlDbType.Float).Value = subt((1))
            comandos1.Parameters.Add("@IVA2", SqlDbType.NVarChar).Value = iva((1))
            comandos1.Parameters.Add("@Vrtotal2", SqlDbType.Float).Value = total((1))
            comandos1.Parameters.Add("@Tiposervicio3", SqlDbType.NVarChar).Value = servicio((2))
            comandos1.Parameters.Add("@SERVICIO3", SqlDbType.NVarChar).Value = nservicio((2))
            comandos1.Parameters.Add("@ADM3", SqlDbType.Float).Value = a((2))
            comandos1.Parameters.Add("@IMP3", SqlDbType.Float).Value = i((2))
            comandos1.Parameters.Add("@UTIL3", SqlDbType.Float).Value = u((2))
            comandos1.Parameters.Add("@CostoDirecto3", SqlDbType.Float).Value = costod((2))
            comandos1.Parameters.Add("@Administracion3", SqlDbType.Float).Value = admin((2))
            comandos1.Parameters.Add("@Imprevistos3", SqlDbType.Float).Value = impre((2))
            comandos1.Parameters.Add("@Utilidad3", SqlDbType.Float).Value = util((2))
            comandos1.Parameters.Add("@Subtotal3", SqlDbType.Float).Value = subt((2))
            comandos1.Parameters.Add("@IVA3", SqlDbType.NVarChar).Value = iva((2))
            comandos1.Parameters.Add("@Vrtotal3", SqlDbType.Float).Value = total((2))
            comandos1.Parameters.Add("@Tiposervicio4", SqlDbType.NVarChar).Value = servicio((3))
            comandos1.Parameters.Add("@SERVICIO4", SqlDbType.NVarChar).Value = nservicio((3))
            comandos1.Parameters.Add("@ADM4", SqlDbType.Float).Value = a((3))
            comandos1.Parameters.Add("@IMP4", SqlDbType.Float).Value = i((3))
            comandos1.Parameters.Add("@UTIL4", SqlDbType.Float).Value = u((3))
            comandos1.Parameters.Add("@CostoDirecto4", SqlDbType.Float).Value = costod((3))
            comandos1.Parameters.Add("@Administracion4", SqlDbType.Float).Value = admin((3))
            comandos1.Parameters.Add("@Imprevistos4", SqlDbType.Float).Value = impre((3))
            comandos1.Parameters.Add("@Utilidad4", SqlDbType.Float).Value = util((3))
            comandos1.Parameters.Add("@Subtotal4", SqlDbType.Float).Value = subt((3))
            comandos1.Parameters.Add("@IVA4", SqlDbType.NVarChar).Value = iva((3))
            comandos1.Parameters.Add("@Vrtotal4", SqlDbType.Float).Value = total((3))
            comandos1.Parameters.Add("@Tiposervicio5", SqlDbType.NVarChar).Value = servicio((4))
            comandos1.Parameters.Add("@SERVICIO5", SqlDbType.NVarChar).Value = nservicio((4))
            comandos1.Parameters.Add("@ADM5", SqlDbType.Float).Value = a((4))
            comandos1.Parameters.Add("@IMP5", SqlDbType.Float).Value = i((4))
            comandos1.Parameters.Add("@UTIL5", SqlDbType.Float).Value = u((4))
            comandos1.Parameters.Add("@CostoDirecto5", SqlDbType.Float).Value = costod((4))
            comandos1.Parameters.Add("@Administracion5", SqlDbType.Float).Value = admin((4))
            comandos1.Parameters.Add("@Imprevistos5", SqlDbType.Float).Value = impre((4))
            comandos1.Parameters.Add("@Utilidad5", SqlDbType.Float).Value = util((4))
            comandos1.Parameters.Add("@Subtotal5", SqlDbType.Float).Value = subt((4))
            comandos1.Parameters.Add("@IVA5", SqlDbType.NVarChar).Value = iva((4))
            comandos1.Parameters.Add("@Vrtotal5", SqlDbType.Float).Value = total((4))
            comandos1.Parameters.Add("@Tiposervicio6", SqlDbType.NVarChar).Value = servicio((5))
            comandos1.Parameters.Add("@SERVICIO6", SqlDbType.NVarChar).Value = nservicio((5))
            comandos1.Parameters.Add("@ADM6", SqlDbType.Float).Value = a((5))
            comandos1.Parameters.Add("@IMP6", SqlDbType.Float).Value = i((5))
            comandos1.Parameters.Add("@UTIL6", SqlDbType.Float).Value = u((5))
            comandos1.Parameters.Add("@CostoDirecto6", SqlDbType.Float).Value = costod((5))
            comandos1.Parameters.Add("@Administracion6", SqlDbType.Float).Value = admin((5))
            comandos1.Parameters.Add("@Imprevistos6", SqlDbType.Float).Value = impre((5))
            comandos1.Parameters.Add("@Utilidad6", SqlDbType.Float).Value = util((5))
            comandos1.Parameters.Add("@Subtotal6", SqlDbType.Float).Value = subt((5))
            comandos1.Parameters.Add("@IVA6", SqlDbType.NVarChar).Value = iva((5))
            comandos1.Parameters.Add("@Vrtotal6", SqlDbType.Float).Value = total((5))
            comandos1.Parameters.Add("@Tiposervicio7", SqlDbType.NVarChar).Value = servicio(6)
            comandos1.Parameters.Add("@SERVICIO7", SqlDbType.NVarChar).Value = nservicio(6)
            comandos1.Parameters.Add("@ADM7", SqlDbType.Float).Value = a(6)
            comandos1.Parameters.Add("@IMP7", SqlDbType.Float).Value = i(6)
            comandos1.Parameters.Add("@UTIL7", SqlDbType.Float).Value = u(6)
            comandos1.Parameters.Add("@CostoDirecto7", SqlDbType.Float).Value = costod(6)
            comandos1.Parameters.Add("@Administracion7", SqlDbType.Float).Value = admin(6)
            comandos1.Parameters.Add("@Imprevistos7", SqlDbType.Float).Value = impre(6)
            comandos1.Parameters.Add("@Utilidad7", SqlDbType.Float).Value = util(6)
            comandos1.Parameters.Add("@Subtotal7", SqlDbType.Float).Value = subt(6)
            comandos1.Parameters.Add("@IVA7", SqlDbType.NVarChar).Value = iva(6)
            comandos1.Parameters.Add("@Vrtotal7", SqlDbType.Float).Value = total(6)
            comandos1.Parameters.Add("@Tiposervicio8", SqlDbType.NVarChar).Value = servicio(7)
            comandos1.Parameters.Add("@SERVICIO8", SqlDbType.NVarChar).Value = nservicio(7)
            comandos1.Parameters.Add("@ADM8", SqlDbType.Float).Value = a(7)
            comandos1.Parameters.Add("@IMP8", SqlDbType.Float).Value = i(7)
            comandos1.Parameters.Add("@UTIL8", SqlDbType.Float).Value = u(7)
            comandos1.Parameters.Add("@CostoDirecto8", SqlDbType.Float).Value = costod(7)
            comandos1.Parameters.Add("@Administracion8", SqlDbType.Float).Value = admin(7)
            comandos1.Parameters.Add("@Imprevistos8", SqlDbType.Float).Value = impre(7)
            comandos1.Parameters.Add("@Utilidad8", SqlDbType.Float).Value = util(7)
            comandos1.Parameters.Add("@Subtotal8", SqlDbType.Float).Value = subt(7)
            comandos1.Parameters.Add("@IVA8", SqlDbType.NVarChar).Value = iva(7)
            comandos1.Parameters.Add("@Vrtotal8", SqlDbType.Float).Value = total(7)
            comandos1.Parameters.Add("@VIGENCIA1", SqlDbType.NVarChar).Value = lblano1.Text()
            comandos1.Parameters.Add("@VALOR1", SqlDbType.Float).Value = txtano1.Text() REM guarda el valor la vigencia
            comandos1.Parameters.Add("@VIGENCIA2", SqlDbType.NVarChar).Value = lblano2.Text()
            comandos1.Parameters.Add("@VALOR2", SqlDbType.Float).Value = txtano2.Text()
            comandos1.Parameters.Add("@VIGENCIA3", SqlDbType.NVarChar).Value = lblano3.Text()
            comandos1.Parameters.Add("@VALOR3", SqlDbType.Float).Value = txtano3.Text()
            comandos1.Parameters.Add("@VIGENCIA4", SqlDbType.NVarChar).Value = lblano4.Text()
            comandos1.Parameters.Add("@VALOR4", SqlDbType.Float).Value = txtano4.Text()
            comandos1.Parameters.Add("@VIGENCIA5", SqlDbType.NVarChar).Value = lblano5.Text()
            comandos1.Parameters.Add("@VALOR5", SqlDbType.Float).Value = txtano5.Text()
            comandos1.Parameters.Add("@REEMBOLSABLE", SqlDbType.NVarChar).Value = coorfinaciero.Text() 'Guarda el nombre del cordinador finaciero
            comandos1.Parameters.Add("@VALIDAU", SqlDbType.NVarChar).Value = spadmin.Text()
            comandos1.Parameters.Add("@otrosi", SqlDbType.NVarChar).Value = 0
            comandos1.Parameters.Add("@porcentajedinero", SqlDbType.NVarChar).Value = 0
            comandos1.Parameters.Add("@porcentajedvigencia", SqlDbType.NVarChar).Value = 0
            comandos1.Parameters.Add("@saldoglobal", SqlDbType.Float).Value = costotal.Text()
            comandos1.Parameters.Add("@acumuladovigencia", SqlDbType.Float).Value = 0
            comandos1.Parameters.Add("@porcentajeanticipo", SqlDbType.Int).Value = TextBox1.Text()
            comandos1.Parameters.Add("@valoranticipo", SqlDbType.Float).Value = TextBox2.Text()
            comandos1.Parameters.Add("@saldodirecto", SqlDbType.Float).Value = cosd.Text()
            comandos1.Parameters.Add("@saldoadmin", SqlDbType.Float).Value = cosa.Text()
            comandos1.Parameters.Add("@saldoimpre", SqlDbType.Float).Value = cosi.Text()
            comandos1.Parameters.Add("@saldoutil", SqlDbType.Float).Value = cosu.Text()
            comandos1.Parameters.Add("@saldosubtotal", SqlDbType.Float).Value = cosdsu.Text()
            comandos1.Parameters.Add("@saldoiva", SqlDbType.Float).Value = cosdiva.Text()
            comandos1.Parameters.Add("@saldototal", SqlDbType.Float).Value = costotal.Text()
            comandos1.Parameters.Add("@vigenciast1", SqlDbType.Float).Value = txtano1.Text()
            comandos1.Parameters.Add("@vigenciast2", SqlDbType.Float).Value = txtano2.Text()
            comandos1.Parameters.Add("@vigenciast3", SqlDbType.Float).Value = txtano3.Text()
            comandos1.Parameters.Add("@vigenciast4", SqlDbType.Float).Value = txtano4.Text()
            comandos1.Parameters.Add("@vigenciast5", SqlDbType.Float).Value = txtano5.Text()
            comandos1.ExecuteNonQuery()
            comandos1.Dispose()
            conexion.close()
            MsgBox("Contrato guardado correctamente")
            enviarmail()
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod2-fun-02:" & "_" & ex.Message)
        End Try
    End Sub
    Private Sub cmbcontrato_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcontrato.KeyPress
        Dim Sep As Char
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
    End Sub

    Private Sub cmbcontrato_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbcontrato.KeyUp
        If cmbcontrato.Text.Length < 10 Then
            Me.ErrorProvider1.SetError(cmbcontrato, "El codigo del contrato debe tener 10 numeros")
        Else
            Me.ErrorProvider1.Clear()
        End If
    End Sub
    Private Sub cmbcontrato_TextChanged(sender As System.Object, e As System.EventArgs) Handles cmbcontrato.TextChanged
        Dim r As New Regex("^[0-9,]*$")
        If Not r.IsMatch(cmbcontrato.Text) Then
            cmbcontrato.Select(0, cmbcontrato.Text.Length)
            Me.ErrorProvider8.SetError(cmbcontrato, "Solo se aceptan Números")
            txtadministrator.Enabled = False
        Else
            Me.ErrorProvider1.Clear()
            Me.CMNuevosBindingSource.Filter = "Contratos like '%" & cmbcontrato.Text & "%'"
            If cmbcontrato.Text = Label14.Text Then
                MsgBox("Este contrato ya existe")
                txtadministrator.Enabled = False
                cmbdisciplina.Enabled = False
                impreporte.Visible = True
                impreporte.Enabled = True
            Else
                txtadministrator.Enabled = True
                impreporte.Enabled = False
                impreporte.Visible = False
            End If
        End If

    End Sub
    Private Sub txtano1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtano1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtano1.Text = FormatNumber(CDbl(txtano1.Text), 2)
        End If
    End Sub
    Private Sub txtano1_LostFocus(sender As Object, e As System.EventArgs) Handles txtano1.LostFocus
        txtano1.Text = FormatNumber(CDbl(txtano1.Text), 2)
    End Sub
    Private Sub txtano1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtano1.TextChanged
        txtano1.Text = Trim(dejarNumerosPuntos(txtano1.Text))
        If (String.IsNullOrEmpty(txtano1.Text.Trim())) Then
            Me.ErrorProvider1.SetError(txtano1, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider1.Clear()
            comprobar()
        End If
    End Sub
    Private Sub txtano2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtano2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtano2.Text = FormatNumber(CDbl(txtano2.Text), 2)
        End If
    End Sub
    Private Sub txtano2_LostFocus(sender As Object, e As System.EventArgs) Handles txtano2.LostFocus
        txtano2.Text = FormatNumber(CDbl(txtano2.Text), 2)
    End Sub
    Private Sub txtano2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtano2.TextChanged
        txtano2.Text = Trim(dejarNumerosPuntos(txtano2.Text))
        If (String.IsNullOrEmpty(txtano2.Text.Trim())) Then
            Me.ErrorProvider2.SetError(txtano2, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider2.Clear()
            comprobar()
        End If
    End Sub
    Private Sub txtano3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtano3.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtano3.Text = FormatNumber(CDbl(txtano3.Text), 2)
        End If
    End Sub
    Private Sub txtano3_LostFocus(sender As Object, e As System.EventArgs) Handles txtano3.LostFocus
        txtano3.Text = FormatNumber(CDbl(txtano3.Text), 2)
    End Sub
    Private Sub txtano3_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtano3.TextChanged
        txtano3.Text = Trim(dejarNumerosPuntos(txtano3.Text))
        If (String.IsNullOrEmpty(txtano3.Text.Trim())) Then
            Me.ErrorProvider3.SetError(txtano3, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider3.Clear()
            comprobar()
        End If
    End Sub
    Private Sub txtano4_LostFocus(sender As Object, e As System.EventArgs) Handles txtano4.LostFocus
        txtano4.Text = FormatNumber(CDbl(txtano4.Text), 2)
    End Sub
    Private Sub txtano4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtano4.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtano4.Text = FormatNumber(CDbl(txtano4.Text), 2)
        End If
    End Sub
    Private Sub txtano4_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtano4.TextChanged
        txtano4.Text = Trim(dejarNumerosPuntos(txtano4.Text))
        If (String.IsNullOrEmpty(txtano4.Text.Trim())) Then
            Me.ErrorProvider4.SetError(txtano4, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider4.Clear()
            comprobar()
        End If
    End Sub
    Private Sub txtano5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtano5.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtano5.Text = FormatNumber(CDbl(txtano5.Text), 2)
        End If
    End Sub

    Private Sub txtano5_LostFocus(sender As Object, e As System.EventArgs) Handles txtano5.LostFocus
        txtano5.Text = FormatNumber(CDbl(txtano5.Text), 2)
    End Sub
    Private Sub txtano5_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtano5.TextChanged
        txtano5.Text = Trim(dejarNumerosPuntos(txtano5.Text))
        If (String.IsNullOrEmpty(txtano5.Text.Trim())) Then
            Me.ErrorProvider5.SetError(txtano5, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider5.Clear()
            comprobar()
        End If
    End Sub
    Private Sub enviarmail()
        Dim vldestinatarios As String
        Dim respuesta As Object
        vldestinatarios = eadmin.Text + ";" + esoporte.Text + ";" + cfinanciero.Text
        For Each myprocess In Process.GetProcesses
            'If myprocess.MainWindowTitle.Contains("Microsoft Outlook") Then
            '* Creamos un Objeto que hará referencia a nuestra aplicación Outlook 
            Dim m_OutLook As Outlook.Application
            Try
                '* Creamos un Objeto tipo Mail 
                Dim objMail As Outlook.MailItem
                '* Inicializamos nuestra apliación OutLook 
                m_OutLook = CreateObject("Outlook.Application")
                '* Creamos una instancia de un objeto tipo MailItem 
                objMail = m_OutLook.CreateItem(Outlook.OlItemType.olMailItem)
                '* Asignamos las propiedades a nuestra Instancial del objeto 
                '* MailItem 
                objMail.To = vldestinatarios
                objMail.Subject = "El contrato Numero" & " " + cmbcontrato.Text & " " + " Requiere de su atencion."
                objMail.Body = "El contrato #" & " " & cmbcontrato.Text & " " & "ha sido registrado por el área de Soporte administrativo dentro de ADMINCCO." & " " & vbCrLf & "Se requiere validación por parte del Coordinador de Análisis Financiero" & " " & coorfinaciero.Text & " " & "para continuar el proceso." & vbCrLf & "Si tiene alguna inquietud, por favor ponerse en contacto con el soporte administrativo" & " " & spadmin.Text & "  " & vbCrLf & "*Mensaje Automático Generado por ADMINCCO (Administración Centralizada de Contratos)."
                objMail.Send()
                Exit For
            Catch ex As Exception
                '* Si se produce algun Error 
                respuesta = MsgBox("No se ha podido notificar a los interezados, Desea reintentar enviar la notificacion?", MsgBoxStyle.YesNo, "Se ha producido un error al notificar")
                If respuesta = vbYes Then
                    Shell("C:\Program Files (x86)\Microsoft Office\Office14\OUTLOOK.EXE", AppWinStyle.MinimizedNoFocus)
                    enviarmail()
                ElseIf respuesta = vbNo Then
                    Exit For
                End If
                Exit Sub
            Finally
                m_OutLook = Nothing ' Destruimos el objeto (recoger la basura...)
            End Try
            'End If
        Next
    End Sub
    Private Sub txtproceso_Click(sender As Object, e As System.EventArgs) Handles txtproceso.Click
        If txtproceso.Text = "POR FAVOR INGRESE CODIGO DE PROCESO" Then
            txtproceso.Text = ""
        End If
    End Sub
    Private Sub txtcreado_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcreado.TextChanged
        ecreado.Text = txtcreado.Text & "@pacificrubiales.com.co"
        cfinanciero.Text = coorfinaciero.Text & "@pacificrubiales.com.co"
        cname.Text = txtcreado.Text
        txtcreado.Text = UCase(txtcreado.Text)
    End Sub

    Private Sub txtproceso_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtproceso.KeyPress
        cmbasociacion.Enabled = True
        ComboBox1.Enabled = True
    End Sub
    Private Sub cmbasociacion_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbasociacion.SelectedIndexChanged
        nivel3.Enabled = True
    End Sub
    Private Sub cmbasociacion_TextChanged(sender As Object, e As System.EventArgs) Handles cmbasociacion.TextChanged
        nivel3.Enabled = True
    End Sub
    Private Sub txtproceso_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtproceso.TextChanged
        Dim r As New Regex("^[a-zA-Z0-9- ]*$")
        If Not r.IsMatch(txtproceso.Text) Then
            txtproceso.Select(0, txtproceso.Text.Length)
            Me.ErrorProvider9.SetError(txtproceso, "Caracter no admitido")
        Else
            Me.ErrorProvider9.Clear()
            Me.CMOriginalesBindingSource.Filter = "PROCESO like '%" & txtproceso.Text & "%'"
            If txtproceso.Text = Label27.Text Then
                MsgBox("Este proceso ya existe")
                cmbasociacion.Enabled = False
                ComboBox1.Enabled = False
                cmbproyecto.Enabled = False
            Else
                cmbasociacion.Enabled = True
                ComboBox1.Enabled = True
                cmbproyecto.Enabled = True
            End If
        End If
    End Sub

    Private Sub txtadministrator_TabIndexChanged(sender As Object, e As System.EventArgs) Handles txtadministrator.TabIndexChanged
        cmbdisciplina.Focus()
    End Sub
    Private Sub txtadministrator_TextChanged(sender As Object, e As System.EventArgs) Handles txtadministrator.TextChanged
        cmbdisciplina.Enabled = True
        listdisciplina.Enabled = True
        eadmin.Text = txtadministrator.Text & "@pacificrubiales.com.co"
    End Sub
    Public Class Centered_Msgbox
        Implements IDisposable
        Private mTries As Integer = "0"
        Private mOwner As Form

        Public Sub New(ByVal owner As Form)
            mOwner = owner
            owner.BeginInvoke(New MethodInvoker(AddressOf findDialog))
        End Sub

        Private Sub findDialog()
            ' Enumerate windows to find the message box
            If mTries < 0 Then
                Return
            End If
            Dim callback As New EnumThreadWndProc(AddressOf checkWindow)
            If EnumThreadWindows(GetCurrentThreadId(), callback, IntPtr.Zero) Then
                If System.Threading.Interlocked.Increment(mTries) < 10 Then
                    mOwner.BeginInvoke(New MethodInvoker(AddressOf findDialog))
                End If
            End If
        End Sub
        Private Function checkWindow(ByVal hWnd As IntPtr, ByVal lp As IntPtr) As Boolean
            ' Checks if <hWnd> is a dialog
            Dim sb As New StringBuilder(260)
            GetClassName(hWnd, sb, sb.Capacity)
            If sb.ToString() <> "#32770" Then
                Return True
            End If
            ' Got it
            Dim frmRect As New Rectangle(mOwner.Location, mOwner.Size)
            Dim dlgRect As RECT
            GetWindowRect(hWnd, dlgRect)
            MoveWindow(hWnd, frmRect.Left + (frmRect.Width - dlgRect.Right + dlgRect.Left) \ 2, frmRect.Top + (frmRect.Height - dlgRect.Bottom + dlgRect.Top) \ 2, dlgRect.Right - dlgRect.Left, dlgRect.Bottom - dlgRect.Top, True)
            Return False
        End Function
        Public Sub Dispose() Implements IDisposable.Dispose
            mTries = -1
        End Sub

        ' P/Invoke declarations
        Private Delegate Function EnumThreadWndProc(ByVal hWnd As IntPtr, ByVal lp As IntPtr) As Boolean
        <DllImport("user32.dll")> _
        Private Shared Function EnumThreadWindows(ByVal tid As Integer, ByVal callback As EnumThreadWndProc, ByVal lp As IntPtr) As Boolean
        End Function
        <DllImport("kernel32.dll")> _
        Private Shared Function GetCurrentThreadId() As Integer
        End Function
        <DllImport("user32.dll")> _
        Private Shared Function GetClassName(ByVal hWnd As IntPtr, ByVal buffer As StringBuilder, ByVal buflen As Integer) As Integer
        End Function
        <DllImport("user32.dll")> _
        Private Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef rc As RECT) As Boolean
        End Function
        <DllImport("user32.dll")> _
        Private Shared Function MoveWindow(ByVal hWnd As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByVal repaint As Boolean) As Boolean
        End Function
        Private Structure RECT
            Public Left As Integer
            Public Top As Integer
            Public Right As Integer
            Public Bottom As Integer
        End Structure
    End Class
    Private Sub vlfaltante_TextChanged(sender As System.Object, e As System.EventArgs) Handles vlfaltante.TextChanged
        lblano1.Text = Year(dtfechai.Value)
        lblano2.Text = lblano1.Text + 1
        lblano3.Text = lblano2.Text + 1
        lblano4.Text = lblano3.Text + 1
        lblano5.Text = lblano4.Text + 1
    End Sub
    Private Sub cosd_TextChanged(sender As System.Object, e As System.EventArgs) Handles cosd.TextChanged
        cosd.Text = FormatNumber(cosd.Text, 2)
    End Sub

    Private Sub cosa_TextChanged(sender As System.Object, e As System.EventArgs) Handles cosa.TextChanged
        cosa.Text = FormatNumber(cosa.Text, 2)
    End Sub

    Private Sub cosi_TextChanged(sender As System.Object, e As System.EventArgs) Handles cosi.TextChanged
        cosi.Text = FormatNumber(cosi.Text, 2)
    End Sub

    Private Sub cosu_TextChanged(sender As System.Object, e As System.EventArgs) Handles cosu.TextChanged
        cosu.Text = FormatNumber(cosu.Text, 2)
    End Sub

    Private Sub cosdsu_TextChanged(sender As System.Object, e As System.EventArgs) Handles cosdsu.TextChanged
        cosdsu.Text = FormatNumber(cosdsu.Text, 2)
    End Sub

    Private Sub cosdiva_TextChanged(sender As System.Object, e As System.EventArgs) Handles cosdiva.TextChanged
        cosdiva.Text = FormatNumber(cosdiva.Text, 2)

    End Sub

    Private Sub costotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles costotal.TextChanged
        costotal.Text = FormatNumber(costotal.Text, 2)
    End Sub
    Private Sub comprobar()
        If ErrorProvider1.GetError(txtano1) = "" Then
            If ErrorProvider2.GetError(txtano2) = "" Then
                If ErrorProvider3.GetError(txtano3) = "" Then
                    If ErrorProvider4.GetError(txtano4) = "" Then
                        If ErrorProvider5.GetError(txtano5) = "" Then
                            If txtano1.Text = "" Then txtano1.Text = 0
                            If txtano2.Text = "" Then txtano2.Text = 0
                            If txtano3.Text = "" Then txtano3.Text = 0
                            If txtano4.Text = "" Then txtano4.Text = 0
                            If txtano5.Text = "" Then txtano5.Text = 0
                            vlfaltante.Text = FormatNumber(CDbl(txtano1.Text) + CDbl(txtano2.Text) + CDbl(txtano3.Text) + CDbl(txtano4.Text) + CDbl(txtano5.Text) - CDbl(vlencarta.Text))
                            If CDbl(vlfaltante.Text) = "0" Then
                                vlencarta.BackColor = Color.Turquoise
                                vlfaltante.BackColor = Color.Turquoise
                                ComboBox2.Enabled = True
                            ElseIf CDbl(vlfaltante.Text) < CDbl(vlencarta.Text) Then
                                vlencarta.BackColor = Color.AntiqueWhite
                                vlfaltante.BackColor = Color.AntiqueWhite
                                btguardar.Enabled = False
                                ComboBox2.Enabled = False
                            ElseIf CDbl(vlfaltante.Text) > CDbl(vlencarta.Text) Then
                                vlfaltante.BackColor = Color.PaleVioletRed
                                vlencarta.BackColor = Color.PaleVioletRed
                                ComboBox2.Enabled = False
                                btguardar.Enabled = False
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub cmbdisciplina_TabIndexChanged(sender As Object, e As System.EventArgs) Handles cmbdisciplina.TabIndexChanged
        cmbcontratista.Focus()
    End Sub
    Function dejarNumerosPuntos(cadenaTexto As String) As String
        Const listaNumeros = "0123456789,."
        Dim cadenaTemporal As String
        Dim i As Integer

        cadenaTexto = Trim$(cadenaTexto)
        If Len(cadenaTexto) = "0" Then
            Exit Function
        End If

        cadenaTemporal = ""

        For i = 1 To Len(cadenaTexto)
            If InStr(listaNumeros, Mid$(cadenaTexto, i, 1)) Then
                cadenaTemporal = cadenaTemporal + Mid$(cadenaTexto, i, 1)
            End If
        Next
        dejarNumerosPuntos = cadenaTemporal
    End Function
    Private Sub impreporte_Click(sender As System.Object, e As System.EventArgs) Handles impreporte.Click
        Dim mireporte As frmReportes
        mireporte = New frmReportes
        mireporte.Modelo = cmbcontrato.Text
        mireporte.Show()
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextBox2.Text = FormatNumber(CDbl(TextBox2.Text), 2)
        End If
    End Sub
    Private Sub TextBox1_LostFocus(sender As Object, e As System.EventArgs) Handles TextBox1.LostFocus
        TextBox2.Text = FormatNumber(CDbl(TextBox2.Text), 2)
    End Sub
    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = Trim(dejarNumerosPuntos(TextBox1.Text))
        If (String.IsNullOrEmpty(TextBox1.Text.Trim())) Then
            Me.ErrorProvider2.SetError(TextBox1, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider2.Clear()
            TextBox2.Text = FormatNumber((CDbl(TextBox1.Text) * CDbl(costotal.Text)) / 100, 2)
            btguardar.Enabled = True
        End If
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex = 1 Then
            TextBox1.Enabled = True
        Else
            TextBox1.Enabled = False
            TextBox1.Text = "0"
        End If
        If ComboBox2.SelectedIndex = 2 Then
            btguardar.Enabled = True
        End If
    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
End Class



