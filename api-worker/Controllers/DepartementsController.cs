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
    public class DepartementsController : ControllerBase
    {
        private static List<Departement> departements = new List<Departement>
        {
            new Departement { Id = 1, Nom = "Ingénierie", Emplacement = "Bâtiment A" },
            new Departement { Id = 2, Nom = "Marketing", Emplacement = "Bâtiment B" }
        };

        // GET: api/departements
        [HttpGet]
        public ActionResult<IEnumerable<Departement>> Get()
        {
            return departements;
        }

        // GET: api/departements/{id}
        [HttpGet("{id}")]
        public ActionResult<Departement> Get(int id)
        {
            var departement = departements.Find(d => d.Id == id);
            if (departement == null)
            {
                return NotFound();
            }
            return departement;
        }

        // POST: api/departements
        [HttpPost]
        public ActionResult<Departement> Post([FromBody] Departement departement)
        {
            departements.Add(departement);
            return CreatedAtAction(nameof(Get), new { id = departement.Id }, departement);
        }

        // PUT: api/departements/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Departement updatedDepartement)
        {
            var departement = departements.Find(d => d.Id == id);
            if (departement == null)
            {
                return NotFound();
            }
            departement.Nom = updatedDepartement.Nom;
            departement.Emplacement = updatedDepartement.Emplacement;
            return NoContent();
        }

        // DELETE: api/departements/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var departement = departements.Find(d => d.Id == id);
            if (departement == null)
            {
                return NotFound();
            }
            departements.Remove(departement);
            return NoContent();
        }
    }
}
