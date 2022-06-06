using Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace VistaForm
{
    /// <summary>
    /// Clase que da de alta reservas de equipos
    /// </summary>
    public partial class FrmRealizarReserva : Form, IMostrarMensaje
    {
        private List<Equipo> listadoEquiposDisponibles;
        private List<Equipo> listadoEquiposReservados;
        private List<Reserva> listadoDeReservas;
        private List<Cliente> listadoClientes = new List<Cliente>();
        private float costoFinal;

        /// <summary>
        /// Constructor del formulario
        /// Carga la lista de equipos que existen en stock
        /// Instancia las listas que manejara internamente el programa. 
        /// En caso de ser una nueva reserva instancia una nueva lista de equipos reservados
        /// </summary>
        public FrmRealizarReserva(bool nuevaReserva)
        {
            InitializeComponent();
            try
            {
                this.listadoEquiposDisponibles = Serializadora<List<Equipo>>.DeserializarJson("equiposEnStock.json");
                foreach (Equipo item in this.listadoEquiposDisponibles)
                {
                    this.lstEquipos.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
            if (nuevaReserva)
            {
                this.listadoEquiposReservados = new List<Equipo>();
            }
            this.listadoDeReservas = new List<Reserva>();
        }
        /// <summary>
        /// SobreCarga del constructor del formulario
        /// Se instanciara un nuevo formulario con parametros cuando se quiera modificar una reserva existente
        /// Se reutiliza el constructor pasandole un "false" para que no instancie una nueva lista
        /// Utilizara los parametros que recibe para cargar los campos
        /// </summary>
        /// <param name="list">El listado de equipos que tenia reservado el cliente</param>
        /// <param name="cliente">El cliente para cargar sus datos</param>
        public FrmRealizarReserva(List<Equipo> list, Cliente cliente)
            : this(false)
        {
            this.listadoEquiposReservados = list;
            foreach (Equipo item in this.listadoEquiposReservados)
            {
                this.lstReservas.Items.Add(item);
            }
            this.txtNombre.Text = cliente.Nombre;
            this.txtApellido.Text = cliente.Apellido;
            this.txtDni.Text = cliente.Dni;
            this.dtpFechaReserva.Value = cliente.FechaReserva;
            this.txtMail.Text = cliente.Mail;
            this.checkEsEstudiante.Checked = cliente.EsEstudiante;
        }
        /// <summary>
        /// Agrega el item seleccionado a un listado de equipos reservados
        /// Muestra ese item en un list box destinado a ello
        /// Quita ese item del listado de equipos disponibles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Equipo)this.lstEquipos.SelectedItem is not null)
                {
                    this.lblItemNoSeleccionado.Visible = false;
                    foreach (Equipo item in this.listadoEquiposDisponibles)
                    {
                        if ((Equipo)this.lstEquipos.SelectedItem is not null
                            && item == (Equipo)this.lstEquipos.SelectedItem
                            && item.Estado == false)
                        {
                            this.listadoEquiposReservados.Add(item);
                            this.lstReservas.Items.Add(this.lstEquipos.SelectedItem);
                            item.Estado = true;
                        }
                    }
                    int indice = this.listadoEquiposDisponibles.IndexOf((Equipo)this.lstEquipos.SelectedItem);
                    this.lstEquipos.Items.Remove(this.lstEquipos.SelectedItem);
                    this.listadoEquiposDisponibles.Remove(listadoEquiposDisponibles[indice]);
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
        /// Elimina en caso de arrepentimiento el item seleccionado del listado de equipos reservados
        /// Lo devuelve al listado original(listado de equipo disponible)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Equipo)this.lstReservas.SelectedItem is not null)
                {
                    this.lblItemNoSeleccionado.Visible = false;
                    foreach (Equipo item in this.listadoEquiposReservados)
                    {
                        if ((Equipo)this.lstReservas.SelectedItem is not null
                            && item == (Equipo)this.lstReservas.SelectedItem
                            && item.Estado == true)
                        {
                            this.listadoEquiposDisponibles.Add(item);
                            this.lstEquipos.Items.Add(item);
                            item.Estado = false;
                        }
                    }
                    int indice = this.listadoEquiposReservados.IndexOf((Equipo)this.lstReservas.SelectedItem);
                    this.lstReservas.Items.Remove(this.lstReservas.SelectedItem);
                    this.listadoEquiposReservados.Remove(listadoEquiposReservados[indice]);
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
        /// Carga la nueva reserva:
        /// Crea un nuevo cliente con un id de reserva unico
        /// Crea la nueva reserva y la agrega a un listado
        /// Crea un nuevo ticket de reserva con todos los datos de la reserva
        /// Actualiza los equipos disponibles, quitando aquellos que son parte de la reserva
        /// Resetea los campos para poder volver a ser cargados con una nueva reserva
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.lstReservas.Text) && String.IsNullOrEmpty(this.txtNombre.Text)
                && String.IsNullOrEmpty(this.txtApellido.Text) && String.IsNullOrEmpty(this.txtDni.Text)
                && this.dtpFechaReserva.Value < DateTime.Now && String.IsNullOrEmpty(this.txtMail.Text))
                {
                    MessageBox.Show("Debe completar los campos");
                }
                else
                {
                    //Creo un nuevo cliente y guardo xml
                    Cliente cliente = CrearCliente();
                    //Creo una nueva reserva y la guardo en un listado
                    CrearListaReservas(cliente);
                    //Creo un recibo
                    string ticket = CrearTicketDeReserva(cliente);
                    //Actualizo mi listado de equipos disponibles
                    Serializadora<List<Equipo>>.SerializarJson("equiposEnStock.json", this.listadoEquiposDisponibles);

                    //LIMPIO LOS CAMPOS Y LISTADOS
                    this.lstReservas.Items.Clear();
                    this.txtNombre.Text = String.Empty;
                    this.txtApellido.Text = String.Empty;
                    this.txtDni.Text = String.Empty;
                    this.txtMail.Text = String.Empty;
                    this.listadoEquiposReservados.Clear();
                    this.listadoDeReservas.Clear();

                    MessageBox.Show(ticket, "Reserva confirmada");
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }
        /// <summary>
        /// Instancia un nuevo cliente con los datos cargados y guarda todos sus datos en un xml
        /// </summary>
        /// <returns>El cliente dado de alta</returns>
        /// <exception cref="Exception">Arroja una nueva Excepcion que contiene o bien un ArchivoException
        /// o contiene una excepcion arrojada al crear el nuevo id</exception>
        private Cliente CrearCliente()
        {
            Cliente cliente = new Cliente(this.txtNombre.Text, this.txtApellido.Text, this.txtDni.Text, this.dtpFechaReserva.Value, this.txtMail.Text);
            try
            {
                if (checkEsEstudiante.Checked)
                {
                    cliente.EsEstudiante = true;
                }
                cliente.IdReserva = CrearNuevoNumeroAutoIncremental("ids.txt");
                this.listadoClientes = Serializadora<List<Cliente>>.DeserializarXml("dataClientes.xml");
                this.listadoClientes.Add(cliente);
                Serializadora<List<Cliente>>.SerializarXml("dataClientes.xml", this.listadoClientes);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el cliente", ex.InnerException);
            }
            return cliente;
        }
        /// <summary>
        ///Crea un nuevo numero autoincremental, 
        /// reservando siempre el ultimo otorgado 
        /// y creando uno nuevo a partir del ultimo guardado
        /// </summary>
        /// <param name="nombreArchivo">El nombre del archivo donde guardara y levantara el numero autoincrementado</param>
        /// <returns>El nuevo id creado</returns>
        /// <exception cref="Exception">Arroja una nueva excepcion que contendra la excepcion ArchivoException
        /// o una excepcion arrojada por el metodo Parse</exception>
        private int CrearNuevoNumeroAutoIncremental(string nombreArchivo)
        {
            int id = 0;
            try
            {
                id = int.Parse(GestorArchivosTexto.LeerArchivoTexto(nombreArchivo));
                id++;
                GestorArchivosTexto.EscribirArchivoTexto(nombreArchivo, $"{id}");
            }
            catch (Exception ex)
            {
                throw new Exception("No pudo crearse el numero correctamente", ex.InnerException);
            }
            return id;
        }
        /// <summary>
        /// Crea una nueva reserva, guardando los datos del cliente y los equipos que alquilo
        /// Guardo en un archivo Json esta nueva reserva realizada
        /// </summary>
        /// <param name="cliente">El cliente que guardara en la reserva</param>
        /// <exception cref="Exception">Arroja una nueva excepcion que contendra un ArchivoException</exception>
        private void CrearListaReservas(Cliente cliente)
        {
            try
            {
                Reserva reserva = new Reserva(cliente, this.listadoEquiposReservados, cliente.IdReserva);
                costoFinal = reserva.CalcularCostoTotal(listadoEquiposReservados, cliente.EsEstudiante);
                //Revisar:No me deja levantar las reservas si internamente apendeo al crear el StreamWriter:
                //Necesito deserializar primero para poder sumar una nueva reserva
                this.listadoDeReservas = Serializadora<List<Reserva>>.DeserializarJson("reservas.json");
                this.listadoDeReservas.Add(reserva);
                Serializadora<List<Reserva>>.SerializarJson("reservas.json", this.listadoDeReservas);
            }
            catch (Exception ex)
            {
                throw new Exception("Error de archivo", ex.InnerException);
            }
        }
        /// <summary>
        /// Crea un recibo con los datos del cliente, los equipos reservados y un numero de id de reserva
        /// </summary>
        /// <param name="cliente">Los datos del cliente a guardar</param>
        /// <returns>Una cadena con los datos</returns>
        /// <exception cref="Exception">Arroja una nueva excepcion que contendra la excepcion ArchivoException
        /// o una excepcion arrojada por el metodo Parse</exception>
        private string CrearTicketDeReserva(Cliente cliente)
        {
            StringBuilder equipos = new StringBuilder();
            foreach (Equipo item in this.listadoEquiposReservados)
            {
                equipos.AppendLine(item.ToString());

            }
            string numTicket = $"{CrearNuevoNumeroAutoIncremental("numeroTicket.txt")}";
            string contenido =
                $"Recibo: {numTicket}\n" +
                $"{cliente.Nombre} {cliente.Apellido} " +
                $"\nFecha de reserva: {cliente.FechaReserva.ToShortDateString()}" +
                $"\nId Reserva:{cliente.IdReserva}" +
                $"\nCosto total: ${this.costoFinal}" +
                $"\nEquipos Reservados:\n{equipos}";
            try
            {
                GestorArchivosTexto.EscribirArchivoTexto($"\\Recibos\\Ticket {numTicket}.txt", contenido);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex.InnerException);
            }
            return contenido;
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