using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KolowkiumAPDB.Models
{
    public class Track
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTrack { get; set; }

        [Required]
        [MaxLength(30)]
        public string TrackName { get; set; }

        [Required]
        public float Duration { get; set; }

        public int? IdMusicAlbum { get; set; }

        [ForeignKey("IdMusicAlbum")]
        public Album Album { get; set; }

        public ICollection<Musician_Track> Musician_Tracks { get; set; }

    }
}
