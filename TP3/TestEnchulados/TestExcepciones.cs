using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEnchulados
{
    [TestClass]
    public class TestExcepciones
    {
        [TestMethod]
        [ExpectedException(typeof(ArchivoException))]
        public void EscribirArchivoTexto_CuandoNoEncuentraLaRutaDelArchivo_DevuelveArchivoException()
        {
            GestorArchivosTexto.EscribirArchivoTexto("archivoRandom.txt", "agrego data random");
        }
    }
}
