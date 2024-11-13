﻿using System;
using System.IO;
using System.Windows.Forms;

namespace Cryptify
{
    public partial class Main : Form
    {
        Engine EncryptionEngine;

        public Main()
        {
            InitializeComponent();

            EncryptionEngine = new Engine( new AES( ) );
        }

        private void FileSelector_Click(object Sender, EventArgs Event)
        {
            var Content = string.Empty;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var Stream = openFileDialog1.OpenFile();

                using (StreamReader Reader = new StreamReader(Stream))
                {
                    Content = Reader.ReadToEnd();
                }

                if (PasswordBox.Text == string.Empty)
                {
                    MessageBox.Show("Password required.");
                    return;
                }

                EncryptionEngine.Process(Content, PasswordBox.Text, openFileDialog1.FileName.EndsWith(".cryptify"));
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            AlgorithmBox.SelectedIndex = 0;
        }

        private void ShowPassword_CheckedChanged(object Sender, EventArgs Event)
        {
            PasswordBox.PasswordChar = ShowPassword.Checked ? '\0' : '*';
        }

        private void Algorithm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            IEncryptionAlgorithm _Algorithm;

            switch (AlgorithmBox.SelectedIndex)
            {
                case 0:
                    _Algorithm = new AES();
                    break;
                case 1:
                    _Algorithm = new dES();
                    break;
                default:
                    _Algorithm = new TripledES();
                    break;
            }

            EncryptionEngine.Algorithm = _Algorithm;
        }
    }
}