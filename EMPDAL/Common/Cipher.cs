using System.Security.Cryptography;
using System.Text;

namespace EMPDAL
{
    public class Cipher
    {
        private const string _secureKey = "837ey96d-ooi9-12s3-lo90-14qjuys5";

        public static string Encrypt(string plainText)
        {
            string base64String;
            try
            {
                RijndaelManaged rijndaelManaged1 = new RijndaelManaged
                {
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7,
                    KeySize = 128,
                    BlockSize = 128
                };
                RijndaelManaged rijndaelManaged2 = rijndaelManaged1;
                byte[] bytes1 = Encoding.UTF8.GetBytes("837ey96d-ooi9-12s3-lo90-14qjuys5");
                byte[] destinationArray = new byte[16];
                int length = bytes1.Length;
                if (length > destinationArray.Length)
                    length = destinationArray.Length;
                Array.Copy((Array)bytes1, (Array)destinationArray, length);
                rijndaelManaged2.Key = destinationArray;
                rijndaelManaged2.IV = destinationArray;
                ICryptoTransform encryptor = rijndaelManaged2.CreateEncryptor();
                byte[] bytes2 = Encoding.UTF8.GetBytes(plainText);
                base64String = Convert.ToBase64String(encryptor.TransformFinalBlock(bytes2, 0, bytes2.Length));
            }
            catch
            {
                throw;
            }
            return base64String;
        }

        public static string Decrypt(string encryptedText)
        {
            string str;
            try
            {
                RijndaelManaged rijndaelManaged1 = new RijndaelManaged();
                rijndaelManaged1.Mode = CipherMode.CBC;
                rijndaelManaged1.Padding = PaddingMode.PKCS7;
                rijndaelManaged1.KeySize = 128;
                rijndaelManaged1.BlockSize = 128;
                RijndaelManaged rijndaelManaged2 = rijndaelManaged1;
                byte[] inputBuffer = Convert.FromBase64String(encryptedText);
                byte[] bytes = Encoding.UTF8.GetBytes("837ey96d-ooi9-12s3-lo90-14qjuys5");
                byte[] destinationArray = new byte[16];
                int length = bytes.Length;
                if (length > destinationArray.Length)
                    length = destinationArray.Length;
                Array.Copy((Array)bytes, (Array)destinationArray, length);
                rijndaelManaged2.Key = destinationArray;
                rijndaelManaged2.IV = destinationArray;
                str = Encoding.UTF8.GetString(rijndaelManaged2.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
            }
            catch
            {
                throw;
            }
            return str;
        }
    }
}
