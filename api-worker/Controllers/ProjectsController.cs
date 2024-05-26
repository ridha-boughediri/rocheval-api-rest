using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using api_worker.Modeles;

namespace api_worker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private static List<Project> projects = new List<Project>
        {
            new Project { Id = 1, Name = "Project A", Description = "Description of Project A", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(6) },
            new Project { Id = 2, Name = "Project B", Description = "Description of Project B", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(12) }
        };

        // GET: api/projects
        [HttpGet]
        public ActionResult<IEnumerable<Project>> Get()
        {
            return projects;
        }

        // GET: api/projects/1
        [HttpGet("{id}")]
        public ActionResult<Project> Get(int id)
        {
            var project = projects.Find(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            return project;
        }

        // POST: api/projects
        [HttpPost]
        public ActionResult<Project> Post([FromBody] Project project)
        {
            projects.Add(project);
            return CreatedAtAction(nameof(Get), new { id = project.Id }, project);
        }

        // PUT: api/projects/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Project updatedProject)
        {
            var project = projects.Find(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            project.Name = updatedProject.Name;
            project.Description = updatedProject.Description;
            project.StartDate = updatedProject.StartDate;
            project.EndDate = updatedProject.EndDate;
            return NoContent();
        }

        // DELETE: api/projects/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = projects.Find(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            projects.Remove(project);
            return NoContent();
        }
    }
}
