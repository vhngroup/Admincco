Public Class cierreestructuraods
    Friend ods As String
    Friend contrato As String
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
    Private Sub btncancelar_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub lblsaldo_TextChanged(sender As Object, e As System.EventArgs) Handles lblsaldo.TextChanged
        lblsaldo.Text = FormatNumber(CDbl(lblsaldo.Text), 2)
    End Sub
    Private Sub TextBox10_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox10.TextChanged
        If TextBox10.Text = "" Then TextBox10.Text = 0
        TextBox10.Text = FormatNumber(CDbl(TextBox10.Text), 2)
    End Sub
    Private Sub TextBox9_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox9.TextChanged
        If TextBox9.Text = "" Then TextBox9.Text = 0
        TextBox9.Text = FormatNumber(CDbl(TextBox9.Text), 2)
    End Sub
    Private Sub TextBox8_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox8.TextChanged
        If TextBox8.Text = "" Then TextBox8.Text = 0
        TextBox8.Text = FormatNumber(CDbl(TextBox8.Text), 2)
    End Sub
    Private Sub TextBox7_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox7.TextChanged
        If TextBox7.Text = "" Then TextBox7.Text = 0
        TextBox7.Text = FormatNumber(CDbl(TextBox7.Text), 2)
    End Sub
    Private Sub TextBox6_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text = "" Then TextBox6.Text = 0
        TextBox6.Text = FormatNumber(CDbl(TextBox6.Text), 2)
    End Sub
    Private Sub TextBox5_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text = "" Then TextBox5.Text = 0
        TextBox5.Text = FormatNumber(CDbl(TextBox5.Text), 2)
    End Sub
    Private Sub TextBox21_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox21.TextChanged
        TextBox21.Text = FormatNumber(CDbl(TextBox21.Text), 2)
        If CDbl(costod3.Text) < CDbl(TextBox21.Text) Then
            Me.ErrorProvider3.SetError(TextBox21, "El valor ingresado es superior al costo directo original")
        Else
            Me.ErrorProvider3.Clear()
        End If
        calculo3()
        constante()
    End Sub
    Private Sub TextBox20_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox20.TextChanged
        If TextBox20.Text = "" Then TextBox20.Text = 0
        TextBox20.Text = FormatNumber(CDbl(TextBox20.Text), 2)
    End Sub
    Private Sub TextBox19_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox19.TextChanged
        If TextBox19.Text = "" Then TextBox19.Text = 0
        TextBox19.Text = FormatNumber(CDbl(TextBox19.Text), 2)
    End Sub
    Private Sub TextBox18_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox18.TextChanged
        If TextBox18.Text = "" Then TextBox18.Text = 0
        TextBox18.Text = FormatNumber(CDbl(TextBox18.Text), 2)
    End Sub
    Private Sub TextBox17_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox17.TextChanged
        If TextBox17.Text = "" Then TextBox17.Text = 0
        TextBox17.Text = FormatNumber(CDbl(TextBox17.Text), 2)
    End Sub
    Private Sub TextBox16_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox16.TextChanged
        If TextBox16.Text = "" Then TextBox16.Text = 0
        TextBox16.Text = FormatNumber(CDbl(TextBox16.Text), 2)
    End Sub
    Private Sub TextBox15_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox15.TextChanged
        If TextBox15.Text = "" Then TextBox15.Text = 0
        TextBox15.Text = FormatNumber(CDbl(TextBox15.Text), 2)
    End Sub
    Private Sub TextBox25_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox25.TextChanged
        If TextBox25.Text = "" Then TextBox25.Text = 0
        TextBox25.Text = FormatNumber(CDbl(TextBox25.Text), 2)
    End Sub
    Private Sub TextBox26_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox26.TextChanged
        TextBox26.Text = FormatNumber(CDbl(TextBox26.Text), 2)
        If CDbl(costod4.Text) < CDbl(TextBox26.Text) Then
            Me.ErrorProvider3.SetError(TextBox26, "El valor ingresado es superior al costo directo original")
        Else
            Me.ErrorProvider3.Clear()
        End If
        calculo4()
        constante()
    End Sub
    Private Sub TextBox27_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox27.TextChanged
        If TextBox27.Text = "" Then TextBox27.Text = 0
        TextBox27.Text = FormatNumber(CDbl(TextBox27.Text), 2)
    End Sub
    Private Sub TextBox28_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox28.TextChanged
        If TextBox28.Text = "" Then TextBox28.Text = 0
        TextBox28.Text = FormatNumber(CDbl(TextBox28.Text), 2)
    End Sub
    Private Sub TextBox29_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox29.TextChanged
        If TextBox29.Text = "" Then TextBox29.Text = 0
        TextBox29.Text = FormatNumber(CDbl(TextBox29.Text), 2)
    End Sub
    Private Sub TextBox30_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox30.TextChanged
        If TextBox30.Text = "" Then TextBox30.Text = 0
        TextBox30.Text = FormatNumber(CDbl(TextBox30.Text), 2)
    End Sub
    Private Sub TextBox31_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox31.TextChanged
        If TextBox31.Text = "" Then TextBox31.Text = 0
        TextBox31.Text = FormatNumber(CDbl(TextBox31.Text), 2)
    End Sub
    Private Sub TextBox40_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox40.TextChanged
        If TextBox40.Text = "" Then TextBox40.Text = 0
        TextBox40.Text = FormatNumber(CDbl(TextBox40.Text), 2)
    End Sub
    Private Sub TextBox36_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox36.TextChanged
        If TextBox36.Text = "" Then TextBox36.Text = 0
        TextBox36.Text = FormatNumber(CDbl(TextBox36.Text), 2)
    End Sub
    Private Sub TextBox35_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox35.TextChanged
        If TextBox35.Text = "" Then TextBox35.Text = 0
        TextBox35.Text = FormatNumber(CDbl(TextBox35.Text), 2)

    End Sub
    Private Sub TextBox38_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox38.TextChanged
        If TextBox38.Text = "" Then TextBox38.Text = 0
        TextBox38.Text = FormatNumber(CDbl(TextBox38.Text), 2)
    End Sub
    Private Sub TextBox39_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox39.TextChanged
        If TextBox39.Text = "" Then TextBox39.Text = 0
        TextBox39.Text = FormatNumber(CDbl(TextBox39.Text), 2)
    End Sub
    Private Sub TextBox37_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox37.TextChanged
        If TextBox37.Text = "" Then TextBox37.Text = 0
        TextBox37.Text = FormatNumber(CDbl(TextBox37.Text), 2)
    End Sub
    Private Sub TextBox11_TextChanged(sender As Object, e As System.EventArgs) Handles TextBox11.TextChanged
        REM abajo1
        TextBox11.Text = FormatNumber(CDbl(TextBox11.Text), 2)
        If CDbl(costod1.Text) < CDbl(TextBox11.Text) Then
            Me.ErrorProvider1.SetError(TextBox11, "El valor ingresado es superior al costo directo original")
        Else
            Me.ErrorProvider1.Clear()
        End If
        calculo1()
        constante()
    End Sub
    Private Sub TextBox42_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox42.TextChanged
        REM arriba1
        TextBox42.Text = Trim(dejarNumerosPuntos(TextBox42.Text))
        If (String.IsNullOrEmpty(TextBox42.Text.Trim())) Then
            Me.ErrorProvider1.SetError(TextBox42, "Cuidado, espacio vacio")
            TextBox11.Text = 0
        Else
            Me.ErrorProvider1.Clear()
            TextBox11.Text = TextBox42.Text
        End If
    End Sub
    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged
        REM arriba2
        TextBox2.Text = Trim(dejarNumerosPuntos(TextBox2.Text))
        If (String.IsNullOrEmpty(TextBox2.Text.Trim())) Then
            Me.ErrorProvider2.SetError(TextBox2, "Cuidado, espacio vacio")
            TextBox41.Text = 0
        Else
            Me.ErrorProvider2.Clear()
            TextBox41.Text = TextBox2.Text
        End If
    End Sub
    Private Sub TextBox41_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox41.TextChanged
        REM abajo2
        TextBox41.Text = FormatNumber(CDbl(TextBox41.Text), 2)
        If CDbl(costod2.Text) < CDbl(TextBox41.Text) Then
            Me.ErrorProvider2.SetError(TextBox41, "El valor ingresado es superior al costo directo original")
        Else
            Me.ErrorProvider2.Clear()

        End If
        calculo2()
        constante()
    End Sub
    Private Sub calculo1()
        If servicio1.Text = 1 Then ' Verifica el tipo de servicio, 1 2 o 3
            a1.Enabled = True
            i1.Enabled = True
            u1.Enabled = True
            If a1.Text <> "" Then ' Administracion 
                If a1.Text = 0 Then
                    TextBox10.Text = 0
                Else
                    TextBox10.Text = FormatNumber(CDbl(TextBox11.Text) * CDbl(a1.Text) / 100)
                End If
            Else
                a1.Text = 0
                TextBox10.Text = 0
            End If

            If i1.Text <> "" Then ' Imprevistos
                If i1.Text = 0 Then
                    TextBox9.Text = 0
                Else
                    TextBox9.Text = FormatNumber(CDbl(TextBox11.Text) * CDbl(i1.Text) / 100)
                End If
            Else
                TextBox9.Text = 0
                i1.Text = 0
            End If

            If u1.Text <> "" Then ' Utilidad
                If u1.Text = 0 Then
                    TextBox8.Text = 0
                Else
                    TextBox8.Text = FormatNumber(CDbl(TextBox11.Text) * CDbl(u1.Text) / 100)
                End If
            Else
                TextBox8.Text = 0
                u1.Text = 0
            End If

            TextBox7.Text = FormatNumber(CDbl(TextBox11.Text) + CDbl(TextBox10.Text) + CDbl(TextBox9.Text) + CDbl(TextBox8.Text))
            TextBox6.Text = FormatNumber(CDbl(TextBox8.Text) * 0.16) ' Multiplica la utilidad x el 16%
            TextBox5.Text = FormatNumber(CDbl(TextBox6.Text) + CDbl(TextBox7.Text)) ' suma el iva + el subtotal
        End If

        If servicio1.Text = 2 Then ' Caso 2
            a1.Enabled = True
            u1.Enabled = False ' Desabilita Utilidad
            i1.Enabled = False
            u1.Enabled = False ' Desabilita Utilidad
            u1.Text = 0
            i1.Text = 0
            TextBox8.Text = 0
            TextBox9.Text = 0
            If a1.Text <> "" Then ' Administracion 
                If a1.Text = 0 Then
                    TextBox10.Text = 0
                Else
                    TextBox10.Text = FormatNumber(CDbl(TextBox11.Text) * CDbl(a1.Text) / 100)
                End If
            Else
                a1.Text = 0
                TextBox10.Text = 0
            End If
            TextBox7.Text = FormatNumber(CDbl(TextBox11.Text) + CDbl(TextBox10.Text) + CDbl(TextBox8.Text))
            TextBox6.Text = FormatNumber(TextBox10.Text * 0.16) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 16%
            TextBox5.Text = FormatNumber(CDbl(TextBox6.Text) + CDbl(TextBox7.Text))
        End If

        If servicio1.Text = 3 Then 'Opcion 3
            i1.Enabled = False
            u1.Enabled = False ' Desabilita Utilidad
            a1.Enabled = False
            u1.Text = 0
            i1.Text = 0
            TextBox8.Text = 0
            TextBox9.Text = 0
            TextBox10.Text = 0
            TextBox7.Text = FormatNumber(CDbl(TextBox11.Text))
            TextBox6.Text = FormatNumber(CDbl(TextBox7.Text) * 0.16)
            TextBox5.Text = FormatNumber(CDbl(TextBox6.Text) + CDbl(TextBox7.Text))
        End If

    End Sub
    Private Sub calculo2()
        If servicio2.Text = 1 Then ' Verifica el tipo de servicio, 2 2 o 3
            a2.Enabled = True
            i2.Enabled = True
            u2.Enabled = True
            If a2.Text <> "" Then ' Administracion 
                If a2.Text = 0 Then
                    TextBox40.Text = 0
                Else
                    TextBox40.Text = FormatNumber(CDbl(TextBox41.Text) * CDbl(a2.Text) / 100)
                End If
            Else
                a2.Text = 0
                TextBox40.Text = 0
            End If

            If i2.Text <> "" Then ' Imprevistos
                If i2.Text = 0 Then
                    TextBox39.Text = 0
                Else
                    TextBox39.Text = FormatNumber(CDbl(TextBox41.Text) * CDbl(i2.Text) / 100)
                End If
            Else
                TextBox39.Text = 0
                i2.Text = 0
            End If

            If u2.Text <> "" Then ' Utilidad
                If u2.Text = 0 Then
                    TextBox38.Text = 0
                Else
                    TextBox38.Text = FormatNumber(CDbl(TextBox41.Text) * CDbl(u2.Text) / 100)
                End If
            Else
                TextBox38.Text = 0
                u2.Text = 0
            End If

            TextBox37.Text = FormatNumber(CDbl(TextBox41.Text) + CDbl(TextBox40.Text) + CDbl(TextBox39.Text) + CDbl(TextBox38.Text))
            TextBox36.Text = FormatNumber(CDbl(TextBox38.Text) * 0.16) ' Multiplica la utilidad x el 26%
            TextBox35.Text = FormatNumber(CDbl(TextBox36.Text) + CDbl(TextBox37.Text)) ' suma el iva + el subtotal
        End If

        If servicio2.Text = 2 Then ' Caso 2
            a2.Enabled = True
            u2.Enabled = False ' Desabilita Utilidad
            i2.Enabled = False
            u2.Enabled = False ' Desabilita Utilidad
            u2.Text = 0
            i2.Text = 0
            TextBox38.Text = 0
            TextBox39.Text = 0
            If a2.Text <> "" Then ' Administracion 
                If a2.Text = 0 Then
                    TextBox40.Text = 0
                Else

                    TextBox40.Text = FormatNumber(CDbl(TextBox41.Text) * CDbl(a2.Text) / 100)
                End If

            Else
                a2.Text = 0
                TextBox40.Text = 0
            End If
            TextBox37.Text = FormatNumber(CDbl(TextBox41.Text) + CDbl(TextBox40.Text) + CDbl(TextBox38.Text))
            TextBox36.Text = FormatNumber(CDbl(TextBox40.Text * 0.16)) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 26%
            TextBox35.Text = FormatNumber(CDbl(TextBox36.Text) + CDbl(TextBox37.Text))
        End If

        If servicio2.Text = 3 Then 'Opcion 3
            i2.Enabled = False
            u2.Enabled = False ' Desabilita Utilidad
            a2.Enabled = False
            u2.Text = 0
            i2.Text = 0
            TextBox38.Text = 0
            TextBox39.Text = 0
            TextBox40.Text = 0
            TextBox37.Text = FormatNumber(CDbl(TextBox41.Text))
            TextBox36.Text = FormatNumber(CDbl(TextBox37.Text) * 0.16)
            TextBox35.Text = FormatNumber(CDbl(TextBox36.Text) + CDbl(TextBox37.Text))
        End If


    End Sub
    Private Sub calculo3()
        If servicio3.Text = 1 Then ' Verifica el tipo de servicio, 3 3 o 3
            a3.Enabled = True
            i3.Enabled = True
            u3.Enabled = True
            If a3.Text <> "" Then ' Administracion 
                If a3.Text = 0 Then
                    TextBox20.Text = 0
                Else

                    TextBox20.Text = FormatNumber(CDbl(TextBox21.Text) * CDbl(a3.Text) / 100)
                End If
            Else
                a3.Text = 0
                TextBox20.Text = 0
            End If

            If i3.Text <> "" Then ' Imprevistos
                If i3.Text = 0 Then
                    TextBox19.Text = 0
                Else
                    TextBox19.Text = FormatNumber(CDbl(TextBox21.Text) * CDbl(i3.Text) / 100)
                End If
            Else
                TextBox19.Text = 0
                i3.Text = 0
            End If

            If u3.Text <> "" Then ' Utilidad
                If u3.Text = 0 Then
                    TextBox18.Text = 0
                Else
                    TextBox18.Text = FormatNumber(CDbl(TextBox21.Text) * CDbl(u3.Text) / 100)
                End If
            Else
                TextBox18.Text = 0
                u3.Text = 0
            End If

            TextBox17.Text = FormatNumber(CDbl(TextBox21.Text) + CDbl(TextBox20.Text) + CDbl(TextBox19.Text) + CDbl(TextBox18.Text))
            TextBox16.Text = FormatNumber(CDbl(TextBox18.Text) * 0.16) ' Multiplica la utilidad x el 36%
            TextBox15.Text = FormatNumber(CDbl(TextBox16.Text) + CDbl(TextBox17.Text)) ' suma el iva + el subtotal
        End If

        If servicio3.Text = 2 Then ' Caso 3
            a3.Enabled = True
            u3.Enabled = False ' Desabilita Utilidad
            i3.Enabled = False
            u3.Enabled = False ' Desabilita Utilidad
            u3.Text = 0
            i3.Text = 0
            TextBox18.Text = 0
            TextBox19.Text = 0
            If a3.Text <> "" Then ' Administracion 
                If a3.Text = 0 Then
                    TextBox20.Text = 0
                Else
                    TextBox20.Text = FormatNumber(CDbl(TextBox21.Text) * CDbl(a3.Text) / 100)
                End If

            Else
                a3.Text = 0
                TextBox20.Text = 0
            End If
            TextBox17.Text = FormatNumber(CDbl(TextBox21.Text) + CDbl(TextBox20.Text) + CDbl(TextBox18.Text))
            TextBox16.Text = FormatNumber(CDbl(TextBox20.Text * 0.16)) ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 36%
            TextBox15.Text = FormatNumber(CDbl(TextBox16.Text) + CDbl(TextBox17.Text))
        End If
        If servicio3.Text = 3 Then 'Opcion 3
            i3.Enabled = False
            u3.Enabled = False ' Desabilita Utilidad
            a3.Enabled = False
            u3.Text = 0
            i3.Text = 0
            TextBox18.Text = 0
            TextBox19.Text = 0
            TextBox20.Text = 0
            TextBox17.Text = TextBox21.Text
            TextBox16.Text = FormatNumber(CDbl(TextBox17.Text) * 0.16)
            TextBox15.Text = FormatNumber(CDbl(TextBox16.Text) + CDbl(TextBox17.Text))
        End If

    End Sub

    Private Sub calculo4()

        If servicio4.Text = 1 Then ' Verifica el tipo de servicio, 4 4 o 4
            a4.Enabled = True
            i4.Enabled = True
            u4.Enabled = True
            If a4.Text <> "" Then ' Administracion 
                If a4.Text = 0 Then
                    TextBox31.Text = 0
                Else
                    TextBox31.Text = FormatNumber(CDbl(TextBox26.Text) * CDbl(a4.Text) / 100)
                End If
            Else
                a4.Text = 0
                TextBox31.Text = 0
            End If

            If i4.Text <> "" Then ' Imprevistos
                If i4.Text = 0 Then
                    TextBox30.Text = 0
                Else
                    TextBox30.Text = FormatNumber(CDbl(TextBox26.Text) * CDbl(i4.Text) / 100)
                End If
            Else
                TextBox30.Text = 0
                i4.Text = 0
            End If

            If u4.Text <> "" Then ' Utilidad
                If u4.Text = 0 Then
                    TextBox29.Text = 0
                Else
                    TextBox29.Text = FormatNumber(CDbl(TextBox26.Text) * CDbl(u4.Text) / 100)
                End If
            Else
                TextBox29.Text = 0
                u4.Text = 0
            End If

            TextBox28.Text = FormatNumber(CDbl(TextBox26.Text) + CDbl(TextBox31.Text) + CDbl(TextBox30.Text) + CDbl(TextBox29.Text))
            TextBox27.Text = FormatNumber(CDbl(TextBox29.Text) * 0.16) ' Multiplica la utilidad x el 46%
            TextBox25.Text = FormatNumber(CDbl(TextBox27.Text) + CDbl(TextBox28.Text)) ' suma el iva + el subtotal
        End If

        If servicio4.Text = 2 Then ' Caso 4
            a4.Enabled = True
            u4.Enabled = False ' Desabilita Utilidad
            i4.Enabled = False
            u4.Enabled = False ' Desabilita Utilidad
            u4.Text = 0
            i4.Text = 0
            TextBox29.Text = 0
            TextBox30.Text = 0
            If a4.Text <> "" Then ' Administracion 
                If a4.Text = 0 Then
                    TextBox31.Text = 0
                Else
                    TextBox31.Text = FormatNumber(CDbl(TextBox26.Text) * CDbl(a4.Text) / 100)
                End If

            Else
                a4.Text = 0
                TextBox31.Text = 0
            End If
            TextBox28.Text = FormatNumber(CDbl(TextBox26.Text) + CDbl(TextBox31.Text) + CDbl(TextBox29.Text))
            TextBox27.Text = TextBox31.Text * 0.16 ' hace Iva igual al costo directo + la administracion+ la utilidad y lo multiplica x el 46%
            TextBox25.Text = FormatNumber(CDbl(TextBox27.Text) + CDbl(TextBox28.Text))
        End If
        If servicio4.Text = 3 Then 'Opcion 4
            i4.Enabled = False
            u4.Enabled = False ' Desabilita Utilidad
            a4.Enabled = False
            u4.Text = 0
            i4.Text = 0
            TextBox29.Text = 0
            TextBox30.Text = 0
            TextBox31.Text = 0
            TextBox28.Text = TextBox26.Text
            TextBox27.Text = FormatNumber(CDbl(TextBox28.Text) * 0.16)
            TextBox25.Text = FormatNumber(CDbl(TextBox27.Text) + CDbl(TextBox28.Text))
        End If

    End Sub

    Private Sub TextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox3.TextChanged
        TextBox3.Text = Trim(dejarNumerosPuntos(TextBox3.Text))
        If (String.IsNullOrEmpty(TextBox3.Text.Trim())) Then
            Me.ErrorProvider3.SetError(TextBox3, "Cuidado, espacio vacio")
            TextBox21.Text = 0
        Else
            Me.ErrorProvider3.Clear()
            TextBox21.Text = TextBox3.Text
        End If
    End Sub
    Private Sub constante()
        If TextBox11.Text = "" Then TextBox11.Text = 0
        If TextBox41.Text = "" Then TextBox41.Text = 0
        If TextBox21.Text = "" Then TextBox21.Text = 0
        If TextBox26.Text = "" Then TextBox26.Text = 0
        txtcostdglobal.Text = FormatNumber(CDbl(TextBox11.Text) + CDbl(TextBox41.Text) + CDbl(TextBox21.Text) + CDbl(TextBox26.Text))
        txtcostadminglobal.Text = FormatNumber(CDbl(TextBox10.Text) + CDbl(TextBox40.Text) + CDbl(TextBox20.Text) + CDbl(TextBox31.Text))
        txtcostimpglobal.Text = FormatNumber(CDbl(TextBox9.Text) + CDbl(TextBox39.Text) + CDbl(TextBox19.Text) + CDbl(TextBox30.Text))
        txtcostutilglobal.Text = FormatNumber(CDbl(TextBox8.Text) + CDbl(TextBox38.Text) + CDbl(TextBox18.Text) + CDbl(TextBox29.Text))
        txtcostsubglobal.Text = FormatNumber(CDbl(TextBox7.Text) + CDbl(TextBox37.Text) + CDbl(TextBox17.Text) + CDbl(TextBox28.Text))
        txtcostivaglobal.Text = FormatNumber(CDbl(TextBox6.Text) + CDbl(TextBox36.Text) + CDbl(TextBox16.Text) + CDbl(TextBox27.Text))
        vrgtotal.Text = FormatNumber(CDbl(TextBox5.Text) + CDbl(TextBox35.Text) + CDbl(TextBox15.Text) + CDbl(TextBox25.Text))

        If txtcostdglobal.Text = lblsaldo.Text Then
            Label82.Text = "Todo en Orden"
            CheckBox1.Enabled = True
        End If
        If txtcostdglobal.Text < lblsaldo.Text Then
            Label82.Text = "por favor verifique los costos directos de cada linea"
            CheckBox1.Enabled = False
        End If
        If txtcostdglobal.Text > lblsaldo.Text Then
            Label82.Text = "La suma de las lineas no puede ser mayor al saldo."
            CheckBox1.Enabled = False
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox4.TextChanged
        TextBox4.Text = Trim(dejarNumerosPuntos(TextBox4.Text))
        If (String.IsNullOrEmpty(TextBox4.Text.Trim())) Then
            Me.ErrorProvider4.SetError(TextBox4, "Cuidado, espacio vacio")
            TextBox26.Text = 0
        Else
            Me.ErrorProvider4.Clear()
            TextBox26.Text = TextBox4.Text
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            btnaceptar.Enabled = True
            TextBox42.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
        End If
        If CheckBox1.Checked = False Then
            btnaceptar.Enabled = False
            TextBox42.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            TextBox4.Enabled = True
        End If
    End Sub
    Private Sub btnaceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnaceptar.Click
        REM costo
        rcierreods.costod2(0) = FormatNumber(CDbl(TextBox11.Text) + CDbl(impcd1.Text))
        rcierreods.costod2(1) = FormatNumber(CDbl(TextBox41.Text) + CDbl(impcd2.Text))
        rcierreods.costod2(2) = FormatNumber(CDbl(TextBox21.Text) + CDbl(impcd3.Text))
        rcierreods.costod2(3) = FormatNumber(CDbl(TextBox26.Text) + CDbl(impcd4.Text))
        REM
        rcierreods.costod2(4) = FormatNumber(CDbl(costod1.Text) - CDbl(TextBox11.Text))
        rcierreods.costod2(5) = FormatNumber(CDbl(costod2.Text) - CDbl(TextBox41.Text))
        rcierreods.costod2(6) = FormatNumber(CDbl(costod3.Text) - CDbl(TextBox21.Text))
        rcierreods.costod2(7) = FormatNumber(CDbl(costod4.Text) - CDbl(TextBox26.Text))
        REM admin 
        rcierreods.admin2(0) = FormatNumber(CDbl(TextBox10.Text) + CDbl(impadm1.Text))
        rcierreods.admin2(1) = FormatNumber(CDbl(TextBox40.Text) + CDbl(impadm2.Text))
        rcierreods.admin2(2) = FormatNumber(CDbl(TextBox20.Text) + CDbl(impadm3.Text))
        rcierreods.admin2(3) = FormatNumber(CDbl(TextBox31.Text) + CDbl(impadm4.Text))
        REM
        rcierreods.admin2(4) = FormatNumber(CDbl(Admin1.Text) - CDbl(TextBox10.Text))
        rcierreods.admin2(5) = FormatNumber(CDbl(admin2.Text) - CDbl(TextBox40.Text))
        rcierreods.admin2(6) = FormatNumber(CDbl(admin3.Text) - CDbl(TextBox20.Text))
        rcierreods.admin2(7) = FormatNumber(CDbl(admin4.Text) - CDbl(TextBox31.Text))
        REM impre
        rcierreods.impre2(0) = FormatNumber(CDbl(TextBox9.Text) + CDbl(impimp1.Text))
        rcierreods.impre2(1) = FormatNumber(CDbl(TextBox39.Text) + CDbl(impimp2.Text))
        rcierreods.impre2(2) = FormatNumber(CDbl(TextBox19.Text) + CDbl(impimp3.Text))
        rcierreods.impre2(3) = FormatNumber(CDbl(TextBox30.Text) + CDbl(impimp4.Text))
        REM
        rcierreods.impre2(4) = FormatNumber(CDbl(impre1.Text) - CDbl(TextBox9.Text))
        rcierreods.impre2(5) = FormatNumber(CDbl(impre2.Text) - CDbl(TextBox39.Text))
        rcierreods.impre2(6) = FormatNumber(CDbl(impre3.Text) - CDbl(TextBox19.Text))
        rcierreods.impre2(7) = FormatNumber(CDbl(impre4.Text) - CDbl(TextBox30.Text))
        REM util
        rcierreods.util2(0) = FormatNumber(CDbl(TextBox8.Text) + CDbl(imputi1.Text))
        rcierreods.util2(1) = FormatNumber(CDbl(TextBox38.Text) + CDbl(imputi2.Text))
        rcierreods.util2(2) = FormatNumber(CDbl(TextBox18.Text) + CDbl(imputi3.Text))
        rcierreods.util2(3) = FormatNumber(CDbl(TextBox29.Text) + CDbl(imputi4.Text))
        REM
        rcierreods.util2(4) = FormatNumber(CDbl(util1.Text) - CDbl(TextBox8.Text))
        rcierreods.util2(5) = FormatNumber(CDbl(util2.Text) - CDbl(TextBox38.Text))
        rcierreods.util2(6) = FormatNumber(CDbl(util3.Text) - CDbl(TextBox18.Text))
        rcierreods.util2(7) = FormatNumber(CDbl(util4.Text) - CDbl(TextBox29.Text))
        REM subt
        rcierreods.subt2(0) = FormatNumber(CDbl(TextBox7.Text) + CDbl(impsubto1.Text))
        rcierreods.subt2(1) = FormatNumber(CDbl(TextBox37.Text) + CDbl(impsubto2.Text))
        rcierreods.subt2(2) = FormatNumber(CDbl(TextBox17.Text) + CDbl(impsubto3.Text))
        rcierreods.subt2(3) = FormatNumber(CDbl(TextBox28.Text) + CDbl(impsubto4.Text))
        REM
        rcierreods.subt2(4) = FormatNumber(CDbl(subt1.Text) - CDbl(TextBox7.Text))
        rcierreods.subt2(5) = FormatNumber(CDbl(subt2.Text) - CDbl(TextBox37.Text))
        rcierreods.subt2(6) = FormatNumber(CDbl(subt3.Text) - CDbl(TextBox17.Text))
        rcierreods.subt2(7) = FormatNumber(CDbl(subt4.Text) - CDbl(TextBox28.Text))
        REM iva
        rcierreods.iva2(0) = FormatNumber(CDbl(TextBox6.Text) + CDbl(impiva1.Text))
        rcierreods.iva2(1) = FormatNumber(CDbl(TextBox36.Text) + CDbl(impiva2.Text))
        rcierreods.iva2(2) = FormatNumber(CDbl(TextBox16.Text) + CDbl(impiva3.Text))
        rcierreods.iva2(3) = FormatNumber(CDbl(TextBox27.Text) + CDbl(impiva4.Text))
        REM
        rcierreods.iva2(4) = FormatNumber(CDbl(iva1.Text) - CDbl(TextBox6.Text))
        rcierreods.iva2(5) = FormatNumber(CDbl(iva2.Text) - CDbl(TextBox36.Text))
        rcierreods.iva2(6) = FormatNumber(CDbl(iva3.Text) - CDbl(TextBox16.Text))
        rcierreods.iva2(7) = FormatNumber(CDbl(iva4.Text) - CDbl(TextBox27.Text))
        REM total
        rcierreods.total2(0) = FormatNumber(CDbl(TextBox5.Text) + CDbl(imptotal1.Text))
        rcierreods.total2(1) = FormatNumber(CDbl(TextBox35.Text) + CDbl(imptotal2.Text))
        rcierreods.total2(2) = FormatNumber(CDbl(TextBox15.Text) + CDbl(imptotal3.Text))
        rcierreods.total2(3) = FormatNumber(CDbl(TextBox25.Text) + CDbl(imptotal4.Text))
        REM muestra el valor real total de la ODS
        rcierreods.total2(4) = FormatNumber(CDbl(total1.Text) - CDbl(TextBox5.Text))
        rcierreods.total2(5) = FormatNumber(CDbl(total2.Text) - CDbl(TextBox35.Text))
        rcierreods.total2(6) = FormatNumber(CDbl(total3.Text) - CDbl(TextBox15.Text))
        rcierreods.total2(7) = FormatNumber(CDbl(total4.Text) - CDbl(TextBox25.Text))
        REM 
        rcierreods.impsuma(0) = FormatNumber(CDbl(TextBox11.Text) + CDbl(TextBox12.Text))
        rcierreods.impsuma(1) = FormatNumber(CDbl(TextBox14.Text) + CDbl(TextBox41.Text))
        rcierreods.impsuma(2) = FormatNumber(CDbl(TextBox33.Text) + CDbl(TextBox21.Text))
        rcierreods.impsuma(3) = FormatNumber(CDbl(TextBox24.Text) + CDbl(TextBox26.Text))
        REM
        rcierreods.impcostod = FormatNumber(CDbl(txtcostdglobal.Text))
        rcierreods.impadmin = FormatNumber(CDbl(txtcostadminglobal.Text))
        rcierreods.impimpre = FormatNumber(CDbl(txtcostimpglobal.Text))
        rcierreods.imputil = FormatNumber(CDbl(txtcostutilglobal.Text))
        rcierreods.impsubtcost = FormatNumber(CDbl(txtcostsubglobal.Text))
        rcierreods.impiva = FormatNumber(CDbl(txtcostivaglobal.Text))
        rcierreods.imptotal = FormatNumber(CDbl(vrgtotal.Text))
        rcierreods.importar()
        rcierreods.Estadoods.Text = "Concluida"
        Me.Close()
    End Sub
    Private Sub TextBox12_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox12.TextChanged
        If TextBox12.Text = "" Then TextBox12.Text = 0
        TextBox12.Text = FormatNumber(CDbl(TextBox12.Text), 2)
    End Sub

    Private Sub TextBox14_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox14.TextChanged
        If TextBox14.Text = "" Then TextBox14.Text = 0
        TextBox14.Text = FormatNumber(CDbl(TextBox14.Text), 2)
    End Sub


    Private Sub TextBox33_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox33.TextChanged
        If TextBox33.Text = "" Then TextBox33.Text = 0
        TextBox33.Text = FormatNumber(CDbl(TextBox33.Text), 2)
    End Sub

    Private Sub TextBox24_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox24.TextChanged
        If TextBox24.Text = "" Then TextBox24.Text = 0
        TextBox24.Text = FormatNumber(CDbl(TextBox24.Text), 2)
    End Sub
    Private Sub cierreestructuraods_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim classResize As New clsResizeForm
        REM classResize.ResizeForm(Me, 1366, 768)
        Me.CMNuevosTableAdapter.Fill(Me.Adminco_MasterDataSet.CMNuevos)
        Me.ODSTableAdapter.Fill(Me.Adminco_MasterDataSet.ODS)
        contratonumero.Text = ods
        Label85.Text = contrato
        lblsaldo.Text = rcierreods.saldo
    End Sub
End Class