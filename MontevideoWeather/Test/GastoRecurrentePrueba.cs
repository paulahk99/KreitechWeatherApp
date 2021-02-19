using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Dominio;

namespace Test
{
    [TestClass]
    public class GastoRecurrentePrueba
    {
        private GastoRecuerrente gastoRec;
        private Categoria cat;
        private Moneda moneda;

        [TestInitialize]
        public void InitTests()
        {
            gastoRec = new GastoRecuerrente();
            cat = new Categoria();
            moneda = new Moneda();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RangoInferiorFechaPrueba()
        {
            gastoRec.Fecha = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RangoSuperiorFechaGastoRecurrentePrueba()
        {
            gastoRec.Fecha = 29;
        }

        [TestMethod]
        public void ConstructorGastoRecurrentePrueba()
        {
           GastoRecuerrente gastoRec2 = new GastoRecuerrente(1000 , "Ir a comer", cat ,10,moneda);
           Assert.AreEqual(gastoRec2.Fecha, 10);
        }

        [TestMethod]
        public void ToStringGastoRecurrentePrueba()
        {
            moneda.Nombre = "Pesos Uruguayos";
            moneda.Simbolo = "UYU";
            gastoRec.Moneda = moneda;
            cat.Nombre = "No hay nombre";
            gastoRec.Categoria = cat;

            Assert.AreEqual(gastoRec.ToString(), "Monto: 0, Descripcion: No hay descripcion, Categoria: No hay nombre, Moneda: UYU,1");
       }
    }
}
