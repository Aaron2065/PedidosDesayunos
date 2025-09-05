using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDatos
{
    public class DalPedido
    {
        // Listar pedidos
        public static List<PedidoVO> GetListaPedidos()
        {
            DataSet ds = MetodoDatos.ExecuteDataSet("Pedidos_Listar");
            List<PedidoVO> lista = new List<PedidoVO>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lista.Add(new PedidoVO(dr));
            }

            return lista;
        }

        // Insertar pedido (solo cliente y notas, porque así está el SP)
        public static int InsertarPedido(int clienteID, string notas)
        {
            DataSet ds = MetodoDatos.ExecuteDataSet("Pedidos_Insertar",
                "@ClienteID", clienteID,
                "@Notas", notas);

            return Convert.ToInt32(ds.Tables[0].Rows[0]["NuevoPedidoID"]);
        }

        // Actualizar pedido
        public static int ActualizarPedido(int pedidoID, int clienteID, bool estado, string notas)
        {
            return MetodoDatos.ExecuteNonQuey("Pedidos_Actualizar",
                "@PedidoID", pedidoID,
                "@ClienteID", clienteID,
                "@Estado", estado,
                "@Notas", notas);
        }

        // Eliminar pedido
        public static int EliminarPedido(int pedidoID)
        {
            return MetodoDatos.ExecuteNonQuey("Pedidos_Eliminar",
                "@PedidoID", pedidoID);
        }

        // Obtener pedido por ID
        public static PedidoVO GetPedidoByID(int pedidoID)
        {
            DataSet ds = MetodoDatos.ExecuteDataSet("Pedidos_GetByID",
                "@PedidoID", pedidoID);

            if (ds.Tables[0].Rows.Count == 0) return null;

            return new PedidoVO(ds.Tables[0].Rows[0]);
        }
    }
}
