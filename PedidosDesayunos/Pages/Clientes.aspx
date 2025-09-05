<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="PedidosDesayunos.Pages.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-center">Gestión de Clientes</h2>
        <hr />

        <%-- Botón agregar nuevo cliente --%>
        <asp:Button ID="btnNuevoCliente" runat="server" Text="Nuevo Cliente" CssClass="btn btn-primary mb-3" OnClick="btnNuevoCliente_Click" />

        <%-- GridView de Clientes --%>
        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered"
            DataKeyNames="ClienteID" OnRowCommand="gvClientes_RowCommand">
            <Columns>
                <asp:BoundField DataField="ClienteID" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" DataFormatString="{0:dd/MM/yyyy}" />

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" CommandName="EditarCliente" CommandArgument='<%# Eval("ClienteID") %>' Text="Editar" CssClass="btn btn-warning btn-sm" />
                        <asp:Button ID="btnEliminar" runat="server" CommandName="EliminarCliente" CommandArgument='<%# Eval("ClienteID") %>' Text="Eliminar" CssClass="btn btn-danger btn-sm eliminarCategoria" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <%-- Panel Modal para Agregar/Editar Cliente --%>
        <asp:Panel ID="pnlCliente" runat="server" CssClass="card p-3" Visible="false">
            <h4 id="lblTituloModal" runat="server">Nuevo Cliente</h4>
            <asp:HiddenField ID="hfClienteID" runat="server" />

            <div class="mb-3">
                <label>Nombre Completo</label>
                <asp:TextBox ID="txtNombreCompleto" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label>Teléfono</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label>Fecha Registro</label>
                <asp:TextBox ID="txtFechaRegistro" runat="server" CssClass="form-control" TextMode="Date" />
            </div>

            <div class="text-end">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
            </div>
        </asp:Panel>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="../Scripts/SweetAlerts/Alertas.js"></script>
</asp:Content>
