using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JhClass.Methods
{
    public static class MethodsClass
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
