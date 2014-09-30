using System;
using System.Windows.Forms;

namespace Crypto
{
    using System.Text;

    using Cryptography;

    public partial class Form1 : Form
    {

        private readonly CaesarAlgorithmCryptographer mCrypto = new CaesarAlgorithmCryptographer(new UnicodeAlphabet());

        public Form1()
        {
            InitializeComponent();

            numericUpDown1.Maximum = int.MaxValue;
            numericUpDown1.Minimum = int.MinValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var encoding = Encoding.Unicode;
            var bytes = encoding.GetBytes(textBox1.Text);
            var base64 = Convert.ToBase64String(bytes);
            var encoded = mCrypto.Encrypt(base64);
            var decoded = mCrypto.Decrypt(encoded);

            bytes = Convert.FromBase64String(decoded);
            var origin = encoding.GetString(bytes);
            
            textBox2.Text = base64;
            textBox3.Text = encoded;
            textBox4.Text = origin;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            mCrypto.Key = Convert.ToInt32(numericUpDown1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var builder = new StringBuilder(10000);
            var alphaLength = mCrypto.Alphabet.Length;
            var encoding = Encoding.Unicode;
            var encoded = textBox3.Text;
            var crypto = new CaesarAlgorithmCryptographer(new UnicodeAlphabet());

            for (int i = 0; i < alphaLength; ++i)
            {
                crypto.Key = i;
                var decoded = crypto.Decrypt(encoded);

                try
                {
                    var bytes = Convert.FromBase64String(decoded);
                    var origin = encoding.GetString(bytes);

                    builder.Append(i);
                    builder.Append(": ");
                    builder.Append(decoded);
                    builder.Append(" --- ");
                    builder.AppendLine(origin);
                }
                catch (Exception ex)
                {
                    
                }
            }

            textBox5.Text = builder.ToString();
        }
    }
}
