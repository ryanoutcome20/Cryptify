using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

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

    public void SwitchAlgorithm(int Index)
    {
        switch (Index)
        {
            case 0:
                Algorithm = new AES();
                break;
            case 1:
                Algorithm = new dES();
                break;
            default:
                Algorithm = new TripledES();
                break;
        }
    }

    public void Process(string Content, string Password, int Index)
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

        // Check if decrypting or encrypting.
        bool Decrypting = IsDecrypting(Content);

        // May fail if you give it an invalid password or file. This is just here as a backup.
        try
        {
            if (Decrypting)
            {
                Save(Algorithm.Decrypt(Content, Key), "All Files (*.*)|*.*");
            }
            else
            {
                Save(Algorithm.Encrypt(Content, Key), "Cryptify Files (*.cryptify)|*.cryptify|All Files (*.*)|*.*", Index + ":Cryptify\n");
            }
        }
        catch
        {
            MessageBox.Show("Invalid password or invalid file format!");
        }
    }

    private bool IsDecrypting(string Content)
    {
        string[] Header = Content.Split('\n')[0].Split(':');
        
        if(Header.Length != 2 || Header[1] != "Cryptify")
            return false;

        SwitchAlgorithm(Convert.ToInt32(Header[0]));

        return true;
    }

    private static void Save(string Content, string Filter, string Header = "")
    {
        Content = Header + Content;
     
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