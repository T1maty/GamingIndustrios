using Microsoft.AspNetCore.Routing.Constraints;
using Org.BouncyCastle.Crypto;
using System.ComponentModel.DataAnnotations;

namespace GamingIndustrios.Models
{
    public class TransferCrypto : BaseObject
    {
    
        public string WalletNumber { get; set; }
        
        public string TransferAmount { get; set; }

    }
}
