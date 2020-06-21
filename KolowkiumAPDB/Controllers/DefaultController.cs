using System;
using System.Collections.Generic;
using System.Linq;
using KolowkiumAPDB.DTOs.Requests;
using KolowkiumAPDB.DTOs.Responses;
using KolowkiumAPDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KolowkiumAPDB.Controllers
{
    [Route("api/musicians")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly MyDbContext _context;

        public DefaultController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetPrzyklad(int id)
        {
            Musician musician;
            try
            {
                musician = _context.Musicians.Where(m => m.IdMusician == id).Single();
            }
            catch (ArgumentNullException e)
            {
                return NotFound("No such musician");
            }

            var musician_tracks = _context.Musician_Tracks.Where(mt => mt.IdMusician == id).Include(mt => mt.Track).ToList();

            ICollection<MusicianTracksData> musicianTracks = new List<MusicianTracksData>();

            foreach (var i in musician_tracks)
            {
                musicianTracks.Add(new MusicianTracksData
                {
                    IdTrack=i.Track.IdTrack,
                    Duration=i.Track.Duration,
                    TrackName=i.Track.TrackName
                });
            }

            var response = new MusicianDataResponse
            {
                FirstName = musician.FirstName,
                LastName = musician.LastName,
                Nickname = musician.Nickname,
                MusicianTracks = musicianTracks,
            };

            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateNewMusician(CreateMusicianRequest request)
        {
            if(_context.Musicians.Any(m => m.FirstName == request.FirstName && m.LastName == request.LastName && m.Nickname == request.Nickname))
            {
                return BadRequest("Such musician already exists");
            }

            Track track;
            if(!_context.Tracks.Any(t => t.TrackName == request.Track.TrackName && t.Duration == request.Track.Duration))
            {
                track = new Track
                {
                    TrackName = request.Track.TrackName,
                    Duration = request.Track.Duration,
                };
            }
            else
            {
                track = _context.Tracks.Where(t => t.TrackName == request.Track.TrackName && t.Duration == request.Track.Duration).Single();
            }

            var newMusician = new Musician
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Nickname = request.Nickname,
            };

            var musician_track = new Musician_Track
            {
                Musician = newMusician,
                Track = track,
            };

            _context.SaveChanges();

            var response = new CreateMusicianResponseData
            {
                FirstName = newMusician.FirstName,
                LastName = newMusician.LastName,
                Nickname = newMusician.Nickname,
            };

            return Created("/" + newMusician.IdMusician.ToString(), response);
        }
    }
}