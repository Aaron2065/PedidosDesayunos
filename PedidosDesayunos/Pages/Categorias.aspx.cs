using CapaNegocio;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace PedidosDesayunos.Pages
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
            }
        }

        // Cargar categorías al Grid
        private void CargarCategorias()
        {
            try
            {
                gvCategorias.DataSource = BllCategoria.GetListaCategorias();
                gvCategorias.DataBind();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error", "No se pudieron cargar las categorías: " + ex.Message, "error");
            }
        }

        // Nueva categoría
        protected void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            pnlCategoria.Visible = true;
            lblTituloModal.InnerText = "Nueva Categoría";
        }

        // Guardar categoría
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = string.IsNullOrEmpty(hfCategoriaID.Value) ? 0 : int.Parse(hfCategoriaID.Value);

                if (id == 0)
                {
                    // Insertar
                    BllCategoria.InsCategoria(txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                    MostrarAlerta("Éxito", "Categoría registrada correctamente.", "success");
                }
                else
                {
                    // Actualizar
                    BllCategoria.UpdCategoria(id, txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), chkActivo.Checked);
                    MostrarAlerta("Éxito", "Categoría actualizada correctamente.", "success");
                }

                pnlCategoria.Visible = false;
                CargarCategorias();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error", "No se pudo guardar la categoría: " + ex.Message, "error");
            }
        }

        // Cancelar edición
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlCategoria.Visible = false;
            LimpiarFormulario();
        }

        // Acciones en GridView
        protected void gvCategorias_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            var categoria = BllCategoria.GetCategoriaByID(id);
            if (e.CommandName == "EditarCategoria")
            {
                
                if (categoria != null)
                {
                    hfCategoriaID.Value = categoria.CategoriaID.ToString();
                    txtNombre.Text = categoria.Nombre;
                    txtDescripcion.Text = categoria.Descripcion;
                    chkActivo.Checked = categoria.Activo;

                    pnlCategoria.Visible = true;
                    lblTituloModal.InnerText = "Editar Categoría";
                }
            }
            else if (e.CommandName == "EliminarCategoria" )
            {
                try
                {
                    if (categoria.Activo == false)
                    {
                        BllCategoria.DelCategoria(id);
                        MostrarAlerta("Éxito", "Categoría eliminada correctamente.", "success");
                        CargarCategorias();
                    }
                    else
                    {
                        MostrarAlerta("Error", "No se pudo eliminar la categoría" , "error");
                    }
                }
                catch (Exception ex)
                {
                    MostrarAlerta("Error", "No se pudo eliminar la categoría: " + ex.Message, "error");
                }
            }
        }

        // Helpers
        private void LimpiarFormulario()
        {
            hfCategoriaID.Value = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            chkActivo.Checked = true;
        }

        private void MostrarAlerta(string titulo, string mensaje, string tipo)
        {
            string script = $"mostrarAlerta('{titulo}', '{mensaje}', '{tipo}');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
        }
    }
}