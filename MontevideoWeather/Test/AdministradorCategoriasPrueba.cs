using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using Excepciones;

namespace Test
{

    [TestClass]
    public class AdministradorCategoriasPrueba
    {
        private IRepositorio miRepositorio;
        private AdministradorCategorias adminCategorias;
        private Categoria unaCategoria;
        private PalabraClave palabraClaveUno;
        private PalabraClave palabraClaveDos;
        private PalabraClave palabraClaveTres;
        private PalabraClave palabraClaveCuatro;

        [TestInitialize]
        public void InitTests()
        {
            miRepositorio = new RepositorioMemoria();
            adminCategorias = new AdministradorCategorias(miRepositorio);
            unaCategoria = new Categoria();
            palabraClaveUno = new PalabraClave();
            palabraClaveDos = new PalabraClave();
            palabraClaveTres = new PalabraClave();
            palabraClaveCuatro = new PalabraClave();
        }

        [TestMethod]
        public void RetornarListaCategoriasPrueba()
        {
            List<Categoria> ListaLocal = new List<Categoria>();
            Assert.IsTrue(adminCategorias.RetornarListaCategorias().SequenceEqual(ListaLocal));
         }

        [TestMethod]
        public void RetornarCategoriaDePalabraClavePrueba()
        {
            Categoria c1 = new Categoria { Nombre = "Entretenimiento" };
            palabraClaveUno.Palabra = "Cine";
            palabraClaveDos.Palabra = "Serie";
            c1.AgregarPalabraClave(palabraClaveUno);
            c1.AgregarPalabraClave(palabraClaveDos);
            adminCategorias.AgregarCategoria(c1);

            Categoria c2 = new Categoria { Nombre = "Gastronimia" };
            palabraClaveTres.Palabra = "Salir";
            palabraClaveCuatro.Palabra = "Demorondanga";
            c2.AgregarPalabraClave(palabraClaveTres);
            c2.AgregarPalabraClave(palabraClaveCuatro);
            adminCategorias.AgregarCategoria(c2);

            unaCategoria = adminCategorias.CategoriaDePalabraClave(palabraClaveUno);
            Assert.AreEqual(c1, unaCategoria);
        }

