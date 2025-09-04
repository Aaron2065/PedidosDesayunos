using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDatos
{
    public class DalProducto
    {
        // Listar todos los productos
        public static List<ProductoVO> GetListaProductos()
        {
            try
            {
                DataSet ds = MetodoDatos.ExecuteDataSet("Productos_Listar");
                List<ProductoVO> lista = new List<ProductoVO>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lista.Add(new ProductoVO(dr));
                }

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetListaProductos: {ex.Message}");
                throw;
            }
        }

        // Obtener producto por ID
        public static ProductoVO GetProductoByID(int id)
        {
            try
            {
                DataSet ds = MetodoDatos.ExecuteDataSet("Productos_GetByID", "@ProductoID", id);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return new ProductoVO(ds.Tables[0].Rows[0]);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetProductoByID: {ex.Message}");
                throw;
            }
        }

        // Insertar producto
        public static int InsertarProducto(int categoriaID, string nombre, string descripcion, decimal precio, string imagenUrl, bool disponible)
        {
            return MetodoDatos.ExecuteNonQuey("Productos_Insertar",
                "@CategoriaID", categoriaID,
                "@Nombre", nombre,
                "@Descripcion", descripcion,
                "@Precio", precio,
                "@ImagenUrl", imagenUrl,
                "@Disponible", disponible);
        }

        // Actualizar producto
        public static int ActualizarProducto(int productoID, int categoriaID, string nombre, string descripcion, decimal precio, string imagenUrl, bool disponible)
        {
            return MetodoDatos.ExecuteNonQuey("Productos_Actualizar",
                "@ProductoID", productoID,
                "@CategoriaID", categoriaID,
                "@Nombre", nombre,
                "@Descripcion", descripcion,
                "@Precio", precio,
                "@ImagenUrl", imagenUrl,
                "@Disponible", disponible);
        }

        // Eliminar producto
        public static int EliminarProducto(int productoID)
        {
            return MetodoDatos.ExecuteNonQuey("Productos_Eliminar", "@ProductoID", productoID);
        }
    }
}
