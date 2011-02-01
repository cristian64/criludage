﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="AltaCliente.aspx.cs" Inherits="Sitio_Web.AltaCliente" %>

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
        Registro</h1>
    <div class="body">
        <div class="ctrlHolder">
            <label for="TextBoxUsuario">
                Usuario</label>
            <asp:TextBox ID="TextBoxUsuario" runat="server" Width="160px" ToolTip="Nombre de usuario"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxPassword">
                Contraseña</label>
            <asp:TextBox ID="TextBoxPassword" runat="server" Width="160px" ToolTip="Contraseña"
                TextMode="Password"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxPasswordConfirmar">
                Confirmar contraseña</label>
            <asp:TextBox ID="TextBoxPasswordConfirmar" runat="server" Width="160px" ToolTip="Confirmar contraseña"
                TextMode="Password"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxNombre">
                Nombre completo</label>
            <asp:TextBox ID="TextBoxNombre" runat="server" Width="160px" ToolTip="Nombre y apellidos"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxNif">
                NIF</label>
            <asp:TextBox ID="TextBoxNif" runat="server" Width="160px" ToolTip="Número de Identificación Fiscal"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxEmail">
                Correo electrónico</label>
            <asp:TextBox ID="TextBoxEmail" runat="server" Width="160px" ToolTip="Dirección de email"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxTelefono">
                Nº de teléfono</label>
            <asp:TextBox ID="TextBoxTelefono" runat="server" Width="160px" ToolTip="Número de teléfono de contacto"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxDireccion">
                Dirección</label>
            <asp:TextBox ID="TextBoxDireccion" runat="server" Width="160px" ToolTip="Dirección"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <label for="TextBoxInfo">
                Información adicional</label>
            <asp:TextBox ID="TextBoxInfo" runat="server" Width="160px" ToolTip="Información adicional"
                TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="ctrlHolder">
            <asp:Button ID="ButtonSubmit" runat="server" ToolTip="Información adicional" OnClick="ButtonSubmit_Click"
                OnClientClick="ButtonSubmit_Click" Text="Enviar"></asp:Button><input id="ButtonReset" type='button' onclick='ClearAllControls()' value='Limpiar'/>
        </div>
    </div>
</asp:Content>