using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolowkiumAPDB.DTOs.Responses
{
    public class MusicianTracksData
    {
        public int IdTrack { get; set; }

        public string TrackName { get; set; }

        public float Duration { get; set; }

    }

    public class MusicianDataResponse
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public ICollection<MusicianTracksData> MusicianTracks { get; set; }
    }
}
