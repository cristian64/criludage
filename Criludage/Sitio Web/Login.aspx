<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Sitio_Web.Login" %>

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
        Acceso</h1>
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
        <div class="buttonHolder">
            <asp:Button ID="ButtonSubmit" runat="server" ToolTip="Información adicional" OnClick="ButtonSubmit_Click"
                OnClientClick="ButtonSubmit_Click" Text="Enviar"></asp:Button><input id="ButtonReset" type='button' onclick='ClearAllControls()' value='Limpiar'/>
        </div>
    </div>
</asp:Content>
