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

        public DbSet<Virksomhedsgodkendelser.Models.Region> Region { get; set; }

        public DbSet<Virksomhedsgodkendelser.Models.Municipality> Municipality { get; set; }

        public DbSet<Virksomhedsgodkendelser.Models.District> District { get; set; }

        public DbSet<Virksomhedsgodkendelser.Models.Approval> Approval { get; set; }

        public DbSet<Virksomhedsgodkendelser.Models.Education> Education { get; set; }

        public DbSet<Virksomhedsgodkendelser.Models.Specialisation> Specialisation { get; set; }
    }
}
