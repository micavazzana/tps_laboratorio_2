using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfaz que implementara la Clase Reserva para calcular el costo total de una reserva
    /// </summary>
    public interface ICostoTotal
    {
        /// <summary>
        /// Calcula el costo total de la reserva
        /// Teniendo en cuenta si el cliente es estudiante o no
        /// </summary>
        /// <param name="listadoEquiposReservados">El listado de equipos que reservo el cliente</param>
        /// <param name="esEstudiante">Recibira true si es estudiante, false caso contrario</param>
        /// <returns>Devuelve el costo total</returns>
        float CalcularCostoTotal(List<Equipo> listadoEquiposReservados, bool esEstudiante);
    }
}
