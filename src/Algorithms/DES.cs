using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class dES : IEncryptionAlgorithm
{
    public string Name { get; set; }

    public dES()
    {
        Name = "DES";
    }

    public string Encrypt(string Content, byte[] Key)
    {
        using (DES dES = DES.Create())
        {
            dES.Key = Key;
            dES.GenerateIV();

            byte[] Plain = Encoding.UTF8.GetBytes(Content);

            using (MemoryStream MemStream = new MemoryStream())
            {
                MemStream.Write(dES.IV, 0, dES.IV.Length);

                using (CryptoStream CryptStream = new CryptoStream(MemStream, dES.CreateEncryptor(), CryptoStreamMode.Write))
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

        using (DES dES = DES.Create())
        {
            dES.Key = Key;

            byte[] IV = new byte[dES.BlockSize / 8];
            Array.Copy(EncryptedData, 0, IV, 0, IV.Length);
            dES.IV = IV;

            using (MemoryStream MemStream = new MemoryStream(EncryptedData, IV.Length, EncryptedData.Length - IV.Length))
            using (CryptoStream CryptStream = new CryptoStream(MemStream, dES.CreateDecryptor(), CryptoStreamMode.Read))
            using (StreamReader Reader = new StreamReader(CryptStream, Encoding.UTF8))
            {
                return Reader.ReadToEnd();
            }
        }
    }
}