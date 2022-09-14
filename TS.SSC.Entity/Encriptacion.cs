using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TS.SSC.Entity
{
    public static class Encriptacion
    {
        //public static String fnq2_enc(String texto)
        //{
        //    String secretKey = "ATMTokenPa$$w0rd"; //llave para encriptar datos
        //    String base64EncryptedString = "";
        //    try
        //    {
        //        MessageDigest md = MessageDigest.getInstance("SHA");
        //        byte[] digestOfPassword = md.digest(secretKey.getBytes("utf - 8"));
        //        byte[] keyBytes = Arrays.copyOf(digestOfPassword, 24);
        //        SecretKey key = new SecretKeySpec(keyBytes, "DESede");
        //        Cipher cipher = Cipher.getInstance("DESede");
        //        cipher.init(Cipher.ENCRYPT_MODE, key);
        //        byte[] plainTextBytes = texto.getBytes("utf - 8");
        //        byte[] buf = cipher.doFinal(plainTextBytes);
        //        byte[] base64Bytes = Base64.encodeBase64(buf);
        //        base64EncryptedString = new String(base64Bytes);
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return base64EncryptedString;
        //}

        public static string fnq_enc(string texto)


        {
            String secretKey = "HATokenPa$$w0rd"; //llave para encriptar datos
            String base64EncryptedString = "";
            var encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(secretKey);
            byte[] messageBytes = encoding.GetBytes(texto);


            try
            {
                using (var hmacsha256 = new HMACSHA256(keyByte))
                {
                    byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                    base64EncryptedString = Convert.ToBase64String(hashmessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar hash SHA512", ex);
            }
            return base64EncryptedString;
        }

        public static String HashPassword(String password, String salt)
        {
            var combinedPassword = String.Concat(password, salt);
            var sha256 = new SHA256Managed();
            var bytes = UTF8Encoding.UTF8.GetBytes(combinedPassword);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }


        public static String GetRandomSalt(Int32 size = 12)
        {
            var random = new RNGCryptoServiceProvider();
            var salt = new Byte[size];
            random.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public static Boolean ValidatePassword(String enteredPassword, String storedHash, String storedSalt)
        {
            // Consider this function as an internal function where parameters like
            // storedHash and storedSalt are read from the database and then passed.

            //var hash = HashPassword(enteredPassword, storedSalt);
            //return String.Equals(storedHash, hash);


            var hash = HashPassword(enteredPassword, storedSalt);
            if (storedSalt == "")
            {
                hash = enteredPassword;
            }
            return String.Equals(storedHash, hash);
        }
    }
}
