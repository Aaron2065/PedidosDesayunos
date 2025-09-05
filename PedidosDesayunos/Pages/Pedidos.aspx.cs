using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace PedidosDesayunos.Pages
{
    public partial class Pedidos : System.Web.UI.Page
    {
        private List<DetallePedidoVO> detalles
        {
            get
            {
                if (ViewState["detalles"] == null)
                    ViewState["detalles"] = new List<DetallePedidoVO>();
                return (List<DetallePedidoVO>)ViewState["detalles"];
            }
            set => ViewState["detalles"] = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
                CargarProductos();
                CargarGrid();
            }
        }

        private void CargarClientes()
        {
            ddlClientes.DataSource = BllCliente.GetListClientes();
            ddlClientes.DataTextField = "NombreCompleto";
            ddlClientes.DataValueField = "ClienteID";
            ddlClientes.DataBind();
            ddlClientes.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
        }

        private void CargarProductos()
        {
            ddlProductos.DataSource = BllProducto.GetListaProductos();
            ddlProductos.DataTextField = "Nombre";
            ddlProductos.DataValueField = "ProductoID";
            ddlProductos.DataBind();
            ddlProductos.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
        }

        private void CargarGrid()
        {
            gvDetallePedido.DataSource = detalles;
            gvDetallePedido.DataBind();
            lblTotal.Text = detalles.Count > 0 ? detalles.Sum(d => d.Subtotal).ToString("C2") : "$0.00";
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(ddlProductos.SelectedValue, out int productoID) || productoID == 0)
            {
                MostrarAlerta("Error", "Seleccione un producto válido.", "error");
                return;
            }

            if (!int.TryParse(txtCantidad.Text.Trim(), out int cantidad) || cantidad <= 0)
            {
                MostrarAlerta("Error", "Ingrese una cantidad válida.", "error");
                return;
            }

            var producto = BllProducto.GetProductoByID(productoID);

            var lista = detalles;
            lista.Add(new DetallePedidoVO
            {
                ProductoID = productoID,
                ProductoNombre = producto.Nombre,
                Cantidad = cantidad,
                PrecioUnitario = producto.Precio,
                Subtotal = producto.Precio * cantidad
            });

            detalles = lista; // actualizar ViewState
            CargarGrid();

            // Limpiar campos
            ddlProductos.SelectedIndex = 0;
            txtCantidad.Text = "";
        }

        protected void gvDetallePedido_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EliminarDetalle")
            {
                int productoID = int.Parse(e.CommandArgument.ToString());
                detalles.RemoveAll(d => d.ProductoID == productoID);
                CargarGrid();
            }
        }

        protected void btnGuardarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(ddlClientes.SelectedValue, out int clienteID) || clienteID == 0 || detalles.Count == 0)
                {
                    MostrarAlerta("Error", "Seleccione un cliente y agregue al menos un producto.", "error");
                    return;
                }

                // Guardar pedido
                int pedidoID = BllPedido.InsPedido(clienteID, txtNotas.Text.Trim());

                // Guardar detalles
                foreach (var det in detalles)
                {
                    BllDetallePedido.InsertDetalle(pedidoID, det.ProductoID, det.Cantidad, det.PrecioUnitario);
                }

                MostrarAlerta("Éxito", "Pedido registrado correctamente.", "success");
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error", "No se pudo guardar el pedido: " + ex.Message, "error");
            }
        }

        protected void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            ddlClientes.SelectedIndex = 0;
            txtNotas.Text = "";
            ddlProductos.SelectedIndex = 0;
            txtCantidad.Text = "";
            detalles.Clear();
            CargarGrid();
        }

        private void MostrarAlerta(string titulo, string mensaje, string tipo)
        {
            string script = $"mostrarAlerta('{titulo}', '{mensaje}', '{tipo}');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetallePedido.aspx");
        }

    }
}
