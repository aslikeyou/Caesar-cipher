namespace Cryptography
{
    using System.Text;

    public class CaesarAlgorithmCryptographer : ICryptographer
    {
        private int mKey;

        public CaesarAlgorithmCryptographer(IAlphabet alphabet)
        {
            Alphabet = alphabet;
        }

        public IAlphabet Alphabet { get; private set; }

        public int Key
        {
            get { return mKey; }
            set
            {
                if (value == mKey)
                    return;

                mKey = value;
            }
        }

        public string Encrypt(string data)
        {
            if (mKey == 0)
                return data;

            var length = data.Length;
            var builder = new StringBuilder(length);

            for (int i = 0; i < length; ++i)
            {
                var code = Alphabet.GetSymbolCode(data[i]);
                code += mKey;
                code %= Alphabet.Length;

                if (code < 0)
                    code += Alphabet.Length;

                var symbol = Alphabet.GetSymbol(code);
                builder.Append(symbol);
            }

            return builder.ToString();
        }

        public string Decrypt(string data)
        {
            if (mKey == 0)
                return data;

            var length = data.Length;
            var builder = new StringBuilder(length);

            for (int i = 0; i < length; ++i)
            {
                var code = Alphabet.GetSymbolCode(data[i]);
                code += Alphabet.Length - mKey;
                code %= Alphabet.Length;

                var symbol = Alphabet.GetSymbol(code);
                builder.Append(symbol);
            }

            return builder.ToString();
        }
    }
}
