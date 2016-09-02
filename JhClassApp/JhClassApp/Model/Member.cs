using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JhClass
{
    /// <summary>
    /// 会员
    /// </summary>
    public class Member
    {
        private string _name;
        private int _age;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Nage
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age
        {
            get { return _age; }
            set
            {
                if (value > 0)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Age", value, "年龄不能小于1。");
                }
            }
        }
    }
}
