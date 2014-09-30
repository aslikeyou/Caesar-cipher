namespace Lab4
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void OnEncryptBtnClick(object sender, EventArgs e)
        {
            var rnd = new Random();
            var input = inputEncrypt.Text;
            var keyLines = keyTextBox.Lines.Select((str, i) => new { Index = i, Value = str})
                                           .OrderBy(x => rnd.Next()).ToArray();

            var builder = new StringBuilder(input.Length * 4 + input.Length);

            foreach (var c in input)
            {
                bool found = false;
                foreach (var line in keyLines)
                {
                    var colIndex = line.Value.IndexOf(c);

                    if (colIndex < 0)
                        continue;
                    
                    found = true;
                    builder.AppendFormat("{0:D2} {1:D2}, ", line.Index, colIndex);
                    break;
                }

                if (found == false)
                {
                    MessageBox.Show(string.Format(@"Ключ немістить символ '{0}'", c));
                    return;
                }
            }

            builder.Remove(builder.Length - 2, 1);
            outputEncrypt.Text = builder.ToString();
        }

        private void OnDecryptBtnClick(object sender, EventArgs e)
        {
            var input = inputDecrypt.Text;
            var letters = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var keyLines = keyTextBox.Lines;
            var builder = new StringBuilder(letters.Length * sizeof(char));
            var splitArr = new[]{ ' ' };

            foreach (var letter in letters)
            {
                var indexes = letter.Split(splitArr, StringSplitOptions.RemoveEmptyEntries);
                var row = int.Parse(indexes[0]);
                var col = int.Parse(indexes[1]);
                builder.Append(keyLines[row][col]);
            }

            outputDecrypt.Text = builder.ToString();
        }
    }
}
