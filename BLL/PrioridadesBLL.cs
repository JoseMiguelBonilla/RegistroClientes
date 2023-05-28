using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroClientes.Models;
using RegistroClientes.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RegistroClientes.BLL
{
    public class PrioridadesBLL
    {
        private readonly Contexto _contexto;

        public PrioridadesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Guardar(Prioridades Prioridad)
        {
            // busca si el registro existe, si existe lo modifica y si no lo inserta
            if (!Existe(Prioridad.PrioridadId))
                return Insertar(Prioridad);
            else
                return Modificar(Prioridad);
        }

         public bool Existe(int PrioridadId)
        {
            return _contexto.Prioridad.Any(s => s.PrioridadId == PrioridadId);
        }

        private bool Insertar(Prioridades Prioridad)
        {
            _contexto.Prioridad.Add(Prioridad);
            int cantidad = _contexto.SaveChanges();
            
            _contexto.Entry(Prioridad).State = EntityState.Detached;
            return cantidad > 0;
        }

        public bool Modificar(Prioridades Prioridad)
        {
            _contexto.Update(Prioridad);
            int cantidad = _contexto.SaveChanges();

            _contexto.Entry(Prioridad).State = EntityState.Detached;
            return cantidad > 0;
        }

        public bool Eliminar(Prioridades Prioridad)
        {
            _contexto.Prioridad.Remove(Prioridad);
            int cantidad = _contexto.SaveChanges();

            _contexto.Entry(Prioridad).State = EntityState.Detached;
            return cantidad > 0;
        }
        
          public Prioridades Buscar(int PrioridadId)
        {
            return _contexto.Prioridad
                .AsNoTracking()
                .FirstOrDefault(s => s.PrioridadId == PrioridadId);
        }
         public List<Prioridades> GetList(Expression<Func<Prioridades, bool>> Criterio)
        {
            return _contexto.Prioridad
                .Where(Criterio)
                .AsNoTracking()
                .ToList();
        }
    }
}