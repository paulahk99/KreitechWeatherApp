using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Test
{
    [TestClass]
    public class AdministradorGastosRecurrentesPrueba
    {
        private AdministradorGastosRecurrentes adminGastosRecurrentes;
        private GastoRecuerrente unGastoRecuerrente;
        private Categoria unaCategoria;
        private IRepositorio miRepositorio;
        private Moneda unaMoneda;

        [TestInitialize]
        public void InitTest()
        {
            miRepositorio = new RepositorioMemoria();
            adminGastosRecurrentes = new AdministradorGastosRecurrentes(miRepositorio);
            unaCategoria = new Categoria() { Nombre = "Entretenimiento" };
            unaMoneda = new Moneda() {Nombre = "Pesos", Cotizacion = 2.00, Simbolo= "UYU" };

            unGastoRecuerrente = new GastoRecuerrente() {Categoria = unaCategoria, Descripcion = "desc", Fecha= 1, Moneda = unaMoneda, Monto = 300};
            unaCategoria = new Categoria();
        }

        [TestMethod]
        public void RetornarListaGastosRecurrentesPrueba()
        {
            List<GastoRecuerrente> ListaLocal = new List<GastoRecuerrente>();
            Assert.IsTrue(adminGastosRecurrentes.RetornarListaGastosRecurrentes().SequenceEqual(ListaLocal));
        }

        [TestMethod]
        public void AgregarGastoComunConCategoriaDefinidaPrueba()
        {
            adminGastosRecurrentes.AgregarGastoRecurrente(unGastoRecuerrente);
            Assert.IsFalse(adminGastosRecurrentes.EsVaciaListaGastosRecurrentes());
        }
        [TestMethod]
        public void EliminarGastoRecurrentePrueba()
        {
            adminGastosRecurrentes.AgregarGastoRecurrente(unGastoRecuerrente);
            adminGastosRecurrentes.EliminarGastoRecurrente(unGastoRecuerrente);
            Assert.IsTrue(adminGastosRecurrentes.EsVaciaListaGastosRecurrentes());
        }

        [TestMethod]
        public void ModificarDescripcionGastoRecurrentePrueba()
        {
            unGastoRecuerrente.Descripcion = "luz";
            adminGastosRecurrentes.AgregarGastoRecurrente(unGastoRecuerrente);
            adminGastosRecurrentes.ModificarDescripcion(unGastoRecuerrente, "agua");
            Assert.AreEqual(unGastoRecuerrente.Descripcion, "agua");
        }

        [TestMethod]
        public void ModificarCategoriaAGastoRecurrentePrueba()
        {
            Categoria otraCategoria  = new Categoria();
            adminGastosRecurrentes.AgregarGastoRecurrente(unGastoRecuerrente);
            adminGastosRecurrentes.ModificarCategoria(unGastoRecuerrente, otraCategoria);
            Assert.AreEqual(unGastoRecuerrente.Categoria, otraCategoria);
        }
       
        [TestMethod]
        public void ModificarDiaDelMesAGastoRecurrentePrueba()
        {
            adminGastosRecurrentes.AgregarGastoRecurrente(unGastoRecuerrente);
            adminGastosRecurrentes.ModificarDiaDelMes(unGastoRecuerrente, 2);
            Assert.AreEqual(unGastoRecuerrente.Fecha, 2);
        }

        [TestMethod]
        public void ModificarMontoAGastoRecurrentePrueba()
        {
            adminGastosRecurrentes.AgregarGastoRecurrente(unGastoRecuerrente);
            adminGastosRecurrentes.ModificarMonto(unGastoRecuerrente, 200);
            Assert.AreEqual(unGastoRecuerrente.Monto, 200);
        }

        [TestMethod]
        public void ModificarMonedaAGastoRecurrentePrueba()
        {
            Moneda otraMoneda = new Moneda(){ Nombre = "Euros", Cotizacion = 2.00, Simbolo = "Eu" };
            adminGastosRecurrentes.AgregarGastoRecurrente(unGastoRecuerrente);
            adminGastosRecurrentes.ModificarMoneda(unGastoRecuerrente, otraMoneda);
            Assert.AreEqual(unGastoRecuerrente.Moneda, otraMoneda);
        }
    }
}
