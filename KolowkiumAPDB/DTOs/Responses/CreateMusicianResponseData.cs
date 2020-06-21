using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolowkiumAPDB.DTOs.Responses
{
    public class CreateMusicianResponseData
    {
        public int IdMusician { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }
    }
}
