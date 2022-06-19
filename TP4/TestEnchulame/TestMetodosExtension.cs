using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestEnchulame
{
    [TestClass]
    public class TestMetodosExtension
    {
        /// <summary>
        /// Test del metodo de extension que cuenta la cantidad de reservas activas
        /// </summary>
        [TestMethod]
        public void ContarCantidadReservas_CuandoRecibeUnaListaDeReservas_DevuelveLaCantidadDeReservas()
        {
            //listado equipos
            List<Equipo> equipos = new List<Equipo>()
            {
                new Equipo("camara", "sony", "a6300", 4500),
                new Equipo("camara", "sony", "a7sii", 6500)
            };
            //nuevo cliente
            Cliente cliente = new Cliente("Mica", "Vazzana", "34573250", DateTime.Now, "micavazzana@gmail.com");
            //nueva reserva
            Reserva reserva = new Reserva(cliente, equipos, 1);
            //listado de reservas
            List<Reserva> listadoReservas = new List<Reserva>();
            listadoReservas.Add(reserva);
            int expected = 1;

            //ACT
            int cantidadReservas = listadoReservas.ContarCantidadReservas();
            //ASSERT
            Assert.AreEqual(expected, cantidadReservas);
        }
        /// <summary>
        /// Test del metodo de extension que evalua si la cadena para cargar un dni es valido
        /// </summary>
        [TestMethod]
        public void ValidarDni_CuandoRecibeSoloNumerosYCantidadAdecuada_DevuelveTrue()
        {
            string dni = "34573250";
            bool expected = dni.ValidarDni();

            Assert.IsTrue(expected);
        }
        /// <summary>
        /// Test del metodo de extension que evalua si la cadena para cargar un nombre es valido
        /// </summary>
        [TestMethod]
        public void ValidarSoloLetras_CuandoRecibeSoloLetras_DevuelveTrue()
        {
            string nombre = "Micaela Vazzana";
            bool expected = nombre.ValidarNombresYApellidos();

            Assert.IsTrue(expected);
        }
        /// <summary>
        /// Test del metodo de extension que evalua si la cadena para cargar un mail es valido
        /// </summary>
        [TestMethod]
        public void ValidarMails_CuandoRecibeSoloLetras_DevuelveTrue()
        {
            string mail = "micavazzana@gmail.com";
            bool expected = mail.ValidarMails();

            Assert.IsTrue(expected);
        }
    }
}
