﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_API.Models.EntityFramework;
using SAE_API.Repository;

namespace SAE_API.Models.DataManager
{
    public class CommanderManager : IDataRepository<Commander>
    {
        readonly BMWDBContext? bmwDBContext;

        //création des controlleur
        public CommanderManager() { }

        public CommanderManager(BMWDBContext context)
        {
            bmwDBContext = context;
        }

        // recherche toute les moto 
        public async Task<ActionResult<IEnumerable<Commander>>> GetAllAsync()
        {
            return await bmwDBContext.Commanders.ToListAsync();
        }
        //recherche par ID moto
        public async Task<ActionResult<Commander>> GetByIdAsync(int id)
        {
            return await bmwDBContext.Commanders.FirstOrDefaultAsync(u => u.IdConfigurationMoto == id);
        }
        //recherche par nom de moto
        public async Task<ActionResult<Commander>> GetByStringAsync(string nom)
        {
            throw new NotImplementedException();
        }
        //ajoute une moto 
        public async Task AddAsync(Commander entity)
        {
            await bmwDBContext.Commanders.AddAsync(entity);
            await bmwDBContext.SaveChangesAsync();
        }
        //Mise à jour de la moto 
        public async Task UpdateAsync(Commander Commander, Commander entity)
        {
            bmwDBContext.Entry(Commander).State = EntityState.Modified;

            Commander.IdConfigurationMoto = entity.IdConfigurationMoto;
            Commander.IdCommande = entity.IdCommande;
            Commander.IdConfigurationMoto = entity.IdConfigurationMoto;
            Commander.QteCommande = entity.QteCommande;


            await bmwDBContext.SaveChangesAsync();
        }

        //supprimer la moto
        public async Task DeleteAsync(Commander Commander)
        {
            bmwDBContext.Commanders.Remove(Commander);
            await bmwDBContext.SaveChangesAsync();
        }

    }
}
