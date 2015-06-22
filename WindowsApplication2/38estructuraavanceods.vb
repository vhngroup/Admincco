Imports System.Windows.Forms.ErrorProvider
Imports System.Text.RegularExpressions
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class verestructuraods
    Dim db As IDbConnection
    Dim midataset As DataSet
    Dim mienlazador As New BindingSource
    Dim conexion = ADONETUtil.cn
    Dim comandos As New SqlCommand
    Friend ods As String = fmrmodificarods.Id.Text
    Friend vigencias As Double = fmrmodificarods.saldovigencia.Text
    Friend restadirecto(4)
    Friend restaadmin(4)
    Friend restaimpre(4)
    Friend restautil(4)
    Friend restasubtotal(4)
    Friend restaiva(4)
    Friend restatotal(4)
    Dim estado = 0

    Friend Sub verestructuraods_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.CMNuevos' Puede moverla o quitarla según sea necesario.
        Me.CMNuevosTableAdapter.Fill(Me.Adminco_MasterDataSet.CMNuevos)
        'TODO: esta línea de código carga datos en la tabla 'Adminco_MasterDataSet.ODS' Puede moverla o quitarla según sea necesario.
        Me.ODSTableAdapter.Fill(Me.Adminco_MasterDataSet.ODS)
        contratonumero.Text = ods
        If nivel1.Enabled = True Then
            txtvalorcontcart.Text = FormatNumber(CDbl(vigencias) + CDbl(vrgtotal.Text))
        Else
            txtvalorcontcart.Text = FormatNumber(CDbl(vigencias))
        End If
    End Sub
    Friend Sub modificacion()
        estado = 1
        nivel1.Enabled = True
        nivel2.Enabled = True
        nivel3.Enabled = True
        nivel4.Enabled = True
    End Sub
    Private Sub calculo1()
        If costod1.Enabled = True Then
            If servicio1.Text = "" Then servicio1.Text = 0 ' Verifica que no este vacio
            If servicio1.Text = 1 Then ' Verifica el tipo de servicio, 1 2 o 3
                a1.Enabled = True
                i1.Enabled = True
                u1.Enabled = True
                If a1.Text <> "" Then ' Administracion 
                    If a1.Text = 0 Then
                        Admin1.Text = 0
                    Else
                        Admin1.Text = FormatNumber(CDbl(costod1.Text) * CDbl(a1.Text) / 100)
                    End If
                Else
                    a1.Text = 0
                    Admin1.Text = 0
                End If

                If i1.Text <> "" Then ' Imprevistos
                    If i1.Text = 0 Then
                        impre1.Text = 0
                    Else
                        impre1.Text = FormatNumber(CDbl(costod1.Text) * CDbl(i1.Text) / 100)
                    End If
                Else
                    i1.Text = 0
                    impre1.Text = 0
                End If

                If u1.Text <> "" Then ' Utilidad
                    If u1.Text = 0 Then
                        util1.Text = 0
                    Else
                        util1.Text = FormatNumber(CDbl(costod1.Text) * CDbl(u1.Text) / 100)
                    End If
                Else
                    u1.Text = 0
                    util1.Text = 0
                End If

                subt1.Text = FormatNumber(CDbl(costod1.Text) + CDbl(Admin1.Text) + CDbl(impre1.Text) + CDbl(util1.Text))
                iva1.Text = FormatNumber(CDbl(util1.Text) * 0.16) ' Multiplica la utilidad x el 16%
                total1.Text = FormatNumber(CDbl(iva1.Text) + CDbl(subt1.Text)) ' suma el iva + el subtotal
            End If

            If servicio1.Text = 2 Then ' Caso 2
                a1.Enabled = True
                u1.Enabled = False ' Desabilita Utilidad
                i1.Enabled = False
                u1.Enabled = False ' Desabilita Utilidad
                u1.Text = 0
                i1.Text = 0
                util1.Text = 0
                impre1.Text = 0
                If a1.Text <> "" Then ' Administracion 
                    If a1.Text = 0 Then
                        Admin1.Text = 0
                    Else
                        Admin1.Text = FormatNumber(CDbl(costod1.Text) * CDbl(a1.Text) / 100)
                    End If

                Else
                    a1.Text = 0
                    Admin1.Text = 0
                End If
                subt1.Text = FormatNumber(CDbl(costod1.Text) + CDbl(Admin1.Text) + CDbl(util1.Text))
                iva1.Text = FormatNumber(Admin1.Text * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 16%
                total1.Text = FormatNumber(CDbl(iva1.Text) + CDbl(subt1.Text))
            End If
            If servicio1.Text = 3 Then 'Opcion 3
                i1.Enabled = False
                u1.Enabled = False ' Desabilita Utilidad
                a1.Enabled = False
                u1.Text = 0
                i1.Text = 0
                util1.Text = 0
                impre1.Text = 0
                Admin1.Text = 0
                subt1.Text = FormatNumber(CDbl(costod1.Text))
                iva1.Text = FormatNumber(CDbl(subt1.Text) * 0.16)
                total1.Text = FormatNumber(CDbl(iva1.Text) + CDbl(subt1.Text))
            End If
        End If
    End Sub
    Private Sub calculo2()
        If costod2.Enabled = True Then
            If servicio2.Text = "" Then servicio2.Text = 0 ' Verifica que no este vacio

            If servicio2.Text = 1 Then ' Verifica el tipo de servicio, 2 2 o 3
                a2.Enabled = True
                i2.Enabled = True
                u2.Enabled = True
                If a2.Text <> "" Then ' Administracion 
                    If a2.Text = 0 Then
                        admin2.Text = 0
                    Else
                        admin2.Text = FormatNumber(CDbl(costod2.Text) * CDbl(a2.Text) / 100)
                    End If
                Else
                    a2.Text = 0
                    admin2.Text = 0
                End If

                If i2.Text <> "" Then ' Imprevistos
                    If i2.Text = 0 Then
                        impre2.Text = 0
                    Else
                        impre2.Text = FormatNumber(CDbl(costod2.Text) * CDbl(i2.Text) / 100)
                    End If
                Else
                    i2.Text = 0
                    impre2.Text = 0
                End If

                If u2.Text <> "" Then ' Utilidad
                    If u2.Text = 0 Then
                        util2.Text = 0
                    Else
                        util2.Text = FormatNumber(CDbl(costod2.Text) * CDbl(u2.Text) / 100)
                    End If
                Else
                    u2.Text = 0
                    util2.Text = 0
                End If

                subt2.Text = FormatNumber(CDbl(costod2.Text) + CDbl(admin2.Text) + CDbl(impre2.Text) + CDbl(util2.Text))
                iva2.Text = FormatNumber(CDbl(util2.Text) * 0.16) ' Multiplica la utilidad x el 26%
                total2.Text = FormatNumber(CDbl(iva2.Text) + CDbl(subt2.Text)) ' suma el iva + el subtotal
            End If
            If servicio2.Text = 2 Then ' Caso 2
                a2.Enabled = True
                u2.Enabled = False ' Desabilita Utilidad
                i2.Enabled = False
                u2.Enabled = False ' Desabilita Utilidad
                u2.Text = 0
                i2.Text = 0
                util2.Text = 0
                impre2.Text = 0
                If a2.Text <> "" Then ' Administracion 
                    If a2.Text = 0 Then
                        admin2.Text = 0
                    Else
                        admin2.Text = FormatNumber(CDbl(costod2.Text) * CDbl(a2.Text) / 100)
                    End If
                Else
                    a2.Text = 0
                    admin2.Text = 0
                End If
                subt2.Text = FormatNumber(CDbl(costod2.Text) + CDbl(admin2.Text) + CDbl(util2.Text))
                iva2.Text = FormatNumber(admin2.Text * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 26%
                total2.Text = FormatNumber(CDbl(iva2.Text) + CDbl(subt2.Text))
            End If

            If servicio2.Text = 3 Then 'Opcion 3
                i2.Enabled = False
                u2.Enabled = False ' Desabilita Utilidad
                a2.Enabled = False
                u2.Text = 0
                i2.Text = 0
                util2.Text = 0
                impre2.Text = 0
                admin2.Text = 0
                subt2.Text = FormatNumber(CDbl(costod2.Text))
                iva2.Text = FormatNumber(CDbl(subt2.Text) * 0.16)
                total2.Text = FormatNumber(CDbl(iva2.Text) + CDbl(subt2.Text))
            End If
        End If
    End Sub
    Private Sub calculo3()
        If costod3.Enabled = True Then
            If servicio3.Text = "" Then servicio3.Text = 0 ' Verifica que no este vacio

            If servicio3.Text = 1 Then ' Verifica el tipo de servicio, 3 3 o 3
                a3.Enabled = True
                i3.Enabled = True
                u3.Enabled = True
                If a3.Text <> "" Then ' Administracion 
                    If a3.Text = 0 Then
                        admin3.Text = 0
                    Else
                        admin3.Text = FormatNumber(CDbl(costod3.Text) * CDbl(a3.Text) / 100)
                    End If
                Else
                    a3.Text = 0
                    admin3.Text = 0
                End If

                If i3.Text <> "" Then ' Imprevistos
                    If i3.Text = 0 Then
                        impre3.Text = 0
                    Else

                        impre3.Text = FormatNumber(CDbl(costod3.Text) * CDbl(i3.Text) / 100)
                    End If
                Else
                    i3.Text = 0
                    impre3.Text = 0
                End If

                If u3.Text <> "" Then ' Utilidad
                    If u3.Text = 0 Then
                        util3.Text = 0
                    Else
                        util3.Text = FormatNumber(CDbl(costod3.Text) * CDbl(u3.Text) / 100)
                    End If
                Else
                    u3.Text = 0
                    util3.Text = 0
                End If

                subt3.Text = FormatNumber(CDbl(costod3.Text) + CDbl(admin3.Text) + CDbl(impre3.Text) + CDbl(util3.Text))
                iva3.Text = FormatNumber(CDbl(util3.Text) * 0.16) ' Multiplica la utilidad x el 36%
                total3.Text = FormatNumber(CDbl(iva3.Text) + CDbl(subt3.Text)) ' suma el iva + el subtotal
            End If

            If servicio3.Text = 2 Then ' Caso 3
                a3.Enabled = True
                u3.Enabled = False ' Desabilita Utilidad
                i3.Enabled = False
                u3.Enabled = False ' Desabilita Utilidad
                u3.Text = 0
                i3.Text = 0
                util3.Text = 0
                impre3.Text = 0
                If a3.Text <> "" Then ' Administracion 
                    If a3.Text = 0 Then
                        admin3.Text = 0
                    Else
                        admin3.Text = FormatNumber(CDbl(costod3.Text) * CDbl(a3.Text) / 100)
                    End If

                Else
                    a3.Text = 0
                    admin3.Text = 0
                End If
                subt3.Text = FormatNumber(CDbl(costod3.Text) + CDbl(admin3.Text) + CDbl(util3.Text))
                iva3.Text = FormatNumber(admin3.Text * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 36%
                total3.Text = FormatNumber(CDbl(iva3.Text) + CDbl(subt3.Text))
            End If

            If servicio3.Text = 3 Then 'Opcion 3
                i3.Enabled = False
                u3.Enabled = False ' Desabilita Utilidad
                a3.Enabled = False
                u3.Text = 0
                i3.Text = 0
                util3.Text = 0
                impre3.Text = 0
                admin3.Text = 0
                subt3.Text = FormatNumber(CDbl(costod3.Text))
                iva3.Text = FormatNumber(CDbl(subt3.Text) * 0.16)
                total3.Text = FormatNumber(CDbl(iva3.Text) + CDbl(subt3.Text))
            End If

        End If
    End Sub

    Private Sub calculo4()
        If costod4.Enabled = True Then
            If servicio4.Text = "" Then servicio4.Text = 0 ' Verifica que no este vacio

            If servicio4.Text = 1 Then ' Verifica el tipo de servicio, 4 4 o 4
                a4.Enabled = True
                i4.Enabled = True
                u4.Enabled = True
                If a4.Text <> "" Then ' Administracion 
                    If a4.Text = 0 Then
                        admin4.Text = 0
                    Else
                        admin4.Text = FormatNumber(CDbl(costod4.Text) * CDbl(a4.Text) / 100)
                    End If
                Else
                    a4.Text = 0
                    admin4.Text = 0
                End If

                If i4.Text <> "" Then ' Imprevistos
                    If i4.Text = 0 Then
                        impre4.Text = 0
                    Else

                        impre4.Text = FormatNumber(CDbl(costod4.Text) * CDbl(i4.Text) / 100)
                    End If
                Else
                    i4.Text = 0
                    impre4.Text = 0
                End If

                If u4.Text <> "" Then ' Utilidad
                    If u4.Text = 0 Then
                        util4.Text = 0
                    Else
                        util4.Text = FormatNumber(CDbl(costod4.Text) * CDbl(u4.Text) / 100)
                    End If
                Else
                    u4.Text = 0
                    util4.Text = 0
                End If

                subt4.Text = FormatNumber(CDbl(costod4.Text) + CDbl(admin4.Text) + CDbl(impre4.Text) + CDbl(util4.Text))
                iva4.Text = FormatNumber(CDbl(util4.Text) * 0.16) ' Multiplica la utilidad x el 46%
                total4.Text = FormatNumber(CDbl(iva4.Text) + CDbl(subt4.Text)) ' suma el iva + el subtotal
            End If

            If servicio4.Text = 2 Then ' Caso 4
                a4.Enabled = True
                u4.Enabled = False ' Desabilita Utilidad
                i4.Enabled = False
                u4.Enabled = False ' Desabilita Utilidad
                u4.Text = 0
                i4.Text = 0
                util4.Text = 0
                impre4.Text = 0
                If a4.Text <> "" Then ' Administracion 
                    If a4.Text = 0 Then
                        admin4.Text = 0
                    Else
                        admin4.Text = FormatNumber(CDbl(costod4.Text) * CDbl(a4.Text) / 100)
                    End If

                Else
                    a4.Text = 0
                    admin4.Text = 0
                End If
                subt4.Text = FormatNumber(CDbl(costod4.Text) + CDbl(admin4.Text) + CDbl(util4.Text))
                iva4.Text = FormatNumber(admin4.Text * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 46%
                total4.Text = FormatNumber(CDbl(iva4.Text) + CDbl(subt4.Text))
            End If

            If servicio4.Text = 3 Then 'Opcion 4
                i4.Enabled = False
                u4.Enabled = False ' Desabilita Utilidad
                a4.Enabled = False
                u4.Text = 0
                i4.Text = 0
                util4.Text = 0
                impre4.Text = 0
                admin4.Text = 0
                subt4.Text = FormatNumber(CDbl(costod4.Text))
                iva4.Text = FormatNumber(CDbl(subt4.Text) * 0.16)
                total4.Text = FormatNumber(CDbl(iva4.Text) + CDbl(subt4.Text))
            End If

        End If
    End Sub
    Private Sub constante()
        If ErrorProvider1.GetError(costod1) = "" Then
            If ErrorProvider2.GetError(costod2) = "" Then
                If ErrorProvider3.GetError(costod3) = "" Then
                    If ErrorProvider4.GetError(costod4) = "" Then

                        If txtvalorcontcart.Text = "" Then
                        Else
                            calculo1()
                            calculo2()
                            calculo3()
                            calculo4()
                            totales()
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub totales()
        If nivel1.Enabled = True Then
            If nivel2.Enabled = True Then
                If nivel3.Enabled = True Then
                    If nivel4.Enabled = True Then
                        txtcostdglobal.Text = FormatNumber(CDbl(costod1.Text) + CDbl(costod2.Text) + CDbl(costod3.Text) + CDbl(costod4.Text))
                        txtcostadminglobal.Text = FormatNumber(CDbl(Admin1.Text) + CDbl(admin2.Text) + CDbl(admin3.Text) + CDbl(admin4.Text))
                        txtcostimpglobal.Text = FormatNumber(CDbl(impre1.Text) + CDbl(impre2.Text) + CDbl(impre3.Text) + CDbl(impre4.Text))
                        txtcostutilglobal.Text = FormatNumber(CDbl(util1.Text) + CDbl(util2.Text) + CDbl(util3.Text) + CDbl(util4.Text))
                        txtcostsubglobal.Text = FormatNumber(CDbl(subt1.Text) + CDbl(subt2.Text) + CDbl(subt3.Text) + CDbl(subt4.Text))
                        txtcostivaglobal.Text = FormatNumber(CDbl(iva1.Text) + CDbl(iva2.Text) + CDbl(iva3.Text) + CDbl(iva4.Text))
                        vrgtotal.Text = FormatNumber(CDbl(total1.Text) + CDbl(total2.Text) + CDbl(total3.Text) + CDbl(total4.Text))
                    End If
                End If
            End If
        End If

    End Sub
    Function dejarNumerosPuntos(cadenaTexto As String) As String
        Const listaNumeros = "0123456789,."
        Dim cadenaTemporal As String
        Dim i As Integer

        cadenaTexto = Trim$(cadenaTexto)
        If Len(cadenaTexto) = 0 Then
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
    Private Sub desviacion_TextChanged(sender As System.Object, e As System.EventArgs) Handles desviacion.TextChanged
        If desviacion.Text = "" Then desviacion.Text = 0
        desviacion.Text = FormatNumber(CDbl(desviacion.Text), 2)
    End Sub
    Function dejarNumerosPuntos2(cadenaTexto As String) As String
        Const listaNumeros = "0123456789,"
        Dim cadenaTemporal As String
        Dim i As Integer

        cadenaTexto = Trim$(cadenaTexto)
        If Len(cadenaTexto) = 0 Then
            Exit Function
        End If

        cadenaTemporal = ""

        For i = 1 To Len(cadenaTexto)
            If InStr(listaNumeros, Mid$(cadenaTexto, i, 1)) Then
                cadenaTemporal = cadenaTemporal + Mid$(cadenaTexto, i, 1)
            End If
        Next
        dejarNumerosPuntos2 = cadenaTemporal
    End Function
    Private Sub txtvalorcontcart_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtvalorcontcart.TextChanged
        If txtvalorcontcart.Text = "" Then txtvalorcontcart.Text = 0
        txtvalorcontcart.Text = FormatNumber(CDbl(txtvalorcontcart.Text), 2)
    End Sub
    Private Sub costod1_TextChanged(sender As Object, e As System.EventArgs) Handles costod1.TextChanged
        costod1.Text = Trim(dejarNumerosPuntos(costod1.Text))
        If (String.IsNullOrEmpty(costod1.Text.Trim())) Then
            Me.ErrorProvider1.SetError(costod1, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider1.Clear()
            constante()
        End If
    End Sub
    Private Sub costod1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles costod1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            costod1.Text = FormatNumber(CDbl(costod1.Text), 2)
        End If
    End Sub
    Private Sub costod2_TextChanged(sender As Object, e As System.EventArgs) Handles costod2.TextChanged
        costod2.Text = Trim(dejarNumerosPuntos(costod2.Text))
        If (String.IsNullOrEmpty(costod2.Text.Trim())) Then
            Me.ErrorProvider2.SetError(costod2, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider2.Clear()
            constante()
        End If
    End Sub
    Private Sub costod2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles costod2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            costod2.Text = FormatNumber(CDbl(costod2.Text), 2)
        End If
    End Sub
    Private Sub costod3_TextChanged(sender As Object, e As System.EventArgs) Handles costod3.TextChanged
        costod3.Text = Trim(dejarNumerosPuntos(costod3.Text))
        If (String.IsNullOrEmpty(costod3.Text.Trim())) Then
            Me.ErrorProvider3.SetError(costod3, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider3.Clear()
            constante()
        End If
    End Sub
    Private Sub costod3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles costod3.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            costod3.Text = FormatNumber(CDbl(costod3.Text), 2)
        End If
    End Sub
    Private Sub costod4_TextChanged(sender As Object, e As System.EventArgs) Handles costod4.TextChanged
        costod4.Text = Trim(dejarNumerosPuntos(costod4.Text))
        If (String.IsNullOrEmpty(costod4.Text.Trim())) Then
            Me.ErrorProvider4.SetError(costod4, "Cuidado, espacio vacio")
        Else
            Me.ErrorProvider4.Clear()
            constante()
        End If
    End Sub
    Private Sub costod4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles costod4.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            costod4.Text = FormatNumber(CDbl(costod4.Text), 2)
        End If
    End Sub
    Private Sub btncancelar_Click(sender As System.Object, e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub
    Private Sub Admin1_TextChanged(sender As Object, e As System.EventArgs) Handles Admin1.TextChanged
        If Admin1.Text = "" Then Admin1.Text = 0
        Admin1.Text = FormatNumber(CDbl(Admin1.Text), 2)
    End Sub
    Private Sub impre1_TextChanged(sender As Object, e As System.EventArgs) Handles impre1.TextChanged
        If impre1.Text = "" Then impre1.Text = 0
        impre1.Text = FormatNumber(CDbl(impre1.Text), 2)
    End Sub

    Private Sub util1_TextChanged(sender As Object, e As System.EventArgs) Handles util1.TextChanged
        If util1.Text = "" Then util1.Text = 0
        util1.Text = FormatNumber(CDbl(util1.Text), 2)
    End Sub

    Private Sub subt1_TextChanged(sender As Object, e As System.EventArgs) Handles subt1.TextChanged
        If subt1.Text = "" Then subt1.Text = 0
        subt1.Text = FormatNumber(CDbl(subt1.Text), 2)
    End Sub

    Private Sub iva1_TextChanged(sender As Object, e As System.EventArgs) Handles iva1.TextChanged
        If iva1.Text = "" Then iva1.Text = 0
        iva1.Text = FormatNumber(CDbl(iva1.Text), 2)
    End Sub

    Private Sub total1_TextChanged(sender As Object, e As System.EventArgs) Handles total1.TextChanged
        If total1.Text = "" Then total1.Text = 0
        total1.Text = FormatNumber(CDbl(total1.Text), 2)

    End Sub
    Private Sub Admin2_TextChanged(sender As Object, e As System.EventArgs) Handles admin2.TextChanged
        If admin2.Text = "" Then admin2.Text = 0
        admin2.Text = FormatNumber(CDbl(admin2.Text), 2)

    End Sub

    Private Sub impre2_TextChanged(sender As Object, e As System.EventArgs) Handles impre2.TextChanged
        If impre2.Text = "" Then impre2.Text = 0
        impre2.Text = FormatNumber(CDbl(impre2.Text), 2)

    End Sub

    Private Sub util2_TextChanged(sender As Object, e As System.EventArgs) Handles util2.TextChanged
        If util2.Text = "" Then util2.Text = 0
        util2.Text = FormatNumber(CDbl(util2.Text), 2)

    End Sub

    Private Sub subt2_TextChanged(sender As Object, e As System.EventArgs) Handles subt2.TextChanged
        If subt2.Text = "" Then subt2.Text = 0
        subt2.Text = FormatNumber(CDbl(subt2.Text), 2)

    End Sub

    Private Sub iva2_TextChanged(sender As Object, e As System.EventArgs) Handles iva2.TextChanged
        If iva2.Text = "" Then iva2.Text = 0
        iva2.Text = FormatNumber(CDbl(iva2.Text), 2)

    End Sub

    Private Sub total2_TextChanged(sender As Object, e As System.EventArgs) Handles total2.TextChanged
        If total2.Text = "" Then total2.Text = 0
        total2.Text = FormatNumber(CDbl(total2.Text), 2)

    End Sub
    Private Sub Admin3_TextChanged(sender As Object, e As System.EventArgs) Handles admin3.TextChanged
        If admin3.Text = "" Then admin3.Text = 0
        admin3.Text = FormatNumber(CDbl(admin3.Text), 2)

    End Sub

    Private Sub impre3_TextChanged(sender As Object, e As System.EventArgs) Handles impre3.TextChanged
        If impre3.Text = "" Then impre3.Text = 0
        impre3.Text = FormatNumber(CDbl(impre3.Text), 2)

    End Sub

    Private Sub util3_TextChanged(sender As Object, e As System.EventArgs) Handles util3.TextChanged
        If util3.Text = "" Then util3.Text = 0
        util3.Text = FormatNumber(CDbl(util3.Text), 2)

    End Sub

    Private Sub subt3_TextChanged(sender As Object, e As System.EventArgs) Handles subt3.TextChanged
        If subt3.Text = "" Then subt3.Text = 0
        subt3.Text = FormatNumber(CDbl(subt3.Text), 2)

    End Sub

    Private Sub iva3_TextChanged(sender As Object, e As System.EventArgs) Handles iva3.TextChanged
        If iva3.Text = "" Then iva3.Text = 0
        iva3.Text = FormatNumber(CDbl(iva3.Text), 2)

    End Sub

    Private Sub total3_TextChanged(sender As Object, e As System.EventArgs) Handles total3.TextChanged
        If total3.Text = "" Then total3.Text = 0
        total3.Text = FormatNumber(CDbl(total3.Text), 2)

    End Sub

    Private Sub Admin4_TextChanged(sender As Object, e As System.EventArgs) Handles admin4.TextChanged
        If admin4.Text = "" Then admin4.Text = 0
        admin4.Text = FormatNumber(CDbl(admin4.Text), 2)
    End Sub
    Private Sub impre4_TextChanged(sender As Object, e As System.EventArgs) Handles impre4.TextChanged
        If impre4.Text = "" Then impre4.Text = 0
        impre4.Text = FormatNumber(CDbl(impre4.Text), 2)
    End Sub
    Private Sub util4_TextChanged(sender As Object, e As System.EventArgs) Handles util4.TextChanged
        If util4.Text = "" Then util4.Text = 0
        util4.Text = FormatNumber(CDbl(util4.Text), 2)
    End Sub
    Private Sub subt4_TextChanged(sender As Object, e As System.EventArgs) Handles subt4.TextChanged
        If subt4.Text = "" Then subt4.Text = 0
        subt4.Text = FormatNumber(CDbl(subt4.Text), 2)

    End Sub
    Private Sub iva4_TextChanged(sender As Object, e As System.EventArgs) Handles iva4.TextChanged
        If iva4.Text = "" Then iva4.Text = 0
        iva4.Text = FormatNumber(CDbl(iva4.Text), 2)

    End Sub
    Private Sub total4_TextChanged(sender As Object, e As System.EventArgs) Handles total4.TextChanged
        If total4.Text = "" Then total4.Text = 0
        total4.Text = FormatNumber(CDbl(total4.Text), 2)

    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            If nivel1.Enabled = True Then
                desviacion.Text = FormatNumber(CDbl(txtvalorcontcart.Text) - CDbl(vrgtotal.Text))
                If CDbl(vrgtotal.Text) > CDbl(txtvalorcontcart.Text) Then
                    Label85.Text = ("Verifique la estructura del contrato" & " " & desviacion.Text)
                    CheckBox1.Checked = False
                Else
                    Label85.Text = ""
                    contabilizar()
                    btnaceptar.Enabled = True
                End If
            Else
                btnaceptar.Enabled = True
            End If
        End If
        If CheckBox1.Checked = False Then
            btnaceptar.Enabled = False
        End If
    End Sub
    Friend Sub guardar()
        If estado = 1 Then
            totales()
            fmrmodificarods.servicio2(0) = servicio1.Text
            fmrmodificarods.servicio2(1) = servicio2.Text
            fmrmodificarods.servicio2(2) = servicio3.Text
            fmrmodificarods.servicio2(3) = servicio4.Text
            fmrmodificarods.nservicio2(0) = nservicio1.Text
            fmrmodificarods.nservicio2(1) = nservicio2.Text
            fmrmodificarods.nservicio2(2) = nservicio3.Text
            fmrmodificarods.nservicio2(3) = nservicio4.Text
            fmrmodificarods.costod2(0) = FormatNumber(CDbl(costod1.Text))
            fmrmodificarods.costod2(1) = FormatNumber(CDbl(costod2.Text))
            fmrmodificarods.costod2(2) = FormatNumber(CDbl(costod3.Text))
            fmrmodificarods.costod2(3) = FormatNumber(CDbl(costod4.Text))
            fmrmodificarods.admin2(0) = FormatNumber(CDbl(Admin1.Text))
            fmrmodificarods.admin2(1) = FormatNumber(CDbl(admin2.Text))
            fmrmodificarods.admin2(2) = FormatNumber(CDbl(admin3.Text))
            fmrmodificarods.admin2(3) = FormatNumber(CDbl(admin4.Text))
            fmrmodificarods.impre2(0) = FormatNumber(CDbl(impre1.Text))
            fmrmodificarods.impre2(1) = FormatNumber(CDbl(impre2.Text))
            fmrmodificarods.impre2(2) = FormatNumber(CDbl(impre3.Text))
            fmrmodificarods.impre2(3) = FormatNumber(CDbl(impre4.Text))
            fmrmodificarods.util2(0) = FormatNumber(CDbl(util1.Text))
            fmrmodificarods.util2(1) = FormatNumber(CDbl(util2.Text))
            fmrmodificarods.util2(2) = FormatNumber(CDbl(util3.Text))
            fmrmodificarods.util2(3) = FormatNumber(CDbl(util4.Text))
            fmrmodificarods.subt2(0) = FormatNumber(CDbl(subt1.Text))
            fmrmodificarods.subt2(1) = FormatNumber(CDbl(subt2.Text))
            fmrmodificarods.subt2(2) = FormatNumber(CDbl(subt3.Text))
            fmrmodificarods.subt2(3) = FormatNumber(CDbl(subt4.Text))
            fmrmodificarods.iva2(0) = FormatNumber(CDbl(iva1.Text))
            fmrmodificarods.iva2(1) = FormatNumber(CDbl(iva2.Text))
            fmrmodificarods.iva2(2) = FormatNumber(CDbl(iva3.Text))
            fmrmodificarods.iva2(3) = FormatNumber(CDbl(iva4.Text))
            fmrmodificarods.total2(0) = FormatNumber(CDbl(total1.Text))
            fmrmodificarods.total2(1) = FormatNumber(CDbl(total2.Text))
            fmrmodificarods.total2(2) = FormatNumber(CDbl(total3.Text))
            fmrmodificarods.total2(3) = FormatNumber(CDbl(total4.Text))
            fmrmodificarods.a2(0) = FormatNumber(CDbl(a1.Text))
            fmrmodificarods.a2(1) = FormatNumber(CDbl(a2.Text))
            fmrmodificarods.a2(2) = FormatNumber(CDbl(a3.Text))
            fmrmodificarods.a2(3) = FormatNumber(CDbl(a4.Text))
            fmrmodificarods.i2(0) = FormatNumber(CDbl(i1.Text))
            fmrmodificarods.i2(1) = FormatNumber(CDbl(i2.Text))
            fmrmodificarods.i2(2) = FormatNumber(CDbl(i3.Text))
            fmrmodificarods.i2(3) = FormatNumber(CDbl(i4.Text))
            fmrmodificarods.u2(0) = FormatNumber(CDbl(u1.Text))
            fmrmodificarods.u2(1) = FormatNumber(CDbl(u2.Text))
            fmrmodificarods.u2(2) = FormatNumber(CDbl(u3.Text))
            fmrmodificarods.u2(3) = FormatNumber(CDbl(u4.Text))
            fmrmodificarods.cosdirecto = FormatNumber(CDbl(txtcostdglobal.Text))
            fmrmodificarods.imptxtcostadminglobal = FormatNumber(CDbl(txtcostadminglobal.Text))
            fmrmodificarods.imptxtcostimpglobal = FormatNumber(CDbl(txtcostimpglobal.Text))
            fmrmodificarods.imptxtcostutilglobal = FormatNumber(CDbl(txtcostutilglobal.Text))
            fmrmodificarods.imptxtcostsubglobal = FormatNumber(CDbl(txtcostsubglobal.Text))
            fmrmodificarods.imptxtcostivaglobal = FormatNumber(CDbl(txtcostivaglobal.Text))
            fmrmodificarods.impvrgtotal = FormatNumber(CDbl(vrgtotal.Text))
        End If
        Me.Close()
    End Sub
    Private Sub contabilizar()
        REM cuando el valor del costo directo es menor al anterior.
        For i As Integer = 0 To 4
            restadirecto(i) = 0
            restaadmin(i) = 0
            restaimpre(i) = 0
            restautil(i) = 0
            restaiva(i) = 0
            restasubtotal(i) = 0
            restatotal(i) = 0
        Next

        REM resta grupo1
        restadirecto(0) = FormatNumber(CDbl(impcostodirecto1.Text) - CDbl(costod1.Text))
        restaadmin(0) = FormatNumber(CDbl(impadmin1.Text) - CDbl(Admin1.Text))
        restaimpre(0) = FormatNumber(CDbl(impimp1.Text) - CDbl(impre1.Text))
        restautil(0) = FormatNumber(CDbl(imputil1.Text) - CDbl(util1.Text))
        restasubtotal(0) = FormatNumber(CDbl(impsubt1.Text) - CDbl(subt1.Text))
        restaiva(0) = FormatNumber(CDbl(impiva1.Text) - CDbl(iva1.Text))
        restatotal(0) = FormatNumber(CDbl(imptotal1.Text) - CDbl(total1.Text))

        restadirecto(1) = FormatNumber(CDbl(impcostodirecto2.Text) - CDbl(costod2.Text))
        restaadmin(1) = FormatNumber(CDbl(impadmin2.Text) - CDbl(admin2.Text))
        restaimpre(1) = FormatNumber(CDbl(impimp2.Text) - CDbl(impre2.Text))
        restautil(1) = FormatNumber(CDbl(imputil2.Text) - CDbl(util2.Text))
        restasubtotal(1) = FormatNumber(CDbl(impsubt2.Text) - CDbl(subt2.Text))
        restaiva(1) = FormatNumber(CDbl(impiva2.Text) - CDbl(iva2.Text))
        restatotal(1) = FormatNumber(CDbl(imptotal2.Text) - CDbl(total2.Text))

        restadirecto(2) = FormatNumber(CDbl(impcostodirecto3.Text) - CDbl(costod3.Text))
        restaadmin(2) = FormatNumber(CDbl(impadmin3.Text) - CDbl(admin3.Text))
        restaimpre(2) = FormatNumber(CDbl(impipm3.Text) - CDbl(impre3.Text))
        restautil(2) = FormatNumber(CDbl(imputil3.Text) - CDbl(util3.Text))
        restasubtotal(2) = FormatNumber(CDbl(impsubt3.Text) - CDbl(subt3.Text))
        restaiva(2) = FormatNumber(CDbl(impiva3.Text) - CDbl(iva3.Text))
        restatotal(2) = FormatNumber(CDbl(imptotal3.Text) - CDbl(total3.Text))

        restadirecto(3) = FormatNumber(CDbl(impcostodirecto4.Text) - CDbl(costod4.Text))
        restaadmin(3) = FormatNumber(CDbl(impadmin4.Text) - CDbl(admin4.Text))
        restaimpre(3) = FormatNumber(CDbl(impipm4.Text) - CDbl(impre4.Text))
        restautil(3) = FormatNumber(CDbl(imputi4.Text) - CDbl(util4.Text))
        restasubtotal(3) = FormatNumber(CDbl(impsubt4.Text) - CDbl(subt4.Text))
        restaiva(3) = FormatNumber(CDbl(impiva4.Text) - CDbl(iva4.Text))
        restatotal(3) = FormatNumber(CDbl(imptotal4.Text) - CDbl(total4.Text))

        restadirecto(4) = FormatNumber(CDbl(impcostodirecto.Text) - CDbl(txtcostdglobal.Text))
        restaadmin(4) = FormatNumber(CDbl(impadministracion.Text) - CDbl(txtcostadminglobal.Text))
        restaimpre(4) = FormatNumber(CDbl(impimprevisto.Text) - CDbl(txtcostimpglobal.Text))
        restautil(4) = FormatNumber(CDbl(imputilidad.Text) - CDbl(txtcostutilglobal.Text))
        restaiva(4) = FormatNumber(CDbl(impiva.Text) - CDbl(txtcostivaglobal.Text))
        restasubtotal(4) = FormatNumber(CDbl(impsubtotal.Text) - CDbl(txtcostsubglobal.Text))
        restatotal(4) = FormatNumber(CDbl(imptotal.Text) - CDbl(vrgtotal.Text))


    End Sub
    Private Sub btnaceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnaceptar.Click
        guardar()
        fmrmodificarods.modo = 4
        fmrmodificarods.modalidad()
        Me.Close()
    End Sub
End Class