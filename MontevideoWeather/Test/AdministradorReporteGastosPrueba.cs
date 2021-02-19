using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Test
{
    [TestClass]
    public class AdministradorReporteGastosPrueba
    {
        private AdministradorGastosRecurrentes adminGastosRecurrentes;
        private GastoRecuerrente unGastoRecuerrente;
        private AdministradorGastosComunes adminGastosComunes;
        private AdministradorReporteGastos adminReporteGastos;
        private Categoria unaCategoria;
        private IRepositorio miRepositorio;
        private GastoComun unGastoComun;
        private Moneda moneda;
        private ExportarTxt exportarTxt;
        private ExportarCsv exportarCsv;

        [TestInitialize]
        public void InitTest()
        {
            miRepositorio = new RepositorioMemoria();
            adminGastosRecurrentes = new AdministradorGastosRecurrentes(miRepositorio);
            adminGastosComunes = new AdministradorGastosComunes(miRepositorio);
            unaCategoria = new Categoria() { Nombre = "Entretenimiento" };
            moneda = new Moneda { Simbolo = "UYU",Cotizacion=1.00 };
            unGastoRecuerrente = new GastoRecuerrente() { Categoria = unaCategoria, Moneda = moneda };
            unGastoComun = new GastoComun() { Categoria = unaCategoria, Moneda = moneda };
            adminReporteGastos = new AdministradorReporteGastos(miRepositorio);
            exportarTxt = new ExportarTxt();
            exportarCsv = new ExportarCsv();
        }


        [TestMethod]
        public void ConvertirGastoRecurrenteMesPrueba()
        {
            unGastoComun = new GastoComun { Categoria = unaCategoria };
            unGastoComun = adminReporteGastos.ConvertirGastoRecurrente(unGastoRecuerrente, 2020, 5);
            Assert.AreEqual(unGastoComun.Fecha.Month, 5);
        }

        [TestMethod]
        public void ConvertirGastoRecurrenteAnioPrueba()
        {
            unGastoComun = new GastoComun { Categoria = unaCategoria };
            Assert.AreEqual(adminReporteGastos.ConvertirGastoRecurrente(unGastoRecuerrente, 2020, 5).Fecha.Year, 2020);
        }

        [TestMethod]
        public void ElementosEnListaGastosRecurrentesConFechaAdecuadaPrueba()
        {
            unGastoRecuerrente.Fecha = 1;
            adminGastosRecurrentes.AgregarGastoRecurrente(unGastoRecuerrente);
            Assert.AreEqual(1, adminReporteGastos.RetornarListaGastosRecurrentesConFechaAdecuada(2020, 10).Count());
        }

        [TestMethod]
        public void DevolverListaDeGastosSegunFechaPrueba()
        {
            unGastoComun.Fecha = new DateTime(2020, 5, 1);
            adminGastosComunes.AgregarGastoComun(unGastoComun);

            GastoComun otroGasto = new GastoComun() { Moneda = moneda, Fecha = new DateTime(2020, 6, 1) };
            otroGasto.Categoria = new Categoria { Nombre = "Auto" };
            adminGastosComunes.AgregarGastoComun(otroGasto);

            List<GastoComun> ListaLocal = new List<GastoComun>();
            ListaLocal.Add(otroGasto);
            Assert.IsTrue(adminReporteGastos.DevolverListaDeGastosComunesSegunFecha(2020,6).SequenceEqual(ListaLocal));
        }
        
        [TestMethod]
        public void UnirListaGastosDelMesPrueba()
        {
            unGastoComun.Fecha = new DateTime(2020, 5, 1);
            adminGastosComunes.AgregarGastoComun(unGastoComun);

            unGastoRecuerrente.Fecha = 1;
            adminGastosRecurrentes.AgregarGastoRecurrente(unGastoRecuerrente);
            Assert.AreEqual(2, adminReporteGastos.UnirListaGastosDelMes(2020, 5).Count());
        }

        [TestMethod]
        public void OrdenarListaMesesDondeHayGastoAnioPrueba()
        {
            unGastoComun.Fecha = new DateTime(2020, 10, 1);
            GastoComun otroGasto = new GastoComun { Moneda = moneda, Fecha = new DateTime(2018, 11, 1) };
            adminGastosComunes.AgregarGastoComun(otroGasto);
        
            Assert.AreEqual(adminReporteGastos.CrearYRetornalListaDeMesesDondeHayGastoOrdenada().First().Year, 2018);
        }

        [TestMethod]
        public void CrearYRetornalListaDeMesesDondeHayGastoOrdenadaPrueba()
        {
            unGastoComun.Fecha = new DateTime(2020, 10, 1);
            GastoComun unGasto = new GastoComun { Moneda = moneda, Fecha = new DateTime(2020, 5, 1) };
            GastoComun otroGasto = new GastoComun { Moneda = moneda, Fecha = new DateTime(2020, 6, 1) };
            adminGastosComunes.AgregarGastoComun(unGastoComun);
            adminGastosComunes.AgregarGastoComun(unGasto);
            adminGastosComunes.AgregarGastoComun(otroGasto);
           
            List<DateTime> ListaLocal = new List<DateTime>();
            ListaLocal.Add(new DateTime(2020, 5, 1));
            ListaLocal.Add(new DateTime(2020, 6, 1));
            ListaLocal.Add(new DateTime(2020, 10, 1));
            Assert.IsTrue(adminReporteGastos.CrearYRetornalListaDeMesesDondeHayGastoOrdenada().SequenceEqual(ListaLocal));

        }

        [TestMethod]
        public void AgregarListaDeMesesDondeHayGastoPrueba()
        {
            unGastoComun.Fecha = new DateTime(2020, 10, 2);
            adminGastosComunes.AgregarGastoComun(unGastoComun);
            Assert.AreEqual(1, adminReporteGastos.CrearYRetornalListaDeMesesDondeHayGastoOrdenada().Count());
        }

        [TestMethod]
        public void AgregarDosRepetidosListaDeMesesDondeHayGastoPrueba()
        {
            unGastoComun.Fecha = new DateTime(2020, 10, 2);
            adminGastosComunes.AgregarGastoComun(unGastoComun);

            GastoComun unGasto = new GastoComun { Categoria = unaCategoria, Moneda = moneda, Fecha = new DateTime(2020, 10, 2) };
            adminGastosComunes.AgregarGastoComun(unGasto);
            Assert.AreEqual(1, adminReporteGastos.CrearYRetornalListaDeMesesDondeHayGastoOrdenada().Count());
        }


        [TestMethod]
        public void AgregarMesesAnioDondeHayGastoPrueba()
        {
            unGastoComun.Fecha = new DateTime(2020, 10, 2);
            adminGastosComunes.AgregarGastoComun(unGastoComun);
            Assert.AreEqual(1, adminReporteGastos.CrearYRetornalListaDeMesesDondeHayGastoOrdenada().Count());
        }
           
        [TestMethod]
        public void ConvertirFechaQuitarElDiaPrueba()
        {
            unGastoComun.Fecha = new DateTime(2020, 5, 28);
            DateTime convertido = adminReporteGastos.ConvertirFechaDejarSoloAnioMes(unGastoComun);
            Assert.IsFalse(convertido.Equals(unGastoComun.Fecha));
           
        }

        [TestMethod]
        public void CalcularMontoDeReportePrueba()
        {
            unGastoComun.Fecha = new DateTime(2020, 10, 28);
            unGastoComun.Monto = 100;
            GastoComun unGasto = new GastoComun { Categoria = unaCategoria, Moneda = moneda, Monto = 100, Fecha = new DateTime(2020, 10, 2) };
            adminGastosComunes.AgregarGastoComun(unGastoComun);
            adminGastosComunes.AgregarGastoComun(unGasto);
            double resultado = 200;
            Assert.AreEqual(resultado, adminReporteGastos.CalcularMontoDeReporte(adminReporteGastos.UnirListaGastosDelMes(2020, 10)));

        }

        [TestMethod]
        public void CalcularGastoTotalDeCategoriaEnMesPrueba()
        {
            
            GastoComun unGasto = new GastoComun { Categoria = unaCategoria, Moneda = moneda, Monto = 100, Fecha = new DateTime(2020, 10, 2) };
            GastoComun otroGasto = new GastoComun { Categoria = unaCategoria, Moneda = moneda, Monto = 200, Fecha = new DateTime(2020, 10, 2) };
            adminGastosComunes.AgregarGastoComun(unGasto);
            adminGastosComunes.AgregarGastoComun(otroGasto);
            double gastoTotalDeCategoriaEnMes = adminReporteGastos.CalcularGastoTotalDeCategoriaEnMes(2020, 10, unaCategoria);
            Assert.AreEqual(gastoTotalDeCategoriaEnMes, 300);
        }

        [TestMethod]
        public void SumaGastosDeUnDiaMesPrueba()
        {
            GastoComun unGasto = new GastoComun { Categoria = unaCategoria, Moneda = moneda, Monto = 100, Fecha = new DateTime(2020, 10, 2), MontoEnPesos = 100 };
            GastoComun otroGasto = new GastoComun { Categoria = unaCategoria, Moneda = moneda, Monto = 200, Fecha = new DateTime(2020, 10, 2), MontoEnPesos = 200 };
            adminGastosComunes.AgregarGastoComun(unGasto);
            adminGastosComunes.AgregarGastoComun(otroGasto);
            List<GastoComun> lista = adminGastosComunes.RetornarListaGastosComunes();
            int dia = unGasto.Fecha.Day;
            double acumulado = adminReporteGastos.SumaGastosDeUnDiaMes(lista, dia);
            Assert.AreEqual(acumulado, 300);
        }
        [TestMethod]
        public void ExportarTXTPrueba()
        {
            adminGastosComunes.AgregarGastoComun(unGastoComun);
            List<GastoComun> ListaLocal = new List<GastoComun>();
            ListaLocal.Add(unGastoComun);
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))

            {
                exportarTxt.Exportar(ListaLocal, stream);
                string actual = Encoding.UTF8.GetString(stream.ToArray());
                Assert.AreEqual("01/05/2020\r\nNo hay descripcion\r\nEntretenimiento\r\nUYU\r\n0\r\n####\r\n", actual);
            }
        }

        [TestMethod]
        public void ExportarCSVPrueba()
        {
            adminGastosComunes.AgregarGastoComun(unGastoComun);
            List<GastoComun> ListaLocal = new List<GastoComun>();
            ListaLocal.Add(unGastoComun);
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            {
                exportarCsv.Exportar(ListaLocal, stream);
                string actual = Encoding.UTF8.GetString(stream.ToArray());
                Assert.AreEqual("01/05/2020,No hay descripcion, Entretenimiento, UYU, 0\r\n", actual);
            }
        }
    }
}
