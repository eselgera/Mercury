Imports MySql.Data.MySqlClient

Module Biblioteca
    'Creamos la conexion a la BBDD
    Public Conexion As New MySqlConnection

    'Creamos el procedimiento para llamar a la consulta
    Public Sub Conectar()
        Try
            'Cerramos la conexion a la BBDD
            Conexion.Close()

            'Establecemos los parametros de la conexion a la BBDD
            Conexion.ConnectionString = "Server=b8hrt3nyyisdb1zuqz9i-mysql.services.clever-cloud.com;Port=3306;Database=b8hrt3nyyisdb1zuqz9i;User ID=ufy3iskn6mnef5us;Password=zdaakkP7DXXiVmu7X411"


            'Abrimos la conexion a la BBDD
            Conexion.Open()

            'Imprimimos un mensaje como que se ha conectado satisfactoriamente a la BBDD MySQL
            'MessageBox.Show("Conexion a la BBDD MySQL realizada")

        Catch ex As Exception
            'En caso de que no se conecte mandamos un mensaje con el error lanzado desde la BBDD MySQL
            MsgBox(ex.Message)
        End Try
    End Sub

    'Creamos un procedimiento que sea la funcion que seleccionará los datos de la BBDD (SELECT)
    Public Function Seleccion_de_datos(ByRef SQL As String) As DataSet
        'Llamamos al procedimiento Conectar() para conectarnos a la BBDD MySQL
        Conectar()

        'Declaramos las cariables que nos van a hacer falta
        Dim Adaptador As New MySqlDataAdapter(SQL, Conexion)
        Dim Rsdatos As New DataSet

        'Adaptador va a rellenar la variable Rsdatos con "DATOS"
        Adaptador.Fill(Rsdatos, "DATOS")

        'Devolvemos los datos que saquemos
        Return Rsdatos

        'Cerramos la conexion a la BBDD MySQL
        Conexion.Close()

    End Function

    Public Function Ejecutar_Query(ByRef SQL As String) As DataSet
        Conectar()

        Dim cmd = New MySqlCommand(SQL, Conexion)
        cmd.ExecuteNonQuery()
        Conexion.Close()

    End Function
End Module
