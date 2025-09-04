using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class CategoriaVO
    {
        // Atributos
        private int _categoriaID;
        private string _nombre;
        private string _descripcion;
        private DateTime _fechaRegistro;
        private bool _activo;


        // Propiedades
        public int CategoriaID
        {
            get => _categoriaID;
            set => _categoriaID = value;
        }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public string Descripcion
        {
            get => _descripcion;
            set => _descripcion = value;
        }

        public DateTime FechaRegistro
        {
            get => _fechaRegistro;
            set => _fechaRegistro = value;
        }

        public bool Activo
        {
            get => _activo;
            set => _activo = value;
        }

        // Constructores
        public CategoriaVO(DataRow dr)
        {
            CategoriaID = int.Parse(dr["CategoriaID"].ToString());
            Nombre = dr["Nombre"].ToString();
            Descripcion = dr["Descripcion"].ToString();
            FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());
            Activo = bool.Parse(dr["Activo"].ToString());
        }

        public CategoriaVO()
        {
            CategoriaID = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            FechaRegistro = DateTime.Parse("1900-01-01");
            Activo = false;
        }
    }
}
