using GamingIndustrios.DataContextClass;
using GamingIndustrios.Models;
using GamingIndustrios.Service.Interfaces;

namespace GamingIndustrios.Service
{
    public class GameServices : IGamesService
    {
        private readonly DataClass _dbContext;

        public GameServices(DataClass dbContext)
        {
            _dbContext = dbContext;
        }

        public Games AddGames(Games games)
        {
            var result = _dbContext.Games.Add(games);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public Result DeleteGames(int? id)
        {
            try
            {
                if (id==null)
                {
                    return new Result
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        ErrorMessage = "Id not provided"
                    };
                }
                var filteredData = _dbContext.Games.Where(x => x.Id ==id).FirstOrDefault();
                if (filteredData == null)
                {
                    return new Result
                    {
                        Id = (int)id,
                        StatusCode = System.Net.HttpStatusCode.NotFound,
                        ErrorMessage = "Games id not found"
                    };
                }
                var result = _dbContext.Remove(filteredData);
                _dbContext.SaveChanges();

                return new Result
                {
                    Id = result.Entity.Id,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    CustomObject = result.Entity
                };
           
            }
            catch (Exception ex)
            {
                return new Result
                {
                    Id = (int)id,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                };
            }
            
        }
    }
}
