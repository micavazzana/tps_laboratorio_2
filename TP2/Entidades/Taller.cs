using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// Clase sellada Taller. No puede tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        /// <summary>
        /// Enumerado que contiene los tipos de vehiculos
        /// </summary>
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }

        private List<Vehiculo> vehiculos;
        private int espacioDisponible;

        /// <summary>
        /// Constructor privado de Taller. Instancia la lista de vehiculos
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Constructor publico de Taller
        /// </summary>
        /// <param name="espacioDisponible">Espacio disponible en el taller</param>
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }

        /// <summary>
        /// Lista todos los datos del taller y TODOS los vehículos
        /// </summary>
        /// <returns>Retorna un string con todos los datos</returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="tipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Retorna un string con los datos requeridos</returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"Tenemos {taller.vehiculos.Count} lugares ocupados de un total de {taller.espacioDisponible} disponibles\n");
            foreach (Vehiculo v in taller.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.SUV:
                        if (v is Suv)
                            sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Ciclomotor:
                        if (v is Ciclomotor)
                            sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Sedan:
                        if (v is Sedan)
                            sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Agregará un elemento a la lista, 
        /// solo si el vehiculo no existe todavia en el listado
        /// y si hay espacio disponible
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns>Retorna el taller donde se agrego el vehiculo (o no)</returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo)
                {
                    return taller;
                }
            }
            if (taller.espacioDisponible > taller.vehiculos.Count)
            {
                taller.vehiculos.Add(vehiculo);
            }
            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista solo si ese vehiculo existe en el listado.
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns>Retorna el taller donde se quito el vehiculo (o no)</returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo)
                {
                    taller.vehiculos.Remove(vehiculo);
                    break;
                }
            }
            return taller;
        }
    }
}
