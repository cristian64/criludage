<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ConsultarSolicitudes.aspx.cs" Inherits="Sitio_Web.ConsultarSolicitudes" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>
        Solicitudes</h1>
    <div class="body">
        <dx:ASPxGridView ID="GridViewSolicitudes" runat="server" 
            AutoGenerateColumns="False" ClientIDMode="AutoID" Width="360px">
            <Columns>
                <dx:GridViewDataHyperLinkColumn Caption="ID" FieldName="ID" Name="ID" 
                    VisibleIndex="0" ReadOnly="True" >
                    <PropertiesHyperLinkEdit NavigateUrlFormatString="Solicitud.aspx?id={0}">
                    </PropertiesHyperLinkEdit>
                </dx:GridViewDataHyperLinkColumn>
                <dx:GridViewDataTextColumn Caption="Descripción" FieldName="Descripcion" 
                    Name="Descripcion" UnboundType="String" VisibleIndex="1" ReadOnly="True">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Fecha" FieldName="Fecha" Name="Fecha" 
                    UnboundType="DateTime" VisibleIndex="2" ReadOnly="True">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Fecha de respuesta" FieldName="FechaResp" 
                    Name="FechaResp" UnboundType="DateTime" Visible="False" VisibleIndex="3" 
                    ReadOnly="True">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Negociado auto." FieldName="Negociado" 
                    Name="Negociado" UnboundType="Boolean" VisibleIndex="3" ReadOnly="True">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Estado" FieldName="Estado" Name="Estado" 
                    UnboundType="String" Visible="False" VisibleIndex="4" ReadOnly="True">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Precio máximo" FieldName="PrecioMax" 
                    Name="PrecioMax" Visible="False" VisibleIndex="4" ReadOnly="True">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Fecha de entrega" FieldName="FechaEntrega" 
                    Name="FechaEntrega" UnboundType="DateTime" Visible="False" 
                    VisibleIndex="6" ReadOnly="True">
                </dx:GridViewDataTextColumn>
            </Columns>
            
        </dx:ASPxGridView>
    </div>
</asp:Content>