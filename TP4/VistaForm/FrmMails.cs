using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VistaForm
{
    /// <summary>
    /// Clase que mostrara los mails de todos los clientes
    /// </summary>
    public partial class FrmMails : Form, IMostrarMensaje
    {
        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public FrmMails()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga los mails de los clientes en el rich text box
        /// trayendolos desde el archivo xml
        /// Comprueba para mostrarlos que no haya mails repetidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTraerXml_Click(object sender, EventArgs e)
        {
            try
            {
                this.rtbMails.Text = String.Empty;
                List<Cliente> clientes = Serializadora<List<Cliente>>.DeserializarXml("dataClientes.xml");
                clientes.Sort((c1, c2) => String.Compare(c1.Mail, c2.Mail));

                List<string> listaMailsAux = new List<string>();
                foreach (Cliente cliente in clientes)
                {
                    listaMailsAux.Add(cliente.Mail);
                }
                IEnumerable<string> listaMailsSinDuplicados = listaMailsAux.Distinct();
                foreach (string mail in listaMailsSinDuplicados)
                {
                    this.rtbMails.Text += mail + "\n";
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        /// <summary>
        /// Carga los mails de los clientes en el rich text box
        /// trayendolos desde la base de datos sql 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTraerSql_Click(object sender, EventArgs e)
        {
            try
            {
                this.rtbMails.Text = String.Empty;
                List<string> listaMails = GestorSqlCliente.LeerMailsSinDuplicados();
                foreach (string mail in listaMails)
                {
                    this.rtbMails.Text += mail + "\n";
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
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
            try
            {
                Clipboard.SetText(rtbMails.Text);
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }
        /// <summary>
        /// Muestra el error que las excepciones pueden arrojar y la excepcion original
        /// </summary>
        /// <param name="ex">La excepcion de la cual se mostrara el mensaje</param>
        public void MostrarMensajeError(Exception ex)
        {
            MessageBox.Show($"{ex.Message}\n{ex.InnerException}");
        }
    }
}
