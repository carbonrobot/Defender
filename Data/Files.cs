namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Files
    {
        public static IEnumerable<string> GetNames()
        {
            return new string[] { "Secure File A", "Secure File B" };
        }
    }
}