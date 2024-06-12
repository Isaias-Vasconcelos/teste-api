using Microsoft.AspNetCore.Mvc;
using TesteAPI.Models;
using TesteAPI.Services;

namespace TesteAPI.Controllers
{
    public class HomeController(IHttpService httpService) : Controller
    {
        private readonly IHttpService _httpService = httpService;
        public IActionResult Index()
        {
            return View(new Credentials());
        }
        public IActionResult Error()
        {
            return View();
        }
        public async Task<IActionResult> Autenticado()
        {
            var usuarioAutenticado = await _httpService.Info();

            return View(usuarioAutenticado);
        }

        public async Task<IActionResult> Login(Credentials credentials)
        {
            if (!ModelState.IsValid) throw new Exception("");

            var autenticacao = await _httpService.Post(credentials);

            if (!autenticacao.IsSuccess) return RedirectToAction("Error");

            return RedirectToAction("Autenticado");

        }
    }
}
