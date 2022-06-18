using System;

namespace Entidades
{
    /// <summary>
    /// Clase que hereda de Exception
    /// Seran arrojadas cuando se produzca un error en la gestion de la base de datos sql
    /// </summary>
    public class SqlException : Exception
    {
        /// <summary>
        /// Constructor que inicializa la instancia con un mensaje por defecto
        /// </summary>
        public SqlException() : base("Error al traer los datos de la base de datos")
        {
        }
        /// <summary>
        /// Constructor que inicializa la instancia con un mensaje recibido
        /// </summary>
        /// <param name="message">Mensaje que describe el error</param>
        public SqlException(string message) : base(message)
        {
        }
        /// <summary>
        /// Constructor que inicializa la instancia con un mensaje de error especifico 
        /// y con una referencia a una excepcion que tiene el mensaje de error que causo la excepcion
        /// </summary>
        /// <param name="message">Mensaje que describe el error</param>
        /// <param name="innerException">Exception que guarda la excepcion arrojada</param>
        public SqlException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
