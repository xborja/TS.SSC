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
    public class SacramentoController : Controller
    {
        // GET: Sacramento
        Usuario usuario = new Usuario();
        Parroquia parroquia = new ParroquiaVM();
        // GET: Sacramento
        public ActionResult Index()
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);

            SacramentoLVM items = ModelService.ToView(SacramentoBL.ToList());
            return View(items);
        }
        // GET: Sacramento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: Sacramento/Create
        public ActionResult Create()
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);

            SacramentoVM item = new SacramentoVM();
            item.estado = true;
            item.estadoT = 1;
            return View(item);
        }
        // POST: Sacramento/Create
        [HttpPost]
        public ActionResult Create(SacramentoVM item)
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);
            int resultado;
            try
            {
                Sacramento itemM = ModelService.ToModel(item);
                
                itemM.UsuarioCrea = usuario.userName;
                //itemM.Estado = 1;   
                if (item.estadoT == 1)
                itemM.estado = true;
            else
                itemM.estado =false;
                resultado = SacramentoBL.Create(itemM);

                if (resultado == 0)
                {
                    item.MensajeProceso = "Proceso realizado Fallido";
                    //return new HttpNotFoundResult(itemM.MensajeProceso);
                    return View(item);
                }
                else
                {
                    item.MensajeProceso = "Proceso realizado exitoso";
                    TempData["Sacramento.Mensaje"] = item.MensajeProceso;
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(item);
            }
        }
        // GET: Sacramento/Edit/5
        public ActionResult Edit(int id)
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);

            SacramentoVM item = new SacramentoVM();
                item= ModelService.ToView(SacramentoBL.GetByID(id));
            if (item.estado == true)
                item.estadoT = 1;
            else
                item.estadoT = 0;
            return View(item);
        }
        // POST: Sacramento/Edit/5
        [HttpPost]
        public ActionResult Edit(SacramentoVM item)
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);
            int resultado;
            try
            {
                Sacramento itemM = ModelService.ToModel(item);
                
                itemM.UsuarioModif = usuario.userName;
                if (item.estadoT == 1)
                    itemM.estado = true;
                else
                    itemM.estado = false;
                resultado = SacramentoBL.Update(itemM);
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
        // GET: Sacramento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        // POST: Sacramento/Delete/5
        [HttpPost]
        public ActionResult Delete(SacramentoVM item)
        {
            try
            {
                int resultado = SacramentoBL.Delete(item);
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
                TempData["Sacramento.Mensaje"] = item.MensajeProceso;
                return RedirectToAction("Index");
            }
        }
    }
}