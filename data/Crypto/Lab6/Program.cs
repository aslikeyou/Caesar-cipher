namespace Lab6
{
    using System;
    using System.Security.Cryptography;

    static class Program
    {
        static void Main()
        {
            var aliceCngKey = CngKey.Create(CngAlgorithm.ECDiffieHellmanP256);
            var alicePublicKey = aliceCngKey.Export(CngKeyBlobFormat.EccPublicBlob);

            var bobCngKey = CngKey.Create(CngAlgorithm.ECDiffieHellmanP256);
            var bobPublicKey = bobCngKey.Export(CngKeyBlobFormat.EccPublicBlob);

            var aliceAlgo = new ECDiffieHellmanCng(aliceCngKey);
            var aliceKey = aliceAlgo.DeriveKeyMaterial(bobCngKey);

            var alicePubCngKey = CngKey.Import(alicePublicKey, CngKeyBlobFormat.EccPublicBlob);
            var bobAlgo = new ECDiffieHellmanCng(bobCngKey);
            var bobKey = bobAlgo.DeriveKeyMaterial(alicePubCngKey);

            Console.WriteLine("Alice key:");
            foreach (var b in aliceKey)
                Console.Write("0x{0:X} ", b);
            Console.WriteLine();

            Console.WriteLine("Bob key:");
            foreach (var b in bobKey)
                Console.Write("0x{0:X} ", b);
            Console.WriteLine();
        }
    }
}
