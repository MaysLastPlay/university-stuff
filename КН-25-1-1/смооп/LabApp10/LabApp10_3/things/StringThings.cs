using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp10_3.things
{
    internal class StringThings
    {
        public Func<string, string, bool> containsWord => (text, str) => text.Contains(str, StringComparison.OrdinalIgnoreCase);
    }
}
