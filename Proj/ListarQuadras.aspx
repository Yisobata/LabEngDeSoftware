<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarQuadras.aspx.cs" Inherits="LabEngSoft.ListQuadras" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Label ID="lblMessage" runat="server" 
        CssClass="alert" 
        Visible="false"
        style="display: block; margin: 10px 0; padding: 10px;">
    </asp:Label>
    <div class="container">
        <h2 class="text-center mb-4">Quadras disponíveis</h2>
        
        <div class="row mb-3">
            <div class="col-md-6">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" 
                    placeholder="Buscar por endereço..."></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlTipoQuadra" runat="server" CssClass="form-control"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlTipoQuadra_SelectedIndexChanged">
                    <asp:ListItem Text="Todos os tipos" Value="" />
                    <asp:ListItem Text="Futebol" Value="1" />
                    <asp:ListItem Text="Vôlei" Value="2" />
                    <asp:ListItem Text="Basquete" Value="3" />
                    <asp:ListItem Text="Poliesportiva" Value="4" />
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnSearch" runat="server" Text="Buscar" 
                    CssClass="btn btn-primary btn-block w-100" OnClick="btnSearch_Click" />
            </div>
            <div class="sort-controls mb-3">
                <span>Ordenar por: </span>
                <asp:DropDownList ID="ddlSort" runat="server" AutoPostBack="true" 
                    OnSelectedIndexChanged="ddlSort_SelectedIndexChanged" CssClass="form-control d-inline-block w-auto">
                    <asp:ListItem Text="Preço (Menor → Maior)" Value="PrecoAsc" />
                    <asp:ListItem Text="Preço (Maior → Menor)" Value="PrecoDesc" />
                    <asp:ListItem Text="Data (Mais Antigas)" Value="DataAsc" />
                    <asp:ListItem Text="Data (Mais Recentes)" Value="DataDesc" Selected="True" />
                </asp:DropDownList>
           </div>
        </div>

<asp:GridView ID="gvQuadras" runat="server" 
    AutoGenerateColumns="false"
    DataKeyNames="Id"
    OnRowEditing="gvQuadras_RowEditing"
    OnRowUpdating="gvQuadras_RowUpdating"
    OnRowCancelingEdit="gvQuadras_RowCancelingEdit"
    CssClass="table table-striped">
    <Columns>
        <%-- Non-editable fields --%>
        <asp:BoundField DataField="Endereco" HeaderText="Endereço" ReadOnly="true" />
        
        <%-- Editable fields --%>
        <asp:TemplateField HeaderText="Tipo de Quadra">
            <ItemTemplate>
                <%# Eval("TipoQuadra") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlTipoQuadra" runat="server" SelectedValue='<%# Bind("TipoQuadra") %>'
                    CssClass="form-control">
                    <asp:ListItem Text="Futebol" Value="Futebol" />
                    <asp:ListItem Text="Vôlei" Value="Vôlei" />
                    <asp:ListItem Text="Basquete" Value="Basquete" />
                </asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Preço/Hora">
            <ItemTemplate>
                <%# Eval("ValorHora", "{0:C2}") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtValorHora" runat="server" Text='<%# Bind("ValorHora") %>'
                    CssClass="form-control" TextMode="Number" step="0.01" />
            </EditItemTemplate>
        </asp:TemplateField>
        
        <%-- Command fields --%>
        <asp:CommandField ShowEditButton="true" ButtonType="Button" 
            EditText="Editar" UpdateText="Salvar" CancelText="Cancelar"
            ControlStyle-CssClass="btn btn-sm btn-outline-primary" />
    </Columns>
</asp:GridView>

        <div class="text-right mt-3">
            <asp:Button ID="btnAddNew" runat="server" Text="Adicionar Nova Quadra" 
                CssClass="btn btn-success" OnClick="btnAddNew_Click" />
        </div>
    </div>
</asp:Content>