        [TestMethod]
        public void PalabraClaveYaIngresadaEnAlgunaListaPrueba()
        {
            Categoria cat = new Categoria { Nombre = "Auto" };
            palabraClaveUno.Palabra = "Nafta";
            cat.AgregarPalabraClave(palabraClaveUno);
            adminCategorias.AgregarCategoria(cat);
            Assert.IsTrue(adminCategorias.PalabraClaveYaIngresadaEnAlgunaLista(palabraClaveUno));
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExistente))]
        public void BuscarPalabraQueNoEstaCateogiraPrueba()
        {
            palabraClaveUno.Palabra = "Manzana";
            adminCategorias.CategoriaDePalabraClave(palabraClaveUno);
        }

        [TestMethod]
        public void IgnorarMayusculasMinusulasCategoriaPrueba()
        {
            Categoria c1 = new Categoria { Nombre = "Auto" };
            palabraClaveUno.Palabra = "Nafta";
            palabraClaveDos.Palabra = "Patente";
            c1.AgregarPalabraClave(palabraClaveUno);
            c1.AgregarPalabraClave(palabraClaveDos);
            adminCategorias.AgregarCategoria(c1);
            palabraClaveTres.Palabra = "nAfta";
            unaCategoria = adminCategorias.CategoriaDePalabraClave(palabraClaveTres);
            Assert.AreEqual(c1, unaCategoria);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoRepetido))]
        public void NoAgregarCategoriaRepetidaPrueba()
        {
            Categoria categoria = new Categoria { Nombre = "Hogar" };
            adminCategorias.AgregarCategoria(categoria);
            Categoria otraCategoria = new Categoria { Nombre = "Hogar" };
            adminCategorias.AgregarCategoria(otraCategoria);
        }

        [TestMethod]
        public void CantDeCategoriasDistintasDondeApareceLaDescripcionPrueba()
        {
            Categoria catrgoria = new Categoria { Nombre = "Entretenimiento" };
            palabraClaveUno.Palabra = "Cine";
            catrgoria.AgregarPalabraClave(palabraClaveUno);
            adminCategorias.AgregarCategoria(catrgoria);

            Categoria otraCatrgoria = new Categoria { Nombre = "GoingOut" };
            palabraClaveDos.Palabra = "Salida";
            otraCatrgoria.AgregarPalabraClave(palabraClaveDos);
            adminCategorias.AgregarCategoria(otraCatrgoria);

            string descripcion = "Salida al Cine";

            Assert.AreEqual(2, adminCategorias.CantDeCategoriasDistintasDondeApareceLaDescripcion(descripcion));

        }

        [TestMethod]
        public void RetornarCategoriaDeDescripcionPrueba()
        {
            Categoria catrgoria = new Categoria { Nombre = "Entretenimiento" };
            palabraClaveUno.Palabra = "Cine";
            catrgoria.AgregarPalabraClave(palabraClaveUno);
            adminCategorias.AgregarCategoria(catrgoria);
            Assert.AreEqual(catrgoria, adminCategorias.RetornarCategoriaDeDescripcion("Voy al Cine"));
        }

        [TestMethod]
        public void CantDeCategoriasDistintasDeDescripcionPrueba()
        {
            Categoria catrgoria = new Categoria { Nombre = "Entretenimiento" };
            palabraClaveUno.Palabra = "Cine";
            catrgoria.AgregarPalabraClave(palabraClaveUno);
            palabraClaveDos.Palabra = "Peli";
            catrgoria.AgregarPalabraClave(palabraClaveDos);
            adminCategorias.AgregarCategoria(catrgoria);
            string descripcion = "Peli al Cine";
            Assert.AreEqual(1, adminCategorias.CantDeCategoriasDistintasDondeApareceLaDescripcion(descripcion));
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionElementoNoExistente))]
        public void RetornarCategoriaDeDescripcionQueNoEstaPrueba()
        {
            adminCategorias.RetornarCategoriaDeDescripcion("Manzana");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RetornarCategoriaDeDescripcionConVariasPalabrasClavesPrueba()
        {
            Categoria catrgoria = new Categoria { Nombre = "Entretenimiento" };
            palabraClaveUno.Palabra = "Cine";
            catrgoria.AgregarPalabraClave(palabraClaveUno);
            adminCategorias.AgregarCategoria(catrgoria);

            Categoria otraCatrgoria = new Categoria { Nombre = "GoingOut" };
            palabraClaveDos.Palabra = "Salida";
            otraCatrgoria.AgregarPalabraClave(palabraClaveDos);
            adminCategorias.AgregarCategoria(otraCatrgoria);
            adminCategorias.RetornarCategoriaDeDescripcion("Salida al Cine");
        }

        [TestMethod]
        public void AgregarCategoriaPrueba()
        {
            adminCategorias.AgregarCategoria(unaCategoria);
            Assert.IsFalse(adminCategorias.EsVaciaListaCategorias());
        }

        [TestMethod]
        public void EsVaciaListaCategoriasPrueba()
        {
            Assert.IsTrue(adminCategorias.EsVaciaListaCategorias());
        }

        [TestMethod]
        public void AgregarPalabraCalveCategoriaSeleccionadaPrueba()
        {
            adminCategorias.AgregarCategoria(unaCategoria);
            palabraClaveUno.Palabra = "Peaje";
            adminCategorias.AgregarPalabraClaveACategoria(unaCategoria, palabraClaveUno);
            Assert.AreEqual(unaCategoria, adminCategorias.CategoriaDePalabraClave(palabraClaveUno));
        }

        [TestMethod]
        public void EliminarPalabraClaveACategoriaPrueba()
        {
            adminCategorias.AgregarCategoria(unaCategoria);
            palabraClaveUno.Palabra = "Peaje";
            adminCategorias.AgregarPalabraClaveACategoria(unaCategoria, palabraClaveUno);
            adminCategorias.BorrarPalabraClaveACategoria(unaCategoria, palabraClaveUno);
            Assert.IsTrue(unaCategoria.EsVacia());
        }

        [TestMethod]
        public void RetornarPalabrasClaveCategoriaPrueba()
        {
            adminCategorias.AgregarCategoria(unaCategoria);
            palabraClaveUno.Palabra = "PEAJE";
            adminCategorias.AgregarPalabraClaveACategoria(unaCategoria, palabraClaveUno);
            adminCategorias.RetornarPalabrasClaveDeCategoria(unaCategoria);
            Assert.IsFalse(unaCategoria.EsVacia());
        }

        [TestMethod]
        public void ConvertirStringACategoriaPrueba()
        {
            unaCategoria.Nombre = "Entretenimiento";
            adminCategorias.AgregarCategoria(unaCategoria);
            Assert.AreEqual(adminCategorias.RetornarCategoriaSegunString("Entretenimiento"), unaCategoria);
        }

        [TestMethod]
        public void EliminarCategoriaPrueba()
        {
            adminCategorias.AgregarCategoria(unaCategoria);
            adminCategorias.EliminarCategoria(unaCategoria);
            Assert.IsTrue(adminCategorias.EsVaciaListaCategorias());
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ListaMax10PalabrasPrueba()
        {
            palabraClaveUno.Palabra = "Manzana";
            for (int i = 0; i < 11; i++)
            {
                adminCategorias.AgregarPalabraClaveACategoria(unaCategoria,palabraClaveUno);
            }
        }
    }
}
