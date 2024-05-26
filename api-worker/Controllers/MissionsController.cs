using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using api_worker.Modeles;
using System.Linq;

namespace api_worker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MissionsController : ControllerBase
    {
        private static List<Mission> missions = new List<Mission>
        {
            new Mission { Id = 1, Name = "Mission A", Description = "Description of Mission A", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(6) },
            new Mission { Id = 2, Name = "Mission B", Description = "Description of Mission B", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(12) }
        };

        // GET: api/missions
        [HttpGet]
        public ActionResult<IEnumerable<Mission>> Get()
        {
            return missions;
        }

        // GET: api/missions/{id}
        [HttpGet("{id}")]
        public ActionResult<Mission> Get(int id)
        {
            var mission = missions.Find(m => m.Id == id);
            if (mission == null)
            {
                return NotFound();
            }
            return mission;
        }

        // POST: api/missions
        [HttpPost]
        public ActionResult<Mission> Post([FromBody] Mission mission)
        {
            missions.Add(mission);
            return CreatedAtAction(nameof(Get), new { id = mission.Id }, mission);
        }

        // PUT: api/missions/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Mission updatedMission)
        {
            var mission = missions.Find(m => m.Id == id);
            if (mission == null)
            {
                return NotFound();
            }
            mission.Name = updatedMission.Name;
            mission.Description = updatedMission.Description;
            mission.StartDate = updatedMission.StartDate;
            mission.EndDate = updatedMission.EndDate;
            return NoContent();
        }

        // DELETE: api/missions/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var mission = missions.Find(m => m.Id == id);
            if (mission == null)
            {
                return NotFound();
            }
            missions.Remove(mission);
            return NoContent();
        }
    }
}
