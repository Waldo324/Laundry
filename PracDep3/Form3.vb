Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Form3
    Private Sub POS_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Label2.Text = Date.Now.ToShortDateString
        Button1.Text = "Jabón"
        Button2.Text = "Detergente"
        Button3.Text = "Cloro"
        Button4.Text = "Suavizante"
        Button5.Text = "Lavado"
        Button6.Text = "Secado"
        Button7.Text = "Planchado"
        Button8.Text = "Paquete"
        Button9.Text = "Cobrar"
        Button10.Text = "Eliminar"
        Button11.Text = "Limpiar"
        Label4.Text = "Total"
        Label3.Text = "00.00"
        Label5.Text = "Ingresa Efectivo"
        'Dim item As New ListViewItem
        'item.SubItems(0).Text = "Dato de la columna 1"
        'item.SubItems(1).Text = "Dato de la columna 2"
        'Venta.Items.Add(item)


    End Sub

    Private Sub RegresarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegresarToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub POS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Timer1.Enabled = True


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Label1.Text = DateTime.Now.ToShortTimeString
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connection As New SqlConnection("Data Source=DESKTOP-AB232H7;Initial Catalog=laundry;Integrated Security=True")
        Dim nombre As String = "Jabon"
        Dim query As String = "SELECT nombre, PRECIO FROM productos WHERE nombre = @nombre"
        Using comando As New SqlCommand(query, connection)
            connection.Open()
            comando.Parameters.AddWithValue("@nombre", nombre)
            Using reader As SqlDataReader = comando.ExecuteReader()
                If reader.Read() Then
                    Dim prod As String = reader("nombre").ToString()
                    Dim precio As Decimal = Decimal.Parse(reader("PRECIO").ToString())
                    Dim lista As New ListViewItem(prod)
                    lista.SubItems.Add(precio.ToString())
                    ListView1.Items.Add(lista)
                End If
            End Using
            connection.Close()
        End Using
        Dim suma As Decimal = 0
        If Not suma Then
            For Each item As ListViewItem In ListView1.Items
                Dim precio As Decimal
                If Decimal.TryParse(item.SubItems(1).Text, precio) Then
                    suma = suma + precio
                End If
            Next
            Label3.Text = suma.ToString()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim connection As New SqlConnection("Data Source=DESKTOP-AB232H7;Initial Catalog=laundry;Integrated Security=True")
        Dim nombre As String = "Detergente"
        Dim query As String = "SELECT nombre, PRECIO FROM productos WHERE nombre = @nombre"
        Using comando As New SqlCommand(query, connection)
            connection.Open()
            comando.Parameters.AddWithValue("@nombre", nombre)
            Using reader As SqlDataReader = comando.ExecuteReader()
                If reader.Read() Then
                    Dim prod As String = reader("nombre").ToString()
                    Dim precio As Decimal = Decimal.Parse(reader("PRECIO").ToString())
                    Dim lista As New ListViewItem(prod)
                    lista.SubItems.Add(precio.ToString())
                    ListView1.Items.Add(lista)

                End If
            End Using
            connection.Close()
        End Using
        Dim suma As Decimal = 0
        If Not suma Then
            For Each item As ListViewItem In ListView1.Items
                Dim precio As Decimal
                If Decimal.TryParse(item.SubItems(1).Text, precio) Then
                    suma = suma + precio
                End If
            Next
            Label3.Text = suma.ToString()
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim connection As New SqlConnection("Data Source=DESKTOP-AB232H7;Initial Catalog=laundry;Integrated Security=True")
        Dim nombre As String = "Cloro"
        Dim query As String = "SELECT nombre, PRECIO FROM productos WHERE nombre = @nombre"
        Using comando As New SqlCommand(query, connection)
            connection.Open()
            comando.Parameters.AddWithValue("@nombre", nombre)
            Using reader As SqlDataReader = comando.ExecuteReader()
                If reader.Read() Then
                    Dim prod As String = reader("nombre").ToString()
                    Dim precio As Decimal = Decimal.Parse(reader("PRECIO").ToString())
                    Dim lista As New ListViewItem(prod)
                    lista.SubItems.Add(precio.ToString())
                    ListView1.Items.Add(lista)
                End If
            End Using
            connection.Close()
        End Using
        Dim suma As Decimal = 0
        If Not suma Then
            For Each item As ListViewItem In ListView1.Items
                Dim precio As Decimal
                If Decimal.TryParse(item.SubItems(1).Text, precio) Then
                    suma = suma + precio
                End If
            Next
            Label3.Text = suma.ToString()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim connection As New SqlConnection("Data Source=DESKTOP-AB232H7;Initial Catalog=laundry;Integrated Security=True")
        Dim nombre As String = "Suavizante"
        Dim query As String = "SELECT nombre, PRECIO FROM productos WHERE nombre = @nombre"
        Using comando As New SqlCommand(query, connection)
            connection.Open()
            comando.Parameters.AddWithValue("@nombre", nombre)
            Using reader As SqlDataReader = comando.ExecuteReader()
                If reader.Read() Then
                    Dim prod As String = reader("nombre").ToString()
                    Dim precio As Decimal = Decimal.Parse(reader("PRECIO").ToString())
                    Dim lista As New ListViewItem(prod)
                    lista.SubItems.Add(precio.ToString())
                    ListView1.Items.Add(lista)
                End If
            End Using
            connection.Close()

        End Using
        Dim suma As Decimal = 0
        If Not suma Then
            For Each item As ListViewItem In ListView1.Items
                Dim precio As Decimal
                If Decimal.TryParse(item.SubItems(1).Text, precio) Then
                    suma = suma + precio
                End If
            Next
            Label3.Text = suma.ToString()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim connection As New SqlConnection("Data Source=DESKTOP-AB232H7;Initial Catalog=laundry;Integrated Security=True")
        Dim nombre As String = "Lavado"
        Dim query As String = "SELECT nombre, PRECIO FROM productos WHERE nombre = @nombre"
        Using comando As New SqlCommand(query, connection)
            connection.Open()
            comando.Parameters.AddWithValue("@nombre", nombre)
            Using reader As SqlDataReader = comando.ExecuteReader()
                If reader.Read() Then
                    Dim prod As String = reader("nombre").ToString()
                    Dim precio As Decimal = Decimal.Parse(reader("PRECIO").ToString())
                    Dim lista As New ListViewItem(prod)
                    lista.SubItems.Add(precio.ToString())
                    ListView1.Items.Add(lista)
                End If
            End Using
            connection.Close()
        End Using
        Dim suma As Decimal = 0
        If Not suma Then
            For Each item As ListViewItem In ListView1.Items
                Dim precio As Decimal
                If Decimal.TryParse(item.SubItems(1).Text, precio) Then
                    suma = suma + precio
                End If
            Next
            Label3.Text = suma.ToString()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim connection As New SqlConnection("Data Source=DESKTOP-AB232H7;Initial Catalog=laundry;Integrated Security=True")
        Dim nombre As String = "Secado"
        Dim query As String = "SELECT nombre, PRECIO FROM productos WHERE nombre = @nombre"
        Using comando As New SqlCommand(query, connection)
            connection.Open()
            comando.Parameters.AddWithValue("@nombre", nombre)
            Using reader As SqlDataReader = comando.ExecuteReader()
                If reader.Read() Then
                    Dim prod As String = reader("nombre").ToString()
                    Dim precio As Decimal = Decimal.Parse(reader("PRECIO").ToString())
                    Dim lista As New ListViewItem(prod)
                    lista.SubItems.Add(precio.ToString())
                    ListView1.Items.Add(lista)
                End If
            End Using
            connection.Close()
        End Using
        Dim suma As Decimal = 0
        If Not suma Then
            For Each item As ListViewItem In ListView1.Items
                Dim precio As Decimal
                If Decimal.TryParse(item.SubItems(1).Text, precio) Then
                    suma = suma + precio
                End If
            Next
            Label3.Text = suma.ToString()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim connection As New SqlConnection("Data Source=DESKTOP-AB232H7;Initial Catalog=laundry;Integrated Security=True")
        Dim nombre As String = "Planchado"
        Dim query As String = "SELECT nombre, PRECIO FROM productos WHERE nombre = @nombre"
        Using comando As New SqlCommand(query, connection)
            connection.Open()
            comando.Parameters.AddWithValue("@nombre", nombre)
            Using reader As SqlDataReader = comando.ExecuteReader()
                If reader.Read() Then
                    Dim prod As String = reader("nombre").ToString()
                    Dim precio As Decimal = Decimal.Parse(reader("PRECIO").ToString())
                    Dim lista As New ListViewItem(prod)
                    lista.SubItems.Add(precio.ToString())
                    ListView1.Items.Add(lista)
                End If
            End Using
            connection.Close()
        End Using
        Dim suma As Decimal = 0
        If Not suma Then
            For Each item As ListViewItem In ListView1.Items
                Dim precio As Decimal
                If Decimal.TryParse(item.SubItems(1).Text, precio) Then
                    suma = suma + precio
                End If
            Next
            Label3.Text = suma.ToString()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim connection As New SqlConnection("Data Source=DESKTOP-AB232H7;Initial Catalog=laundry;Integrated Security=True")
        Dim nombre As String = "Paquete"
        Dim query As String = "SELECT nombre, PRECIO FROM productos WHERE nombre = @nombre"
        Using comando As New SqlCommand(query, connection)
            connection.Open()
            comando.Parameters.AddWithValue("@nombre", nombre)
            Using reader As SqlDataReader = comando.ExecuteReader()
                If reader.Read() Then
                    Dim prod As String = reader("nombre").ToString()
                    Dim precio As Decimal = Decimal.Parse(reader("PRECIO").ToString())
                    Dim lista As New ListViewItem(prod)
                    lista.SubItems.Add(precio.ToString())
                    ListView1.Items.Add(lista)
                End If
            End Using
            connection.Close()
        End Using
        Dim suma As Decimal = 0
        If Not suma Then
            For Each item As ListViewItem In ListView1.Items
                Dim precio As Decimal
                If Decimal.TryParse(item.SubItems(1).Text, precio) Then
                    suma = suma + precio
                End If
            Next
            Label3.Text = suma.ToString()
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim suma As Decimal = 0
        If Not suma Then
            For Each item As ListViewItem In ListView1.Items
                Dim precio As Decimal
                If Decimal.TryParse(item.SubItems(1).Text, precio) Then
                    suma = suma + precio
                End If
            Next
            Label3.Text = suma.ToString()
        End If
        If ListView1.SelectedItems.Count > 0 Then
            Dim itSelec As ListViewItem = ListView1.SelectedItems(0)
            Dim cantSelec As Decimal
            If Decimal.TryParse(itSelec.SubItems(1).Text, cantSelec) Then
                suma -= cantSelec
                Label3.Text = suma.ToString()
            End If

            ' Remover el item seleccionado de ListView1
            itSelec.Remove()
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim suma As Decimal = 0
        ListView1.Items.Clear()
        Label3.Text = suma.ToString
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim suma As Decimal = 0
        If Not suma Then
            For Each item As ListViewItem In ListView1.Items
                Dim precio As Decimal
                If Decimal.TryParse(item.SubItems(1).Text, precio) Then
                    suma = suma + precio
                End If
            Next
            Label3.Text = suma.ToString()
        End If
        Dim efectivo As Decimal
        If Decimal.TryParse(TextBox1.Text, efectivo) AndAlso efectivo >= suma Then
            ' Continuar con el resto del código

            Dim fechaActual As DateTime = DateTime.Now
            Dim connection As New SqlConnection("Data Source=DESKTOP-AB232H7;Initial Catalog=laundry;Integrated Security=True")
            connection.Open()
            Dim fechaVenta As String = fechaActual.ToString("yyyy/MM/dd")
            Dim totalVenta As Decimal = suma
            Dim ventaQuery As String = "INSERT INTO venta (fecha, total) VALUES (@fecha, @total); DECLARE @idventa INT; SELECT SCOPE_IDENTITY();"
            Using ventaCommand As New SqlCommand(ventaQuery, connection)
                ventaCommand.Parameters.AddWithValue("@fecha", fechaVenta)
                ventaCommand.Parameters.AddWithValue("@total", totalVenta)
                Dim idVenta As Integer = Convert.ToInt32(ventaCommand.ExecuteScalar())
                ' INSERT INTO orden (idventa, idproducto) VALUES (@idVenta, 1);
                ' INSERT INTO orden (idventa, idproducto) VALUES (@idVenta, 2);
                Dim ordenQuery As String = "INSERT INTO orden (idventa, idproducto) VALUES (@idVenta, @idProducto);"
                Using ordenCommand As New SqlCommand(ordenQuery, connection)
                    For Each item As ListViewItem In ListView1.Items
                        Dim nombreProducto As String = item.SubItems(0).Text ' Suponiendo que el nombre del producto está en la primera columna

                        ' Realizamos la búsqueda del ID del producto en base al nombre
                        Dim idProducto As Integer
                        Using idProductoCommand As New SqlCommand("SELECT idproducto FROM productos WHERE nombre = @nombre", connection)
                            idProductoCommand.Parameters.AddWithValue("@nombre", nombreProducto)

                            Dim result As Object = idProductoCommand.ExecuteScalar()
                            If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                                idProducto = Convert.ToInt32(result)

                                ' Insertamos en la tabla "orden" utilizando el ID de venta y el ID del producto
                                ordenCommand.Parameters.Clear()
                                ordenCommand.Parameters.AddWithValue("@idVenta", idVenta)
                                ordenCommand.Parameters.AddWithValue("@idProducto", idProducto)
                                ordenCommand.ExecuteNonQuery()
                            End If
                        End Using
                    Next
                End Using
            End Using
            Dim cambio As Decimal = efectivo - suma
            MessageBox.Show("El cambio es de " & cambio)
        Else
            ' El efectivo ingresado es menor a la suma. Mostrar un mensaje de error.
            MessageBox.Show("El efectivo ingresado es menor a la suma total. Intente nuevamente.", "Error")
        End If
        suma = 0
        ListView1.Items.Clear()
        Label3.Text = suma.ToString
    End Sub


End Class