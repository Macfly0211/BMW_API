﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_API.Models.EntityFramework;
using SAE_API.Repository;

namespace SAE_API.Models.DataManager
{
    public class AcquerirManager : IDataRepository<Acquerir>
    {
        readonly BMWDBContext? bmwDBContext;

        //création des controlleur
        public AcquerirManager() { }

        public AcquerirManager(BMWDBContext context)
        {
            bmwDBContext = context;
        }

        // recherche toute les moto 
        public async Task<ActionResult<IEnumerable<Acquerir>>> GetAllAsync()
        {
            return await bmwDBContext.Acquerirs.ToListAsync();
        }
        //recherche par ID moto
        public async Task<ActionResult<Acquerir>> GetByIdAsync(int id)
        {
            return await bmwDBContext.Acquerirs.FirstOrDefaultAsync(u => u.IdCb == id);
        }
        //recherche par nom de moto
        public async Task<ActionResult<Acquerir>> GetByStringAsync(string nom)
        {
            throw new NotImplementedException();
        }
        //ajoute une moto 
        public async Task AddAsync(Acquerir entity)
        {
            await bmwDBContext.Acquerirs.AddAsync(entity);
            await bmwDBContext.SaveChangesAsync();
        }
        //Mise à jour de la moto 
        public async Task UpdateAsync(Acquerir acquerir, Acquerir entity)
        {
            bmwDBContext.Entry(acquerir).State = EntityState.Modified;

            acquerir.IdCb = entity.IdCb;
            acquerir.IdCompteClient = entity.IdCompteClient;
           

            await bmwDBContext.SaveChangesAsync();
        }

        //supprimer la moto
        public async Task DeleteAsync(Acquerir acquerir)
        {
            bmwDBContext.Acquerirs.Remove(acquerir);
            await bmwDBContext.SaveChangesAsync();
        }

    }
}
