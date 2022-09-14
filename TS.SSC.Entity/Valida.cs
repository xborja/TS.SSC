using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS.TS.SSC.Entity
{
    public static class Valida
    {
        public static string Str(string Cadena)
        {
            string VaPr_Cadena = "";


            if (Cadena == null)
            {
                VaPr_Cadena = "";
            }
            else
            {
                VaPr_Cadena = Cadena.Trim();
            }
            return VaPr_Cadena;
        }
        public static string StrN(string Cadena)
        {
            string VaPr_Cadena = "";

            if (Cadena == null || Cadena == "")
            {
                VaPr_Cadena = "0";
            }
            else
            {
                VaPr_Cadena = Cadena.Trim();
            }
            return Convert.ToInt32(VaPr_Cadena).ToString();
        }
        public static string NStr(string Cadena)
        {
            string VaPr_Cadena = "";

            if (Cadena == null || Cadena == "")
            {
                VaPr_Cadena = "";
            }
            else
            {
                VaPr_Cadena = Cadena.Trim();
            }
            return VaPr_Cadena;
        }
        public static string StrD(string Cadena)
        {
            string VaPr_Cadena = "";

            if (Cadena == null || Cadena == "")
            {
                VaPr_Cadena = "0";
            }
            else
            {
                VaPr_Cadena = Cadena.Trim();
            }
            return Convert.ToDouble(VaPr_Cadena).ToString();
        }
        public static string StrDec(string Cadena)
        {
            string VaPr_Cadena = "";

            if (Cadena == null || Cadena == "")
            {
                VaPr_Cadena = "0";
            }
            else
            {
                VaPr_Cadena = Cadena.Trim();
            }
            return Convert.ToDecimal(VaPr_Cadena).ToString();
        }
        public static bool EsNumero(string Cadena)
        {
            string VaPr_Cadena = "";
            string Caract = "";
            bool num = true;
            int NCarac = 0;

            if (Cadena == null || Cadena == "")
            {
                VaPr_Cadena = "0";
                num = false;
            }
            else
            {
                VaPr_Cadena = Cadena.Trim();
                foreach (char l in VaPr_Cadena)
                {
                    NCarac = Convert.ToInt32(l);
                    if ((NCarac != 46 && NCarac != 45 && NCarac < 48) || 57 < NCarac)
                    {
                        num = false;
                    }
                }
            }
            return num;
        }
        public static int Val(string Cadena)
        {
            try
            {
                string VaPr_Cadena = "";

                if (Cadena == null || Cadena == "")
                {
                    VaPr_Cadena = "0";
                }
                else
                {
                    VaPr_Cadena = Cadena.Trim();
                }
                return Convert.ToInt32(VaPr_Cadena.Split('.')[0]);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static int Val(int Valor)
        {
            int VaPr_Cadena;

            if (Valor == null)
            {
                VaPr_Cadena = 0;
            }
            else
            {
                VaPr_Cadena = Valor;
            }
            return VaPr_Cadena;
        }
        public static decimal Dec(string Cadena)
        {
            string VaPr_Cadena = "";

            if (Cadena == null || Cadena == "")
            {
                VaPr_Cadena = "0";
            }
            else
            {
                VaPr_Cadena = Cadena.Trim();
            }
            return Convert.ToDecimal(VaPr_Cadena);
        }
        public static double DVal(string Cadena)
        {
            try
            {
                string VaPr_Cadena = "";

                if (Cadena == null || Cadena == "")
                {
                    VaPr_Cadena = "0";
                }
                else
                {
                    VaPr_Cadena = Cadena.Trim();
                }
                return Convert.ToDouble(VaPr_Cadena);
            }
            catch (Exception ex)
            {
                return Convert.ToDouble(0);
            }
        }

        public static bool ValFechaFormat(string Fecha, FormatFecha FormaORG)
        {
            try
            {
                DateTime FechaCal = new DateTime();
                string Dia = "", Mes = "", Anio = "";

                if (Valida.Str(Fecha) != "")
                {
                    switch (FormaORG)
                    {
                        case FormatFecha.DMY:
                            Dia = Fecha.Substring(0, 2);
                            Mes = Fecha.Substring(3, 2);
                            Anio = Fecha.Substring(6, 4);
                            break;
                        case FormatFecha.YMD:
                            Dia = Fecha.Substring(8, 2);
                            Mes = Fecha.Substring(5, 2);
                            Anio = Fecha.Substring(0, 4);
                            break;
                        case FormatFecha.MDY:
                            Dia = Fecha.Substring(3, 2);
                            Mes = Fecha.Substring(0, 2);
                            Anio = Fecha.Substring(6, 4);
                            break;
                        case FormatFecha.DYM:
                            Dia = Fecha.Substring(0, 2);
                            Mes = Fecha.Substring(6, 2);
                            Anio = Fecha.Substring(4, 4);
                            break;
                    }
                    FechaCal = new DateTime(Valida.Val(Anio), Valida.Val(Mes), Valida.Val(Dia));
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static string FechaAct(FormatFecha Formato, string Separador)
        {
            string Cadena = "";
            string Dia = "", Mes = "", Anio = "";

            Dia = (100 + (DateTime.Now.Day)).ToString().Substring(1, 2).Trim();
            Mes = (100 + (DateTime.Now.Month)).ToString().Substring(1, 2).Trim();
            Anio = (DateTime.Now.Year).ToString().Trim();

            switch (Formato)
            {
                case FormatFecha.DMY:
                    Cadena = Dia + Separador + Mes + Separador + Anio;
                    break;
                case FormatFecha.YMD:
                    Cadena = Anio + Separador + Mes + Separador + Dia;
                    break;
                case FormatFecha.MDY:
                    Cadena = Mes + Separador + Dia + Separador + Anio;
                    break;
                case FormatFecha.DYM:
                    Cadena = Dia + Separador + Anio + Separador + Mes;
                    break;
            }

            return Cadena;
        }
        public static string FechaAct_Dia(FormatFecha Formato, string Separador)
        {
            string Dia = "";

            Dia = (100 + (DateTime.Now.Day)).ToString().Substring(1, 2).Trim();

            return Dia;
        }
        public static string FechaAct_Mes(FormatFecha Formato, string Separador)
        {
            string Mes = "";

            Mes = (100 + (DateTime.Now.Month)).ToString().Substring(1, 2).Trim();

            return Mes;
        }
        public static string FechaAct_Anio(FormatFecha Formato, string Separador)
        {
            string Anio = "";

            Anio = (DateTime.Now.Year).ToString().Trim();

            return Anio;
        }
        public static string DifHoyVSFecha(string Fecha, FormatFecha FormaORG)
        {
            int CantDias = 0;
            DateTime Hoy;
            DateTime FechaPR;

            Hoy = DateTime.Now;

            string Dia = "", Mes = "", Anio = "";

            if (Valida.Str(Fecha) != "")
            {
                switch (FormaORG)
                {
                    case FormatFecha.DMY:
                        Dia = Fecha.Substring(0, 2);
                        Mes = Fecha.Substring(3, 2);
                        Anio = Fecha.Substring(6, 4);
                        break;
                    case FormatFecha.YMD:
                        Dia = Fecha.Substring(8, 2);
                        Mes = Fecha.Substring(5, 2);
                        Anio = Fecha.Substring(0, 4);
                        break;
                    case FormatFecha.MDY:
                        Dia = Fecha.Substring(3, 2);
                        Mes = Fecha.Substring(0, 2);
                        Anio = Fecha.Substring(6, 4);
                        break;
                    case FormatFecha.DYM:
                        Dia = Fecha.Substring(0, 2);
                        Mes = Fecha.Substring(6, 2);
                        Anio = Fecha.Substring(4, 4);
                        break;
                }
                FechaPR = Convert.ToDateTime(Fecha + " " + Hoy.TimeOfDay.ToString());
                TimeSpan Mio = FechaPR - Hoy;
                CantDias = ((int)(Mio.TotalDays)); // Compare(Hoy, Fecha);
            }
            return CantDias.ToString();
        }
        public static string DifFechaXVSFecha(string FechaX, string Fecha, FormatFecha FormaORG)
        {
            int CantDias = 0;
            DateTime Hoy;
            DateTime FechaPR;

            string Dia = "", Mes = "", Anio = "";
            string Diax = "", Mesx = "", Aniox = "";

            if (Valida.Str(Fecha) != "")
            {
                switch (FormaORG)
                {
                    case FormatFecha.DMY:
                        Dia = Fecha.Substring(0, 2);
                        Mes = Fecha.Substring(3, 2);
                        Anio = Fecha.Substring(6, 4);

                        Diax = FechaX.Substring(0, 2);
                        Mesx = FechaX.Substring(3, 2);
                        Aniox = FechaX.Substring(6, 4);
                        break;
                    case FormatFecha.YMD:
                        Dia = Fecha.Substring(8, 2);
                        Mes = Fecha.Substring(5, 2);
                        Anio = Fecha.Substring(0, 4);

                        Diax = FechaX.Substring(8, 2);
                        Mesx = FechaX.Substring(5, 2);
                        Aniox = FechaX.Substring(0, 4);
                        break;
                    case FormatFecha.MDY:
                        Dia = Fecha.Substring(3, 2);
                        Mes = Fecha.Substring(0, 2);
                        Anio = Fecha.Substring(6, 4);

                        Diax = FechaX.Substring(3, 2);
                        Mesx = FechaX.Substring(0, 2);
                        Aniox = FechaX.Substring(6, 4);
                        break;
                    case FormatFecha.DYM:
                        Dia = Fecha.Substring(0, 2);
                        Mes = Fecha.Substring(6, 2);
                        Anio = Fecha.Substring(4, 4);

                        Diax = FechaX.Substring(0, 2);
                        Mesx = FechaX.Substring(6, 2);
                        Aniox = FechaX.Substring(4, 4);
                        break;
                }

                Hoy = new DateTime(Valida.Val(Aniox), Valida.Val(Mesx), Valida.Val(Diax));

                FechaPR = Convert.ToDateTime(Fecha + " " + Hoy.TimeOfDay.ToString());
                TimeSpan Mio = FechaPR - Hoy;
                CantDias = ((int)(Mio.TotalDays)); // Compare(Hoy, Fecha);
            }
            return CantDias.ToString();
        }
        public static string CFechaFormat(string Fecha, FormatFecha FormaORG, FormatFecha FormaDST, string Separador)
        {
            string Cadena = "";
            string Dia = "", Mes = "", Anio = "";

            if (Valida.Str(Fecha) != "")
            {
                switch (FormaORG)
                {
                    case FormatFecha.DMY:
                        Dia = Fecha.Substring(0, 2);
                        Mes = Fecha.Substring(3, 2);
                        Anio = Fecha.Substring(6, 4);
                        break;
                    case FormatFecha.YMD:
                        Dia = Fecha.Substring(8, 2);
                        Mes = Fecha.Substring(5, 2);
                        Anio = Fecha.Substring(0, 4);
                        break;
                    case FormatFecha.MDY:
                        Dia = Fecha.Substring(3, 2);
                        Mes = Fecha.Substring(0, 2);
                        Anio = Fecha.Substring(6, 4);
                        break;
                    case FormatFecha.DYM:
                        Dia = Fecha.Substring(0, 2);
                        Mes = Fecha.Substring(6, 2);
                        Anio = Fecha.Substring(4, 4);
                        break;
                }

                switch (FormaDST)
                {
                    case FormatFecha.DMY:
                        Cadena = Dia + Separador + Mes + Separador + Anio;
                        break;
                    case FormatFecha.YMD:
                        Cadena = Anio + Separador + Mes + Separador + Dia;
                        break;
                    case FormatFecha.MDY:
                        Cadena = Mes + Separador + Dia + Separador + Anio;
                        break;
                    case FormatFecha.DYM:
                        Cadena = Dia + Separador + Anio + Separador + Mes;
                        break;
                    case FormatFecha.ddmmyy:
                        Cadena = Dia + Separador + Mes + Separador + Anio.Substring(2, 2);
                        break;
                    case FormatFecha.yymmdd:
                        Cadena = Anio.Substring(2, 2) + Separador + Mes + Separador + Dia;
                        break;
                    case FormatFecha.mmddyy:
                        Cadena = Mes + Separador + Dia + Separador + Anio.Substring(2, 2);
                        break;
                    case FormatFecha.ddyymm:
                        Cadena = Dia + Separador + Anio.Substring(2, 2) + Separador + Mes;
                        break;
                }
            }
            return Cadena;
        }
        public static string CFechaFormat(DateTime Fecha, FormatFecha Formato, string Separador)
        {
            string Cadena = "";
            string Dia = "", Mes = "", Anio = "";

            Dia = (100 + (Fecha.Day)).ToString().Substring(1, 2).Trim();
            Mes = (100 + (Fecha.Month)).ToString().Substring(1, 2).Trim();
            Anio = (Fecha.Year).ToString().Trim();

            switch (Formato)
            {
                case FormatFecha.DMY:
                    Cadena = Dia + Separador + Mes + Separador + Anio;
                    break;
                case FormatFecha.YMD:
                    Cadena = Anio + Separador + Mes + Separador + Dia;
                    break;
                case FormatFecha.MDY:
                    Cadena = Mes + Separador + Dia + Separador + Anio;
                    break;
                case FormatFecha.DYM:
                    Cadena = Dia + Separador + Anio + Separador + Mes;
                    break;
                case FormatFecha.ddmmyy:
                    Cadena = Dia + Separador + Mes + Separador + Anio.Substring(2, 2);
                    break;
                case FormatFecha.yymmdd:
                    Cadena = Anio.Substring(2, 2) + Separador + Mes + Separador + Dia;
                    break;
                case FormatFecha.mmddyy:
                    Cadena = Mes + Separador + Dia + Separador + Anio.Substring(2, 2);
                    break;
                case FormatFecha.ddyymm:
                    Cadena = Dia + Separador + Anio.Substring(2, 2) + Separador + Mes;
                    break;
            }

            return Cadena;
        }
        public enum FormatFecha
        {
            DMY = 1,
            YMD = 2,
            MDY = 3,
            DYM = 4,
            ddmmyy = 5,
            yymmdd = 6,
            mmddyy = 7,
            ddyymm = 8,
            LMDY = 9 //ref ant 5
        }
    }
}
