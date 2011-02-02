<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarPerfil.aspx.cs" Inherits="Sitio_Web.EditarPerfil" %>
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
        Editar perfil</h1>

    <div class="body">

        <asp:RequiredFieldValidator Display="None" EnableClientScript="true" ID="RequiredFieldValidatorNombre" runat="server"
            ControlToValidate="TextBoxUsuario" ErrorMessage="Nombre de usuario obligatorio"
            ValidationGroup="grupo1"></asp:RequiredFieldValidator>
        <asp:CompareValidator Display="None" EnableClientScript="true" ID="CompareValidatorPassword" runat="server"
            ErrorMessage="La contraseña no coincide" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxPasswordConfirmar"
            ValidationGroup="grupo1"></asp:CompareValidator>
        <asp:RequiredFieldValidator Display="None" EnableClientScript="true" ID="RequiredFieldValidatorDNI" runat="server"
            ControlToValidate="TextBoxNif" ErrorMessage="NIF obligatorio"
            ValidationGroup="grupo1"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator Display="None" EnableClientScript="true" ID="RegularExpressionValidatorDNI"
            runat="server" ControlToValidate="TextBoxNif" ErrorMessage="DNI incorrecto" ValidationExpression="^(([A-Z]\d{8})|(\d{8}[A-Z]))$"
            ValidationGroup="grupo1"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator Display="None" EnableClientScript="true" ID="RequiredFieldValidatorNombreCompleto"
            runat="server" ControlToValidate="TextBoxNombre" ErrorMessage="Nombre completo obligatorio"
            ValidationGroup="grupo1"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator Display="None" EnableClientScript="true" ID="RegularExpressionValidatorTelefono"
            runat="server" ControlToValidate="TextBoxTelefono" ErrorMessage="Teléfono inválido"
            ValidationExpression="^\d{9}$" ValidationGroup="grupo1"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator Display="None" EnableClientScript="true" ID="RequiredFieldValidatorTelefono" runat="server"
            ControlToValidate="TextBoxTelefono" ErrorMessage="Teléfono obligatorio"
            ValidationGroup="grupo1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator Display="None" EnableClientScript="true" ID="RequiredFieldValidatorEmail" runat="server"
            ControlToValidate="TextBoxEmail" ErrorMessage="Correo electrónico obligatorio"
            ValidationGroup="grupo1"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator Display="None" EnableClientScript="true" ID="RegularExpressionValidatorEmail"
            runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Correo electrónico inválido"
            ValidationExpression="^\w+@(\w+.)+\w+$" ValidationGroup="grupo1"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator Display="None" EnableClientScript="true" ID="RequiredFieldValidatorDireccion" runat="server"
            ControlToValidate="TextBoxDireccion" ErrorMessage="Dirección obligatoria"
            ValidationGroup="grupo1"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator Display="None" EnableClientScript="true" ID="RegularExpressionValidatorDireccion"
            runat="server" ControlToValidate="TextBoxDireccion" ErrorMessage="Dirección inválida"
            ValidationExpression="^[0-9A-Za-zçÇñÑºªáéíóúÁÉÍÓÚÈÒèòàÀïüÜÏ'·/ ]+$" ValidationGroup="grupo1"></asp:RegularExpressionValidator>
        
        <div class="ctrlHolder">
            <label for="TextBoxUsuario">
                Usuario</label>
            <asp:TextBox ValidationGroup="grupo1" ID="TextBoxUsuario" runat="server" Width="160px"
                ToolTip="Nombre de usuario" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxPassword">
                Nueva contraseña</label>
            <asp:TextBox ValidationGroup="grupo1" ID="TextBoxPassword" runat="server" Width="160px" ToolTip="Contraseña"
                TextMode="Password"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxPasswordConfirmar">
                Confirma contraseña</label>
            <asp:TextBox ValidationGroup="grupo1" ID="TextBoxPasswordConfirmar" runat="server" Width="160px" ToolTip="Confirmar contraseña"
                TextMode="Password"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxNombre">
                Nombre completo</label>
            <asp:TextBox ValidationGroup="grupo1" ID="TextBoxNombre" runat="server" Width="160px" ToolTip="Nombre y apellidos"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxNif">
                NIF</label>
            <asp:TextBox ValidationGroup="grupo1" ID="TextBoxNif" runat="server" Width="160px" ToolTip="Número de Identificación Fiscal"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxEmail">
                Correo electrónico</label>
            <asp:TextBox ValidationGroup="grupo1" ID="TextBoxEmail" runat="server" Width="160px" ToolTip="Dirección de email"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxTelefono">
                Nº de teléfono</label>
            <asp:TextBox ValidationGroup="grupo1" ID="TextBoxTelefono" runat="server" Width="160px" ToolTip="Número de teléfono de contacto"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxDireccion">
                Dirección</label>
            <asp:TextBox ValidationGroup="grupo1" ID="TextBoxDireccion" runat="server" Width="160px" ToolTip="Dirección" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxInfo">
                Información adicional</label>
            <asp:TextBox ID="TextBoxInfo" runat="server" Width="160px" ToolTip="Información adicional"
                TextMode="MultiLine"></asp:TextBox>
        </div>

        <ASP:ValidationSummary CssClass="ErrorSummary" ID="ValidationSummary1" ValidationGroup="grupo1" runat="server"
            RenderMode="BulletedList" HeaderText="<p>Se han encontrado los siguientes errores: </p>">
        </ASP:ValidationSummary>

        <div class="buttonHolder">
            <asp:Button  ValidationGroup="grupo1" ID="ButtonSubmit" runat="server" ToolTip="Información adicional" OnClick="ButtonSubmit_Click"
                OnClientClick="ButtonSubmit_Click" Text="Enviar"></asp:Button><input id="ButtonReset" type='button' onclick='ClearAllControls()' value='Limpiar'/><input id="Button1" type='button' onclick="javascript:history.back(); return false" value='Cancelar'/>
        </div>
    </div>
</asp:Content>
