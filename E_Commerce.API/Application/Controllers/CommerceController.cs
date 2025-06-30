using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommerceController : ControllerBase
    {
       

        private readonly ILogger<CommerceController> _logger;

        public CommerceController(ILogger<CommerceController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Get")]
        public void Deletar()
        {
            Console.WriteLine("Testou");
        }

        [HttpGet(Name = "Get")]
        public void Deletar()
        {
            Console.WriteLine("Testou");
        }

        [HttpPost(Name = "Get")]
        public void Deletar()
        {
            Console.WriteLine("Testou");
        }

        [HttpDelete(Name = "Get")]
        public void Deletar()
        {
            Console.WriteLine("Testou");
        }

        [HttpPost(Name = "Get")]
        public void Deletar()
        {
            Console.WriteLine("Testou");
        }
    }
}
