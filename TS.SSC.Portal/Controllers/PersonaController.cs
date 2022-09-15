using System;
using System.Collections.Generic;
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
    public class PersonaController : Controller
    {
        Usuario usuario = new Usuario();
        Parroquia parroquia = new ParroquiaVM();
        // GET: Persona
        public ActionResult Index()
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);

            PersonaLVM items = new PersonaLVM();
            items.LetraDesde = "A";
            items.LetraHasta = "A";
            //ModelService.ToView(PersonaBL.ToList(parroquia.id));
            return View(items);
        }

        [HttpPost]
        public ActionResult Index(PersonaLVM item)
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);
            PersonaLVM items = ModelService.ToView(PersonaBL.ToList(parroquia.id, item.LetraDesde, item.LetraHasta, item.FNombre));
            return View(items);

        }

        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: Persona/Create
        public ActionResult Create()
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);

            PersonaVM item = new PersonaVM();
            item.FechaBautismo = DateTime.Today;
            item.FechaNacimiento = DateTime.Today;
            return View(item);
        }
        // POST: Persona/Create
        [HttpPost]
        public ActionResult Create(PersonaVM item)
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);
            int resultado;
            try
            {
                Persona itemM = ModelService.ToModel(item);
                itemM.idParroquia = parroquia.id;
                itemM.UsuarioCrea = usuario.userName;
                //itemM.Estado = 1;
                resultado = PersonaBL.Create(itemM);

                if (resultado == 0)
                {
                    item.MensajeProceso = "Proceso realizado Fallido";
                    //return new HttpNotFoundResult(itemM.MensajeProceso);
                    return View(item);
                }
                else
                {
                    item.MensajeProceso = "Proceso realizado exitoso";
                    TempData["Empresa.Mensaje"] = item.MensajeProceso;
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(item);
            }
        }
        // GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);

            PersonaVM item = ModelService.ToView(PersonaBL.GetByID(parroquia.id, id));

            return View(item);
        }
        // POST: Persona/Edit/5
        [HttpPost]
        public ActionResult Edit(PersonaVM item)
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);
            int resultado;
            try
            {
                Persona itemM = ModelService.ToModel(item);
                itemM.idParroquia = parroquia.id;
                itemM.UsuarioModif = usuario.userName;
                //itemM.Estado = 1;
                resultado = PersonaBL.Update(itemM);
                if (resultado == 0)
                {
                    item.MensajeProceso = "Proceso realizado Fallido";
                    //return new HttpNotFoundResult(itemM.MensajeProceso);
                    return View(item);
                }
                else
                {

                    item.MensajeProceso = "Proceso realizado exitoso";
                    TempData["Empresa.Mensaje"] = item.MensajeProceso;
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(item);
            }
        }
        // GET: Persona/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        // POST: Persona/Delete/5
        [HttpPost]
        public ActionResult Delete(PersonaVM item)
        {
            try
            {
                int resultado = PersonaBL.Delete(item);
                if (resultado == 0)
                {
                    item.MensajeProceso = "Proceso realizado Fallido";
                    //return new HttpNotFoundResult(itemM.MensajeProceso);
                    return View(item);
                }
                else
                {
                    item.MensajeProceso = "Proceso realizado exitoso";
                    TempData["Empresa.Mensaje"] = item.MensajeProceso;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                item.MensajeProceso = "Proceso fallido: " + ex.Message;
                TempData["Persona.Mensaje"] = item.MensajeProceso;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult PersonaSacramento(PersonaVM item)
        {
            try
            {
                PersonaVM person = ModelService.ToView(PersonaBL.GetByID(item.idParroquia,item.id));
                return Json(person, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
