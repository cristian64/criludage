<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Desguace.aspx.cs" Inherits="Sitio_Web.Desguace" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Ficha de desguace</h1>
    <div class="body">

        <div class="ctrlHolder">
            <label for="TextBoxNombre">
                Nombre</label>
            <asp:TextBox ID="TextBoxNombre" runat="server"  Width="160px" ReadOnly="true">
            </asp:TextBox>
        </div>

        <div class="ctrlHolder">
            <label for="TextBoxNif">
                NIF</label>
            <asp:TextBox ID="TextBoxNif" runat="server"  Width="160px" ReadOnly="true" ToolTip="Nombre del desguace">
            </asp:TextBox>
        </div>


        <div class="ctrlHolder">
            <label for="TextBoxDireccion">
                Dirección</label>
            <asp:TextBox ID="TextBoxDireccion" runat="server" Width="160px" ToolTip="Dirección del desguace"
                TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
        </div>

       <div class="ctrlHolder">
            <label for="TextBoxCorreoElectronico">
                Correo electrónico</label>
            <asp:TextBox ID="TextBoxCorreoElectronico" runat="server"  Width="160px" ReadOnly="true" ToolTip="Correo electrónico del desguace">
            </asp:TextBox>
        </div>


        <div class="ctrlHolder">
            <label for="TextBoxTelefono">
                Teléfono</label>
            <asp:TextBox ID="TextBoxTelefono" runat="server" Width="160px" 
                ToolTip="Teléfono de contacto del desguace" ReadOnly="True"></asp:TextBox>
        </div>
 
        <div class="ctrlHolder">
            <label for="TextBoxInfo">
                Información adicional</label>
            <asp:TextBox ID="TextBoxInfo" runat="server" Width="160px" ToolTip="Información adicional sobre el desguace"
                TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
        </div>

    </div>
</asp:Content>
