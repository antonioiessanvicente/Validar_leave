Option Explicit On
Option Strict On
''' <summary>
''' Ejemplo de validación a la hora de abandonar un control
''' </summary>

Public Class frmRegistro

    'Atributos que nos permiten conocer el estado de validación de los controles.
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

        'Es redundante usar un tooltip y el color con el ErrorProvider, pero se pone a modo de ejemplo
        ErrorProvider1.SetError(pControl, CadenaErrores)
    End Sub

    Public Sub IndicarOk(ByVal pControl As Control)
        Dim TTip As ToolTip = New ToolTip()
        pControl.BackColor = Color.White
        TTip.SetToolTip(pControl, "")
        TTip.Active = False

        'Es redundante usar un tooltip y el color con el error provider, pero se pone a modo de ejemplo
        ErrorProvider1.SetError(pControl, "")
    End Sub


    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        'Para que el formulario sea más usable hay que indicar siempre todos los errores cometidos

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
            IndicarError(tbNombre, CadenaErrores)
        Else
            _ControlNombre = True
            IndicarOk(tbNombre)
        End If

    End Sub

    Private Sub tbApellidos_Leave(sender As Object, e As EventArgs) Handles tbApellidos.Leave
        Dim CadenaErrores As String = ""
        Dim Resultado As Integer = 0

        _ConrtrolApellidos = False
        Resultado = ValidaString(tbNombre.Text, 255, True)
        If Resultado > 0 Then
            Select Case Resultado
                Case 1
                    CadenaErrores &= "El Campo Apellidos no permite más de 255 carácteres." & vbNewLine
                Case 2
                    CadenaErrores &= "El Campo Apellidos no puede estar vacío" & vbNewLine
                Case 3
                    CadenaErrores &= "El Campo Apellidos no puede ser Rojo." & vbNewLine
            End Select
            IndicarError(tbApellidos, CadenaErrores)
        Else
            _ConrtrolApellidos = True
            IndicarOk(tbApellidos)
        End If

    End Sub

    Private Sub frmRegistro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Inicializamos el estado de los controles con el formulario vacío.
        _ControlNombre = False
        _ConrtrolApellidos = True
    End Sub

End Class


