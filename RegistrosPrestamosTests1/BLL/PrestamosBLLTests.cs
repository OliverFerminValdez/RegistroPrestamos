using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistrosPrestamos.BLL;
using RegistrosPrestamos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrosPrestamos.BLL.Tests
{
    [TestClass()]
    public class PrestamosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Prestamo prestamo = new Prestamo();

            prestamo.PersonaId = 1;
            prestamo.Fecha = DateTime.Now;
            prestamo.Concepto = "Deuda";
            prestamo.Balance = 300;
            prestamo.Monto = 300;

            bool guardado = PrestamosBLL.Guardar(prestamo);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Prestamo prestamo = PrestamosBLL.Buscar(3);
            prestamo.Concepto = "x";

            bool modificado = PrestamosBLL.Modificar(prestamo);

            Assert.AreEqual(modificado,true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool eliminado = PrestamosBLL.Eliminar(4);
            Assert.AreEqual(eliminado, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Prestamo prestamo = PrestamosBLL.Buscar(1);

            Assert.IsNotNull(prestamo);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Prestamo> lista = PrestamosBLL.GetList(p => true);

            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool existe = PrestamosBLL.Existe(1);

            Assert.AreEqual(existe, true);
        }
    }
}