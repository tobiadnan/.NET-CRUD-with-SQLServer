Imports System.Data
Imports System.Data.SqlClient


Namespace Conection
    Public Class Config

        ' alamat server database
        Dim CallServer As New SqlConnection("Data Source=TOBYADNAN\SQLEXPRESS;Initial Catalog=DbPerpus;Integrated Security=True")

        'koneksi vb to database
        Public Function con() As SqlConnection
            With CallServer
                If .State <> ConnectionState.Open Then .Open()

            End With
            Return CallServer
        End Function

        Public Sub UnCon()
            CallServer.Close()

        End Sub
    End Class
End Namespace

