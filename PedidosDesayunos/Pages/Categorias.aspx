<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="PedidosDesayunos.Pages.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-center">Gestión de Categorías</h2>
        <hr />

        <%--Botón agregar nueva categoría --%>
        <asp:Button ID="btnNuevaCategoria" runat="server" Text="Nueva Categoría" CssClass="btn btn-primary mb-3" OnClick="btnNuevaCategoria_Click" />

        <%--GridView--%>
        <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered"
            DataKeyNames="CategoriaID" OnRowCommand="gvCategorias_RowCommand">
            <Columns>
                <asp:BoundField DataField="CategoriaID" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:CheckBoxField DataField="Activo" HeaderText="Activo" />
                <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" DataFormatString="{0:dd/MM/yyyy}" />

                <%-- Botones de Editar y Eliminar --%>
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" CommandName="EditarCategoria" CommandArgument='<%# Eval("CategoriaID") %>' Text="Editar" CssClass="btn btn-warning btn-sm" />
                        <asp:Button ID="btnEliminar" runat="server" CommandName="EliminarCategoria" CommandArgument='<%# Eval("CategoriaID") %>' Text="Eliminar" CssClass="btn btn-danger btn-sm eliminarCategoria" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <%--Panel Modal para Agregar/Editar--%>
        <asp:Panel ID="pnlCategoria" runat="server" CssClass="card p-3" Visible="false">
            <h4 id="lblTituloModal" runat="server">Nueva Categoría</h4>
            <asp:HiddenField ID="hfCategoriaID" runat="server" />

            <div class="mb-3">
                <label>Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label>Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
            </div>

            <div class="mb-3">
                <label>Activo</label>
                <asp:CheckBox ID="chkActivo" runat="server" Checked="true" />
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
    