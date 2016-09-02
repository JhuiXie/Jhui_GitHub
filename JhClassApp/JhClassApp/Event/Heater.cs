using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JhClass
{
    class Heater
    {
        private int temp = 0;
        public string name = "热水器";
        public int year = 2009;
        
        /// <summary>
        /// 加热方法
        /// </summary>
        public void heat()
        {
            for (int i = 0;i <100;i++)
            {
            temp = i;
                if (temp > 95)
                {
                    HeaterEventArgs e = new HeaterEventArgs(temp, name, year);
                    HeaterEvent(this, e);
                }
            }
        }

        /// <summary>
        /// 事件参数
        /// </summary>
        public class HeaterEventArgs:EventArgs
        {
            public readonly int temp;
            public readonly string HeaterName;
            public readonly int year;
            public HeaterEventArgs(int temp, string name, int year)
            {
                this.temp = temp;
                this.HeaterName = name;
                this.year = year;
            }
        }
        /// <summary>
        /// 委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void HeaterEventHandler(object sender,HeaterEventArgs e);
        /// <summary>
        /// 事件
        /// </summary>
        public event HeaterEventHandler HeaterEvent;


    }
}
