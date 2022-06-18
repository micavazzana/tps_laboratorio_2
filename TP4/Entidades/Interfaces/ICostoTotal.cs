using System.Collections.Generic;

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
        static float CalcularPresupuesto(List<Equipo> listadoEquiposReservados, bool esEstudiante)
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
