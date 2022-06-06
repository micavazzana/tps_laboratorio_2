using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

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
            List<Cliente> clientes = Serializadora<List<Cliente>>.DeserializarXml("dataClientes.xml");
            foreach (Cliente cliente in clientes)
            {
                this.rtbMails.Text += cliente.Mail + "\n";
            }

            //Esto me serviria para eliminar mails duplicados usando: using System.Linq;
            //List<Cliente> clientesSinMailDuplicado = (from item in clientes group item by new {item.Mail} into grupo select new Cliente() { Mail = grupo.Key.Mail }).ToList();
            //https://docs.microsoft.com/es-es/dotnet/csharp/linq/group-query-results
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
