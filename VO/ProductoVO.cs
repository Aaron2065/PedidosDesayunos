using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class ProductoVO
    {
        // Atributos
        private int _productoID;
        private int _categoriaID;
        public string _categoriaNombre;
        private string _nombre;
        private string _descripcion;
        private decimal _precio;
        private string _imagenUrl;
        private bool _disponible;
        private DateTime _fechaRegistro;

        // Propiedades
        public int ProductoID 
        {
            get => _productoID; 
            set => _productoID = value; 
        }
        public int CategoriaID 
        { 
            get => _categoriaID; 
            set => _categoriaID = value; 
        }

        public string CategoriaNombre
        {
            get => _categoriaNombre;
            set => _categoriaNombre = value;
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
        public decimal Precio 
        { 
            get => _precio; 
            set => _precio = value; 
        }
        public string ImagenUrl 
        { 
            get => _imagenUrl; 
            set => _imagenUrl = value; 
        }
        public bool Disponible 
        { 
            get => _disponible; 
            set => _disponible = value; 
        }
        public DateTime FechaRegistro 
        { 
            get => _fechaRegistro; 
            set => _fechaRegistro = value; 
        }

        // Constructores
        public ProductoVO()
        {
            ProductoID = 0;
            CategoriaID = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Precio = 0;
            ImagenUrl = string.Empty;
            Disponible = true;
            FechaRegistro = DateTime.Now;
        }

        public ProductoVO(DataRow dr, bool incluirNombreCategoria = false)
        {
            ProductoID = int.Parse(dr["ProductoID"].ToString());
            CategoriaID = int.Parse(dr["CategoriaID"].ToString());
            Nombre = dr["Nombre"].ToString();
            Descripcion = dr["Descripcion"].ToString();
            Precio = decimal.Parse(dr["Precio"].ToString());
            ImagenUrl = dr["ImagenUrl"].ToString();
            Disponible = bool.Parse(dr["Disponible"].ToString());
            FechaRegistro = DateTime.Parse(dr["FechaRegistro"].ToString());


            if (incluirNombreCategoria && dr.Table.Columns.Contains("CategoriaNombre"))
                CategoriaNombre = dr["CategoriaNombre"].ToString();
            else
                CategoriaNombre = "";
        }
    }
}
