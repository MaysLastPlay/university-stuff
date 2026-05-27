using System;
using System.Collections.Generic;
using System.Text;
using LabApp8_3.utils;

namespace LabApp8_3
{
    internal class TestClass
    {
        public static void CipherTest()
        {
         string[] text = { "Awawawawawa", "Bwbwbwbwbwb", "Cxcxcxcxcxc" };
         ACipher aCipher = new ACipher(text.Length);
         BCipher bCipher = new BCipher(text.Length);

        for (int i = 0; i < text.Length; i++)
            {
                aCipher.Text = text[i];
                bCipher.Text = text[i];
                Console.WriteLine($"Original Text: {text[i]}");
                Console.WriteLine($"ACipher Encrypted: {aCipher.Encrypt(text[i])}");
                Console.WriteLine($"ACipher Decrypted: {aCipher.Decrypt(aCipher.Encrypt(text[i]))}");
                Console.WriteLine($"BCipher Encrypted: {bCipher.Encrypt(text[i])}");
                Console.WriteLine($"BCipher Decrypted: {bCipher.Decrypt(bCipher.Encrypt(text[i]))}");
                Console.WriteLine();
            }
        }
    }
}
