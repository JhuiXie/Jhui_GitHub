using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace JhClass.接口
{
    class Test1<Object> : ITest1<Object>
    {
       public string TestIMethod()
        {
            return "T";
        }

        string ITest1<Object>.TestIMethod()
       {
           return "I";
       }
    }
}
