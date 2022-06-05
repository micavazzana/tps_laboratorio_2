using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// Clase que contiene el contenido de una reserva: Los Datos del cliente y los equipos que reservo
    /// </summary>
    public class Reserva
    {
        private Cliente cliente;
        private List<Equipo> equiposReservados;
        private int idReserva;

        /// <summary>
        /// Constructor público y sin parámetros necesario para la serialización
        /// </summary>
        public Reserva()
        {

        }
        /// <summary>
        /// Constructor que inicializará los datos de la reserva
        /// </summary>
        /// <param name="cliente">El cliente que tiene todos sus datos</param>
        /// <param name="equiposReservados">El listado de equipos que el cliente reservó</param>
        public Reserva(Cliente cliente, List<Equipo> equiposReservados, int idReserva)
        {
            this.cliente = cliente;
            this.equiposReservados = equiposReservados;
            this.idReserva = idReserva;
        }
        /// <summary>
        /// Propiedad de Lectura y Escritura que carga o devuelve un cliente
        /// </summary>
        public Cliente Cliente
        {
            get
            {
                return this.cliente;
            }
            set
            {
                this.cliente = value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura y Escritura que carga o devuelve la lista de equipos reservados
        /// </summary>
        public List<Equipo> EquiposReservados
        {
            get
            {
                return this.equiposReservados;
            }

            set
            {
                this.equiposReservados = value;
            }
        }
        /// <summary>
        /// Sobreescritura del ToString para que devuelva los datos de la reserva
        /// </summary>
        /// <returns>La cadena que contiene la data</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Cliente.ToString());
            foreach (Equipo item in this.equiposReservados)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
