using Dominio;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using obligatorio1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class AdministradorMonedaPrueba
    {
        private IRepositorio miRepositorio;
        private AdministradorMonedas adminMonedas;
        private Moneda unaMoneda;
        private Moneda otraMoneda;

        [TestInitialize]
        public void InitTests()
        {
            miRepositorio = new RepositorioMemoria();
            adminMonedas = new AdministradorMonedas(miRepositorio);
            unaMoneda = new Moneda();
            otraMoneda = new Moneda();
        }

        [TestMethod]
        public void AgregarMonedaPrueba()
        {
            adminMonedas.AgregarMoneda(unaMoneda);
            List<Moneda> ListaLocal = new List<Moneda>();
            ListaLocal.Add(unaMoneda);
            Assert.IsTrue(adminMonedas.RetornarListaMonedas().SequenceEqual(ListaLocal));
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoRepetido))]
        public void NoAgregarMonedaRepetidaPrueba()
        {
            adminMonedas.AgregarMoneda(unaMoneda);
            adminMonedas.AgregarMoneda(unaMoneda);
        }

        [TestMethod]
        public void BorrarMonedaPrueba()
        {
            adminMonedas.AgregarMoneda(unaMoneda);
            adminMonedas.BorrarMoneda(unaMoneda);
            Assert.IsFalse(adminMonedas.RetornarListaMonedas().Contains(unaMoneda));
        }

        [TestMethod]
        public void ModificarNombreAMonedaPrueba()
        {
            unaMoneda.Nombre = "EURO";
            adminMonedas.AgregarMoneda(unaMoneda);
            adminMonedas.ModificarNombreAMoneda(unaMoneda, "PesosUY");
            Assert.AreEqual(unaMoneda.Nombre, "PesosUY");
        }

        [TestMethod]
        public void ModificarSimboloAMonedaPrueba()
        {
            unaMoneda.Simbolo = "EU";
            adminMonedas.AgregarMoneda(unaMoneda);
            adminMonedas.ModificarSimboloAMoneda(unaMoneda, "$");
            Assert.AreEqual(unaMoneda.Simbolo, "$");
        }

        [TestMethod]
        public void ModificarCotizacionAMonedaPrueba()
        {
            unaMoneda.Cotizacion = 0.22;
            adminMonedas.AgregarMoneda(unaMoneda);
            adminMonedas.ModificarCotizacionAMoneda(unaMoneda, 0.22);
            Assert.AreEqual(unaMoneda.Cotizacion, 0.22);
        }
    }
}
