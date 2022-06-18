using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que extiende un listado de reservas
    /// </summary>
    public static class ExtensionReservas
    {
        /// <summary>
        /// Metodo que cuenta la cantidad de reservas activas
        /// </summary>
        /// <param name="listado"></param>
        /// <returns></returns>
        public static int ContarCantidadReservas(this List<Reserva> listado)
        {
            return listado.Count;
        }
    }
}
