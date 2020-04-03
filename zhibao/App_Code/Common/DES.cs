using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// DES 的摘要说明
/// </summary>
public class DES
{
    /// <summary>
    /// 解密
    /// </summary>
    /// <param name="encryptedString"></param>
    /// <returns></returns>
    public static string Decrypt(string encryptedString)
    {
        if (encryptedString == null || encryptedString == "")
        {
            return encryptedString;
        }
        string str = "";
        byte[] bytes = Encoding.Default.GetBytes(Config.DESString);
        byte[] rgbIV = Encoding.Default.GetBytes(Config.DESString);
        DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
        using (MemoryStream stream = new MemoryStream())
        {
            byte[] buffer = Convert.FromBase64String(encryptedString);
            try
            {
                using (CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write))
                {
                    stream2.Write(buffer, 0, buffer.Length);
                    stream2.FlushFinalBlock();
                }
                str = Encoding.Default.GetString(stream.ToArray());
            }
            catch (Exception ex)
            {
                string ret = ex.Message;
            }
        }
        return str;
    }
    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="sourceString"></param>
    /// <returns></returns>
    public static string Encrypt(string sourceString)
    {
        if (sourceString == null || sourceString == "")
        {
            return sourceString;
        }
        string str;
        byte[] bytes = Encoding.Default.GetBytes(Config.DESString);
        byte[] rgbIV = Encoding.Default.GetBytes(Config.DESString);
        DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
        using (MemoryStream stream = new MemoryStream())
        {
            byte[] buffer = Encoding.Default.GetBytes(sourceString);
            try
            {
                using (CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write))
                {
                    stream2.Write(buffer, 0, buffer.Length);
                    stream2.FlushFinalBlock();
                }
                str = Convert.ToBase64String(stream.ToArray());
            }
            catch
            {
                throw;
            }
        }
        return str;
    }


    public static string DESDeCode(string pToDecrypt, string sKey)
    {
        //    HttpContext.Current.Response.Write(pToDecrypt + "<br>" + sKey);     
        //    HttpContext.Current.Response.End();     
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();

        byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
        for (int x = 0; x < pToDecrypt.Length / 2; x++)
        {
            int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
            inputByteArray[x] = (byte)i;
        }

        des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
        des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();

        StringBuilder ret = new StringBuilder();

        // return HttpContext.Current.Server.UrlDecode(System.Text.Encoding.Default.GetString(ms.ToArray()));  
        return System.Text.Encoding.Default.GetString(ms.ToArray());
    }    
}