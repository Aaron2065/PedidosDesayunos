using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    internal class MetodoDatos
    {
        // Metodo que nos regresa informacion en un DataSet
        public static DataSet ExecuteDataSet(String sp, params object[] parametros)
        {
            DataSet ds = new DataSet();

            // Obtener la cadena de coexion
            string cadenaConexion = Conexion.ObtenerConexion;

            //Crear la conexion
            SqlConnection conn = new SqlConnection(cadenaConexion);

            try
            {
                // Crear el SqlCommand
                SqlCommand cmd = new SqlCommand(sp, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;

                // Valida que los parámetros están completos (en pares)
                if (parametros != null && parametros.Length % 2 != 0)
                {
                    throw new ApplicationException("Los parametros deben venir en pares");
                }
                else
                {
                    // Se asigna los parámetros al command
                    for (int i = 0; i < parametros.Length; i = i + 2)
                    {
                        cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                    }

                    // Se abre la conexion
                    conn.Open();

                    // Se ejecta el comando
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    // Se llama el dataset
                    adapter.Fill(ds);

                    // Se cierra lla conexion
                    conn.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error ejecutando ExecuteDataSet: " + ex.Message, ex);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        // Metodo para insertar, actualizar y eliminar
        public static int ExecuteNonQuey(String sp, params object[] parametros)
        {
            int exitoso = 0;

            // Obtener la cadena de coexion
            string cadenaConexion = Conexion.ObtenerConexion;

            //Crear la conexion
            SqlConnection conn = new SqlConnection(cadenaConexion);

            try
            {
                // Crear el SqlCommand
                SqlCommand cmd = new SqlCommand(sp, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;

                // Valida que los parámetros están completos (en pares)
                if (parametros != null && parametros.Length % 2 != 0)
                {
                    throw new ApplicationException("Los parametros deben venir en pares");
                }
                else
                {
                    // Se asigna los parámetros al command
                    for (int i = 0; i < parametros.Length; i = i + 2)
                    {
                        cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                    }

                    // Se abre la conexion
                    conn.Open();

                    cmd.ExecuteNonQuery();
                    exitoso = 1;

                    // Se cierra la conexion
                    conn.Close();
                }
                return exitoso;
            }
            catch (Exception ex)
            {
                return exitoso;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        // Metodo que ejecuta un escalar
        public static int ExecuteEscalar(string sp, params object[] parametros)
        {
            int id = 0;

            //Traer la cadena de conexión
            string cadenaConexion = Conexion.ObtenerConexion;

            //Crear la conexion
            SqlConnection conn = new SqlConnection(cadenaConexion);

            try
            {
                //Crear el SqlCommand
                SqlCommand cmd = new SqlCommand(sp, conn);

                //Se selecciona el tipo de comando y el se le envía el nombre del storedProocedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = sp;

                //Agregan los parámetros
                for (int i = 0; i < parametros.Length; i = i + 2)
                {
                    cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                }

                //Abrir la conexion
                conn.Open();

                //Ejecutar el stored procedure
                id = int.Parse(cmd.ExecuteScalar().ToString());

                //Cerrar la conexion
                conn.Close();

                return id;
            }
            catch (Exception ex)
            {
                return id;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
