using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DBDomain
{
     class DB_context : DbContext
    {
        public DbSet<DB_highScore> DHighScore { get; set; }
        public DbSet<DB_player> DPlayer { get; set; }

        public DB_context()
        {

        }

        public DB_context(DbContextOptions<DB_context> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                // Om webappen skapar en SamuraiContext så kommer inte detta köras
                // Detta är default. Körs alltså när du använda Update-Database eller från EfSamurai.App-projektet

                optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = CardGame; Trusted_Connection = True; ");
            }
            optionsBuilder.EnableSensitiveDataLogging();

        }

    }
}