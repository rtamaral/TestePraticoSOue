using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAutenticacao _autentica;

        public LoginController(IAutenticacao autentica)
        {
            _autentica = autentica;
        }

        [HttpGet]
        public IActionResult RegistrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarUsuario([Bind] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                string RegistroStatus = _autentica.RegistrarUsuario(usuario);
                if (RegistroStatus == "Sucesso")
                {
                    ModelState.Clear();
                    TempData["Sucesso"] = "Cadastro realizado com sucesso!";
                    return View();
                }
                else
                {
                    TempData["Falhou"] = "Cadastro já existe.";
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult LoginUsuario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUsuario([Bind] Usuario usuario)
        {
            if (usuario != null)
            {
                string LoginStatus = _autentica.ValidarLogin(usuario);

                if (LoginStatus == "Sucesso")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.Cpf)
                    };

                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "cpf");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("UsuarioHome", "Usuario");
                }
                else
                {
                    TempData["LoginUsuarioFalhou"] = "Você esqueceu a senha ou não possui permissão para acessar está página.";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
       
    }
}
