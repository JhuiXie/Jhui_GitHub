using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace JhClass
{
    /// <summary>
    /// 热水器类
    /// </summary>
   public class Heater
    {
        #region 属性
        /// <summary>
        /// 温度
        /// </summary>
        private int temp = 0;
        /// <summary>
        /// 名称
        /// </summary>
        public string name = "热水器";
        /// <summary>
        /// 制造年份
        /// </summary>
        public int year = 2009;
        #endregion

    

        #region 方法
        /// <summary>
        /// 加热
        /// </summary>
        public void Heat(CancellationToken token)
        {
            for (int i = 0;i <100;i++)
            {
            temp = i;
                //当温度大于95度时，触发事件
                if (temp > 95)
                {
                    HeaterEventArgs e = new HeaterEventArgs(temp, name, year);
                    HeaterEvent(this, e);
                }
            }
        }


        #endregion
        
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
        public delegate void HeaterEventHandler(Heater sender,HeaterEventArgs e);

        /// <summary>
        /// 事件
        /// </summary>
        public event HeaterEventHandler HeaterEvent;


    }
}
