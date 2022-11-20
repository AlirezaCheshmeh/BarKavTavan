using System.Security.Cryptography;
using System.Text;

namespace AdminBarKavTavan.Services
{
    public class Utility
    {
        public static string ActiveCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6);
        }

        public static string HashPssword(string password)
        {
            
            
                Byte[] mainBytes;
                Byte[] encodingBytes;


                MD5 md5;
                md5 = new MD5CryptoServiceProvider();
                mainBytes = ASCIIEncoding.Default.GetBytes(password);
                encodingBytes = md5.ComputeHash(mainBytes);
                return BitConverter.ToString(encodingBytes);
            
            
        }

    }
}
