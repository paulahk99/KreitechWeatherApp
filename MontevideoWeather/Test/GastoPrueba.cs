using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;


namespace Test
{
    
    [TestClass]
    public class GastoPrueba
    {
        private Gasto gasto;
        private Categoria cat;
        private Moneda moneda;
        private Categoria categoria;

        [TestInitialize]
        public void InitTests()
        {
            gasto = new Gasto() ;
            cat = new Categoria();
            moneda = new Moneda() ;
            categoria = new Categoria() { Nombre = "Entretenimiento" };
        }

        [TestMethod]
        public void PropertyMonedaPrueba()
        {
            gasto.Moneda = moneda;
            Assert.AreEqual(moneda,gasto.Moneda);
        }

        [TestMethod]
        public void PropertyIdGastoPrueba()
        {
            gasto.Id = 1;
            Assert.AreEqual(gasto.Id, 1);
        }

        [TestMethod]
        public void PropertyMontoDecimalPrueba()
        {
            gasto.Monto = 0;
            Assert.AreEqual(0.00, gasto.Monto);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void PropertyMontoPositivoPrueba()
        {
            gasto.Monto = -1;
        }

        [TestMethod]
        public void PropertyDescripcionPrueba()
        {
            gasto. Descripcion = "Una descripcion" ;
            string descrpcion = "Una descripcion";
            Assert.AreEqual(descrpcion, gasto.Descripcion);
        }

        [TestMethod]
        public void PropertyCategoriaPrueba()
        {
            Categoria cat = new Categoria();
            gasto.Categoria = cat ;
            Assert.AreEqual(cat , gasto.Categoria);
        }

        [TestMethod]
        public void PropertyMontoEnPesosPrueba()
        {
            gasto.MontoEnPesos = 40;
            Assert.AreEqual(40, gasto.MontoEnPesos);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RangoDescripcionPrueba()
        {
            gasto.Descripcion = "a";
            Gasto gasto2 = new Gasto() { Descripcion = "abcdefghijklmnopqrsuvwxyz" };
        }

        [TestMethod]
        public void ConstructorPrueba()
        {
            Gasto gasto2 = new Gasto(1000, "Ir a comer", cat , moneda);
            Assert.AreEqual(gasto2.Monto,1000);
        }

        [TestMethod]
        public void ToStringGastoPrueba()
        {
            moneda.Nombre = "Pesos Uruguayos";
            moneda.Simbolo = "UYU";
            gasto.Moneda = moneda;
            categoria.Nombre = "No hay nombre";
            gasto.Categoria = categoria;
            Assert.AreEqual(gasto.ToString(), "Monto: 0, Descripcion: No hay descripcion, Categoria: No hay nombre, Moneda: UYU");
        }
    }
}

  

