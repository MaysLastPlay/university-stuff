using System;
using System.Collections.Generic;
using System.Text;
using LabApp8_3.interfaces;

namespace LabApp8_3.utils
{
    internal class BCipher : ICipher, IComparable<BCipher>
    {
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
                char chars = characters[i];
                if (char.IsLetter(chars))
                {
                    char offset = char.IsUpper(chars) ? 'A' : 'a';
                    characters[i] = (char)(offset + ('Z' - char.ToUpper(chars)));
                    if (char.IsLower(chars)) characters[i] = char.ToLower(characters[i]);
                }

            }
            return new string(characters);
        }

        public string Decrypt(string input) => Encrypt(input);

        public int CompareTo(BCipher other)
        {
            if (other == null) return 1;
            return Text.CompareTo(other?.Text);
        }
    }
}
