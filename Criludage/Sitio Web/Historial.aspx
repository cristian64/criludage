<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="Sitio_Web.Historial" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Historial de compras</h1>
    <div class="body">
        <br />

        <dx:ASPxGridView ID="GridViewPropuestas" runat="server" AutoGenerateColumns="False" 
                ClientIDMode="AutoID" Width="605px">
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
                </Columns>
            </dx:ASPxGridView>
            <br />
    </div>
</asp:Content>

