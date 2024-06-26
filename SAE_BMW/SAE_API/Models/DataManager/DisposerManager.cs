﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_API.Models.EntityFramework;
using SAE_API.Repository;

namespace SAE_API.Models.DataManager
{
    public class DisposerManager : IDataRepository<Disposer>
    {
        readonly BMWDBContext? bmwDBContext;

        //création des controlleur
        public DisposerManager() { }

        public DisposerManager(BMWDBContext context)
        {
            bmwDBContext = context;
        }

        // recherche toute les moto 
        public async Task<ActionResult<IEnumerable<Disposer>>> GetAllAsync()
        {
            return await bmwDBContext.Disposers.ToListAsync();
        }
        //recherche par ID moto
        public async Task<ActionResult<Disposer>> GetByIdAsync(int id)
        {
            return await bmwDBContext.Disposers.FirstOrDefaultAsync(u => u.IdStock == id);
        }
        //recherche par nom de moto
        public async Task<ActionResult<Disposer>> GetByStringAsync(string nom)
        {
            throw new NotImplementedException();
        }
        //ajoute une moto 
        public async Task AddAsync(Disposer entity)
        {
            await bmwDBContext.Disposers.AddAsync(entity);
            await bmwDBContext.SaveChangesAsync();
        }
        //Mise à jour de la moto 
        public async Task UpdateAsync(Disposer Disposer, Disposer entity)
        {
            bmwDBContext.Entry(Disposer).State = EntityState.Modified;

            Disposer.IdStock = entity.IdStock;
            Disposer.IdEquipement = entity.IdEquipement;


            await bmwDBContext.SaveChangesAsync();
        }

        //supprimer la moto
        public async Task DeleteAsync(Disposer Disposer)
        {
            bmwDBContext.Disposers.Remove(Disposer);
            await bmwDBContext.SaveChangesAsync();
        }

    }
}
