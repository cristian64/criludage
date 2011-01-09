using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aplicación_de_Escritorio
{
    public partial class FormVerClienteDesguace : UserControl
    {
        public FormVerClienteDesguace(Cliente cliente)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            textEditId.Text = cliente.Id.ToString();
            textEditNif.Text = cliente.Nif;
            textEditCorreoElectronico.Text = cliente.CorreoElectronico;
            textEditNombre.Text = cliente.Nombre;
            textEditUsuario.Text = cliente.Usuario;
            textEditTelefono.Text = cliente.Telefono;
            memoEditDireccion.Text = cliente.Direccion;
            memoEditInformacionAdicional.Text = cliente.InformacionAdicional;
        }

        public FormVerClienteDesguace(Desguace desguace)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            textEditId.Text = desguace.Id.ToString();
            textEditNif.Text = desguace.Nif;
            textEditCorreoElectronico.Text = desguace.CorreoElectronico;
            textEditNombre.Text = desguace.Nombre;
            textEditUsuario.Text = desguace.Usuario;
            textEditTelefono.Text = desguace.Telefono;
            memoEditDireccion.Text = desguace.Direccion;
            memoEditInformacionAdicional.Text = desguace.InformacionAdicional;
        }
    }
}
