using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        public IActionResult UsuarioHome()
        {
            return View();
        }

    }
}
