using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AES : IEncryptionAlgorithm
{
    public string Name { get; set; }

    public AES( )
    {
        Name = "AES";
    }

    public string Encrypt(string Content, byte[] Key)
    {
        using (Aes AES = Aes.Create())
        {
            AES.Key = Key;
            AES.GenerateIV();

            byte[] Plain = Encoding.UTF8.GetBytes(Content);

            using (MemoryStream MemStream = new MemoryStream())
            {
                MemStream.Write(AES.IV, 0, AES.IV.Length);

                using (CryptoStream CryptStream = new CryptoStream(MemStream, AES.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    CryptStream.Write(Plain, 0, Plain.Length);
                    CryptStream.FlushFinalBlock();
                }

                return Convert.ToBase64String(MemStream.ToArray());
            }
        }
    }

    public string Decrypt(string Content, byte[] Key)
    {
        byte[] EncryptedData = Convert.FromBase64String(Content);

        using (Aes AES = Aes.Create())
        {
            AES.Key = Key;

            byte[] IV = new byte[AES.BlockSize / 8];
            Array.Copy(EncryptedData, 0, IV, 0, IV.Length);
            AES.IV = IV;

            using (MemoryStream MemStream = new MemoryStream(EncryptedData, IV.Length, EncryptedData.Length - IV.Length))
            using (CryptoStream CryptStream = new CryptoStream(MemStream, AES.CreateDecryptor(), CryptoStreamMode.Read))
            using (StreamReader Reader = new StreamReader(CryptStream, Encoding.UTF8))
            {
                return Reader.ReadToEnd();
            }
        }
    }
}