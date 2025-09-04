using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaNegocio
{
    public class BllProducto
    {
        public static List<ProductoVO> GetListaProductos()
        {
            try
            {
                return DalProducto.GetListaProductos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de productos: " + ex.Message);
            }
        }

        // Obtener producto por ID
        public static ProductoVO GetProductoByID(int productoID)
        {
            try
            {
                return DalProducto.GetProductoByID(productoID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el producto: " + ex.Message);
            }
        }

        // Insertar producto
        public static void InsProducto(int categoriaID, string nombre, string descripcion, decimal precio, string urlFoto, bool disponible)
        {
            try
            {
                DalProducto.InsertarProducto(categoriaID, nombre, descripcion, precio, urlFoto, disponible);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el producto: " + ex.Message);
            }
        }

        // Actualizar producto
        public static void UpdProducto(int productoID, int categoriaID, string nombre, string descripcion, decimal precio, string urlFoto, bool disponible)
        {
            try
            {
                DalProducto.ActualizarProducto(productoID, categoriaID, nombre, descripcion, precio, urlFoto, disponible);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el producto: " + ex.Message);
            }
        }

        // Eliminar producto
        public static void DelProducto(int productoID)
        {
            try
            {
                DalProducto.EliminarProducto(productoID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto: " + ex.Message);
            }
        }
    }
}
