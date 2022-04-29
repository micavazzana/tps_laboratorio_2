using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    /// <summary>
    /// Clase Sedan, hereda de Vehiculo
    /// </summary>
    public class Sedan : Vehiculo
    {
        /// <summary>
        /// Enumerado que contiene cantidad de puertas
        /// </summary>
        public enum ETipo { CuatroPuertas, CincoPuertas }
        ETipo tipo;

        /// <summary>
        /// Constructor de Sedan
        /// </summary>
        /// <param name="marca">marca a asignar</param>
        /// <param name="chasis">chasis a asignar</param>
        /// <param name="color">color a asignar</param>
        /// <param name="tipo">tipo a asignar</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(marca, chasis, color)
        {
            this.tipo = tipo;
        }
        /// <summary>
        /// Constructor de Sedan. Por defecto, TIPO es CuatroPuertas
        /// </summary>
        /// <param name="marca">marca a asignar</param>
        /// <param name="chasis">chasis a asignar</param>
        /// <param name="color">color a asignar</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.CuatroPuertas)
        {
        }

        /// <summary>
        /// Obtiene el tamaño de Sedan: 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Muestra los datos del objeto tipo Sedan
        /// </summary>
        /// <returns>Retorna un string con los datos</returns>
        public sealed override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SEDAN");
            sb.Append(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine($"TIPO : {this.tipo}");
            sb.AppendLine("\n---------------------");
            return sb.ToString();
        }
    }
}
