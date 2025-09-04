using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDatos
{
    public class DalCliente
    {
        // Listar clientes
        public static List<ClienteVO> GetListaClientes()
        {
            try
            {
                DataSet st = MetodoDatos.ExecuteDataSet("Clientes_Listar");

                List<ClienteVO> lista = new List<ClienteVO>();

                foreach (DataRow dr in st.Tables[0].Rows)
                {
                    lista.Add(new ClienteVO(dr));
                }

                return lista;
            }
            catch (Exception ex) {
                Console.WriteLine($"Error en GetListaClientes: {ex.Message}");
                throw;
            }
        }

        // Insertar cliente
        public static int InsertarCliente(string nombreCompleto, string telefono, DateTime fechaRegistro)
        {
            return MetodoDatos.ExecuteNonQuey("Clientes_Insertar",
                "@NombreCompleto", nombreCompleto,
                "@Telefono", telefono,
                "@FechaRegistro", fechaRegistro);
        }

        // Obtener cliente por ID
        public static ClienteVO GetClienteByID(int id)
        {
            try
            {
                DataSet ds = MetodoDatos.ExecuteDataSet("Clientes_GetByID",
                    "@ClienteID", id);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return new ClienteVO(ds.Tables[0].Rows[0]);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error en GetClienteByID: {ex.Message}");
                throw;
            }
        }

        // Actualizar cliente
        public static int ActualizarCliente(int ClienteID, string nombreCompleto, string telefono, DateTime fechaRegistro)
        {
            return MetodoDatos.ExecuteNonQuey("Clientes_Actualizar",
                "@ClienteID", ClienteID,
                "@NombreCompleto", nombreCompleto,
                "@Telefono", telefono,
                "@FechaRegistro", fechaRegistro);
        }

        // Eliminar cliente
        public static int EliminarCliente(int id)
        {
            return MetodoDatos.ExecuteNonQuey("Clientes_Eliminar", "@ClienteID", id);
        }
    }
}
