using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    [Serializable]
    public class DetallePedidoVO
    {
        private int _detalleID;
        private int _pedidoID;
        private int _productoID;
        private string _productoNombre;
        private int _cantidad;
        private decimal _precioUnitario;
        private decimal _subtotal;

        public int DetalleID 
        { 
            get => _detalleID; 
            set => _detalleID = value; 
        }
        public int PedidoID 
        { 
            get => _pedidoID; 
            set => _pedidoID = value; 
        }
        public int ProductoID 
        { 
            get => _productoID; 
            set => _productoID = value; 
        }
        public string ProductoNombre 
        { 
            get => _productoNombre; 
            set => _productoNombre = value; 
        }
        public int Cantidad 
        { 
            get => _cantidad; 
            set => _cantidad = value; 
        }
        public decimal PrecioUnitario 
        { 
            get => _precioUnitario; 
            set => _precioUnitario = value; 
        }
        public decimal Subtotal 
        { 
            get => _subtotal; 
            set => _subtotal = value; 
        }

        public DetallePedidoVO()
        {
            DetalleID = 0;
            PedidoID = 0;
            ProductoID = 0;
            ProductoNombre = string.Empty;
            Cantidad = 0;
            PrecioUnitario = 0;
            Subtotal = 0;
        }

        public DetallePedidoVO(DataRow dr)
        {
            DetalleID = Convert.ToInt32(dr["DetalleID"]);
            PedidoID = Convert.ToInt32(dr["PedidoID"]);
            ProductoID = Convert.ToInt32(dr["ProductoID"]);
            ProductoNombre = dr.Table.Columns.Contains("Producto") ? dr["Producto"].ToString() : string.Empty;
            Cantidad = Convert.ToInt32(dr["Cantidad"]);
            PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]);
            Subtotal = Convert.ToDecimal(dr["Subtotal"]);
        }
    }
}
