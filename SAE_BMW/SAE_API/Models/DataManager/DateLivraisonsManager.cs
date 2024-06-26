﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_API.Models.EntityFramework;
using SAE_API.Repository;

namespace SAE_API.Models.DataManager
{
    public class DateLivraisonManager : IDataRepository<DateLivraison>
    {
        readonly BMWDBContext? bmwDBContext;

        //création des controlleur
        public DateLivraisonManager() { }

        public DateLivraisonManager(BMWDBContext context)
        {
            bmwDBContext = context;
        }

        // recherche toute les moto 
        public async Task<ActionResult<IEnumerable<DateLivraison>>> GetAllAsync()
        {
            return await bmwDBContext.DateLivraisons.ToListAsync();
        }
        //recherche par ID moto
        public async Task<ActionResult<DateLivraison>> GetByIdAsync(int id)
        {
            return await bmwDBContext.DateLivraisons.FirstOrDefaultAsync(u => u.IdDateLivraison == id);
        }
        //recherche par nom de moto
        public async Task<ActionResult<DateLivraison>> GetByStringAsync(string nom)
        {
            throw new NotImplementedException();
        }
        //ajoute une moto 
        public async Task AddAsync(DateLivraison entity)
        {
            await bmwDBContext.DateLivraisons.AddAsync(entity);
            await bmwDBContext.SaveChangesAsync();
        }
        //Mise à jour de la moto 
        public async Task UpdateAsync(DateLivraison DateLivraison, DateLivraison entity)
        {
            bmwDBContext.Entry(DateLivraison).State = EntityState.Modified;

            DateLivraison.IdDateLivraison = entity.IdDateLivraison;
            DateLivraison.Date = entity.Date;


            await bmwDBContext.SaveChangesAsync();
        }

        //supprimer la moto
        public async Task DeleteAsync(DateLivraison DateLivraison)
        {
            bmwDBContext.DateLivraisons.Remove(DateLivraison);
            await bmwDBContext.SaveChangesAsync();
        }

    }
}
