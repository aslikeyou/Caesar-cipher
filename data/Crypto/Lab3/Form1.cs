namespace Lab3
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private readonly string ALPHABET;

        public Form1()
        {
            InitializeComponent();

            numericUpDown1.Minimum = int.MinValue;
            numericUpDown1.Maximum = int.MaxValue;

            var builder = new StringBuilder(120);
            for (char c = 'a'; c <= 'z'; ++c)
                builder.Append(c);

            for (char c = 'а'; c <= 'я'; ++c)
                builder.Append(c);

            builder.Append('ё');
            builder.Append(' ');
            builder.Append('.');
            builder.Append(',');
            builder.Append('!');
            builder.Append('?');
            ALPHABET = builder.ToString();
        }

        private void OnEncryptBtnClick(object sender, EventArgs e)
        {
            PreProcessText();
            
            var random = new Random(Convert.ToInt32(numericUpDown1.Value));
            var input = inputEncrypt.Text;
            var builder = new StringBuilder(input.Length);

            foreach (var c in input)
            {
                int code = ALPHABET.IndexOf(c);
                int rnd = random.Next(0, ALPHABET.Length);
                int encrypted = code ^ rnd;
                builder.Append(ALPHABET[encrypted]);
            }
            
            outputEncrypt.Text = builder.ToString();
        }

        private void OnDecryptBtnClick(object sender, EventArgs e)
        {
            var random = new Random(Convert.ToInt32(numericUpDown1.Value));
            var input = inputDecrypt.Text;
            var builder = new StringBuilder(input.Length);

            foreach (var c in input)
            {
                int code = ALPHABET.IndexOf(c);
                int rnd = random.Next(0, ALPHABET.Length);
                int encrypted = code ^ rnd;
                builder.Append(ALPHABET[encrypted]);
            }

            outputDecrypt.Text = builder.ToString();
        }

        private void PreProcessText()
        {
            var regex = new Regex(@"[^a-zа-яё\.,!? ]");
            inputEncrypt.Text = regex.Replace(inputEncrypt.Text.ToLower(), "");
        }
    }
}
