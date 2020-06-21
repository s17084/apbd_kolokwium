using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KolowkiumAPDB.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int IdAlbum { get; set; }

        [Required]
        [MaxLength(30)]
        public string AlbumName { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        public int IdMusicLabel { get; set; }

        [ForeignKey("IdMusicLabel")]
        public MusicLabel MusicLabel { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}
