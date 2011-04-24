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
using DevExpress.XtraWizard;

namespace Aplicación_de_Escritorio
{
    public partial class FormPrimeraVez : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        /// <summary>
        /// Indican si ya se han validado las 3 partes del asistente.
        /// Dado que una vez validado, el formulario se bloquea y no se vuelve a validar.
        /// </summary>
        private bool validadaUbicacion, validadoRegistro, validadoEmpleado;
        private Cliente cliente;
        private Desguace desguace;
        private Empleado empleado;

        public FormPrimeraVez()
        {
            InitializeComponent();

            // Se establecen algunos valores por defecto.
            textEditUDDI.Text = Configuracion.Default.uddi;
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
            Program.EmpleadoIdentificado = empleado;
            Program.ClienteIdentificado = cliente;
            Program.DesguaceIdentificado = desguace;
            Close();
        }

        /// <summary>
        /// Comprueba la página de ubicación.
        /// Si es incorrecta retrocede hasta dicha página y muestra los errores.
        /// </summary>
        /// <returns>Devuelve verdadero si los datos son correctos.</returns>
        private bool validarUbicacion()
        {
            bool correcto = true;

            // Comprobamos que la ruta de UDDI es correcta.
            Inquiry uddi = new Inquiry(textEditUDDI.Text);
            if (uddi.PuntoAccesoServicio("Criludage") != null)
            {
                
            }
            else
            {
                dxErrorProvider.SetError(textEditUDDI, "No se puede conectar al servidor de descubrimiento de servicios");
                wizardControl.SelectedPage = wizardPageUbicacionServidor;
                correcto = false;
            }

            if (correcto)
            {
                textEditUDDI.Properties.ReadOnly = true;
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
            bool correcto = true;

            if (textEditServicioUsuario.Text.Length <= 3)
            {
                dxErrorProvider.SetError(textEditServicioUsuario, "El nombre de usuario debe tener una longitud de 4 o más caracteres");
                correcto = false;
            }
            if (textEditServicioContrasena.Text.Length == 0)
            {
                dxErrorProvider.SetError(textEditServicioContrasena2, "Debe introducir una contraseña");
                correcto = false;
            }
            if (!textEditServicioContrasena.Text.Equals(textEditServicioContrasena2.Text))
            {
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
                int id = 0;

                try
                {
                    if (Program.TipoAplicacion == Program.TiposAplicacion.DESGUACE)
                    {
                        desguace = new Desguace();
                        desguace.Usuario = textEditServicioUsuario.Text;
                        desguace.Contrasena = Sha1.ComputeHash(textEditServicioContrasena.Text);
                        desguace.CorreoElectronico = textEditCorreoElectronico.Text;

                        desguace.Id = Program.InterfazRemota().RegistroDesguace(desguace.ENDesguace);
                        id = desguace.Id;
                    }
                    else
                    {
                        cliente = new Cliente();
                        cliente.Usuario = textEditServicioUsuario.Text;
                        cliente.Contrasena = Sha1.ComputeHash(textEditServicioContrasena.Text);
                        cliente.CorreoElectronico = textEditCorreoElectronico.Text;

                        cliente.Id = Program.InterfazRemota().RegistroCliente(cliente.ENCliente);
                        id = cliente.Id;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }

                if (id > 0)
                {
                    textEditServicioUsuario.Properties.ReadOnly = true;
                    textEditServicioContrasena.Properties.ReadOnly = true;
                    textEditServicioContrasena2.Properties.ReadOnly = true;
                    textEditCorreoElectronico.Properties.ReadOnly = true;
                    dropDownButtonTipoAplicacion.Enabled = false;
                    validadoRegistro = true;
                }
                else if (id == -1)
                {
                    dxErrorProvider.SetError(textEditServicioUsuario, "El nombre de usuario ya está en uso");
                    correcto = false;
                }
                else
                {
                    dxErrorProvider.SetError(textEditServicioUsuario, "Error desconocido durante el proceso de registro en el servidor");
                    correcto = false;
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
                dxErrorProvider.SetError(textEditContrasena2, "Debe introducir una contraseña");
                correcto = false;
            }
            if (!textEditContrasena.Text.Equals(textEditContrasena2.Text))
            {
                dxErrorProvider.SetError(textEditContrasena2, "Las contraseñas no coinciden");
                correcto = false;
            }

            if (correcto)
            {
                empleado = new Empleado();
                empleado.Usuario = textEditUsuario.Text;
                empleado.Administrador = true;
                empleado.Contrasena = Sha1.ComputeHash(textEditContrasena.Text);
                if (empleado.Guardar())
                {
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

        /// <summary>
        /// Valida todas las páginas.
        /// </summary>
        /// <returns></returns>
        private bool validar()
        {
            dxErrorProvider.SetError(textEditUDDI, "");
            dxErrorProvider.SetError(textEditServicioUsuario, "");
            dxErrorProvider.SetError(textEditServicioContrasena2, "");
            dxErrorProvider.SetError(textEditCorreoElectronico, "");
            dxErrorProvider.SetError(textEditUsuario, "");
            dxErrorProvider.SetError(textEditContrasena2, "");

            if (validadaUbicacion || validarUbicacion())
            {
                if (validadoRegistro || validarRegistro())
                {
                    if (validadoEmpleado || validarEmpleado())
                    {
                        // Se guarda la configuración establecida.
                        Configuracion.Default.uddi = textEditUDDI.Text;
                        Configuracion.Default.contrasena = Sha1.ComputeHash(textEditServicioContrasena.Text);
                        Configuracion.Default.usuario = textEditServicioUsuario.Text;
                        Configuracion.Default.correoelectronico = textEditCorreoElectronico.Text;
                        Configuracion.Default.desguace = Program.TipoAplicacion == Program.TiposAplicacion.DESGUACE;
                        Configuracion.Default.Save();

                        wizardPageFinalizar.AllowCancel = false;
                        wizardPageUbicacionServidor.AllowCancel = false;
                        wizardPageUsuarioServidor.AllowCancel = false;
                        wizardPagePrimerEmpleado.AllowCancel = false;
                        wizardPageBienvenida.AllowCancel = false;

                        Registro.WriteLine("Registro en la aplicación: " + Configuracion.Default.usuario);
                        return true;
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
            return false;
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

        private void wizardControl_SelectedPageChanging(object sender, DevExpress.XtraWizard.WizardPageChangingEventArgs e)
        {
            if (e.PrevPage == wizardPageEnviando && e.Direction == Direction.Forward)
            {
                if (!validar())
                    e.Cancel = true;
            }

            if (e.Page == wizardPageEnviando)
            {
                wizardControl.NextText = "&Enviar >";
            }
            else
            {
                wizardControl.NextText = "&Siguiente >";
            }
        }

        private void wizardControl_SelectedPageChanged(object sender, WizardPageChangedEventArgs e)
        {
            if (e.Page == wizardPageFinalizar)
                wizardControl.Pages.Remove(wizardPageEnviando);
        }
    }
}