<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroQuadra.aspx.cs" 
    Inherits="LabEngSoft.CadastrarQuadra" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="max-width: 600px; margin: 20px auto;">
        <h2 class="text-center">Cadastro de Quadra</h2>
        
        <div class="form-group">
            <label for="txtNome">Nome da Quadra</label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" placeholder="Ex: Quadra Central"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNome" runat="server" 
                ControlToValidate="txtNome" ErrorMessage="Nome obrigatório"
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label for="txtEndereco">Endereço Completo</label>
            <asp:TextBox ID="txtEndereco" runat="server" CssClass="form-control" 
                placeholder="Rua, número, bairro, cidade"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEndereco" runat="server" 
                ControlToValidate="txtEndereco" ErrorMessage="Endereço obrigatório"
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="ddlTipoQuadra">Tipo de Quadra</label>
                <asp:DropDownList ID="ddlTipoQuadra" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Selecione..." Value="" Selected="True" />
                    <asp:ListItem Text="Futebol" Value="Futebol" />
                    <asp:ListItem Text="Vôlei" Value="Vôlei" />
                    <asp:ListItem Text="Basquete" Value="Basquete" />
                    <asp:ListItem Text="Poliesportiva" Value="Poliesportiva" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvTipoQuadra" runat="server" 
                    ControlToValidate="ddlTipoQuadra" InitialValue=""
                    ErrorMessage="Selecione um tipo" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group col-md-6">
                <label for="txtCapacidade">Capacidade (pessoas)</label>
                <asp:TextBox ID="txtCapacidade" runat="server" CssClass="form-control" 
                    TextMode="Number" min="1" placeholder="Ex: 20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCapacidade" runat="server" 
                    ControlToValidate="txtCapacidade" ErrorMessage="Capacidade obrigatória"
                    ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <label for="txtValorHora">Valor por Hora (R$)</label>
            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text">R$</span>
                </div>
                <asp:TextBox ID="txtValorHora" runat="server" CssClass="form-control" 
                    TextMode="Number" step="0.01" min="0" placeholder="Ex: 50,00"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="rfvValorHora" runat="server" 
                ControlToValidate="txtValorHora" ErrorMessage="Valor obrigatório"
                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label for="txtDescricao">Descrição</label>
            <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" 
                TextMode="MultiLine" Rows="3" placeholder="Detalhes sobre a quadra"></asp:TextBox>
        </div>

        <div class="form-group text-center">
            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar Quadra" 
                CssClass="btn btn-primary btn-lg" OnClick="btnCadastrar_Click" />
            <asp:HyperLink ID="hlVoltar" runat="server" NavigateUrl="~/ListarQuadras.aspx" 
                CssClass="btn btn-secondary btn-lg ml-2">Voltar</asp:HyperLink>
        </div>

        <asp:Label ID="lblMensagem" runat="server" CssClass="alert alert-success mt-3" 
            Visible="false" style="display: block;"></asp:Label>
    </div>
</asp:Content>