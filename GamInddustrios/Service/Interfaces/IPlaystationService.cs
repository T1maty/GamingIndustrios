using GamingIndustrios.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace GamingIndustrios.Service.Interfaces

{
    public interface IPlaystationService
    {
        public  Playstation AddPlaystation(Playstation playstation);
        public Task UpdatePlaystationPatchAsync(int id, JsonPatchDocument abonement);
    }
}
