using System;
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

        #endregion 属性

        #region 方法

        /// <summary>
        /// 加热方法
        /// 用多线程调用时，可以异步终止该方法
        /// </summary>
        /// <param name="token">用来传递取消操作的通知</param>
        public void Heat(CancellationToken token)
        {
            for (int i = 0; i < 100; i++)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }
                temp = i;
                //当温度大于75度时，触发事件
                if (temp > 75)
                {
                    HeaterEventArgs e = new HeaterEventArgs(temp, name, year);
                    HeaterEvent(this, e);
                }
            }
        }

        #endregion 方法

        /// <summary>
        /// 事件参数
        /// </summary>
        public class HeaterEventArgs : EventArgs
        {
            public readonly int HeaterTemp;
            public readonly string HeaterName;
            public readonly int HeaterYear;

            public HeaterEventArgs(int temp, string name, int year)
            {
                HeaterTemp = temp;
                HeaterName = name;
                HeaterYear = year;
            }
        }

        /// <summary>
        /// 委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void HeaterEventHandler(Heater sender, HeaterEventArgs e);

        /// <summary>
        /// 事件
        /// </summary>
        public event HeaterEventHandler HeaterEvent;
    }
}