using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEnchulame
{
    [TestClass]
    public class TestExcepciones
    {
        /// <summary>
        /// Test que retorna un ArchivoException al intentar escribir un archivo de texto cuando la ruta es invalida
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivoException))]
        public void EscribirArchivoTexto_CuandoNoEncuentraLaRutaDelArchivo_DevuelveArchivoException()
        {
            GestorArchivosTexto.EscribirArchivoTexto("", "agrego data random");
        }
        /// <summary>
        /// Test que retorna un ArchivoException al intentar leer un archivo de texto cuando la ruta es invalida
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivoException))]
        public void LeerArchivoTexto_CuandoNoEncuentraLaRutaDelArchivo_DevuelveArchivoException()
        {
            GestorArchivosTexto.LeerArchivoTexto("lavida.txt");
        }
        /// <summary>
        /// Test que retorna un ArchivoException al intentar escribir un archivo xml cuando la ruta es invalida
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivoException))]
        public void SerializarXml_CuandoNoEncuentraLaRutaDelArchivo_DevuelveArchivoException()
        {
            Serializadora<Cliente>.SerializarXml("", new Cliente());
        }
        /// <summary>
        /// Test que retorna un ArchivoException al intentar escribir un archivo json cuando la ruta es invalida
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivoException))]
        public void SerializarJson_CuandoNoEncuentraLaRutaDelArchivo_DevuelveArchivoException()
        {
            Serializadora<Cliente>.SerializarJson("", new Cliente());
        }
        /// <summary>
        /// Test que retorna un ArchivoException al intentar leer un archivo xml cuando la ruta es invalida
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivoException))]
        public void DeserializarXml_CuandoNoEncuentraLaRutaDelArchivo_DevuelveArchivoException()
        {
            Serializadora<Cliente>.DeserializarXml("lavida.xml");
        }
        /// <summary>
        /// Test que retorna un ArchivoException al intentar leer un archivo json cuando la ruta es invalida
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivoException))]
        public void DeserializarJson_CuandoNoEncuentraLaRutaDelArchivo_DevuelveArchivoException()
        {
            Serializadora<Cliente>.DeserializarJson("lavida.json");
        }
    }
}
