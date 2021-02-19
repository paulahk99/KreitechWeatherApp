using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System;


namespace Test
{
    [TestClass]
    public class GastoComunPrueba
    {
        private GastoComun gasto;
        private Categoria cat;
        private Moneda moneda; 

        [TestInitialize]
        public void InitTests()
        {
            gasto = new GastoComun();
            cat = new Categoria();
            moneda = new Moneda();
        }

        [TestMethod]
        public void PropertyFechaPrueba()
        {
            gasto.Fecha = new DateTime(2020, 5, 1);
            DateTime fecha = new DateTime(2020, 5, 1);
            Assert.AreEqual(fecha, gasto.Fecha);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RangoInferiorFechaPrueba()
        {
            gasto.Fecha = new DateTime(2017, 12, 31);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RangoInferiorFechaGastoComunPrueba()
        {
            gasto.Fecha = new DateTime(2017, 12, 31);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RangoSuperiorFechaGastoComunPrueba()
        {
            gasto.Fecha = new DateTime(2031, 1, 1);
        }
        
        [TestMethod]
        public void ConstructorGastoComunPrueba()
        {
            DateTime fecha = new DateTime(2020, 5, 1);
            GastoComun gastoRec2 = new GastoComun(1000, "Ir a comer", cat,fecha,moneda);
            Assert.AreEqual(gastoRec2.Descripcion,"Ir a comer");
        }

       [TestMethod]
        public void ToStringGastoComunPrueba()
        {
            moneda.Nombre = "Pesos Uruguayos";
            moneda.Simbolo = "UYU";
            gasto.Moneda = moneda;
            cat.Nombre = "No hay nombre";
            gasto.Categoria = cat;
            Assert.AreEqual(gasto.ToString(), "Monto: 0, Descripcion: No hay descripcion, Categoria: No hay nombre, Moneda: UYU, Fecha: 5/1/2020");
        }
    }
}
