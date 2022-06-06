using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestEnchulame
{
    [TestClass]
    public class TestOtrosMetodos
    {
        /// <summary>
        /// Test que examina si la sobrecarga del == compara si dos equipos son iguales
        /// </summary>
        [TestMethod]
        public void SobrecargaComparacion_CuandoDosEquiposSonIguales_DevuelveTrue()
        {
            //Arrange
            Equipo equipo1 = new Equipo("camara", "sony", "a7sii", 2700);
            Equipo equipo2 = new Equipo("camara", "sony", "a7sii", 2700);
            bool expected = true;
            bool actual = false;
            //Act
            if (equipo1 == equipo2)
            {
                actual = true;
            }
            //Assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test que examina si el calculo del costo total de la reserva es correcto
        /// </summary>
        [TestMethod]
        public void CalcularCostoTotal_CuandoNoEsEstudianteNoRecibeDescuentoDescuento_DevuelveElCostoTotal()
        {
            //Arrange
            List<Equipo> list = new List<Equipo>
            {
                new Equipo("camara","sony","a7sii",2700),
                new Equipo("camara","sony","a6300",1700)
            };
            Cliente cliente = new Cliente("Quentin", "Tarantino", "12457852", DateTime.Now, "meme_maker@hotmail.com");
            Reserva reserva = new Reserva(cliente, list, 6);
            float expected = 4400;
            //Act
            float actual = reserva.CalcularCostoTotal(list, cliente.EsEstudiante);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test que examina si el calculo del costo total de la reserva es correcto
        /// y si el cliente al ser estudiante aplica un 15% de descuento
        /// </summary>
        [TestMethod]
        public void CalcularCostoTotal_CuandoEsEstudianteRecibeUn15PorcientoDeDescuento_DevuelveElCostoTotalConDescuento()
        {
            //Arrange
            List<Equipo> list = new List<Equipo>
            {
                new Equipo("camara","sony","a7sii",2700),
                new Equipo("camara","sony","a6300",1700)
            };
            Cliente cliente = new Cliente("Quentin", "Tarantino", "12457852", DateTime.Now, "meme_maker@hotmail.com");
            cliente.EsEstudiante = true;
            Reserva reserva = new Reserva(cliente, list, 6);
            float expected = 4400 - (4400 * 0.15f);
            //Act
            float actual = reserva.CalcularCostoTotal(list, cliente.EsEstudiante);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
