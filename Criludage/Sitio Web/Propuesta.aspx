<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Propuesta.aspx.cs" Inherits="Sitio_Web.Propuesta" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Ficha de propuesta</h1>
    <div class="body">
        <br />
        <asp:Image CssClass="displayed" ID="Foto" runat="server" Height="143px" Width="119px" BorderWidth="1px" BorderColor="Black" />
        <br /><br />

        <div class="ctrlHolder">
            <label class="etiqueta" for="TextBoxDescripcion">
                Descripción de la pieza</label>
            <asp:TextBox ID="TextBoxDescripcion" runat="server" Width="160px" ToolTip="Descripción de la pieza"
                TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
        </div>
        
        <div class="ctrlHolder">
            <label class="etiqueta" for="TextBoxEstado">
                Estado</label>
            <asp:TextBox ID="TextBoxEstado" runat="server"  Width="160px" ReadOnly="true">
            </asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label class="etiqueta" for="TextBoxPrecio">
                Precio</label>
            <asp:TextBox ID="TextBoxPrecio" runat="server" Width="160px" 
                ToolTip="Precio máximo admitido para la pieza" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label class="etiqueta" for="DateEditEntrega">
                Fecha de entrega</label>
            <dx:aspxdateedit ID="DateEditEntrega" runat="server" ReadOnly="True" 
                EditFormat="DateTime">
            </dx:aspxdateedit>
        </div>

        <br />
        <br />
        <h2>Datos del desguace</h2>
        <br />
        <div class="ctrlHolder">
            <label class="etiqueta" for="TextBoxNombre">
                Nombre</label>
            <asp:TextBox ID="TextBoxNombre" runat="server"  Width="160px" ReadOnly="true">
            </asp:TextBox>
        </div>

        <div class="ctrlHolder">
            <label class="etiqueta" for="TextBoxNif">
                NIF</label>
            <asp:TextBox ID="TextBoxNif" runat="server"  Width="160px" ReadOnly="true" ToolTip="Nombre del desguace">
            </asp:TextBox>
        </div>


        <div class="ctrlHolder">
            <label class="etiqueta" for="TextBoxDireccion">
                Dirección</label>
            <asp:TextBox ID="TextBoxDireccion" runat="server" Width="160px" ToolTip="Dirección del desguace"
                TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
        </div>

       <div class="ctrlHolder">
            <label class="etiqueta" for="TextBoxCorreoElectronico">
                Correo electrónico</label>
            <asp:TextBox ID="TextBoxCorreoElectronico" runat="server"  Width="160px" ReadOnly="true" ToolTip="Correo electrónico del desguace">
            </asp:TextBox>
        </div>


        <div class="ctrlHolder">
            <label class="etiqueta" for="TextBoxTelefono">
                Teléfono</label>
            <asp:TextBox ID="TextBoxTelefono" runat="server" Width="160px" 
                ToolTip="Teléfono de contacto del desguace" ReadOnly="True"></asp:TextBox>
        </div>
 
        <div class="ctrlHolder">
            <label class="etiqueta" for="TextBoxInfo">
                Información adicional</label>
            <asp:TextBox ID="TextBoxInfo" runat="server" Width="160px" ToolTip="Información adicional sobre el desguace"
                TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
        </div>
        <asp:Panel id="buttonConfirmar" runat="server">
            <div class="buttonHolder">
                <asp:Button ID="ButtonSubmit" runat="server" ToolTip="Confirmar propuesta" OnClientClick="return confirm('¿Confirma selección de propuesta?');" 
                    OnClick="ButtonSubmit_Click" Text="Confirmar propuesta">
                </asp:Button>
            </div>

        </asp:Panel>

    </div>
</asp:Content>
