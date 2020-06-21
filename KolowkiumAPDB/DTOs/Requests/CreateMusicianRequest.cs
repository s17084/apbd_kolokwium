using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KolowkiumAPDB.DTOs.Requests
{
    public class MusicianTrackRequest
    {
        public string TrackName { get; set; }
        public float Duration { get; set; }
    }

    public class CreateMusicianRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Nickname { get; set; }

        public MusicianTrackRequest Track { get; set; }
    }
}
