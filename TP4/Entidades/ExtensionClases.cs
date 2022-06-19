using System.Collections.Generic;

namespace Entidades
{
    /// <summary>
    /// Clase que extiende distintas clases
    /// </summary>
    public static class ExtensionClases
    {
        /// <summary>
        /// Extiende la clase Reserva
        /// Cuenta la cantidad de reservas activas
        /// </summary>
        /// <param name="listado"></param>
        /// <returns></returns>
        public static int ContarCantidadReservas(this List<Reserva> listado)
        {
            return listado.Count;
        }
        /// <summary>
        /// Extiende clase string
        /// Valida que un dni sea valido, solo numeros y cantidad de digitos indicados
        /// </summary>
        /// <param name="str">define el objeto extendido y lo que el metodo hace con el</param>
        /// <returns></returns>
        public static bool ValidarDni(this string str)
        {
            int numero;
            int cantidad = str.Length;
            return int.TryParse(str, out numero) && cantidad == 8;
        }
        /// <summary>
        /// Extiende clase string
        /// Valida que la cadena sea nombres validos, compuestos de letras y/o espacios
        /// </summary>
        /// <param name="str">define el objeto extendido y lo que el metodo hace con el</param>
        /// <returns></returns>
        public static bool ValidarNombresYApellidos(this string str)
        {
            foreach (char letra in str)
            {
                if ((letra < 'a' || letra > 'z') && (letra < 'A' || letra > 'Z') && letra != ' ')
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Extiende la clase string
        /// Valida que la cadena sea un email valido, contenga @ y un .com
        /// </summary>
        /// <param name="str">define el objeto extendido y lo que el metodo hace con el</param>
        /// <returns></returns>
        public static bool ValidarMails(this string str)
        {
            foreach (char letra in str)
            {
                if ((letra < 'a' || letra > 'z') && (letra < 'A' || letra > 'Z') && letra != '@' && letra != '.')
                {
                    return false;
                }
            }
            if (!str.Contains('@') || !str.Contains(".com"))
            {
                return false;
            }
            return true;
        }
    }
}
