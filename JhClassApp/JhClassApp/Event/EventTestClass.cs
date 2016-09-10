using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JhClass.Event
{
    /// <summary>
    /// 测试自定义事件
    /// 自定义事件需要自定义事件的参数，委托及事件
    /// 在调用时，将方法MakeAlarm注册到事件上
    /// 条件满足时，委托中的方法Heat就会回调注册的方法MakeAlarm
    /// </summary>
    public class EventTestClass
    {
        private CancellationTokenSource _cts;
        //TODO:加入取消加热的方法
        public EventTestClass(CancellationTokenSource cts)
        {

        }

        /// <summary>
        /// 需要将该方法注册到事件中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MakeAlarm(Heater sender, Heater.HeaterEventArgs e)
        {
            Heater heater = sender as Heater;
            string mess = "温度：" + e.temp + "年份：" + e.year + "型号：" + e.HeaterName;
            _cts.Cancel();
            System.Windows.Forms.MessageBox.Show(mess);
        }
    }
}
