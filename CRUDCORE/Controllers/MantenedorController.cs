using CRUDCORE.Datos;
using CRUDCORE.Models;
using Microsoft.AspNetCore.Mvc;


namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            //La vista mostrara una lista de contactos
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Metodo solo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //Metodo recibe el objeto para guardarlo en BD
            if (!ModelState.IsValid) {
                return View();
            }

            var respuesta = _ContactoDatos.Guardar(oContacto);

            if (respuesta) {
                return RedirectToAction("Listar");
            } else {
                return View();
            }
        }
    }
}
