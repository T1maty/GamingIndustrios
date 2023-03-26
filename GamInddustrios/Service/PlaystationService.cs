using GamingIndustrios.DataContextClass;
using GamingIndustrios.Models;
using GamingIndustrios.Service.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace GamingIndustrios.Service
{
    public class PlaystationService : IPlaystationService
    {
        private readonly DataClass _dbContext;

        public PlaystationService(DataClass dbContext)
        {
            _dbContext = dbContext;
        }

        public Playstation AddPlaystation(Playstation playstation)
        {
            var result = _dbContext.Playstations.Add(playstation);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public async  Task UpdatePlaystationPatchAsync(int id, JsonPatchDocument abonement)
        {
            var playstation = await _dbContext.Playstations.FindAsync(id);
            if (playstation != null)
            {
                playstation.ApplyTo(playstation);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
