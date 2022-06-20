using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject
{
    internal static class IntExtention
    {
        public static int ToInt(this string number)
        {
            return Convert.ToInt32(number);
        }

        public static int ToInt(this bool b)
        {
            return b ? 1 : 0;
        }
    }
}
