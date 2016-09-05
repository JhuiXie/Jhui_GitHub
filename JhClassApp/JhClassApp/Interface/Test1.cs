using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace JhClass.Interface
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
