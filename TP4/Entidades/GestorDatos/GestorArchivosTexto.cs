using System;
using System.IO;

namespace Entidades
{
    /// <summary>
    /// Clase que va a gestionar la lectura y escritura de archivos de texto
    /// </summary>
    public class GestorArchivosTexto
    {
        private static string rutaBase;

        /// <summary>
        /// Constructor que define una ruta de base en el escritorio de la pc a ejecutarse
        /// </summary>
        static GestorArchivosTexto()
        {
            rutaBase = $"{AppDomain.CurrentDomain.BaseDirectory}\\Archivos";
        }
        /// <summary>
        /// Escribe un archivo de texto
        /// </summary>
        /// <param name="nombreArchivo">el nombre que del archivo a escribir</param>
        /// <param name="contenido">el contenido de lo que se guardara en el archivo</param>
        /// <exception cref="ArchivoException">Arroja una excepcion que contendra la excepcion devuelta por el StreamWriter</exception>
        public static void EscribirArchivoTexto(string nombreArchivo, string contenido)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter($"{rutaBase}\\{nombreArchivo}"))
                {
                    sw.WriteLine(contenido);
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoException("Error al escribir archivo de texto", ex);
            }
        }
        /// <summary>
        /// Lee un archivo de texto
        /// </summary>
        /// <param name="nombreArchivo">el nombre que del archivo a leer</param>
        /// <returns>String con el contenido de lo leido</returns>
        /// <exception cref="ArchivoException">Arroja una excepcion que contendra la excepcion devuelta por el StreamReader</exception>
        public static string LeerArchivoTexto(string nombreArchivo)
        {
            try
            {
                using (StreamReader sr = new StreamReader($"{rutaBase}\\{nombreArchivo}"))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoException("Error al leer archivo de texto", ex);
            }
        }
    }
}
