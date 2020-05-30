using Microsoft.EntityFrameworkCore;
using ProyectoPersonasBlazor.DAL;
using ProyectoPersonasBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProyectoPersonasBlazor.BLL
{
    public class PersonasBLL
    {

        public static bool Guardar(Personas personas)
        {
            if (!Existe(personas.personaId))
                return Insertar(personas);
            else
                return Modificar(personas);
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Personas.Any(p => p.personaId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Insertar(Personas personas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Personas.Add(personas);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Personas personas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(personas).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Personas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Personas persona;


            try
            {
                persona = contexto.Personas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return persona;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var persona = contexto.Personas.Find(id);

                if (persona != null)
                {
                    contexto.Personas.Remove(persona);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static List<Personas> GetList(Expression<Func<Personas, bool>> criterio)
        {
            List<Personas> listaPersonas = new List<Personas>();
            Contexto contexto = new Contexto();

            try
            {
                listaPersonas = contexto.Personas.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return listaPersonas;
        }

        public static List<Personas> GetPersonas()
        {
            List<Personas> listaPersonas = new List<Personas>();
            Contexto contexto = new Contexto();
            try
            {
                listaPersonas = contexto.Personas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return listaPersonas;
        }
    }
}
