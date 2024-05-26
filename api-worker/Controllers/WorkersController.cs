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
    public class WorkersController : ControllerBase
    {
        private static List<Worker> Workers = new List<Worker>
        {
            new Worker { Id = 1, FirstName = "John", LastName = "Doe", Position = "Developer", Salary = 60000, DepartementId = 1 },
            new Worker { Id = 2, FirstName = "Jane", LastName = "Smith", Position = "Manager", Salary = 80000, DepartementId = 2 }
        };

        // GET: api/Workers
        [HttpGet]
        public ActionResult<IEnumerable<Worker>> Get()
        {
            return Workers;
        }

        // GET: api/Workers/{id}
        [HttpGet("{id}")]
        public ActionResult<Worker> Get(int id)
        {
            var worker = Workers.Find(e => e.Id == id);
            if (worker == null)
            {
                return NotFound();
            }
            return worker;
        }

        // POST: api/Workers
        [HttpPost]
        public ActionResult<Worker> Post([FromBody] Worker worker)
        {
            Workers.Add(worker);
            return CreatedAtAction(nameof(Get), new { id = worker.Id }, worker);
        }

        // PUT: api/Workers/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Worker updatedWorker)
        {
            var worker = Workers.Find(e => e.Id == id);
            if (worker == null)
            {
                return NotFound();
            }
            worker.FirstName = updatedWorker.FirstName;
            worker.LastName = updatedWorker.LastName;
            worker.Position = updatedWorker.Position;
            worker.Salary = updatedWorker.Salary;
            worker.DepartementId = updatedWorker.DepartementId;
            return NoContent();
        }

        // DELETE: api/Workers/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var worker = Workers.Find(e => e.Id == id);
            if (worker == null)
            {
                return NotFound();
            }
            Workers.Remove(worker);
            return NoContent();
        }
    }
}
