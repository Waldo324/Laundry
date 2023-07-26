Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Form1

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Label1.Text = "Contraseña"
        Button1.Text = "Entrar"
        Button2.Text = "Salir"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connection As New SqlConnection("Data Source=DESKTOP-AB232H7;Initial Catalog=laundry;Integrated Security=True")
        Try
            connection.Open()
            Dim query As String = "SELECT nombre FROM empleados"
            Using Command As New SqlCommand(query, connection)
                Using reader As SqlDataReader = Command.ExecuteReader()
                    ListBox1.Items.Clear()
                    While reader.Read()
                        ListBox1.Items.Add(reader("nombre").ToString)
                    End While

                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListBox1.SelectedIndex = -1 Then
            MessageBox.Show("Por favor, seleccione un usuario de la lista.")
            Return
        End If
        Dim connection As New SqlConnection("Data Source=DESKTOP-AB232H7;Initial Catalog=laundry;Integrated Security=True")
        Dim usuario As String = ListBox1.SelectedItem.ToString()
        Dim contraseña As String = TextBox1.Text
        connection.Open()
        Dim query As String = "SELECT contraseña FROM empleados WHERE nombre = @nombre"
        Using comando As New SqlCommand(query, connection)
            comando.Parameters.AddWithValue("@nombre", usuario)
            Dim contraseña2 As String = Convert.ToString(comando.ExecuteScalar)
            If contraseña2 = contraseña Then
                Me.Hide()
                Form2.Show()
            Else
                MessageBox.Show("Contraseña incorrecta")
            End If
            connection.Close()
        End Using

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Activa el evento Click del botón
            Button1.PerformClick()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.UseSystemPasswordChar = True
        TextBox1.PasswordChar = "*"

    End Sub
End Class
