using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoPersonasBlazor.BLL;
using ProyectoPersonasBlazor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoPersonasBlazor.BLL.Tests
{
    [TestClass()]
    public class MorasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Moras mora = new Moras();

            mora.moraId = 0;
            mora.fecha = DateTime.Now;
            mora.total = 5000;

            paso = MorasBLL.Guardar(mora);

            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = MorasBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso = false;
            Moras mora = new Moras();

            mora.moraId = 0;
            mora.fecha = DateTime.Now;
            mora.total = 5000;

            paso = MorasBLL.Guardar(mora);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Moras mora = new Moras();

            mora.moraId = 2;
            mora.fecha = DateTime.Now;
            mora.total = 5000;

            paso = MorasBLL.Guardar(mora);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso = false;

            Moras mora = MorasBLL.Buscar(1);

            if (mora != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = MorasBLL.Eliminar(1);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}