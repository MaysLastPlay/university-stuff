using System;
using System.Collections.Generic;
using System.Text;
using LabApp8_3.interfaces;

namespace LabApp8_3.utils
{
    internal class BCipher : ICipher, IComparable<BCipher>
    {
        private const int key = 1;
        private const int alphabet = 26;
        private int length;

        public string Text { get; set; }

        public BCipher(string text)
        {
            Text = text;
        }

        public BCipher(int length)
        {
            this.length = length;
        }

        public string Encrypt(string input)
        {
            char[] characters = input.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                if (!char.IsLetter(characters[i])) continue;
                char offset = char.IsUpper(characters[i]) ? 'A' : 'a';
                characters[i] = (char)((characters[i] - offset + key) % 26 + offset);
            }
            return new string(characters);
        }

        public string Decrypt(string input)
        {
            char[] characters = input.ToCharArray();

            for (int i = 0; i < characters.Length; i++)
            {
                if (!char.IsLetter(characters[i])) continue;
                char offset = char.IsUpper(characters[i]) ? 'A' : 'a';

                characters[i] = (char)((characters[i] - offset - key + alphabet) % alphabet + offset);
            }

            return new string(characters);
        }

        public int CompareTo(BCipher other)
        {
            if (other == null) return 1;
            return Text.CompareTo(other?.Text);
        }
    }
}
