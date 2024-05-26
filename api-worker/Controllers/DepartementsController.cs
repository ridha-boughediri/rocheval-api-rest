using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using api_worker.Modeles;

namespace api_worker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementsController : ControllerBase
    {
        private static List<Departement> Departements = new List<Departement>
        {
            new Departement { Id = 1, Name = "Engineering", Location = "Building A" },
            new Departement { Id = 2, Name = "Marketing", Location = "Building B" }
        };

        // GET: api/Departements
        [HttpGet]
        public ActionResult<IEnumerable<Departement>> Get()
        {
            return Departements;
        }

        // GET: api/Departements/1
        [HttpGet("{id}")]
        public ActionResult<Departement> Get(int id)
        {
            var Departement = Departements.Find(d => d.Id == id);
            if (Departement == null)
            {
                return NotFound();
            }
            return Departement;
        }

        // POST: api/Departements
        [HttpPost]
        public ActionResult<Departement> Post([FromBody] Departement Departement)
        {
            Departements.Add(Departement);
            return CreatedAtAction(nameof(Get), new { id = Departement.Id }, Departement);
        }

        // PUT: api/Departements/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Departement updatedDepartement)
        {
            var Departement = Departements.Find(d => d.Id == id);
            if (Departement == null)
            {
                return NotFound();
            }
            Departement.Name = updatedDepartement.Name;
            Departement.Location = updatedDepartement.Location;
            return NoContent();
        }

        // DELETE: api/Departements/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Departement = Departements.Find(d => d.Id == id);
            if (Departement == null)
            {
                return NotFound();
            }
            Departements.Remove(Departement);
            return NoContent();
        }
    }
}
