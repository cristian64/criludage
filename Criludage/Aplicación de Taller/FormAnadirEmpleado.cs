using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Aplicación_de_Taller
{
    public partial class FormAnadirEmpleado : UserControl
    {
        public FormAnadirEmpleado()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Indica si el empleado que se va a crear es un administrador o no.
        /// </summary>
        public void Modo(bool administrador)
        {
            radioGroupAdministrador.SelectedIndex = administrador ? 1 : 0;
        }

        private void limpiarFormulario()
        {
            textEditNombre.Text = "";
            textEditUsuario.Text = "";
            textEditNif.Text = "";
            textEditCorreoElectronico.Text = "";
            radioGroupAdministrador.SelectedIndex = 0;
            textEditContrasena.Text = "";
            textEditContrasena2.Text = "";
        }

        private void simpleButtonAnadirEmpleado_Click(object sender, EventArgs e)
        {
            bool correcto = true;

            if (Empleado.Obtener(textEditUsuario.Text) != null)
            {
                FormBase.GetInstancia().MostrarMensaje("Nombre de usuario en uso", ""); //TODO
                correcto = false;
            }

            if (!textEditContrasena.Text.Equals(textEditContrasena2.Text))
            {
                FormBase.GetInstancia().MostrarMensaje("Contraseñas diferentes", ""); //TODO
                correcto = false;
            }

            if (correcto)
            {
                Empleado empleado = new Empleado();
                empleado.Nombre = textEditNombre.Text;
                empleado.Usuario = textEditUsuario.Text;
                empleado.Nif = textEditNif.Text;
                empleado.CorreoElectronico = textEditCorreoElectronico.Text;
                empleado.Administrador = radioGroupAdministrador.SelectedIndex == 1 ? true : false;
                empleado.Contrasena = sha1(textEditContrasena.Text);
                FormBase.GetInstancia().MostrarMensaje(empleado.Contrasena, "");

                if (empleado.Guardar())
                {
                    limpiarFormulario();
                    FormBase.GetInstancia().FormVerEmpleados.ProcesarEmpleado(empleado);
                    FormBase.GetInstancia().FormVerEmpleados.SeleccionarEmpleado(empleado);
                    FormBase.GetInstancia().MostrarVerEmpleados();
                }
                else
                {
                    FormBase.GetInstancia().MostrarMensaje("ERROR AL GUARDAR: esto es chungo no deberia ocurrir!", ""); //TODO
                }
            }
        }

        private static string sha1(string cadena)
        {
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(cadena));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        private void simpleButtonCancelar_Click(object sender, EventArgs e)
        {
            FormBase.GetInstancia().MostrarAnterior();
        }

        private void simpleButtonLimpiarFormulario_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }
    }
}
