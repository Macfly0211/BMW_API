﻿using Microsoft.AspNetCore.Mvc;
using SAE_API.Models.EntityFramework;
using SAE_API.Repository;

namespace SAE_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompteClientController : ControllerBase
    {
        private readonly IDataRepository<CompteClient> dataRepository;

        public CompteClientController(IDataRepository<CompteClient> dataRepo)
        {
            //_context = context;
            dataRepository = dataRepo;
        }

        [HttpGet]
        [ActionName("GetUtilisateurs")]
        public async Task<ActionResult<IEnumerable<CompteClient>>> GetUtilisateurs()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        [ActionName("GetUtilisateurById")]
        public async Task<ActionResult<CompteClient>> GetUtilisateurById(int id)
        {

            var compteClient = await dataRepository.GetByIdAsync(id);
            //var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (compteClient == null)
            {
                return NotFound();
            }
            return compteClient;
        }

        // GET : api/Utilisateurs/nom
        [HttpGet("{nom}")]
        [ActionName("GetUtilisateurByName")]
        public async Task<ActionResult<CompteClient>> GetUtilisateurByName(string email)
        {
            var compteClient = await dataRepository.GetByStringAsync(email);
            //var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (compteClient == null)
            {
                return NotFound();
            }
            return compteClient;
        }

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ActionName("PutUtilisateur")]
        public async Task<IActionResult> PutUtilisateur(int id, CompteClient compteClient)
        {
            if (id != compteClient.IdCompteClient)
            {
                return BadRequest();
            }
            var userToUpdate = await dataRepository.GetByIdAsync(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(userToUpdate.Value, compteClient);
                return NoContent();
            }
        }

        // POST: api/Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ActionName("PostUtilisateur")]
        public async Task<ActionResult<CompteClient>> PostUtilisateur(CompteClient compteClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(compteClient);
            return CreatedAtAction("GetUtilisateurById", new { id = compteClient.IdCompteClient }, compteClient); // GetById : nom de l’action
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        [ActionName("DeleteUtilisateur")]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            var compteClient = await dataRepository.GetByIdAsync(id);
            if (compteClient == null)
            {
                return NotFound();
            }
            await dataRepository.DeleteAsync(compteClient.Value);
            return NoContent();
        }

    }
}
