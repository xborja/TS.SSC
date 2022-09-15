using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using TS.SSC.BL;
using TS.SSC.Entity;
using TS.SSC.Portal.Services;
using TS.SSC.Portal.ViewModels;

namespace TS.SSC.Portal.Controllers
{
    public class RegistroSacramentoController : Controller
    {
        Usuario usuario = new Usuario();
        Parroquia parroquia = new ParroquiaVM();
        // GET: RegistroSacramento
        public ActionResult Index()
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);

            //RegistroSacramentoLVM items = ModelService.ToView(RegistroSacramentoBL.ToList(parroquia.id));
            RegistroSacramentoLVM items = new RegistroSacramentoLVM();
            var rangoSacramentos = RegistroSacramentoBL.GetYearRange(parroquia.id);
            items.AnioDesde = rangoSacramentos[0];
            items.AnioHasta= rangoSacramentos[1];
            return View(items);
        }

        [HttpPost]
        public ActionResult Index(RegistroSacramentoLVM item)
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);
            RegistroSacramentoLVM items = ModelService.ToView(RegistroSacramentoBL.ToList(parroquia.id, item.AnioDesde, item.AnioHasta, item.sacramento));
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

            RegistroSacramentoVM item = new RegistroSacramentoVM();
            item.idParroquia = parroquia.id;
            item.cargarListas();
            item.ListPersonas.Items.Add(new PersonaVM { id = -1, Nombre = "[Nuevo]" });
            item.PersonaM = new PersonaVM();
            item.PersonaM.FechaBautismo = DateTime.Today;
            item.PersonaM.FechaNacimiento = DateTime.Today;
            item.fechaRegistro = DateTime.Today;

            return View(item);
        }
        // POST: Persona/Create
        [HttpPost]
        public ActionResult Create(RegistroSacramentoVM item)
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);
            int resultado;
            try
            {
                if (item.PersonaM.id == 0)
                {

                    item.PersonaM.idParroquia = parroquia.id;
                    item.PersonaM.UsuarioCrea = usuario.userName; 
                    int rescr = PersonaBL.Create(item.PersonaM);
                    item.idPersona = item.PersonaM.id;
                }
                else
                {
                    item.PersonaM.UsuarioModif = usuario.userName;
                    int resup = PersonaBL.Update(item.PersonaM);
                }
                RegistroSacramento itemM = ModelService.ToModel(item);
                itemM.idParroquia = parroquia.id;
                itemM.UsuarioCrea = usuario.userName;
                //itemM.= 1;
                resultado = RegistroSacramentoBL.Create(itemM);

                if (resultado == 0)
                {
                    item.MensajeProceso = "Proceso realizado Fallido";
                    //return new HttpNotFoundResult(itemM.MensajeProceso);
                    return View(item);
                }
                else
                {
                    item.MensajeProceso = "Proceso realizado exitoso";
                    TempData["RegistroSacramento.Mensaje"] = item.MensajeProceso;
                    //ViewBag(item.MensajeProceso);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                item.idParroquia = parroquia.id;
                item.cargarListas();
                item.fechaRegistro = DateTime.Today;
                return View(item);
            }
        }
        // GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);

            RegistroSacramentoVM item = ModelService.ToView(RegistroSacramentoBL.GetByID(parroquia.id, id));
            item.cargarListas();
            item.ListPersonas.Items.Add(new PersonaVM { id = -1, Nombre = "[Nuevo]" });
            item.cargaPersona();
            return View(item);
        }
        // POST: Persona/Edit/5
        [HttpPost]
        public ActionResult Edit(RegistroSacramentoVM item)
        {
            UserService.CargaDatosUsuario(ref usuario, ref parroquia);
            if (item.PersonaM.id == 0)
            {

                item.PersonaM.idParroquia = parroquia.id;
                item.PersonaM.UsuarioCrea = usuario.userName;
                int rescr = PersonaBL.Create(item.PersonaM);
                item.idPersona = item.PersonaM.id;
            }
            else
            {
                item.PersonaM.idParroquia = parroquia.id;
                item.PersonaM.UsuarioModif = usuario.userName;
                int resup = PersonaBL.Update(item.PersonaM);
                item.idPersona = item.PersonaM.id;
            }

            int resultado;
            try
            {
                RegistroSacramento itemM = ModelService.ToModel(item);
                itemM.idParroquia = parroquia.id;
                itemM.UsuarioModif = usuario.userName;
                //itemM.Estado = 1;
                resultado = RegistroSacramentoBL.Update(itemM);
                if (resultado == 0)
                {
                    item.cargarListas();
                    item.ListPersonas.Items.Add(new PersonaVM { id = -1, Nombre = "[Nuevo]" });
                    item.cargaPersona();
                    item.MensajeProceso = "Proceso Fallido";
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
        public ActionResult Delete(RegistroSacramentoVM item)
        {
            try
            {
                int resultado = RegistroSacramentoBL.Delete(item);
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

        public ActionResult DisplayAPDF(printSacramentoVM registro)
        {
            List<printSacramentoBL> printactual;
            try
            {
                printactual = printSacramentoBL.ToList(1, registro.idRegistro);
                //string documento = PDFService.ExportProformasDAToPDF(id, ds);
                if (printactual.Count>0)
                {
                    printactual[0].NotaMarginal = registro.NotaMarginal;
                    byte[] bytes = PDFService.ExportRegistroAPDFStream(printactual);
                    if (bytes.Length > 0)
                    {
                        MemoryStream workStream = new MemoryStream(bytes);
                        return new FileStreamResult(workStream, "application/pdf");
                    }
                    else
                        return Content("El Archivo no contiene datos, favor verificar");
                }
                else
                    return Content("El Archivo no contiene datos, favor verificar");

            }
            catch (Exception ex)
            {
                return Content("No se generó el reporte. El error es: " + ex.Message);
            }

        }
        public ActionResult DisplayAPDFMembrete(printSacramentoVM registro)
        {
            List<printSacramentoBL> printactual;
            try
            {
                printactual = printSacramentoBL.ToList(1, registro.idRegistro);
                //string documento = PDFService.ExportProformasDAToPDF(id, ds);
                if (printactual.Count > 0)
                {
                    printactual[0].NotaMarginal = registro.NotaMarginal;
                    byte[] bytes = PDFService.ExportRegistroMembreteAPDFStream(printactual);
                    if (bytes.Length > 0)
                    {
                        MemoryStream workStream = new MemoryStream(bytes);
                        return new FileStreamResult(workStream, "application/pdf");
                    }
                    else
                        return Content("El Archivo no contiene datos, favor verificar");
                }
                else
                    return Content("El Archivo no contiene datos, favor verificar");

            }
            catch (Exception ex)
            {
                return Content("No se generó el reporte. El error es: " + ex.Message);
            }

        }

    }
}