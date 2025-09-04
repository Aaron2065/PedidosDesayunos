using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaNegocio
{
    public class BllCategoria
    {
        // Listar todas las categorías
        public static List<CategoriaVO> GetListaCategorias()
        {
            return DalCategoria.GetListaCategorias();
        }

        // Insertar una nueva categoría
        public static void InsCategoria(string nombre, string descripcion)
        {
            try
            {
                DalCategoria.InsertarCategoria(nombre, descripcion);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al insertar categoría: {ex.Message}");
            }
        }

        // Actualizar una categoría existente
        public static void UpdCategoria(int categoriaID, string nombre, string descripcion, bool activo)
        {
            try
            {
                DalCategoria.ActualizarCategoria(categoriaID, nombre, descripcion, activo);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al actualizar categoría: {ex.Message}");
            }
        }

        // Eliminar una categoría
        public static string DelCategoria(int categoriaID)
        {
            // Opcional: podrías validar que no tenga productos relacionados antes de eliminar
            CategoriaVO categoria = DalCategoria.GetCategoriaByID(categoriaID);

            if (categoria != null && categoria.Activo == false)
            {
                DalCategoria.EliminarCategoria(categoriaID);
                return "1"; // Eliminación exitosa
            }
            else
            {
                return "0"; // No se pudo eliminar
            }
        }

        // Obtener una categoría por ID
        public static CategoriaVO GetCategoriaByID(int categoriaID)
        {
            return DalCategoria.GetCategoriaByID(categoriaID);
        }
    }
}
