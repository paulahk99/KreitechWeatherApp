using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Test
{
    [TestClass]
    public class PalabraClavePrueba
    {
        private PalabraClave palabraClaveUno;
        
        [TestInitialize]
        public void InitTests()
        {
            palabraClaveUno = new PalabraClave();
        }
        [TestMethod]
        public void PropertyIdPrueba()
        {
            palabraClaveUno.Id = 1;
            Assert.AreEqual(palabraClaveUno.Id, 1);
        }
        [TestMethod]
        public void PropertyNombrePalabraPrueba()
        {
            palabraClaveUno.Palabra = "Nafta";
            string palabra = "NAFTA";
            Assert.AreEqual(palabraClaveUno.Palabra, palabra);
        }

        [TestMethod]
        public void EqualsPrueba()
        {
            palabraClaveUno.Palabra = "Nafta";
            PalabraClave palabraClaveDos = new PalabraClave { Palabra = "Nafta" };
            Assert.AreEqual(palabraClaveUno, palabraClaveDos);
        }

        [TestMethod]
        public void toStringPalabrasClavesPrueba()
        {
            PalabraClave palabraClaveDos = new PalabraClave() { Palabra = "UnaPalabra" };
            Assert.AreEqual(palabraClaveDos.ToString(), "UNAPALABRA");
        }
    }
}
