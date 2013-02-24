using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerializersTests
{
    public static class Helper
    {
        private static readonly Random rnd = new Random((int)DateTime.Now.Ticks);

        public static string CreateRandomString(int length)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < length; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rnd.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
