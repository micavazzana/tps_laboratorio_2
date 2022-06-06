using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que contiene los datos del cliente que realizará la reserva
    /// </summary>
    public class Cliente
    {
        private string nombre;
        private string apellido;
        private string dni;
        private DateTime fechaReserva;
        private string mail;
        private int idReserva;
        private bool esEstudiante;

        /// <summary>
        /// Constructor público y sin parámetros necesario para la serialización
        /// </summary>
        public Cliente()
        {

        }
        /// <summary>
        /// Constructor que inicializará los datos del cliente
        /// </summary>
        /// <param name="nombre">Nombre del cliente</param>
        /// <param name="apellido">Apellido del cliente</param>
        /// <param name="dni">Dni del cliente</param>
        /// <param name="fechaReserva">Fecha para la cual realiza la reserva</param>
        /// <param name="mail">Mail del cliente</param>
        public Cliente(string nombre, string apellido, string dni, DateTime fechaReserva, string mail)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.fechaReserva = fechaReserva;
            this.mail = mail;
            this.esEstudiante = false;//Por defecto ningun cliente accedera al descuento por estudiante
        }
        /// <summary>
        /// Propiedad de Lectura y Escritura que carga o devuelve el nombre del cliente
        /// </summary>
        public string Nombre 
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura y Escritura que carga o devuelve el apellido del cliente
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura y Escritura que carga o devuelve el dni del cliente
        /// </summary>
        public string Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura y Escritura que carga o devuelve la fecha para la cual el cliente realiza la reserva
        /// </summary>
        public DateTime FechaReserva
        {
            get
            {
                return this.fechaReserva;
            }
            set
            {
                this.fechaReserva = value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura y Escritura que carga o devuelve el mail del cliente
        /// </summary>
        public string Mail
        {
            get
            {
                return this.mail;
            }
            set
            {
                this.mail = value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura y Escritura que carga o devuelve un numero de id que sirve para identificar la reserva
        /// </summary>
        public int IdReserva
        {
            get
            {
                return this.idReserva;
            }
            set
            {
                this.idReserva = value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura y Escritura que carga o devuelve si el cliente es estudiante
        /// </summary>
        public bool EsEstudiante
        {
            get
            {
                return this.esEstudiante;
            }
            set
            {
                this.esEstudiante = value;
            }
        }

        /// <summary>
        /// Sobreescritura del ToString para que devuelva los datos del cliente
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {this.Nombre} ");
            sb.AppendLine($"Apellido: {this.Apellido} ");
            sb.AppendLine($"DNI: {this.Dni} ");
            sb.AppendLine($"Fecha de reserva: {this.FechaReserva.ToShortDateString()} ");
            sb.AppendLine($"Id Reserva: {this.IdReserva} ");
            return sb.ToString();
        }
    }
}
