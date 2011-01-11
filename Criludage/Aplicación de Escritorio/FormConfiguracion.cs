using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Biblioteca_Común;

namespace Aplicación_de_Escritorio
{
    public partial class FormConfiguracion : UserControl
    {
        public FormConfiguracion()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            Cargar();
        }

        /// <summary>
        /// Carga el cliente identificado o el desguace identificado.
        /// </summary>
        public void Cargar()
        {
            if (Program.TipoAplicacion == Program.TiposAplicacion.TALLER)
            {
                textEditId.Text = Program.ClienteIdentificado.Id.ToString();
                textEditNif.Text = Program.ClienteIdentificado.Nif;
                textEditCorreoElectronico.Text = Program.ClienteIdentificado.CorreoElectronico;
                textEditNombre.Text = Program.ClienteIdentificado.Nombre;
                textEditUsuario.Text = Program.ClienteIdentificado.Usuario;
                textEditTelefono.Text = Program.ClienteIdentificado.Telefono;
                memoEditDireccion.Text = Program.ClienteIdentificado.Direccion;
                memoEditInformacionAdicional.Text = Program.ClienteIdentificado.InformacionAdicional;
                textEditContrasena.Text = "";
                textEditContrasena2.Text = "";
            }
            else
            {
                textEditId.Text = Program.DesguaceIdentificado.Id.ToString();
                textEditNif.Text = Program.DesguaceIdentificado.Nif;
                textEditCorreoElectronico.Text = Program.DesguaceIdentificado.CorreoElectronico;
                textEditNombre.Text = Program.DesguaceIdentificado.Nombre;
                textEditUsuario.Text = Program.DesguaceIdentificado.Usuario;
                textEditTelefono.Text = Program.DesguaceIdentificado.Telefono;
                memoEditDireccion.Text = Program.DesguaceIdentificado.Direccion;
                memoEditInformacionAdicional.Text = Program.DesguaceIdentificado.InformacionAdicional;
                textEditContrasena.Text = "";
                textEditContrasena2.Text = "";
            }
            simpleButtonGuardarCambios.Enabled = simpleButtonDescartarCambios.Enabled = false;
        }

        private void simpleButtonCancelar_Click(object sender, EventArgs e)
        {
            Cargar();
            FormBase.Instancia.MostrarNinguno();
            FormBase.Instancia.MostrarAnterior();
        }

        private void simpleButtonDescartarCambios_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void simpleButtonGuardarCambios_Click(object sender, EventArgs e)
        {
            bool correcto = true;

            dxErrorProvider.SetError(textEditContrasena, "");
            dxErrorProvider.SetError(textEditContrasena2, "");
            dxErrorProvider.SetError(textEditCorreoElectronico, "");

            // Si no se ha introducido nada en las contraseñas, significa que no se quieren cambiar.
            if (textEditContrasena.Text.Length != 0 || textEditContrasena2.Text.Length != 0)
            {
                if (!textEditContrasena.Text.Equals(textEditContrasena2.Text))
                {
                    dxErrorProvider.SetError(textEditContrasena, "Las contraseñas no coinciden");
                    dxErrorProvider.SetError(textEditContrasena2, "Las contraseñas no coinciden");
                    if (correcto)
                        textEditContrasena.Focus();
                    correcto = false;
                }
            }

            if (!new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*").IsMatch(textEditCorreoElectronico.Text))
            {
                dxErrorProvider.SetError(textEditCorreoElectronico, "El correo electrónico no tiene un formato correcto");
                correcto = false;
            }

            if (correcto)
            {
                if (Program.TipoAplicacion == Program.TiposAplicacion.TALLER)
                {
                    Cliente nuevo = new Cliente();
                    nuevo.Id = Program.ClienteIdentificado.Id;
                    nuevo.Usuario = Program.ClienteIdentificado.Usuario;

                    nuevo.Nombre = textEditNombre.Text;
                    nuevo.Nif = textEditNif.Text;
                    nuevo.CorreoElectronico = textEditCorreoElectronico.Text;
                    nuevo.Telefono = textEditTelefono.Text;
                    nuevo.Direccion = memoEditDireccion.Text;
                    nuevo.InformacionAdicional = memoEditInformacionAdicional.Text;

                    if (textEditContrasena.Text.Length > 0)
                        nuevo.Contrasena = Sha1.ComputeHash(textEditContrasena.Text);
                    else
                        nuevo.Contrasena = Program.ClienteIdentificado.Contrasena;

                    if (nuevo.Actualizar())
                    {
                        Program.ClienteIdentificado = nuevo;
                        simpleButtonGuardarCambios.Enabled = simpleButtonDescartarCambios.Enabled = false;

                        Configuracion.Default.correoelectronico = nuevo.CorreoElectronico;
                        Configuracion.Default.contrasena = nuevo.Contrasena;
                        Configuracion.Default.Save();
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Se produjo un error al guardar los datos en el servicio.", "Guardando información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Desguace nuevo = new Desguace();
                    nuevo.Id = Program.DesguaceIdentificado.Id;
                    nuevo.Usuario = Program.DesguaceIdentificado.Usuario;

                    nuevo.Nombre = textEditNombre.Text;
                    nuevo.Nif = textEditNif.Text;
                    nuevo.CorreoElectronico = textEditCorreoElectronico.Text;
                    nuevo.Telefono = textEditTelefono.Text;
                    nuevo.Direccion = memoEditDireccion.Text;
                    nuevo.InformacionAdicional = memoEditInformacionAdicional.Text;

                    if (textEditContrasena.Text.Length > 0)
                        nuevo.Contrasena = Sha1.ComputeHash(textEditContrasena.Text);
                    else
                        nuevo.Contrasena = Program.DesguaceIdentificado.Contrasena;

                    if (nuevo.Actualizar())
                    {
                        Program.DesguaceIdentificado = nuevo;
                        simpleButtonGuardarCambios.Enabled = simpleButtonDescartarCambios.Enabled = false;

                        Configuracion.Default.correoelectronico = nuevo.CorreoElectronico;
                        Configuracion.Default.contrasena = nuevo.Contrasena;
                        Configuracion.Default.Save();
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Se produjo un error al guardar los datos en el servicio.", "Guardando información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void todos_Modified(object sender, EventArgs e)
        {
            simpleButtonGuardarCambios.Enabled = simpleButtonDescartarCambios.Enabled = true;
        }
    }
}
