Imports Microsoft.Office.Interop
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports System.Data.SqlClient

Public Class frmaprobarcontrato
    Dim conexion = ADONETUtil.cn
    Dim comandos As New SqlCommand
    Friend hoy As Date
    Friend modo As Integer
    Friend servicio(7) As String
    Friend nservicio(7) As String
    Friend costod(7) As Double
    Friend admin(7) As Double
    Friend impre(7) As Double
    Friend util(7) As Double
    Friend subt(7) As Double
    Friend iva(7) As Double
    Friend total(7) As Double
    Friend a(7) As Integer
    Friend i(7) As Integer
    Friend u(7) As Integer
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
    Friend transpaso As Integer = 0
    Friend numero1 As Integer
    Friend nuevo As Integer = 0
    Dim str As String
    Dim str1 As String
    Dim str2 As String
    Dim str3 As String
    Friend state As String
    Friend vigenciaorg(4) As Double
    Friend traetotales(6) As Double
    Private Sub frmaprobarods_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.CMNuevos' Puede moverla o quitarla según sea necesario.
        Me.CMNuevosTableAdapter.Fill(Me.Adminco_MasterDataSet.CMNuevos)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.CMOriginales' Puede moverla o quitarla según sea necesario.
        REM Me.CMOriginalesTableAdapter.Fill(Me.Adminco_MasterDataSet.CMOriginales)
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.CMNuevos' Puede moverla o quitarla según sea necesario.
        txtmodific.Text = frmformulario.impcm
        hoy = System.DateTime.Now.Date
        REM  dtfechai.Value = hoy
        REM dtfechaf.Value = hoy
        validar()
        spname.Visible = False
        esoporte.Visible = False
        ecoorfinaciero.Visible = False
        cname.Visible = False
        eadmin.Visible = False
        ecreado.Visible = False
        txtano1.Text = FormatNumber(CDbl(txtano1.Text), 2)
        txtano2.Text = FormatNumber(CDbl(txtano2.Text), 2)
        txtano3.Text = FormatNumber(CDbl(txtano3.Text), 2)
        txtano4.Text = FormatNumber(CDbl(txtano4.Text), 2)
        txtano5.Text = FormatNumber(CDbl(txtano5.Text), 2)
        If My.Settings.usuario2.Trim = coorfinaciero.Text.Trim Then
            Button3.Enabled = True
        Else
            Button3.Enabled = False
        End If
        cmbcontrato.SelectedIndex = 1
    End Sub
    Private Sub costotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles costotal.TextChanged
        If costotal.Text = "" Then costotal.Text = 0
        costotal.Text = FormatNumber(CDbl(costotal.Text), 2)
    End Sub
    Private Sub validar()
        If My.Settings.usuario2 = txtadministrator.Text Or My.Settings.usuario2 = coorfinaciero.Text Or My.Settings.usuario2 = spadmin.Text Then
            calcvigencias.Enabled = False
            calcvigencias.Visible = False
            If My.Settings.usuario2 = spadmin.Text Then
                If cmbestado.Text = "Rechazada" Then
                    Me.ErrorProvider1.SetError(nuevovrcontrato, "Ingrese nuevo valor del contrato")
                    nuevovrcontrato.Enabled = True
                    btndistribuir.Enabled = False
                    cmbopcion.Enabled = False
                Else
                    Me.ErrorProvider1.Clear()
                    nuevovrcontrato.Enabled = False
                    nuevovrcontrato.Text = 0
                    Me.ErrorProvider6.Clear()
                End If
            End If
            CheckBox1.Enabled = False
            btndistribuir.Enabled = False
            If cmbopcion.Text = "Tiempo" Then
                nivel3.Enabled = True
                nivel7.Enabled = False
                cmbestado.Enabled = False
                CheckBox1.Enabled = True
                txtcomentarios.Enabled = True
                tiempo()
                niveles1()
                CheckBox1.Enabled = True
            End If

            If cmbopcion.Text = "Vigencia" Then
                nivel7.Enabled = False
                nivel3.Enabled = False
                cmbestado.Enabled = False
                txtcomentarios.Enabled = True
                tiempo()
                calcvigencias.Visible = True
                calcvigencias.Enabled = True
            End If

            If cmbopcion.Text = "Costo" Then
                nivel7.Enabled = False
                cmbestado.Enabled = False
                REM CheckBox1.Enabled = True
                txtcomentarios.Enabled = True
                nuevovrcontrato.Enabled = True
                Me.ErrorProvider6.SetError(nuevovrcontrato, "Por favor indique nuevo valor del contrato")

                tiempo()
            End If

            If cmbopcion.Text = "Cambiar Estado" Then
                nivel3.Enabled = False
                nivel7.Enabled = False
                btndistribuir.Enabled = False
                If cmbestado.Text = "En Aprobación" Then
                    If coorfinaciero.Text.Trim = My.Settings.usuario2.Trim Or spadmin.Text.Trim = My.Settings.usuario2.Trim Then
                        btndistribuir.Enabled = True
                        cmbopcion.Enabled = False
                    End If
                    cmbestado.Enabled = False
                    btndistribuir.Enabled = True
                    If VALIDCOST.Text = coorfinaciero.Text Then
                        If txtadministrator.Text = My.Settings.usuario2 Or spadmin.Text.Trim = My.Settings.usuario2.Trim Then
                            cmbopcion.Enabled = False
                        End If
                    End If
                ElseIf cmbestado.Text <> "Rechazada" Then
                    cmbestado.Enabled = True
                    CheckBox1.Enabled = True
                    Me.cmbestado.Items.Clear()
                    cmbestado.Items.Add("Abierto")
                    cmbestado.Items.Add("Cerrado")
                    cmbestado.Items.Add("Suspendido")
                    cmbestado.SelectedIndex = 0
                End If
            Else
            End If
        End If
    End Sub
    Private Sub verificar()
        If cmbestado.Text.Trim = "En Aprobación" Then
            Me.cmbopcion.DataSource = Nothing
            Me.cmbopcion.Items.Clear()
            cmbopcion.Items.Add("Cambiar Estado")
            cmbopcion.SelectedIndex = 0
            cmbopcion.Enabled = False
            cmbestado.Enabled = False
            txtcomentarios.Enabled = False
        Else
            Me.cmbopcion.DataSource = Nothing
            Me.cmbopcion.Items.Clear()
            cmbopcion.Items.Add("Seleccione Opcion")
            cmbopcion.Items.Add("Tiempo")
            cmbopcion.Items.Add("Vigencia")
            cmbopcion.Items.Add("Costo")
            cmbopcion.Items.Add("Cambiar Estado")
            cmbopcion.SelectedIndex = 0
            txtcomentarios.Enabled = False
        End If
        validar()
    End Sub
    Private Sub newvigenciaa_TextChanged(sender As System.Object, e As System.EventArgs) Handles newvigenciaa.TextChanged
        niveles1()
    End Sub

    Private Sub niveles1()
        If newvigenciaa.Text > 0 Then
            Select Case newvigenciaa.Text
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
    End Sub
    Private Sub tiempo()
        If cmbopcion.SelectedIndex = 1 Or cmbopcion.SelectedIndex = 4 Then
            newvigenciad.Text = dtfechaf.Value.Subtract(dtfechai.Value).TotalDays
            newvigenciaa.Text = newvigenciad.Text / 365 + 1
        Else
            newvigenciad.Text = 0
            newvigenciaa.Text = 0
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            ecoorfinaciero.Text = coorfinaciero.Text + "pacificrubiales.com.co"
            eadmin.Text = txtadministrator.Text + "pacificrubiales.com.co"
            ecreado.Text = txtcreado.Text + "pacificrubiales.com.co"
            btndistribuir.Enabled = False
            txtano1.Text = FormatNumber(CDbl(txtano1.Text), 2)
            txtano2.Text = FormatNumber(CDbl(txtano2.Text), 2)
            txtano3.Text = FormatNumber(CDbl(txtano3.Text), 2)
            txtano4.Text = FormatNumber(CDbl(txtano4.Text), 2)
            txtano4.Text = FormatNumber(CDbl(txtano4.Text), 2)
            txtano5.Text = FormatNumber(CDbl(txtano5.Text), 2)
            If cmbopcion.Text = "Por favor seleccione Opcion" Then
                MsgBox("Por favor Seleccion alguna modalidad de actualizacion del contrato")
                btndistribuir.Enabled = True
            Else
                btguardar.Enabled = False
                impreporte.Enabled = False
                If cmbestado.Text = "En Aprobación" Then
                    If My.Settings.usuario2 = spadmin.Text.Trim Then
                        VALIDCOST.Text = spadmin.Text
                        VALIDADMIN.Text = spadmin.Text
                        Me.cmbestado.DataSource = Nothing
                        Me.cmbestado.Items.Clear()
                        cmbestado.Items.Add("Abierto")
                        cmbestado.SelectedIndex = 0
                        nuevo = 2
                    Else
                        If VALIDCOST.Text <> coorfinaciero.Text Then
                            VALIDCOST.Text = coorfinaciero.Text
                            nuevo = 1
                        Else
                            If VALIDCOST.Text = coorfinaciero.Text And My.Settings.usuario2.Trim = txtadministrator.Text.Trim Then
                                VALIDADMIN.Text = txtadministrator.Text
                                Me.cmbestado.DataSource = Nothing
                                Me.cmbestado.Items.Clear()
                                cmbestado.Items.Add("Abierto")
                                cmbestado.SelectedIndex = 0
                                nuevo = 2
                            End If
                        End If
                    End If
                End If
                If cmbopcion.Text = "Tiempo" Then
                    cmbotrosi.Text = cmbotrosi.Text + CDbl(1)
                    nivel3.Enabled = False
                End If
                If cmbopcion.Text = "Costo" Then
                    cmbotrosi.Text = cmbotrosi.Text + CDbl(1)
                End If
                btguardar.Enabled = True
            End If
            cmbcontrato.Enabled = False
            cmbopcion.Enabled = False
        End If
        If CheckBox1.Checked = False Then
            cmbcontrato.Enabled = True
        End If
    End Sub
    Private Sub btguardar_Click(sender As System.Object, e As System.EventArgs) Handles btguardar.Click
        cmbopcion.Enabled = False
        cmbcontrato.Enabled = False
        guardar()
    End Sub
    Private Sub guardar()
        If conexion.State = ConnectionState.Open Then
        Else
            conexion.Open()
        End If
        Try
            comandos.CommandType = CommandType.StoredProcedure
            If cmbopcion.Text = "Tiempo" Then
                comandos.CommandText = "cmmodificatiempo"
                comandos.Connection = conexion
                comandos.Parameters.Add("@FechInicio", SqlDbType.DateTime).Value = dtfechai.Value.Date
                comandos.Parameters.Add("@FechaFinal", SqlDbType.DateTime).Value = dtfechaf.Value.Date
                comandos.Parameters.Add("@diasv", SqlDbType.Float).Value = newvigenciad.Text()
                comandos.Parameters.Add("@modificado", SqlDbType.NVarChar).Value = txtmodific.Text()
                comandos.Parameters.Add("@otrosi", SqlDbType.NVarChar).Value = cmbotrosi.Text()
                comandos.Parameters.Add("@Comentario", SqlDbType.NVarChar).Value = txtcomentarios.Text()
                comandos.Parameters.Add("@causalmodificador", SqlDbType.NVarChar).Value = cmbopcion.Text()
                comandos.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato.Text()
            End If
            If cmbopcion.Text = "Vigencia" Then
                comandos.CommandText = "cmmodificavigencia"
                comandos.Connection = conexion
                comandos.Parameters.Add("@VALOR1", SqlDbType.Float).Value = txtano1.Text()
                comandos.Parameters.Add("@VALOR2", SqlDbType.Float).Value = txtano2.Text()
                comandos.Parameters.Add("@VALOR3", SqlDbType.Float).Value = txtano3.Text()
                comandos.Parameters.Add("@VALOR4", SqlDbType.Float).Value = txtano4.Text()
                comandos.Parameters.Add("@VALOR5", SqlDbType.Float).Value = txtano5.Text()
                comandos.Parameters.Add("@modificado", SqlDbType.NVarChar).Value = txtmodific.Text()
                comandos.Parameters.Add("@Comentario", SqlDbType.NVarChar).Value = txtcomentarios.Text()
                comandos.Parameters.Add("@causalmodificador", SqlDbType.NVarChar).Value = cmbopcion.Text()
                comandos.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato.Text()
                comandos.Parameters.Add("@vigenciast1", SqlDbType.Float).Value = vigenciaorg(0)
                comandos.Parameters.Add("@vigenciast2", SqlDbType.Float).Value = vigenciaorg(1)
                comandos.Parameters.Add("@vigenciast3", SqlDbType.Float).Value = vigenciaorg(2)
                comandos.Parameters.Add("@vigenciast4", SqlDbType.Float).Value = vigenciaorg(3)
                comandos.Parameters.Add("@vigenciast5", SqlDbType.Float).Value = vigenciaorg(4)
            End If
            If cmbopcion.Text = "Costo" Then
                comandos.CommandText = "cmmodificacionvalormanual"
                comandos.Connection = conexion
                comandos.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato.Text()
                comandos.Parameters.Add("@VrCtoFirmado", SqlDbType.Float).Value = costotal.Text()
                comandos.Parameters.Add("@Costodirecto", SqlDbType.Float).Value = traetotales(0)
                comandos.Parameters.Add("@Administracion", SqlDbType.Float).Value = traetotales(1)
                comandos.Parameters.Add("@Imprevisto", SqlDbType.Float).Value = traetotales(2)
                comandos.Parameters.Add("@Utilidad", SqlDbType.Float).Value = traetotales(3)
                comandos.Parameters.Add("@Subtotal", SqlDbType.Float).Value = traetotales(4)
                comandos.Parameters.Add("@iva", SqlDbType.NVarChar).Value = traetotales(5)
                comandos.Parameters.Add("@VrContrato", SqlDbType.Float).Value = traetotales(6)
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
                comandos.Parameters.Add("@VALOR1", SqlDbType.Float).Value = txtano1.Text() REM guarda el valor la vigencia
                comandos.Parameters.Add("@VALOR2", SqlDbType.Float).Value = txtano2.Text()
                comandos.Parameters.Add("@VALOR3", SqlDbType.Float).Value = txtano3.Text()
                comandos.Parameters.Add("@VALOR4", SqlDbType.Float).Value = txtano4.Text()
                comandos.Parameters.Add("@VALOR5", SqlDbType.Float).Value = txtano5.Text()
                comandos.Parameters.Add("@modificado", SqlDbType.NVarChar).Value = txtmodific.Text()
                comandos.Parameters.Add("@otrosi", SqlDbType.NVarChar).Value = cmbotrosi.Text()
                comandos.Parameters.Add("@comentario", SqlDbType.NVarChar).Value = txtcomentarios.Text()
                comandos.Parameters.Add("@causalmodificador", SqlDbType.NVarChar).Value = cmbopcion.Text()
                comandos.Parameters.Add("@saldoglobal", SqlDbType.Float).Value = impvrgtotal
                comandos.Parameters.Add("@saldodirecto", SqlDbType.Float).Value = cosd.Text()
                comandos.Parameters.Add("@saldoadmin", SqlDbType.Float).Value = cosa.Text()
                comandos.Parameters.Add("@saldoimpre", SqlDbType.Float).Value = cosi.Text()
                comandos.Parameters.Add("@saldoutil", SqlDbType.Float).Value = cosu.Text()
                comandos.Parameters.Add("@saldosubtotal", SqlDbType.Float).Value = cosdsu.Text()
                comandos.Parameters.Add("@saldoiva", SqlDbType.Float).Value = cosdiva.Text()
                comandos.Parameters.Add("@saldototal", SqlDbType.Float).Value = costotal.Text()
                comandos.Parameters.Add("@vigenciast1", SqlDbType.Float).Value = CDbl(vigenciaorg(0))
                comandos.Parameters.Add("@vigenciast2", SqlDbType.Float).Value = CDbl(vigenciaorg(1))
                comandos.Parameters.Add("@vigenciast3", SqlDbType.Float).Value = CDbl(vigenciaorg(2))
                comandos.Parameters.Add("@vigenciast4", SqlDbType.Float).Value = CDbl(vigenciaorg(3))
                comandos.Parameters.Add("@vigenciast5", SqlDbType.Float).Value = CDbl(vigenciaorg(4))
            End If

            REM guarda en caso de cambiar estado manualmente
            If cmbopcion.Text = "Cambiar Estado" And cmbopcion.Enabled = True Then
                comandos.CommandText = "cmmodificacionestadomanual"
                comandos.Connection = conexion
                comandos.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = cmbestado.Text()
                comandos.Parameters.Add("@Comentario", SqlDbType.NVarChar).Value = txtcomentarios.Text()
                comandos.Parameters.Add("@causalmodificador", SqlDbType.NVarChar).Value = cmbopcion.Text()
                comandos.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato.Text()
            End If
            If cmbopcion.Text = "Cambiar Estado" And cmbopcion.Enabled = False Then
                comandos.CommandText = "cmmodificaautoriza"
                comandos.Connection = conexion
                comandos.Parameters.Add("@Estado", SqlDbType.NVarChar).Value = cmbestado.Text()
                comandos.Parameters.Add("@VALIDACOST", SqlDbType.NVarChar).Value = VALIDCOST.Text()
                comandos.Parameters.Add("@VALIDAADMIN", SqlDbType.NVarChar).Value = VALIDADMIN.Text()
                comandos.Parameters.Add("@modificado", SqlDbType.NVarChar).Value = txtmodific.Text()
                comandos.Parameters.Add("@Comentario", SqlDbType.NVarChar).Value = txtcomentarios.Text()
                comandos.Parameters.Add("@causalmodificador", SqlDbType.NVarChar).Value = cmbopcion.Text()
                comandos.Parameters.Add("@Contratos", SqlDbType.NVarChar).Value = cmbcontrato.Text()
                If nuevo = 1 Then
                    guardar1()
                End If
                If nuevo = 2 Then
                    guardar2()
                End If
            End If
            comandos.ExecuteNonQuery()
            comandos.Dispose()
            CheckBox1.Enabled = False
            btguardar.Enabled = False
            nivel1.Enabled = False
            nivel2.Enabled = False
            nivel3.Enabled = False
            nivel4.Enabled = False
            nivel5.Enabled = False
            nivel7.Enabled = False
            impreporte.Enabled = False
            Button1.Enabled = False
            cmbestado.Enabled = False
            conexion.Close()
            MsgBox("Guardado Corectamente", vbInformation, ("Guardado"))
            verificaremail()
            nuevo = 0
            modo = 0
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod11-fun-01:" & "_" & ex.Message)
        End Try
        If cmbestado.Text.Trim = "Abierto" Then
            impreporte.Enabled = True
        Else
            impreporte.Enabled = False
        End If
    End Sub
    Private Sub guardar1()
        REM valida costo
        REM Dim str As String
        str3 = "Update CMOriginales SET Estado = '" & cmbestado.Text & "', VALIDACOST = '" & VALIDCOST.Text & "' Where Contratos = '" & cmbcontrato.Text & "'"
    End Sub
    Private Sub guardar2()
        REM validan todos
        str1 = "Update CMOriginales SET Estado = '" & cmbestado.Text & "', VALIDACOST = '" & VALIDCOST.Text & "', VALIDAADMIN = '" & VALIDADMIN.Text & "' Where Contratos = '" & cmbcontrato.Text & "'"
        CheckBox1.Enabled = False
    End Sub
    Private Sub verificaremail()
        If VALIDCOST.Text.Trim = coorfinaciero.Text.Trim And VALIDADMIN.Text.Trim <> txtadministrator.Text.Trim Then
            enviarmail1()
        End If
        If VALIDCOST.Text.Trim = coorfinaciero.Text.Trim And VALIDADMIN.Text = txtadministrator.Text.Trim Then
            enviarmail2()
        End If

        If modo = 4 Then
            enviarmail4()
        End If
        If nuevo = 3 Then REM envia mensaje de vigencias
            mensajevigencias()
        End If
    End Sub
    Private Sub dtfechaf_TextChanged(sender As Object, e As System.EventArgs) Handles dtfechaf.TextChanged
        Dim number As Integer
        If newvigenciad.Text <> "" Then
            If newvigenciad.Text > 0 Then
                number = FormatNumber(CDbl(newvigenciad.Text) / 365)
                Math.Ceiling(number)
                newvigenciaa.Text = number + 1
            End If
        End If
    End Sub
    Private Sub dtfechaf_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtfechaf.ValueChanged
        Dim number As Integer
        If cmbopcion.SelectedIndex = 1 Or cmbopcion.SelectedIndex = 4 Then
            newvigenciad.Text = dtfechaf.Value.Subtract(dtfechai.Value).TotalDays

            number = FormatNumber(CDbl(newvigenciad.Text) / 365)
            Math.Ceiling(number)
            newvigenciaa.Text = number + 1
        Else
            newvigenciad.Text = 0
            newvigenciaa.Text = 0
        End If
    End Sub

    Private Sub impreporte_Click(sender As System.Object, e As System.EventArgs) Handles impreporte.Click
        If cmbopcion.SelectedIndex = 0 Then
            numero1 = 1
            Dim mireporte As restadoactualcm
            mireporte = New restadoactualcm
            mireporte.Modelo = cmbcontrato.Text
            mireporte.Show()
        Else
            Dim mireporte As restadoactualcm
            mireporte = New restadoactualcm
            numero1 = 1
            mireporte.Modelo = cmbcontrato.Text
            mireporte.Show()
        End If
    End Sub
    Private Sub btndistribuir_Click(sender As System.Object, e As System.EventArgs) Handles btndistribuir.Click
        REM se aplica cuando se rechaza una ODS
        If cmbopcion.Text = "Seleccione Opcion" And cmbestado.Text = "Rechazada" Then
            frmestructurarechazada.valornet = cmbcontrato.Text
            frmestructurarechazada.impservicio = nuevovrcontrato.Text
            frmestructurarechazada.ShowDialog()
            frmestructurarechazada.Dispose()
            REM se aplica cuando se aprueba una ODS
        ElseIf cmbopcion.Text = "Cambiar Estado" Then
            validarestructuramacro.valornet = cmbcontrato.Text
            validarestructuramacro.impservicio1 = costotal.Text
            validarestructuramacro.ShowDialog()
            validarestructuramacro.Dispose()
            REM se aplica cuando se va a realizar un otrosi x costo
        Else
            modificarestructuracm.valornet = cmbcontrato.Text
            modificarestructuracm.vroriginal.Text = nuevovrcontrato.Text
            modificarestructuracm.ShowDialog()
            modificarestructuracm.Dispose()
        End If
        txtano1.Text = FormatNumber(CDbl(txtano1.Text), 2)
        txtano2.Text = FormatNumber(CDbl(txtano2.Text), 2)
        txtano3.Text = FormatNumber(CDbl(txtano3.Text), 2)
        txtano4.Text = FormatNumber(CDbl(txtano4.Text), 2)
    End Sub
    Private Sub textObjeto_TextChanged(sender As System.Object, e As System.EventArgs) Handles textObjeto.TextChanged
        btndistribuir.Enabled = False
        calcvigencias.Visible = False
        calcvigencias.Enabled = False
        If TextBox1.Text <> "" Then
            MsgBox("Este contrato se encuentra bloqueado por el usuario " & TextBox1.Text & " Por favor espere unos minutos e ingrese nuevamente")
        Else
            If txtadministrator.Text = My.Settings.usuario2 Or spadmin.Text = My.Settings.usuario2 Then
                If cmbestado.Text <> "Rechazada" Then
                    cmbopcion.Enabled = True
                    CheckBox1.Checked = False
                    CheckBox1.Enabled = False
                    cmbestado.Enabled = False
                End If
            Else
                cmbopcion.Enabled = False
                CheckBox1.Enabled = False
                CheckBox1.Checked = False
                cmbestado.Enabled = False
            End If
        End If
        verificar()
        comprobar()
    End Sub
    Private Sub cmbopcion_TextChanged(sender As Object, e As System.EventArgs) Handles cmbopcion.TextChanged
        validar()
        txtcomentarios.Enabled = True
    End Sub
    Private Sub enviarmail1()
        Dim vldestinatarios As String
        Dim respuesta As Object
        vldestinatarios = ecoorfinaciero.Text + ";" + eadmin.Text + ";" + ecreado.Text
        If CheckBox1.Checked = False Then
        Else
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
                    objMail.Subject = "El contrato #" & " " + cmbcontrato.Text & " " + "ha sido aprobado por el área Financiera dentro de ADMINCCO."
                    objMail.Body = "El contrato #" & " " & cmbcontrato.Text & " " & "ha sido aprobado por el área Financiera dentro de ADMINCCO." & " " & vbCrLf & " Se requiere validación por parte del Administrador de contrato:" & " " & txtadministrator.Text & "  " & vbCrLf & "si tiene alguna inquietud, favor contactar a soporte administrativo: " & " " & spadmin.Text & " " & vbCrLf & "*Mensaje Automático Generado por ADMINCCO (Administración Centralizada de Contratos)."
                    objMail.Send()
                    Exit For
                Catch ex As Exception
                    '* Si se produce algun Error 
                    respuesta = MsgBox("No se ha podido notificar a los interezados, Desea reintentar enviar la notificacion?", MsgBoxStyle.YesNo, "Se ha producido un error al notificar")
                    If respuesta = vbYes Then
                        Shell("C:\Program Files (x86)\Microsoft Office\Office14\OUTLOOK.EXE", AppWinStyle.MinimizedNoFocus)
                        enviarmail1()
                    ElseIf respuesta = vbNo Then
                        Exit For
                    End If
                    Exit Sub
                Finally
                    m_OutLook = Nothing ' Destruimos el objeto (recoger la basura...)
                End Try
                'End If
            Next
        End If
    End Sub
    Private Sub enviarmail2()
        Dim vldestinatarios1 As String
        Dim respuesta As Object
        vldestinatarios1 = ecoorfinaciero.Text + ";" + eadmin.Text + ";" + ecreado.Text
        If CheckBox1.Checked = False Then
        Else
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
                    objMail.To = vldestinatarios1
                    objMail.Subject = "El contrato #" & " " + cmbcontrato.Text & " " + "ha sido aprobado por" & " " & txtadministrator.Text
                    objMail.Body = "El contrato #" & " " & cmbcontrato.Text & " " & "ha sido aprobado por el Administrador del contrato" & " " & txtadministrator.Text & " " & "dentro de ADMINCCO." & vbCrLf & "El estado actual del contrato es Abierto." & vbCrLf & "si tiene alguna inquietud, favor contactar a soporte administrativo:" & " " & spadmin.Text & " " & vbCrLf & "*Mensaje Automático Generado por ADMINCCO (Administración Centralizada de Contratos)."
                    objMail.Send()
                    Exit For
                Catch ex As Exception
                    '* Si se produce algun Error 
                    respuesta = MsgBox("No se ha podido notificar a los interezados, Desea reintentar enviar la notificacion?", MsgBoxStyle.YesNo, "Se ha producido un error al notificar")

                    If respuesta = vbYes Then
                        Shell("C:\Program Files (x86)\Microsoft Office\Office14\OUTLOOK.EXE", AppWinStyle.MinimizedNoFocus)
                        enviarmail2()
                    ElseIf respuesta = vbNo Then
                        Exit For
                    End If
                    Exit Sub
                Finally
                    m_OutLook = Nothing ' Destruimos el objeto (recoger la basura...)
                End Try
                'End If
            Next
        End If
    End Sub
    Private Sub mensajevigencias()
        Dim vldestinatariosvigencias As String
        Dim respuesta As Object
        vldestinatariosvigencias = ecoorfinaciero.Text + ";" + eadmin.Text + ";" + ecreado.Text
        If CheckBox1.Checked = False Then
        Else
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
                    objMail.To = vldestinatariosvigencias
                    objMail.Subject = "El contrato #" & " " + cmbcontrato.Text & " " + "ha cambiado sus vigencias por" & " " & My.Settings.usuario2
                    objMail.Body = "El contrato #" & " " & cmbcontrato.Text & " " & "ha cambiado sus vigencias TOTALES por las siguientes:" & " " & vbCrLf & lblano1.Text & ": " & CDbl(vigenciaorg(0)) & vbCrLf & lblano2.Text & ": " & CDbl(vigenciaorg(1)) & vbCrLf & lblano3.Text & " " & CDbl(vigenciaorg(2)) & vbCrLf & lblano4.Text & ": " & CDbl(vigenciaorg(3)) & vbCrLf & lblano5.Text & ": " & CDbl(vigenciaorg(4)) & vbCrLf & "Los nuevos saldos son los siguientes: " & vbCrLf & lblano1.Text & ": " & txtano1.Text & vbCrLf & lblano2.Text & ": " & txtano2.Text & vbCrLf & lblano3.Text & ": " & txtano3.Text & vbCrLf & lblano4.Text & ": " & txtano4.Text & vbCrLf & lblano5.Text & ": " & txtano5.Text & vbCrLf & "Si tiene alguna inquietud, por favor contactar a:" & " " & My.Settings.usuario2 & " " & vbCrLf & "*Mensaje Automático Generado por ADMINCCO (Administración Centralizada de Contratos)."
                    objMail.Send()
                    Exit For
                Catch ex As Exception
                    '* Si se produce algun Error 
                    respuesta = MsgBox("No se ha podido notificar a los interezados, Desea reintentar enviar la notificacion?", MsgBoxStyle.YesNo, "Se ha producido un error al notificar")

                    If respuesta = vbYes Then
                        Shell("C:\Program Files (x86)\Microsoft Office\Office14\OUTLOOK.EXE", AppWinStyle.MinimizedNoFocus)
                        mensajevigencias()
                    ElseIf respuesta = vbNo Then
                        Exit For
                    End If
                    Exit Sub
                Finally
                    m_OutLook = Nothing ' Destruimos el objeto (recoger la basura...)
                End Try
                'End If
            Next
        End If
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ecoorfinaciero.Text = coorfinaciero.Text + "pacificrubiales.com.co"
        eadmin.Text = txtadministrator.Text + "pacificrubiales.com.co"
        ecreado.Text = txtcreado.Text + "pacificrubiales.com.co"
        Try
            Dim str As String
            str = "Update CMOriginales SET Estado = '" & cmbestado.Text & "' Where Contratos = '" & cmbcontrato.Text & "'"
            comandos = New SqlCommand(str, conexion)
            comandos.ExecuteNonQuery()
            MsgBox("Guardado Corectamente", vbInformation, ("Guardado"))
            enviarmail3()
            Button1.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Notificar error codigo Mod11-fun-02:" & "_" & ex.Message)
        End Try
    End Sub
    Private Sub enviarmail3()
        Dim vldestinatarios As String
        Dim respuesta As Object
        vldestinatarios = ecoorfinaciero.Text + ";" + eadmin.Text + ";" + ecreado.Text
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
                objMail.Subject = "El contrato #" & " " + cmbcontrato.Text & " " + "ha sido RECHAZADO por " & My.Settings.usuario2 & "dentro de ADMINCCO."
                objMail.Body = "El contrato #" & " " & cmbcontrato.Text & " " & "ha sido RECHAZADO por " & My.Settings.usuario2 & " dentro de ADMINCCO." & " " & vbCrLf & " Se requiere atencion por parte del soporte administrativo:" & " " & spadmin.Text & " y  del administrador " & txtadministrator.Text & vbCrLf & "si tiene alguna inquietud, favor contactar a: " & " " & My.Settings.usuario2 & " " & vbCrLf & "*Mensaje Automático Generado por ADMINCCO (Administración Centralizada de Contratos)."
                objMail.Send()
                Exit For
            Catch ex As Exception
                '* Si se produce algun Error 
                respuesta = MsgBox("No se ha podido notificar a los interezados, Desea reintentar enviar la notificacion?", MsgBoxStyle.YesNo, "Se ha producido un error al notificar")
                If respuesta = vbYes Then
                    Shell("C:\Program Files (x86)\Microsoft Office\Office14\OUTLOOK.EXE", AppWinStyle.MinimizedNoFocus)
                    enviarmail3()
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
    Private Sub enviarmail4()
        Dim vldestinatarios As String
        Dim respuesta As Object
        vldestinatarios = ecoorfinaciero.Text + ";" + eadmin.Text + ";" + ecreado.Text
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
                objMail.Body = "El contrato #" & " " & cmbcontrato.Text & " " & "ha sido modificado por el área de Soporte administrativo dentro de ADMINCCO." & " " & vbCrLf & "Se requiere nuevamente validación por parte del Coordinador de Análisis Financiero" & " " & coorfinaciero.Text & " " & "para continuar el proceso." & vbCrLf & "Si tiene alguna inquietud, por favor ponerse en contacto con el soporte administrativo" & " " & spadmin.Text & "  " & vbCrLf & "*Mensaje Automático Generado por ADMINCCO (Administración Centralizada de Contratos)."
                objMail.Send()
                Exit For
            Catch ex As Exception
                '* Si se produce algun Error 
                respuesta = MsgBox("No se ha podido notificar a los interezados, Desea reintentar enviar la notificacion?", MsgBoxStyle.YesNo, "Se ha producido un error al notificar")
                If respuesta = vbYes Then
                    Shell("C:\Program Files (x86)\Microsoft Office\Office14\OUTLOOK.EXE", AppWinStyle.MinimizedNoFocus)
                    enviarmail4()
                ElseIf respuesta = vbNo Then
                    Exit For
                End If
                Exit Sub
            Finally
                m_OutLook = Nothing ' Destruimos el objeto (recoger la basura...)
            End Try
            'End If
        Next
        CheckBox1.Enabled = False
    End Sub
    Private Sub cmbopcion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbopcion.SelectedIndexChanged
        If cmbopcion.Text <> "Seleccione Opcion" Then
            validar()
            Try
                If conexion.State = ConnectionState.Open Then
                Else
                    conexion.Open()
                End If
                Dim str4 As String
                str4 = "Update CMNuevos SET lock = '" & My.Settings.usuario2 & "'  Where Contratos = '" & cmbcontrato.Text & "'"
                comandos = New SqlCommand(str4, conexion)
                comandos.ExecuteNonQuery()
                TextBox1.Text = My.Settings.usuario2
            Catch ex As Exception
                MessageBox.Show("Notificar error codigo Mod11-fun-03:" & "_" & ex.Message)
            End Try
        End If
    End Sub
    Private Sub cosd_TextChanged(sender As System.Object, e As System.EventArgs) Handles cosd.TextChanged
        If cosd.Text = "" Then cosd.Text = 0
        cosd.Text = FormatNumber(CDbl(cosd.Text), 2)
    End Sub
    Private Sub cosa_TextChanged(sender As System.Object, e As System.EventArgs) Handles cosa.TextChanged
        If cosa.Text = "" Then cosa.Text = 0
        cosa.Text = FormatNumber(CDbl(cosa.Text), 2)
    End Sub

    Private Sub cosi_TextChanged(sender As System.Object, e As System.EventArgs) Handles cosi.TextChanged
        If cosi.Text = "" Then cosi.Text = 0
        cosi.Text = FormatNumber(CDbl(cosi.Text), 2)
    End Sub

    Private Sub cosu_TextChanged(sender As System.Object, e As System.EventArgs) Handles cosu.TextChanged
        If cosu.Text = "" Then cosu.Text = 0
        cosu.Text = FormatNumber(CDbl(cosu.Text), 2)
    End Sub

    Private Sub cosdsu_TextChanged(sender As System.Object, e As System.EventArgs) Handles cosdsu.TextChanged
        If cosdsu.Text = "" Then cosdsu.Text = 0
        cosdsu.Text = FormatNumber(CDbl(cosdsu.Text), 2)
    End Sub

    Private Sub cosdiva_TextChanged(sender As System.Object, e As System.EventArgs) Handles cosdiva.TextChanged
        If cosdiva.Text = "" Then cosdiva.Text = 0
        cosdiva.Text = FormatNumber(CDbl(cosdiva.Text), 2)
    End Sub
    Private Sub vlfaltante_TextChanged(sender As System.Object, e As System.EventArgs) Handles vlfaltante.TextChanged
        If vlfaltante.Text = "" Then vlfaltante.Text = 0
        vlfaltante.Text = FormatNumber(CDbl(vlfaltante.Text), 2)
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
        If txtano1.Enabled = False Then
            If txtano1.Text = "" Then txtano1.Text = 0
            txtano1.Text = FormatNumber(CDbl(txtano1.Text), 2)
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
        If txtano2.Enabled = False Then
            If txtano2.Text = "" Then txtano2.Text = 0
            txtano2.Text = FormatNumber(CDbl(txtano2.Text), 2)
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
        If txtano3.Enabled = False Then
            If txtano3.Text = "" Then txtano3.Text = 0
            txtano3.Text = FormatNumber(CDbl(txtano3.Text), 2)
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
        If txtano4.Enabled = False Then
            If txtano4.Text = "" Then txtano4.Text = 0
            txtano4.Text = FormatNumber(CDbl(txtano4.Text), 2)
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
        If txtano5.Enabled = False Then
            If txtano5.Text = "" Then txtano5.Text = 0
            txtano5.Text = FormatNumber(CDbl(txtano5.Text), 2)
        End If
    End Sub
    Private Sub comprobar()
        If ErrorProvider1.GetError(txtano1) = "" Then
            If ErrorProvider2.GetError(txtano2) = "" Then
                If ErrorProvider3.GetError(txtano3) = "" Then
                    If ErrorProvider4.GetError(txtano4) = "" Then
                        If ErrorProvider5.GetError(txtano5) = "" Then
                            If costotal.Text = "" Then costotal.Text = 0
                            If txtano1.Text = "" Then txtano1.Text = 0
                            If txtano2.Text = "" Then txtano2.Text = 0
                            If txtano3.Text = "" Then txtano3.Text = 0
                            If txtano4.Text = "" Then txtano4.Text = 0
                            If txtano5.Text = "" Then txtano5.Text = 0
                        Else
                            If calcvigencias.Visible = True Then
                            Else
                                vlfaltante.Text = FormatNumber(CDbl(txtano1.Text) + CDbl(txtano2.Text) + CDbl(txtano3.Text) + CDbl(txtano4.Text) + CDbl(txtano5.Text) - CDbl(costotal.Text))
                                If cmbestado.Text = "Rechazada" And ErrorProvider1.GetError(nuevovrcontrato) = "" And My.Settings.usuario2 = spadmin.Text Then
                                    CheckBox1.Enabled = True
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    Friend Sub validador()
        If transpaso = 1 Then
            If My.Settings.usuario2 = coorfinaciero.Text.Trim And VALIDCOST.Text <> coorfinaciero.Text.Trim Then
                CheckBox1.Enabled = True
            End If
            If My.Settings.usuario2 = txtadministrator.Text.Trim And coorfinaciero.Text = VALIDCOST.Text.Trim Then
                CheckBox1.Enabled = True
            End If
            If My.Settings.usuario2 = spadmin.Text Then
                CheckBox1.Enabled = True
            End If
        End If
        If transpaso <> 1 Then
            CheckBox1.Enabled = False
        End If
    End Sub

    Friend Sub cancelado()
        If cmbestado.Text = "Rechazada" Then
            CheckBox1.Enabled = False
            CheckBox1.Checked = False
            btguardar.Enabled = False
            impreporte.Enabled = False
            Button1.Enabled = True
        End If
    End Sub

    Private Sub limpiar()
        cosd.DataBindings.Clear()
        cosa.DataBindings.Clear()
        cosi.DataBindings.Clear()
        cosu.DataBindings.Clear()
        cosdsu.DataBindings.Clear()
        cosdiva.DataBindings.Clear()
        costotal.DataBindings.Clear()
        lblano1.DataBindings.Clear()
        lblano2.DataBindings.Clear()
        lblano3.DataBindings.Clear()
        lblano4.DataBindings.Clear()
        lblano5.DataBindings.Clear()
        txtano1.DataBindings.Clear()
        txtano2.DataBindings.Clear()
        txtano3.DataBindings.Clear()
        txtano4.DataBindings.Clear()
        txtano5.DataBindings.Clear()
    End Sub
    Private Sub cmbestado_TextChanged(sender As Object, e As System.EventArgs) Handles cmbestado.TextChanged
        If cmbestado.Text = "Rechazada" And My.Settings.usuario2 <> spadmin.Text Or My.Settings.usuario2 <> spadmin.Text Then
            CheckBox1.Enabled = False
        End If
    End Sub

    Private Sub nuevovrcontrato_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles nuevovrcontrato.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            nuevovrcontrato.Text = FormatNumber(CDbl(nuevovrcontrato.Text), 2)
        End If
    End Sub

    Private Sub nuevovrcontrato_LostFocus(sender As Object, e As System.EventArgs) Handles nuevovrcontrato.LostFocus
        nuevovrcontrato.Text = FormatNumber(CDbl(nuevovrcontrato.Text), 2)
    End Sub
    Private Sub nuevovrcontrato_TextChanged(sender As System.Object, e As System.EventArgs) Handles nuevovrcontrato.TextChanged
        nuevovrcontrato.Text = Trim(dejarNumerosPuntos(nuevovrcontrato.Text))
        If (String.IsNullOrEmpty(nuevovrcontrato.Text.Trim())) Then
            Me.ErrorProvider1.SetError(nuevovrcontrato, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider1.Clear()
            If nuevovrcontrato.Text > 0 Then
                btndistribuir.Enabled = True
            End If
        End If
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
    Private Sub cos_TextChanged(sender As System.Object, e As System.EventArgs) Handles cosd.TextChanged
        If cosd.Text = "" Then cosd.Text = 0
        cosd.Text = FormatNumber(CDbl(cosd.Text), 2)
    End Sub
    Friend Sub nuevoproceso()
        If modo = 4 Then
            nuevovrcontrato.Enabled = False
            Me.ErrorProvider6.Clear()
            nivel7.Enabled = True
            REM MESTRA LOS SALDOS
            cosd.Text = cosdirecto
            cosa.Text = imptxtcostadminglobal
            cosi.Text = imptxtcostimpglobal
            cosu.Text = imptxtcostutilglobal
            cosdsu.Text = imptxtcostsubglobal
            cosdiva.Text = imptxtcostivaglobal
            costotal.Text = impvrgtotal
            REM vlfaltante.Text = impvrgtotal
            btndistribuir.Enabled = False
            If txtvigencia.Text > "0" Then
                calcvigencias.Enabled = True
                calcvigencias.Visible = True
            Else
                calcvigencias.Enabled = False
                calcvigencias.Visible = False
            End If
        End If
    End Sub

    Private Sub txtproceso_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtproceso.TextChanged
        If My.Settings.usuario2.Trim = coorfinaciero.Text.Trim Then
            Button3.Enabled = True
        Else
            Button3.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Form13.ShowDialog()
        Form13.Dispose()
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub cerrar()
        If TextBox1.Text = My.Settings.usuario2 Then
            Try
                If conexion.State = ConnectionState.Open Then
                Else
                    conexion.Open()
                End If
                Dim str4 As String
                str4 = "Update CMNuevos SET lock = '" & "" & "'  Where Contratos = '" & cmbcontrato.Text & "'"
                comandos = New SqlCommand(str4, conexion)
                comandos.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Notificar error codigo Mod11-fun-04:" & "_" & ex.Message)
            End Try
        End If
        frmmenu.Show()
        frmmenu.retorno = 1
    End Sub
    Private Sub frmaprobarods_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case e.CloseReason
            Case CloseReason.ApplicationExitCall
                cerrar()
            Case CloseReason.FormOwnerClosing
                cerrar()
            Case CloseReason.MdiFormClosing
                cerrar()
            Case CloseReason.None
                cerrar()
            Case CloseReason.TaskManagerClosing
                cerrar()
            Case CloseReason.UserClosing
                cerrar()
            Case CloseReason.WindowsShutDown
                cerrar()
            Case Else
                cerrar()
        End Select
    End Sub

    Private Sub calcvigencias_Click(sender As Object, e As EventArgs) Handles calcvigencias.Click
        Form12.contrato.Text = cmbcontrato.Text
        Form12.cmbopcion = cmbopcion.Text
        Form12.vigencia = txtvigencia.Text
        Form12.ShowDialog()
        Form12.Dispose()
    End Sub
End Class