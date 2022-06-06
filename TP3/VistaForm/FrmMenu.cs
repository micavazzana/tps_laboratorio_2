using System;
using System.Windows.Forms;

namespace VistaForm
{
    /// <summary>
    /// Clase del formulario principal del proyecto.
    /// Abre un menu para elegir que accion llevar a cabo
    /// </summary>
    public partial class FrmMenu : Form
    {
        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public FrmMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Crea e instancia un nuevo formulario donde se realizaran las reservas
        /// y cargaran los datos del cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRealizarReserva_Click(object sender, EventArgs e)
        {
            FrmRealizarReserva frmLista = new FrmRealizarReserva(true);
            frmLista.ShowDialog();
        }
        /// <summary>
        /// Crea e instancia un formulario que mostrara las reservas realizadas
        /// Permitira cancelar reservas o modificarlas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReservas_Click(object sender, EventArgs e)
        {
            FrmReservas frmReservas = new FrmReservas();
            frmReservas.ShowDialog();
        }
        /// <summary>
        /// Crea e instancia un formulario que traera solo los mails de los clientes
        /// Este servira para copiar los mail y realizar mailing de promociones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMails_Click(object sender, EventArgs e)
        {
            FrmMails frmMails = new FrmMails();
            frmMails.ShowDialog();
        }
    }
}
