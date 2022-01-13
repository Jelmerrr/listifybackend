using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Listify_Backend.DataModels
{
    public class Context : DbContext
    {
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Songs> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server = database,1433; Database = dbi459818_listifydb; User Id = sa; Password = m3ZS5g9YjPjct5am;"); //docker
            optionsBuilder.UseSqlServer("Server = mssql.fhict.local; Database = dbi459818_listifydb; User Id = dbi459818_listifydb; Password = ListifyDB;"); //non-docker
        }
    }
    }
}
