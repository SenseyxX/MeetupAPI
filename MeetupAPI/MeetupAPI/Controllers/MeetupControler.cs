using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using MeetupAPI.Entities;
using System.Threading.Tasks;

namespace MeetupAPI.Controllers
{

    [Route("api/meerup")]
    public class MeetupControler : ControllerBase
    {
        private readonly MeetupContext _meetupContext;

        public MeetupControler(MeetupContext meetupContext)
        {

        }

        [HttpGet]
        public ActionResult<List<Meetup>> Get()
        {
            var meetups = _meetupContext.Meetups.ToList();

            return meetups;
        }
    }
}
