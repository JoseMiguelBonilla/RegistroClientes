using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroClientes.Models;
using RegistroClientes.DAL;
using Microsoft.EntityFrameworkCore;

namespace RegistroClientes.BLL
{
     public class ClientesBLL
    {
        private readonly Contexto _contexto;

        public ClientesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool Guardar(Cliente Clientes)
        {
            // busca si el registro existe, si existe lo modifica y si no lo inserta
            if (!Existe(Clientes.ClienteId))
                return Insertar(Clientes);
            else
                return Modificar(Clientes);
        }

         public bool Existe(int ClienteId)
        {
            return _contexto.Clientes.Any(s => s.ClienteId == ClienteId);
        }

        private bool Insertar(Cliente Clientes)
        {
            _contexto.Clientes.Add(Clientes);
            int cantidad = _contexto.SaveChanges();
            
            _contexto.Entry(Clientes).State = EntityState.Detached;
            return cantidad > 0;
        }

        public bool Modificar(Cliente Clientes)
        {
            _contexto.Update(Clientes);
            int cantidad = _contexto.SaveChanges();

            _contexto.Entry(Clientes).State = EntityState.Detached;
            return cantidad > 0;
        }

        public bool Eliminar(Cliente Clientes)
        {
            _contexto.Clientes.Remove(Clientes);
            int cantidad = _contexto.SaveChanges();

            _contexto.Entry(Clientes).State = EntityState.Detached;
            return cantidad > 0;
        }
        
        public Cliente Buscar(int ClienteId)
        {
            return _contexto.Clientes
                .AsNoTracking()
                .FirstOrDefault(s => s.ClienteId == ClienteId);
        }
 }
}
