using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Dominio;

namespace Test
{
    [TestClass]
    public class CategoriaMontoPrueba
    {
        private CategoriaMonto categoriaMonto;
        private Categoria categoria;

        [TestInitialize]
        public void InitTests()
        {
            categoriaMonto = new CategoriaMonto();
            categoria = new Categoria();
        }

        [TestMethod]
        public void PropertyCategoriaPrueba()
        {
            categoriaMonto.Categoria = categoria;
            Assert.AreEqual(categoria, categoriaMonto.Categoria);
        }

        [TestMethod]
        public void PropertyIdCategoriaMontoPrueba()
        {
            categoriaMonto.Id = 1;
            Assert.AreEqual(categoriaMonto.Id, 1);
        }

        [TestMethod]
        public void PropertyMontoPrueba()
        {
            categoriaMonto.Monto = 1000;
            int unMonto = 1000;
            Assert.AreEqual(categoriaMonto.Monto, unMonto);
        }

        [TestMethod]
        public void PropertyMontoDecimalPrueba()
        {
            categoriaMonto.Monto = 0;
            Assert.AreEqual(0.00, categoriaMonto.Monto);

        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MontoMenorA0Prueba()
        {
            categoriaMonto.Monto = -1000.00;
        }

        
        [TestMethod]
        public void MontoInicialEn0Prueba()
        {
            int montoInicial = 0;
            Assert.AreEqual(montoInicial, categoriaMonto.Monto);
        }
    }
}