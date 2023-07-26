Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Form8

    Private Sub Form8_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Button1.Text = "Eliminar"
        Button2.Text = "Salir"
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connection As New SqlConnection("Data Source=DESKTOP-AB232H7;Initial Catalog=laundry;Integrated Security=True")
        If ListBox1.SelectedIndex <> -1 Then
            Dim Sel As String = ListBox1.SelectedItem.ToString()
            Dim query As String = "DELETE FROM empleados WHERE nombre = @empleado"
            Using comando As New SqlCommand(query, connection)
                comando.Parameters.AddWithValue("@empleado", Sel)
                connection.Open()
                comando.ExecuteNonQuery()
            End Using
        Else
            MessageBox.Show("No se selecciono niguno")
        End If
        connection.Close()
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
End Class