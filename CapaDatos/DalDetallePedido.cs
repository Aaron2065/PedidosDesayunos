using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDatos
{
    public class DalDetallePedido
    {
        // Listar detalles de un pedido
        public static List<DetallePedidoVO> GetDetallesByPedido(int pedidoID)
        {
            DataSet ds = MetodoDatos.ExecuteDataSet("DetallePedido_ListarPorPedido",
                "@PedidoID", pedidoID);

            List<DetallePedidoVO> lista = new List<DetallePedidoVO>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lista.Add(new DetallePedidoVO(dr));
            }

            return lista;
        }

        // Insertar detalle
        public static int InsertarDetalle(int pedidoID, int productoID, int cantidad, decimal precioUnitario)
        {
            return MetodoDatos.ExecuteNonQuey("DetallePedido_Insertar",
                "@PedidoID", pedidoID,
                "@ProductoID", productoID,
                "@Cantidad", cantidad,
                "@PrecioUnitario", precioUnitario);
        }

        // Eliminar detalle
        public static int EliminarDetalle(int detalleID)
        {
            return MetodoDatos.ExecuteNonQuey("DetallePedido_Eliminar",
                "@DetalleID", detalleID);
        }
    }
}
