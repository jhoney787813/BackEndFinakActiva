using BEndClientes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEndClientes
{
    public class AplicationDbContext : DbContext
    {
      public  DbSet<Cliente> Clientes {get;set; }
       public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext>options):base(options)
        {

        }

    }
}
