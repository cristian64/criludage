<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Propuesta.aspx.cs" Inherits="Sitio_Web.Propuesta" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>
        Ficha de propuesta</h1>
    <div class="body">
        <asp:Image ID="Foto" runat="server" Height="143px" Width="119px" BorderWidth="1px" BorderColor="Black" />
        <br /><br />
        <div class="ctrlHolder">
            <label for="TextBoxDescripcion">
                Descripción de la pieza</label>
            <asp:TextBox ID="TextBoxDescripcion" runat="server" Width="160px" ToolTip="Descripción de la pieza"
                TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
        </div>
        
        <div class="ctrlHolder">
            <label for="DropDownListEstado">
                Estado</label>
            <asp:DropDownList ID="DropDownListEstado" runat="server" Enabled="False">
            </asp:DropDownList>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxPrecio">
                Precio</label>
            <asp:TextBox ID="TextBoxPrecio" runat="server" Width="160px" 
                ToolTip="Precio máximo admitido para la pieza" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="DateEditEntrega">
                Fecha de entrega</label>
            <dx:aspxdateedit ID="DateEditEntrega" runat="server" ReadOnly="True">
            </dx:aspxdateedit>
        </div>
    </div>
</asp:Content>
