using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistrosPrestamos.BLL;
using RegistrosPrestamos.Models;
using RegistrosPrestamos.Pages.Registros;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrosPrestamos.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Persona personas = new Persona();

            personas.PersonaId = 0;
            personas.Nombre = "antonio";
            personas.Nacimiento = DateTime.Now;
            personas.Telefono = "92304923423";
            personas.Cedula = "092340234";
            personas.Balance = 0;
            personas.Direccion = "Castillo";

            bool guardado = PersonasBLL.Guardar(personas);

            Assert.AreEqual(true, guardado);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Persona persona = PersonasBLL.Buscar(1);
            persona.Nombre = "Oliver Jose Fermin";

            bool modificado = PersonasBLL.Modificar(persona);

            Assert.AreEqual(modificado, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = PersonasBLL.Eliminar(3);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var Persona = PersonasBLL.Buscar(1);
            Assert.IsNotNull(Persona);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Persona> lista = PersonasBLL.GetList(p => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool persona = PersonasBLL.Existe(1);
            Assert.AreEqual(persona, true);
        }

        [TestMethod()]
        public void GetPersonasTest()
        {
            List<Persona> lista = PersonasBLL.GetPersonas();
            Assert.IsNotNull(lista);
        }
    }
}