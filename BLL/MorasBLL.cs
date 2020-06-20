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
    public class MorasBLL
    {

        public static bool Guardar(Moras mora)
        {
            if (!Existe(mora.moraId))
                return Insertar(mora);
            else
                return Modificar(mora);
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Moras.Any(m => m.moraId == id);
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

        public static bool Insertar(Moras mora)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Moras.Add(mora);
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

        public static bool Modificar(Moras mora)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(mora).State = EntityState.Modified;
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

        public static Moras Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Moras mora;


            try
            {
                mora = contexto.Moras.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return mora;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var mora = contexto.Moras.Find(id);

                if (mora != null)
                {
                    contexto.Moras.Remove(mora);
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

        public static List<Moras> GetList(Expression<Func<Moras, bool>> criterio)
        {
            List<Moras> listaMoras = new List<Moras>();
            Contexto contexto = new Contexto();

            try
            {
                listaMoras = contexto.Moras.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return listaMoras;
        }
    }
}
