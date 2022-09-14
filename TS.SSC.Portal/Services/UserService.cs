using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using TS.SSC.BL;
using TS.SSC.Entity;


namespace TS.SSC.Portal.Services
{
    public class UserService
    {
        public static void CargaDatosUsuario(ref Usuario usuario, ref Parroquia parroquia)
        {
            if (HttpContext.Current.Session["GlbUsrInst2774378"] == null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    usuario = UsuarioBL.GetByUserName(HttpContext.Current.User.Identity.GetUserId());
                    parroquia = ParroquiaBL.GetByID(usuario.idParroquia);
                    //usuario = Usuario.GetNivelesAprobacionGral(usuario);
                    HttpContext.Current.Session["GlbUsrInst2774378"] = usuario;
                    HttpContext.Current.Session["GlbPerInst2774380"] = parroquia;
                }
            }
            else
            {
                usuario = (Usuario)HttpContext.Current.Session["GlbUsrInst2774378"];
                parroquia = (Parroquia)HttpContext.Current.Session["GlbPerInst2774380"];
            }

        }

    }
}