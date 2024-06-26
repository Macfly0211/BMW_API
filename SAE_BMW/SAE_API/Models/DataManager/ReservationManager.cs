﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_API.Models.EntityFramework;
using SAE_API.Repository;

namespace SAE_API.Models.DataManager
{
    public class ReservationManager : IDataRepository<Reservation>
    {
        readonly BMWDBContext? bmwDBContext;

        //création des controlleur
        public ReservationManager() { }

        public ReservationManager(BMWDBContext context)
        {
            bmwDBContext = context;
        }

        // recherche toute les moto 
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllAsync()
        {
            return await bmwDBContext.Reservations.ToListAsync();
        }
        //recherche par ID moto
        public async Task<ActionResult<Reservation>> GetByIdAsync(int id)
        {
            return await bmwDBContext.Reservations.FirstOrDefaultAsync(u => u.IdReservationOffre == id);
        }
        //recherche par nom de moto
        public async Task<ActionResult<Reservation>> GetByStringAsync(string nom)
        {
            return await bmwDBContext.Reservations.FirstOrDefaultAsync(u => u.FinancementReservationOffre.ToUpper() == nom.ToUpper());
        }
        //ajoute une moto 
        public async Task AddAsync(Reservation entity)
        {
            await bmwDBContext.Reservations.AddAsync(entity);
            await bmwDBContext.SaveChangesAsync();
        }
        //Mise à jour de la moto 
        public async Task UpdateAsync(Reservation reservation, Reservation entity)
        {
            bmwDBContext.Entry(reservation).State = EntityState.Modified;

            reservation.IdReservationOffre = entity.IdReservationOffre;
            reservation.IdConcessionnaire = entity.IdConcessionnaire;
            reservation.FinancementReservationOffre = entity.FinancementReservationOffre;
            reservation.AssuranceReservation = entity.AssuranceReservation;
            

            await bmwDBContext.SaveChangesAsync();
        }

        //supprimer la moto
        public async Task DeleteAsync(Reservation reservation)
        {
            bmwDBContext.Reservations.Remove(reservation);
            await bmwDBContext.SaveChangesAsync();
        }


    }
}
