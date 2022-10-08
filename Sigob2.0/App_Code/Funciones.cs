using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de Funciones
/// </summary>
public class Funciones
{

    public static string DesencriptarAES(string plainText)
    {
        MemoryStream memoryStream = null;
        CryptoStream cryptoStream = null;
        try
        {
            byte[] initialVectorBytes;
            initialVectorBytes = Encoding.ASCII.GetBytes("3duc4rtScs1s0lu$");

            var saltValueBytes = Encoding.ASCII.GetBytes("S1c1r4u1*n4Y!");
            var cipherTextBytes = Convert.FromBase64String(plainText);
            var passwd = new PasswordDeriveBytes("S1c1r4u1*n4Y!", saltValueBytes, "SHA1", 2);
            var keyBytes = passwd.GetBytes(128 / 8);
            var symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            var decryptor = symmetricKey.CreateDecryptor(keyBytes, initialVectorBytes);
            memoryStream = new MemoryStream(cipherTextBytes);
            cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length + 1];
            var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            var desencriptado = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            return desencriptado;
        }
        catch
        {
            throw;
        }
        finally
        {
            if ((memoryStream != null))
                memoryStream.Close();
            if ((cryptoStream != null))
                cryptoStream.Close();
        }
    }
    public static string EncriptarAES(string plainText)
    {
        MemoryStream memoryStream = null;
        CryptoStream cryptoStream = null;
        try
        {
            byte[] initialVectorBytes;
            initialVectorBytes = Encoding.ASCII.GetBytes("3duc4rtScs1s0lu$");
            byte[] saltValueBytes = Encoding.ASCII.GetBytes("S1c1r4u1*n4Y!");
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var passwd = new PasswordDeriveBytes("S1c1r4u1*n4Y!", saltValueBytes, "SHA1", 2);
            byte[] keyBytes = passwd.GetBytes(128 / 8);
            var symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initialVectorBytes);
            memoryStream = new MemoryStream();
            cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            var cipherTextBytes = memoryStream.ToArray();
            var cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }
        catch
        {
            throw;
        }
        finally
        {
            if ((memoryStream != null))
                memoryStream.Close();
            if ((cryptoStream != null))
                cryptoStream.Close();
        }
    }

    public static string enviamail(string mailenvio, string asunto, string cuerpo)
    {
        SmtpClient host = new SmtpClient();
        host.Host = "webmail.joyeria5estrellas.com.mx";
        //host.EnableSsl = true;
        //host.Port = 2525;
        //host.DeliveryMethod = SmtpDeliveryMethod.Network;
        //host.UseDefaultCredentials = false;
        host.Credentials = new System.Net.NetworkCredential("noresponder@joyeria5estrellas.com.mx", "eC5d50m*");

        //host.Host = "smtp.gmail.com";
        //host.Port = 587;
        //host.EnableSsl = true;
        //host.DeliveryMethod = SmtpDeliveryMethod.Network;
        //host.UseDefaultCredentials = false;
        //host.Credentials = new System.Net.NetworkCredential("joyeria5tienda@gmail.com", "fRGcUtzD");

        //host.Host = "smtp.live.com";
        //host.Port = 587;
        //host.UseDefaultCredentials = false;
        //host.DeliveryMethod = SmtpDeliveryMethod.Network;
        //host.EnableSsl = true;
        //host.Credentials = new System.Net.NetworkCredential("raul.a.lopez.lopez@hotmail.com", "JosephDanari83!");

        MailMessage mensaje = new MailMessage();
        mensaje.To.Add(mailenvio);
        mensaje.From = new System.Net.Mail.MailAddress("noresponder@joyeria5estrellas.com.mx", "SIGOB");
        //mensaje.From = new System.Net.Mail.MailAddress("raul.a.lopez.lopez@hotmail.com", "SIGOB");
        mensaje.Subject = asunto;
        mensaje.IsBodyHtml = true;
        mensaje.Body = cuerpo;

        try
        {
            //ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            host.Send(mensaje);
            return "OK";
        }
        catch (Exception e)
        {
            return e.ToString();
        }


    }
}

