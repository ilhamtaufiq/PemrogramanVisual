Imports MySql.Data.MySqlClient
Public Class Form1

    ''change textbox being password char
    Private Sub InitializeMyControl()
        TextBox2.Text = ""
        TextBox2.PasswordChar = "*"
        TextBox2.MaxLength = 14
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login.Click
        Dim conn As MySqlConnection
        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost; user id=root; password=toor ; database=siswa"
        Try
            conn.Open()
        Catch ex As Exception
            MsgBox("Ada kesalahan dalam koneksi database")
        End Try
        Dim myAdapter As New MySqlDataAdapter

        Dim sqlQuery = "SELECT * FROM login_siswa WHERE username='" + TextBox1.Text + "' AND password='" + TextBox2.Text + "'"
        Dim myCommand As New MySqlCommand
        myCommand.Connection = conn
        myCommand.CommandText = sqlQuery

        myAdapter.SelectCommand = myCommand
        Dim myData As MySqlDataReader
        myData = myCommand.ExecuteReader()

        If myData.HasRows = 0 Then
            MsgBox("username dan password salah!! ",
                   MsgBoxStyle.Exclamation, "Error Login")
        Else
            MsgBox("Login berhasil, Selamat datang " & TextBox1.Text & "!", MsgBoxStyle.Information, "Successfull Login")
            Home.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class