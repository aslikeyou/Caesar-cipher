using System;
using System.Windows.Forms;

namespace TrithemiusDemo
{
    using System.Text;

    public partial class Form1 : Form
    {
        private readonly string ALPHABET;

        public Form1()
        {
            InitializeComponent();

            var builder = new StringBuilder(30);
            for (char c = 'a'; c <= 'z'; ++c)
                builder.Append(c);

            builder.Append(' ');
            ALPHABET = builder.ToString();
        }

        private void OnEncryptBtnClick(object sender, EventArgs e)
        {
            string result = "";

            if (byPosition.Checked)
                result = EncryptByPosition(inputEncrypt.Text);
            else if (byFormula.Checked)
                result = EncryptByFormula(inputEncrypt.Text, Convert.ToInt32(aNum.Value), Convert.ToInt32(bNum.Value));
            else if (byPhrase.Checked)
                result = EncryptByPhrase(inputEncrypt.Text, phraseTextBox.Text);

            outputEncrypt.Text = result;
        }

        private void OnDecryptBtnClick(object sender, EventArgs e)
        {
            string result = "";

            if (byPosition.Checked)
                result = DecryptByPosition(inputDecrypt.Text);
            else if (byFormula.Checked)
                result = DecryptByFormula(inputDecrypt.Text, Convert.ToInt32(aNum.Value), Convert.ToInt32(bNum.Value));
            else if (byPhrase.Checked)
                result = DecryptByPhrase(inputDecrypt.Text, phraseTextBox.Text);

            outputDecrypt.Text = result;
        }

        private string EncryptByPosition(string text)
        {
            var builder = new StringBuilder(text.Length);

            int i = 0;
            foreach (var c in text)
            {
                var code = ALPHABET.IndexOf(c);
                var encryptedCode = (code + i++) % ALPHABET.Length;
                builder.Append(ALPHABET[encryptedCode]);
            }

            return builder.ToString();
        }

        private string EncryptByFormula(string text, int a, int b)
        {
            var builder = new StringBuilder(text.Length);

            int i = 0;
            foreach (var c in text)
            {
                var code = ALPHABET.IndexOf(c);
                var encryptedCode = (code + a * i * i + b * i) % ALPHABET.Length;
                while (encryptedCode < 0)
                    encryptedCode += ALPHABET.Length;

                builder.Append(ALPHABET[encryptedCode % ALPHABET.Length]);
                ++i;
            }

            return builder.ToString();
        }

        private string EncryptByPhrase(string text, string phrase)
        {
            var builder = new StringBuilder(text.Length);

            for (int i = 0, j = 0; i < text.Length; ++i, ++j)
            {
                if (j == phrase.Length)
                    j = 0;
                
                var code = ALPHABET.IndexOf(text[i]);
                var phraseCode = ALPHABET.IndexOf(phrase[j]);
                var encryptedCode = (code + phraseCode) % ALPHABET.Length;
                builder.Append(ALPHABET[encryptedCode]);
            }

            return builder.ToString();
        }

        private string DecryptByPosition(string text)
        {
            var builder = new StringBuilder(text.Length);

            int i = 0;
            foreach (var c in text)
            {
                var code = ALPHABET.IndexOf(c);
                var encryptedCode = (code - i++) % ALPHABET.Length;

                while (encryptedCode < 0)
                    encryptedCode += ALPHABET.Length;

                builder.Append(ALPHABET[encryptedCode % ALPHABET.Length]);
            }

            return builder.ToString();
        }

        private string DecryptByFormula(string text, int a, int b)
        {
            var builder = new StringBuilder(text.Length);

            int i = 0;
            foreach (var c in text)
            {
                var code = ALPHABET.IndexOf(c);
                var encryptedCode = (code - (a * i * i + b * i)) % ALPHABET.Length;

                while (encryptedCode < 0)
                    encryptedCode += ALPHABET.Length;

                builder.Append(ALPHABET[encryptedCode % ALPHABET.Length]);
                ++i;
            }

            return builder.ToString();
        }

        private string DecryptByPhrase(string text, string phrase)
        {
            var builder = new StringBuilder(text.Length);

            for (int i = 0, j = 0; i < text.Length; ++i, ++j)
            {
                if (j == phrase.Length)
                    j = 0;

                var code = ALPHABET.IndexOf(text[i]);
                var phraseCode = ALPHABET.IndexOf(phrase[j]);
                var encryptedCode = (code - phraseCode) % ALPHABET.Length;
                
                while (encryptedCode < 0)
                    encryptedCode += ALPHABET.Length;

                builder.Append(ALPHABET[encryptedCode % ALPHABET.Length]);
            }

            return builder.ToString();
        }
    }
}
