﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_API.Models.EntityFramework;
using SAE_API.Repository;

namespace SAE_API.Models.DataManager
{
    public class APourTailleManager : IDataRepository<APourTaille>
    {
        readonly BMWDBContext? bmwDBContext;

        //création des controlleur
        public APourTailleManager() { }

        public APourTailleManager(BMWDBContext context)
        {
            bmwDBContext = context;
        }

        // recherche toute les moto 
        public async Task<ActionResult<IEnumerable<APourTaille>>> GetAllAsync()
        {
            return await bmwDBContext.APourTailles.ToListAsync();
        }
        //recherche par ID moto
        public async Task<ActionResult<APourTaille>> GetByIdAsync(int id)
        {
            return await bmwDBContext.APourTailles.FirstOrDefaultAsync(u => u.IdTailleEquipement == id);
        }
        //recherche par nom de moto
        public async Task<ActionResult<APourTaille>> GetByStringAsync(string nom)
        {
            throw new NotImplementedException();
        }
        //ajoute une moto 
        public async Task AddAsync(APourTaille entity)
        {
            await bmwDBContext.APourTailles.AddAsync(entity);
            await bmwDBContext.SaveChangesAsync();
        }
        //Mise à jour de la moto 
        public async Task UpdateAsync(APourTaille aPourTailles, APourTaille entity)
        {
            bmwDBContext.Entry(aPourTailles).State = EntityState.Modified;

            aPourTailles.IdTailleEquipement = entity.IdTailleEquipement;
            aPourTailles.IdEquipement = entity.IdEquipement;
           
            await bmwDBContext.SaveChangesAsync();
        }

        //supprimer la moto
        public async Task DeleteAsync(APourTaille aPourTailles)
        {
            bmwDBContext.APourTailles.Remove(aPourTailles);
            await bmwDBContext.SaveChangesAsync();
        }


    }
}
