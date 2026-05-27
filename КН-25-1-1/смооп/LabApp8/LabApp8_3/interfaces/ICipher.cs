using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp8_3.interfaces
{
    internal interface ICipher
    {
     string Encrypt(string input);
     string Decrypt(string input);
    string Text { get; set; }

    }
}