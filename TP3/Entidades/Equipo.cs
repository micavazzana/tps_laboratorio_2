namespace Entidades
{
    /// <summary>
    /// Clase que contiene los datos del equipo a reservar
    /// </summary>
    public class Equipo
    {
        private string tipo;
        private string marca;
        private string nombreEquipo;
        private float precio;
        private bool estaReservado;

        /// <summary>
        /// Constructor público y sin parámetros necesario para la serialización
        /// </summary>
        public Equipo()
        {

        }
        /// <summary>
        /// Constructor que inicializará los datos del equipo
        /// </summary>
        /// <param name="tipo">El tipo del equipo, si es camara, luz, microfono, etc</param>
        /// <param name="marca">La marca del equipo</param>
        /// <param name="nombreEquipo">El nombre del equipo</param>
        /// <param name="precio">El costo que tiene el alquiler del equipo por jornada</param>
        public Equipo(string tipo, string marca, string nombreEquipo, float precio)
        {
            this.tipo = tipo;
            this.marca = marca;
            this.nombreEquipo = nombreEquipo;
            this.precio = precio;
            this.estaReservado = false;//Por defecto al crear un nuevo equipo, este tendra disponibilidad
        }
        /// <summary>
        /// Propiedad de Lectura y Escritura que carga o devuelve el tipo del equipo
        /// </summary>
        public string Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                this.tipo = value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura y Escritura que carga o devuelve la marca del equipo
        /// </summary>
        public string Marca
        {
            get
            {
                return this.marca;
            }
            set
            {
                this.marca = value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura y Escritura que carga o devuelve el nombre del equipo
        /// </summary>
        public string NombreEquipo 
        {
            get
            {
                return this.nombreEquipo;
            }
            set
            {
                this.nombreEquipo = value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura y Escritura que carga o devuelve el costo del equipo por jornada
        /// </summary>
        public float Precio 
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura y Escritura que carga o devuelve el estado del equipo
        /// Sera True si esta reservado o False si no lo esta
        /// </summary>
        public bool Estado 
        {
            get
            {
                return this.estaReservado;
            }
            set
            {
                this.estaReservado = value;
            }
        }

        /// <summary>
        /// Compara si dos equipos son iguales. 
        /// Seran iguales cuando el nombre del equipo sea el mismo
        /// </summary>
        /// <param name="equipo1">El primer equipo a comparar</param>
        /// <param name="equipo2">El segundo equipo a comparar</param>
        /// <returns>True si son iguales, False caso contario </returns>
        public static bool operator ==(Equipo equipo1, Equipo equipo2)
        {
            return equipo1.nombreEquipo == equipo2.nombreEquipo;
        }
        /// <summary>
        /// Compara si dos equipos son distintos.
        /// Seran distintos cuando el nombre del equipo no sea el mismo
        /// </summary>
        /// <param name="equipo1">El primer equipo a comparar</param>
        /// <param name="equipo2">El segundo equipo a comparar</param>
        /// <returns>True si son distintos, False caso contrario</returns>
        public static bool operator !=(Equipo equipo1, Equipo equipo2)
        {
            return !(equipo1 == equipo2);
        }
        /// <summary>
        /// Sobreescritura del ToString para que devuelva los datos del equipo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Tipo} - {this.Marca} {this.NombreEquipo} - Precio ${this.precio}";
        }
    }
}
