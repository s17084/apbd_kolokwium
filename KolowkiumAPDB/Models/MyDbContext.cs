using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolowkiumAPDB.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }

        public DbSet<Musician> Musicians { get; set; }

        public DbSet<Musician_Track> Musician_Tracks { get; set; }

        public DbSet<MusicLabel> MusicLabels { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public MyDbContext()
        {
            
        }

        public MyDbContext( DbContextOptions options)
            :base(options)
        {

        }
    }
}
