using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JhClass.Delegates
{
    public class DelegateTest : IDisposable
    {
        public DelegateTest()
        {
        }
        /// <summary>
        /// 定义一个委托，该委托的返回类型为string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public delegate string StringDelegate(ref string str);


        /// <summary>
        /// 调用了委托StringDelegate
        /// </summary>
        /// <param name="str"></param>
        /// <param name="testDelegate"></param>
        /// <returns></returns>
        public string delegateUser(string str, StringDelegate testDelegate)
        {
            if (testDelegate != null)
            {
                return testDelegate(ref str);
            }
            else
            {
                return null;
            }
        }

        public void Dispose()
        {

        }
    }
}
