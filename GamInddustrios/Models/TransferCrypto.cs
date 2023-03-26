using Microsoft.AspNetCore.Routing.Constraints;
using Org.BouncyCastle.Crypto;
using System.ComponentModel.DataAnnotations;

namespace GamingIndustrios.Models
{
    public class TransferCrypto : BaseObject
    {
        [MaxLength(300)]
        public string WalletNumber { get; set; }
        public int TransferAmount { get; set; }

    }
}
