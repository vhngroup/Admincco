Option Strict Off
Option Explicit On
Public Class Form5
    Private Function CreateTextBox(ByVal location As Point, ByVal size As Size) As TextBox

        Dim tb As New TextBox()

        tb.Location = location
        tb.Size = size

        ' Añadimos el controlador para el evento TextChanged
        '
        AddHandler tb.TextChanged, AddressOf TextBoxOnTextChanged

        Return tb

    End Function

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim int As Integer
        Integer.TryParse(Label1.Text, int)
        Label1.Text = (int + 1)

        Dim btnnumero As Integer = 0
        Dim points(CInt(Label1.Text)) As Point
        For index As Integer = 0 To points.Length - 2
            points(index) = New Point(140, (20 * index) + 20)
            ' Creamos el control TextBox
            Dim tb As TextBox = CreateTextBox(points(index), New Size(140, 14))
            ' Lo añadimos al formulario donde actualmente
            ' se está ejecutando el código.
            tb.Parent = Me
        Next
    End Sub
    Private Sub TextBoxOnTextChanged(ByVal sender As Object, ByVal e As EventArgs)

        ' Referenciamos el control TextBox que ha desencadenado el evento
        '
        Dim tb As TextBox = DirectCast(sender, TextBox)

        ' Obtenemos su valor actual
        '
        Console.WriteLine(tb.Text)

    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub
End Class