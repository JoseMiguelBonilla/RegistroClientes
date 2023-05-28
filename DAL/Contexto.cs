using System;
using Microsoft.EntityFrameworkCore;
using RegistroClientes.Models;

namespace RegistroClientes.DAL

{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Tickets> Ticket {get; set;}
        public DbSet<Prioridades> Prioridad {get; set;}
        public Contexto(DbContextOptions<Contexto>options): base(options){}

    }
}