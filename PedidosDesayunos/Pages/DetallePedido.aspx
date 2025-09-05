<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePedido.aspx.cs" Inherits="PedidosDesayunos.Pages.DetallePedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-center">Detalle de Pedidos</h2>
        <hr />

        <%-- Seleccionar pedido --%>
        <div class="mb-3">
            <label>Pedido</label>
            <asp:DropDownList ID="ddlPedidos" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlPedidos_SelectedIndexChanged" />
        </div>

        <%-- Información del pedido --%>
        <div class="mb-3">
            <label>Notas</label>
            <asp:TextBox ID="txtNotas" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" ReadOnly="true" />
        </div>

        <%-- GridView con detalle de pedido --%>
        <asp:GridView ID="gvDetallePedido" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="ProductoNombre" HeaderText="Producto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" DataFormatString="{0:C2}" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C2}" />
            </Columns>
        </asp:GridView>

        <%-- Total del pedido --%>
        <div class="text-end mt-3">
            <h5>Total: <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label></h5>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="../Scripts/SweetAlerts/Alertas.js"></script>
</asp:Content>
