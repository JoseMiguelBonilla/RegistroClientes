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
    public class TicketsBLL
    {
        private readonly Contexto _contexto;

        public TicketsBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Guardar(Tickets Ticket)
        {
            // busca si el registro existe, si existe lo modifica y si no lo inserta
            if (!Existe(Ticket.TicketsId))
                return Insertar(Ticket);
            else
                return Modificar(Ticket);
        }

         public bool Existe(int TicketId)
        {
            return _contexto.Ticket.Any(s => s.TicketsId == TicketId);
        }

        private bool Insertar(Tickets Ticket)
        {
            _contexto.Ticket.Add(Ticket);
            int cantidad = _contexto.SaveChanges();
            
            _contexto.Entry(Ticket).State = EntityState.Detached;
            return cantidad > 0;
        }

        public bool Modificar(Tickets Ticket)
        {
            _contexto.Update(Ticket);
            int cantidad = _contexto.SaveChanges();

            _contexto.Entry(Ticket).State = EntityState.Detached;
            return cantidad > 0;
        }

        public bool Eliminar(Tickets Ticket)
        {
            _contexto.Ticket.Remove(Ticket);
            int cantidad = _contexto.SaveChanges();

            _contexto.Entry(Ticket).State = EntityState.Detached;
            return cantidad > 0;
        }
        
          public Tickets Buscar(int TicketId)
        {
            return _contexto.Ticket
                .AsNoTracking()
                .FirstOrDefault(s => s.TicketsId == TicketId);
        }
         public List<Tickets> GetList(Expression<Func<Tickets, bool>> Criterio)
        {
            return _contexto.Ticket
                .Where(Criterio)
                .AsNoTracking()
                .ToList();
        }
    }
}