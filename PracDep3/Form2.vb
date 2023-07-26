Imports MySql.Data.MySqlClient
Public Class Form2

    Private Sub Menu_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.WindowState = 2
        Label2.Text = Date.Now.ToShortDateString
    End Sub

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Timer1.Enabled = True
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Environment.Exit(0)
    End Sub

    Private Sub POSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles POSToolStripMenuItem.Click
        Form3.Show()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub

    Private Sub ACercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ACercaDeToolStripMenuItem.Click
        MessageBox.Show("Version Beta" & vbNewLine & "Solano Waldo Hector Manuel", "Mensaje", MessageBoxButtons.OK)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Label1.Text = DateTime.Now.ToShortTimeString
    End Sub

    Private Sub ReportesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportesToolStripMenuItem.Click
        Form4.Show()
    End Sub


    Private Sub AltaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AltaToolStripMenuItem.Click
        Form5.Show()
    End Sub

    Private Sub FileSystemWatcher1_Changed(sender As Object, e As IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed

    End Sub

    Private Sub AltaBajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AltaBajaToolStripMenuItem.Click
        Form7.Show()
    End Sub
End Class