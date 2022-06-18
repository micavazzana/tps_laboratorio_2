using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase que va a gestionar la lectura y escritura de archivos Xml o Json
    /// </summary>
    /// <typeparam name="T">Tipo generico que servira para determinar que tipo serializar o deserializar</typeparam>
    public class Serializadora<T> where T : class
    {
        private static string rutaBase;

        /// <summary>
        /// Constructor que define una ruta de base que buscara los archivos en la carpeta del proyecto
        /// </summary>
        static Serializadora()
        {
            rutaBase = $"{AppDomain.CurrentDomain.BaseDirectory}\\Archivos";
        }
        /// <summary>
        /// Serializa un XML
        /// </summary>
        /// <param name="nombreArchivo">el nombre que del archivo a escribir</param>
        /// <param name="objeto">el objeto que serializara en xml</param>
        /// <exception cref="ArchivoException">Arroja una excepcion que contendra la excepcion devuelta por el StreamWriter</exception>
        public static void SerializarXml(string nombreArchivo, T objeto)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter($"{rutaBase}\\{nombreArchivo}"))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    xml.Serialize(sw, objeto);
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoException("Error al serializar el xml", ex);
            }
        }
        /// <summary>
        /// Serializa un JSON
        /// </summary>
        /// <param name="nombreArchivo">el nombre que del archivo a escribir</param>
        /// <param name="objeto">el objeto que serializara en json</param>
        /// <exception cref="ArchivoException">Arroja una excepcion que contendra la excepcion devuelta por el StreamWriter</exception>
        public static void SerializarJson(string nombreArchivo, T objeto)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter($"{rutaBase}\\{nombreArchivo}"))
                {
                    JsonSerializerOptions opciones = new JsonSerializerOptions();
                    opciones.WriteIndented = true;
                    string ser = JsonSerializer.Serialize(objeto, opciones);
                    sw.WriteLine(ser);
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoException("Error al serializar el json", ex);
            }
        }
        /// <summary>
        /// Deserializa un XML
        /// </summary>
        /// <param name="nombreArchivo">el nombre que del archivo a leer</param>
        /// <returns>Un objeto que contiene lo deserializado</returns>
        /// <exception cref="ArchivoException">Arroja una excepcion que contendra la excepcion devuelta por el StreamReader</exception>
        public static T DeserializarXml(string nombreArchivo)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader($"{rutaBase}\\{nombreArchivo}"))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    T tipo = (T)xml.Deserialize(streamReader);
                    return tipo;
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoException("Error al deserializar xml", ex);
            }
        }
        /// <summary>
        /// Deserializa un json
        /// </summary>
        /// <param name="nombreArchivo">el nombre que del archivo a leer</param>
        /// <returns>Un objeto que contiene lo deserializado</returns>
        /// <exception cref="ArchivoException">Arroja una excepcion que contendra la excepcion devuelta por el StreamReader</exception>
        public static T DeserializarJson(string nombreArchivo)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader($"{rutaBase}\\{nombreArchivo}"))
                {
                    string json = streamReader.ReadToEnd();
                    return JsonSerializer.Deserialize<T>(json);
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoException("Error al deserializar json", ex);
            }
        }
    }
}