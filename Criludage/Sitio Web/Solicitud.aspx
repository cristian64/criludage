<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Solicitud.aspx.cs" Inherits="Sitio_Web.Solicitud" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Ficha de solicitud</h1>
    <div class="body">
        <div class="ctrlHolder">
            <label class="etiqueta" for="TextBoxEstadoSolicitud">
                Estado de la solicitud</label>
            <asp:TextBox ID="TextBoxEstadoSolicitud" runat="server"  Width="160px" ReadOnly="true">
            </asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label class="etiqueta" for="TextBoxDescripcion">
                Descripción de la pieza</label>
            <asp:TextBox ID="TextBoxDescripcion" runat="server" Width="160px" ToolTip="Descripción de la pieza"
                TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label class="etiqueta" for="RadioButtonListNegociado">
                Negociado</label>
            <asp:RadioButtonList ID="RadioButtonListNegociado" runat="server" 
                ToolTip="Tipo de negociado de la solicitud" RepeatColumns="2" 
                Enabled="False" Width="160px" CellPadding="15" 
                RepeatDirection="Horizontal">
                <asp:ListItem Value="manual" Selected="True" />
                <asp:ListItem Value="automático" />
            </asp:RadioButtonList>
        </div>
        <div class="ctrlHolder">
            <label class="etiqueta" for="TextBoxEstado">
                Estado</label>
            <asp:TextBox ID="TextBoxEstado" runat="server"  Width="160px" ReadOnly="true">
            </asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label class="etiqueta" for="TextBoxPrecio">
                Precio máximo</label>
            <asp:TextBox ID="TextBoxPrecio" runat="server" Width="160px" 
                ToolTip="Precio máximo admitido para la pieza" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label class="etiqueta" for="DateEditEntrega">
                Fecha de entrega</label>
            <dx:ASPxDateEdit ID="DateEditEntrega" runat="server" ReadOnly="True">
            </dx:ASPxDateEdit>
        </div>

        <div class="ctrlHolder">
            <label class="etiqueta" for="DateEditFecha">
                Fecha</label>
            <dx:ASPxDateEdit ID="DateEditFecha" runat="server" ReadOnly="True" 
                EditFormat="DateTime">
            </dx:ASPxDateEdit>
        </div>
        <div class="ctrlHolder">
            <label class="etiqueta" for="DateEditRespuesta">
                Fecha de respuesta</label>
            <dx:ASPxDateEdit ID="DateEditRespuesta" runat="server" ReadOnly="True" 
                EditFormat="DateTime">
            </dx:ASPxDateEdit>
        </div>
        <asp:Panel id="bloquePropuestas" runat="server">
            <br />
            <br />
            <h2>Propuestas</h2>
            <br />
            <dx:ASPxGridView ID="GridViewPropuestas" runat="server" AutoGenerateColumns="False" 
                ClientIDMode="AutoID" Width="605px" 
                onhtmlrowprepared="GridViewPropuestas_HtmlRowPreprared">
                <Columns>
                    <dx:GridViewDataHyperLinkColumn Caption="ID" FieldName="ID" Name="ID" 
                        ReadOnly="True" UnboundType="Integer" VisibleIndex="0">
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="Propuesta.aspx?id={0}"></PropertiesHyperLinkEdit>
                    </dx:GridViewDataHyperLinkColumn>
                    <dx:GridViewDataTextColumn Caption="Descripción" FieldName="Descripcion" 
                        Name="Descripcion" ReadOnly="True" UnboundType="String" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Fecha de entrega" FieldName="FechaEntrega" 
                        Name="FechaEntrega" ReadOnly="True" UnboundType="DateTime" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Estado" FieldName="Estado" Name="Estado" 
                        ReadOnly="True" UnboundType="String" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Precio" FieldName="Precio" Name="Precio" 
                        ReadOnly="True" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Confirmada" FieldName="Confirmada" 
                        Name="Confirmada" ReadOnly="True" UnboundType="Boolean" Visible="False" 
                        VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <br />
        </asp:Panel>
    </div>
</asp:Content>
