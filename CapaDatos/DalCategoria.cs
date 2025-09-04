using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;


namespace CapaDatos
{
    public class DalCategoria
    {
        // Listar categorías activas
        public static List<CategoriaVO> GetListaCategorias()
        {
            try
            {
                DataSet ds = MetodoDatos.ExecuteDataSet("Categorias_Listar");

                List<CategoriaVO> lista = new List<CategoriaVO>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lista.Add(new CategoriaVO(dr));
                }

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetListaCategorias: {ex.Message}");
                throw;
            }
        }

        // Insertar categoría
        public static int InsertarCategoria(string nombre, string descripcion)
        {
            return MetodoDatos.ExecuteNonQuey("Categorias_Insertar",
                "@Nombre", nombre,
                "@Descripcion", descripcion);
        }

        // Obtener categoría por ID
        public static CategoriaVO GetCategoriaByID(int id)
        {
            try
            {
                DataSet ds = MetodoDatos.ExecuteDataSet("Categorias_GetByID",
                    "@CategoriaID", id);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return new CategoriaVO(ds.Tables[0].Rows[0]);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetCategoriaByID: {ex.Message}");
                throw;
            }
        }

        // Actualizar categoría
        public static int ActualizarCategoria(int id, string nombre, string descripcion, bool activo)
        {
            return MetodoDatos.ExecuteNonQuey("Categorias_Actualizar",
                "@CategoriaID", id,
                "@Nombre", nombre,
                "@Descripcion", descripcion,
                "@Activo", activo);
        }

        // Eliminar categoría
        public static int EliminarCategoria(int id)
        {
            return MetodoDatos.ExecuteNonQuey("Categorias_Eliminar",
                "@CategoriaID", id);
        }
    }
}
