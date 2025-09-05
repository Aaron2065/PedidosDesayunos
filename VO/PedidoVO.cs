using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class PedidoVO
    {

        private int _pedidoID;
        private int _clienteID;
        private string _clienteNombre;
        private DateTime _fechaPedido;
        private decimal _total;
        private bool _estado;
        private string _notas;

        public int PedidoID 
        { 
            get => _pedidoID; 
            set => _pedidoID = value; 
        }
        public int ClienteID 
        { 
            get => _clienteID; 
            set => _clienteID = value; 
        }
        public string ClienteNombre 
        { 
            get => _clienteNombre; 
            set => _clienteNombre = value; 
        }
        public DateTime FechaPedido 
        { 
            get => _fechaPedido; 
            set => _fechaPedido = value; 
        }
        public decimal Total 
        { 
            get => _total; 
            set => _total = value; 
        }
        public bool Estado 
        { 
            get => _estado; 
            set => _estado = value; 
        }
        public string Notas 
        { 
            get => _notas; 
            set => _notas = value; 
        }

        public PedidoVO()
        {
            PedidoID = 0;
            ClienteID = 0;
            ClienteNombre = string.Empty;
            FechaPedido = DateTime.Now;
            Total = 0;
            Estado = true;
            Notas = string.Empty;
        }

        public PedidoVO(DataRow dr)
        {
            PedidoID = Convert.ToInt32(dr["PedidoID"]);
            ClienteID = Convert.ToInt32(dr["ClienteID"]);
            ClienteNombre = dr.Table.Columns.Contains("Cliente") ? dr["Cliente"].ToString() : string.Empty;
            FechaPedido = Convert.ToDateTime(dr["FechaPedido"]);
            Total = Convert.ToDecimal(dr["Total"]);
            Estado = Convert.ToBoolean(dr["Estado"]);
            Notas = dr["Notas"].ToString();
        }
    }
}
