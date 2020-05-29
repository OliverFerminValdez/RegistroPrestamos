using RegistrosPrestamos.DAL;
using RegistrosPrestamos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistrosPrestamos.BLL
{
    public class PersonasBLL
    {
        public static bool Guardar(Persona Persona)
        {
            if (!Existe(Persona.PersonaId))
                return Insertar(Persona);
            else
                return Modificar(Persona);
        }

        public static bool Insertar(Persona persona)
        {

            bool paso = false;
            Contexto db = new Contexto();

            try
            {

                db.Personas.Add(persona);
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
        public static bool Modificar(Persona persona)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(persona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var persona = db.Personas.Find(id);

                if (persona != null)
                {
                    db.Personas.Remove(persona);
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

        public static Persona Buscar(int id)
        {
            Persona persona = new Persona();
            Contexto db = new Contexto();

            try
            {
                persona = db.Personas.Find(id);
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

        public static List<Persona> GetList(Expression<Func<Persona, bool>> criterio)
        {
            List<Persona> ListaPersona = new List<Persona>();
            Contexto db = new Contexto();

            try
            {
                ListaPersona = db.Personas.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return ListaPersona;
        }

       

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.Personas.Any(p => p.PersonaId == id);
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

        public static List<Persona> GetPersonas()
        {
            List<Persona> List = new List<Persona>();
            Contexto db = new Contexto();

            try
            {
                List = db.Personas.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return List;
        }
    }
}
