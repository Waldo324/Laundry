Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Form7

    Private Sub Form7_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Label1.Text = "Nombre"
        Label2.Text = "Contraseña"
        Button1.Text = "Agregar"
        Button2.Text = "Eliminar"
        Button3.Text = "Salir"
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form8.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connections As String = ("Data Source=DESKTOP-AB232H7;Initial Catalog=laundry;Integrated Security=True")
        Try

            Dim valor1 As String = TextBox1.Text
            Dim valor2 As String = TextBox2.Text

            If String.IsNullOrEmpty(valor1) Then
                MessageBox.Show("Por favor, ingrese un valor en TextBox1.")
                Return
            End If

            Dim query As String = "INSERT INTO empleados (nombre, contraseña) VALUES (@Valor1, @Valor2)"

            Using connection As New SqlConnection(connections)
                Using Command As New SqlCommand(query, connection)
                    Command.Parameters.AddWithValue("@valor1", valor1)
                    Command.Parameters.AddWithValue("@valor2", valor2)

                    connection.Open()

                    Command.ExecuteNonQuery()
                End Using
            End Using
            TextBox1.Clear()
            TextBox2.Clear()

            MessageBox.Show("Insercion Exitosa")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.UseSystemPasswordChar = True
        TextBox2.PasswordChar = "*"
    End Sub
End Class