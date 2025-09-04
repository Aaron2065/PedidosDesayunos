using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class ClienteVO
    {
        // Atributos
        private int _clienteID;
        private string _nombreCompleto;
        private string _telefono;
        private DateTime _fechaRegistro;

        // Propiedades
        public int ClienteID
        {
            get => _clienteID;
            set => _clienteID = value;
        }

        public string NombreCompleto
        {
            get => _nombreCompleto;
            set => _nombreCompleto = value;
        }

        public string Telefono
        {
            get => _telefono;
            set => _telefono = value;
        }

        public DateTime FechaRegistro
        {
            get => _fechaRegistro;
            set => _fechaRegistro = value;
        }

        // Contructor
        public ClienteVO()
        {
            ClienteID = 0;
            NombreCompleto = string.Empty;
            Telefono = string.Empty;
            FechaRegistro = DateTime.Now;
        }

        public ClienteVO(DataRow dr)
        {
            ClienteID = int.Parse(dr["ClienteID"].ToString());
            NombreCompleto = dr["NombreCompleto"].ToString();
            Telefono = dr["Telefono"].ToString();
            FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
        }
    }
}
