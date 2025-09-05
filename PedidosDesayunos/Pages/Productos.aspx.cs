using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosDesayunos.Pages
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
                CargarCategorias();
            }
        }

        private void CargarProductos()
        {
            try
            {
                gvProductos.DataSource = BllProducto.GetListaProductos();
                gvProductos.DataBind();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error", "No se pudieron cargar los productos: " + ex.Message, "error");
            }
        }

        private void CargarCategorias()
        {
            ddlCategorias.DataSource = BllCategoria.GetListaCategorias();
            ddlCategorias.DataTextField = "Nombre";
            ddlCategorias.DataValueField = "CategoriaID";
            ddlCategorias.DataBind();
            ddlCategorias.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
        }

        protected void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            pnlProducto.Visible = true;
            lblTituloModal.InnerText = "Nuevo Producto";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = string.IsNullOrEmpty(hfProductoID.Value) ? 0 : int.Parse(hfProductoID.Value);
                int categoriaID = int.Parse(ddlCategorias.SelectedValue);

                if (categoriaID == 0)
                {
                    MostrarAlerta("Error", "Debe seleccionar una categoría.", "error");
                    return;
                }

                decimal precio = decimal.Parse(txtPrecio.Text.Trim());

                // Guardar imagen si hay archivo
                string urlImagen = "";
                if (fuImagen.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(fuImagen.FileName).ToLower();
                    string[] extensionesPermitidas = { ".jpg", ".jpeg", ".png", ".gif" };

                    if (!extensionesPermitidas.Contains(extension))
                    {
                        MostrarAlerta("Error", "Solo se permiten imágenes JPG, PNG o GIF.", "error");
                        return;
                    }

                    string nombreArchivo = Guid.NewGuid() + extension;
                    string ruta = Server.MapPath("~/Uploads/Productos/");
                    if (!System.IO.Directory.Exists(ruta))
                        System.IO.Directory.CreateDirectory(ruta);

                    fuImagen.SaveAs(System.IO.Path.Combine(ruta, nombreArchivo));
                    urlImagen = "~/Uploads/Productos/" + nombreArchivo;
                }

                if (id == 0)
                {
                    BllProducto.InsProducto(categoriaID, txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), precio, urlImagen, chkDisponible.Checked);
                    MostrarAlerta("Éxito", "Producto registrado correctamente.", "success");
                }
                else
                {
                    // Si no sube nueva imagen, mantener la existente
                    if (string.IsNullOrEmpty(urlImagen))
                        urlImagen = BllProducto.GetProductoByID(id).ImagenUrl;

                    BllProducto.UpdProducto(id, categoriaID, txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), precio, urlImagen, chkDisponible.Checked);
                    MostrarAlerta("Éxito", "Producto actualizado correctamente.", "success");
                }

                pnlProducto.Visible = false;
                CargarProductos();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error", "No se pudo guardar el producto: " + ex.Message, "error");
            }
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlProducto.Visible = false;
            LimpiarFormulario();
        }

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            var producto = BllProducto.GetProductoByID(id);

            if (e.CommandName == "EditarProducto")
            {
                
                if (producto != null)
                {
                    hfProductoID.Value = producto.ProductoID.ToString();
                    txtNombre.Text = producto.Nombre;
                    txtDescripcion.Text = producto.Descripcion;
                    ddlCategorias.SelectedValue = producto.CategoriaID.ToString();
                    txtPrecio.Text = producto.Precio.ToString();
                    chkDisponible.Checked = producto.Disponible;

                    pnlProducto.Visible = true;
                    lblTituloModal.InnerText = "Editar Producto";

                    // Mostrar imagen actual
                    if (!string.IsNullOrEmpty(producto.ImagenUrl))
                    {
                        divImagenActual.Visible = true;
                        imgProducto.ImageUrl = producto.ImagenUrl;
                    }
                    else
                    {
                        divImagenActual.Visible = false;
                        imgProducto.ImageUrl = "";
                    }
                }
            }
            else if (e.CommandName == "EliminarProducto")
            {
                try
                {
                    if (producto.Disponible == false)
                    {
                        BllProducto.DelProducto(id);
                        MostrarAlerta("Éxito", "Producto eliminado correctamente.", "success");
                        CargarProductos();
                    }
                    else
                    {
                        MostrarAlerta("Error", "No se pudo eliminar el producto", "error");
                    }
                }
                catch (Exception ex)
                {
                    MostrarAlerta("Error", "No se pudo eliminar el producto: " + ex.Message, "error");
                }
            }
        }

        private void LimpiarFormulario()
        {
            hfProductoID.Value = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            ddlCategorias.SelectedIndex = 0;
            txtPrecio.Text = "";
            chkDisponible.Checked = true;
        }

        private void MostrarAlerta(string titulo, string mensaje, string tipo)
        {
            string script = $"mostrarAlerta('{titulo}', '{mensaje}', '{tipo}');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
        }
    }
}