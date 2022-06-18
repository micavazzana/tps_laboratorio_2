using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VistaForm
{
    /// <summary>
    /// Clase que muestra las reservas realizadas activas
    /// </summary>
    public partial class FrmReservas : Form, IMostrarMensaje
    {
        List<Reserva> listadoDeReservas;
        int indice;

        /// <summary>
        /// Constructor del formulario
        /// Trae el listado de reservas
        /// </summary>
        public FrmReservas()
        {
            InitializeComponent();
            TraerListado();
        }
        /// <summary>
        /// Modifica los datos de una reserva
        /// en caso de que el cliente quiera cancelar alguno de los equipos que eligio
        /// o en caso de que quiera agregar mas equipos a su reserva
        /// Tambien se puede modificar algun campo errado de la carga del cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstReservas.SelectedItem is not null)
                {
                    indice = this.listadoDeReservas.IndexOf((Reserva)this.lstReservas.SelectedItem);
                    FrmRealizarReserva frm = new FrmRealizarReserva(this.listadoDeReservas[indice].EquiposReservados, this.listadoDeReservas[indice].Cliente);

                    //Si confirma la modificacion
                    //el metodo EliminarReserva eliminara la reserva seleccionada
                    //Caso contrario el metodo la conservara en el listado
                    frm.OnConfirmaModificacion += EliminarReserva;
                    frm.ShowDialog();

                    this.listadoDeReservas.Clear();
                    this.lstReservas.Items.Clear();
                    TraerListado();
                }
                else
                {
                    this.lblItemNoSeleccionado.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }
        /// <summary>
        /// Da de baja una reserva del listado.
        /// En caso de que cancele el pedido o en caso de devolucion de los equipos al finalizar su alquiler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstReservas.SelectedItem is not null)
                {
                    indice = this.listadoDeReservas.IndexOf((Reserva)this.lstReservas.SelectedItem);
                    EliminarReserva(true);
                }
                else
                {
                    this.lblItemNoSeleccionado.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }

        /// <summary>
        /// Elimina la reserva seleccionada
        /// Metodo que se llama tanto para eliminar una reserva como para realizar una modificacion
        /// </summary>
        /// <param name="reserva"></param>
        private void EliminarReserva(bool confirmaEliminacion)
        {
            Reserva reserva = this.listadoDeReservas[indice];
            try
            {
                if (confirmaEliminacion)
                {
                    this.listadoDeReservas.Remove(reserva);
                    this.lstReservas.Items.Remove(reserva);
                    Serializadora<List<Reserva>>.SerializarJson("reservas.json", this.listadoDeReservas);

                    //Una vez eliminada la reserva prosigo a devolver los equipos al listado original:
                    List<Equipo> listAux = Serializadora<List<Equipo>>.DeserializarJson("equiposEnStock.json");
                    foreach (Equipo item in reserva.EquiposReservados)
                    {
                        listAux.Add(item);
                        item.Estado = false;
                    }
                    Serializadora<List<Equipo>>.SerializarJson("equiposEnStock.json", listAux);
                }               
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }
        /// <summary>
        /// Trae el listado de reservas guardado
        /// </summary>
        private void TraerListado()
        {
            try
            {
                this.listadoDeReservas = Serializadora<List<Reserva>>.DeserializarJson("reservas.json");
                foreach (Reserva reserva in this.listadoDeReservas)
                {
                    this.lstReservas.Items.Add(reserva);
                }
                //Metodo de extension: cuenta reservas activas
                this.lblCantReservasActivas.Text = $"Cantidad de reservas activas: {listadoDeReservas.ContarCantidadReservas()}";
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