using GamingIndustrios.Models;

namespace GamingIndustrios.Service.Interfaces
{
    public interface IGamesService
    {
        public Games AddGames(Games games);

        public Result DeleteGames(int? id);
    }
}
