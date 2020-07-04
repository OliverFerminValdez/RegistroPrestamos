using RegistrosPrestamos.DAL;
using RegistrosPrestamos.Models;
using RegistrosPrestamos.Pages.Registros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistrosPrestamos.BLL
{
    public class PrestamosBLL
    {
        public static bool Guardar(Prestamo Prestamo)
        {
            if (!Existe(Prestamo.PrestamoId))
                return Insertar(Prestamo);
            else
                return Modificar(Prestamo);
        }

        public static bool Insertar(Prestamo prestamo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (PersonasBLL.Buscar(prestamo.PersonaId) != null)
                {     
                        var persona = PersonasBLL.Buscar(prestamo.PersonaId);
                        persona.Balance += prestamo.Monto;
                        PersonasBLL.Modificar(persona);
                }

                db.Prestamos.Add(prestamo);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Modificar(Prestamo prestamo)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {

                if (PersonasBLL.Buscar(prestamo.PersonaId) != null)
                {
                    var persona = PersonasBLL.Buscar(prestamo.PersonaId);
                    persona.Balance = prestamo.Monto;
                    PersonasBLL.Modificar(persona);
                }

                db.Entry(prestamo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var prestamo = db.Prestamos.Find(id);

                if(prestamo != null)
                {
                    if (PersonasBLL.Buscar(prestamo.PersonaId) != null)
                    {
                        var persona = PersonasBLL.Buscar(prestamo.PersonaId);
                        persona.Balance -= prestamo.Monto;
                        PersonasBLL.Modificar(persona);
                    }
                    prestamo.Balance = prestamo.Monto;
                    db.Prestamos.Remove(prestamo);
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Prestamo Buscar(int id)
        {
            Prestamo persona = new Prestamo();
            Contexto db = new Contexto();

            try
            {
                persona = db.Prestamos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return persona;
        }

        public static List<Prestamo> GetList(Expression<Func<Prestamo, bool>> criterio)
        {
            List<Prestamo> ListaPrestamo = new List<Prestamo>();
            Contexto db = new Contexto();

            try
            {
                ListaPrestamo = db.Prestamos.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return ListaPrestamo;
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.Prestamos.Any(p => p.PrestamoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }
    }
}
