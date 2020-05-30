using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoPersonasBlazor.BLL;
using ProyectoPersonasBlazor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoPersonasBlazor.BLL.Tests
{
    [TestClass()]
    public class PrestamosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Prestamos prestamo = new Prestamos();

            prestamo.prestamoId = 0;
            prestamo.fecha = DateTime.Now;
            prestamo.monto = 5000;
            prestamo.balance = 0;
            prestamo.concepto = "Compra de propiedades";
            prestamo.personaId = 2;

            paso = PrestamosBLL.Guardar(prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = PrestamosBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso = false;
            Prestamos prestamo = new Prestamos();

            prestamo.prestamoId = 0;
            prestamo.fecha = DateTime.Now;
            prestamo.monto = 5000;
            prestamo.balance = 0;
            prestamo.concepto = "Compra de propiedades";
            prestamo.personaId = 2;

            paso = PrestamosBLL.Insertar(prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Prestamos prestamo = new Prestamos();

            prestamo.prestamoId = 2;
            prestamo.fecha = DateTime.Now;
            prestamo.monto = 5000;
            prestamo.balance = 0;
            prestamo.concepto = "Compra de propiedades";
            prestamo.personaId = 2;

            paso = PrestamosBLL.Modificar(prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Prestamos prestamo = new Prestamos();
            bool paso = false;

            prestamo = PrestamosBLL.Buscar(2);

            if (prestamo != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = PrestamosBLL.Eliminar(1);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GuardarBalancePersonaTest()
        {
            Prestamos prestamo = new Prestamos();
            bool paso = false;

            prestamo.prestamoId = 0;
            prestamo.fecha = DateTime.Now;
            prestamo.monto = 5000;
            prestamo.balance = 0;
            prestamo.concepto = "Compra de propiedades";
            prestamo.personaId = 3;

            PrestamosBLL.Insertar(prestamo);

            Personas persona = PersonasBLL.Buscar(3);

            if (persona.balance == prestamo.balance)
                paso = true;

            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ModificarBalancePersonaTest()
        {
            Prestamos prestamo = new Prestamos();
            bool paso = false;

            prestamo.prestamoId = 5;
            prestamo.fecha = DateTime.Now;
            prestamo.monto = 4000;
            prestamo.balance = 0;
            prestamo.concepto = "Compra de propiedades";
            prestamo.personaId = 3;

            PrestamosBLL.Modificar(prestamo);

            Personas persona = PersonasBLL.Buscar(3);

            if (persona.balance == prestamo.balance)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarBalancePersonaTest()
        {
            Prestamos prestamo = new Prestamos();
            bool paso = false;

            PrestamosBLL.Eliminar(5);

            Personas persona = PersonasBLL.Buscar(3);

            if (persona.balance == prestamo.balance)
                paso = true;

            Assert.AreEqual(paso, true);
        }
    }
}