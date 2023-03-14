using GamingIndustrios.DataContextClass;
using GamingIndustrios.Models;
using GamingIndustrios.Service.Interfaces;

namespace GamingIndustrios.Service
{
    public class CryptoService : ICryptoService
    {
        private readonly DataClass _dbContext;
        public CryptoService(DataClass dbContext)
        {
            _dbContext = dbContext;
        }

        public TransferCrypto AddTransferCrypto(TransferCrypto transferCrypto)
        {
           var result = _dbContext.transferCryptos.Add(transferCrypto);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
