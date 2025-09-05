using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosDesayunos.Pages
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        private void CargarClientes()
        {
            try
            {
                gvClientes.DataSource = BllCliente.GetListClientes();
                gvClientes.DataBind();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error", "No se pudieron cargar los clientes: " + ex.Message, "error");
            }
        }

        protected void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            pnlCliente.Visible = true;
            lblTituloModal.InnerText = "Nuevo Cliente";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = string.IsNullOrEmpty(hfClienteID.Value) ? 0 : int.Parse(hfClienteID.Value);
                string nombre = txtNombreCompleto.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                DateTime fechaRegistro = string.IsNullOrEmpty(txtFechaRegistro.Text) ? DateTime.Now : DateTime.Parse(txtFechaRegistro.Text);

                if (id == 0)
                {
                    BllCliente.InsCliente(nombre, telefono, fechaRegistro);
                    MostrarAlerta("Éxito", "Cliente registrado correctamente.", "success");
                }
                else
                {
                    BllCliente.UpdCliente(id, nombre, telefono, fechaRegistro);
                    MostrarAlerta("Éxito", "Cliente actualizado correctamente.", "success");
                }

                pnlCliente.Visible = false;
                CargarClientes();
            }
            catch (Exception ex)
            {
                MostrarAlerta("Error", "No se pudo guardar el cliente: " + ex.Message, "error");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlCliente.Visible = false;
            LimpiarFormulario();
        }

        protected void gvClientes_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            var cliente = BllCliente.GetClienteByID(id);

            if (e.CommandName == "EditarCliente")
            {
                if (cliente != null)
                {
                    hfClienteID.Value = cliente.ClienteID.ToString();
                    txtNombreCompleto.Text = cliente.NombreCompleto;
                    txtTelefono.Text = cliente.Telefono;
                    txtFechaRegistro.Text = cliente.FechaRegistro.ToString("yyyy-MM-dd");

                    pnlCliente.Visible = true;
                    lblTituloModal.InnerText = "Editar Cliente";
                }
            }
            else if (e.CommandName == "EliminarCliente")
            {
                try
                {
                    string resultado = BllCliente.DelCliente(id);
                    if (resultado == "1")
                    {
                        MostrarAlerta("Éxito", "Cliente eliminado correctamente.", "success");
                        CargarClientes();
                    }
                    else
                    {
                        MostrarAlerta("Error", "El cliente no existe o no se pudo eliminar.", "error");
                    }
                }
                catch (Exception ex)
                {
                    MostrarAlerta("Error", "No se pudo eliminar el cliente: " + ex.Message, "error");
                }
            }
        }

        private void LimpiarFormulario()
        {
            hfClienteID.Value = "";
            txtNombreCompleto.Text = "";
            txtTelefono.Text = "";
            txtFechaRegistro.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void MostrarAlerta(string titulo, string mensaje, string tipo)
        {
            string script = $"mostrarAlerta('{titulo}', '{mensaje}', '{tipo}');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
        }
    }
}