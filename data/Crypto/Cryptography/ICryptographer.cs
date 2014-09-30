namespace Cryptography
{
    public interface ICryptographer
    {
        IAlphabet Alphabet { get; }

        string Encrypt(string data);

        string Decrypt(string data);
    }
}
