using System.IO;
using System.Windows.Forms;

public class Engine
{
    public IEncryptionAlgorithm Algorithm { get; set; }

    public Engine(IEncryptionAlgorithm _Algorithm)
    {
        /*
         * It's setup like this so that Form1.cs can access this variable and adjust it
         * based on what you input into the dropdown.
        */

        Algorithm = _Algorithm;
    }

    public void Process(string Content, string Password, bool Decrypting)
    {
        /*
         * Used to have RC2 support, hence the seperation in key generators. 
         * 
         * Might add other features to this kind of key system too.
         * The issue is really the key size won't be correct.
        */

        byte[] Key = Algorithm.Name == "AES" ? KeyGenerator.GenerateKey(Password) : KeyGenerator.GenerateStableKey(Password);

        // Usually occurs with pittyfully weak keys or litterally empty keys.
        if (Key == null)
        {
            MessageBox.Show("Couldn't parse key into hashed key! Try using a diffrent key?");
            return;
        }

        // May fail if you give it an invalid password or file. This is just here as a backup.
        try
        {
            if (Decrypting)
            {
                Save(Algorithm.Decrypt(Content, Key), "All Files (*.*)|*.*");
            }
            else
            {
                Save(Algorithm.Encrypt(Content, Key), "Cryptify Files (*.cryptify)|*.cryptify|All Files (*.*)|*.*");
            }
        }
        catch
        {
            MessageBox.Show("Invalid password or invalid file format!");
        }
    }

    private static void Save( string Content, string Filter )
    {
        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = Filter;
            saveFileDialog.Title = "Save File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, Content);
            }
        }
    }
}