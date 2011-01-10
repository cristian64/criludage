using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Biblioteca_Común;
using System.Text.RegularExpressions;

namespace Aplicación_de_Escritorio
{
    public partial class FormPrimeraVez : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        /// <summary>
        /// Indican si ya se han validado las 3 partes del asistente.
        /// Dado que una vez validado, el formulario se bloquea.
        /// </summary>
        private bool validadaUbicacion, validadoRegistro, validadoEmpleado;

        public FormPrimeraVez()
        {
            InitializeComponent();

            // Se establecen algunos valores por defecto.
            textEditServicioWeb.Text = Configuracion.Default.servicioweb;
            textEditActiveMq.Text = Configuracion.Default.activemq;
            dropDownButtonTipoAplicacion_Click(null, null);

            // Traemos la aplicación al frente.
            BringToFront();
            Activate();
        }

        private void barButtonItemSalir_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItemAcercaDe_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FormAcercaDe().Show();
        }

        private void wizardControl_CancelClick(object sender, CancelEventArgs e)
        {
            Close();
        }

        private void wizardControl_FinishClick(object sender, CancelEventArgs e)
        {
            dxErrorProvider.SetError(textEditServicioWeb, "");
            dxErrorProvider.SetError(textEditActiveMq, "");
            dxErrorProvider.SetError(textEditServicioUsuario, "");
            dxErrorProvider.SetError(textEditServicioContrasena, "");
            dxErrorProvider.SetError(textEditServicioContrasena2, "");
            dxErrorProvider.SetError(textEditCorreoElectronico, "");
            dxErrorProvider.SetError(textEditUsuario, "");
            dxErrorProvider.SetError(textEditContrasena, "");
            dxErrorProvider.SetError(textEditContrasena2, "");

            if (validadaUbicacion || validarUbicacion())
            {
                if (validadoRegistro || validarRegistro())
                {
                    if (validadoEmpleado || validarEmpleado())
                    {
                        // TODO: guardar config si todo ha ido bien. pero el cabron de jorge me puo
                        // resulta que el resources es mas readonly que mis cojones xD
                        Close();
                    }
                    else
                    {
                        wizardControl.SelectedPage = wizardPagePrimerEmpleado;
                    }
                }
                else
                {
                    wizardControl.SelectedPage = wizardPageUsuarioServidor;
                }
            }
            else
            {
                wizardControl.SelectedPage = wizardPageUbicacionServidor;
            }
        }

        /// <summary>
        /// Comprueba la página de ubicación.
        /// Si es incorrecta retrocede hasta dicha página y muestra los errores.
        /// </summary>
        /// <returns>Devuelve verdadero si los datos son correctos.</returns>
        private bool validarUbicacion()
        {
            Console.WriteLine("valido ubicacion");
            bool correcto = true;

            // Comprobamos que la ruta del servicio web es correcta.
            try
            {
                Program.InterfazRemota.Url = textEditServicioWeb.Text;
                Program.InterfazRemota.Inicializar();
            }
            catch (Exception)
            {
                dxErrorProvider.SetError(textEditServicioWeb, "No se puede conectar al servicio web");
                wizardControl.SelectedPage = wizardPageUbicacionServidor;
                correcto = false;
            }

            // Comprobamos que la ruta de ActiveMQ es correcta.
            Consumidor consumidor = new Consumidor();
            if (consumidor.Conectar(textEditActiveMq.Text, Configuracion.Default.topic))
            {
                consumidor.Desconectar();
            }
            else
            {
                dxErrorProvider.SetError(textEditActiveMq, "No se puede conectar al servidor de mensajería");
                correcto = false;
            }

            if (correcto)
            {
                textEditActiveMq.Properties.ReadOnly = true;
                textEditServicioWeb.Properties.ReadOnly = true;
                validadaUbicacion = true;
            }

            return correcto;
        }

        /// <summary>
        /// Comprueba la página de registro en el servicio.
        /// Si es incorrecta retrocede hasta dicha página y muestra los errores.
        /// </summary>
        /// <returns>Devuelve verdadero si los datos son correctos.</returns>
        private bool validarRegistro()
        {
            Console.WriteLine("valido registro");
            bool correcto = true;

            if (textEditServicioUsuario.Text.Length <= 3)
            {
                dxErrorProvider.SetError(textEditServicioUsuario, "El nombre de usuario debe tener una longitud de 4 o más caracteres");
                correcto = false;
            }
            if (textEditServicioContrasena.Text.Length == 0)
            {
                dxErrorProvider.SetError(textEditServicioContrasena, "Debe introducir una contraseña");
                correcto = false;
            }
            if (!textEditServicioContrasena.Text.Equals(textEditServicioContrasena2.Text))
            {
                dxErrorProvider.SetError(textEditServicioContrasena, "Las contraseñas no coinciden");
                dxErrorProvider.SetError(textEditServicioContrasena2, "Las contraseñas no coinciden");
                correcto = false;
            }
            if (!new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*").IsMatch(textEditCorreoElectronico.Text))
            {
                dxErrorProvider.SetError(textEditCorreoElectronico, "El correo electrónico no tiene un formato correcto");
                correcto = false;
            }

            if (correcto)
            {
                Desguace desguace = null;
                Cliente cliente = null;

                if (Program.TipoAplicacion == Program.TiposAplicacion.DESGUACE)
                {
                    desguace = new Desguace();
                    desguace.Usuario = textEditServicioUsuario.Text;
                    desguace.Contrasena = Sha1.ComputeHash(textEditServicioContrasena.Text);
                    desguace.CorreoElectronico = textEditCorreoElectronico.Text;

                    desguace.Id = Program.InterfazRemota.RegistroDesguace(desguace.ENDesguace);
                    correcto = desguace.Id > 0;
                }
                else
                {
                    cliente = new Cliente();
                    cliente.Usuario = textEditServicioUsuario.Text;
                    cliente.Contrasena = Sha1.ComputeHash(textEditServicioContrasena.Text);
                    cliente.CorreoElectronico = textEditCorreoElectronico.Text;

                    cliente.Id = Program.InterfazRemota.RegistroCliente(cliente.ENCliente);
                    correcto = cliente.Id > 0;
                }

                if (correcto)
                {
                    Program.ClienteIdentificado = cliente;
                    Program.DesguaceIdentificado = desguace;
                    textEditServicioUsuario.Properties.ReadOnly = true;
                    textEditServicioContrasena.Properties.ReadOnly = true;
                    textEditServicioContrasena2.Properties.ReadOnly = true;
                    textEditCorreoElectronico.Properties.ReadOnly = true;
                    dropDownButtonTipoAplicacion.Enabled = false;
                    validadoRegistro = true;
                }
                else
                {
                    dxErrorProvider.SetError(textEditServicioUsuario, "El nombre de usuario ya está en uso");
                }
            }

            return correcto;
        }

        /// <summary>
        /// Comprueba la página de registro del primer empleado.
        /// Si es incorrecta retrocede hasta dicha página y muestra los errores.
        /// </summary>
        /// <returns>Devuelve verdadero si los datos son correctos.</returns>
        private bool validarEmpleado()
        {
            Console.WriteLine("valido empleado");
            bool correcto = true;

            if (textEditUsuario.Text.Length <= 3)
            {
                dxErrorProvider.SetError(textEditUsuario, "El nombre de usuario debe tener una longitud de 4 o más caracteres");
                correcto = false;
            }
            if (Empleado.Obtener(textEditUsuario.Text) != null)
            {
                dxErrorProvider.SetError(textEditUsuario, "El nombre de usuario ya está siendo utilizado");
                correcto = false;
            }
            if (textEditContrasena.Text.Length == 0)
            {
                dxErrorProvider.SetError(textEditContrasena, "Debe introducir una contraseña");
                correcto = false;
            }
            if (!textEditContrasena.Text.Equals(textEditContrasena2.Text))
            {
                dxErrorProvider.SetError(textEditContrasena, "Las contraseñas no coinciden");
                dxErrorProvider.SetError(textEditContrasena2, "Las contraseñas no coinciden");
                correcto = false;
            }

            if (correcto)
            {
                Empleado empleado = new Empleado();
                empleado.Usuario = textEditUsuario.Text;
                empleado.Administrador = true;
                empleado.Contrasena = Sha1.ComputeHash(textEditContrasena.Text);
                if (empleado.Guardar())
                {
                    Program.EmpleadoIdentificado = empleado;
                    textEditUsuario.Properties.ReadOnly = true;
                    textEditContrasena.Properties.ReadOnly = true;
                    textEditContrasena2.Properties.ReadOnly = true;
                    validadoEmpleado = true;
                }
                else
                {
                    correcto = false;
                }
            }

            return correcto;
        }

        private void barButtonItemDesguace_ItemClick(object sender, ItemClickEventArgs e)
        {
            dropDownButtonTipoAplicacion.Text = "Desguace";
            dropDownButtonTipoAplicacion.Image = barButtonItemDesguace.Glyph;
            Program.TipoAplicacion = Program.TiposAplicacion.DESGUACE;
        }

        private void barButtonItemTaller_ItemClick(object sender, ItemClickEventArgs e)
        {
            dropDownButtonTipoAplicacion.Text = "Taller";
            dropDownButtonTipoAplicacion.Image = barButtonItemTaller.Glyph;
            Program.TipoAplicacion = Program.TiposAplicacion.TALLER;
        }

        private void dropDownButtonTipoAplicacion_Click(object sender, EventArgs e)
        {
            if (dropDownButtonTipoAplicacion.Text.Equals("Taller"))
            {
                barButtonItemDesguace_ItemClick(null, null);
            }
            else
            {
                barButtonItemTaller_ItemClick(null, null);
            }
        }
    }
}