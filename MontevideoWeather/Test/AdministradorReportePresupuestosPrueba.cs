using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Test
{
    [TestClass]
    public class AdministradorReportePresupuestosPrueba
    {
        private Categoria unaCategoria;
        private IRepositorio miRepositorio;
        private AdministradorReportePresupuestos adminReportePresupuestos;
        private Presupuesto unPresupuesto;
        private AdministradorPresupuesto adminPresupuestos;

        [TestInitialize]
        public void InitTest()
        {
            miRepositorio = new RepositorioMemoria();
            adminPresupuestos = new AdministradorPresupuesto(miRepositorio);
            unaCategoria = new Categoria() { Nombre = "Entretenimiento" };
            adminReportePresupuestos = new AdministradorReportePresupuestos(miRepositorio);
            unPresupuesto = new Presupuesto();
        }

        [TestMethod]
        public void AgregarMesesAnioDondeHayPresupuestoPrueba()
        {
            unPresupuesto.Fecha = new DateTime(2020, 10, 2);
            adminPresupuestos.AgregarPresupuesto(unPresupuesto);
            Assert.AreEqual(1, adminReportePresupuestos.AgregarYRetornalListaDeMesesDondeHayPresupuestosOrdenada().Count());
        }

        [TestMethod]
        public void AgregarYRetornarListaDeMesesDondeHayPresupuestosOrdenadaPrueba()
        {
            unPresupuesto.Fecha = new DateTime(2020, 10, 2);
            Presupuesto otroPresupuesto = new Presupuesto();
            otroPresupuesto.Fecha = new DateTime(2020, 11, 2);
            adminPresupuestos.AgregarPresupuesto(unPresupuesto);
            adminPresupuestos.AgregarPresupuesto(otroPresupuesto);

            List<DateTime> ListaLocal = new List<DateTime>();
            ListaLocal.Add(new DateTime(2020, 10, 1));
            ListaLocal.Add(new DateTime(2020, 11, 1));

            Assert.IsTrue(adminReportePresupuestos.AgregarYRetornalListaDeMesesDondeHayPresupuestosOrdenada().SequenceEqual(ListaLocal));
        }

        [TestMethod]
        public void AgregarAListaDeMesesDondeHayPresupuestoPrueba()
        {
            unPresupuesto.Fecha = new DateTime(2020, 10, 2);
            adminPresupuestos.AgregarPresupuesto(unPresupuesto);
            Assert.AreEqual(1, adminReportePresupuestos.AgregarYRetornalListaDeMesesDondeHayPresupuestosOrdenada().Count());
        }

        [TestMethod]
        public void ConvertirFechaDejarSoloAnioMesPrueba()
        {
            unPresupuesto.Fecha = new DateTime(2020, 10, 2);
            DateTime unaFecha = new DateTime(2020, 10, 1);
            Assert.AreEqual(unaFecha, adminReportePresupuestos.ConvertirFechaDejarSoloAnioMes(unPresupuesto));
        }

        [TestMethod]
        public void ConvertirFechaQuitarElDiaPrueba()
        {
            unPresupuesto.Fecha = new DateTime(2020, 5, 28);
            DateTime convertido = adminReportePresupuestos.ConvertirFechaDejarSoloAnioMes(unPresupuesto);
            Assert.IsFalse(convertido.Equals(unPresupuesto.Fecha));
        }
    }
}
