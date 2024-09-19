using GorevYoneticisi.Interfaces;
using GorevYoneticisi.Model;
using GorevYoneticisi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GorevYoneticisi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;

        readonly IRaporService _raporService;

        private static int id;

        public UserController(IUserService userService, IRaporService raporService)
        {
            _userService = userService;
            _raporService = raporService;
        }

        [HttpPost("Create User")]
        [AllowAnonymous]

        public async Task<ActionResult<string>> createUser([FromQuery] string username, [FromQuery] string password, [FromQuery] string passwordagain)
        {
            var result = await _userService.createUser(username, password, passwordagain);
            return result;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<TokenInfo>> Login([FromQuery] string username, [FromQuery] string password)
        {
            var result = await _userService.login(username, password);
            id = result.Id;
            return result;
        }

        [HttpPost("CreateReport")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> CreateReport([FromQuery] string raporTipi, [FromQuery] string raporIcerigi)
        {        
            var result = await _raporService.raporEkle(id, raporTipi, raporIcerigi); 
            return result;
        }

        [HttpPost("ShowReport")]
        [AllowAnonymous]
        public async Task<ActionResult<List<RaporKayit>>> ShowReport()
        {
            var result = await _raporService.raporlar(id);
            return result;
        }

        [HttpPost("ShowReportByType")]
        [AllowAnonymous]
        public async Task<ActionResult<List<RaporKayit>>> ShowReportByType([FromQuery] string raporTipi)
        {
            var result = await _raporService.raporByTip(id, raporTipi);
            return result;
        }
    }
}
