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

            MorasDetalle detalle = new MorasDetalle();

            detalle.fecha = DateTime.Now;
            detalle.moraId = 1;
            detalle.morasDetalleId = 0;
            detalle.prestamoId = 0;
            detalle.valor = 500;

            prestamo.MorasDetalle.Add(detalle);

            paso = PrestamosBLL.Guardar(prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = PrestamosBLL.Existe(3);
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
            prestamo.personaId = 1;

            MorasDetalle detalle = new MorasDetalle();

            detalle.fecha = DateTime.Now;
            detalle.moraId = 1;
            detalle.morasDetalleId = 0;
            detalle.prestamoId = 0;
            detalle.valor = 500;

            prestamo.MorasDetalle.Add(detalle);

            paso = PrestamosBLL.Insertar(prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Prestamos prestamo = new Prestamos();

            prestamo.prestamoId = 1;
            prestamo.fecha = DateTime.Now;
            prestamo.monto = 5000;
            prestamo.balance = 0;
            prestamo.concepto = "Compra de propiedades";
            prestamo.personaId = 1;

            MorasDetalle detalle = new MorasDetalle();

            detalle.fecha = DateTime.Now;
            detalle.moraId = 1;
            detalle.morasDetalleId = 0;
            detalle.prestamoId = 0;
            detalle.valor = 500;

            prestamo.MorasDetalle.Add(detalle);

            paso = PrestamosBLL.Modificar(prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Prestamos prestamo = new Prestamos();
            bool paso = false;

            prestamo = PrestamosBLL.Buscar(1);

            if (prestamo != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = PrestamosBLL.Eliminar(3);

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
            prestamo.personaId = 2;

            MorasDetalle detalle = new MorasDetalle();

            detalle.fecha = DateTime.Now;
            detalle.moraId = 1;
            detalle.morasDetalleId = 0;
            detalle.prestamoId = 0;
            detalle.valor = 500;

            prestamo.MorasDetalle.Add(detalle);

            PrestamosBLL.Insertar(prestamo);

            Personas persona = PersonasBLL.Buscar(2);

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
            prestamo.personaId = 2;

            MorasDetalle detalle = new MorasDetalle();

            detalle.fecha = DateTime.Now;
            detalle.moraId = 1;
            detalle.morasDetalleId = 0;
            detalle.prestamoId = 0;
            detalle.valor = 500;

            prestamo.MorasDetalle.Add(detalle);

            PrestamosBLL.Modificar(prestamo);

            Personas persona = PersonasBLL.Buscar(2);

            if (persona.balance == prestamo.balance)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarBalancePersonaTest()
        {
            Prestamos prestamo = new Prestamos();
            bool paso = false;

            PrestamosBLL.Eliminar(2);

            Personas persona = PersonasBLL.Buscar(1);

           if (persona.balance == prestamo.balance)
                paso = true;

            Assert.AreEqual(paso, true);
        }
    }
}