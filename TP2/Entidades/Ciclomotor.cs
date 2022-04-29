using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Ciclomotor, hereda de Vehiculo
    /// </summary>
    public class Ciclomotor : Vehiculo
    {
        /// <summary>
        /// Constructor de Ciclomotor
        /// </summary>
        /// <param name="marca">marca a asignar</param>
        /// <param name="chasis">chasis a asignar</param>
        /// <param name="color">color a asignar</param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            :base(marca,chasis,color)
        {
        }
        
        /// <summary>
        /// Obtiene el tamaño de Ciclomotor: 'Chico'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Muestra los datos del objeto tipo Ciclomotor
        /// </summary>
        /// <returns>Retorna un string con los datos</returns>
        public sealed override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CICLOMOTOR");
            sb.Append(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("\n---------------------");
            return sb.ToString();
        }
    }
}
