using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JhClass.Methods
{
    /// <summary>
    /// 此静态类用于存放扩展方法
    /// </summary>
   public static class MethodExtra
    {
        /// <summary>
        /// 扩展方法,将输入*3
        /// 使用this作为修饰符
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int Triple(this int a)
        {
            return a * 3;
        }
    }
}
