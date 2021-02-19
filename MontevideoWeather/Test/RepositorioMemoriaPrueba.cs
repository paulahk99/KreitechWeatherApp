using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Test
{
    [TestClass]
    public class RepositorioMemoriaPrueba
    {
        private IRepositorio Repositorio { get; set; }
        private Categoria UnaCategoria { get; set; }
        private GastoRecuerrente GastoRecuerrente { get; set; }
        private GastoComun GastoComun { get; set; }
        private PalabraClave UnaPalabraClave { get; set; }
        private CategoriaMonto UnaCategoriaMonto { get; set; }
        private Presupuesto UnPresupuesto { get; set; }
        private Moneda UnaMoneda { get; set; }

        [TestInitialize]
        public void InitTests()
        {
            Repositorio = new RepositorioMemoria();
            UnaCategoria = new Categoria();
            GastoRecuerrente = new GastoRecuerrente();
            GastoComun = new GastoComun();
            UnaPalabraClave = new PalabraClave() { Palabra = "Cine" };
            UnaCategoriaMonto = new CategoriaMonto();
            UnPresupuesto = new Presupuesto();
            UnaMoneda = new Moneda();
        }

        [TestMethod]
        public void CrearListaCategoriasVaciaPrueba()
        {
            Assert.IsTrue(Repositorio.EsVaciaListaCategorias());
        }

        [TestMethod]
        public void RetornarListaCategoriasPrueba()
        {
            List<Categoria> ListaLocal = new List<Categoria>();
            Assert.IsTrue(Repositorio.RetornarListaCategorias().SequenceEqual(ListaLocal));
        }

        [TestMethod]
        public void AlAgregarCateogoriaNoEsVacioPrueba()
        {
            Repositorio.AgregarCategoria(UnaCategoria);
            Assert.IsFalse(Repositorio.EsVaciaListaCategorias());
        }

        [TestMethod]
        public void EliminarCategoriaPrueba()
        {
            Repositorio.AgregarCategoria(UnaCategoria);
            Repositorio.EliminarCategoria(UnaCategoria);
            Assert.IsFalse(Repositorio.ExisteCategoria(UnaCategoria));
        }

        [TestMethod]
        public void ExisteCategoriaPrueba()
        {
            Repositorio.AgregarCategoria(UnaCategoria);
            Assert.IsTrue(Repositorio.ExisteCategoria(UnaCategoria));
        }
      
        [TestMethod]
        public void RetornarListaGastosRecurrentesPrueba()
        {
            List<GastoRecuerrente> ListaLocal = new List<GastoRecuerrente>();
            Assert.IsTrue(Repositorio.RetornarListaGastosRecurrentes().SequenceEqual(ListaLocal));
        }
        [TestMethod]
        public void AlAgregarGastoRecuerrenteNoEsVacioPrueba()
        {
            Repositorio.AgregarGastoRecurrente(GastoRecuerrente);
            Assert.IsFalse(Repositorio.EsVaciaListaGastosRecurrentes());
        }
        [TestMethod]
        public void EliminarGastoRecuerrentePrueba()
        {
            Repositorio.AgregarGastoRecurrente(GastoRecuerrente);
            Repositorio.EliminarGastoRecuerrente(GastoRecuerrente);
            Assert.IsFalse(Repositorio.ExisteGastoRecurrente(GastoRecuerrente));
        }

        [TestMethod]
        public void ExisteGastoRecuerrentePrueba()
        {
            Repositorio.AgregarGastoRecurrente(GastoRecuerrente);
            Assert.IsTrue(Repositorio.ExisteGastoRecurrente(GastoRecuerrente));
        }

        [TestMethod]
        public void RetornarListaGastosComunesPrueba()
        {
            List<GastoComun> ListaLocal = new List<GastoComun>();
            Assert.IsTrue(Repositorio.RetornarListaGastosCoumnes().SequenceEqual(ListaLocal));
        }

        [TestMethod]
        public void AlAgregarGastoComunNoEsVacioPrueba()
        {
            Repositorio.AgregarGastoComun(GastoComun);
            Assert.IsFalse(Repositorio.EsVaciaListaGastosComunes());
        }

        [TestMethod]
        public void EliminarGastoComunPrueba()
        {
            Repositorio.AgregarGastoComun(GastoComun);
            Repositorio.EliminarGastoComun(GastoComun);
            Assert.IsFalse(Repositorio.ExisteGastoComun(GastoComun));
        }

        [TestMethod]
        public void ExisteGastoComunPrueba()
        {
            Repositorio.AgregarGastoComun(GastoComun);
            Assert.IsTrue(Repositorio.ExisteGastoComun(GastoComun));
        }

        [TestMethod]
        public void ModificarGastoComunPrueba()
        {
            GastoComun.Id = 1;
            GastoComun otro = new GastoComun() { Id = 1 };
            Repositorio.AgregarGastoComun(otro);
            otro.Descripcion = "Cine";
            Repositorio.ModificarGasto(GastoComun);
            Assert.AreEqual(otro.Descripcion,GastoComun.Descripcion);
        }

        [TestMethod]
        public void AgregarPalabrasEnRepoPrueba()
        {
            Repositorio.AgregarPalabrasEnRepo(UnaCategoria, UnaPalabraClave);
            List<PalabraClave> ListaLocal = new List<PalabraClave>();
            ListaLocal.Add(UnaPalabraClave);
            Assert.IsTrue(Repositorio.RetornarPalabrasClaveDeCategoriaDelRepo(UnaCategoria).SequenceEqual(ListaLocal));
        }
        [TestMethod]
        public void EliminarPalabrasEnRepoPrueba()
        {
            Repositorio.AgregarPalabrasEnRepo(UnaCategoria, UnaPalabraClave);
            Repositorio.EliminarPalabrasEnRepo(UnaCategoria, UnaPalabraClave);
            Assert.IsFalse(UnaCategoria.ExistePalabraClave(UnaPalabraClave));
        }

        [TestMethod]
        public void AgregarCategoriaMontoPrueba()
        {
            Repositorio.AgregarCategoriaMonto(UnaCategoriaMonto, UnPresupuesto);
            List<CategoriaMonto> ListaLocal = new List<CategoriaMonto>();
            ListaLocal.Add(UnaCategoriaMonto);
            Assert.IsTrue(Repositorio.RetornarCategoriaMontoDelRepo(UnPresupuesto).SequenceEqual(ListaLocal));
        }

        [TestMethod]
        public void ExisteMonedaPrueba()
        {
            Repositorio.AgregarMoneda(UnaMoneda);
            Assert.IsTrue(Repositorio.ExisteMoneda(UnaMoneda));
        }

        [TestMethod]
        public void RetornarListaMonedasPrueba()
        {
            List<Moneda> ListaLocal = new List<Moneda>();
            Assert.IsTrue(Repositorio.RetornarListaMonedas().SequenceEqual(ListaLocal));
        }

        [TestMethod]
        public void ExisteUnPresupuestoPrueba()
        {
            UnPresupuesto.Fecha = new DateTime(2020, 5, 1);
            Repositorio.AgregarPresupuesto(UnPresupuesto);
            Assert.IsTrue(Repositorio.ExisteUnPresupuesto(UnPresupuesto.Fecha));
        }

        [TestMethod]
        public void AgregarPresupuestoPrueba()
        {
            UnPresupuesto.Fecha= new DateTime(2020, 5, 1);
            Repositorio.AgregarPresupuesto(UnPresupuesto);
            List<Presupuesto> ListaLocal = new List<Presupuesto>();
            ListaLocal.Add(UnPresupuesto);
            Assert.IsTrue(Repositorio.RetornarListaPresupuestos().SequenceEqual(ListaLocal));
        }

        [TestMethod]
        public void ModificarNombreAMonedaPrueba()
        {
            Repositorio.AgregarMoneda(UnaMoneda);
            Repositorio.ModificarNombreAMoneda(UnaMoneda, "Peso");
            Assert.AreEqual(UnaMoneda.Nombre, "Peso");
        }
    }
}
