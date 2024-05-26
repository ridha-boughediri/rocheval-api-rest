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
    public class AssignmentsController : ControllerBase
    {
        private static List<Assignment> assignments = new List<Assignment>
        {
            new Assignment { WorkerId = 1, ProjectId = 1, AssignedDate = DateTime.Now },
            new Assignment { WorkerId = 2, ProjectId = 2, AssignedDate = DateTime.Now }
        };

        // GET: api/assignments
        [HttpGet]
        public ActionResult<IEnumerable<Assignment>> Get()
        {
            return assignments;
        }

        // GET: api/assignments/{workerId}/{projectId}
        [HttpGet("{workerId}/{projectId}")]
        public ActionResult<Assignment> Get(int workerId, int projectId)
        {
            var assignment = assignments.Find(a => a.WorkerId == workerId && a.ProjectId == projectId);
            if (assignment == null)
            {
                return NotFound();
            }
            return assignment;
        }

        // POST: api/assignments
        [HttpPost]
        public ActionResult<Assignment> Post([FromBody] Assignment assignment)
        {
            assignments.Add(assignment);
            return CreatedAtAction(nameof(Get), new { workerId = assignment.WorkerId, projectId = assignment.ProjectId }, assignment);
        }

        // DELETE: api/assignments/{workerId}/{projectId}
        [HttpDelete("{workerId}/{projectId}")]
        public IActionResult Delete(int workerId, int projectId)
        {
            var assignment = assignments.Find(a => a.WorkerId == workerId && a.ProjectId == projectId);
            if (assignment == null)
            {
                return NotFound();
            }
            assignments.Remove(assignment);
            return NoContent();
        }
    }
}
