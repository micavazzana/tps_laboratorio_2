using Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaForm
{
    /// <summary>
    /// Clase que da de alta reservas de equipos
    /// </summary>
    public partial class FrmRealizarReserva : Form, IMostrarMensaje, ICostoTotal
    {
        //Declaracion de un evento
        public event DelegadoConfirmaModificacion OnConfirmaModificacion;

        private List<Equipo> listadoEquiposDisponibles;
        private List<Equipo> listadoEquiposReservados;
        private List<Reserva> listadoDeReservas;
        private List<Cliente> listadoClientes = new List<Cliente>();

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
            this.lblPresupuesto.Text = $"{ICostoTotal.CalcularPresupuesto(listadoEquiposReservados, cliente.EsEstudiante)}";
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
                    Task.Run(() => MostrarPresupuestoFinal(listadoEquiposReservados, this.checkEsEstudiante.Checked));
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
                    Task.Run(() => MostrarPresupuestoFinal(listadoEquiposReservados, this.checkEsEstudiante.Checked));
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
                    //En caso de ser una modificacion, envio la confirmacion de la modificacion
                    //a traves de un evento
                    if (this.OnConfirmaModificacion is not null)
                        this.OnConfirmaModificacion.Invoke(true);

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
                if (this.checkEsEstudiante.Checked)
                {
                    cliente.EsEstudiante = true;
                }
                //Agrego el manejo de los clientes a traves de una conexion a bases de datos
                GestorSqlCliente.AltaCliente(cliente);

                //Sigo guardando los datos en un xml(Sostengo lo hecho en tp3)
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
        /// Crea un nuevo numero autoincremental, 
        /// reservando siempre el ultimo otorgado 
        /// y creando uno nuevo a partir del ultimo guardado
        /// </summary>
        /// <param name="nombreArchivo">El nombre del archivo donde guardara y levantara el numero autoincrementado</param>
        /// <returns>El nuevo id creado</returns>
        /// <exception cref="Exception">Arroja una nueva excepcion que contendra la excepcion ArchivoException
        /// o una excepcion arrojada por el metodo Parse</exception>
        private int CrearNuevoNumeroAutoIncremental(string nombreArchivo)
        {
            int numero = 0;
            try
            {
                numero = int.Parse(GestorArchivosTexto.LeerArchivoTexto(nombreArchivo));
                numero++;
                GestorArchivosTexto.EscribirArchivoTexto(nombreArchivo, $"{numero}");
            }
            catch (Exception ex)
            {
                throw new Exception("No pudo crearse el numero correctamente", ex.InnerException);
            }
            return numero;
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
                $"\nCosto total: ${ICostoTotal.CalcularPresupuesto(listadoEquiposReservados, this.checkEsEstudiante.Checked)}" +
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

        /// <summary>
        /// Chequea el cambio de estado del checkBox esEstudiante
        /// para poder realizar en tiempo real el calculo del presupuesto final
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkEsEstudiante_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => MostrarPresupuestoFinal(listadoEquiposReservados, this.checkEsEstudiante.Checked));
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }
        /// <summary>
        /// Muestra y calcula el presupuesto final de lo que se esta eligiendo.
        /// Chequea si la modificacion del label para mostrarlo esta queriendo ser modificado
        /// desde un hilo secundario, si es asi, lo vuelve a invocar como hilo principal para poder cambiarlo
        /// </summary>
        /// <param name="listado"></param>
        /// <param name="esEstudiante"></param>
        public void MostrarPresupuestoFinal(List<Equipo> listado, bool esEstudiante)
        {
            try
            {
                if (this.lblPresupuesto.InvokeRequired)
                {
                    DelegadoPresupuestoTotal mostrarPresupuesto = MostrarPresupuestoFinal;
                    object[] argumentos = { listado, esEstudiante };
                    this.BeginInvoke(mostrarPresupuesto, argumentos);
                }
                else
                {
                    this.lblPresupuesto.Text = $"Presupuesto: ${ICostoTotal.CalcularPresupuesto(listado, esEstudiante)}";
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError(ex);
            }
        }
        /// <summary>
        /// Cancela el alta o modificacion del cliente
        /// En caso de modificacion envia un false a traves del evento que avisara la cancelacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.OnConfirmaModificacion is not null)
                this.OnConfirmaModificacion.Invoke(false);
            this.Close();
        }
    }
}



