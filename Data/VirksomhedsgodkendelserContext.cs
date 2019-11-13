using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Virksomhedsgodkendelser.Models;

namespace Virksomhedsgodkendelser.Data
{
    public class VirksomhedsgodkendelserContext : DbContext
    {
        public VirksomhedsgodkendelserContext (DbContextOptions<VirksomhedsgodkendelserContext> options)
            : base(options)
        {
        }

        public DbSet<Virksomhedsgodkendelser.Models.Company> Company { get; set; }
    }
}
