using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KolowkiumAPDB.Models
{
    public class Musician_Track
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMusicianTrack { get; set; }

        public int IdMusician { get; set; }

        [ForeignKey("IdMusician")]
        public Musician Musician { get; set; }

        public int IdTrack { get; set; }

        [ForeignKey("IdTrack")]
        public Track Track { get; set; }

    }
}
