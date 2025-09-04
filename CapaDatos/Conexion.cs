using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    internal class Conexion
    {
        private static readonly string _cadenaConexion = @"Data Source =
            PC;Initial Catalog=PedidosDesayunos; Integrated Security=True";

        public static string ObtenerConexion
        {
            get
            {
                return _cadenaConexion;
            }
        }
    }
}
