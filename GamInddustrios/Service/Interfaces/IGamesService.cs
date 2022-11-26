using GamingIndustrios.Models;

namespace GamingIndustrios.Service.Interfaces
{
    public interface IGamesService
    {
        public Game AddGames(Game games);

        public Result DeleteGames(int? id);
    }
}
