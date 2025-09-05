using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace PedidosDesayunos.Pages
{
    public partial class DetallePedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPedidos();
            }
        }

        private void CargarPedidos()
        {
            var pedidos = BllPedido.GetListaPedidos();

            ddlPedidos.DataSource = pedidos;
            ddlPedidos.DataTextField = "ClienteNombre"; // puedes mostrar ClienteNombre + ID
            ddlPedidos.DataValueField = "PedidoID";
            ddlPedidos.DataBind();
            ddlPedidos.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
        }

        protected void ddlPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pedidoID = int.Parse(ddlPedidos.SelectedValue);

            if (pedidoID == 0)
            {
                gvDetallePedido.DataSource = null;
                gvDetallePedido.DataBind();
                txtNotas.Text = "";
                lblTotal.Text = "0";
                return;
            }

            // Obtener detalles
            var detalles = BllDetallePedido.GetDetallesByPedido(pedidoID);

            gvDetallePedido.DataSource = detalles;
            gvDetallePedido.DataBind();

            // Mostrar notas del pedido
            var pedido = BllPedido.GetPedidoByID(pedidoID);
            txtNotas.Text = pedido != null ? pedido.Notas : "";

            // Calcular total
            lblTotal.Text = detalles.Sum(d => d.Subtotal).ToString("C2");

            if (detalles.Count == 0)
            {
                MostrarAlerta("Aviso", "Este pedido no tiene productos.", "info");
            }
        }

        private void MostrarAlerta(string titulo, string mensaje, string tipo)
        {
            string script = $"mostrarAlerta('{titulo}', '{mensaje}', '{tipo}');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
        }
    }
}
