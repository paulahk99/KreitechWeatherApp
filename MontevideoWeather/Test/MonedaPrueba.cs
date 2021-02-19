
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Dominio;
using Excepciones;

namespace Test
{
    [TestClass]
    public class MonedaPrueba
    {
        private Moneda moneda;

        [TestInitialize]
        public void InitTests()
        {
            moneda = new Moneda();
        }
        [TestMethod]
        public void PropertyNombrePrueba()
        {
            moneda.Nombre = "Euro";
            string nombre = "Euro";
            Assert.AreEqual(nombre, moneda.Nombre);
        }

        [TestMethod]
        public void PropertyIdMonedaPrueba()
        {
            moneda.Id = 1;
            Assert.AreEqual(moneda.Id, 1);
        }

        [TestMethod]
        public void PropertSimboloPrueba()
        {
            moneda.Simbolo = "$";
            string simbolo = "$";
            Assert.AreEqual(simbolo, moneda.Simbolo);
        }

        [TestMethod]
        public void PropertCotizacionPrueba()
        {
            moneda.Cotizacion = 58;
            double cotizacion = 58;
            Assert.AreEqual(cotizacion, moneda.Cotizacion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPalabraLarga))]
        public void LargoNombrePrueba()
        {
            moneda.Nombre = "Eu";
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPalabraLarga))]
        public void LargoSimboloPrueba()
        {
            moneda.Simbolo = "USDDD";
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CotizacionMenor0Prueba()
        {
            moneda.Cotizacion = -3;
        }

        [TestMethod]
        public void ToStringMonedaPrueba()
        {
            Assert.AreEqual(moneda.ToString(), "UYU");
        }

        [TestMethod]
        public void EqualsMonedaPrueba()
        {
            Moneda unaMoneda = new Moneda {Simbolo = "UYU" };
            Moneda otraMoneda = new Moneda { Simbolo = "UYU" };
            Assert.AreEqual(unaMoneda, otraMoneda);
        }
    }
}
