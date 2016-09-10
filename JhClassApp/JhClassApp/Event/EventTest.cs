using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JhClass.Event
{
    /// <summary>
    /// 热水器的测试自定义事件测试
    /// 自定义事件需要自定义事件的参数，委托及事件
    /// 在调用时，将方法MakeAlarm注册到事件上
    /// 条件满足时，委托中的方法Heat就会回调注册的方法MakeAlarm
    /// </summary>
    public class HeaterEventTestClass
    {
        /// <summary>
        /// 用来传递取消操作的通知
        /// </summary>
        private CancellationTokenSource _cts;
        public HeaterEventTestClass(CancellationTokenSource cts)
        {
            _cts = cts;
        }

        /// <summary>
        /// 需要将该方法注册到事件中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MakeAlarm(Heater sender, Heater.HeaterEventArgs e)
        {
            string mess = "温度：" + e.HeaterTemp + "年份：" + e.HeaterYear + "型号：" + e.HeaterName;
            //终止所有由_cts接收取消通知的方法(需要在方法内写相应的终止代码)
            _cts.Cancel();
            System.Windows.Forms.MessageBox.Show(mess);
        }
    }
}
