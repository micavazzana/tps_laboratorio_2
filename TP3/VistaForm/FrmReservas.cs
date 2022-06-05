using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VistaForm
{
    public partial class FrmReservas : Form
    {
        List<Reserva> listadoDeReservas;

        public FrmReservas()
        {
            InitializeComponent();
            TraerListado();
        }

        private void btnModificarReserva_Click(object sender, EventArgs e)
        {

            if (this.lstReservas.SelectedItem is not null)
            {
                int indice = this.listadoDeReservas.IndexOf((Reserva)this.lstReservas.SelectedItem);
                FrmRealizarReserva frm = new FrmRealizarReserva(listadoDeReservas[indice].EquiposReservados, listadoDeReservas[indice].Cliente);
                frm.ShowDialog();
                EliminarReserva(listadoDeReservas[indice]);
                listadoDeReservas.Clear();
                lstReservas.Items.Clear();
                TraerListado();
            }
        }

        private void btnEliminarReserva_Click(object sender, EventArgs e)
        {
            if (this.lstReservas.SelectedItem is not null)
            {
                int indice = this.listadoDeReservas.IndexOf((Reserva)this.lstReservas.SelectedItem);
                EliminarReserva(listadoDeReservas[indice]);
            }
        }
        private void EliminarReserva(Reserva reserva)
        {
            this.listadoDeReservas.Remove(reserva);
            this.lstReservas.Items.Remove(reserva);
            GestoraArchivos<List<Reserva>>.SerializarJson("reservas.json", this.listadoDeReservas);
            //al eliminar debo devolver los equipos que tenia reservados a mi listado original
        }
        private void TraerListado()
        {
            this.listadoDeReservas = GestoraArchivos<List<Reserva>>.DeserializarJson("reservas.json");
            foreach (Reserva reserva in listadoDeReservas)
            {
                this.lstReservas.Items.Add(reserva);
            }
        }
    }
}
