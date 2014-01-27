using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Files
    {
        public static IEnumerable<string> GetNames()
        {
            return new string[] { "Secure File A", "Secure File B" };
        }
    }
}
