using Check02.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Check02.Context
{
    public class Context : DbContext
    {
        public DbSet<MdDono> ctDonos { get; set; }

        public DbSet<MdCao> ctCao { get; set; }

        public DbSet<MdCao_Dono> ctCao_Dono { get; set; }

        public DbSet<MdRaca> ctRacas { get; set; }

        public DbSet<MdServicos> ctServicos { get; set; }

        public DbSet<MdOferta> ctOferta{ get; set; }
    }
}