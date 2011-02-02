<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="SolicitarPieza.aspx.cs" Inherits="Sitio_Web.SolicitarPieza" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type='text/javascript'>

    function ClearAllControls() {
        for (i = 0; i < document.forms[0].length; i++) {
            doc = document.forms[0].elements[i];
            switch (doc.type) {
                case "text":
                    doc.value = "";
                    break;
                case "textarea":
                    doc.value = "";
                    break;
                case "password":
                    doc.value = "";
                    break;
                case "checkbox":
                    doc.checked = false;
                    break;
                case "radio":
                    doc.checked = false;
                    break;
                case "select-one":
                    doc.options[doc.selectedIndex].selected = false;
                    break;
                case "select-multiple":
                    while (doc.selectedIndex != -1) {
                        indx = doc.selectedIndex;
                        doc.options[indx].selected = false;
                    }
                    doc.selected = false;
                    break;

                default:
                    break;
            }
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Solicitar pieza</h1>
    <div class="body">

        <asp:RequiredFieldValidator Display="None" EnableClientScript="true" ID="RequiredFieldValidatorDescripcion" runat="server"
            ControlToValidate="TextBoxDescripcion" ErrorMessage="Descripción de la pieza obligatoria"
            ValidationGroup="grupo1"></asp:RequiredFieldValidator>
        
        <asp:RegularExpressionValidator Display="None" EnableClientScript="true" ID="RegularExpressionValidatorPrecio"
            runat="server" ControlToValidate="TextBoxPrecio" ErrorMessage="Precio incorrecto o vacío" ValidationExpression="^[0-9]+(.[0-9]{3})*([\.\,][0-9]{1,2})?(\w)*(€)?$"
            ValidationGroup="grupo1"></asp:RegularExpressionValidator>

        <asp:CustomValidator ID="CustomValidatorEntrega" runat="server" ControlToValidate="DateEditEntrega" ErrorMessage="Fecha de entrega vacía o incorrecta" OnServerValidate="ValidacionFecha" ValidationGroup="grupo1"></asp:CustomValidator>
        <asp:CustomValidator ID="CustomValidatorRespuesta" runat="server" ControlToValidate="DateEditRespuesta" ErrorMessage="Fecha de respuesta vacía o incorrecta" OnServerValidate="ValidacionFecha" ValidationGroup="grupo1"></asp:CustomValidator>

        <div class="ctrlHolder">
            <label for="TextBoxDescripcion">
                Descripción de la pieza</label>
            <asp:TextBox ValidationGroup="grupo1" ID="TextBoxDescripcion" runat="server" Width="160px" ToolTip="Descripción de la pieza"
                TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="RadioButtonListNegociado">
                Negociado</label>
            <asp:RadioButtonList ID="RadioButtonListNegociado" runat="server" 
                ToolTip="Tipo de negociado de la solicitud" RepeatColumns="2" 
                RepeatDirection="Horizontal">
                <asp:ListItem Value="manual" Selected="True" />
                <asp:ListItem Value="automático" />
            </asp:RadioButtonList>
        </div>
        <div class="ctrlHolder">
            <label for="DropDownListEstado">
                Estado</label>
            <asp:DropDownList ID="DropDownListEstado" runat="server">
            </asp:DropDownList>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxPrecio">
                Precio máximo (€)</label>
            <asp:TextBox ValidationGroup="grupo1" ID="TextBoxPrecio" runat="server" Width="160px" ToolTip="Precio máximo admitido para la pieza"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="DateEditEntrega">
                Fecha de entrega</label>
            <dx:ASPxDateEdit ID="DateEditEntrega" runat="server">
            </dx:ASPxDateEdit>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxInfo">
                Información adicional de la solicitud</label>
            <asp:TextBox ID="TextBoxInfo" runat="server" Width="160px" ToolTip="Descripción de la pieza"
                TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="DateEditRespuesta">
                Fecha de respuesta</label>
            <dx:ASPxDateEdit ID="DateEditRespuesta" runat="server">
            </dx:ASPxDateEdit>
        </div>

        <ASP:ValidationSummary CssClass="ErrorSummary" ID="ValidationSummary1" ValidationGroup="grupo1" runat="server"
            RenderMode="BulletedList" HeaderText="<p>Se han encontrado los siguientes errores: </p>">
        </ASP:ValidationSummary>

        <div class="buttonHolder">
            <asp:Button ID="ButtonSubmit"  ValidationGroup="grupo1" runat="server" ToolTip="Información adicional" OnClick="ButtonSubmit_Click"
                OnClientClick="ButtonSubmit_Click" Text="Enviar solicitud"></asp:Button><input id="ButtonReset"
                    type='button' onclick='ClearAllControls()' value='Limpiar formulario' />
        </div>
    </div>
</asp:Content>
