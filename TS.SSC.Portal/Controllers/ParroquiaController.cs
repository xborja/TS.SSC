using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TS.SSC.BL;
using TS.SSC.Entity;
using TS.SSC.Portal.Services;
using TS.SSC.Portal.ViewModels;

namespace TS.SSC.Portal.Controllers
{
    [Authorize]
    public class ParroquiaController : Controller
    {
        Usuario usuario = new Usuario();
        Parroquia parroquia = new ParroquiaVM();

        // GET: Parroquia
        public ActionResult DatosParroquia()
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);

            ParroquiaVM item = ModelService.ToView(ParroquiaBL.GetByID(parroquia.id));
            return View(item);
        }

        [HttpPost]
        public ActionResult DatosParroquia(ParroquiaVM item)
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);
            int resultado;
            try
            {
                Parroquia itemM = ModelService.ToModel(item);
                itemM.id = parroquia.id;
                itemM.UsuarioModif = usuario.userName;
                //itemM.Estado = 1;
                resultado = ParroquiaBL.Update(itemM);
                if (resultado == 0)
                {
                    item.MensajeProceso = "Proceso realizado Fallido";
                    //return new HttpNotFoundResult(itemM.MensajeProceso);
                    return View(item);
                }
                else
                {
                    item.MensajeProceso = "Proceso realizado exitoso";
                    TempData["Parroquia.Mensaje"] = item.MensajeProceso;
                    return RedirectToAction("DatosParroquia");
                }
            }
            catch (Exception ex)
            {
                item.MensajeProceso = "Proceso no realizado, el mensaje es: " + ex.Message;
                TempData["Parroquia.Mensaje"] = item.MensajeProceso;
                return RedirectToAction("DatosParroquia");
            }

        }
    
    }
}