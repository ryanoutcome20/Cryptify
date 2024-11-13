using System;

public interface IEncryptionAlgorithm
{
    string Name { get; set; }

    string Encrypt(string Content, byte[] Key);
    string Decrypt(string Content, byte[] Key);
}