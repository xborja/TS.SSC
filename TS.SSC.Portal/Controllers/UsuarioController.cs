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
    public class UsuarioController : Controller
    {
        Usuario usuario = new Usuario();
        Parroquia parroquia = new ParroquiaVM();
        // GET: Usuario
        public ActionResult Index()
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);
            UsuarioLVM items = ModelService.ToView(UsuarioBL.ToList(parroquia.id));
       
            return View(items);
        }
        // GET: Usuario/Create
        public ActionResult Create()
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);
            UsuarioVM item = new UsuarioVM();
            item.CargarListas();
            return View(item);
        }
        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioVM item)
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);
            int resultado;
            try
            {
                Usuario itemM = ModelService.ToModel(item);
                string saltpass = Encriptacion.GetRandomSalt(20);
                string hashpass = Encriptacion.HashPassword(itemM.password, saltpass);
                itemM.passwordHash = saltpass;
                itemM.tipoUsuario = "normal";
                itemM.password = hashpass;
                itemM.estado = true;
                itemM.idParroquia = parroquia.id;
                itemM.FechaCreacion = DateTime.Today;
                itemM.UsuarioCrea = usuario.userName;
                resultado = UsuarioBL.Create(itemM);

                if (resultado == 0)
                {
                    return new HttpNotFoundResult(itemM.MensajeProceso);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(item);
            }

        }
        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            UsuarioVM item = ModelService.ToView(UsuarioBL.GetByID(id));
            item.CargarDetalles();
            item.CargarListas();
            return View(item);
        }
        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioVM item)
        {
            int resultado;
            try
            {
                UserService.CargaDatosUsuario(ref usuario, ref parroquia);
                Usuario itemM = ModelService.ToModel(item);
                string saltpass = Encriptacion.GetRandomSalt(20);
                string hashpass = Encriptacion.HashPassword(itemM.password, saltpass);
                itemM.passwordHash = saltpass;
                itemM.password = hashpass;
                itemM.tipoUsuario = "normal";
                itemM.estado = true;
                itemM.idParroquia = parroquia.id;
                itemM.FechaModif = DateTime.Today;
                itemM.UsuarioModif = usuario.userName;
                resultado = UsuarioBL.Update(itemM);
                if (resultado == 0)
                {
                    return new HttpNotFoundResult(itemM.MensajeProceso);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(item);
            }
        }
        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ChangeEstado(int id)
        {
            Usuario itemM = UsuarioBL.GetByID(id);
            itemM.estado = !itemM.estado;
            int resultado = UsuarioBL.Update(itemM);
            if (resultado == 0)
            {
                return new HttpNotFoundResult(itemM.MensajeProceso);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
