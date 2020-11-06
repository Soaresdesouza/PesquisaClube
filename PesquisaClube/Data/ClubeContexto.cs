using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesquisaClube.Models
{
    public class ClubeContexto : DbContext
    {

        public ClubeContexto(DbContextOptions<ClubeContexto> options) : base(options)
        {

        }

        public DbSet<Clube> Clube { get; set; }
    }
}
