namespace DESDemo
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private readonly DESCryptoServiceProvider mCryptic = new DESCryptoServiceProvider();

        public Form1()
        {
            InitializeComponent();
        }

        private void OnEncryptBtnClick(object sender, EventArgs e)
        {
            try
            {
                mCryptic.Key = Encoding.ASCII.GetBytes(keyTextBox.Text);
                mCryptic.IV = Encoding.ASCII.GetBytes(vectorTextBox.Text);

                using (var stream = new MemoryStream())
                {
                    using (var crypto = new CryptoStream(stream, mCryptic.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (var writer = new StreamWriter(crypto))
                        {
                            writer.Write(inputEncrypt.Text);
                        }
                    }

                    var bytes = stream.ToArray();
                    outputEncrypt.Text = Convert.ToBase64String(bytes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnDecryptBtnClick(object sender, EventArgs e)
        {
            try
            {
                mCryptic.Key = Encoding.ASCII.GetBytes(keyTextBox.Text);
                mCryptic.IV = Encoding.ASCII.GetBytes(vectorTextBox.Text);
                var bytes = Convert.FromBase64String(inputDecrypt.Text);

                using (var stream = new MemoryStream(bytes))
                {
                    using (var crypto = new CryptoStream(stream, mCryptic.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (var reader = new StreamReader(crypto))
                        {
                            outputDecrypt.Text = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
