Public Class frmRegistro


    Private _ControlNombre As Boolean
    Private _ConrtrolApellidos As Boolean

    Private Function ValidaString(ByVal cadena As String, ByVal logitudMaxima As Integer, ByVal Nulo As Boolean) As Integer
        Dim CodigoError As Integer = 0

        If cadena.Length > logitudMaxima Then
            CodigoError = 1
        End If

        If Not Nulo And cadena.Length < 1 Then
            CodigoError = 2
        End If

        Return CodigoError

    End Function

    Public Sub IndicarError(ByVal pControl As Control, ByVal CadenaErrores As String)
        Dim TTip As ToolTip = New ToolTip()
        pControl.BackColor = Color.LightCoral
        TTip.SetToolTip(pControl, CadenaErrores)

        'Es redundante usar un tooltip y el color con el error provider, pero se pone a modo de ejemplo
        ErrorProvider1.SetError(pControl, CadenaErrores)
    End Sub

    Public Sub IndicarOk(ByVal pControl As Control, ByVal CadenaErrores As String)
        pControl.BackColor = Color.White


        'Es redundante usar un tooltip y el color con el error provider, pero se pone a modo de ejemplo
        ErrorProvider1.SetError(pControl, "")
    End Sub

    '''' <summary>
    '''' Validar un formulario se pude hacer de muchas formas, una de ellas es a la hora de pulsar el botón aceptar.
    '''' Tenemos que validar todos los errores por separado para poder informar al usuario de TODOS los errores cometidos.
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    'Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
    '    Dim CadenaErrores As String = ""
    '    Dim Resultado As Integer = 0


    '    Resultado = ValidaString(tbNombre.Text, 100, False)
    '    If Resultado > 0 Then
    '        Select Case Resultado
    '            Case 1
    '                CadenaErrores &= "El Campo Nombre no permite más de 100 carácteres." & vbNewLine
    '            Case 2
    '                CadenaErrores &= "El Campo Nombre no puede estar vacío" & vbNewLine
    '        End Select


    '    End If

    '    CadenaErrores = ""
    '    Resultado = ValidaString(tbApellidos.Text, 255, True)
    '    If Resultado > 0 Then
    '        Select Case Resultado
    '            Case 1
    '                CadenaErrores &= "El Campo Nombre no permite más de 100 carácteres." & vbNewLine
    '            Case 2
    '                CadenaErrores &= "El Campo Nombre no puede estar vacío" & vbNewLine
    '        End Select
    '        tbApellidos.BackColor = Color.LightCoral
    '        TTip.SetToolTip(tbApellidos, CadenaErrores)
    '        ErrorProvider1.SetError(tbApellidos, CadenaErrores)
    '    End If

    '    If CadenaErrores.Length > 0 Then
    '        MsgBox(CadenaErrores)
    '    Else

    '        MsgBox("Jugador insertado correctamente")
    '    End If
    'End Sub





    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        If _ControlNombre And _ConrtrolApellidos Then
            MsgBox("Jugador insertado correctamente")
        Else
            MsgBox("Existen errores en el formulario, por favor revíselo.")
        End If

    End Sub

    Private Sub tbNombre_Leave(sender As Object, e As EventArgs) Handles tbNombre.Leave
        Dim CadenaErrores As String = ""
        Dim Resultado As Integer = 0

        _ControlNombre = False
        Resultado = ValidaString(tbNombre.Text, 100, False)
        If Resultado > 0 Then
            Select Case Resultado
                Case 1
                    CadenaErrores &= "El Campo Nombre no permite más de 100 carácteres." & vbNewLine
                Case 2
                    CadenaErrores &= "El Campo Nombre no puede estar vacío" & vbNewLine
                Case 3
                    CadenaErrores &= "El Campo Nombre no puede ser Rojo." & vbNewLine
            End Select
        Else
            _ControlNombre = True
        End If
        IndicarError(tbNombre, CadenaErrores)
    End Sub

    Private Sub tbApellidos_Leave(sender As Object, e As EventArgs) Handles tbApellidos.Leave
        Dim CadenaErrores As String = ""
        Dim Resultado As Integer = 0

        _ControlNombre = False
        Resultado = ValidaString(tbNombre.Text, 255, True)
        If Resultado > 0 Then
            Select Case Resultado
                Case 1
                    CadenaErrores &= "El Campo Nombre no permite más de 100 carácteres." & vbNewLine
                Case 2
                    CadenaErrores &= "El Campo Nombre no puede estar vacío" & vbNewLine
                Case 3
                    CadenaErrores &= "El Campo Nombre no puede ser Rojo." & vbNewLine
            End Select
        Else
            _ControlNombre = True
        End If
        IndicarError(tbApellidos, CadenaErrores)
    End Sub
    Private Sub frmRegistro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _ControlNombre = False
        _ConrtrolApellidos = True
    End Sub

End Class


