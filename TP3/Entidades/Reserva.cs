using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// Clase que contiene el contenido de una reserva: Los Datos del cliente y los equipos que reservo
    /// </summary>
    public class Reserva : ICostoTotal
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
        /// <summary>
        /// Calcula el costo total de la reserva
        /// Teniendo en cuenta si el cliente es estudiante o no
        /// </summary>
        /// <param name="listadoEquiposReservados">El listado de equipos que reservo el cliente</param>
        /// <param name="esEstudiante">Recibira true si es estudiante, false caso contrario</param>
        /// <returns>Devuelve el costo total</returns>
        public float CalcularCostoTotal(List<Equipo> listadoEquiposReservados, bool esEstudiante)
        {
            float total = 0;
            foreach (Equipo item in listadoEquiposReservados)
            {
                total += item.Precio;
            }
            if (esEstudiante)
            {
                total -= total * 0.15f;
            }
            return total;

        }
    }
}
