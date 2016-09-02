using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JhClass.Method
{
    public static class Methods
    {
        /// <summary>
        /// ref方法
        /// </summary>
        /// <param name="a"></param>
        public static void SetDouble(ref int a)
        {
            a *= 2;
        }
    }
}
