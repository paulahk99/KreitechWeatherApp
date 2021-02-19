using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Excepciones;

namespace Test
{
    [TestClass]
    public class AdministradorPresupuestoPrueba
    {
        
        private AdministradorPresupuesto adminPresupuestos;
        private Categoria unaCategoria;
        private Categoria otraCategoria;
        private CategoriaMonto unaCategoriaMonto;
        private Presupuesto unPresupuesto;
        private IRepositorio miRepositorio;

        [TestInitialize]
        public void InitTests()
        {
            miRepositorio = new RepositorioMemoria();
            adminPresupuestos = new AdministradorPresupuesto(miRepositorio);           
            unaCategoria = new Categoria();
            otraCategoria = new Categoria();
            unPresupuesto = new Presupuesto();
            unaCategoriaMonto = new CategoriaMonto();
        }

        [TestMethod]
        public void RetornarListaPresupuestoPrueba()
        {
            List<Presupuesto> ListaLocal = new List<Presupuesto>();
            Assert.IsTrue(adminPresupuestos.RetornarListaPresupuestos().SequenceEqual(ListaLocal));
        }
       
        [TestMethod]
        public void AgregarPresupuestoPrueba()
        {
            adminPresupuestos.AgregarPresupuesto(unPresupuesto);
            List<Presupuesto> ListaLocal = new List<Presupuesto>();
            ListaLocal.Add(unPresupuesto);
            Assert.IsTrue(adminPresupuestos.RetornarListaPresupuestos().SequenceEqual(ListaLocal));
        }

        [TestMethod]
        public void RetornarPresupuestoSegunMesPrueba()
        {
            DateTime fecha = new DateTime(2020, 1, 1);
            unPresupuesto.Fecha = fecha;
            adminPresupuestos.AgregarPresupuesto(unPresupuesto);
            Assert.AreEqual(adminPresupuestos.RetornarPresupuestoSegunMes(1, 2020), unPresupuesto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExistente))]
        public void PresupuestoNoExistentePrueba()
        {            
            adminPresupuestos.RetornarPresupuestoSegunMes(1, 2019);
        }

        [TestMethod]
        public void AsignacionDeCategoriasMontoPrueba()
        {
            unaCategoriaMonto.Categoria = unaCategoria;
            unaCategoriaMonto.Monto = 100;
            CategoriaMonto otraCategoriaMonto = new CategoriaMonto { Categoria = otraCategoria, Monto = 300 };
            unPresupuesto.AgregarCategoriaMonto(unaCategoriaMonto);
            unPresupuesto.AgregarCategoriaMonto(otraCategoriaMonto);

            Assert.AreEqual(unPresupuesto.ListaCategoriaMonto.Count, 2);
        }

        [TestMethod]
        public void ModificarMontoACategoriaPrueba()
        {
            unaCategoriaMonto.Categoria = unaCategoria;
            unaCategoriaMonto.Monto = 200;
            unPresupuesto.AgregarCategoriaMonto(unaCategoriaMonto);
            adminPresupuestos.AgregarPresupuesto(unPresupuesto);
            adminPresupuestos.ModificarMontoACategoria(unPresupuesto, unaCategoria, 300);
            Assert.AreEqual(unPresupuesto.ListaCategoriaMonto.First().Monto, 300);
        }

       
        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoRepetido))]
        public void AgregarPresupuestoRepetidoPrueba()
        {
            unaCategoriaMonto.Categoria = unaCategoria;
            unaCategoriaMonto.Monto = 200;
            unPresupuesto.AgregarCategoriaMonto(unaCategoriaMonto);
            adminPresupuestos.AgregarPresupuesto(unPresupuesto);
            adminPresupuestos.AgregarPresupuesto(unPresupuesto);

        }

        [TestMethod]
        public void PresupuestoSegunMesPrueba()
        {
            DateTime fecha = new DateTime(2020, 1, 1);
            unPresupuesto.Fecha = fecha;
            adminPresupuestos.AgregarPresupuesto(unPresupuesto);
            Assert.AreEqual(adminPresupuestos.RetornarPresupuestoSegunMes(1, 2020).Fecha.Month, 1);
        }

        [TestMethod]
        public void RetornarPresupuestoSegunAnioPrueba()
        {
            DateTime fecha = new DateTime(2020, 1, 1);
            unPresupuesto.Fecha = fecha;
            adminPresupuestos.AgregarPresupuesto(unPresupuesto);
            Assert.AreEqual(adminPresupuestos.RetornarPresupuestoSegunMes(1, 2020).Fecha.Year, 2020);
        }

        [TestMethod]
        public void RetornarCategoriaMontoPrueba()
        {
            unPresupuesto.AgregarCategoriaMonto(unaCategoriaMonto);
            List<CategoriaMonto> ListaLocal = new List<CategoriaMonto>();
            ListaLocal.Add(unaCategoriaMonto);
            Assert.IsTrue(adminPresupuestos.RetornarCatMonto(unPresupuesto).SequenceEqual(ListaLocal));
        }
    }
}
