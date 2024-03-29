﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Servicio_de_Gestión_de_Compra
{
    public class Registro
    {
        /// <summary>
        /// Escribe un mensaje en el registro.
        /// </summary>
        /// <param name="tipo">Tipo de registro: los que haya en el .sql en la restricción ck_registro_tipo.</param>
        /// <param name="usuario">Nombre de usuario que llevó a cabo la operación. Puede ser vacío si la operación era de "acceso".</param>
        /// <param name="descripcion">Descripción del mensaje.</param>
        public static void WriteLine(String tipo, String usuario, String descripcion)
        {
            DebugCutre.WriteLine(descripcion);
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["bd"].ConnectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "insert into registro (fecha, tipo, usuario, descripcion) " +
                    "values (@fecha, @tipo, @usuario, @descripcion); ";

                command.Parameters.AddWithValue("@fecha", DateTime.Now);
                command.Parameters.AddWithValue("@tipo", tipo);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                DebugCutre.WriteLine(e.Message);
                DebugCutre.WriteLine(e.StackTrace);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
    }
}