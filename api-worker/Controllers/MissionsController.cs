using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using api_worker.Modeles;

namespace api_worker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionsController : ControllerBase
    {
        private static List<Mission> Missions = new List<Mission>
        {
            new Mission { Id = 1, Title = "Mission 1", Description = "Description 1", DueDate = DateTime.Now.AddDays(1), IsCompleted = false },
            new Mission { Id = 2, Title = "Mission 2", Description = "Description 2", DueDate = DateTime.Now.AddDays(2), IsCompleted = false }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Mission>> Get()
        {
            return Missions;
        }

        [HttpGet("{id}")]
        public ActionResult<Mission> Get(int id)
        {
            var Mission = Missions.Find(t => t.Id == id);
            if (Mission == null)
            {
                return NotFound();
            }
            return Mission;
        }

        [HttpPost]
        public ActionResult<Mission> Post([FromBody] Mission Mission)
        {
            Mission.Id = Missions.Count > 0 ? Missions[^1].Id + 1 : 1;
            Missions.Add(Mission);
            return CreatedAtAction(nameof(Get), new { id = Mission.Id }, Mission);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Mission updatedMission)
        {
            var Mission = Missions.Find(t => t.Id == id);
            if (Mission == null)
            {
                return NotFound();
            }
            Mission.Title = updatedMission.Title;
            Mission.Description = updatedMission.Description;
            Mission.DueDate = updatedMission.DueDate;
            Mission.IsCompleted = updatedMission.IsCompleted;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Mission = Missions.Find(t => t.Id == id);
            if (Mission == null)
            {
                return NotFound();
            }
            Missions.Remove(Mission);
            return NoContent();
        }
    }
}
