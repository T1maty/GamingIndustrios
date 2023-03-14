using GamingIndustrios.Models;
using GamingIndustrios.Service;
using GamingIndustrios.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamingIndustrios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoService _cryptoService;
        public CryptoController(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }
        [HttpPost("transfer")]
        public TransferCrypto AddTransferCrypto(TransferCrypto transferCrypto)
        {
            return _cryptoService.AddTransferCrypto(transferCrypto);
        }
    }
}
