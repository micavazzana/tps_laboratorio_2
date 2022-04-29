using System;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// Clase abstracta Vehiculo. No permite que se instancien objetos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        /// <summary>
        /// Enumerado que contiene marcas
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        /// <summary>
        /// Enumerado que contiene tamaños
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        private EMarca marca;
        private string chasis;
        private ConsoleColor color;

        /// <summary>
        /// Constructor de Vehiculo
        /// </summary>
        /// <param name="marca">marca a asignar</param>
        /// <param name="chasis">chasis a asignar</param>
        /// <param name="color">color a asignar</param>
        protected Vehiculo(EMarca marca, string chasis, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }
        /// <summary>
        /// Propiedad ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; }

        /// <summary>
        /// Muestra los datos del objeto, casteando a string utilizando la sobrecarga del operador.
        /// </summary>
        /// <returns>Retorna un string con los datos del vehiculo</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }    
        /// <summary>
        /// Publica los datos del vehiculo como string
        /// </summary>
        /// <param name="p">Vehiculo del cual se obtendra la informacion</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CHASIS: {p.chasis}\r");
            sb.AppendLine($"MARCA : {p.marca}\r");
            sb.AppendLine($"COLOR : {p.color}\r");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }

        /// <summary>
        /// Compara dos vehiculos. Son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Primer vehiculo a comparar</param>
        /// <param name="v2">Segundo vehiculo a comparar</param>
        /// <returns>True si fueron iguales, caso contrario False</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.chasis == v2.chasis;
        }
        /// <summary>
        /// Compara dos vehiculos. Son distintos si no comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Primer vehiculo a comparar</param>
        /// <param name="v2">Segundo vehiculo a comparar</param>
        /// <returns>True si fueron distintos, caso contrario False</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
    }
}
