using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp10_3.things
{
    internal static class StringThings
    {
        public static Func<string, string, bool> containsWord => (text, str) => text.Contains(str, StringComparison.OrdinalIgnoreCase);
    }
}
