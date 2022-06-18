using System;

namespace Entidades
{
    /// <summary>
    /// Clase que hereda de Exception
    /// Seran arrojadas cuando se produzca una excepcion al leer o escribir archivos
    /// </summary>
    public class ArchivoException : Exception
    {
        /// <summary>
        /// Constructor que inicializa la instancia con un mensaje por defecto
        /// </summary>
        public ArchivoException() : base("Error al manipular los archivos de gestión del programa")
        {

        }
        /// <summary>
        /// Constructor que inicializa la instancia con un mensaje recibido
        /// </summary>
        /// <param name="message">Mensaje que describe el error</param>
        public ArchivoException(string message) : base(message)
        {
        }
        /// <summary>
        /// Constructor que inicializa la instancia con un mensaje de error especifico 
        /// y con una referencia a una excepcion que tiene el mensaje de error que causo la excepcion
        /// </summary>
        /// <param name="message">Mensaje que describe el error</param>
        /// <param name="innerException">Exception que guarda la excepcion arrojada</param>
        public ArchivoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
