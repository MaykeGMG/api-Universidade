using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace apiUniversidade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorizaController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AutorizaController(UserManager<IdentityUser> userManeger, SignInManager<IdentityUser> signInManager){
            _userManager = userManeger;
            _signInManager = signInManager;
        }

        [HttpGet]
            public ActionResult<string> Get(){
                return "AutorizaController :: Acessado em : "
                    + DateTime.Now.ToLongTimeString();
            }
    }
}