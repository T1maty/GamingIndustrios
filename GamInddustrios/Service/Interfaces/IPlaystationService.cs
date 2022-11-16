using GamingIndustrios.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace GamingIndustrios.Service.Interfaces
{
    public interface IPlaystationService
    {
        public  Playstation AddPlaystation(Playstation playstation);

        public Playstation UpdatePlaystation(Playstation playstation);

        public Task UpdateProductPatchAsync(int id, JsonPatchDocument abonement);
    }
}
