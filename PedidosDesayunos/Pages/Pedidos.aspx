<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="PedidosDesayunos.Pages.Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-center">Gestión de Pedidos</h2>
        <hr />

        <%-- Seleccionar cliente --%>
        <div class="mb-3">
            <label>Cliente</label>
            <asp:DropDownList ID="ddlClientes" runat="server" CssClass="form-select" />
        </div>

        <%-- Notas del pedido --%>
        <div class="mb-3">
            <label>Notas</label>
            <asp:TextBox ID="txtNotas" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
        </div>

        <%-- Agregar productos al pedido --%>
        <div class="mb-3 row">
            <div class="col-md-6">
                <label>Producto</label>
                <asp:DropDownList ID="ddlProductos" runat="server" CssClass="form-select" />
            </div>
            <div class="col-md-3">
                <label>Cantidad</label>
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3 align-self-end">
                <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar al Pedido" CssClass="btn btn-primary w-100" OnClick="btnAgregarProducto_Click" />
            </div>
        </div>

        <%-- GridView con productos agregados temporalmente --%>
        <asp:GridView ID="gvDetallePedido" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" OnRowCommand="gvDetallePedido_RowCommand">
            <Columns>
                <asp:BoundField DataField="ProductoNombre" HeaderText="Producto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" DataFormatString="{0:C2}" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C2}" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEliminarDetalle" runat="server" CommandName="EliminarDetalle" CommandArgument='<%# Eval("ProductoID") %>' Text="Eliminar" CssClass="btn btn-danger btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <%-- Total del pedido --%>
        <div class="text-end mb-3">
            <h5>Total: <asp:Label ID="lblTotal" runat="server" Text="$0.00"></asp:Label></h5>
        </div>

        <%-- Botones para guardar o cancelar pedido --%>
        <div class="text-end">
            <asp:Button ID="btnGuardarPedido" runat="server" Text="Guardar Pedido" CssClass="btn btn-success" OnClick="btnGuardarPedido_Click" />
            <asp:Button ID="btnCancelarPedido" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelarPedido_Click" />
        </div>
    </div>
    <asp:Button ID="btnVerDetalle" runat="server" Text="Ver Detalle de Pedidos" CssClass="btn btn-warning ms-2" OnClick="btnVerDetalle_Click" />

    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="../Scripts/SweetAlerts/Alertas.js"></script>
</asp:Content>
