using System;

namespace Entidades
{
    /// <summary>
    /// Interfaz que implementaran las clases para mostrar obligadamente las excepciones producidas
    /// </summary>
    public interface IMostrarMensaje
    {
        /// <summary>
        /// Muestra el mensaje de la excepcion
        /// </summary>
        /// <param name="ex"></param>
        void MostrarMensajeError(Exception ex);
    }
}
