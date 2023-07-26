Imports Microsoft.Office.Interop
Imports System.Data.SqlClient

Public Class Form4

    Private Sub Form4_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Label1.Text = "Fecha Inicio"
        Label2.Text = "Fecha Final"
        Button1.Text = "Generar"
        Button2.Text = "Salir"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Public Class Venta
        Public Property IdVenta As Integer
        Public Property Fecha As DateTime
        Public Property Total As Decimal
    End Class

    Public Class Producto
        Public Property Nombre As String
        Public Property Precio As Decimal
    End Class

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fechai As String = DateTimePicker1.Value.ToString("yyyy/MM/dd")
        Dim fechaf As String = DateTimePicker2.Value.ToString("yyyy/MM/dd")

        Dim ventas As List(Of Venta) = ObtenerVentasEnRango(fechai, fechaf)

        ' Crear un nuevo archivo de Excel
        Dim excelApp As New Excel.Application()
        Dim excelWorkbook As Excel.Workbook = excelApp.Workbooks.Add()
        Dim excelWorksheet As Excel.Worksheet = excelWorkbook.ActiveSheet


        ' Escribir encabezados
        excelWorksheet.Cells(1, 1).Value = "Nombre del Producto"
        excelWorksheet.Cells(1, 2).Value = "Precio"

        ' Escribir datos de ventas
        Dim row As Integer = 2
        For Each venta As Venta In ventas
            Dim productos As List(Of Producto) = ObtenerProductosPorVenta(venta.IdVenta)
            For Each producto As Producto In productos
                excelWorksheet.Cells(row, 1).Value = producto.Nombre
                excelWorksheet.Cells(row, 2).Value = producto.Precio
                row += 1
            Next
        Next

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Archivos de Excel|*.xlsx"
        saveFileDialog.Title = "Guardar archivo de Excel"
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ' Guardar el archivo de Excel en la ubicación seleccionada
            Dim filePath As String = saveFileDialog.FileName
            excelWorkbook.SaveAs(filePath)
            excelWorkbook.Close()
            excelApp.Quit()

            MessageBox.Show("Reporte generado y guardado con éxito.")
        Else
            ' Cerrar el archivo de Excel sin guardar
            excelWorkbook.Close(False)
            excelApp.Quit()

            MessageBox.Show("Generación de reporte cancelada.")
        End If
    End Sub

    Private Function ObtenerVentasEnRango(fechaInicial As String, fechaFinal As String) As List(Of Venta)
        Dim ventas As New List(Of Venta)()
        Try
            Using connection As New SqlConnection("Data Source=DESKTOP-AB232H7;Initial Catalog=laundry;Integrated Security=True")
                connection.Open()

                Dim query As String = "SELECT idventa, fecha, total FROM venta WHERE fecha >= @fechaInicial AND fecha <= @fechaFinal"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@fechaInicial", fechaInicial)
                    command.Parameters.AddWithValue("@fechaFinal", fechaFinal)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim venta As New Venta()
                            venta.IdVenta = Convert.ToInt32(reader("idventa"))
                            venta.Fecha = Convert.ToDateTime(reader("fecha"))
                            venta.Total = Convert.ToDecimal(reader("total"))
                            ventas.Add(venta)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener las ventas: " & ex.Message)
        End Try

        Return ventas
    End Function

    Private Function ObtenerProductosPorVenta(idVenta As Integer) As List(Of Producto)
        Dim productos As New List(Of Producto)()
        Try
            Using connection As New SqlConnection("Data Source=DESKTOP-AB232H7;Initial Catalog=laundry;Integrated Security=True")
                connection.Open()
                Dim query As String = "SELECT productos.nombre, productos.precio FROM orden INNER JOIN productos ON orden.idproducto = productos.idproducto WHERE orden.idventa = @idVenta"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@idVenta", idVenta)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim producto As New Producto()
                            producto.Nombre = reader("nombre").ToString()
                            producto.Precio = Convert.ToDecimal(reader("precio"))
                            productos.Add(producto)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener los productos por venta: " & ex.Message)
        End Try

        Return productos
    End Function


End Class