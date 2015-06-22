Imports System.Text.RegularExpressions
Imports System.Windows.Forms.ErrorProvider
Public Class validarestructuramacro
    Public Property ValidateEmptyText As Boolean
    Public valornet As String = 0 ' traer el valor del contrato
    Public impservicio1 As String 'trae el nombre del servicio

    Private Sub validarestructuramacro_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
        txtvalorcontcart.Text = valornet
        Label10.Text = impservicio1
        WindowState = FormWindowState.Normal
        Me.CMOriginalesTableAdapter.Fill(Me.Adminco_MasterDataSet.CMOriginales)
    End Sub

    Private Sub btncancelar_Click(sender As System.Object, e As System.EventArgs) Handles btncancelar.Click
        frmaprobarcontrato.transpaso = 0
        frmaprobarcontrato.validador()
        Me.Close()
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            btnaceptar.Enabled = True
            Button1.Enabled = False
        End If
        If CheckBox1.Checked = False Then
            btnaceptar.Enabled = False
            Button1.Enabled = True
        End If
    End Sub
    Private Sub txtcostdglobal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcostdglobal.TextChanged
        If txtcostdglobal.Text = "" Then txtcostdglobal.Text = 0
        txtcostdglobal.Text = FormatNumber(CDbl(txtcostdglobal.Text), 2)
    End Sub

    Private Sub txtcostadminglobal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcostadminglobal.TextChanged
        If txtcostadminglobal.Text = "" Then txtcostadminglobal.Text = 0
        txtcostadminglobal.Text = FormatNumber(CDbl(txtcostadminglobal.Text), 2)
    End Sub

    Private Sub txtcostimpglobal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcostimpglobal.TextChanged
        If txtcostimpglobal.Text = "" Then txtcostimpglobal.Text = 0
        txtcostimpglobal.Text = FormatNumber(CDbl(txtcostimpglobal.Text), 2)
    End Sub

    Private Sub txtcostutilglobal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcostutilglobal.TextChanged
        If txtcostutilglobal.Text = "" Then txtcostutilglobal.Text = 0
        txtcostutilglobal.Text = FormatNumber(CDbl(txtcostutilglobal.Text), 2)
    End Sub

    Private Sub txtcostsubglobal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcostsubglobal.TextChanged
        If txtcostsubglobal.Text = "" Then txtcostsubglobal.Text = 0
        txtcostsubglobal.Text = FormatNumber(CDbl(txtcostsubglobal.Text), 2)
    End Sub

    Private Sub txtcostivaglobal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtcostivaglobal.TextChanged
        If txtcostivaglobal.Text = "" Then txtcostivaglobal.Text = 0
        txtcostivaglobal.Text = FormatNumber(CDbl(txtcostivaglobal.Text), 2)
    End Sub

    Private Sub vrgtotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles vrgtotal.TextChanged
        If vrgtotal.Text = "" Then vrgtotal.Text = 0
        vrgtotal.Text = FormatNumber(CDbl(vrgtotal.Text), 2)
    End Sub

    Private Sub costod1_TextChanged(sender As System.Object, e As System.EventArgs) Handles costod1.TextChanged
        If costod1.Text = "" Then costod1.Text = 0
        costod1.Text = FormatNumber(CDbl(costod1.Text), 2)
    End Sub
    Private Sub costod2_TextChanged(sender As System.Object, e As System.EventArgs) Handles costod2.TextChanged
        If costod2.Text = "" Then costod2.Text = 0
        costod2.Text = FormatNumber(CDbl(costod2.Text), 2)
    End Sub
    Private Sub costod3_TextChanged(sender As System.Object, e As System.EventArgs) Handles costod3.TextChanged
        If costod3.Text = "" Then costod3.Text = 0
        costod3.Text = FormatNumber(CDbl(costod3.Text), 2)
    End Sub
    Private Sub costod4_TextChanged(sender As System.Object, e As System.EventArgs) Handles costod4.TextChanged
        If costod4.Text = "" Then costod4.Text = 0
        costod4.Text = FormatNumber(CDbl(costod4.Text), 2)
    End Sub
    Private Sub costod5_TextChanged(sender As System.Object, e As System.EventArgs) Handles costod5.TextChanged
        If costod5.Text = "" Then costod5.Text = 0
        costod5.Text = FormatNumber(CDbl(costod5.Text), 2)

    End Sub
    Private Sub costod6_TextChanged(sender As System.Object, e As System.EventArgs) Handles costod6.TextChanged
        If costod6.Text = "" Then costod6.Text = 0
        costod6.Text = FormatNumber(CDbl(costod6.Text), 2)

    End Sub
    Private Sub costod7_TextChanged(sender As System.Object, e As System.EventArgs) Handles costod7.TextChanged
        If costod7.Text = "" Then costod7.Text = 0
        costod7.Text = FormatNumber(CDbl(costod7.Text), 2)

    End Sub
    Private Sub costod8_TextChanged(sender As System.Object, e As System.EventArgs) Handles costod8.TextChanged
        If costod8.Text = "" Then costod8.Text = 0
        costod8.Text = FormatNumber(CDbl(costod8.Text), 2)
    End Sub

    Private Sub Admin1_TextChanged(sender As System.Object, e As System.EventArgs) Handles Admin1.TextChanged
        If Admin1.Text = "" Then Admin1.Text = 0
        Admin1.Text = FormatNumber(CDbl(Admin1.Text), 2)
    End Sub

    Private Sub util1_TextChanged(sender As System.Object, e As System.EventArgs) Handles util1.TextChanged
        If util1.Text = "" Then util1.Text = 0
        util1.Text = FormatNumber(CDbl(util1.Text), 2)
    End Sub

    Private Sub impre1_TextChanged(sender As System.Object, e As System.EventArgs) Handles impre1.TextChanged
        If impre1.Text = "" Then impre1.Text = 0
        impre1.Text = FormatNumber(CDbl(impre1.Text), 2)
    End Sub

    Private Sub subt1_TextChanged(sender As System.Object, e As System.EventArgs) Handles subt1.TextChanged
        If subt1.Text = "" Then subt1.Text = 0
        subt1.Text = FormatNumber(CDbl(subt1.Text), 2)
    End Sub

    Private Sub iva1_TextChanged(sender As System.Object, e As System.EventArgs) Handles iva1.TextChanged
        If iva1.Text = "" Then iva1.Text = 0
        iva1.Text = FormatNumber(CDbl(iva1.Text), 2)
    End Sub

    Private Sub total1_TextChanged(sender As System.Object, e As System.EventArgs) Handles total1.TextChanged
        If total1.Text = "" Then total1.Text = 0
        total1.Text = FormatNumber(CDbl(total1.Text), 2)
    End Sub
    Private Sub Admin2_TextChanged(sender As System.Object, e As System.EventArgs) Handles admin2.TextChanged
        If admin2.Text = "" Then admin2.Text = 0
        admin2.Text = FormatNumber(CDbl(admin2.Text), 2)
    End Sub

    Private Sub util2_TextChanged(sender As System.Object, e As System.EventArgs) Handles util2.TextChanged
        If util2.Text = "" Then util2.Text = 0
        util2.Text = FormatNumber(CDbl(util2.Text), 2)
    End Sub

    Private Sub impre2_TextChanged(sender As System.Object, e As System.EventArgs) Handles impre2.TextChanged
        If impre2.Text = "" Then impre2.Text = 0
        impre2.Text = FormatNumber(CDbl(impre2.Text), 2)
    End Sub

    Private Sub subt2_TextChanged(sender As System.Object, e As System.EventArgs) Handles subt2.TextChanged
        If subt2.Text = "" Then subt2.Text = 0
        subt2.Text = FormatNumber(CDbl(subt2.Text), 2)
    End Sub

    Private Sub iva2_TextChanged(sender As System.Object, e As System.EventArgs) Handles iva2.TextChanged
        If iva2.Text = "" Then iva2.Text = 0
        iva2.Text = FormatNumber(CDbl(iva2.Text), 2)
    End Sub

    Private Sub total2_TextChanged(sender As System.Object, e As System.EventArgs) Handles total2.TextChanged
        If total2.Text = "" Then total2.Text = 0
        total2.Text = FormatNumber(CDbl(total2.Text), 2)
    End Sub
    Private Sub Admin3_TextChanged(sender As System.Object, e As System.EventArgs) Handles admin3.TextChanged
        If admin3.Text = "" Then admin3.Text = 0
        admin3.Text = FormatNumber(CDbl(admin3.Text), 2)
    End Sub

    Private Sub util3_TextChanged(sender As System.Object, e As System.EventArgs) Handles util3.TextChanged
        If util3.Text = "" Then util3.Text = 0
        util3.Text = FormatNumber(CDbl(util3.Text), 2)
    End Sub

    Private Sub impre3_TextChanged(sender As System.Object, e As System.EventArgs) Handles impre3.TextChanged
        If impre3.Text = "" Then impre3.Text = 0
        impre3.Text = FormatNumber(CDbl(impre3.Text), 2)
    End Sub

    Private Sub subt3_TextChanged(sender As System.Object, e As System.EventArgs) Handles subt3.TextChanged
        If subt3.Text = "" Then subt3.Text = 0
        subt3.Text = FormatNumber(CDbl(subt3.Text), 2)
    End Sub

    Private Sub iva3_TextChanged(sender As System.Object, e As System.EventArgs) Handles iva3.TextChanged
        If iva3.Text = "" Then iva3.Text = 0
        iva3.Text = FormatNumber(CDbl(iva3.Text), 2)
    End Sub

    Private Sub total3_TextChanged(sender As System.Object, e As System.EventArgs) Handles total3.TextChanged
        If total3.Text = "" Then total3.Text = 0
        total3.Text = FormatNumber(CDbl(total3.Text), 2)
    End Sub
    Private Sub Admin4_TextChanged(sender As System.Object, e As System.EventArgs) Handles admin4.TextChanged
        If admin4.Text = "" Then admin4.Text = 0
        admin4.Text = FormatNumber(CDbl(admin4.Text), 2)
    End Sub

    Private Sub util4_TextChanged(sender As System.Object, e As System.EventArgs) Handles util4.TextChanged
        If util4.Text = "" Then util4.Text = 0
        util4.Text = FormatNumber(CDbl(util4.Text), 2)
    End Sub

    Private Sub impre4_TextChanged(sender As System.Object, e As System.EventArgs) Handles impre4.TextChanged
        If impre4.Text = "" Then impre4.Text = 0
        impre4.Text = FormatNumber(CDbl(impre4.Text), 2)
    End Sub

    Private Sub subt4_TextChanged(sender As System.Object, e As System.EventArgs) Handles subt4.TextChanged
        If subt4.Text = "" Then subt4.Text = 0
        subt4.Text = FormatNumber(CDbl(subt4.Text), 2)
    End Sub

    Private Sub iva4_TextChanged(sender As System.Object, e As System.EventArgs) Handles iva4.TextChanged
        If iva4.Text = "" Then iva4.Text = 0
        iva4.Text = FormatNumber(CDbl(iva4.Text), 2)
    End Sub

    Private Sub total4_TextChanged(sender As System.Object, e As System.EventArgs) Handles total4.TextChanged
        If total4.Text = "" Then total4.Text = 0
        total4.Text = FormatNumber(CDbl(total4.Text), 2)
    End Sub
    Private Sub Admin5_TextChanged(sender As System.Object, e As System.EventArgs) Handles admin5.TextChanged
        If admin5.Text = "" Then admin5.Text = 0
        admin5.Text = FormatNumber(CDbl(admin5.Text), 2)
    End Sub

    Private Sub util5_TextChanged(sender As System.Object, e As System.EventArgs) Handles util5.TextChanged
        If util5.Text = "" Then util5.Text = 0
        util5.Text = FormatNumber(CDbl(util5.Text), 2)
    End Sub

    Private Sub impre5_TextChanged(sender As System.Object, e As System.EventArgs) Handles impre5.TextChanged
        If impre5.Text = "" Then impre5.Text = 0
        impre5.Text = FormatNumber(CDbl(impre5.Text), 2)
    End Sub

    Private Sub subt5_TextChanged(sender As System.Object, e As System.EventArgs) Handles subt5.TextChanged
        If subt5.Text = "" Then subt5.Text = 0
        subt5.Text = FormatNumber(CDbl(subt5.Text), 2)
    End Sub

    Private Sub iva5_TextChanged(sender As System.Object, e As System.EventArgs) Handles iva5.TextChanged
        If iva5.Text = "" Then iva5.Text = 0
        iva5.Text = FormatNumber(CDbl(iva5.Text), 2)
    End Sub

    Private Sub total5_TextChanged(sender As System.Object, e As System.EventArgs) Handles total5.TextChanged
        If total5.Text = "" Then total5.Text = 0
        total5.Text = FormatNumber(CDbl(total5.Text), 2)
    End Sub
    Private Sub Admin6_TextChanged(sender As System.Object, e As System.EventArgs) Handles admin6.TextChanged
        If admin6.Text = "" Then admin6.Text = 0
        admin6.Text = FormatNumber(CDbl(admin6.Text), 2)
    End Sub

    Private Sub util6_TextChanged(sender As System.Object, e As System.EventArgs) Handles util6.TextChanged
        If util6.Text = "" Then util6.Text = 0
        util6.Text = FormatNumber(CDbl(util6.Text), 2)
    End Sub

    Private Sub impre6_TextChanged(sender As System.Object, e As System.EventArgs) Handles impre6.TextChanged
        If impre6.Text = "" Then impre6.Text = 0
        impre6.Text = FormatNumber(CDbl(impre6.Text), 2)
    End Sub

    Private Sub subt6_TextChanged(sender As System.Object, e As System.EventArgs) Handles subt6.TextChanged
        If subt6.Text = "" Then subt6.Text = 0
        subt6.Text = FormatNumber(CDbl(subt6.Text), 2)
    End Sub

    Private Sub iva6_TextChanged(sender As System.Object, e As System.EventArgs) Handles iva6.TextChanged
        If iva6.Text = "" Then iva6.Text = 0
        iva6.Text = FormatNumber(CDbl(iva6.Text), 2)
    End Sub

    Private Sub total6_TextChanged(sender As System.Object, e As System.EventArgs) Handles total6.TextChanged
        If total6.Text = "" Then total6.Text = 0
        total6.Text = FormatNumber(CDbl(total6.Text), 2)
    End Sub
    Private Sub Admin7_TextChanged(sender As System.Object, e As System.EventArgs) Handles admin7.TextChanged
        If admin7.Text = "" Then admin7.Text = 0
        admin7.Text = FormatNumber(CDbl(admin7.Text), 2)
    End Sub

    Private Sub util7_TextChanged(sender As System.Object, e As System.EventArgs) Handles util7.TextChanged
        If util7.Text = "" Then util7.Text = 0
        util7.Text = FormatNumber(CDbl(util7.Text), 2)
    End Sub

    Private Sub impre7_TextChanged(sender As System.Object, e As System.EventArgs) Handles impre7.TextChanged
        If impre7.Text = "" Then impre7.Text = 0
        impre7.Text = FormatNumber(CDbl(impre7.Text), 2)
    End Sub

    Private Sub subt7_TextChanged(sender As System.Object, e As System.EventArgs) Handles subt7.TextChanged
        If subt7.Text = "" Then subt7.Text = 0
        subt7.Text = FormatNumber(CDbl(subt7.Text), 2)
    End Sub

    Private Sub iva7_TextChanged(sender As System.Object, e As System.EventArgs) Handles iva7.TextChanged
        If iva7.Text = "" Then iva7.Text = 0
        iva7.Text = FormatNumber(CDbl(iva7.Text), 2)
    End Sub

    Private Sub total7_TextChanged(sender As System.Object, e As System.EventArgs) Handles total7.TextChanged
        If total7.Text = "" Then total7.Text = 0
        total7.Text = FormatNumber(CDbl(total7.Text), 2)
    End Sub
    Private Sub Admin8_TextChanged(sender As System.Object, e As System.EventArgs) Handles admin8.TextChanged
        If admin8.Text = "" Then admin8.Text = 0
        admin8.Text = FormatNumber(CDbl(admin8.Text), 2)
    End Sub

    Private Sub util8_TextChanged(sender As System.Object, e As System.EventArgs) Handles util8.TextChanged
        If util8.Text = "" Then util8.Text = 0
        util8.Text = FormatNumber(CDbl(util8.Text), 2)
    End Sub

    Private Sub impre8_TextChanged(sender As System.Object, e As System.EventArgs) Handles impre8.TextChanged
        If impre8.Text = "" Then impre8.Text = 0
        impre8.Text = FormatNumber(CDbl(impre8.Text), 2)
    End Sub

    Private Sub subt8_TextChanged(sender As System.Object, e As System.EventArgs) Handles subt8.TextChanged
        If subt8.Text = "" Then subt8.Text = 0
        subt8.Text = FormatNumber(CDbl(subt8.Text), 2)
    End Sub

    Private Sub iva8_TextChanged(sender As System.Object, e As System.EventArgs) Handles iva8.TextChanged
        If iva8.Text = "" Then iva8.Text = 0
        iva8.Text = FormatNumber(CDbl(iva8.Text), 2)
    End Sub

    Private Sub total8_TextChanged(sender As System.Object, e As System.EventArgs) Handles total8.TextChanged
        If total8.Text = "" Then total8.Text = 0
        total8.Text = FormatNumber(CDbl(total8.Text), 2)
    End Sub

    Private Sub btnaceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnaceptar.Click
        frmaprobarcontrato.transpaso = 1
        guardar()
        frmaprobarcontrato.validador()
        Me.Close()
    End Sub

    Private Sub txtvalorcontcart_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtvalorcontcart.TextChanged
        Me.CMOriginalesBindingSource.Filter = "Contratos = '" & txtvalorcontcart.Text & "'"
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmaprobarcontrato.cmbestado.Text = "Rechazada"
        frmaprobarcontrato.cancelado()
        Me.Close()
    End Sub
    Friend Sub guardar()
        frmaprobarcontrato.servicio(0) = servicio1.Text
        frmaprobarcontrato.servicio(1) = servicio2.Text
        frmaprobarcontrato.servicio(2) = servicio3.Text
        frmaprobarcontrato.servicio(3) = servicio4.Text
        frmaprobarcontrato.servicio(4) = servicio5.Text
        frmaprobarcontrato.servicio(5) = servicio6.Text
        frmaprobarcontrato.servicio(6) = servicio7.Text
        frmaprobarcontrato.servicio(7) = servicio8.Text
        frmaprobarcontrato.nservicio(0) = nservicio1.Text
        frmaprobarcontrato.nservicio(1) = nservicio2.Text
        frmaprobarcontrato.nservicio(2) = nservicio3.Text
        frmaprobarcontrato.nservicio(3) = nservicio4.Text
        frmaprobarcontrato.nservicio(4) = nservicio5.Text
        frmaprobarcontrato.nservicio(5) = nservicio6.Text
        frmaprobarcontrato.nservicio(6) = nservicio7.Text
        frmaprobarcontrato.nservicio(7) = nservicio8.Text
        frmaprobarcontrato.costod(0) = costod1.Text
        frmaprobarcontrato.costod(1) = costod2.Text
        frmaprobarcontrato.costod(2) = costod3.Text
        frmaprobarcontrato.costod(3) = costod4.Text
        frmaprobarcontrato.costod(4) = costod5.Text
        frmaprobarcontrato.costod(5) = costod6.Text
        frmaprobarcontrato.costod(6) = costod7.Text
        frmaprobarcontrato.costod(7) = costod8.Text
        frmaprobarcontrato.admin(0) = Admin1.Text
        frmaprobarcontrato.admin(1) = admin2.Text
        frmaprobarcontrato.admin(2) = admin3.Text
        frmaprobarcontrato.admin(3) = admin4.Text
        frmaprobarcontrato.admin(4) = admin5.Text
        frmaprobarcontrato.admin(5) = admin6.Text
        frmaprobarcontrato.admin(6) = admin7.Text
        frmaprobarcontrato.admin(7) = admin8.Text
        frmaprobarcontrato.impre(0) = impre1.Text
        frmaprobarcontrato.impre(1) = impre2.Text
        frmaprobarcontrato.impre(2) = impre3.Text
        frmaprobarcontrato.impre(3) = impre4.Text
        frmaprobarcontrato.impre(4) = impre5.Text
        frmaprobarcontrato.impre(5) = impre6.Text
        frmaprobarcontrato.impre(6) = impre7.Text
        frmaprobarcontrato.impre(7) = impre8.Text
        frmaprobarcontrato.util(0) = util1.Text
        frmaprobarcontrato.util(1) = util2.Text
        frmaprobarcontrato.util(2) = util3.Text
        frmaprobarcontrato.util(3) = util4.Text
        frmaprobarcontrato.util(4) = util5.Text
        frmaprobarcontrato.util(5) = util6.Text
        frmaprobarcontrato.util(6) = util7.Text
        frmaprobarcontrato.util(7) = util8.Text
        frmaprobarcontrato.subt(0) = subt1.Text
        frmaprobarcontrato.subt(1) = subt2.Text
        frmaprobarcontrato.subt(2) = subt3.Text
        frmaprobarcontrato.subt(3) = subt4.Text
        frmaprobarcontrato.subt(4) = subt5.Text
        frmaprobarcontrato.subt(5) = subt6.Text
        frmaprobarcontrato.subt(6) = subt7.Text
        frmaprobarcontrato.subt(7) = subt8.Text
        frmaprobarcontrato.iva(0) = iva1.Text
        frmaprobarcontrato.iva(1) = iva2.Text
        frmaprobarcontrato.iva(2) = iva3.Text
        frmaprobarcontrato.iva(3) = iva4.Text
        frmaprobarcontrato.iva(4) = iva5.Text
        frmaprobarcontrato.iva(5) = iva6.Text
        frmaprobarcontrato.iva(6) = iva7.Text
        frmaprobarcontrato.iva(7) = iva8.Text
        frmaprobarcontrato.total(0) = total1.Text
        frmaprobarcontrato.total(1) = total2.Text
        frmaprobarcontrato.total(2) = total3.Text
        frmaprobarcontrato.total(3) = total4.Text
        frmaprobarcontrato.total(4) = total5.Text
        frmaprobarcontrato.total(5) = total6.Text
        frmaprobarcontrato.total(6) = total7.Text
        frmaprobarcontrato.total(7) = total8.Text
        frmaprobarcontrato.a(0) = a1.Text
        frmaprobarcontrato.a(1) = a2.Text
        frmaprobarcontrato.a(2) = a3.Text
        frmaprobarcontrato.a(3) = a4.Text
        frmaprobarcontrato.a(4) = a5.Text
        frmaprobarcontrato.a(5) = a6.Text
        frmaprobarcontrato.a(6) = a7.Text
        frmaprobarcontrato.a(7) = a8.Text
        frmaprobarcontrato.i(0) = i1.Text
        frmaprobarcontrato.i(1) = i2.Text
        frmaprobarcontrato.i(2) = i3.Text
        frmaprobarcontrato.i(3) = i4.Text
        frmaprobarcontrato.i(4) = i5.Text
        frmaprobarcontrato.i(5) = i6.Text
        frmaprobarcontrato.i(6) = i7.Text
        frmaprobarcontrato.i(7) = i8.Text
        frmaprobarcontrato.u(0) = u1.Text
        frmaprobarcontrato.u(1) = u2.Text
        frmaprobarcontrato.u(2) = u3.Text
        frmaprobarcontrato.u(3) = u4.Text
        frmaprobarcontrato.u(4) = u5.Text
        frmaprobarcontrato.u(5) = u6.Text
        frmaprobarcontrato.u(6) = u7.Text
        frmaprobarcontrato.u(7) = u8.Text
        frmaprobarcontrato.cosdirecto = txtcostdglobal.Text
        frmaprobarcontrato.imptxtcostadminglobal = txtcostadminglobal.Text
        frmaprobarcontrato.imptxtcostimpglobal = txtcostimpglobal.Text
        frmaprobarcontrato.imptxtcostutilglobal = txtcostutilglobal.Text
        frmaprobarcontrato.imptxtcostsubglobal = txtcostsubglobal.Text
        frmaprobarcontrato.imptxtcostivaglobal = txtcostivaglobal.Text
        frmaprobarcontrato.impvrgtotal = vrgtotal.Text
    End Sub

End Class
