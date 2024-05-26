using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using api_worker.Modeles;

namespace api_worker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private static List<Worker> workers = new List<Worker>
        {
            new Worker { Id = 1, Name = "John Doe", Position = "Developer", Salary = 60000 },
            new Worker { Id = 2, Name = "Jane Smith", Position = "Manager", Salary = 80000 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Worker>> Get()
        {
            return workers;
        }

        [HttpGet("{id}")]
        public ActionResult<Worker> Get(int id)
        {
            var worker = workers.Find(w => w.Id == id);
            if (worker == null)
            {
                return NotFound();
            }
            return worker;
        }

        [HttpPost]
        public ActionResult<Worker> Post([FromBody] Worker worker)
        {
            workers.Add(worker);
            return CreatedAtAction(nameof(Get), new { id = worker.Id }, worker);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Worker updatedWorker)
        {
            var worker = workers.Find(w => w.Id == id);
            if (worker == null)
            {
                return NotFound();
            }
            worker.Name = updatedWorker.Name;
            worker.Position = updatedWorker.Position;
            worker.Salary = updatedWorker.Salary;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var worker = workers.Find(w => w.Id == id);
            if (worker == null)
            {
                return NotFound();
            }
            workers.Remove(worker);
            return NoContent();
        }
    }
}
