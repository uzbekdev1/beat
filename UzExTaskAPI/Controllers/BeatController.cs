using System;
using UzExTaskAPI.Models;
using UzExTaskAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BeatsApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BeatsController : ControllerBase
    {
        private readonly BeatService _beatService;

        public BeatsController(BeatService beatService)
        {
            _beatService = beatService;
        }

        [HttpGet]
        public ActionResult<List<Beat>> Get() =>
            _beatService.Get();

        [HttpPost]
        public ActionResult<Beat> Create(BeatVM beatvm)
        {
            var beat = new Beat();

            beat.BeaterId = beatvm.BeaterId;
            beat.Price = beatvm.Price;
            beat.BeatTime = DateTime.Now;

            var reult = _beatService.Create(beat);

            return Ok(reult);
        }

        [HttpGet("lastbeat")]
        public ActionResult<Beat> LastBeat(){
            var lastBeat = _beatService.LastBeat();
            return Ok(lastBeat);
        }
    }
}