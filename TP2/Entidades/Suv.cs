using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Suv, hereda de Vehiculo
    /// </summary>
    public class Suv : Vehiculo
    {
        /// <summary>
        /// Constructor de Suv
        /// </summary>
        /// <param name="marca">marca a asignar</param>
        /// <param name="chasis">chasis a asignar</param>
        /// <param name="color">color a asignar</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(marca, chasis, color)
        {
        }

        /// <summary>
        /// Obtiene el tamaño de SUV: 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        /// <summary>
        /// Muestra los datos del objeto tipo Suv
        /// </summary>
        /// <returns>Retorna un string con los datos</returns>
        public sealed override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SUV");
            sb.Append(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("\n---------------------");
            return sb.ToString();
        }
    }
}
