using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;

namespace VistaForm
{
    /// <summary>
    /// Clase que mostrara los mails de todos los clientes
    /// </summary>
    public partial class FrmMails : Form
    {
        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public FrmMails()
        {
            InitializeComponent();
            TraerDatosClientes();
        }
        /// <summary>
        /// Carga los mails de los clientes en el rich text box
        /// </summary>
        private void TraerDatosClientes()
        {
            List<Cliente> clientes = GestoraArchivos<List<Cliente>>.DeserializarXml("dataClientes.xml");
            foreach (Cliente cliente in clientes)
            {
                this.rtbMails.Text += cliente.Mail + "\n";
            }
        }
        /// <summary>
        /// Copia el contenido del rich text box al portapapeles
        /// de forma que sea sencillo para el empleado pegarlos en un mail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbMails.Text);
        }
    }
}
