using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System;
using Excepciones;

namespace Test
{

    [TestClass]
    public class CategoriaPrueba
    {
        private Categoria categoria;
        private PalabraClave palabraClaveUno;

        [TestInitialize]
        public void InitTests()
        {
            categoria = new Categoria();
            palabraClaveUno = new PalabraClave();
        }

        [TestMethod]
        public void PropertyNombrePrueba()
        {
            categoria.Nombre = "Entretenimiento";
            string nombre = "Entretenimiento";
            Assert.AreEqual(nombre, categoria.Nombre);
        }

        [TestMethod]
        public void PropertyIdCategoriaPrueba()
        {
            categoria.Id = 1;
            Assert.AreEqual(categoria.Id, 1);
        }

        [TestMethod]
        public void CrearCatListaVaciaPrueba()
        {
            Assert.IsTrue(categoria.EsVacia());
        }

        [TestMethod]
        public void AgregarPalabraClavePrueba()
        {
            palabraClaveUno.Palabra = "Cine";
            categoria.AgregarPalabraClave(palabraClaveUno);
            Assert.IsFalse(categoria.EsVacia());
        }

        [TestMethod]
        public void EliminarPalabraClavePrueba()
        {
            palabraClaveUno.Palabra = "Cine";
            categoria.AgregarPalabraClave(palabraClaveUno);
            categoria.BorrarPalabraClave(palabraClaveUno);
            Assert.IsTrue(categoria.EsVacia());
        }

     
        [TestMethod]
        [ExpectedException(typeof(ExcepcionPalabraLarga))]
        public void ValidarNombreCortoPrueba()
        {
            Categoria categoria1 = new Categoria() { Nombre = "B" };
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPalabraLarga))]
        public void ValidarNombreLargoPrueba()
        {
            Categoria categoria2 = new Categoria() { Nombre = "PalabraMuyMuyLarga" };
        }

        [TestMethod]
        public void EqualsPrueba()
        {
            Categoria unaCategoria = new Categoria { Nombre = "Entretenimiento" };
            Categoria otraCategoria = new Categoria { Nombre = "Entretenimiento" };
            Assert.AreEqual(unaCategoria, otraCategoria);
        }

        [TestMethod]
        public void ExistePalabraClavePrueba()
        {
            palabraClaveUno.Palabra = "Cine";
            categoria.AgregarPalabraClave(palabraClaveUno);
            PalabraClave palabraClaveDos = new PalabraClave { Palabra = "cInE" };
            Assert.IsTrue(categoria.ExistePalabraClave(palabraClaveDos));
        }

        [TestMethod]
        public void toStringCategoriaPrueba()
        {
            Assert.AreEqual(categoria.ToString(), "No hay nombre");
        }
    }
}
