using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ExportarReporteGastoFabricaPrueba
    {
        [TestMethod]
        public void CrearExportarTxtPrueba()
        {
            var ExportarTXT = ExportarReporteGastoFabrica.CrearExportacion("txt");
            Assert.IsNotNull(ExportarTXT);
        }

        [TestMethod]
        public void CrearExportarCsvPrueba()
        {
            var ExportarCSV = ExportarReporteGastoFabrica.CrearExportacion("csv");
            Assert.IsNotNull(ExportarCSV);
        }

        [TestMethod]
        public void CrearExportarXmlPrueba()
        {
            var ExportarXml = ExportarReporteGastoFabrica.CrearExportacion("xml");
            Assert.IsNotNull(ExportarXml);
        }
    }
}
