using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaNegocio
{
    public class BllDetallePedido
    {
        public static List<DetallePedidoVO> GetDetallesByPedido(int pedidoID)
        {
            return DalDetallePedido.GetDetallesByPedido(pedidoID);
        }

        public static void InsertDetalle(int pedidoID, int productoID, int cantidad, decimal precioUnitario)
        {
            DalDetallePedido.InsertarDetalle(pedidoID, productoID, cantidad, precioUnitario);
        }

        public static void DeleteDetalle(int detalleID)
        {
            DalDetallePedido.EliminarDetalle(detalleID);
        }
    }
}
