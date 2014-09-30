namespace Cryptography
{
    using System;

    public class UnicodeAlphabet : IAlphabet
    {
        public int Length { get { return char.MaxValue + 1; } }

        public int GetSymbolCode(char symbol)
        {
            return symbol;
        }

        public char GetSymbol(int code)
        {
            if (code < 0)
                throw new ArgumentOutOfRangeException("code should be greater than zero");

            return (char)(code % char.MaxValue);
        }
    }
}
