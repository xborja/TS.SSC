using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TS.SSC.Entity;

namespace TS.SSC.BL
{
    public class Auth
    {
        public static Usuario user { get; set; }
        public static List<string> permissions { get; set; }
        public static void setUser(Usuario p_user)
        {
            user = p_user;
        }


        public static Usuario getUser(String id)
        {
            if (user == null)
            {
                user = UsuarioBL.GetByID(Convert.ToInt32(id));
            }

            return user;
        }


   

        public static bool can(string module, string action)
        {   // agrego consulta por la descripcion tambien (acccion) BPM 08/12/2017
            string var = permissions.Where(x => x.Contains(module)).Where(x => x.Contains(action)).FirstOrDefault();

            if (var == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}

