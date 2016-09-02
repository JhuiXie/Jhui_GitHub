using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace JhClass
{
    class EventClass
    {
        /// <summary>
        /// 自定义公开事件
        /// </summary>
        internal class NewMailEventArgs : EventArgs
        {
            private readonly string m_from, m_to, m_subject;

            public NewMailEventArgs(string from, string to, string subject)
            {
                m_from = from;
                m_to = to;
                m_subject = subject;
            }
            public string From { get { return m_from; } }
            public string To { get { return m_to; } }
            public string Subject { get { return m_subject; } }
        }

        public  class MailManager
        {
            //定义事件成员
            public event EventHandler<NewMailEventArgs> NewMail;

            //定义一个引发事件的方法，通知已登记的对象
            protected virtual void OnNewMail(NewMailEventArgs e)
            {
                //出于线程安全考虑，现在将对委托字段的引用复制到一个临时字段中
                //EventHandler<EventArgs> temp = Interlocked.CompareExchange(ref NewMail, null, null);
                EventHandler<NewMailEventArgs> temp = NewMail;

                //任何方法登记了对事件的关注，就通知它们
                if (temp != null)
                {
                    temp(this, e);
                }
            }

            //定义一个方法，将输入转化为期望事件
            public  void SimulateNewMail(string from, string to, string subject)
            {
                NewMailEventArgs e = new NewMailEventArgs(from, to, subject);

                OnNewMail(e);
            }
        }
    }
}
