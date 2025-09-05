using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaNegocio
{
    public class BllPedido
    {
        // Listar todos los pedidos
        public static List<PedidoVO> GetListaPedidos()
        {
            return DalPedido.GetListaPedidos();
        }

        // Insertar un nuevo pedido
        public static int InsPedido(int clienteID, string notas)
        {
            try
            {
                return DalPedido.InsertarPedido(clienteID, notas);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al insertar pedido: {ex.Message}");
            }
        }

        // Actualizar un pedido
        public static void UpdPedido(int pedidoID, int clienteID, bool estado, string notas)
        {
            try
            {
                DalPedido.ActualizarPedido(pedidoID, clienteID, estado, notas);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al actualizar pedido: {ex.Message}");
            }
        }

        // Eliminar un pedido
        public static string DelPedido(int pedidoID)
        {
            try
            {
                DalPedido.EliminarPedido(pedidoID);
                return "1"; // Eliminación exitosa
            }
            catch
            {
                return "0"; // No se pudo eliminar
            }
        }

        // Obtener pedido por ID
        public static PedidoVO GetPedidoByID(int pedidoID)
        {
            return DalPedido.GetPedidoByID(pedidoID);
        }
    }
}
