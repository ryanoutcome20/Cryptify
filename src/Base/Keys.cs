using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class KeyGenerator
{
    public static byte[] GenerateKey(string Password)
    {
        // AES makes it stronger for us, so we don't need to do any work.

        using (SHA256 SHA = SHA256.Create())
        {
            return SHA.ComputeHash(Encoding.UTF8.GetBytes(Password));
        }
    }

    private static readonly byte[][] WeakKeys = {
        new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // All-zero key
        new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, // All-one key
        new byte[] { 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01 }, // 0x0101010101010101
        new byte[] { 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE, 0xFE }, // 0xFEFEFEFEFEFEFEFE
        new byte[] { 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F, 0x1F }, // 0x1F1F1F1F1F1F1F1F
        new byte[] { 0xE0, 0xE0, 0xE0, 0xE0, 0xE0, 0xE0, 0xE0, 0xE0 }, // 0xE0E0E0E0E0E0E0E0
        new byte[] { 0xF0, 0xF0, 0xF0, 0xF0, 0xF0, 0xF0, 0xF0, 0xF0 }, // 0xF0F0F0F0F0F0F0F0
    };

    public static byte[] GenerateStableKey(string Password)
    {
        // We have to prevent DES-based algorithms from screaming that it's a weak key at us.

        using (SHA256 SHA = SHA256.Create())
        {
            byte[] Key;


            // Although this looks highly unsafe and looks like it'll result in an infinite loop,
            // the chances are actually 2.6*10^-8 (1 in 260 million).
            do
            {
                // Compute the SHA-256 hash of the password and take first 8 bytes.
                byte[] hash = SHA.ComputeHash(Encoding.UTF8.GetBytes(Password));
                Key = hash.Take(8).ToArray();
            
                // Repeat until the key doesn't match any weak key.
            } while (WeakKeys.Any(wk => wk.SequenceEqual(Key)));

            // Set the parity bit for each byte in the key to ensure DES "security".
            for (int i = 0; i < Key.Length; i++)
            {
                Key[i] = SetParityBit(Key[i]);
            }

            return Key;
        }
    }

    private static byte SetParityBit(byte Key)
    {
        int Bit = 0;

        // Calculate the parity by XORing all bits in the byte, except the parity bit.
        for (int i = 0; i < 7; i++)
        {
            Bit ^= (Key >> i) & 0x01;
        }

        // Clear the current parity bit (bit 0).
        Key &= 0xFE;

        // Set it up so that the parity bit will have odd parity.
        Key |= (byte)(Bit ^ 1);

        return Key;
    }
}
