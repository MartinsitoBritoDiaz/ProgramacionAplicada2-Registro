﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.DependencyModel.Resolution;
using ProyectoPersonasBlazor.DAL;
using ProyectoPersonasBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace ProyectoPersonasBlazor.BLL
{
    public class PrestamosBLL
    {
        public static bool Guardar(Prestamos prestamo)
        {
            if (!Existe(prestamo.prestamoId))
                return Insertar(prestamo);
            else
                return Modificar(prestamo);
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Prestamos.Any(p => p.prestamoId == id);
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

        public static bool Insertar(Prestamos prestamo)
        {
            double valor = 0;
            bool paso = false;
            Contexto contexto = new Contexto();
            
            try
            {
                foreach (var auxiliar in prestamo.MorasDetalle)
                {
                    valor += auxiliar.valor;
                }

                prestamo.balance = prestamo.monto + valor;

                GuardarBalancePersona(prestamo);
                contexto.Prestamos.Add(prestamo);
                paso = (contexto.SaveChanges() > 0);
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

        public static bool Modificar(Prestamos prestamo)
        {
            double valor = 0 ;
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM MorasDetalle Where moraId = {prestamo.prestamoId}");

                foreach (var auxiliar in prestamo.MorasDetalle)
                {
                    contexto.Entry(auxiliar).State = EntityState.Added;
                }

                foreach (var auxiliar in prestamo.MorasDetalle)
                {
                    valor += auxiliar.valor;
                }

                prestamo.balance = prestamo.monto + valor;

                ModificarBalancePersona(prestamo);
                contexto.Entry(prestamo).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
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

        public  static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamo;

            try
            {
                prestamo = contexto.Prestamos
                    .Where(p => p.prestamoId == id)
                    .Include(p => p.MorasDetalle)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return prestamo;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var prestamo = contexto.Prestamos.Find(id);

                if(prestamo != null)
                {
                    EliminarBalancePersona(prestamo);
                    contexto.Prestamos.Remove(prestamo);
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

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> listaPrestamos = new List<Prestamos>();
            Contexto contexto = new Contexto();

            try
            {
                listaPrestamos = contexto.Prestamos.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return listaPrestamos;
        }


        /*Metodos para alterar el balance*/
        public static void GuardarBalancePersona(Prestamos prestamo)
        {
            Personas personas = new Personas();

            personas = PersonasBLL.Buscar(prestamo.personaId);
            personas.balance += prestamo.balance;

            PersonasBLL.Modificar(personas);
        }

        public static void ModificarBalancePersona(Prestamos prestamoNuevo)
        {
            Personas persona = new Personas();
            Prestamos prestamoAntiguo = new Prestamos();

            prestamoAntiguo = PrestamosBLL.Buscar(prestamoNuevo.prestamoId);
            persona = PersonasBLL.Buscar(prestamoNuevo.personaId);
            persona.balance -= prestamoAntiguo.balance;
            persona.balance += prestamoNuevo.balance;

            PersonasBLL.Modificar(persona);
        }

        public static void EliminarBalancePersona(Prestamos prestamo)
        {
            Personas persona = new Personas();

            persona = PersonasBLL.Buscar(prestamo.personaId);
            persona.balance -= prestamo.balance;
            PersonasBLL.Modificar(persona);
        }
    }
}
