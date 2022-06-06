using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VistaForm
{
    public partial class FrmReservas : Form
    {
        List<Reserva> listadoDeReservas;
        
        /// <summary>
        /// 
        /// </summary>
        public FrmReservas()
        {
            InitializeComponent();
            TraerListado();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarReserva_Click(object sender, EventArgs e)
        {
            if (this.lstReservas.SelectedItem is not null)
            {
                int indice = this.listadoDeReservas.IndexOf((Reserva)this.lstReservas.SelectedItem);
                FrmRealizarReserva frm = new FrmRealizarReserva(this.listadoDeReservas[indice].EquiposReservados, this.listadoDeReservas[indice].Cliente);
                EliminarReserva(listadoDeReservas[indice]);
                frm.ShowDialog();
                listadoDeReservas.Clear();
                lstReservas.Items.Clear();
                TraerListado();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarReserva_Click(object sender, EventArgs e)
        {
            if (this.lstReservas.SelectedItem is not null)
            {
                int indice = this.listadoDeReservas.IndexOf((Reserva)this.lstReservas.SelectedItem);
                EliminarReserva(listadoDeReservas[indice]);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        private void EliminarReserva(Reserva reserva)
        {
            this.listadoDeReservas.Remove(reserva);
            this.lstReservas.Items.Remove(reserva);
            Serializadora<List<Reserva>>.SerializarJson("reservas.json", this.listadoDeReservas);          
            List<Equipo> listAux = Serializadora<List<Equipo>>.DeserializarJson("equiposEnStock.json");
            foreach (Equipo item in reserva.EquiposReservados)
            {
                listAux.Add(item);
                item.Estado = false;
            }
            Serializadora<List<Equipo>>.SerializarJson("equiposEnStock.json",listAux);
        }
        /// <summary>
        /// 
        /// </summary>
        private void TraerListado()
        {
            this.listadoDeReservas = Serializadora<List<Reserva>>.DeserializarJson("reservas.json");
            foreach (Reserva reserva in listadoDeReservas)
            {
                this.lstReservas.Items.Add(reserva);
            }
        }
    }
}
