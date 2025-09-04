using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaNegocio
{
    public class BllCliente
    {
        // Listar todos los clientes
        public static List<ClienteVO> GetListClientes()
        {
            return DalCliente.GetListaClientes();
        }

        // Insertar un nuevo cliente
        public static void InsCliente(string nombreCompleto, string telefono, DateTime fechaRegistro)
        {
            try
            {
                DalCliente.InsertarCliente(nombreCompleto, telefono, fechaRegistro);
            }
            catch (Exception ex) 
            {
                throw new ApplicationException($"Error al insertar categoría: {ex.Message}");
            }
        }

        // Actualizar un cliente existente
        public static void UpdCliente(int clienteID, string nombreCompleto, string telefono, DateTime fechaRegistro)
        {
            try
            {
                DalCliente.ActualizarCliente(clienteID, nombreCompleto, telefono, fechaRegistro);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al actualizar cliente: {ex.Message}");
            }
        }

        // Eliminar un cliente
        public static string DelCliente(int clienteID)
        {
            ClienteVO cliente = DalCliente.GetClienteByID(clienteID);
            
            if (cliente != null)
            {
                DalCliente.EliminarCliente(clienteID);
                return "1";
            }
            else
            {
                return "0";
            }
        }

        // Obtener una categoría por ID
        public static ClienteVO GetClienteByID(int categoriaID)
        {
            return DalCliente.GetClienteByID(categoriaID);
        }
    }
}
