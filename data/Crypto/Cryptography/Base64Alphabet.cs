namespace Cryptography
{
    using System;

    public class Base64Alphabet : IAlphabet
    {
        private static readonly char[] mSymbols;

        static Base64Alphabet()
        {
            mSymbols = new char[65];
            int i = 0;

            for (char c = 'A'; c <= 'Z'; ++c, ++i)
                mSymbols[i] = c;

            for (char c = 'a'; c <= 'z'; ++c, ++i)
                mSymbols[i] = c;

            for (char c = '0'; c <= '9'; ++c, ++i)
                mSymbols[i] = c;

            mSymbols[i++] = '+';
            mSymbols[i++] = '/';
            mSymbols[i] = '=';
        }

        public int Length { get { return mSymbols.Length; } }

        public int GetSymbolCode(char symbol)
        {
            return Array.IndexOf(mSymbols, symbol);
        }

        public char GetSymbol(int code)
        {
            return mSymbols[code];
        }
    }
}
