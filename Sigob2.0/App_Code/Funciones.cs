using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

}

