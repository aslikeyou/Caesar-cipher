using System.Windows.Forms;

namespace CaesarDemo
{
    using System;
    using System.Text;
    using System.Threading.Tasks;

    using Cryptography;

    public partial class MainForm : Form
    {
        #region Fields

        private readonly IAlphabet mBase64Alphabet = new UnicodeAlphabet();

        private readonly CaesarAlgorithmCryptographer mCaesar;

        private readonly CaesarAlgorithmCryptographer mDecrypter;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();

            mCaesar = new CaesarAlgorithmCryptographer(mBase64Alphabet);
            mDecrypter = new CaesarAlgorithmCryptographer(mBase64Alphabet);
        }

        #endregion

        #region Methods

        private void OnLoad(object sender, System.EventArgs e)
        {
            numericUpDown1.Maximum = int.MaxValue;
            numericUpDown1.Minimum = int.MinValue;
        }

        private void OnEncode(object sender, EventArgs e)
        {
            try
            {
                toolStripProgressBar1.Visible = true;

                //var encoding = Encoding.Unicode;
                //var bytes = encoding.GetBytes(textBox1.Text);
                //var base64 = Convert.ToBase64String(bytes);
                var encoded = mCaesar.Encrypt(textBox1.Text);
                var decoded = mCaesar.Decrypt(encoded);

                //bytes = Convert.FromBase64String(decoded);
                //var origin = encoding.GetString(bytes);

                //textBox2.Text = base64;
                textBox3.Text = encoded;
                //textBox4.Text = origin;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                toolStripProgressBar1.Visible = false;
            }
        }

        private async void OnTryDecrypt(object sender, EventArgs e)
        {
            try
            {
                toolStripProgressBar1.Visible = true;

                var encoded = textBox3.Text;
                textBox5.Text = await Task.Run(() => Decrypt(encoded));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                toolStripProgressBar1.Visible = false;
            }
        }

        private void OnKeyValueChanged(object sender, EventArgs e)
        {
            mCaesar.Key = Convert.ToInt32(numericUpDown1.Value);
        }

        private string Decrypt(string encoded)
        {
            var builder = new StringBuilder(10000);
            var alphaLength = mBase64Alphabet.Length;
            var encoding = Encoding.Unicode;

            for (int i = 0; i < alphaLength; ++i)
            {
                mDecrypter.Key = i;
                var decoded = mDecrypter.Decrypt(encoded);

                try
                {
                    //var bytes = Convert.FromBase64String(decoded);
                    //var origin = encoding.GetString(bytes);

                    builder.Append(i);
                    builder.Append(": ");
                    builder.AppendLine(decoded);
                    //builder.Append(" --- ");
                    //builder.AppendLine(origin);
                }
                catch
                {
                }
            }

            return builder.ToString();
        }

        #endregion
    }
}
