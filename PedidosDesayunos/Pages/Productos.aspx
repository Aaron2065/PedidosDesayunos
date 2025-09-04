<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="PedidosDesayunos.Pages.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-center">Gestión de Productos</h2>
        <hr />

        <%-- Botón agregar nuevo producto --%>
        <asp:Button ID="btnNuevoProducto" runat="server" Text="Nuevo Producto" CssClass="btn btn-primary mb-3" OnClick="btnNuevoProducto_Click" />

        <%-- GridView --%>
        <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered"
            DataKeyNames="ProductoID" OnRowCommand="gvProductos_RowCommand">
            <Columns>
                <asp:BoundField DataField="ProductoID" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="CategoriaNombre" HeaderText="Categoría" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C2}" />
                <asp:CheckBoxField DataField="Disponible" HeaderText="Disponible" />
                <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" DataFormatString="{0:dd/MM/yyyy}" />

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" CommandName="EditarProducto" CommandArgument='<%# Eval("ProductoID") %>' Text="Editar" CssClass="btn btn-warning btn-sm" />
                        <asp:Button ID="btnEliminar" runat="server" CommandName="EliminarProducto" CommandArgument='<%# Eval("ProductoID") %>' Text="Eliminar" CssClass="btn btn-danger btn-sm eliminarCategoria" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <%-- Panel Modal para Agregar/Editar Producto --%>
        <asp:Panel ID="pnlProducto" runat="server" CssClass="card p-3" Visible="false">
            <h4 id="lblTituloModal" runat="server">Nuevo Producto</h4>
            <asp:HiddenField ID="hfProductoID" runat="server" />

            <div class="mb-3">
                <label>Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label>Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
            </div>

            <div class="mb-3">
                <label>Categoría</label>
                <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-select" />
            </div>

            <div class="mb-3">
                <label>Precio</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label>Disponible</label>
                <asp:CheckBox ID="chkDisponible" runat="server" Checked="true" />
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
