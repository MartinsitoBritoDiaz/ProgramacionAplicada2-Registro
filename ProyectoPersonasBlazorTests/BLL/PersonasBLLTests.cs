using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoPersonasBlazor.BLL;
using ProyectoPersonasBlazor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Sdk;

namespace ProyectoPersonasBlazor.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Personas persona = new Personas();
            bool paso = false;

            persona.personaId = 0;
            persona.nombre = "Miguel";
            persona.telefono = "8098010738";
            persona.cedula = "40233030523";
            persona.direccion = "Nagua";
            persona.fechaNacimiento = DateTime.Now;

            paso = PersonasBLL.Guardar(persona);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = PersonasBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            Personas persona = new Personas();
            bool paso = false;

            persona.personaId = 0;
            persona.nombre = "Martinsito";
            persona.telefono = "8098010738";
            persona.cedula = "40233030523";
            persona.direccion = "Nagua";
            persona.fechaNacimiento = DateTime.Now;

            paso = PersonasBLL.Insertar(persona);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Personas persona = new Personas();
            bool paso = false;

            persona.personaId = 1;
            persona.nombre = "Marcos";
            persona.telefono = "8098010738";
            persona.cedula = "40233030523";
            persona.direccion = "Nagua";
            persona.fechaNacimiento = DateTime.Now;

            paso = PersonasBLL.Modificar(persona);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso = false;
         
            Personas persona = PersonasBLL.Buscar(1);

            if (persona != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = PersonasBLL.Eliminar(1);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPersonasTest()
        {
            Assert.Fail();
        }
    }
}