namespace Cryptography
{
    public interface IAlphabet
    {
        int Length { get; }

        int GetSymbolCode(char symbol);

        char GetSymbol(int code);
    }
}
